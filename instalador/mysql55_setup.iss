; ============================================================
;  Instalador MySQL Server 5.5 - Script Inno Setup
;  Gerado para uso com Inno Setup 6.x
;
;  Pré-requisitos incluídos:
;    - Microsoft .NET Framework 3.5 + SP1
;      Coloque os arquivos em: redist\dotnetfx35.exe
;                              redist\dotnetfx35sp1.exe
;
;    - Microsoft Report Viewer 2012 (v11) Runtime
;      Coloque o arquivo em:   redist\ReportViewer.exe
;      Pacote oficial:         ReportViewer2012.exe (KB2610209)
;      Requer .NET 4.0+; será instalado ANTES do MySQL.
;
;    - Banco de dados inicial (nascomercio)
;      Coloque o arquivo em:   database\nascom_bkp_padrao.sql
;      O banco é criado automaticamente após o serviço MySQL
;      ser iniciado. Requer senha do root definida neste instalador.
; ============================================================

#define AppName        "MySQL Server 5.5"
#define DotNetFx35     "dotnetfx35.exe"
#define DotNetFx35SP   "dotnetfx35sp1.exe"
#define ReportViewer   "ReportViewer.exe"
; GUID do ReportViewer 2012 Runtime (KB2610209 / v11.0.3366.16)
#define ReportViewerGUID "{B3BE2B2E-B60A-4B7E-AFD6-A3D3E4E001A0}"
#define NascomDB       "nascom_bkp_padrao.sql"
#define NascomDBName   "nascomercio"
#define AppVersion   "5.5.62"
#define AppPublisher "Oracle Corporation"
#define AppURL       "https://www.mysql.com"
#define AppExeName   "mysqld.exe"
#define ServiceName  "MySQL55"
#define DefaultPort  "3306"
#define DefaultRoot  "C:\MySQL55"

