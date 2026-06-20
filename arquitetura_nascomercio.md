# Estudo Arquitetural — Nascomercio
**Branch:** `feature/nascomnew`  
**Data:** 2026-06-20  
**Objetivo:** Base de conhecimento para refactoring arquitetural

---

## 1. Visão Geral

O Nascomercio é um **sistema de gestão comercial (ERP) desktop**, desenvolvido como aplicação Windows Forms em **VB.NET** com alguns módulos auxiliares em **C#**. Opera sobre banco de dados **MySQL** local e é distribuído como executável instalado na máquina do cliente (PDV/loja).

O sistema cobre os domínios de: PDV/Caixa, Estoque, Clientes, Fornecedores, Crediário, Contas a Pagar, Ordem de Serviço, Nota Fiscal Eletrônica (NF-e/NF-Ce), SPED/EFD e Relatórios.

---

## 2. Estrutura da Solution

A solution `nascomercio.sln` é composta por **10 projetos** agrupados por responsabilidade:

| Projeto | Linguagem | Tipo | Papel |
|---|---|---|---|
| `nascomercio` | VB.NET | WinForms App | Camada de Apresentação (UI) |
| `ncDados` | VB.NET | Class Library | Modelos de Domínio (DTOs) |
| `ncPersistencia` | VB.NET | Class Library | Acesso a Dados (Repositórios) |
| `ncRegras` | VB.NET | Class Library | Regras de Negócio |
| `ncComum` | VB.NET | Class Library | Infraestrutura Compartilhada |
| `ncEfd` | VB.NET | Class Library | Módulo SPED/EFD Fiscal |
| `LibNF65` | C# | Class Library | Emissão NF-e/NF-Ce (Fiscal) |
| `AssinadorCertificado` | C# | Console App | Utilitário de certificado digital |
| `NCImport` | VB.NET | WinForms App | Utilitário de importação de dados |
| `NasLibackup` | C# | Class Library | Backup automático para AWS S3 |

---

## 3. Arquitetura em Camadas

O projeto segue uma **arquitetura N-Tier** com separação em quatro camadas funcionais:

```
┌─────────────────────────────────────────────────────────┐
│               CAMADA DE APRESENTAÇÃO                    │
│  nascomercio (WinForms)                                 │
│  fCaixa, fProduto, fCliente, fVenda, fRelatorio, ...    │
│  mdiPrincipal (MDI host + controle de sessão)           │
└──────────────────────┬──────────────────────────────────┘
                       │ instancia diretamente
┌──────────────────────▼──────────────────────────────────┐
│               CAMADA DE REGRAS (ncRegras)               │
│  rVenda, rCaixa, rCliente, rProduto, rPix, ...          │
│  Prefixo: r*  |  Namespace: ns<Entidade>               │
└──────────────────────┬──────────────────────────────────┘
                       │ instancia diretamente
┌──────────────────────▼──────────────────────────────────┐
│            CAMADA DE PERSISTÊNCIA (ncPersistencia)      │
│  pVenda, pCaixa, pCliente, pProduto, pPix, ...          │
│  Prefixo: p*  |  Namespace: ns<Entidade>               │
└──────────────────────┬──────────────────────────────────┘
                       │ usa
┌──────────────────────▼──────────────────────────────────┐
│            INFRAESTRUTURA / BANCO (ncComum)             │
│  cAcessoBD → MySQL via MySql.Data                       │
│  ExecutarINT / ExecutarCID / ExecutarDS                 │
└──────────────────────┬──────────────────────────────────┘
                       │
┌──────────────────────▼──────────────────────────────────┐
│                  BANCO DE DADOS                         │
│  MySQL 5.x  |  Schema: nascomercio                      │
│  Views, Stored Procedures, Events agendados             │
└─────────────────────────────────────────────────────────┘
```

### 3.1 Camada de Apresentação — `nascomercio`

- **WinForms MDI**: `mdiPrincipal` é o host MDI que gerencia o ciclo de vida das telas-filhas.
- **Convenção de nomes**: formulários prefixados com `f` (ex: `fCaixa`, `fProdutoForm`, `fClienteLista`).
- **Padrão recorrente**: cada entidade tem três formulários — `fXxxFiltro` (pesquisa), `fXxxForm` (cadastro), `fXxxLista` (listagem).
- **Diretórios**:
  - `formulario/` — todos os formulários de cadastro e operação
  - `principal/` — formulário MDI e login
  - `relatorio/` — formulários de relatório + arquivos `.rdlc` (Microsoft Report)
