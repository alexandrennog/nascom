Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Configuration

Public Class fCamera

  Public cliente_cid As Integer
  Public existe_foto As Boolean = False

  Const WM_CAP As Short = &H400S

  Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
  Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
  Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30

  Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
  Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
  Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
  Const WS_CHILD As Integer = &H40000000
  Const WS_VISIBLE As Integer = &H10000000
  Const SWP_NOMOVE As Short = &H2S
  Const SWP_NOSIZE As Short = 1
  Const SWP_NOZORDER As Short = &H4S
  Const HWND_BOTTOM As Short = 1

  Dim iDevice As Integer = 0 ' Current device ID
  Dim hHwnd As Integer ' Handle to preview window
  Dim existeCamera = False
  Dim nomeCamera = String.Empty

  Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
      (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
      <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

  Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
      ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
      ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

  Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

  Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
      (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
      ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
      ByVal nHeight As Short, ByVal hWndParent As Integer, _
      ByVal nID As Integer) As Integer

  Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
      ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
      ByVal cbVer As Integer) As Boolean

  Private Sub IniciarCamera()

    CarregarCamera()

    'btnStart.Enabled = True

    picImagem.SizeMode = PictureBoxSizeMode.StretchImage

    iDevice = 0

    IniciarJanela()

  End Sub

  Private Sub FinalizarCamera()
    SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

    '
    ' close window
    '

    DestroyWindow(hHwnd)
  End Sub

  Private Sub CarregarCamera()
    Dim strName As String = Space(100)
    Dim strVer As String = Space(100)
    Dim bReturn As Boolean
    Dim x As Integer = 0

    '   Get Driver name and version
    '
    bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)

    existeCamera = bReturn
    nomeCamera = strName.Trim()
  End Sub

  Private Sub IniciarJanela()
    Dim iHeight As Integer = picImagem.Height
    Dim iWidth As Integer = picImagem.Width

    '
    ' Open Preview window in picturebox
    '
    hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
        480, picImagem.Handle.ToInt32, 0)

    '
    ' Connect to device
    '
    If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
      '
      'Set the preview scale
      '
      SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

      '
      'Set the preview rate in milliseconds
      '
      SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

      '
      'Start previewing the image from the camera
      '
      SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

      '
      ' Resize window to fit in picturebox
      '
      SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picImagem.Width, picImagem.Height, _
              SWP_NOMOVE Or SWP_NOZORDER)

      'btnSave.Enabled = True
      'btnStop.Enabled = True
      'btnStart.Enabled = False
    Else
      '
      ' Error connecting to device close window
      ' 
      DestroyWindow(hHwnd)

      'btnSave.Enabled = False
    End If
  End Sub

  Private Sub fCamera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        FinalizarCamera()
        Me.Close()
      Case Keys.Enter
        SalvarImagem()
    End Select
  End Sub

  Private Sub fCamera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    IniciarCamera()
  End Sub

  Private Sub SalvarImagem()
    '-- Salvar Imagem
    Dim data As IDataObject
    Dim bmap As Image
    Dim dirRaiz As String
    Dim dirFoto As String
    Dim dirFotos As String


    dirFoto = ConfigurationManager.AppSettings.Item("DIRETORIO_FOTO")
    If dirFoto.Contains("\\") Or dirFoto.Contains(":") Then
      dirRaiz = ""
    Else
      dirRaiz = AppDomain.CurrentDomain.BaseDirectory
    End If

    If dirRaiz <> "" Then
      dirFotos = dirRaiz & "\" & dirFoto
    Else
      dirFotos = dirFoto
    End If

    If Not Directory.Exists(dirFotos) Then
      Directory.CreateDirectory(dirFotos)
    End If

    '
    ' Copy image to clipboard
    '
    SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

    '
    ' Get image from clipboard and convert it to a bitmap
    '
    data = Clipboard.GetDataObject()
    If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
      bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
      picImagem.Image = bmap
      FinalizarCamera()

      bmap.Save(dirFotos & "\foto" & Me.cliente_cid.ToString() & ".jpg", Imaging.ImageFormat.Jpeg)

      existe_foto = True
      bmap = Nothing
    End If

    Me.Close()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    FinalizarCamera()
    Me.Close()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    SalvarImagem()
  End Sub

End Class