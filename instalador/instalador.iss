[Setup]
AppId={{8A5F5E3A-9C3D-4B2A-8F1C-2E4D6B8A0F1C}
AppName=Nascomercio
AppVersion=2.3.2.0
AppPublisher=Sua Empresa
AppPublisherURL=https://www.seusite.com.br
AppSupportURL=https://www.seusite.com.br/suporte
AppUpdatesURL=https://www.seusite.com.br/atualizacoes

DefaultDirName={pf}\Nascomercio
DefaultGroupName=Nascomercio
AllowNoIcons=yes

OutputDir=.
OutputBaseFilename=Instalador_Nascomercio_Setup

Compression=lzma2
SolidCompression=yes
WizardStyle=modern

PrivilegesRequired=admin
PrivilegesRequiredOverridesAllowed=dialog

ArchitecturesAllowed=x86
ArchitecturesInstallIn64BitMode=x64

ShowLanguageDialog=yes

[Languages]
Name: "portuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1

[Files]
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\AWSSDK.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\AWSSDK.S3.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\BouncyCastle.Crypto.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\BouncyCastle.Cryptography.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Dapper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\itextsharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\LibNF65.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.Bcl.Cryptography.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.ReportViewer.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.ReportViewer.DataVisualization.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.ReportViewer.ProcessingObjectModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.ReportViewer.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\MySql.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\nascomercio.exe"; DestDir: "{app}"; Flags: ignoreversion; AfterInstall: SetPermissions
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\NasLibackup.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\ncComum.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\ncDados.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\ncEfd.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\ncPersistencia.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\ncRegras.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\QRCoder.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.Buffers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.Formats.Asn1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.Memory.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.Security.Cryptography.Cng.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.Security.Cryptography.Xml.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Business.DFe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Cryptography.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Security.Platform.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Unidanfe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Utils.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\fundo.jpg"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\nascomercio.exe.config"; DestDir: "{app}"; Flags: ignoreversion

; MySQL — copiado para pasta temporária e apagado após instalação
Source: "C:\Instalador\mysql-5.5.41-win32.msi"; DestDir: "{tmp}"; Flags: ignoreversion deleteafterinstall

[Registry]
Root: HKA; Subkey: "Software\Microsoft\Windows\CurrentVersion\App Paths\nascomercio.exe"; ValueType: string; ValueName: ""; ValueData: "{app}\nascomercio.exe"; Flags: uninsdeletevalue

[Code]
// ✅ 1. INSTALAÇÃO SILENCIOSA DO MySQL
procedure InstallMySQL();
var
  ResultCode: Integer;
begin
  if Exec('msiexec.exe',
    '/i "' + ExpandConstant('{tmp}') + '\mysql-5.5.41-win32.msi" /qn /norestart',
    '', SW_HIDE, ewWaitUntilTerminated, ResultCode) then
  begin
    if ResultCode = 0 then
      Log('MySQL instalado com sucesso.')
    else
      MsgBox('Aviso: MySQL retornou código ' + IntToStr(ResultCode) +
             '. Verifique se já está instalado.', mbInformation, MB_OK);
  end
  else
    MsgBox('Erro ao executar o instalador do MySQL.', mbError, MB_OK);
end;

// ✅ 2. FUNÇÃO AUXILIAR DE PERMISSÕES
function SetFilePermissions(FilePath, User, Permissions: string): Boolean;
var
  ResultCode: Integer;
  Command: string;
begin
  Command := Format('icacls "%s" /grant "%s:%s" /T', [FilePath, User, Permissions]);
  Result := Exec(ExpandConstant('{cmd}'), '/c ' + Command, '', SW_HIDE, ewWaitUntilTerminated, ResultCode)
            and (ResultCode = 0);
end;

// ✅ 3. PROCEDURE DE PERMISSÕES
procedure SetPermissions();
var
  FilePath: string;
begin
  FilePath := ExpandConstant('{app}') + '\nascomercio.exe';
  if FileExists(FilePath) then
  begin
    if not SetFilePermissions(FilePath, 'Users', 'FullControl') then
      Log('Não foi possível definir permissões para usuários em ' + FilePath);
  end;
end;

// ✅ 4. EVENTO PÓS-INSTALAÇÃO
procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    InstallMySQL();
    Log('Instalação concluída. Permissões aplicadas.');
  end;
end;