- **Relatórios**: gerados com `Microsoft.ReportViewer` via arquivos `.rdlc` locais. Há 21 relatórios cobrindo vendas, fechamento, estoque, crediário, PIX, etc.
- **Sessão global**: `mdiPrincipal` mantém variáveis públicas `gUsuario` (dUsuario) e `gLoja` (dLoja) com o estado da sessão corrente. Todas as telas que precisam de contexto acessam essas variáveis diretamente.
- **Controle de perfil/acesso**: feito em `mdiPrincipal.CarregarUsuario()`, que avalia `usuarioPerfil_codigo` (`a`, `g`, `c`, `v`) e `TIPO_TERMINAL` (`CAIXA` ou outro) para definir o modo de operação.

### 3.2 Camada de Modelos — `ncDados`

- Contém apenas **classes de transferência de dados (DTOs)** — sem comportamento.
- Convenção: prefixo `d` (ex: `dVenda`, `dProduto`, `dCliente`).
- Cada entidade tem também uma **coleção tipada**: `ColecaoVenda : Inherits List(Of dVenda)`.
- Organizado por **Namespace** (`nsVenda`, `nsProduto`, etc.) dentro do mesmo assembly.
- As classes usam o padrão VB.NET verboso de propriedades com campo privado `_campo`.

### 3.3 Camada de Persistência — `ncPersistencia`

- Responsável exclusivamente por **queries SQL e mapeamento de DataSet → DTO**.
- Convenção: prefixo `p` (ex: `pVenda`, `pProduto`).
- Cada método constrói SQL **por concatenação de strings** usando helpers de `cFuncoes` (`PersistirTexto`, `PersistirInteiro`, etc.) para escapar valores.
- Acessa o banco via `cAcessoBD` de `ncComum`.
- Usa `DataSet` / `DataTable` / `DataRow` como retorno intermediário.
- Sem ORM — nenhum mapeamento automático.

### 3.4 Camada de Regras — `ncRegras`

- Convenção: prefixo `r` (ex: `rVenda`, `rCaixa`).
- Em boa parte dos casos, as regras **delegam diretamente** para a persistência sem lógica adicional.
- Onde há lógica real: controle de transação com `TransactionScope`, orquestração de múltiplos repositórios (ex: em `rVenda.Incluir`, que persiste venda + produtos + atualiza estoque + gera PIX).
- Usa `Imports System.Transactions` para controle de transações distribuídas.

### 3.5 Infraestrutura Compartilhada — `ncComum`

| Módulo | Responsabilidade |
|---|---|
| `cAcessoBD` | Gerenciamento de conexão MySQL + execução de SQL |
| `cFuncoes` | Funções utilitárias de formatação e persistência de strings SQL |
| `criptografia` | Criptografia AES-256 (Rijndael) com chaves fixas hardcoded |
| `cLog` | Gravação de log de auditoria no banco (tabela `log`) |
| `Impressao` | Impressão raw em impressoras ESC/POS via porta USB/COM/LPT |
| `RawPrinterHelper` | Envio de dados raw para impressora via Win32 API |
| `etiqueta.vb` | Geração de etiquetas de produto |
| `SendMailService` | Envio de e-mail via SMTP Gmail |
| `excecao.vb` | `ExcecaoNascomercio` — exceção customizada |
| `constantes.vb` | Enum `Parametros` com IDs dos parâmetros de configuração |
| `enumeradores.vb` | Enumerações gerais (ex: `EstoqueOperacao`) |
| `EncDec.vb` | Encoder/Decoder auxiliar |
| `comum.vb` | Acesso à configuração PIX via `LibNF65` |

### 3.6 Módulo Fiscal — `LibNF65` (C#)

