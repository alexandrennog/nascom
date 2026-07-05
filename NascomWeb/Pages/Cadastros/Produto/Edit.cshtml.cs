using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Produto;

public class GradeLinhaView
{
    public int Item { get; set; }
    public Dictionary<string, string> Valores { get; } = new();
}

public class EditModel : PageModel
{
    private readonly ProdutoApiClient _produtoClient;
    private readonly ProdutoTipoCaracteristicaApiClient _vinculoClient;
    private readonly CaracteristicaItemApiClient _itemClient;
    private readonly CrudApiClientFactory _factory;

    public EditModel(ProdutoApiClient produtoClient, ProdutoTipoCaracteristicaApiClient vinculoClient, CaracteristicaItemApiClient itemClient, CrudApiClientFactory factory)
    {
        _produtoClient = produtoClient;
        _vinculoClient = vinculoClient;
        _itemClient = itemClient;
        _factory = factory;
    }

    [BindProperty]
    public dProduto Dados { get; set; } = new() { situacao = "A" };

    [BindProperty]
    public Dictionary<string, string> NovaLinhaValores { get; set; } = new();

    [BindProperty]
    public string? NovaLinhaCodigoBarras { get; set; }

    [BindProperty]
    public decimal? NovaLinhaEstoque { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Tab { get; set; } = "dados";

    public List<dProdutoTipo> ProdutoTipos { get; set; } = new();
    public List<dFornecedor> Fornecedores { get; set; } = new();
    public List<dFabricante> Fabricantes { get; set; } = new();
    public List<dCor> Cores { get; set; } = new();
    public List<dGrupo> Grupos { get; set; } = new();
    public List<dProdutoTipoCaracteristica> CaracteristicasDoTipo { get; set; } = new();
    public Dictionary<string, List<dCaracteristicaItem>> ItensPorCaracteristica { get; set; } = new();
    public List<GradeLinhaView> Linhas { get; set; } = new();

    public bool ProdutoJaSalvo => Dados.cid is int cid && cid > 0;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        await CarregarListasApoioAsync();

        if (id is int cid && cid > 0)
        {
            var existente = await _produtoClient.ConsultarPorCidAsync(cid);
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
            await CarregarGradeAsync(cid);
        }

        return Page();
    }

