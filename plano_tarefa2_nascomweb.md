# Plano de Ação — Tarefa 2: Formulários NascomWeb (Razor Pages) consumindo a API

**Data:** 2026-07-02
**Escopo:** Criação dos formulários de cadastro no projeto `NascomWeb` consumindo a `APINascom`, reproduzindo a UX das telas WinForms de `nascomercio/formulario` (branch `feature/versaofinal`).

---

## Contexto

O sistema Nascomercio hoje é um WinForms (VB.NET) monolítico acoplado direto ao MySQL. Já existe uma `APINascom` (schema em [schemaapi.json](schemaapi.json), OpenAPI 3.0.1, autenticação `Bearer` JWT via `/api/Auth/login`) expondo **62 grupos de endpoints** que cobrem a maior parte das entidades de cadastro do sistema (Cor, Categoria, Grupo, Fabricante, Estado, Cliente + sub-entidades, Fornecedor, Produto, Servico, Condição, Usuário, etc.), seguindo o padrão de ações `listar` (GET) / `consultar` (POST) / `incluir` (POST) / `alterar` (PUT) / `excluir` (DELETE) por entidade — refletindo o padrão de telas do WinForms: `fXxxFiltro` (busca) → `fXxxLista` (grade de resultados) → `fXxxForm` (cadastro/edição).

A pasta `nascomercio/formulario` (branch `feature/versaofinal`) tem **98 telas**. Nem todas são migráveis via API: telas como `fCaixa`, `fPreVenda`/Venda, `fNFeForm`, `fSPEDForm`, `fBackup`, `fCamera`, `fProdutoEtiqueta` dependem de hardware fiscal, certificado digital, SEFAZ, impressoras ESC/POS — fora do escopo de um frontend web puro de CRUD e fora do escopo desta tarefa.

O objetivo desta tarefa é criar, no projeto `NascomWeb` (já scaffolded como Razor Pages .NET 9, com Bootstrap e jQuery Validation prontos), as telas equivalentes de **cadastro** (Filtro + Lista + Form), reproduzindo a UX observada no WinForms, mas com boas práticas modernas de Razor Pages.

**Decisões de arquitetura adotadas:**
- Manter **Razor Pages** (aproveita o scaffold existente: `Pages/`, `_Layout.cshtml`, validação jQuery já configurada).
- Client HTTP tipado: **na execução**, o ambiente não teve acesso à internet para restaurar pacotes NuGet (NSwag/`Microsoft.dotnet-openapi` precisam baixar o gerador). Em vez de bloquear a entrega, o `NascomWeb` referencia diretamente o projeto `Modelos` (via `ProjectReference`) e reutiliza os mesmos DTOs da API (`dCor`, `dCategoria`, ...) num `CrudApiClient<TDto>` genérico hand-written — mesmo objetivo do NSwag (tipagem forte, sem duplicar classes, sem reescrever 60+ services), sem dependência de download externo. Se o acesso a pacotes NuGet for liberado depois, dá para migrar para NSwag sem alterar as Pages (a interface do `CrudApiClient` seria só trocada por baixo).
- Fasear o escopo por complexidade, começando pelos cadastros simples para fixar o padrão, depois expandindo para os cadastros com sub-telas (Cliente, Produto). Telas operacionais/fiscais ficam fora deste plano (decisão futura).

---

## Fase 0 — Infraestrutura base do NascomWeb