- Biblioteca independente em **C#** que encapsula toda a emissão e comunicação fiscal.
- Usa a biblioteca **Unimake.DFe** para emissão de NF-Ce (modelo 65) e NF-e.
- Ponto de entrada principal: `NFCe65` — gera XML, assina com certificado X.509, transmite à SEFAZ.
- Usa **Dapper** para acesso ao banco (consulta de configuração PIX/NF).
- Tem estrutura interna com:
  - `Modelo/` — classes de domínio fiscal (`PixConfig`, `ProdutoVendido`, `MeioPagamentoNascom`, `InfoProduto`)
  - `Services/` — `ServiceLocator` (container de DI minimalista), `InfoProdutoService`
  - `Interfaces/` — abstrações (`IInfProtRepository`, `INFCe`, `IInfoProdutoService`)
- Configuração lida do `app.config`: `TipoAmbiente`, `CSC`, `CSCIDToken`, `SchemaVersao`, `CNPJ`.

### 3.7 Módulo EFD/SPED — `ncEfd`

- Implementa a geração do arquivo EFD (Escrita Fiscal Digital / SPED).
- Organizado internamente em três subpastas espelhando a própria arquitetura:
  - `Dados/` — DTOs dos registros EFD (`dReg0000`, `dRegC100`, etc.)
  - `Persistencia/` — leitores dos dados do banco (`pReg0000`, `pRegC100`, etc.)
  - `Regras/` — orquestrador de geração do arquivo (`rArquivo`)
- Depende apenas de `ncComum` (sem referência a `ncDados` ou `ncPersistencia` do core).

---

## 4. Banco de Dados

### 4.1 Tecnologia

- **MySQL 5.x** (conexão configurada para `127.0.1.1:3306`).
- Schema único: `nascomercio`.
- Driver: `MySql.Data` versão 5.x (assembly legado).

### 4.2 Principais Tabelas (inferidas das queries e scripts)

| Tabela | Domínio |
|---|---|
| `vendas`, `vendasprodutos` | PDV / Transações |
| `vales`, `valesprodutos` | Vale-troca |
| `credpag`, `crediario` | Crediário |
| `clientes`, `clientesenderecos` | Clientes |
| `produtos`, `produtositens` | Catálogo de produtos |
| `estoque` | Estoque |
| `caixa` | Operação de caixa |
| `pix`, `pixconfig` | Integração PIX |
| `fornecedores` | Fornecedores |
| `lojas` | Multi-loja |
| `usuarios`, `usuariosperfil` | Controle de acesso |
| `infprot`, `basennf` | Controle NF-e/NF-Ce |
| `log` | Auditoria |
| `parametros` | Configuração do sistema |
| `recent_clients` | Cobrança automatizada (WhatsApp) |
| `curva_abc_resultado` | Análise Curva ABC |

### 4.3 Objetos de Banco

- **Views**: `v_fechamento`, `v_vendas_sintetico`, `v_cheques`, `v_vendasvendedor`, `v_vendas`, `v_vendas_grupo`
- **Stored Procedures**: `sp_backup`, `sp_curva_abc`, `sp_curva_abc_fornecedores_quantidade`
- **Functions**: `fu_getqtdprods`
- **Events (agendados)**: `faz_backup`, `carrega_tabela` — executados diariamente pelo MySQL Event Scheduler

### 4.4 Migrações

O diretório `scripts/` contém **36+ scripts SQL numerados sequencialmente**, que funcionam como histórico de migrações manuais. Não há ferramenta de migração automatizada (Flyway, Liquibase, EF Migrations).

---

## 5. Dependências Externas

### NuGet / Pacotes

| Pacote | Versão | Uso |
|---|---|---|
| `Unimake.DFe` | 20251106 | Emissão NF-e / NF-Ce (XML, SEFAZ) |
| `Unimake.Unidanfe` | 20251029 | DANFE (impressão de NF-e) |
| `Unimake.Cryptography` | 20250912 | Criptografia fiscal |
| `Unimake.Security.Platform` | 20230706 | Segurança certificado digital |
| `Zeus.Net.NFe.NFCe` | 2025.8.12 | Biblioteca alternativa NF-e (referência duplicada) |
| `AWSSDK.S3` | 3.7.509 | Backup automático para Amazon S3 |
| `BouncyCastle.Cryptography` | 2.6.2 | Criptografia assimétrica |
| `iTextSharp` | 5.5.13 | Geração de PDF |
| `QRCoder` | 1.7.0 | Geração de QR Code (PIX) |
| `Dapper` | 2.1.66 | Micro-ORM (apenas em `LibNF65`) |
| `Newtonsoft.Json` | 13.0.3 | Serialização JSON |
| `Microsoft.ReportViewer.WinForms` | 10.0 | Relatórios RDLC |
| `NetBarcode` | 1.0.7 | Geração de código de barras |
| `MySql.Data` | 5.x / 6.x | Driver MySQL (versões conflitantes) |