    public async Task<IActionResult> OnPostDadosAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.descricao))
            ModelState.AddModelError("Dados.descricao", "É necessário informar a Descrição.");
        if (Dados.produtoTipo_cid is null or 0)
            ModelState.AddModelError("Dados.produtoTipo_cid", "É necessário selecionar o Tipo de Produto.");

        if (!ModelState.IsValid)
        {
            await CarregarListasApoioAsync();
            if (ProdutoJaSalvo) await CarregarGradeAsync(Dados.cid!.Value);
            return Page();
        }

        var usuario = ObterUsuarioLogado();

        if (Dados.cid is null or 0)
        {
            var novoCid = await _produtoClient.IncluirCompletoAsync(Dados, new List<List<dProdutoItem>>(), usuario);
            TempData["Mensagem"] = "Produto incluído com sucesso.";
            return RedirectToPage(new { id = novoCid, tab = "dados" });
        }

        var gradeAtual = await CarregarGradeAgrupadaAsync(Dados.cid.Value);
        await _produtoClient.AlterarCompletoAsync(Dados, gradeAtual, usuario);
        TempData["Mensagem"] = "Produto alterado com sucesso.";
        return RedirectToPage(new { id = Dados.cid, tab = "dados" });
    }

    public async Task<IActionResult> OnPostAdicionarLinhaAsync(int id)
    {
        var produtoAtual = await _produtoClient.ConsultarPorCidAsync(id);
        if (produtoAtual == null) return RedirectToPage("Index");

        var grupos = await CarregarGradeAgrupadaAsync(id);
        var proximoItem = grupos.SelectMany(g => g).Select(i => i.item ?? 0).DefaultIfEmpty(0).Max() + 1;

        var novaLinha = new List<dProdutoItem>();
        foreach (var (codigo, valor) in NovaLinhaValores)
        {
            if (string.IsNullOrWhiteSpace(valor)) continue;
            novaLinha.Add(new dProdutoItem { produtos_cid = id, item = proximoItem, caracteristicas_codigo = codigo, valor = valor });
        }
        novaLinha.Add(new dProdutoItem { produtos_cid = id, item = proximoItem, caracteristicas_codigo = "estoque", valor = (NovaLinhaEstoque ?? 0).ToString() });
        novaLinha.Add(new dProdutoItem { produtos_cid = id, item = proximoItem, caracteristicas_codigo = "codigobarras", valor = NovaLinhaCodigoBarras ?? string.Empty });

        grupos.Add(novaLinha);

        await _produtoClient.AlterarCompletoAsync(produtoAtual, grupos, ObterUsuarioLogado());
        TempData["Mensagem"] = "Variação de grade adicionada com sucesso.";
        return RedirectToPage(new { id, tab = "grade" });
    }

    public async Task<IActionResult> OnPostRemoverLinhaAsync(int id, int item)
    {
        var produtoAtual = await _produtoClient.ConsultarPorCidAsync(id);
        if (produtoAtual == null) return RedirectToPage("Index");

        var grupos = await CarregarGradeAgrupadaAsync(id);
        grupos.RemoveAll(g => g.Count > 0 && g[0].item == item);

        await _produtoClient.AlterarCompletoAsync(produtoAtual, grupos, ObterUsuarioLogado());
        TempData["Mensagem"] = "Variação de grade removida com sucesso.";
        return RedirectToPage(new { id, tab = "grade" });
    }

    private async Task<List<List<dProdutoItem>>> CarregarGradeAgrupadaAsync(int produtoCid)
    {
        var linhas = await _produtoClient.ConsultarGradePorProdutoAsync(produtoCid);
        return linhas
            .GroupBy(l => l.item ?? 0)
            .Select(g => g.ToList())
            .ToList();
    }

    private async Task CarregarGradeAsync(int produtoCid)
    {
        var linhasFlat = await _produtoClient.ConsultarGradePorProdutoAsync(produtoCid);
        Linhas = linhasFlat
            .GroupBy(l => l.item ?? 0)
            .Select(g =>
            {
                var linha = new GradeLinhaView { Item = g.Key };
                foreach (var eav in g)
                    linha.Valores[eav.caracteristicas_codigo ?? string.Empty] = eav.valor ?? string.Empty;
                return linha;
            })
            .OrderBy(l => l.Item)
            .ToList();

        if (Dados.produtoTipo_cid is int tipoCid && tipoCid > 0)
        {
            CaracteristicasDoTipo = await _vinculoClient.ConsultarPorProdutoTipoAsync(tipoCid);

            foreach (var c in CaracteristicasDoTipo)
            {
                if (c.caracteristica_cid is not int caracteristicaCid || c.caracteristica_codigo is not { } codigo) continue;
                if (codigo is "estoque" or "codigobarras") continue;

                var itens = await _itemClient.ConsultarPorCaracteristicaAsync(caracteristicaCid);
                if (itens.Count > 0) ItensPorCaracteristica[codigo] = itens;
            }
        }
    }

    private async Task CarregarListasApoioAsync()
    {
        ProdutoTipos = await _factory.Create<dProdutoTipo>("ProdutoTipo").ListarAsync();
        Fornecedores = await _factory.Create<dFornecedor>("Fornecedor").ListarAsync();
        Fabricantes = await _factory.Create<dFabricante>("Fabricante").ListarAsync();
        Cores = await _factory.Create<dCor>("Cor").ListarAsync();
        Grupos = await _factory.Create<dGrupo>("Grupo").ListarAsync();
    }

    private dUsuario ObterUsuarioLogado()
    {
        var cidStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return new dUsuario
        {
            cid = int.TryParse(cidStr, out var cid) ? cid : null,
            usuario = User.FindFirst("login_usuario")?.Value ?? string.Empty,
            nomeCompleto = User.Identity?.Name ?? string.Empty
        };
    }
}
