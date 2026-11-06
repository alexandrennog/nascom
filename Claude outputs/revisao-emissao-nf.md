# Revisão — Emissão de Nota Fiscal (NFC-e e NF-e)

**Data:** 21/09/2026
**Escopo:** revisão de código, sem nenhuma alteração aplicada (conforme pedido). Cobre NFC-e (cupom fiscal, usado no caixa) e NF-e (nota fiscal modelo 55).
**Arquivos revisados:** `LibNF65/NFCe65.cs`, `LibNF65/Interfaces/NFCe.cs`, `LibNF65/Interfaces/INFCe.cs`, `nascomercio/formulario/fPagamento.vb`, `nascomercio/formulario/fCaixa.vb`, `nascomercio/formulario/fNFeForm.vb`, `nascomercio/formulario/mdiPrincipal.vb`, `ncRegras/rVenda.vb`.

## Resumo executivo

O sistema hoje **só emite NFC-e de verdade**. A tela de "NF-e" que existe no menu do sistema é um resquício não funcional — nunca chega a falar com a SEFAZ. Do lado do NFC-e (que funciona e é usado todo dia), o fluxo principal já recebeu bastante trabalho de blindagem recentemente (dá pra ver isso nos comentários do próprio código), mas ainda existem **dois pontos de risco reais**: quando a emissão falha ou é rejeitada pela SEFAZ, a venda no banco de dados pode ficar num estado inconsistente, sem nenhuma tela ou rotina para detectar/corrigir isso depois.

---

## 1. NFC-e (`LibNF65/NFCe65.cs` + `fPagamento.vb`)

### 1.1. Venda fica "órfã" quando a geração da NFC-e lança exceção

Em `fPagamento.vb`, o fluxo de emissão é:

```vb
dados.chnfe = "temporario"
Dim nNF = novaVenda.IncluirnNF(dados)          ' grava no banco AGORA, com TransactionScope próprio
...
Dim chave = NFCe65.GerarNF(...)                 ' pode lançar exceção
regraVenda.Alterar(controle.ToString(), chave)
dados.chnfe = chave
dados.SeqNFe = nNF
regraVenda.AlterarBaseNnf(dados)

Catch ex As Exception
    MessageBox.Show(ex.Message)
End Try
```

`IncluirnNF` (em `ncRegras/rVenda.vb`) abre o próprio `TransactionScope` e já dá `ts.Complete()` — ou seja, o registro da venda com `chnfe = "temporario"` e o número sequencial da NFC-e (`nNF`) já foram **gravados e confirmados no banco** antes mesmo de `NFCe65.GerarNF` ser chamado.

Se `GerarNF` lançar exceção (falha de comunicação com a SEFAZ, falha ao assinar o XML, XML reprovado na validação de schema — todos esses caminhos existem no código e terminam em `throw`), o `Catch` aqui só mostra `MessageBox.Show(ex.Message)`. Não há rollback, não há exclusão do registro, não há nova tentativa. A venda fica **permanentemente** com `chnfe = "temporario"` no banco.

Busquei em todo o projeto por qualquer tela, relatório ou rotina que trate esse valor `"temporario"` depois — **não existe nenhuma**. Nenhuma tela de reconciliação, nenhum job de reenvio, nenhum relatório que sinalize essas vendas.

**Impacto prático:**
- O número sequencial da NFC-e (`nNF`) foi "queimado" — pulado — sem que a nota correspondente exista de fato. Pela legislação, número pulado precisa ser justificado à SEFAZ via **Inutilização**; não há nada no código que faça isso automaticamente.
- Relatórios que olham a tabela de vendas (incluindo o de Grade que ajustamos há pouco, ou qualquer relatório de vendas/SPED) podem contar essa venda como concluída, mesmo sem NFC-e válida por trás.
- O operador de caixa só vê uma mensagem de erro genérica, sem orientação do que fazer a seguir.

### 1.2. Venda rejeitada pela SEFAZ é salva como se fosse válida

Esse é sutil e diferente do item anterior. Dentro de `NFCe65.GerarNF`, quando a SEFAZ processa o lote mas **rejeita** a nota (`infProt.CStat` diferente de 100), o código **não lança exceção** — só mostra um `MessageBox` com o motivo e **retorna normalmente** a `chaveAcesso` (o cupom não é impresso, isso já foi corrigido antes — só entra na branch de impressão quando `CStat == 100`).

Só que em `fPagamento.vb`, como `GerarNF` retornou sem lançar exceção, o código continua e executa:

```vb
regraVenda.Alterar(controle.ToString(), chave)
dados.chnfe = chave
dados.SeqNFe = nNF
regraVenda.AlterarBaseNnf(dados)
```

Ou seja, a **chave de uma NFC-e rejeitada** é gravada no registro da venda exatamente da mesma forma que uma chave autorizada — não existe nenhum campo de status (autorizado/rejeitado) sendo salvo junto. Quem olhar essa venda depois (relatório, SPED, consulta) não tem como distinguir "nota autorizada" de "nota rejeitada pela SEFAZ" só olhando o banco.

### 1.3. `CancelarNFe` — falhas silenciosas

```csharp
var ret = infoProdutoService.BuscarPorChNFe(chave, repository);
...
var retCancelamento = objNFCe.EventoCancelamentoNFCe(chave, x509Cert, ret.NProt);
```

