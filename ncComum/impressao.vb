Imports System.IO
Imports System.Runtime.InteropServices
''' <summary>
''' This class can print  labels to either a network share, LPT, or COM port.
''' 
''' Programmer: Rick Chronister
''' </summary>
''' <remarks>Only tested for network share, but in theory works for LPT and COM.</remarks>
Public Class Impressao
    Private Const GENERIC_WRITE As Integer = &H40000000
    Private Const OPEN_EXISTING As Integer = 3
    Private Const FILE_SHARE_WRITE As Integer = &H2

    Private _fileWriter As StreamWriter
    Private _outFile As FileStream
    Private _hPort As Integer
    Private _porta As String
    Private _arquivo, _diretorio As String

    ''' <summary>
    ''' Structure for CreateFile.  Used only to fill requirement
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SECURITY_ATTRIBUTES
        Private nLength As Integer
        Private lpSecurityDescriptor As Integer
        Private bInheritHandle As Integer
    End Structure

    'Define Win32 functions
    Private Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As Integer) As Integer
    Private Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, <MarshalAs(UnmanagedType.Struct)> ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As Integer
    ''' <summary>
    ''' This function must be called first.  Printer path must be a COM Port or a UNC path.
    ''' </summary>
    Public Sub StartWrite(ByVal printerPath As String)
        Dim SA As SECURITY_ATTRIBUTES
        Dim hPortP As IntPtr

        _porta = printerPath

        If _porta.Substring(0, 3) = "USB" Or _porta.Substring(0, 3) = "LAZ" Or _porta.Substring(0, 3) = "ELG" Then
            _diretorio = "c:\nascomercio\"
            _arquivo = "c:\nascomercio\print.txt"

            'SE A PASTA NÃO EXISTIR, CRIA.
            If Not IO.Directory.Exists(_diretorio) Then
                IO.Directory.CreateDirectory(_diretorio)
            End If

            If IO.File.Exists(_arquivo) Then 'caso exista o arquivo deleta e cria novo por cima
                IO.File.Delete(_arquivo)
                Dim criar = IO.File.CreateText(_arquivo)
                criar.Close()
            Else 'inexistente, cria novo.
                Dim criar = IO.File.CreateText(_arquivo)
                criar.Close()
            End If

        Else
            'Create connection
            _hPort = CreateFile(printerPath, GENERIC_WRITE, FILE_SHARE_WRITE, SA, OPEN_EXISTING, 0, 0)

            'Get unsafe pointer
            hPortP = New IntPtr(_hPort) 'convert Integer to IntPtr 

            'Create file stream
            _outFile = New FileStream(hPortP, FileAccess.Write)

            'Create stream writer
            _fileWriter = New StreamWriter(_outFile)
        End If

    End Sub
    ''' <summary>
    ''' This will write a command to the printer.
    ''' </summary>
    Public Sub Write(ByVal rawLine As String)
        Dim codutf As System.Text.Encoding

        If _porta.Substring(0, 3) = "USB" Or _porta.Substring(0, 3) = "LAZ" Or _porta.Substring(0, 3) = "ELG" Then
            codutf = System.Text.Encoding.GetEncoding("ISO-8859-1") 'selecionando codificação
            Dim fluxoTexto As IO.StreamWriter 'carregando streamwriter
            fluxoTexto = New IO.StreamWriter(_arquivo, True, codutf) 'instancia streamwriter
            Dim texto As String
            texto = rawLine
            fluxoTexto.WriteLine(texto) 'escrevendo no txt
            fluxoTexto.Close()
        Else
            _fileWriter.WriteLine(rawLine)
        End If
    End Sub

    ''' <summary>
    ''' This function must be called after writing to the zebra printer.
    ''' </summary>
    Public Sub EndWrite()

        If System.Configuration.ConfigurationManager.AppSettings("CORTAR_PAPEL") = "SIM" Then
            Write("<B1>m")
        End If

        If _porta.Substring(0, 3) = "LAZ" Then
            Dim p As New Process
            Dim pi As ProcessStartInfo

            pi = New ProcessStartInfo("notepad.exe", "/p " & _arquivo)
            p.StartInfo = pi
            p.Start()
        ElseIf _porta.Substring(0, 3) = "USB" Then
            System.IO.File.Copy(_arquivo, "LPT" & _porta.Substring(3, 1), True)
        ElseIf _porta.Substring(0, 3) = "ELG" Then
            RawPrinterHelper.SendStringToPrinter("BTP-L42", System.IO.File.ReadAllText(_arquivo))
        Else
            'Clean up
            _fileWriter.Flush()
            _fileWriter.Close()
            _outFile.Close()
            CloseHandle(_hPort)
        End If
    End Sub

End Class