1. **Client tipado da API**: `ProjectReference` para `Modelos.csproj` (reuso dos DTOs) + `Infrastructure/CrudApiClient.cs` (genérico, `listar/consultar/incluir/alterar/excluir` via `HttpClient`) + `Infrastructure/CrudApiClientFactory.cs` (cria uma instância por entidade a partir do `IHttpClientFactory`).
2. **Autenticação (padrão BFF — token nunca chega ao navegador/JS)**:
   - Página `Pages/Login.cshtml` + `LoginModel` que chama `POST /api/Auth/login` (schema `dLogin`: `usuario`/`senha`), recebe o `dTokenResposta` e faz `HttpContext.SignInAsync` com **Cookie Authentication** (`AddAuthentication(CookieAuthenticationDefaults...)`), reproduzindo as claims do JWT (`role`, `name`) para que `[Authorize(Roles=...)]` funcione nativamente nas Pages.
   - O token de acesso (e o refresh token, ver abaixo) são guardados via `AuthenticationProperties.StoreTokens(...)` dentro do cookie criptografado/HttpOnly/Secure — nunca em `localStorage`/JS.
   - `[Authorize]` nas Razor Pages de cadastro; middleware de redirecionamento para `/Login` quando não autenticado.
   - **Refresh token**: como a API hoje (`AuthController.cs`, `rJwt.cs`) só emite o access token JWT (sem refresh token nem endpoint de renovação), isso exige um **incremento mínimo no backend**, fora do `NascomWeb` mas necessário para o recurso funcionar ponta a ponta:
     - `dTokenResposta` ganha um campo `RefreshToken` (string opaca aleatória, não-JWT) + expiração própria e mais longa (ex.: 7 dias, configurável em `Jwt:RefreshExpiracaoDias`).
     - Persistência do refresh token (tabela simples `usuario_refresh_token: cid, token, expiracao, revogado`) para permitir validação e revogação no logout — um refresh token JWT auto-validável não permite revogar sessão comprometida.
     - Novo endpoint `POST /api/Auth/refresh` (`{ refreshToken }` → novo `dTokenResposta`, com rotação: o refresh token antigo é invalidado e um novo é emitido).
     - Novo endpoint `POST /api/Auth/logout` para revogar o refresh token armazenado.
   - **No NascomWeb**, o `JwtForwardingHandler` (`DelegatingHandler` do `HttpClient` tipado) fica responsável pelo *silent refresh*: antes de anexar o `Authorization: Bearer`, verifica a expiração do access token guardado no cookie; se expirado (ou se a API responder `401`), chama `/api/Auth/refresh` com o refresh token guardado, atualiza o cookie via novo `SignInAsync` e repete a chamada original uma vez. Se o refresh também falhar (expirado/revogado), força `SignOutAsync` e redireciona para `/Login`.
   - Cookie configurado com `SlidingExpiration = true` e `ExpireTimeSpan` alinhado à validade do refresh token; o access token continua expirando no seu próprio prazo curto e sendo renovado de forma transparente pelo handler.
3. **Configuração do HttpClient**: `builder.Services.AddHttpClient<NascomApiClient>(...)` com `BaseAddress` vindo de `appsettings.json` (`ApiSettings:BaseUrl`), + `JwtForwardingHandler` que injeta o Bearer token (e faz o refresh silencioso descrito acima).
4. **Layout/Navegação**: atualizar `Pages/Shared/_Layout.cshtml` com menu lateral/top agrupando as entidades por domínio (Cadastros Gerais, Clientes, Produtos, Fornecedores/Serviços), reproduzindo a organização do menu MDI do WinForms (`mdiPrincipal`) de forma simplificada.
5. **Convenção de pastas**: `Pages/Cadastros/<Entidade>/Index.cshtml` (Filtro+Lista combinados em uma página, como é comum em Razor Pages) e `Pages/Cadastros/<Entidade>/Edit.cshtml` (Form de inclusão/edição, com `id` opcional na rota).
6. **Padrão de UI reutilizável**: criar Partial Views / componentes compartilhados:
   - `_FiltroPartial` (campos de busca + botão pesquisar, reproduzindo `fXxxFiltro`)
   - `_GridPartial` (tabela de resultados com paginação, ação editar/excluir, reproduzindo `fXxxLista`)
   - `_FormActionsPartial` (botões Salvar/Cancelar + modal de confirmação, reproduzindo o `MessageBox.Show("Confirma ...")` do VB)
   - Um `BaseCrudPageModel<TDto>` (ou pattern similar) para reduzir duplicação entre PageModels de entidades simples.

