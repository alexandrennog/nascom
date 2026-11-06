# Relatório de Alterações — Nascomercio

## 12/10/2026 — Varredura de acentuação corrompida + bugs de impressão da NFC-e (CALCEAKI/SAPATEK)

**Escopo:** praticamente todo o projeto (varredura) + `LibNF65` (impressão/emissão da NFC-e) + `nascomercio/formulario/fCaixa.vb` e `fPagamento.vb`.

### 1. Varredura completa de acentuação corrompida (mojibake)

**Motivação:** diversos textos no sistema apareciam com o acento trocado por um caractere inválido (`�`, U+FFFD) — provavelmente de uma conversão de codificação malfeita em algum momento no histórico do repositório. Pedido explícito do usuário para varrer o projeto inteiro de uma vez, não só os arquivos que apareciam na tela.

**O que foi feito:** scan de todos os 394 arquivos `.vb`/`.cs` do projeto (excluindo apenas `*.Designer.vb` gerados automaticamente) procurando o caractere `�`. Encontradas e corrigidas **211 ocorrências em 11 arquivos**:

- `ncComum/impressao.vb` (2), `ncComum/acessobd.vb` (4), `ncRegras/rParametro.vb` (1)
- `nascomercio/relatorio/fRelatorioCheques.vb` (1), `fCaixaConsulta.vb` (1), `fRelatorioCrediario.vb` (1), `fRelatorioFechamentoSAT.vb` (3)
- `nascomercio/formulario/mdiPrincipal.vb` (4), `fSPEDForm.vb` (39, em 18 pontos — nomes de registro do EFD/SPED e mensagens de erro)
- `nascomercio/formulario/fPagamento.vb` (69, em 26 pontos)
- `nascomercio/formulario/fCaixa.vb` (77 — o maior do lote)

**Achado relevante, não só cosmético:** em `fCaixa.vb`, a chave `AppSettings("ORDEM_SERVI�O")` não batia com a chave `"ORDEM_SERVIÇO"` usada no `app.config` e em `mdiPrincipal.vb` — ou seja, essa configuração nunca era lida corretamente. Corrigida junto com o resto da varredura.

**Verificação final:** novo scan após todas as correções confirmou **0 ocorrências restantes** em todo o projeto.

### 2. Botão "Cancelar" (F7) limpava a tela mesmo sem confirmação

**Sintoma relatado:** no caixa, apertar F7 limpava a pré-venda mesmo quando o operador respondia "Não" à confirmação de exclusão, ou cancelava/errava a senha do gerente.

**Causa:** em `fCaixa.vb`, `ExcluirPreVenda()` chamava `NovaVenda()` (limpa a tela) **fora** do bloco `If` que checava a confirmação e a senha do gerente — ou seja, rodava sempre, incondicionalmente.

**Correção:** `EfetivaExclusaoPreVenda()` virou uma `Function` que devolve `True`/`False` conforme a exclusão realmente aconteceu. `NovaVenda()` agora só é chamado quando essa função devolve `True`, dentro dos dois ramos (com e sem exigência de senha de gerente).

### 3. Cupom fiscal (DANFE) com valores inflados ~100x

**Sintoma relatado:** um item vendido a R$ 4,50 saía impresso no cupom fiscal como R$ 450,00 (e a quantidade de "1,000" como "100,000").

**Causa:** `NFCeImpressaoSP.ParseXML` (`LibNF65`), usado tanto na impressão logo após a venda quanto na reimpressão, lia os valores do XML da NFC-e com `decimal.Parse(...)` sem especificar cultura. O XML sempre grava números com "." como separador decimal (ex. `"4.50"`), mas na cultura pt-BR do Windows da máquina "." é separador de milhar — `decimal.Parse` acabava lendo `"4.50"` como `450`.

**Correção:** `CultureInfo.InvariantCulture` adicionado aos 7 pontos de `decimal.Parse` dessa função (quantidade, valor unitário e total do item; valor dos produtos, desconto e total da nota; valor do pagamento).

### 4. Cupom fiscal (DANFE) não imprimia na hora da venda, mas reimpressão funcionava

**Sintoma relatado:** ao finalizar uma venda com a NFC-e aprovada pela SEFAZ, o cupom fiscal não saía e aparecia erro de timeout de 8s ("impressora não respondeu"); indo em Consulta de Caixa → Reimprimir, a mesma nota imprimia normalmente.

**Duas causas encontradas, uma em cima da outra:**

a) **Impressão rodando em thread errada.** Uma correção anterior (desta mesma sessão, antes de hoje) tinha envolvido `printDoc.Print()` num `Task.Run(...)` pra evitar que a tela travasse caso a impressora não respondesse. Só que `PrintDocument.Print()` (API de impressão do Windows/GDI+) precisa rodar numa thread **STA**, e `Task.Run` usa o ThreadPool, que roda em **MTA** — causando falha inconsistente. Corrigido trocando por uma `Thread` dedicada com `ApartmentState.STA` explícito, mantendo o mesmo timeout de 8s como proteção.

