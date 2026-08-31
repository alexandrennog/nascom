# Relatório de Alterações — Nascomercio

**Data:** 31/08/2026
**Escopo:** melhorias de baixo risco na camada de acesso a dados e regras de negócio (`ncComum`, `ncPersistencia`, `ncRegras`)

## O que foi mudado

**107 arquivos `.vb`** receberam três tipos de ajuste, todos internos (nenhuma assinatura pública mudou):

1. **Preservação da causa raiz de erros** — `ExcecaoNascomercio` ganhou um construtor que aceita a exceção original (`InnerException`). As ~800 chamadas `Throw New ExcecaoNascomercio(msg & ex.Message)` passaram a incluir `ex`, então o erro real fica visível ao depurar, não só a mensagem.
2. **Relançamento sem perder stack trace** — as ~54 ocorrências de `Catch nex As ExcecaoNascomercio / Throw nex` viraram `Throw` (sem argumento), que preserva o rastro original em vez de resetá-lo.
3. **`ncComum/acessobd.vb` reescrito com `Using`** — conexão, comando e `MySqlDataAdapter` agora fecham/descartam garantidamente mesmo em caminho de exceção (antes, um erro no meio do `Fill()` vazava o `MySqlDataAdapter`).

## Como foi validado

Compilei os 4 projetos afetados (`ncDados → ncComum → ncPersistencia → ncRegras`) com o compilador oficial do VB.NET, usando os `.vbproj` reais e os binários já compilados na sua máquina (`LibNF65.dll` e dependências, `MySql.Data.dll`). **Zero erros.** Os únicos avisos são pré-existentes no código original (variável não usada, API de criptografia obsoleta) — nenhum novo veio das mudanças.

Não recompilei o projeto de telas (`nascomercio`), o instalador nem o `NCImport` — não têm linha alterada, e como nenhuma assinatura pública mudou, não têm como quebrar.

## Pendente (não mexido ainda — precisa de mais cuidado)

- Possível SQL injection em pontos que concatenam valor direto no SQL (`ncPersistencia`)
- Versões duplicadas de pacotes NuGet e do `MySql.Data.dll`
- Módulo `ncEfd` (SPED Fiscal) sem nenhum tratamento de exceção

Detalhes completos e histórico ficam no doc `visao-geral-arquitetura.md` do projeto.