## Fase 1 — Piloto: cadastros simples (fixar o padrão)

Entidades: **Cor**, **Categoria**, **Grupo**, **Fabricante**, **Estado**, **Condicao**, **Servico** — todas com o mesmo padrão de tela (Filtro por nome/situação → Lista → Form com Nome + Situação).

Referência direta: [fCorForm.vb](nascomercio/formulario/fCorForm.vb) (branch `feature/versaofinal`) mostra o padrão: validação obrigatória de Nome, checagem de duplicidade antes de incluir (`regras.Consultar`), diálogo de confirmação antes de salvar, combo de Situação (Ativo/Inativo).

Para cada entidade:
- `Index.cshtml`: filtro (nome/situação) + grid com resultados de `GET /api/{Entidade}/listar` (ou `POST /consultar` quando o filtro exigir corpo).
- `Edit.cshtml`: formulário com `[Required]` nos campos obrigatórios (equivalente à validação manual do VB), reutilizando `jquery.validate.unobtrusive` já presente no projeto.
- Checagem de duplicidade antes de `incluir` (client-side aviso + validação server-side).
- Confirmação antes de salvar/excluir via modal Bootstrap (substitui `MessageBox.Show`).
- Mensagens de sucesso/erro via `TempData` (padrão PRG — Post/Redirect/Get).

Esta fase entrega o **template replicável**: depois dela, adicionar uma nova entidade simples deve ser um exercício mecânico (copiar estrutura, trocar DTO/endpoint).

## Fase 2 — Cadastros com sub-telas (mestre-detalhe)