### Bibliotecas Hardware

| Componente | Uso |
|---|---|
| `Daruma32.dll` | Integração com impressoras Daruma (SAT/fiscal) |
| Win32 `winspool.drv` | Impressão raw ESC/POS |

---

## 6. Configuração e Ambiente

Toda a configuração está em `nascomercio/app.config` (não há suporte a múltiplos ambientes):

- **Connection strings** com senha criptografada (AES-256 com chave fixa)
- **Parâmetros fiscais**: `TipoAmbiente` (1=Produção, 2=Homologação), `CSC`, `CSCIDToken`, `CNPJ`
- **Parâmetros operacionais**: `FISCAL`, `CUPOM`, `ETIQUETA`, `TIPO_TERMINAL`, `NOME_TERMINAL`
- **Integração PIX**: `pathPIX`, `Banco`
- **Backup**: `bucketName`, `directoryBackupPath`, `BACKUPAUTOMATICO`
- **E-mail**: `nascomercioMail`, `nascomercioPass` (senha em texto claro)
- **Identificação**: `clientID`, `Cliente`, `Loja`

---

## 7. Fluxos Principais

### 7.1 Fluxo de Venda (PDV)

```
fCaixa (UI)
  └─► rVenda.Incluir(dVenda, ColecaoVendaProduto)     [ncRegras]
        └─► TransactionScope
              ├─► pVenda.Incluir(dVenda)              [ncPersistencia → MySQL]
              ├─► pVendaProdutos.Incluir(itens)        [ncPersistencia → MySQL]
              ├─► pEstoque.Alterar(subtração)          [ncPersistencia → MySQL]
              └─► pPix.Incluir() (se PIX)             [ncPersistencia → MySQL]
```

### 7.2 Fluxo de Emissão NF-Ce

```
fCaixa (UI)
  └─► LibNF65.NFCe65.GerarNF(produtos, cert, meiosPag, cpf, controle, nNF)   [C#]
        ├─► Unimake.DFe: monta XML NFCe
        ├─► Assina com X.509 (certificado A1/A3)
        ├─► Transmite à SEFAZ (TLS 1.2)
        ├─► Grava protocolo em `infprot`
        └─► Unimake.Unidanfe: imprime DANFE
```

### 7.3 Fluxo de Login e Inicialização

```
mdiPrincipal.New()
  └─► Acesso()
        ├─► VerificarChaveSistema() → consulta tabela parametros
        └─► CarregarUsuario(usuario, senha)
              ├─► rUsuario.Consultar() → valida credenciais
              ├─► Verifica perfil (a/g/c/v) e TIPO_TERMINAL
              ├─► Carrega gUsuario e gLoja (estado global)
              └─► IniciarAdministrador() | IniciarGerente() | IniciarCaixa()
```

---

## 8. Pontos de Atenção para o Refactoring

### 8.1 Riscos de Segurança

- **Chaves de criptografia hardcoded** em `ncComum/criptografia.vb` (`sKy` e `sIV` fixos no código-fonte).
- **Senha de e-mail em texto claro** no `app.config`.
- **SQL por concatenação de strings** na camada de persistência. Embora `cFuncoes.PersistirTexto` tente sanitizar, não usa parâmetros preparados — risco de SQL Injection.
- Apenas `LibNF65` usa Dapper com queries parametrizadas.

### 8.2 Acoplamento e Design

- **Estado global de sessão** em `mdiPrincipal` (`gUsuario`, `gLoja`) acessado diretamente por todas as telas — impede testabilidade e reuso.
- **ncRegras frequentemente não tem lógica real**: muitas classes `r*` são pass-through puro para `p*`, sem validações, sem enriquecimento. As regras de negócio de fato (transações, estoque) ficam misturadas na própria `rVenda` junto com orquestração.
- **Ausência de interfaces**: `ncPersistencia` e `ncRegras` não expõem contratos (interfaces), impossibilitando inversão de dependência ou mocking.
- **Formulários WinForms com lógica de negócio**: `fCaixa.vb` importa diretamente `ncRegras` e `ncDados`, violando a separação da camada de apresentação.
- **Conflitos de merge não resolvidos** em `scripts/27 - objetos_relatorios.sql` (marcadores `<<<<<<`, `=======`, `>>>>>>>`).