- Não há checagem de `ret == null` antes de usar `ret.NProt` — se a chave não for encontrada no repositório local, isso lança `NullReferenceException` sem mensagem clara.
- Quando o evento de cancelamento é **rejeitado** pela SEFAZ (`InfEvento.CStat` fora de 135/155), ou quando o lote inteiro não é processado (`CStat != 128`), o código cai no `default`/fica fora do `if` — só um comentário `//Tratamentos necessários quando o evento é rejeitado`, sem tratamento nenhum. O método só devolve `false`, sem o motivo da rejeição (`XEvento`) em lugar nenhum. Quem chama `CancelarNFe` não tem como saber *por que* o cancelamento falhou.

### 1.4. UF fixa em SP na consulta de cadastro

```csharp
var infCons = new InfCons {
    CNPJ = ConfigurationManager.AppSettings["CNPJ"],
    UF = UFBrasil.SP
};
```

Mesmo padrão de hardcode que já tínhamos identificado no bug do `cMunFG` (não mexido, conforme combinado). Hoje não causa problema porque todas as lojas são de SP, mas é o mesmo ponto frágil: se uma loja de outro estado for cadastrada, essa consulta vai continuar batendo na SEFAZ de SP.

### 1.5. Pontos menores

- `chaveAcesso = xml.NFe.First().InfNFe.FirstOrDefault().Chave;` — se `RecuperarProdutos` alguma vez devolver uma nota sem nenhum `InfNFe` (ex.: lista de produtos vazia), isso estoura `NullReferenceException` em vez de um erro claro tipo "nenhum produto informado".
- Não há fallback de contingência (emissão offline / EPEC) se a SEFAZ estiver fora do ar — hoje, indisponibilidade da SEFAZ simplesmente falha a venda (ver item 1.1). Pode ser aceitável para o negócio, mas vale confirmar se é intencional.
- O algoritmo de assinatura usado é SHA-1 (`AlgorithmType.Sha1`) — isso **não é um bug**: é o que a SEFAZ exige hoje para assinatura de NFe/NFC-e, mesmo sendo um algoritmo considerado fraco para outros usos.

### O que já está bem resolvido (achados positivos)

O arquivo tem comentários explicando melhorias que já foram feitas — confirmei que estão realmente implementadas:
- `chaveAcesso` deixou de ser campo estático da classe (evitava um caixa sobrescrever a chave de outro caixa rodando em paralelo).
- Caminho dos XMLs passou a ser absoluto (não depende mais do diretório de trabalho atual, que podia mudar durante a execução).
- Impressão do cupom só acontece depois de confirmar `CStat == 100` — antes imprimia mesmo com nota rejeitada.
- `MoverArquivo` não lança mais exceção se falhar ao mover o arquivo (evitava mascarar o resultado fiscal real, que já tinha acontecido na SEFAZ).
- Checagem de `ProtNFe == null` antes de acessar o protocolo, evitando `NullReferenceException` em caso de rejeição de lote.

---

## 2. NF-e (`fNFeForm.vb`) — não funciona

Achei a tela de "NF-e" (`fNFeForm`), mas duas coisas chamaram atenção:

**Não está acessível pelo menu.** `mdiPrincipal.CarregarTelaNFe()` é o único jeito de abrir essa tela, e ela existe no código — mas busquei em todo o projeto e **nenhum item de menu chama esse método**. Ou seja, mesmo que quisesse, hoje não dá pra abrir essa tela pela interface do sistema (a não ser que exista algum atalho de teclado que eu não encontrei).

**Mesmo se fosse aberta, não emite nada de verdade.** O botão "Executar" da tela faz isto:
- Monta um XML manualmente, escrevendo tags fixas linha por linha.
- O `idLote` é um valor fixo hardcoded (`123456789012345`) — não gerado.
- O `Id` do `infNFe` é uma chave de acesso **fake, hardcoded** (`NFe12345678901234567890123456789012345678901234`) — não uma chave real calculada (UF + data + CNPJ + modelo + série + número + código numérico + dígito verificador).
- A tag `infNFe` é escrita **vazia** — sem emitente, destinatário, produtos, impostos, totais, nada.
- A tag `Signature` também é escrita vazia — o XML nunca é assinado digitalmente de verdade.
- A versão do layout é `1.01` — a SEFAZ exige `4.00` desde 2018/2019; a `1.01` seria rejeitada de cara.
- Não existe **nenhuma chamada para a SEFAZ** em lugar nenhum desse arquivo — ele só grava um `.xml` numa pasta local (`arquivos_nfe\`) e mostra "Arquivo criado com sucesso!".

**Conclusão prática:** o sistema hoje não tem capacidade nenhuma de emitir NF-e (modelo 55) — nem para venda, nem para transferência, nem para faturamento. Só existe o NFC-e (modelo 65), usado no caixa. Se em algum momento a operação precisar emitir NF-e de verdade (ex.: venda para CNPJ, transferência entre lojas, e-commerce B2B), isso precisaria ser construído praticamente do zero — o que existe hoje é só uma casca visual que nunca foi terminada.

---

## Não coberto nesta revisão

- O bug já conhecido do `cMunFG = 0` (loja CALCEAKI) — segue como estava, sem mexer, aguardando você retomar.
- Uma varredura completa de caracteres com acentuação quebrada (encoding) nesses arquivos — encontrei o mesmo padrão de corrupção que já vínhamos corrigindo no relatório de Grade, mas não fiz uma varredura sistemática aqui porque o foco pedido foi a lógica de emissão, não texto.
- `ncEfd` (SPED Fiscal) e emissão de outros documentos (SAT, Cupom Fiscal não-eletrônico) não foram olhados.

Nenhuma alteração de código foi feita — isto é só o levantamento, como combinado.