Entidades: **Cliente** (+ `ClienteEndereco`, `ClienteFinanceiro`, `ClienteProfissional`, `ClienteVeiculo`), **Fornecedor**, **Produto** (+ `ProdutoItem`/grade, `ProdutoTipo`, `ProdutoTipoCaracteristica`), **Usuario**/**UsuarioPerfil**.

Referência: [fClienteForm.vb](nascomercio/formulario/fClienteForm.vb) (1116 linhas) organiza as sub-entidades em abas dentro do mesmo formulário, todas chaveadas por `cliente_cid`.

Padrão de UI: página `Edit.cshtml` do Cliente com **Bootstrap Tabs** (Dados Gerais / Endereço / Financeiro / Profissional / Veículos), cada aba postando para o endpoint correspondente (`ClienteEndereco/incluir`, `ClienteFinanceiro/alterar`, etc.) via handlers nomeados do Razor Pages (`OnPostEndereco`, `OnPostFinanceiro`, ...) ou via chamadas AJAX incrementais, mantendo uma única página coesa como no WinForms original.

## Fora de escopo (registrar, não implementar agora)

Telas operacionais/fiscais que dependem de hardware, certificado digital ou integrações externas (Caixa/PDV, Venda/PreVenda, NF-Ce, EFD/SPED, Backup, Câmera, Etiquetas) — decisão de incluir fica para uma rodada futura, após validar o padrão com as Fases 1 e 2.

---

## Status da execução (2026-07-02)

**Concluído:**
- Backend: refresh token completo (`Modelos/dRefreshToken.cs`, `Repositorios/{IpRefreshToken,pRefreshToken}.cs`, `Servicos/{IsRefreshToken,rRefreshToken}.cs`, `APINascom/Controllers/AuthController.cs` com `/refresh` e `/logout`, `scripts/37 - usuario_refresh_token.sql`, DI em `APINascom/Program.cs`, `Jwt:RefreshExpiracaoDias` em `appsettings.json`). `schemaapi.json` regenerado a partir da API rodando localmente.
- Fase 0 (infraestrutura NascomWeb): autenticação por cookie + BFF, `JwtForwardingHandler` com silent refresh, `UnauthorizedRedirectFilter` global, layout/menu, modal de confirmação compartilhado (substitui `MessageBox.Show`).
- Fase 1 completa: Cor, Categoria, Grupo, Fabricante, Estado, Condicao, Servico (Index + Edit cada).
- Build da solution completa e da NascomWeb sem erros; smoke test manual (sem banco de dados disponível no ambiente) confirmou: rotas protegidas redirecionam para `/Login`, página de login renderiza.

**Fase 2 — Cliente (mestre-detalhe) concluída:**
- `Pages/Cadastros/Cliente/Index` (filtro por nome/situação, busca por CPF/nome) e `Edit` com abas Bootstrap: Dados Gerais, Endereço, Financeiro, Profissional e Veículos.
- `Infrastructure/ClienteApiClient.cs` — client dedicado (não genérico), pois as sub-entidades não seguem o padrão CRUD uniforme:
  - Endereço/Financeiro/Profissional são 1:1 por `cliente_cid` e **não têm PK própria** — Endereço é upsert via `excluirporcliente` + `incluir`; Financeiro/Profissional fazem `consultar` e decidem `incluir` vs `alterar`.
  - Veículos é 1:N com PK própria (`cid`) — implementado como lista com adicionar (`incluir2`) e remover (`excluir`) por linha.
- As abas de sub-cadastro ficam desabilitadas até o cliente ser salvo (mesma regra do WinForms: `Me.cid` precisa existir antes de gravar registros filhos).
- Build da solution e do NascomWeb sem erros; smoke test HTTP confirmou as novas rotas (`/Cadastros/Cliente/Index`, `/Cadastros/Cliente/Edit`) redirecionando corretamente para `/Login`.

**Fase 2 — restante concluído (2026-07-03):**
- **Fornecedor**: cadastro simples (mesmo padrão da Fase 1, com dropdown de Estado).
- **UsuarioPerfil**: cadastro simples (código/nome/situação).
- **Usuario**: cadastro com dropdown de Perfil e campo de senha separado do DTO (`NovaSenha`) — nunca exibe o hash existente; senha em branco na edição mantém a atual (delegado à API, que já faz o hash BCrypt).
- **Caracteristica**: cadastro simples, adicionado como pré-requisito real de `ProdutoTipoCaracteristica` (sem ele, não haveria características para vincular).
- **ProdutoTipo**: cadastro simples + seção de "Características vinculadas" (`ProdutoTipoCaracteristica`) na própria página de edição — vincular/desvincular características via `Infrastructure/ProdutoTipoCaracteristicaApiClient.cs`.
- **Produto**: tela mestre-detalhe com abas "Dados do Produto" e "Grade". A grade (variações de tamanho/cor/etc.) é modelada na API como linhas EAV em `ProdutoItem` (uma linha por característica, agrupadas por número de `item`) e qualquer gravação com grade (`incluircompleto`/`alterarcompleto`) reescreve **todas** as linhas do produto — por isso `Infrastructure/ProdutoApiClient.cs` sempre recarrega e reenvia as linhas existentes ao adicionar/remover uma variação. Escopo definido conscientemente: a tela cria variações com característica(s) + estoque inicial + código de barras (manual ou auto-gerado pela API), mas **não** implementa o fluxo de movimentação/entrada de estoque incremental (`estoquenovo`) nem edição de linha existente — esses ficam classificados como telas operacionais (mesma categoria de Caixa/Venda) fora do escopo original.
- Foi necessário adicionar dois claims extras no cookie de login (`ClaimTypes.NameIdentifier` = cid do usuário, decodificado do JWT; e `login_usuario` = login) porque os endpoints `incluircompleto`/`alterarcompleto`/`excluir` do Produto exigem um `dUsuario` completo para auditoria, e isso não vem em `dTokenResposta`.
- Build da solution completa e do `NascomWeb` sem erros; smoke test confirmou as 12 novas rotas (Fornecedor, Usuario, UsuarioPerfil, Caracteristica, ProdutoTipo, Produto × Index/Edit) redirecionando corretamente para `/Login`.

**Lacunas fechadas após revisão (2026-07-03):**
- **CaracteristicaItem**: seção "Valores possíveis" embutida em `Caracteristica/Edit` (ex.: para a característica "Tamanho", cadastrar P/M/G). A aba Grade do Produto agora usa `<select>` com esses valores quando existem, em vez de texto livre — via `Infrastructure/CaracteristicaItemApiClient.cs`.
- **Loja**: cadastro completo (nome fantasia, razão social, CNPJ, endereço, SPC).
- **Parametro**: cadastro simples (descrição/valor).
- **Municipios**: cadastro com filtro por Estado (usa o endpoint específico `listarporestados`, já que `Consultar` da API não filtra por `estados_cid`).

**Pendente / fora de escopo (fica para rodada futura, por decisão explícita do plano):**
- Telas operacionais/fiscais (Caixa/PDV, Venda/PreVenda, NF-Ce, EFD/SPED, Backup, Câmera, Etiquetas) e o fluxo de movimentação de estoque (`estoquenovo`) do Produto.
- Teste end-to-end real de login/CRUD contra um MySQL com dados (não disponível neste ambiente de execução) — todo o build e smoke test HTTP foi feito sem banco de dados real.

**Desvio em relação ao plano original:** o client HTTP tipado não foi gerado via NSwag (sem acesso à internet para restaurar o pacote no ambiente de execução). Foi usado um `CrudApiClient<TDto>` genérico + `ProjectReference` ao projeto `Modelos`, com o mesmo objetivo (tipagem forte, DTOs únicos, sem 60+ services manuais).

## Arquivos-chave criados/alterados

**Backend (refresh token)**
- `Modelos/dTokenResposta.cs`, `Modelos/dRefreshToken.cs`
- `Repositorios/IpRefreshToken.cs`, `Repositorios/pRefreshToken.cs`
- `Servicos/IsRefreshToken.cs`, `Servicos/rRefreshToken.cs`
- `APINascom/Controllers/AuthController.cs`, `APINascom/Program.cs`, `APINascom/appsettings.json`
- `scripts/37 - usuario_refresh_token.sql`

**Frontend (`NascomWeb`)**
- `NascomWeb/NascomWeb.csproj` — `ProjectReference` para `Modelos`
- `NascomWeb/appsettings.json` — `ApiSettings:BaseUrl`
- `NascomWeb/Program.cs` — cookie auth, `AddHttpClient` (client "cru" para Auth + client "NascomApi" com `JwtForwardingHandler`), `AuthorizeFolder("/Cadastros")`
- `NascomWeb/Infrastructure/` — `AuthApiClient.cs`, `CrudApiClient.cs`, `CrudApiClientFactory.cs`, `JwtForwardingHandler.cs`, `UnauthorizedRedirectFilter.cs`, `ApiException.cs`, `ApiUnauthorizedException.cs`
- `NascomWeb/Pages/Login.cshtml(.cs)`, `NascomWeb/Pages/Logout.cshtml(.cs)`
- `NascomWeb/Pages/Shared/_Layout.cshtml` — menu, mensagens (`TempData`), modal de confirmação
- `NascomWeb/wwwroot/js/site.js` — comportamento do modal de confirmação (`data-confirm`)
- `NascomWeb/Pages/Cadastros/{Cor,Categoria,Grupo,Fabricante,Estado,Condicao,Servico}/{Index,Edit}.cshtml(.cs)`

## Verificação

- [x] `dotnet build` da solution completa e do `NascomWeb.csproj` — 0 erros.
- [x] Smoke test HTTP (sem banco): `/Cadastros/*/Index` e `/Edit` redirecionam (302) para `/Login`; `/Login` renderiza 200.
- [ ] Navegação manual completa com banco de dados real: login → listar/filtrar → incluir → editar → excluir em Cor (e demais entidades da Fase 1) — requer MySQL configurado, não disponível neste ambiente.
- [ ] Forçar expiração do access token e confirmar renovação silenciosa via `/api/Auth/refresh`, e revogação/expiração do refresh token forçando logout — requer ambiente com banco de dados.
- [ ] Fluxo mestre-detalhe do Cliente (Fase 2) — não implementado nesta rodada.
