Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports SKK02OBJECTS
Imports SKK03SECURITY
Imports System.Runtime.InteropServices
Imports SKK03SECURITY.SecurityExceptions
Imports DevExpress.XtraBars.Helpers

Public Class frmLoginAKIRRA
    Implements IDisposable

    Private _objUserProp As clsUserGEMINI
    Private _objUserPropWS As clsWSNasaUser

    Private _oPass As clsSKKSecurity
    Private _oTablemaster As clsGetDataTableMaster

    Private vsUserId As String = ""
    Private vsUserName As String = ""
    Private vsUserInfo As String = ""
    Private vsLocalIpAddress As String
    Private vsPublicIpAddress As String
    Private vsAssemblyVer As String = ""
    Private vsMetadat As String = ""
    Private vsFileVersion As String = ""

    Private vsServerTargetPrivate As String = "172.25.0.2,1500"
    Private vsServerTargetPublic As String = "103.116.201.138,1500"
    Private vsServerTargetPrivateStaging As String = "172.25.0.4"
    Private vsServerTargetPublicStaging As String = "103.116.201.140"

    Private vsSkinName As String = "Coffee" '"VS2013" - "Basic" - "DevExpress Style"
    Private vsUserld As String = ""
    Private vsAllSkins As String() = {
        "Coffee", "Office 2019 Colorful", "Office 2019 White",
        "Visual Studio 2013 Blue", "The Bezier", "DevExpress Style", "Seven", "Seven Classic",
        "Pumpkin", "iMaginary", "Liquid Sky", "Valentine", "Springtime",
        "Summer 2008", "Stardust"
    }

    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        _objUserProp = New clsUserGEMINI With {._UserProp01cTitle = "©2024-" & Year(Now.Date).ToString & " wSo",
                                             ._UserProp02cUserID = "mrv", ._UserProp03cUserName = "AKIRRA"}
        vsUserld = "231123"
        _objUserPropWS = New clsWSNasaUser With {._UserProp01cTitle = "©2021-" & Year(Now.Date).ToString & " wSo",
                                             ._UserProp02cUserID = "mrv", ._UserProp03cUserName = "AKIRRA"}

        _oPass = New clsSKKSecurity
        _oTablemaster = New clsGetDataTableMaster
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        _oTablemaster.Dispose()

        _oTablemaster.Dispose()
    End Sub

    Private Sub frmLoginAKIRRA_Load(sender As Object, e As EventArgs) Handles Me.Load
        _clsSkinHelper.pbm01ApplyRandomSkins(_objUserProp, _objUserPropWS)

        Dim vsImg As String = System.IO.Path.Combine(Application.StartupPath, "Images\wso.png")
        peImage.Image = Image.FromFile(vsImg)
        Me.Text = "SIGN IN | ©2024-" & Year(Now.Date).ToString & " wSo"

        _pvmAsync01GetUserInfo()

        _03cTargetNetwork.Properties.Items.Add("LOCAL [" + vsLocalIpAddress + "]")
        _03cTargetNetwork.Properties.Items.Add("PRIVATE [" + vsServerTargetPrivate + "]")
        _03cTargetNetwork.Properties.Items.Add("PUBLIC [" + vsServerTargetPublic + "]")
        _03cTargetNetwork.Properties.Items.Add("PRIVATE-STAGING [" + vsServerTargetPrivateStaging + "]")
        _03cTargetNetwork.Properties.Items.Add("PUBLIC-STAGING [" + vsServerTargetPublicStaging + "]")

        _03cTargetNetwork.SelectedIndex = 1

        _03cTargetNetwork.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        pvm00ShowMeOnTop()

        _03cTargetNetwork.Focus()
    End Sub

#End Region

