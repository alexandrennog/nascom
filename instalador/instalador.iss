; Script gerado a partir do manifesto ClickOnce para o projeto "nascomercio"
; Considere que todos os arquivos de origem estão em: C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug

[Setup]
; Identificação básica do instalador
AppId={{8A5F5E3A-9C3D-4B2A-8F1C-2E4D6B8A0F1C} ; Um GUID único para identificar o aplicativo
AppName=Nascomercio
AppVersion=2.3.2.0
AppPublisher=Sua Empresa
AppPublisherURL=https://www.seusite.com.br
AppSupportURL=https://www.seusite.com.br/suporte
AppUpdatesURL=https://www.seusite.com.br/atualizacoes

; Diretório de instalação padrão
DefaultDirName={pf}\Nascomercio
DefaultGroupName=Nascomercio
AllowNoIcons=yes

; Informações sobre o arquivo de saída
OutputDir=.
OutputBaseFilename=Instalador_Nascomercio_Setup

; Ícone do instalador (opcional, se você tiver um .ico)
; SetupIconFile=seu_icone.ico

; Compressão e configurações de instalação
Compression=lzma2
SolidCompression=yes
WizardStyle=modern

; Requer privilégios de administrador? (Baseado no manifesto: asInvoker)
; 'priviligedRequired' é mais seguro para escrever em Program Files.
; Se o app pode rodar sem admin, mude para 'lowest'.
PrivilegesRequired=admin
PrivilegesRequiredOverridesAllowed=dialog

; Arquitetura do sistema (32 bits)
ArchitecturesAllowed=x86
ArchitecturesInstallIn64BitMode=x64

; Desabilita a página de seleção de idioma se não for necessário
ShowLanguageDialog=yes

[Languages]
Name: "portuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1

; --- ARQUIVOS A SEREM INSTALADOS ---
; Todos os caminhos Source são relativos à pasta que você informou.
; O parâmetro "Flags: ignoreversion" substitui arquivos mais antigos.
; "recursesubdirs" é usado para a pasta Resources.

[Files]
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\AWSSDK.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\AWSSDK.S3.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\BouncyCastle.Crypto.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\BouncyCastle.Cryptography.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Dapper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\itextsharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\LibNF65.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.Bcl.AsyncInterfaces.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.Bcl.Cryptography.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.ReportViewer.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.ReportViewer.DataVisualization.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.ReportViewer.ProcessingObjectModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Microsoft.ReportViewer.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\MySql.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\nascomercio.exe"; DestDir: "{app}"; Flags: ignoreversion; AfterInstall: "SetPermissions"; 
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
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.Threading.Tasks.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Business.DFe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Cryptography.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Security.Platform.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Unidanfe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\Unimake.Utils.dll"; DestDir: "{app}"; Flags: ignoreversion

; --- ARQUIVOS ADICIONAIS (SEM DEPENDÊNCIA NO MANIFESTO) ---
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\DarumaFrameWork_SAT.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\fundo.jpg"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jjail\Projetos\nascom\nascomercio\bin\Debug\nascomercio.exe.config"; DestDir: "{app}"; Flags: ignoreversion



; --- CONFIGURAÇÕES DE EXECUÇÃO (REGISTRO) ---
[Registry]
; Torna o aplicativo visível em "Adicionar ou Remover Programas" (já é padrão, mas útil para configurar)
Root: HKA; Subkey: "Software\Microsoft\Windows\CurrentVersion\App Paths\nascomercio.exe"; ValueType: string; ValueName: ""; ValueData: "{app}\nascomercio.exe"; Flags: uninsdeletevalue

; --- CÓDIGO PERSONALIZADO (PERMISSÕES) ---
[Code]
procedure SetPermissions();
var
  FilePath: string;
begin
  FilePath := ExpandConstant('{app}') + '\nascomercio.exe';
  if FileExists(FilePath) then
  begin
    // Concede permissão total para usuários (Útil se o app precisar gravar na própria pasta)
    // Isso requer que o instalador rode como admin. Se não quiser isso, remova ou modifique.
    if not SetFilePermissions(FilePath, 'Users', 'FullControl') then
      Log('Não foi possível definir permissões para usuários em ' + FilePath);
  end;
end;

// Função auxiliar para definir permissões (usando icacls via shell)
function SetFilePermissions(FilePath, User, Permissions: string): Boolean;
var
  ResultCode: Integer;
  Command: string;
begin
  Command := Format('icacls "%s" /grant "%s:%s" /T', [FilePath, User, Permissions]);
  Result := Exec(ExpandConstant('{cmd}'), '/c ' + Command, '', SW_HIDE, ewWaitUntilTerminated, ResultCode) and (ResultCode = 0);
end;

// Executa após a instalação, para qualquer outra configuração
procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    Log('Instalação concluída. Permissões aplicadas.');
  end;
end;