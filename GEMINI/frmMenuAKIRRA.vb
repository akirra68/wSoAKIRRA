Imports SKK02OBJECTS
Imports SKK03SECURITY
Imports wSo

Public Class frmMenuAKIRRA

    Implements IDisposable

    Public _objUserProp As clsUserGEMINI
    Public _objUserPropWS As clsWSNasaUser

    Public vsServerTarget As String = ""

    Public vsUserId As String = ""
    Public vsUserName As String = ""
    Public vsFileVersion As String = ""

    Private vsTitle As String = ""

    Private _loginForm As frmLoginAKIRRA

#Region "form - event"
    Public Sub New(loginForm As frmLoginAKIRRA)

        ' This call is required by the designer.
        InitializeComponent()

        _loginForm = loginForm

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Async Sub GEMINI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try
            Cursor = Cursors.WaitCursor

            Dim vsImgPath As String = System.IO.Path.Combine(Application.StartupPath, "Images\skk.png")
            Dim _oImg As Image = Nothing
            If IO.File.Exists(vsImgPath) Then
                _oImg = Image.FromFile(vsImgPath)
            End If

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowSkinSplashScreen(
                logoImage:=_oImg, title:="wSo | (Warehouse SO) File Uploader", subtitle:="v" & vsFileVersion + Environment.NewLine + "Welcome " & Environment.UserName, footer:="Copyright ©" & DateTime.Now.Year & " AKIRRA." & Environment.NewLine & "All Rights reserved.", loading:="Starting...", parentForm:=Me, throwExceptionIfAlreadyOpened:=True)

            System.Threading.Thread.Sleep(4000)

        Catch ex As Exception
            MessageBox.Show("Splash Screen error : " & ex.Message)
        Finally
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
            'Me.Show()
        End Try

        Me.WindowState = FormWindowState.Maximized
        Me.Text = "Main Menu | wSo (Warehouse SO) File Uploader"

        vsTitle = "wSo (Warehouse SO) File Uploader. [Version : " & vsFileVersion &
    ", Name : " & vsUserName & ", Local IP : " & _objUserPropWS._UserProp05IPLocalAddress & ", Public IP : " & _objUserPropWS._UserProp06IPPublicAddress & "] - [Server : " & vsServerTarget & "]."

        Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub frmMenuAKIRRA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each frm As Form In Application.OpenForms.OfType(Of Form).ToList()
            If frm IsNot Me AndAlso frm IsNot _loginForm Then
                frm.Close()
            End If
        Next

        _clsSkinHelper.pbm01ApplyRandomSkins(_objUserProp, _objUserPropWS)

        _loginForm.Show()
    End Sub


    Private Sub mnuBUP01wSo_Click(sender As Object, e As EventArgs) Handles mnuBUP01wSo.Click
        Dim vsTitleText As String = vsTitle
        Dim _oBUP As New uc24IX01BULKUPLOAD With {.Dock = DockStyle.Fill, ._objUserPropWS = _objUserPropWS,
        ._enmTarget = uc24IX01BULKUPLOAD.targetBulkUpload._BUP01Stock}

        Dim _frmBUP As New DevExpress.XtraEditors.XtraForm With {.Name = vsTitle, .Text = vsTitleText, .WindowState = FormWindowState.Maximized}
        _frmBUP.Controls.Add(_oBUP)
        _frmBUP.Show()
    End Sub

    Private Sub mnuBUP02wSoLD_Click(sender As Object, e As EventArgs) Handles mnuBUP02wSoLD.Click
        Dim msg As MsgBoxResult = MsgBox("Please ensure that wsTABLE29 Trigger's has been DISABLED." & vbCrLf + vbCrLf & "Or contact IT if needed.", vbOKOnly + MsgBoxStyle.Exclamation, "wSo (Warehouse SO) File Uploader")

        If msg = MsgBoxResult.Ok Then
            Dim vsTitleText As String = vsTitle
            Dim _oBUP As New uc24IX01BULKUPLOAD With {.Dock = DockStyle.Fill, ._objUserPropWS = _objUserPropWS,
        ._enmTarget = uc24IX01BULKUPLOAD.targetBulkUpload._BUP02Sold}

            Dim _frmBUP As New DevExpress.XtraEditors.XtraForm With {.Name = vsTitle, .Text = vsTitleText, .WindowState = FormWindowState.Maximized}
            _frmBUP.Controls.Add(_oBUP)
            _frmBUP.Show()
        End If

    End Sub

End Class