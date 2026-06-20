; Script do Inno Setup para o projeto Nascomercio
; Gerado automaticamente para ser portátil e completo.

#define AppName "Nascomercio"
#define AppVersion "2.3.2.0"
#define AppPublisher "Nascom Tecnologia em Informática Ltda"
#define AppURL "https://www.nascom.com.br"
#define AppExeName "nascomercio.exe"
#define AppIconName "unimake.ico"

[Setup]
; Identificação básica
AppId={{54bd77f2-1065-4dc0-a256-b60bf5e0732d}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}
AppUpdatesURL={#AppURL}

; Diretórios e Saída
DefaultDirName={pf}\{#AppName}
DefaultGroupName={#AppName}
OutputDir=Output
OutputBaseFilename=Instalador_Nascomercio_v{#AppVersion}
SetupIconFile=..\nascomercio\{#AppIconName}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern

; Configurações de Instalação
PrivilegesRequired=admin
ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Executável principal e arquivos na pasta bin
Source: "..\nascomercio\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Arquivos adicionais na raiz do projeto (se houver necessidade específica)
Source: "..\nascomercio\fundo.jpg"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\nascomercio\DarumaFrameWork_SAT.xml"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExeName}"
Name: "{group}\{cm:UninstallProgram,{#AppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Registry]
Root: HKA; Subkey: "Software\Microsoft\Windows\CurrentVersion\App Paths\{#AppExeName}"; ValueType: string; ValueName: ""; ValueData: "{app}\{#AppExeName}"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Microsoft\Windows\CurrentVersion\App Paths\{#AppExeName}"; ValueType: string; ValueName: "Path"; ValueData: "{app}"; Flags: uninsdeletevalue

[Run]
Filename: "{app}\{#AppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
// Procedimento para garantir permissões de escrita na pasta do App se necessário
procedure CurStepChanged(CurStep: TSetupStep);
var
  ResultCode: Integer;
begin
  if CurStep = ssPostInstall then
  begin
    // Exemplo: conceder permissões totais à pasta de instalação para evitar problemas com arquivos de config/logs
    Exec('icacls', '"' + ExpandConstant('{app}') + '" /grant Users:(OI)(CI)F /T', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
  end;
end;
