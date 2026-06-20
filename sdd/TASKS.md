# TASKS — Refactoring Nascomercio

Execução incremental por fase. Cada fase deve deixar o sistema compilando e funcional antes de avançar.  
Referência: `SPEC.md` para regras e critérios de conclusão.

---

## Fase 1 — Interfaces e Inversão de Dependência

**Meta:** todas as camadas se comunicam via contrato, não via implementação concreta.

### TASK-01 Criar `IRepositorio<T>` base em `ncPersistencia`
- Arquivo: `ncPersistencia/IRepositorio.vb`
- Interface genérica com os métodos comuns: `Incluir`, `Alterar`, `Excluir`, `Consultar`
- Não é obrigatório que todos os repositórios implementem todos os métodos — usar apenas o que a entidade precisa

### TASK-02 Criar `IServico<T>` base em `ncRegras`
- Arquivo: `ncRegras/IServico.vb`
- Mesma abordagem de TASK-01 para a camada de regras

### TASK-03 Extrair interfaces concretas para as entidades críticas
Ordem de prioridade (pelo volume de uso na UI):
1. `IServicoVenda` / `IRepositorioVenda`
2. `IServicoCliente` / `IRepositorioCliente`
3. `IServicoProduto` / `IRepositorioProduto`
4. `IServicoParametro` / `IRepositorioParametro`
5. `IServicoUsuario` / `IRepositorioUsuario`

Para cada entidade:
- Criar `IServicoXxx.vb` em `ncRegras` listando os métodos públicos existentes em `rXxx`
- Criar `IRepositorioXxx.vb` em `ncPersistencia` listando os métodos públicos existentes em `pXxx`
- Fazer `rXxx` implementar `IServicoXxx` e `pXxx` implementar `IRepositorioXxx`

### TASK-04 Criar `ISessionContext` em `ncComum`
- Arquivo: `ncComum/ISessionContext.vb`
- Propriedades: `Usuario As dUsuario`, `Loja As dLoja`, `PerfilCodigo As String`
- Implementação concreta: `SessionContext.vb` (singleton simples, sem DI container)
- Formulários recebem `ISessionContext` via construtor ou propriedade pública no lugar de `mdiPrincipal.gUsuario`

---

## Fase 2 — Acesso a Dados Seguro

**Meta:** eliminar risco de SQL Injection; toda persistência usa parâmetros.

### TASK-05 Adicionar sobrecarga parametrizada em `cAcessoBD`
- Arquivo: `ncComum/acessobd.vb`
- Adicionar: `ExecutarINT(sql As String, parametros As MySqlParameter())` e equivalente para `ExecutarDS`
- Não remover as sobrecargas existentes ainda (compatibilidade)

### TASK-06 Migrar `pVenda` para queries parametrizadas
- Substituir toda concatenação de `cFuncoes.PersistirTexto` por `MySqlParameter`
- Usar as novas sobrecargas de TASK-05
- Testar manualmente: incluir venda, consultar, excluir

### TASK-07 Migrar `pCliente` e `pProduto` para queries parametrizadas
- Mesmo procedimento de TASK-06

### TASK-08 Migrar os demais `pXxx` restantes
- Todos os arquivos em `ncPersistencia/` que ainda usam concatenação
- Após esta task, remover `PersistirTexto` e `PersistirInteiro` de `cFuncoes` (ou marcar como `Obsolete`)

---

## Fase 3 — Segurança de Configuração

**Meta:** nenhum segredo no código-fonte ou versionado.

### TASK-09 Externalizar chaves de criptografia
- Arquivo: `ncComum/criptografia.vb`
- Ler `sKy` e `sIV` de variável de ambiente `NASCOM_CRYPTO_KEY` e `NASCOM_CRYPTO_IV`
- Fallback para as chaves atuais somente em modo Debug (com Warning no log)

### TASK-10 Externalizar credenciais do `app.config`
- Senha de e-mail (`nascomercioPass`): mover para variável de ambiente `NASCOM_MAIL_PASS`
- Senha do banco: manter criptografada no config mas com chave lida do ambiente (TASK-09 resolve)
- Criar `app.config.example` sem valores reais e adicionar ao `.gitignore` o `app.config` real