b) **Causa raiz real: dois cupons disputando a mesma impressora.** Confirmado com o usuário que a regra de negócio é: SEFAZ aprovou → imprime **só** o cupom fiscal (DANFE com QR Code); SEFAZ deu erro → imprime **só** o cupom normal (recibo simples), como alternativa pro cliente. O código, porém, imprimia os dois **sempre** em modo `FISCAL=ONLINE` — o cupom fiscal dentro do `GerarNF` e, logo em seguida, no mesmo clique, o cupom normal (`ncComum/impressao.vb`, escrita direta na porta) — os dois disputando a mesma impressora térmica e travando o segundo a disparar. Corrigido em `fPagamento.vb`: a condição que decide se imprime o cupom normal agora inclui `AndAlso String.IsNullOrEmpty(chave)` (só imprime quando a NFC-e **não** foi emitida com sucesso).

**Erro de compilação introduzido e corrigido no mesmo dia:** a correção do item (b) quebrou o build (`BC30451 "chave" não está declarado`), porque a variável `chave` estava declarada dentro do bloco `ElseIf FISCAL = "ONLINE"` — em VB.NET isso limita o escopo a esse bloco, não ao procedimento inteiro (diferente do VB6/VBA). Corrigido movendo a declaração de `chave` para o topo da `Sub Imprime`, visível em toda a função.

### 5. Aviso ao operador quando o cupom fiscal falha ao imprimir (feito, ainda não implantado a pedido do usuário)

Dentro de `GerarNF` (`NFCe65.cs`), a impressão do DANFE sempre ficou isolada num `try/catch` vazio de propósito — uma falha de impressão não pode invalidar uma nota já autorizada pela SEFAZ. O efeito colateral: o operador nunca ficava sabendo que o cupom não saiu. Adicionado um parâmetro opcional `aoFalharImpressao` (callback), chamado nos dois pontos onde a impressão falhava em silêncio, e conectado em `fPagamento.vb` pra mostrar um aviso não bloqueante ("A NFC-e foi autorizada normalmente, mas o CUPOM FISCAL não pôde ser impresso... reimprima depois na tela de Consulta de Caixa"). **A pedido do usuário, essa parte específica ainda não foi testada/implantada** — fica pronta no código-fonte pra quando ele quiser subir.

### 6. Erro ao gerar a NFC-e por falta de código do município/UF (loja CALCEAKI)

**Sintoma relatado:** emissão de NFC-e falhando direto na SEFAZ em algumas lojas, com o código do município do fato gerador vindo como 0 — tópico que tinha ficado pausado numa sessão anterior.

**Causa:** o `app.config` não tinha as chaves `CodigoMunicipio` (código IBGE da cidade da loja) e `UF` (sigla do estado), usadas pela emissão da NFC-e quando a SEFAZ não devolve esse dado junto com o cadastro do emitente.

**Correção:** adicionadas as duas chaves no `app.config`, com comentário explicando o propósito de cada uma e lembrando de ajustar por loja quando não for São Paulo capital. Confirmado por comparação direta entre o `app.config` da versão antiga em produção e o da versão nova.

### 7. Aviso de certificado digital vencido ou próximo de vencer

**Motivação:** certificado vencido só aparecia pro operador como erro genérico de "falha ao emitir NFC-e" / 403 da SEFAZ durante uma venda real, com o cliente no caixa.

**O que foi feito:** `LibNF65/NFCe65.cs` ganhou `VerificarValidadeCertificado()` / `StatusCertificado` (verifica `NotBefore`/`NotAfter` do certificado configurado). Chamado em `mdiPrincipal.vb` (`VerificarCertificadoDigital`), em background (`Task.Run`, pra não travar a abertura da tela), logo na abertura do sistema: mostra aviso de erro se já vencido, ou de atenção se faltar 30 dias ou menos.

### 8. Otimização do banco de dados — índices criados automaticamente

**O que foi feito:** nova classe `ncComum/manutencaoBanco.vb` (`cManutencaoBanco`), chamada em `mdiPrincipal.vb` (`VerificarIndicesRelatorios`) na abertura do sistema. Cria (se ainda não existirem) índices em `vendas`, `vendasprodutos`, `vales` e `valesprodutos` (data+vendedor, clienteId, controle, produto) pra acelerar os relatórios de vendas. Checagem rápida decide se mostra o aviso "Otimizando banco de dados..."; criação real só roda se faltar algum índice. Seguro pra rodar em paralelo em vários terminais da mesma loja — qualquer erro (índice já existe, tabela ocupada) é ignorado sem interromper o login, por ser otimização e não requisito.

### 9. Painel de Compras — reposição refinada por referência+cor

**Motivação:** feedback da cliente (áudio) sobre o Painel de Compras (item do dia 17/09): a lista de "precisa repor" somava todas as cores de um produto numa linha só, continuava mostrando marca/produto descontinuado, e um item aparecia com estoque negativo (erro de lançamento).

