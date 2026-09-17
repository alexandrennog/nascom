# Relatório de Alterações — Nascomercio

## 17/09/2026 — Unificação da Curva ABC e novo Painel de Compras

**Motivação:** retorno da cliente (áudio) reclamando que os relatórios não respondem direto perguntas como "qual marca mais vendeu", "quantos pares por marca" (faltava soma) e "o que preciso comprar mais". Investigando o relatório de Curva ABC por Fabricante que já existia, apareceram dois problemas de fundo — corrigidos aqui — e a partir da correção deu pra construir a tela que ela pediu.

**Escopo:** `ncDados`, `ncPersistencia`, `ncRegras`, `nascomercio` + 2 scripts novos de banco.

### Problemas encontrados na Curva ABC por Fabricante (já existente)

1. O script `36 - sp_curva_abc_fornecedores_quantidade.sql` era uma cópia literal do script `35` (variante "Valor") — recriava a mesma procedure `sp_curva_abc_fornecedores`, sem nunca implementar a agregação por quantidade. O botão "Quantidade" do relatório de Curva ABC (`fRelatorioVendasABC.vb`) muito provavelmente falhava ou repetia o cálculo de valor.
2. As duas procedures liam o resultado de tabelas `ranking_resultado_valor` / `ranking_resultado_quantidade` que **não existem em nenhum script versionado** (a procedure só devolve um `SELECT` direto e depois derruba suas tabelas temporárias). Precisa confirmar contra o banco real se essas tabelas foram criadas manualmente em alguma loja em algum momento.
3. A chamada dessas procedures em `pVenda.ListarVendasABC` usava interpolação direta de string no `CALL` (`$"call sp_curva_abc_fornecedores('{dataIni}','{dataFim}')"`) — mesma família do problema de SQL injection já registrado em 31/08.
4. Existia ainda uma **segunda implementação de Curva ABC**, órfã: `sp_curva_abc` (script `33`), por referência/produto, já cruzando com estoque (`v_estoque`) — mais completa que a usada no relatório, mas nunca chamada de lugar nenhum no VB.

### O que foi mudado

1. **`scripts/37 - curva_abc_unificada.sql`** — nova procedure `sp_curva_abc_por_fabricante`, que reaproveita o cálculo de `sp_curva_abc` (mesma base, sem duplicar lógica) e só agrupa por fabricante. Cria a tabela `curva_abc_fabricante` e remove as duas procedures antigas (`sp_curva_abc_fornecedores` e a variante quebrada `_quantidade`).
2. **`ncPersistencia/pVenda.vb`** — `ListarVendasABC` agora chama `sp_curva_abc_por_fabricante`, com as datas sempre passando por `PersistirData` (nunca concatenadas cruas) e `tipo` restrito a `'V'`/`'Q'` — fecha a brecha de SQL injection do item 3.
3. **`scripts/38 - dashboard_compras.sql`** — duas procedures novas: `sp_dashboard_compras_resumo` (ticket médio, faturamento total, marca campeã em valor e em quantidade) e `sp_dashboard_compras_reposicao` (reaproveita `sp_curva_abc` em quantidade e lista os itens classe A/B com estoque baixo em relação ao vendido — heurística inicial, dá pra refinar depois).
4. **Painel de Compras (tela nova)** — `nascomercio/relatorio/fPainelCompras.vb` (+ `.Designer.vb`, `.resx`), com as camadas `ncDados/dDashboardCompras.vb`, `ncPersistencia/pDashboardCompras.vb` e `ncRegras/rDashboardCompras.vb`. Mostra de cara: faturamento, ticket médio, quantidade de vendas, marca campeã (valor e quantidade) e uma lista do que vender bem e está com pouco estoque — a ideia de "bater o olho e entender" que a cliente pediu.
5. **`mdiPrincipal.vb`** — novo `Sub CarregarPainelCompras()`, no mesmo padrão de `CarregarRelVendasABC()`.

### Revisão do mesmo dia — 3 bugs encontrados e corrigidos antes de qualquer teste

Como pedido, revisei com calma tudo que tinha acabado de escrever acima (sem poder compilar — ver "Pendente" abaixo). Apareceram 3 problemas reais, todos já corrigidos nos arquivos:

1. **Nome de coluna errado em `pVenda.ListarVendasABC`** — o código lia `row("data_inicio")`/`row("data_fim")`, mas a procedure nova (`sp_curva_abc_por_fabricante`) devolve `periodo_inicio`/`periodo_fim`. Ia estourar exceção ("coluna não existe") assim que a tela de Curva ABC fosse aberta. Corrigido.
2. **Datas viravam `NULL` silenciosamente** em `pVenda.ListarVendasABC` e em `pDashboardCompras` (resumo e reposição) — usei `cFuncoes.PersistirData` do mesmo jeito que o resto do sistema já faz, mas essa função espera o texto cru da tela (com "/"), e eu já tinha passado o valor por `cFuncoes.FormatarData` antes (necessário pra bater com o padrão de `fRelatorioVendasABC.vb`). Encadear as duas devolve `NULL` pros dois parâmetros de data — a consulta rodaria, só que sempre com **zero resultados**, sem erro nenhum aparecer. É o tipo de bug que só aparece meses depois quando alguém percebe que o relatório "nunca mostra nada". Troquei por uma função nova e isolada (`DataSqlSegura`) que já recebe o formato certo e não depende do comportamento (inconsistente) de `FormatarData`.
3. **Resultset errado ao chamar procedure aninhada** — esse foi o mais sério dos três. `sp_curva_abc_por_fabricante` e `sp_dashboard_compras_reposicao` fazem `CALL sp_curva_abc(...)` por dentro delas mesmas, e `sp_curva_abc` termina com um `SELECT` próprio. O MySQL manda esse `SELECT` interno pro cliente como um resultset **separado**, antes do resultset final da procedure que chamou — então `ds.Tables(0)` (que é o que o código lia) pegava o resultado errado (colunas de produto, não de fabricante/reposição), e a tela quebraria com "coluna X não existe" assim que fosse aberta. Corrigido lendo sempre o **último** resultset (`ds.Tables(ds.Tables.Count - 1)`) em vez do primeiro, nos dois pontos afetados.

Também conferi: os 4 `.vbproj` (bem formados, sem entrada duplicada), as duas SQL novas (33/37/38 quanto a escopo de tabela temporária — sem conflito de nome entre a procedure interna e a externa) e o `fPainelCompras.vb` batendo certinho com os nomes de controle do `.Designer.vb`. Também reforcei a estrutura do `.Designer.vb` (3 painéis que dividiam a mesma borda `Dock=Top` viraram um `TableLayoutPanel` com posição explícita por linha) — não achei confirmação de que isso quebraria, mas a forma antiga dependia de uma regra de empilhamento que eu não conseguia validar sem abrir o designer, então preferi eliminar a ambiguidade.

### Botão de menu do Painel de Compras (adicionado depois)

Acrescentei o item que tinha ficado pendente: novo radio button "Painel de Compras" na tela de Relatórios (`fRelatorio.vb`/`fRelatorio.Designer.vb`), no mesmo padrão dos demais (`ElseIf rbtPainelCompras.Checked Then mdiPrincipal.CarregarPainelCompras()`). Não precisa mais abrir o designer manualmente pra isso.

### Correção de acentuação em `fRelatorio.Designer.vb`

Ao testar a tela de Relatórios você reportou "erros nos nomes" — 11 textos já vinham com o acento quebrado (caractere inválido no lugar do acento), problema pré-existente, não relacionado a nenhuma mudança desta sessão: "Relatórios", "Crediário" (2x), "Usuário", "Sintético", "Escrituração", "Eletrônica", "Transferências", "Redução", "Balanço", "Cobrança Crediário". Corrigidos.

### Testes reais na sua máquina — mais 2 bugs de execução encontrados e corrigidos

Depois de compilar e testar de verdade (prints da tela rodando + debugger do Visual Studio), apareceram dois problemas que não tinham como ser vistos só lendo o código sem compilar:

1. **Curva ABC: `MissingMethodException` em `ExecutarDSLongo`** — ao abrir o relatório, estourava "Método não encontrado" em `ncComum.nsAcessoBD.cAcessoBD.ExecutarDSLongo(String, MySqlParameterCollection, Int32?)". O método existe no código-fonte e as DLLs estavam com build fresco — não era um esquecimento. A causa é a mesma fragilidade já registrada na auditoria de pacotes (ver seção "Auditoria de arquivos órfãos" mais abaixo): `ncComum.vbproj` e `ncPersistencia.vbproj` referenciam **versões diferentes do `MySql.Data.dll`**. Assim que uma chamada entre esses dois projetos usa um tipo do MySQL Connector (`MySqlParameterCollection`) na própria assinatura do método, o .NET não reconhece o método em tempo de execução, mesmo compilando sem erro — apesar do parâmetro sempre ter sido `Nothing` nesse caso. **Correção:** criei uma sobrecarga `ExecutarDSLongo(comandoSQL As String, timeoutSegundos As Integer?)` em `ncComum/acessobd.vb`, sem nenhum tipo do MySql.Data na assinatura vista de fora — o mesmo motivo por que `ExecutarDS(comandoSQL)` (1 parâmetro) sempre funcionou entre esses projetos. Ajustei as 3 chamadas afetadas (`pVenda.ListarVendasABC` e as duas de `pDashboardCompras`) para usar essa sobrecarga nova. **Não mexi em nenhuma referência de `MySql.Data.dll`, `componentes\` ou string de conexão** — a causa raiz (as 3 versões diferentes do conector) continua exatamente como estava, só evitei que ela afete essa chamada específica.
2. **Painel de Compras: `NullReferenceException` logo no `Load`** — a tela quebrava na primeira linha do evento `Load` (`Me.txtDataInicial.Text = ...`), porque `txtDataInicial` (e todos os outros controles) nunca chegavam a ser criados. Faltava no topo de `fPainelCompras.Designer.vb` o atributo `<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>` que toda tela do sistema tem (é ele que faz o VB chamar `InitializeComponent()` automaticamente no construtor, mesmo sem um `Sub New()` explícito — confirmei comparando com `fRelatorio.Designer.vb`, que tem o atributo e funciona). Corrigido acrescentando o atributo que faltava.

**Observação à parte, não corrigida:** durante os testes também apareceu um `DirectoryNotFoundException` ao gerar SPED (`fSPEDForm.vb`, pasta `arquivos_sped` não existe em `bin\Debug`). Esse bug é pré-existente, não tem nenhuma relação com Curva ABC/Painel de Compras e não foi tocado nesta sessão — fica registrado aqui só porque apareceu no mesmo teste. Aviso se quiser que eu olhe isso também.

### Pendente antes de ir pra produção

- **Recompilar depois destas últimas correções** (o `MissingMethodException` e o `NullReferenceException` acima foram corrigidos depois do build que você testou) e reabrir Curva ABC e Painel de Compras pra confirmar que os dois abrem sem erro agora.
- **Rodar os scripts 37 e 38 no MySQL de cada loja** antes de usar (mesmo processo dos scripts anteriores).
- Confirmar contra o banco real se as tabelas `ranking_resultado_valor/quantidade` existem (item 2 acima) — se existirem, dá pra apagar depois que a versão nova estiver validada.
- A heurística de "estoque baixo" no Painel de Compras (`estoque_atual <= 20% do vendido no período`) é um primeiro corte — vale validar com a cliente se faz sentido antes de vender como resposta definitiva pra ela.
- Mesma limitação de concorrência que `sp_curva_abc` já tinha: se dois terminais rodarem a Curva ABC ou o Painel de Compras ao mesmo tempo na mesma loja, um pode ver o resultado do outro pela metade (tabela de resultado compartilhada com `TRUNCATE`). Não é novo, mas não foi resolvido aqui.

---

## 13/09/2026 — Filtro de período no relatório de Grade (Entrada e Venda)

**Escopo:** nova funcionalidade no relatório Relatórios > Grade, mais correções incidentais de build e de acentuação encontradas no processo (`nascomercio`, `ncDados`, `ncPersistencia`, `ncRegras`).

### O que foi mudado

1. **Filtro de período "Entrada de: / ate:"** — dois campos de data novos na tela do relatório de Grade, no mesmo padrão visual do relatório de Estoque. Quando preenchidos, o relatório passa a **somar todas as entradas de estoque** (`logestoque`) dentro do período, por produto/tamanho, em vez de mostrar só a entrada mais recente. Com os campos em branco, o comportamento é **idêntico ao original** (mostra só a última entrada).
2. **Checkbox "Venda"** — ao lado dos campos de data. Marcado, o mesmo período passa a filtrar também a data usada em **"ULT. VENDA"** (só considera a venda mais recente dentro do período; fica em branco se não houve venda no período). Desmarcado (padrão), "ULT. VENDA" continua mostrando a venda mais recente sem filtro nenhum — comportamento inalterado.
3. **Arquivos alterados:**
   - `ncDados/dGradeItem.vb` — 3 propriedades novas: `dataEntradaInicio`, `dataEntradaFim`, `filtrarVenda`.
   - `ncPersistencia/pGradeItem.vb` — SQL de `ConsultarItens` (soma de entradas no período) e `ConsultarUltimaVenda` (filtro de venda quando `filtrarVenda = True`).
   - `ncRegras/rGradeItem.vb` — `ConsultarItens` passou a aceitar o filtro como parâmetro opcional.
   - `nascomercio/relatorio/fRelatorioGrade.vb` e `.Designer.vb` — campos de data, checkbox "Venda", validação das datas digitadas.
4. **Correções de acentuação (encoding)** — 6 textos que já estavam com o acento quebrado (aparecendo como caractere inválido) na tela e nas mensagens foram corrigidos: "Ordem Alfabética", "É necessário selecionar um Fabricante ou um Fornecedor!", comentário "validação", "Relatório de Grade de Produtos" (impressão), "Página" (impressão) e "Erro em Consultar Referência" (mensagem de erro interna).
5. **Correção de build** — `GenerateManifests` desligado só para a configuração **Debug** em `nascomercio.vbproj`. Isso evitava que toda build local falhasse na tarefa `ResolveManifestFiles`, bloqueada por uma política de Controle de Aplicativo do Windows. A configuração **Release** (usada no Publish real, distribuído para `D:\MeuNote\Distrib\Nascom\x64\`) não foi alterada e continua gerando o manifesto normalmente.

### Como foi validado

- Testado direto na máquina do usuário: comparação visual do relatório com e sem o filtro de período aplicado — confirmado que as entradas fora do período somem corretamente (linha zera) e que sem filtro o relatório continua idêntico ao original.
- Build recompilada com sucesso no Visual Studio do usuário (Limpar Solução + Recompilar Solução) depois da correção do `GenerateManifests`, sem os erros de compilação que apareceram no meio do processo (esses erros eram de cache de build desatualizado, não do código novo).

### Pendente

- Decidir se produtos sem nenhuma entrada no período devem ser **ocultados da lista** em vez de aparecer com a linha zerada (em aberto com o usuário).
- **Tópico separado, pausado a pedido do usuário:** investigação do erro de emissão de NFC-e (código do município do fato gerador = 0) na loja CALCEAKI. Diagnóstico já feito, mas nenhuma alteração de código foi aplicada — aguardando o usuário retomar o assunto.

---

## 31/08/2026 — Melhorias de baixo risco na camada de acesso a dados e regras de negócio

**Escopo:** `ncComum`, `ncPersistencia`, `ncRegras`

### O que foi mudado

**107 arquivos `.vb`** receberam três tipos de ajuste, todos internos (nenhuma assinatura pública mudou):

1. **Preservação da causa raiz de erros** — `ExcecaoNascomercio` ganhou um construtor que aceita a exceção original (`InnerException`). As ~800 chamadas `Throw New ExcecaoNascomercio(msg & ex.Message)` passaram a incluir `ex`, então o erro real fica visível ao depurar, não só a mensagem.
2. **Relançamento sem perder stack trace** — as ~54 ocorrências de `Catch nex As ExcecaoNascomercio / Throw nex` viraram `Throw` (sem argumento), que preserva o rastro original em vez de resetá-lo.
3. **`ncComum/acessobd.vb` reescrito com `Using`** — conexão, comando e `MySqlDataAdapter` agora fecham/descartam garantidamente mesmo em caminho de exceção (antes, um erro no meio do `Fill()` vazava o `MySqlDataAdapter`).

### Como foi validado

Compilei os 4 projetos afetados (`ncDados → ncComum → ncPersistencia → ncRegras`) com o compilador oficial do VB.NET, usando os `.vbproj` reais e os binários já compilados na sua máquina (`LibNF65.dll` e dependências, `MySql.Data.dll`). **Zero erros.** Os únicos avisos são pré-existentes no código original (variável não usada, API de criptografia obsoleta) — nenhum novo veio das mudanças.

Não recompilei o projeto de telas (`nascomercio`), o instalador nem o `NCImport` — não têm linha alterada, e como nenhuma assinatura pública mudou, não têm como quebrar.

### Pendente (não mexido ainda — precisa de mais cuidado)

- Possível SQL injection em pontos que concatenam valor direto no SQL (`ncPersistencia`)
- Versões duplicadas de pacotes NuGet e do `MySql.Data.dll`
- Módulo `ncEfd` (SPED Fiscal) sem nenhum tratamento de exceção

Detalhes completos e histórico ficam no doc `visao-geral-arquitetura.md` do projeto.