---

## Fase 4 — Logging Estruturado

**Meta:** rastreabilidade sem depender de INSERT no banco.

### TASK-11 Adicionar Serilog ao `ncComum`
- Instalar `Serilog` e `Serilog.Sinks.File` via NuGet
- Inicializar em `ncComum` com sink de arquivo em `C:\nascomercio\logs\nascom-.log` (rolling diário)

### TASK-12 Substituir `cLog.GravarLog` por Serilog
- Manter a assinatura pública de `cLog.GravarLog` para não quebrar chamadas existentes
- Internamente chamar `Log.Information(...)` ao invés de INSERT direto
- O sink de banco (INSERT em `log`) pode ser mantido como sink adicional configurável

---

## Fase 5 — Lógica de Negócio nos Formulários

**Meta:** formulários WinForms só chamam `IServicoXxx`; zero lógica de domínio na UI.

### TASK-13 Auditar `fCaixa.vb` e extrair lógica para `rVenda`
- Identificar todo código que não seja UI (validações, cálculos, decisões de negócio)
- Mover para métodos em `rVenda` ou criar novos métodos auxiliares
- `fCaixa` passa a chamar apenas `IServicoVenda`

### TASK-14 Auditar demais formulários de alta complexidade
Ordem sugerida: `fOrdemServico`, `fCrediarioForm`, `fPagamento`, `fNotaFiscalFornecedorForm`
- Mesma abordagem de TASK-13

---

## Fase 6 — Consolidação Fiscal

**Meta:** uma única biblioteca de emissão fiscal.

### TASK-15 Remover referência a `Zeus.Net.NFe.NFCe`
- Verificar se há chamadas diretas à biblioteca Zeus no código (grep por `Zeus`)
- Se houver, mapear equivalente na Unimake.DFe
- Remover o pacote da solution e dos `packages.config`

### TASK-16 Criar interface `INFCeService` em `ncComum`
- Arquivo: `ncComum/INFCeService.vb`
- Métodos: `GerarNF(...)`, `CancelarNF(...)`, `ConsultarStatus(...)`
- `LibNF65` implementa essa interface
- Formulários referenciam apenas `INFCeService`

---

## Fase 7 — Testes

**Meta:** cobertura mínima nas regras de negócio críticas.

### TASK-17 Criar projeto `nascomercio.Tests` (MSTest)
- Adicionar à solution `nascomercio.sln`
- Referenciar `ncRegras`, `ncDados`, `ncComum`
- Criar mock simples de `IRepositorioVenda` com `Moq` ou implementação manual

### TASK-18 Escrever testes para `rVenda`
- Caminho feliz: `Incluir` com dados válidos
- Erro: `Incluir` com produto sem estoque
- Erro: `Consultar` com filtro vazio

### TASK-19 Escrever testes para `rCaixa` e `rCliente`
- Ao menos um teste por método público com lógica real

---

## Fase 8 — Migrações de Banco

**Meta:** histórico de schema versionado e aplicável de forma automatizada.

### TASK-20 Adotar Flyway CLI para as migrations
- Criar pasta `db/migrations/`
- Renomear os scripts de `scripts/` para o padrão Flyway: `V001__descricao.sql`, `V002__...`, etc.
- Criar `db/flyway.conf` com URL, usuário e senha lidos de variável de ambiente
- Documentar comando de aplicação no `README.md`

---

## Checklist de Conclusão Geral

- [ ] Fase 1: todas as entidades críticas têm interface; `ISessionContext` em uso
- [ ] Fase 2: zero concatenação de valores em SQL; `PersistirTexto` removido ou obsoleto
- [ ] Fase 3: nenhum segredo no repositório git
- [ ] Fase 4: logs gravados em arquivo; `cLog` não faz INSERT direto
- [ ] Fase 5: `fCaixa` sem lógica de domínio
- [ ] Fase 6: Zeus.Net removido; `INFCeService` em uso
- [ ] Fase 7: projeto de testes existente com cobertura de `rVenda`, `rCaixa`, `rCliente`
- [ ] Fase 8: migrations em `db/migrations/` aplicáveis via Flyway