### 8.3 Infraestrutura de Banco

- **Sem migração automatizada** — 36+ scripts manuais, sem versionamento formal.
- **Dependência de lógica no banco**: views complexas, stored procedures e eventos agendados dificultam portabilidade.
- **Duas versões do driver MySQL** no projeto (`5.x` em `nascomercio`, `6.x` em `LibNF65`).
- **MySQL 5.x** em EOL — charset `latin1` em tabelas antigas, `utf8` em novas (inconsistência).

### 8.4 Observabilidade e Qualidade

- **Log de auditoria via SQL direto** em `cLog` — sem framework de logging estruturado.
- **Tratamento de exceção genérico**: catch `ex As Exception` em quase todos os métodos, relança como `ExcecaoNascomercio` perdendo stack trace original.
- **Sem testes automatizados** no código principal (MSTest está nos pacotes mas não há projetos de teste para `ncRegras` ou `ncPersistencia`).

### 8.5 Duplicidade

- **Zeus.Net.NFe.NFCe** e **Unimake.DFe** são duas bibliotecas de emissão fiscal distintas presentes na solution — indica migração incompleta.
- Código comentado extensivamente em `LibNF65/NFCe65.cs`, sugerindo evolução incremental e não refatorada.

---

## 9. Mapa de Dependências Entre Projetos

```
nascomercio ──────────────────────────────────────────────────────────────────┐
  ├── ncRegras          (Regras de Negócio)                                   │
  │     ├── ncPersistencia    (Repositórios SQL)                              │
  │     │     ├── ncDados         (DTOs / Domínio)                            │
  │     │     └── ncComum         (Infraestrutura: BD, Funções, Log)         │
  │     ├── ncDados                                                           │
  │     └── ncComum                                                           │
  ├── ncPersistencia                                                          │
  ├── ncDados                                                                 │
  ├── ncComum                                                                 │
  ├── ncEfd             (Módulo EFD/SPED)                                     │
  │     └── ncComum                                                           │
  ├── LibNF65           (Módulo NF-Ce — C#)                                   │
  │     └── Unimake.DFe / Dapper / QRCoder / MySql.Data                      │
  └── NasLibackup       (Backup AWS S3 — C#)                                  │
        └── AWSSDK.S3                                                         │
                                                                              │
NCImport ─────────────────────────────────────────────────────────────────────┘
  ├── ncRegras
  ├── ncDados
  └── ncComum
```

---

## 10. Sumário Executivo para o Refactoring

O Nascomercio possui uma arquitetura N-Tier reconhecível e com separação de camadas declarada, mas com aderência parcial. Os principais focos para um refactoring arquitetural são:

1. **Introduzir interfaces** em `ncPersistencia` e `ncRegras` para habilitar inversão de dependência e testabilidade.
2. **Substituir concatenação SQL** por Dapper ou outro micro-ORM com queries parametrizadas (o padrão já existe em `LibNF65`).
3. **Eliminar estado global** de sessão em `mdiPrincipal` — extrair para um serviço de contexto (`ISessionContext`) injetável.
4. **Mover lógica de negócio** que está nos formulários WinForms para a camada `ncRegras`.
5. **Consolidar a biblioteca fiscal** — eliminar a duplicidade Zeus.Net vs Unimake.DFe.
6. **Externalizar chaves e segredos** do código-fonte e do `app.config` estático para um mecanismo seguro (variáveis de ambiente, Azure Key Vault, etc.).
7. **Adotar ferramenta de migração de banco** (Flyway ou equivalente) para versionamento formal do schema.
8. **Implementar logging estruturado** (Serilog/NLog) substituindo o `cLog` que grava diretamente no MySQL.
9. **Cobrir `ncRegras` com testes unitários** aproveitando a infraestrutura MSTest já nos pacotes.
10. **Padronizar charset do banco** para `utf8mb4` e atualizar o driver MySQL para versão corrente.
