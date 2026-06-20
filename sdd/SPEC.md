# SPEC — Refactoring Arquitetural Nascomercio

## Contexto

Sistema ERP desktop (WinForms / VB.NET + .NET 4.7.2) para gestão comercial de lojas.  
A arquitetura atual é N-Tier com quatro camadas declaradas (`ncDados`, `ncPersistencia`, `ncRegras`, `nascomercio`), mas com aderência parcial.  
Este spec orienta o refactoring incremental sem reescrita total.

---

## Objetivo

Evoluir a base de código para que cada camada respeite seu contrato, sem mudar a stack nem o banco de dados. O refactoring deve ser executável por fase, com o sistema funcionando ao final de cada uma.

---

## Arquitetura Alvo

```
nascomercio (WinForms)
  │  só instancia/injeta; zero lógica de domínio
  ▼
IRegraXxx  ◄──── rXxx (ncRegras)
  │               │  só orquestra; usa TransactionScope onde necessário
  ▼               ▼
IRepositorioXxx ◄─ pXxx (ncPersistencia)
  │               │  só executa SQL parametrizado; retorna DTOs
  ▼               ▼
cAcessoBD (ncComum)   →   MySQL
```

### Regras fixas da arquitetura alvo

1. **Interfaces obrigatórias** — toda classe `rXxx` implementa `IRegraXxx`; toda classe `pXxx` implementa `IRepositorioXxx`. Nenhuma camada superior referencia a implementação concreta diretamente.
2. **SQL parametrizado** — toda query usa `MySqlParameter` ou Dapper. Proibido concatenar valores do usuário em string SQL.
3. **Sem estado global de sessão** — substituir `mdiPrincipal.gUsuario` / `gLoja` por `ISessionContext` injetado nos formulários.
4. **Formulários sem lógica de domínio** — formulários WinForms só chamam `IRegraXxx`. Validações de negócio vivem em `ncRegras`.
5. **Uma única biblioteca fiscal** — apenas `Unimake.DFe`. Remover `Zeus.Net.NFe.NFCe`.
6. **Segredos fora do código** — chaves de criptografia, senhas e tokens lidos de variável de ambiente ou arquivo externo não versionado.
7. **Logging estruturado** — substituir `cLog` (INSERT direto no banco) por Serilog com sink de arquivo. Log no banco pode permanecer como sink adicional opcional.
8. **Testes na camada de regras** — todo método público de `ncRegras` com lógica real tem ao menos um teste MSTest cobrindo o caminho feliz e um caminho de erro.

---

## Fora de Escopo

- Mudança de banco de dados (MySQL permanece)
- Mudança de UI framework (WinForms permanece)
- Mudança de runtime (.NET 4.7.2 permanece)
- Reescrita de `LibNF65` (apenas integrar via interface)
- Migração de dados históricos

---

## Convenções de Código

| Elemento | Convenção |
|---|---|
| Interface de Regra | `IRegra<Entidade>` em `ncRegras` |
| Interface de Repositório | `IRepositorio<Entidade>` em `ncPersistencia` |
| Contexto de sessão | `ISessionContext` em `ncComum` |
| Queries SQL | Sempre com `MySqlParameter`, nunca string interpolada |
| Exceções | Re-lançar com `ExcecaoNascomercio` preservando inner exception |
| Testes | Projeto `nascomercio.Tests` (MSTest), um arquivo por classe testada |

---

## Critério de Conclusão de Cada Fase

- Build sem erros e sem warnings novos
- Testes existentes passando
- Funcionalidade manual verificada no fluxo de Venda e Login