#Region "custom - method"

    Private Sub pvm00ShowMeOnTop()
        'Me.WindowState = FormWindowState.Normal
        Me.TopMost = True
        Me.Show()
        Me.BringToFront()
        SetForegroundWindow(Me.Handle)
        Me.TopMost = False
    End Sub

    Private Async Sub _pvmAsync01GetUserInfo()
        Cursor = Cursors.WaitCursor

        vsUserId = "141202"
        vsUserName = Environment.UserName
        vsUserInfo = ""
        vsLocalIpAddress = ""
        vsPublicIpAddress = ""

        ' get user information + OS version
        ' ============================================================================
        Dim vsOsVersion As String = "UnkOS"
        Try
            If Environment.OSVersion.Platform = PlatformID.Win32NT Then
                Dim objSearcher As New System.Management.ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem")
                For Each lpOs As System.Management.ManagementObject In objSearcher.Get()
                    Dim vsCaption As String = lpOs("Caption").ToString()
                    Dim vsCleaned As String = vsCaption.Replace("Microsoft", "").Replace("Windows", "").Trim()

                    Dim vsSplit = vsCleaned.Split(" "c)
                    If vsSplit.Length >= 2 Then
                        Dim vsVersion = vsSplit(0)
                        Dim vsEdition = vsSplit(1)
                        vsOsVersion = vsVersion & vsEdition
                    Else
                        vsOsVersion = vsCleaned.Replace(" ", "")
                    End If

                    Exit For
                Next
            Else
                vsOsVersion = "NonWin"
            End If
        Catch ex As Exception
            vsOsVersion = "UnkOS"
        End Try


        Dim vsMergeUserInfo As String = $"{Environment.UserName}@{Environment.MachineName}#{vsOsVersion}"

        If vsMergeUserInfo.Length > 50 Then
            Dim maxLength As Integer = 50 - 1 - vsOsVersion.Length

            Dim userMachine As String = $"{Environment.UserName}@{Environment.MachineName}"
            If userMachine.Length > maxLength Then
                userMachine = userMachine.Substring(0, maxLength)
            End If

            vsMergeUserInfo = $"{userMachine}#{vsOsVersion}"
        End If

        vsUserInfo = vsMergeUserInfo


        ' get LOCAL & PUBLIC ip address
        ' ============================================================================
        Dim _oIpAddressess = System.Net.Dns.GetHostAddresses(Environment.MachineName)

        For Each lpIp In _oIpAddressess
            If lpIp.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                Dim vsLocalIp = lpIp.ToString()
                If Not String.IsNullOrEmpty(vsLocalIp) AndAlso vsLocalIp <> "0.0.0.0" Then
                    vsLocalIpAddress = vsLocalIp
                    Exit For
                End If
            End If
        Next


        Try
            Dim _oHttpClient As New System.Net.Http.HttpClient
            vsPublicIpAddress = Await _oHttpClient.GetStringAsync("https://api.ipify.org")
            If String.IsNullOrWhiteSpace(vsPublicIpAddress) Then
                vsPublicIpAddress = Await _oHttpClient.GetStringAsync("https://checkip.amazonaws.com")
            End If
        Catch ex As Exception
            Console.WriteLine("Failed to fetch public IP: " & ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Function _pvm02GetFileVersion() As String()

        Dim _oAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim _oFileVer As FileVersionInfo = FileVersionInfo.GetVersionInfo(_oAssembly.Location)

        Dim vsFileVersion As String = _oFileVer.FileVersion
        Dim vsAssemblVersion As String = _oFileVer.Comments
        Dim vsMetadata As String = _oFileVer.LegalCopyright

        Return New String() {vsFileVersion, vsAssemblVersion, vsMetadata}
    End Function

    Private Function _pvm03ValidateFileVersion(ByVal prmiTargetServer As Int16) As Int16
        vsFileVersion = ""
        vsAssemblyVer = ""
        vsMetadat = ""

        Dim vbValid As Int16 = 0
        Dim vsFileVer As String() = _pvm02GetFileVersion()
        Dim vsFileVersionApp As String = vsFileVer(0)

        Dim vdtFileVersionDb As New DataTable
        Dim vsAssemblVersion As String = vsFileVer(1)
        vdtFileVersionDb = _oTablemaster._pb04GetDataAppVersion(prmiTargetServer, "WSO")
        Dim vsMetadata As String = vsFileVer(2)

        For Each lpDataRow As DataRow In vdtFileVersionDb.Rows
            If CStr(lpDataRow("f03String")) = vsFileVersionApp Then
                vsFileVersion = vsFileVersionApp
                If CStr(lpDataRow("f14String")) = vsAssemblVersion And CStr(lpDataRow("f15String")) = vsMetadata Then
                    vsAssemblyVer = vsAssemblVersion
                    vsMetadat = vsMetadata
                    vbValid = 1
                Else
                    vbValid = -1
                End If
            Else
                vbValid = 0

                Dim rsl = XtraMessageBox.Show("A new version of wSo is available" & vbCrLf & vbCrLf &
                                    "Please click YES to get the latest version", "Update to New Version | " & _objUserProp._UserProp01cTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                If rsl = DialogResult.Yes Then
                    Process.Start(New ProcessStartInfo("https://api.whatsapp.com/send?phone=6281387299776&text=Permisi%2C%20mohon%20maaf%20mengganggu%20waktunya..%0ASaya%20ingin%20melakukan%20UPDATE%20program%20'*wSo*'.%0AApakah%20boleh%20dibantu%20%3F%20Terima%20kasih.%0A%0ARegards%2C%0ANama%20%3A%0ADepartment%20%3A") With {.UseShellExecute = True})

                    Application.Exit()
                End If
            End If
        Next

        Return vbValid
    End Function


    Private Sub pvm04LoginProcess()
        If String.IsNullOrEmpty(_03cTargetNetwork.EditValue) Then
            MsgBox("Please select the Server Target..", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _objUserProp._UserProp01cTitle)
        Else
            Cursor.Current = Cursors.WaitCursor

            Dim viServerTarget As Int16 = 0
            Dim vsServerTarget As String = ""
            Select Case _03cTargetNetwork.SelectedIndex
                Case 0
                    viServerTarget = 0  'LOCAL
                    vsServerTarget = vsLocalIpAddress
                Case 1
                    viServerTarget = 1  'PRIVATE/LAN
                    vsServerTarget = vsServerTargetPrivate
                Case 2
                    viServerTarget = 2  'PUBLIC
                    vsServerTarget = vsServerTargetPublic
                Case 3
                    viServerTarget = 3  'STAGING
                    vsServerTarget = vsServerTargetPrivateStaging
                Case 4
                    viServerTarget = 4  'STAGING
                    vsServerTarget = vsServerTargetPublicStaging
            End Select

            Try
                Dim viRsl As Int16 = _pvm03ValidateFileVersion(viServerTarget)
                If viRsl > 0 Then
                    Dim vdtResult As New DataTable
                    vdtResult = _oTablemaster._pb01GetDataUserLOGIN(viServerTarget, vsUserld)

                    If vdtResult.Rows.Count > 0 Then
                        With _oPass
                            For Each dtRow As DataRow In vdtResult.Rows
                                .prop01PrivateKey = dtRow("f01StringMax")
                                .prop02DataEncrypted = dtRow("f02StringMax")

                                With _objUserProp
                                    ._UserProp02cUserID = dtRow("k02String")
                                    ._UserProp03cUserName = dtRow("f01String")
                                    ._UserProp04ComputerName = vsUserInfo
                                    ._UserProp05IPAddress = vsLocalIpAddress
                                    ._UserProp06Password = "MERSY"
                                    ._UserProp07TargetNetwork = viServerTarget
                                End With

                                With _objUserPropWS
                                    ._UserProp02cUserID = dtRow("k02String")
                                    ._UserProp03cUserName = dtRow("f01String")
                                    ._UserProp04ComputerName = vsUserInfo
                                    ._UserProp05IPLocalAddress = vsLocalIpAddress
                                    ._UserProp06IPPublicAddress = vsPublicIpAddress
                                    ._UserProp07Password = "MERSY"
                                    ._UserProp08TargetNetwork = viServerTarget
                                    ._UserProp09IsRootUser = True

                                End With
                            Next
                        End With
                        If "MERSY" = _oPass.pb02DescryptPassword() Then
                            Dim vdtUserAccess As New DataTable
                            vdtUserAccess = _oTablemaster._pb02GetDataUserACCESSAsync(viServerTarget, vsUserld)


                            Dim frmMenu As Form = New frmMenuAKIRRA(Me) With {._objUserProp = _objUserProp, ._objUserPropWS = _objUserPropWS, .vsServerTarget = vsServerTarget, .vsUserId = vsUserId, .vsUserName = vsUserName, .vsFileVersion = vsFileVersion}
                            frmMenu.Show()

                            Me.Hide()





                        Else
                            Cursor.Current = Cursors.Default
                            MsgBox("Access DENIED ... ", vbOKOnly + vbCritical, _objUserProp._UserProp01cTitle)
                        End If
                    Else
                        Cursor.Current = Cursors.Default
                        MsgBox("NIK is unknown ... ", vbOKOnly + vbCritical, _objUserProp._UserProp01cTitle)
                    End If
                ElseIf viRsl < 0 Then
                    Cursor.Current = Cursors.Default
                    Throw New FraudException
                End If
            Catch ex As Exception
                Cursor.Current = Cursors.Default
                If TypeOf ex Is FraudException Then
                    XtraMessageBox.Show(ex.Message, "FRAUD DETECTED ! | " & _objUserProp._UserProp01cTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End If
                Dim errMsg As String = "An error occured when connecting to the server." & vbCrLf & vbCrLf &
                           "Code : " & "0x" & Hex(ex.HResult) & vbCrLf &
                           "Desc  : " & ex.Message
                MsgBox(errMsg, vbOKOnly + vbCritical, "Error | " & _objUserProp._UserProp01cTitle)
            End Try

        End If
    End Sub
#End Region

#Region "control - event"

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        If e.Button.Properties.Tag = 100 Then       'Login
            pvm04LoginProcess()
        Else
            If e.Button.Properties.Tag = 200 Then   'Exit
                Me.Close()
                Me.Dispose()

                Application.Exit()
            End If
        End If
    End Sub

    Private Sub _03cTargetNetwork_KeyDown(sender As Object, e As KeyEventArgs) Handles _03cTargetNetwork.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
            pvm04LoginProcess()
        End If
    End Sub

#End Region

End Class