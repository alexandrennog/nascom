@echo off
REM ============================================================================
REM Limpeza de arquivos orfaos e pacotes NuGet duplicados - projeto Nascomercio
REM Gerado em 17/09/2026, a partir de uma auditoria completa comparando o disco
REM contra os 9 .vbproj/.csproj da solution e os 2 packages.config existentes.
REM
REM NAO mexe em nada relacionado a conexao com o banco (MySql.Data.dll, pasta
REM componentes\, ou a referencia do MySQL Connector Net na ncPersistencia) -
REM isso fica como esta, por pedido explicito.
REM
REM Revise a lista abaixo antes de rodar. Cada linha imprime o que esta
REM apagando. Precisa rodar a partir da pasta raiz do projeto (a mesma onde
REM fica o nascomercio.sln) OU ajustar a variavel RAIZ abaixo.
REM ============================================================================

set RAIZ=%~dp0
if not exist "%RAIZ%nascomercio.sln" (
    echo AVISO: nao encontrei nascomercio.sln em "%RAIZ%".
    echo Coloque este .bat na pasta raiz do projeto ^(a mesma do .sln^) e rode de novo.
    pause
    exit /b 1
)

echo.
echo ===== Arquivos de codigo orfaos (nunca referenciados em nenhum .vbproj) =====
echo.

echo Apagando pasta nascomercio\principal\ (fAcesso e mdiPrincipal antigos, substituidos pelos de formulario\)...
rd /s /q "%RAIZ%nascomercio\principal"

echo Apagando nascomercio\Form1.vb / .Designer.vb / .resx (sobra do template padrao do Visual Studio)...
del /q "%RAIZ%nascomercio\Form1.vb"
del /q "%RAIZ%nascomercio\Form1.Designer.vb"
del /q "%RAIZ%nascomercio\Form1.resx"

echo Apagando nascomercio\Settings1.Designer.vb / .settings (sobra do template padrao)...
del /q "%RAIZ%nascomercio\Settings1.Designer.vb"
del /q "%RAIZ%nascomercio\Settings1.settings"

echo Apagando nascomercio\formulario\comum.vb (classe vazia, sem uso)...
del /q "%RAIZ%nascomercio\formulario\comum.vb"

echo Apagando nascomercio\formulario\fPixConfigForm.vb / .Designer.vb / .resx (tela orfa, nome enganoso - mexe em Cor, nao em Pix)...
del /q "%RAIZ%nascomercio\formulario\fPixConfigForm.vb"
del /q "%RAIZ%nascomercio\formulario\fPixConfigForm.Designer.vb"
del /q "%RAIZ%nascomercio\formulario\fPixConfigForm.resx"

echo.
echo ===== Pacotes NuGet duplicados/nao usados (nao aparecem em nenhum packages.config nem .vbproj/.csproj) =====
echo.

for %%P in (
    "AWSSDK.Core.3.7.500.61"
    "AWSSDK.S3.3.7.509.2"
    "BouncyCastle.Cryptography.2.6.1"
    "DFeBR.EmissorNFe.0.0.1"
    "Microsoft.Bcl.AsyncInterfaces.10.0.1"
    "Microsoft.Bcl.Cryptography.9.0.9"
    "Microsoft.SqlServer.Types.14.0.314.76"
    "MSTest.Analyzers.3.10.0"
    "MSTest.TestAdapter.2.2.10"
    "MSTest.TestFramework.2.2.10"
    "MSTest.TestFramework.3.10.0"
    "NetBarcode.1.0.7"
    "Newtonsoft.Json.12.0.2"
    "QRCoder.1.3.5"
    "System.Buffers.4.6.1"
    "System.Drawing.Common.4.5.0"
    "System.Formats.Asn1.9.0.9"
    "System.IO.Pipelines.10.0.1"
    "System.Memory.4.6.3"
    "System.Numerics.Vectors.4.6.1"
    "System.Runtime.CompilerServices.Unsafe.4.5.3"
    "System.Runtime.CompilerServices.Unsafe.6.1.2"
    "System.Security.AccessControl.4.5.0"
    "System.Security.Cryptography.Algorithms.4.3.0"
    "System.Security.Cryptography.X509Certificates.4.3.2"
    "System.Security.Cryptography.Xml.4.5.0"
    "System.Security.Cryptography.Xml.9.0.9"
    "System.Security.Permissions.4.5.0"
    "System.Security.Principal.Windows.4.5.0"
    "System.Text.Encodings.Web.10.0.1"
    "System.Text.Json.6.0.0"
    "System.Threading.Tasks.Extensions.4.6.3"
    "System.ValueTuple.4.6.1"
    "Unimake.DFe.20250917.1627.18"
    "Unimake.Unidanfe.20250821.1702.23"
    "Zeus.Net.NFe.NFCe.2025.7.28.1818"
    "Zeus.Net.NFe.NFCe.2025.8.12.1032"
) do (
    if exist "%RAIZ%packages\%%~P" (
        echo Apagando packages\%%~P ...
        rd /s /q "%RAIZ%packages\%%~P"
    )
)

echo.
echo ===== Concluido. Nada em componentes\ ou nas referencias de MySql.Data foi tocado. =====
echo.
echo Abra a solution no Visual Studio e rode Limpar Solucao + Recompilar Solucao
echo para confirmar que continua tudo compilando normalmente.
echo.
pause