**O que foi feito:** novo script `scripts/new script/39 - dashboard_compras_reposicao_por_cor.sql`, substitui só `sp_dashboard_compras_reposicao` (a `sp_dashboard_compras_resumo` não muda). Passa a agrupar por `produtos.cid` (referência+cor) em vez de só referência, exclui fabricante/produto/cor com `situacao = 'I'`, exclui estoque negativo, e sobe o `LIMIT` de 15 para 50 (já que a mesma quantidade de produtos diferentes agora ocupa mais linhas, uma por cor).

### 10. Novo relatório "Vendas por Fabricante"

**O que foi feito:** relatório novo (`fRelatorioVendasFabricante.vb` + Designer/resx, `VendasFabricantes.rdlc`), no mesmo padrão dos relatórios por vendedor/fornecedor já existentes. Nova view `scripts/new script/40 - v_vendasfabricante.sql` (`v_vendasfabricante`), seguindo o padrão de `v_vendasfornecedor` (vendas + vales, agrupado por fabricante). Nota técnica no script: `quantidade`/`total_valor` convertidos explicitamente pra `SIGNED` — a coluna `UNSIGNED` original vinda de dentro de uma VIEW causava problema de binding no ReportViewer/MySqlDataAdapter (coluna Quantidade sempre em branco).

### 11. Consultas por período mais rápidas em vários relatórios

**O que foi feito:** pelo menos 11 telas de relatório (`fRelatorioVendas`, `fRelatorioFechamento`, `fRelatorioCrediario`, `fRelatorioCheques`, `fRelatorioVendasVendedor`, `fRelatorioVendasSintetico`, `fRelatorioVendasFornecedor`, `fRelatorioTransferencia`, `fRelatorioGrupoProduto`, `fRelatorioAuditoria`, além do novo `fRelatorioVendasFabricante`) ganharam um método `CarregarDados()` com SQL parametrizado filtrando por data direto no banco (`WHERE data BETWEEN @dataInicial AND @dataFinal`), no lugar do `TableAdapter.Fill()` genérico anterior. Também adicionado `PeriodoMuitoLargo()`: avisa e pede confirmação quando o período pedido passa de 60 dias, antes de disparar a consulta.

### 12. Senha do gerente pedida repetidamente ao trocar de campo na tela de pagamento

**Sintoma relatado:** com desconto acima do limite permitido pro vendedor, o sistema pedia a senha do gerente corretamente uma vez, mas voltava a pedir toda vez que o operador saía de qualquer outro campo de pagamento (dinheiro, PIX, cartão, etc.), mesmo sem tocar no desconto de novo.

**Causa:** em `fPagamento.vb`, `txtDinheiro_Leave` trata o evento `Leave` de TODOS os campos de pagamento (não só o de desconto) e chamava `VerificarAlcada()` incondicionalmente.

**Correção:** `VerificarAlcada()` só é chamado quando `sender Is txtDesconto` — ou seja, só quando o próprio campo de desconto perde o foco.

### Arquivos alterados nesta sessão

- `ncComum/impressao.vb`, `ncComum/acessobd.vb`, `ncComum/manutencaoBanco.vb` (novo), `ncRegras/rParametro.vb`
- `nascomercio/relatorio/fRelatorioCheques.vb`, `fCaixaConsulta.vb`, `fRelatorioCrediario.vb`, `fRelatorioFechamentoSAT.vb`, `fRelatorioVendas.vb`, `fRelatorioFechamento.vb`, `fRelatorioVendasVendedor.vb`, `fRelatorioVendasSintetico.vb`, `fRelatorioVendasFornecedor.vb`, `fRelatorioTransferencia.vb`, `fRelatorioGrupoProduto.vb`, `fRelatorioAuditoria.vb`, `fRelatorioVendasFabricante.vb` (novo, + Designer/resx), `fPainelCompras.vb`
- `nascomercio/formulario/mdiPrincipal.vb`, `fSPEDForm.vb`, `fPagamento.vb`, `fCaixa.vb`
- `LibNF65/NFCeImpressaoSP.cs`, `LibNF65/NFCe65.cs`
- `nascomercio/app.config` (`CodigoMunicipio`, `UF`, `CertificadoArquivo`, `CertificadoSenha`)
- `scripts/new script/39 - dashboard_compras_reposicao_por_cor.sql`, `40 - v_vendasfabricante.sql` (novos)

### Pendente

- Testar/implantar o aviso de falha de impressão (item 5) quando o usuário decidir — código já confirmado consistente (assinatura de `GerarNF` com 9 parâmetros, lambda em `fPagamento.vb` fechando certo), só falta o Rebuild + atualização da versão na loja.
- Confirmar nas lojas que usam impressora não-USB/LAZ/ELG (porta COM/UNC direta) se o problema de timeout do cupom normal em si (quando a SEFAZ erra) é de configuração de porta/impressora física, não de código — ficou registrado numa conversa anterior com a loja CALCEAKI mas não foi resolvido em código (não dá pra resolver em código: é conectividade/config física).

**Já instalado e confirmado em uso na loja (itens 4(b) e 3 acima):** a correção que impede o cupom normal de imprimir junto com o fiscal quando a SEFAZ aprova.

---

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