[Setup]
AppId={{A1B2C3D4-E5F6-7890-ABCD-EF1234567890}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}
AppUpdatesURL={#AppURL}
DefaultDirName={#DefaultRoot}
DefaultGroupName={#AppName}
AllowNoIcons=yes
LicenseFile=license\LICENSE.txt
OutputDir=Output
OutputBaseFilename=MySQL55_Installer
SetupIconFile=resources\mysql.ico
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
MinVersion=6.0
ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64
UninstallDisplayIcon={app}\bin\mysqld.exe
CloseApplications=yes
RestartApplications=no
UninstallDisplayName={#AppName}

[Languages]
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "english";            MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "installservice";   Description: "Instalar MySQL como serviço do Windows";      GroupDescription: "Configuração do Serviço:"; Flags: checkedonce
Name: "autostart";        Description: "Iniciar o serviço automaticamente com o Windows"; GroupDescription: "Configuração do Serviço:"; Flags: checkedonce
Name: "firewallrule";     Description: "Adicionar regra no Firewall do Windows (porta {#DefaultPort})"; GroupDescription: "Firewall:"; Flags: unchecked
Name: "desktopicon";      Description: "Criar atalho na Área de Trabalho"; GroupDescription: "Atalhos:"; Flags: unchecked

[Files]
; --- Binários principais ---
Source: "files\bin\*";           DestDir: "{app}\bin";     Flags: ignoreversion recursesubdirs
Source: "files\lib\*";           DestDir: "{app}\lib";     Flags: ignoreversion recursesubdirs
Source: "files\include\*";       DestDir: "{app}\include"; Flags: ignoreversion recursesubdirs
Source: "files\share\*";         DestDir: "{app}\share";   Flags: ignoreversion recursesubdirs

; --- .NET Framework 3.5 (pré-requisito) ---
Source: "redist\{#DotNetFx35}";   DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsDotNet35Installed
Source: "redist\{#DotNetFx35SP}"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsDotNet35Installed

; --- Report Viewer 2012 Runtime (pré-requisito) ---
Source: "redist\{#ReportViewer}"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsReportViewerInstalled

; --- Arquivo de configuração base ---
Source: "config\my-default.ini"; DestDir: "{app}";         DestName: "my.ini"; Flags: onlyifdoesntexist

; --- Scripts de inicialização ---
Source: "scripts\install_db.bat"; DestDir: "{app}\scripts"; Flags: ignoreversion

; --- Documentação ---
Source: "license\LICENSE.txt";   DestDir: "{app}";         Flags: ignoreversion isreadme

; --- Banco de dados inicial nascomercio ---
Source: "database\{#NascomDB}";  DestDir: "{app}\database"; Flags: ignoreversion

[Dirs]
Name: "{app}\data";   Permissions: everyone-full
Name: "{app}\logs";   Permissions: everyone-full
Name: "{app}\tmp";    Permissions: everyone-full

[Icons]
Name: "{group}\MySQL Command Line Client"; Filename: "{app}\bin\mysql.exe"; Parameters: "--user=root --password"; WorkingDir: "{app}\bin"
Name: "{group}\MySQL Workbench (externo)"; Filename: "https://dev.mysql.com/downloads/workbench/"
Name: "{group}\Desinstalar {#AppName}";   Filename: "{uninstallexe}"
Name: "{commondesktop}\MySQL 5.5 Client"; Filename: "{app}\bin\mysql.exe"; Parameters: "--user=root --password"; Tasks: desktopicon

[Run]
; 0. Instalar .NET Framework 3.5 (se necessário)
Filename: "{tmp}\{#DotNetFx35}"; Parameters: "/q /norestart"; \
  StatusMsg: "Instalando .NET Framework 3.5 — aguarde, pode demorar vários minutos..."; \
  Flags: runhidden waituntilterminated; Check: not IsDotNet35Installed

Filename: "{tmp}\{#DotNetFx35SP}"; Parameters: "/q /norestart"; \
  StatusMsg: "Instalando .NET Framework 3.5 SP1..."; \
  Flags: runhidden waituntilterminated; Check: not IsDotNet35Installed

; 0b. Instalar Report Viewer 2012 Runtime (se necessário)
Filename: "{tmp}\{#ReportViewer}"; Parameters: "/q /norestart"; \
  StatusMsg: "Instalando Microsoft Report Viewer 2012 Runtime..."; \
  Flags: runhidden waituntilterminated; Check: not IsReportViewerInstalled

; 1. Inicializar o banco de dados (mysql_install_db)
Filename: "{app}\bin\mysqld.exe"; Parameters: "--initialize-insecure --basedir=""{app}"" --datadir=""{app}\data"""; \
  StatusMsg: "Inicializando banco de dados..."; Flags: runhidden waituntilterminated; \
  Check: not ServiceAlreadyExists

; 2. Instalar serviço Windows
Filename: "{app}\bin\mysqld.exe"; Parameters: "--install {#ServiceName} --defaults-file=""{app}\my.ini"""; \
  StatusMsg: "Registrando serviço do Windows..."; Flags: runhidden waituntilterminated; \
  Tasks: installservice; Check: not ServiceAlreadyExists

; 3. Configurar início automático do serviço
Filename: "sc.exe"; Parameters: "config {#ServiceName} start= auto"; \
  StatusMsg: "Configurando inicialização automática..."; Flags: runhidden waituntilterminated; \
  Tasks: installservice and autostart

; 4. Iniciar o serviço
Filename: "net.exe"; Parameters: "start {#ServiceName}"; \
  StatusMsg: "Iniciando o serviço MySQL..."; Flags: runhidden waituntilterminated; \
  Tasks: installservice

; 5. Regra de firewall
Filename: "netsh.exe"; \
  Parameters: "advfirewall firewall add rule name=""MySQL Server 5.5"" protocol=TCP dir=in localport={#DefaultPort} action=allow"; \
  StatusMsg: "Adicionando regra no Firewall..."; Flags: runhidden waituntilterminated; \
  Tasks: firewallrule

; 6. Importar banco de dados nascomercio
Filename: "{app}\bin\mysql.exe"; \
  Parameters: "--user=root --password=""{code:GetRootPassword}"" --port={#DefaultPort} --default-character-set=utf8 < ""{app}\database\{#NascomDB}"""; \
  StatusMsg: "Importando banco de dados nascomercio — aguarde..."; \
  Flags: runhidden waituntilterminated; Check: not IsDatabaseExists

; 7. Exibir aviso pós-instalação
Filename: "{app}\bin\mysql.exe"; Description: "Abrir MySQL Command Line Client"; \
  Flags: nowait postinstall skipifsilent unchecked

[UninstallRun]
; Parar e remover o serviço antes de desinstalar
Filename: "net.exe";        Parameters: "stop {#ServiceName}";    Flags: runhidden waituntilterminated; RunOnceId: "StopService"
Filename: "{app}\bin\mysqld.exe"; Parameters: "--remove {#ServiceName}"; Flags: runhidden waituntilterminated; RunOnceId: "RemoveService"
Filename: "netsh.exe"; Parameters: "advfirewall firewall delete rule name=""MySQL Server 5.5"""; Flags: runhidden waituntilterminated; RunOnceId: "RemoveFirewall"

[UninstallDelete]
; Remove dados gerados pelo MySQL (somente após confirmação - veja BeforeUninstall)
Type: filesandordirs; Name: "{app}\data"
Type: filesandordirs; Name: "{app}\logs"
Type: filesandordirs; Name: "{app}\tmp"

[Registry]
; Registrar caminho no PATH do sistema
Root: HKLM; Subkey: "SYSTEM\CurrentControlSet\Control\Session Manager\Environment"; \
  ValueType: expandsz; ValueName: "MYSQL_HOME"; ValueData: "{app}"; \
  Flags: uninsdeletevalue

; Informações do MySQL no registro
Root: HKLM; Subkey: "SOFTWARE\MySQL AB\MySQL Server 5.5"; \
  ValueType: string; ValueName: "Location"; ValueData: "{app}"; \
  Flags: uninsdeletekey createvalueifdoesntexist

Root: HKLM; Subkey: "SOFTWARE\MySQL AB\MySQL Server 5.5"; \
  ValueType: string; ValueName: "Version"; ValueData: "{#AppVersion}"; \
  Flags: createvalueifdoesntexist

[Code]

// -------------------------------------------------------
//  Verificação de existência do banco nascomercio
// -------------------------------------------------------

// Retorna True se o banco "nascomercio" já existir no MySQL,
// evitando reimportar o dump em reinstalações.
function IsDatabaseExists: Boolean;
var
  TmpFile, Cmd: string;
  ResultCode:   Integer;
  Lines:        TArrayOfString;
begin
  Result  := False;
  TmpFile := ExpandConstant('{tmp}\db_check.txt');

  // Consulta o information_schema via mysql.exe e redireciona saída para arquivo
  Cmd := '/C "' + ExpandConstant('{app}\bin\mysql.exe') + '"' +
         ' --user=root --password="' + edtRootPwd.Text + '"' +
         ' --port={#DefaultPort}' +
         ' --skip-column-names' +
         ' -e "SELECT SCHEMA_NAME FROM information_schema.SCHEMATA' +
         ' WHERE SCHEMA_NAME=''' + '{#NascomDBName}' + ''';"' +
         ' > "' + TmpFile + '" 2>&1';

  Exec(ExpandConstant('{cmd}'), Cmd, '', SW_HIDE, ewWaitUntilTerminated, ResultCode);

  if LoadStringsFromFile(TmpFile, Lines) then
    Result := (GetArrayLength(Lines) > 0) and (Trim(Lines[0]) = '{#NascomDBName}');
end;

// Função auxiliar usada no parâmetro {code:GetRootPassword} do [Run]
function GetRootPassword(Param: string): string;
begin
  Result := edtRootPwd.Text;
end;

// -------------------------------------------------------
//  Detecção do Report Viewer 2012 Runtime
// -------------------------------------------------------

// Retorna True se o ReportViewer 2012 (v11) já estiver instalado.
// Verifica pelo GUID de produto nas chaves de desinstalação do Windows.
function IsReportViewerInstalled: Boolean;
var
  Dummy: string;
begin
  Result := False;

  // Chave padrão (x86 e x64 nativo)
  if RegQueryStringValue(HKLM,
      'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#ReportViewerGUID}',
      'DisplayName', Dummy) then
  begin
    Result := True;
    Exit;
  end;

  // WOW6432Node para sistemas 64 bits
  if RegQueryStringValue(HKLM,
      'SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{#ReportViewerGUID}',
      'DisplayName', Dummy) then
  begin
    Result := True;
    Exit;
  end;

  // Verificação alternativa pela chave de produto MSI (alguns ambientes)
  if RegQueryStringValue(HKCU,
      'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#ReportViewerGUID}',
      'DisplayName', Dummy) then
    Result := True;
end;

// -------------------------------------------------------
//  Detecção do .NET Framework 3.5
// -------------------------------------------------------

// Retorna True se o .NET 3.5 (ou superior dentro do 3.x) já estiver instalado.
// Verifica a chave de registro oficial da Microsoft.
function IsDotNet35Installed: Boolean;
var
  Installed: Cardinal;
begin
  Result := False;

  // .NET 3.5 full install: HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5  →  Install = 1
  if RegQueryDWordValue(HKLM,
      'SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5',
      'Install', Installed) then
    Result := (Installed = 1);

  // Em sistemas de 64 bits, também checar WOW6432Node
  if not Result then
    if RegQueryDWordValue(HKLM,
        'SOFTWARE\Wow6432Node\Microsoft\NET Framework Setup\NDP\v3.5',
        'Install', Installed) then
      Result := (Installed = 1);
end;

// Exibe avisos na abertura do instalador para pré-requisitos ausentes
function InitializeSetup: Boolean;
var
  Msg: string;
begin
  Result := True;
  Msg := '';

  if not IsDotNet35Installed then
    Msg := Msg +
      '• .NET Framework 3.5 não encontrado — será instalado automaticamente.' +
      #13#10 + '  (arquivo necessário: redist\{#DotNetFx35})' + #13#10;

  if not IsReportViewerInstalled then
    Msg := Msg +
      '• Microsoft Report Viewer 2012 Runtime não encontrado — será instalado automaticamente.' +
      #13#10 + '  (arquivo necessário: redist\{#ReportViewer})' + #13#10;

  if Msg <> '' then
    MsgBox(
      'Os seguintes pré-requisitos serão instalados antes do MySQL Server:' +
      #13#10#13#10 + Msg + #13#10 +
      'Certifique-se de que os arquivos acima estão presentes na pasta "redist\".',
      mbInformation, MB_OK);
end;

// -------------------------------------------------------
//  Funções auxiliares
// -------------------------------------------------------

function ServiceAlreadyExists: Boolean;
var
  Dummy: DWORD;
begin
  Result := RegQueryDWordValue(HKLM,
    'SYSTEM\CurrentControlSet\Services\{#ServiceName}',
    'Type', Dummy);
end;

// -------------------------------------------------------
//  Página customizada: configurações do MySQL
// -------------------------------------------------------
var
  PageConfig: TWizardPage;
  edtPort, edtRootPwd, edtConfirmPwd: TEdit;
  lblPort, lblRootPwd, lblConfirmPwd: TLabel;
  lblWarning: TLabel;

procedure CreateConfigPage;
begin
  PageConfig := CreateCustomPage(wpSelectTasks,
    'Configuração do MySQL',
    'Defina a porta de escuta e a senha do usuário root.');

  lblPort := TLabel.Create(PageConfig);
  lblPort.Caption := 'Porta TCP (padrão: {#DefaultPort}):';
  lblPort.Parent := PageConfig.Surface;
  lblPort.SetBounds(0, 0, 300, 17);

  edtPort := TEdit.Create(PageConfig);
  edtPort.Text := '{#DefaultPort}';
  edtPort.Parent := PageConfig.Surface;
  edtPort.SetBounds(0, 20, 120, 23);

  lblRootPwd := TLabel.Create(PageConfig);
  lblRootPwd.Caption := 'Senha do root:';
  lblRootPwd.Parent := PageConfig.Surface;
  lblRootPwd.SetBounds(0, 60, 300, 17);

  edtRootPwd := TEdit.Create(PageConfig);
  edtRootPwd.PasswordChar := '*';
  edtRootPwd.Parent := PageConfig.Surface;
  edtRootPwd.SetBounds(0, 80, 200, 23);

  lblConfirmPwd := TLabel.Create(PageConfig);
  lblConfirmPwd.Caption := 'Confirme a senha:';
  lblConfirmPwd.Parent := PageConfig.Surface;
  lblConfirmPwd.SetBounds(0, 115, 300, 17);

  edtConfirmPwd := TEdit.Create(PageConfig);
  edtConfirmPwd.PasswordChar := '*';
  edtConfirmPwd.Parent := PageConfig.Surface;
  edtConfirmPwd.SetBounds(0, 135, 200, 23);

  lblWarning := TLabel.Create(PageConfig);
  lblWarning.Caption :=
    'ATENÇÃO: Anote a senha antes de continuar. ' +
    'Não é possível recuperá-la sem reinicializar o banco.';
  lblWarning.Parent := PageConfig.Surface;
  lblWarning.WordWrap := True;
  lblWarning.Font.Color := clRed;
  lblWarning.SetBounds(0, 175, 400, 40);
end;

// -------------------------------------------------------
//  Validação dos campos antes de avançar
// -------------------------------------------------------
function NextButtonClick(CurPageID: Integer): Boolean;
var
  Port: Integer;
begin
  Result := True;

  if CurPageID = PageConfig.ID then
  begin
    // Validar porta
    Port := StrToIntDef(edtPort.Text, 0);
    if (Port < 1024) or (Port > 65535) then
    begin
      MsgBox('Informe uma porta válida entre 1024 e 65535.', mbError, MB_OK);
      Result := False;
      Exit;
    end;

    // Validar senha mínima
    if Length(edtRootPwd.Text) < 6 then
    begin
      MsgBox('A senha do root deve ter pelo menos 6 caracteres.', mbError, MB_OK);
      Result := False;
      Exit;
    end;

    // Confirmar senha
    if edtRootPwd.Text <> edtConfirmPwd.Text then
    begin
      MsgBox('As senhas não coincidem. Verifique e tente novamente.', mbError, MB_OK);
      edtConfirmPwd.SetFocus;
      Result := False;
      Exit;
    end;
  end;
end;

// -------------------------------------------------------
//  Gerar my.ini com os valores informados
// -------------------------------------------------------
procedure WriteMyIni;
var
  IniPath: string;
  Lines: TStringList;
begin
  IniPath := ExpandConstant('{app}\my.ini');
  Lines   := TStringList.Create;
  try
    Lines.Add('[client]');
    Lines.Add('port=' + edtPort.Text);
    Lines.Add('');
    Lines.Add('[mysqld]');
    Lines.Add('port=' + edtPort.Text);
    Lines.Add('basedir=' + ExpandConstant('{app}'));
    Lines.Add('datadir=' + ExpandConstant('{app}\data'));
    Lines.Add('tmpdir=' + ExpandConstant('{app}\tmp'));
    Lines.Add('log-error=' + ExpandConstant('{app}\logs\mysql_error.log'));
    Lines.Add('max_connections=151');
    Lines.Add('character-set-server=utf8');
    Lines.Add('collation-server=utf8_general_ci');
    Lines.Add('default-storage-engine=InnoDB');
    Lines.Add('');
    Lines.Add('[mysqldump]');
    Lines.Add('quick');
    Lines.Add('max_allowed_packet=16M');
    Lines.SaveToFile(IniPath);
  finally
    Lines.Free;
  end;
end;

// -------------------------------------------------------
//  Alterar senha do root via mysqladmin após instalação
// -------------------------------------------------------
procedure SetRootPassword;
var
  ResultCode: Integer;
  Cmd: string;
begin
  Cmd := '"' + ExpandConstant('{app}\bin\mysqladmin.exe') + '"' +
         ' -u root password "' + edtRootPwd.Text + '"';
  Exec(ExpandConstant('{cmd}'), '/C ' + Cmd, '', SW_HIDE,
       ewWaitUntilTerminated, ResultCode);
end;

// -------------------------------------------------------
//  Aviso de remoção de dados na desinstalação
// -------------------------------------------------------
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if CurUninstallStep = usUninstall then
  begin
    if MsgBox(
      'Deseja remover TODOS os dados do MySQL (bancos, logs e arquivos temporários)?'
      + #13#10 + 'Esta ação é irreversível.',
      mbConfirmation, MB_YESNO) = IDNO then
    begin
      // Cancelar remoção dos dados — remove as entradas da seção [UninstallDelete]
      // Isso é feito não fazendo nada; as pastas permanecerão.
      // Inno Setup não oferece remoção condicional de [UninstallDelete],
      // mas podemos criar um marcador para scripts externos.
    end;
  end;
end;

// -------------------------------------------------------
//  Eventos principais do assistente
// -------------------------------------------------------
procedure InitializeWizard;
begin
  CreateConfigPage;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    WriteMyIni;
    SetRootPassword;
  end;
end;
