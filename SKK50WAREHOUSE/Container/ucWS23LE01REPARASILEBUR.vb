Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraSpreadsheet.Model
Imports SKK02OBJECTS
Imports SKK50WAREHOUSE.ucWS23KU01MUTASI

Public Class ucWS23LE01REPARASILEBUR
    Implements IDisposable

    Public Property _prop01cTarget As String  '"REPAIR", "LEBUR"
    Public Property _prop02User As clsWSNasaUser
    Public Property _prop03cKodeSLocCurrent As String
    Public Property _prop04objParent As ucWS23KU01MUTASI

    Private pdtData As DataTable
    Private objKeyData As clsWSNasaTemplateKey

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtData = New DataTable
        objKeyData = New clsWSNasaTemplateKey With {.prop_dtKEY = pdtData}
        objKeyData.dtInitKEY()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtData.Dispose()
        objKeyData.Dispose()
    End Sub

    Private Sub ucWS23LE01REPARASILEBUR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop02User._UserProp10Skin)

        Select Case _prop01cTarget
            Case "REPAIR"
                _lay01cPathXLSBulkUploadRepairLebur.Text = "Bulk Upload Data REPARASI - .XLS"
                _lay03cKodeAlasanRepairLebur.Text = "Alasan REPARASI"

            Case "LEBUR"
                _lay01cPathXLSBulkUploadRepairLebur.Text = "Bulk Upload Data LEBUR - .XLS"
                _lay03cKodeAlasanRepairLebur.Text = "Alasan LEBUR"

        End Select

        _cm01InitCtrlAlasanRepairLebur()
        _cm02BersihkanEntrian()
    End Sub
#End Region

#Region "custom - method"
    Private Sub _cm01InitCtrlAlasanRepairLebur()
        Cursor = Cursors.WaitCursor

        Dim pdtMasterAlasan As New DataTable
        Dim objMasterAlasan As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop02User}

        Dim pcTarget As String = ""
        Select Case _prop01cTarget
            Case "REPAIR"
                pcTarget = "ALREP"

            Case "LEBUR"
                pcTarget = "ALLEB"

        End Select
        pdtMasterAlasan = objMasterAlasan.__pb01GetDataMasterWarehouseBerdasarkanGroup(pcTarget)

        With _03cKodeAlasanRepairLebur
            ._prop01WSDataSource = pdtMasterAlasan
            ._prop02WSDaftarField = New String() {"k13String", "k14String"}
            ._prop05WSFieldValueMember = "k13String"
            ._prop06WSFieldDisplayMember = "k14String"
            ._prop07WSKeyKolomFilterUntSelect = "k13String"
        End With
        _03cKodeAlasanRepairLebur._pb01BindingAwalDataSource2Field()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm02BersihkanEntrian()
        _01cPathXLSBulkUploadRepairLebur.EditValue = ""
        _02cWSSKURepairLebur.EditValue = ""
        _03cKodeAlasanRepairLebur.EditValue = ""
        _04cKeteranganRepairLebur.EditValue = ""
        _05objPicture.Image = Nothing

        _02cWSSKURepairLebur.Focus()
    End Sub

    Private Sub _cm03ShowImageBRJ()
        Dim pdtGambar As New DataTable
        Using objGetMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop02User,
                                                                      ._prop02String = _02cWSSKURepairLebur.EditValue,
                                                                      ._prop03String = _prop03cKodeSLocCurrent}
            pdtGambar = objGetMaster._pb02GetDataGambarFromPosterSKU()
            If pdtGambar.Rows.Count > 0 Then
                For Each dtRow As DataRow In pdtGambar.Rows
                    _05objPicture.EditValue = dtRow("f01objGambar")
                Next
            End If
        End Using
    End Sub

    Private Sub _cm04SubmitDataRepairLebur()
        Cursor = Cursors.WaitCursor

        Dim pcTarget As String = ""
        Select Case _prop01cTarget
            Case "REPAIR"
                pcTarget = "REPAIR"

            Case "LEBUR"
                pcTarget = "LEBUR"
        End Select

        objKeyData.prop_dtKEY.Clear()

        objKeyData.dtAddNewKEY(pcTarget, _02cWSSKURepairLebur.EditValue, _03cKodeAlasanRepairLebur.EditValue, _03cKodeAlasanRepairLebur.Text, _04cKeteranganRepairLebur.EditValue)

        Dim objDlg As _dlg01DisplayGridRepairLebur = AddressOf _prop04objParent.__dlg01DisplayGridPosterSKURepairLeburInvoke
        objDlg.Invoke(objKeyData.prop_dtKEY)

        _cm02BersihkanEntrian()

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "control - event"
    Private Sub _01cPathXLSBulkUploadRepairLebur_EditValueChanged(sender As Object, e As EventArgs) Handles _01cPathXLSBulkUploadRepairLebur.EditValueChanged

    End Sub

    Private Sub _02cWSSKURepairLebur_LostFocus(sender As Object, e As EventArgs) Handles _02cWSSKURepairLebur.LostFocus
        If Not String.IsNullOrEmpty(_02cWSSKURepairLebur.EditValue) Then
            _cm03ShowImageBRJ()
        End If
    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Save
                _cm04SubmitDataRepairLebur()

            Case 200  'Clear
                _cm02BersihkanEntrian()
        End Select
    End Sub

#End Region


End Class
