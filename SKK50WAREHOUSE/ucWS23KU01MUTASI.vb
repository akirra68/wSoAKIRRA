Imports DevExpress.DataAccess.UI.Native
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSpreadsheet.Model
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucWS23KU01MUTASI
    Implements IDisposable

    Public Property _prop01User As clsWSNasaUser

    Private pdtDataGridAllMutasi As DataTable
    Private objGetDataGridMutasi As clsWSNasaSelect4PivotGridProses

    Private pcKodeSLocHanya1 As String = ""

    Private objContainer As PopupContainerControl
    Private objUserControl As XtraUserControl

    Private pdtWSSKURepairLebur As DataTable
    Private objWSSKURepairLebur As clsWSNasaTemplateKey

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtDataGridAllMutasi = New DataTable
        objGetDataGridMutasi = New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}

        objContainer = New PopupContainerControl
        objUserControl = New XtraUserControl With {.Dock = DockStyle.Fill}

        pdtWSSKURepairLebur = New DataTable
        objWSSKURepairLebur = New clsWSNasaTemplateKey With {.prop_dtKEY = pdtWSSKURepairLebur}
        objWSSKURepairLebur.dtInitKEY()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtDataGridAllMutasi.Dispose()
        objGetDataGridMutasi.Dispose()

        objContainer.Dispose()
        objUserControl.Dispose()

        pdtWSSKURepairLebur.Dispose()
        objWSSKURepairLebur.Dispose()
    End Sub

    Private Sub ucWS23KU01MUTASI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        objContainer.Controls.Add(objUserControl)

        With _gdMutasi
            ._prop01User = _prop01User
        End With
        _gdMutasi.__pbWSGrid01InitGrid()

        _cm01BersihkanEntrian()
        _cm02InitCtrlTargetMutasi()
        _cm03InitCtrlAsalSLoc()

        _cm04SettingContent()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01BersihkanEntrian()
        'Visibility
        _lay04dTanggalTransaksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay05cApprovedVia.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _layPopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _01cTargetTransaksi.EditValue = ""
        _02cKeterangan.EditValue = ""

        _04dTanggalTransaksi.EditValue = Today.Date
        _05cApprovedVia.SelectedIndex = 0  '0:Manual ; 1:Otomatis

        PopupContainerEdit1.EditValue = ""

        _gdMutasi.__pbWSGrid02ClearGrid()

        If pcKodeSLocHanya1 = "" Then
            _03cKodeSLocAsal.EditValue = ""
            _03cKodeSLocAsal.Properties.ReadOnly = False
            _03cKodeSLocAsal.Focus()
        Else
            _01cTargetTransaksi.Focus()
        End If

        pdtDataGridAllMutasi.Clear()

        '-------- Obj - Mutasi Antar SLoc ---------------
        _10cKodeTujuanSLoc.EditValue = ""

        '-------- Obj - Repair & Lebur    ---------------
        objWSSKURepairLebur.prop_dtKEY.Clear()

    End Sub

    Private Sub _cm02InitCtrlTargetMutasi()
        Cursor = Cursors.WaitCursor

        '"f03String = 5030; 	dan f04String = Warehouse Target Mutasi"  ==> TABLEMASTER..TABLE21

        Dim objTargetMutasi As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        Dim pdtTargetMutasi As New DataTable
        pdtTargetMutasi = objTargetMutasi.__pb02GetDataTable21TargetWarehouseByUser("5030")

        If pdtTargetMutasi.Rows.Count > 0 Then
            With _01cTargetTransaksi
                ._prop01WSDataSource = pdtTargetMutasi
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _01cTargetTransaksi._pb01BindingAwalDataSource2Field("Code", "Target")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm03InitCtrlAsalSLoc()
        Cursor = Cursors.WaitCursor
        '"f03String = 5040; 	dan f04String = Warehouse Storage Location"  ==> TABLEMASTER..TABLE21

        Dim objSLoc As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        Dim pdtSLoc As New DataTable
        If _prop01User._UserProp09IsRootUser Then
            pdtSLoc = objSLoc.__pb02GetDataTable21TargetWarehouseByUser("5040")
            'pdtSLoc = objSLoc.__pb03GetDataTable21TargetWarehouseByGroup("5040")
        Else
            pdtSLoc = objSLoc.__pb02GetDataTable21TargetWarehouseByUser("5040")
        End If

        If pdtSLoc.Rows.Count > 0 Then
            With _03cKodeSLocAsal
                ._prop01WSDataSource = pdtSLoc
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _03cKodeSLocAsal._pb01BindingAwalDataSource2Field("Code", "Target")

            If pdtSLoc.Rows.Count = 1 Then
                For Each dtRow As DataRow In pdtSLoc.Rows
                    pcKodeSLocHanya1 = dtRow("f05String").ToString
                Next

                _03cKodeSLocAsal.EditValue = pcKodeSLocHanya1
                _03cKodeSLocAsal.Properties.ReadOnly = True
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm04SettingContent()

        Select Case _01cTargetTransaksi.EditValue
            Case "50301"    'Mutasi Antar SLoc
                PopupContainerEdit1.Properties.PopupControl = obj01ContainerMutasiAntarSLoc
                _cm101InitControlMutasiAntarSLoc()

            Case "50302"    'Approve Mutasi'
                _cm102InitControlApproveMutasi()
                _cm102DisplayGridApproveMutasi()

            Case "50303", "50304"    '"50303-Reparasi"; "50304-Lebur"
                _cm103InitControlRepairLebur()
                _cm103FillContentRepairLebur()

        End Select

    End Sub

    Private Sub _cm05SaveAllTransaksiMutasi()
        If Not String.IsNullOrEmpty(_01cTargetTransaksi.EditValue) Then
            Select Case _01cTargetTransaksi.EditValue
                Case "50301"    'Mutasi Antar SLoc
                    _cm101SaveDataMutasiAntarSLoc()

                Case "50302"    'Approve Mutasi 
                    _cm102SaveDataApproveMutasi()

                Case "50303", "50304"    '"50303-Reparasi"; "50304-Lebur"
                    _cm103SaveDataRepairLebur()

            End Select
        End If
    End Sub

#End Region

    Public Delegate Sub _dlg01DisplayGridRepairLebur(ByVal prmDataParent As DataTable)

#Region "delegate - invoke"
    Public Sub __dlg01DisplayGridPosterSKURepairLeburInvoke(ByVal prmRecordData As DataTable)
        Dim pcSLocCurrent As String = ""
        Dim pcWSSKU As String = ""
        Dim pcKodeAlasan As String = ""
        Dim pcNamaAlasan As String = ""
        Dim pcKeterangan As String = ""

        For Each dtRow As DataRow In prmRecordData.Rows
            pcSLocCurrent = _03cKodeSLocAsal.EditValue
            pcWSSKU = dtRow("k02String")
            pcKodeAlasan = dtRow("k03String")
            pcNamaAlasan = dtRow("k04String")
            pcKeterangan = dtRow("k05String")
        Next

        'jangan di CLEAR sb ini adalah kumpulan.
        'Unt CLEAR ada di method BERSIH-ENTRIAN.
        objWSSKURepairLebur.dtAddNewKEY(pcSLocCurrent, pcWSSKU, pcKodeAlasan, pcNamaAlasan, pcKeterangan)

        Dim objData As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User}

        pdtDataGridAllMutasi.Clear()
        pdtDataGridAllMutasi = objData._pb03GetDataDisplayGridRepairLeburRetur(objWSSKURepairLebur.prop_dtKEY)

        _gdMutasi.__pbWSGrid02ClearGrid()
        With _gdMutasi
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSRepairLebur
            ._prop03pdtDataSourceGrid = pdtDataGridAllMutasi
        End With
        _gdMutasi.__pbWSGrid03DisplayGrid()
    End Sub
#End Region

#Region "control - event"

    Private Sub _01cTargetTransaksi_EditValueChanged(sender As Object, e As EventArgs) Handles _01cTargetTransaksi.EditValueChanged
        If Not String.IsNullOrEmpty(_01cTargetTransaksi.EditValue) Then
            _cm04SettingContent()
        End If
    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Save
                _cm05SaveAllTransaksiMutasi()

            Case 200  'Clear
                _cm01BersihkanEntrian()
        End Select
    End Sub

#End Region

#Region "101. Mutasi Antar SLoc - method"

    Private Sub _cm101InitControlMutasiAntarSLoc()
        'Visibility
        _lay04dTanggalTransaksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay05cApprovedVia.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _layPopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        Dim objSLoc As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        Dim pdtSLoc As New DataTable
        pdtSLoc = objSLoc.__pb02GetDataTable21TargetWarehouseByUser("5040")
        'pdtSLoc = objSLoc.__pb03GetDataTable21TargetWarehouseByGroup("5040")

        'sb jika ADMIN makan akan TERHAPUS SEMUA
        If Not _prop01User._UserProp09IsRootUser Then
            For Each dtRow As DataRow In pdtSLoc.Rows
                If _03cKodeSLocAsal.EditValue = dtRow("f05String").ToString Then
                    dtRow.Delete()
                End If
            Next
            pdtSLoc.AcceptChanges()
        End If

        If pdtSLoc.Rows.Count > 0 Then
            _10cKodeTujuanSLoc.Properties.DataSource = Nothing

            With _10cKodeTujuanSLoc
                ._prop01WSDataSource = pdtSLoc
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _10cKodeTujuanSLoc._pb01BindingAwalDataSource2Field("Code", "Target")
        End If

    End Sub

    Private Sub _cm101DisplayGridMutasiAntarSLoc()
        pdtDataGridAllMutasi.Clear()

        Dim objParam As New clsWSNasaSelectParamDataCollection
        objParam._pb01AddNew(3, 0, 2, _03cKodeSLocAsal.EditValue, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim objNasa As New clsWSNasaHelper
        pdtDataGridAllMutasi = objNasa._pbWSNasaHelperExec04SPSELECTToDataTable(_prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS, objParam)

        _gdMutasi.__pbWSGrid02ClearGrid()
        With _gdMutasi
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSMutasiAntarSLoc
            ._prop03pdtDataSourceGrid = pdtDataGridAllMutasi
        End With
        _gdMutasi.__pbWSGrid03DisplayGrid()
    End Sub

    Private Sub _cm101ProsesSaveDataMutasiAntarSLoc()
        Cursor = Cursors.WaitCursor

        Dim pdtData As New DataTable
        Dim objTempSmall As New clsWSNasaTemplateDataSmall With {.prop_dtsTABLESMALL = pdtData}
        objTempSmall.dtInitsTABLESMALL()

        Dim pcApprovedVia As String = ""
        Select Case _05cApprovedVia.SelectedIndex
            Case 0   'Manual
                pcApprovedVia = "MANUAL"
            Case 1   'Otomatis
                pcApprovedVia = "OTOMATIS"
        End Select

        Dim pcNoDokumen As String = ""
        Dim objNoDoc As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                  ._prop02String = "WSNOMUTASIANTARSLOC"}
        pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()

        Dim pcWSSKU As String = ""
        Dim plCheck As Boolean = False

        'k02String  = "SKU"           
        For Each dtRow As DataRow In pdtDataGridAllMutasi.Rows

            'plCheck = False
            'plCheck = CBool(dtRow("k00Boolean"))
            'MsgBox(plCheck)

            If CBool(dtRow("k00Boolean")) Then
                'pcWSSKU = ""
                'pcWSSKU = dtRow("k02String").ToString
                'MsgBox(pcWSSKU)

                objTempSmall.dtAddNewsTABLESMALL(
                     dtRow("k02String").ToString, pcApprovedVia, _10cKodeTujuanSLoc.EditValue,
                     _10cKodeTujuanSLoc.Text, pcNoDokumen, "ucWS23KU01MUTASI", "MUTASI ANTAR SLOC", "", "", "", "", "", _02cKeterangan.EditValue,
                     0, 0, 0, 0.0, 0.0, 0.0,
                     _04dTanggalTransaksi.EditValue, "3000-01-01", "3000-01-01",
                     "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                     _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            End If
        Next

        Cursor = Cursors.Default

        If objTempSmall.prop_dtsTABLESMALL.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            Dim objNasa As New clsWSNasaHelper
            Dim pnJmlRec As Integer = 0
            pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                    2, "spWSTABLE22MutasiAntarSLoc",
                                    "@tpTemplateSmall", objTempSmall.prop_dtsTABLESMALL)

            Cursor = Cursors.Default

            MsgBox("Proses Simpan Data ... SUKSES...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf... Data yg akan disimpan tidak ada ... " & Chr(13) &
                   "Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm101SaveDataMutasiAntarSLoc()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar unt proses Simpan Data ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm101ProsesSaveDataMutasiAntarSLoc()
        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _10cKodeTujuanSLoc_EditValueChanged(sender As Object, e As EventArgs) Handles _10cKodeTujuanSLoc.EditValueChanged
        If Not String.IsNullOrEmpty(_10cKodeTujuanSLoc.EditValue) Then
            _cm101DisplayGridMutasiAntarSLoc()

            PopupContainerEdit1.EditValue = _10cKodeTujuanSLoc.Text
        End If

    End Sub

#End Region

#Region "102. Approve Mutasi"
    Private Sub _cm102InitControlApproveMutasi()
        'Visibility
        _lay04dTanggalTransaksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay05cApprovedVia.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _layPopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub _cm102DisplayGridApproveMutasi()
        pdtDataGridAllMutasi.Clear()

        Dim objParam As New clsWSNasaSelectParamDataCollection
        objParam._pb01AddNew(3, 0, 3, _03cKodeSLocAsal.EditValue, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim objNasa As New clsWSNasaHelper
        pdtDataGridAllMutasi = objNasa._pbWSNasaHelperExec04SPSELECTToDataTable(_prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS, objParam)

        _gdMutasi.__pbWSGrid02ClearGrid()
        With _gdMutasi
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSApproveMutasi
            ._prop03pdtDataSourceGrid = pdtDataGridAllMutasi
        End With
        _gdMutasi.__pbWSGrid03DisplayGrid()
    End Sub

    Private Sub _cm102ProsesSaveDataApproveMutasi()
        Cursor = Cursors.WaitCursor

        Dim pdtData As New DataTable
        Dim objTempSmall As New clsWSNasaTemplateDataSmall With {.prop_dtsTABLESMALL = pdtData}
        objTempSmall.dtInitsTABLESMALL()

        Dim pcNoDokumen As String = ""
        Dim objNoDoc As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                  ._prop02String = "WSAPPROVEMUTASI"}
        pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()

        Dim pcWSSKU As String = ""
        Dim plCheck As Boolean = False

        'k02String  = "SKU"           
        For Each dtRow As DataRow In pdtDataGridAllMutasi.Rows
            If CBool(dtRow("k00Boolean")) Then
                objTempSmall.dtAddNewsTABLESMALL(
                     dtRow("k02String").ToString, pcNoDokumen, "",
                     "ucWS23KU01MUTASI", "APPROVE MUTASI", "", "", "", "", "", "", "", _02cKeterangan.EditValue,
                     0, 0, 0, 0.0, 0.0, 0.0,
                     "3000-01-01", "3000-01-01", "3000-01-01",
                     "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                     _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            End If
        Next

        Cursor = Cursors.Default

        If objTempSmall.prop_dtsTABLESMALL.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            Dim objNasa As New clsWSNasaHelper
            Dim pnJmlRec As Integer = 0
            pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                    2, "spWSTABLE21ApproveMutasi",
                                    "@tpTemplateSmall", objTempSmall.prop_dtsTABLESMALL)

            Cursor = Cursors.Default

            MsgBox("Proses Simpan Data ... SUKSES...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf... Data yg akan disimpan tidak ada ... " & Chr(13) &
                   "Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm102SaveDataApproveMutasi()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar unt proses Simpan Data ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm102ProsesSaveDataApproveMutasi()
        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub
#End Region

#Region "103. Reparasi dan Lebur"

    Private Sub _cm103InitControlRepairLebur()
        'Visibility
        _lay04dTanggalTransaksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay05cApprovedVia.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _layPopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    End Sub

    Private Sub _cm103FillContentRepairLebur()
        Cursor = Cursors.WaitCursor

        PopupContainerEdit1.Controls.Clear()
        objUserControl.Controls.Clear()

        Select Case _01cTargetTransaksi.EditValue
            Case "50303"    'Reparasi
                _cm103CreateContentRepairLebur("REPAIR")

            Case "50304"    'Lebur'
                _cm103CreateContentRepairLebur("LEBUR")

        End Select

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm103CreateContentRepairLebur(ByVal prmcTarget As String)
        Dim objUCReparasiLebur As New ucWS23LE01REPARASILEBUR With {._prop01cTarget = prmcTarget,
                                                                    ._prop02User = _prop01User,
                                                                    ._prop03cKodeSLocCurrent = _03cKodeSLocAsal.EditValue,
                                                                    ._prop04objParent = Me}

        Dim objSize As New Size With {.Width = objUCReparasiLebur.Size.Width,
                                      .Height = objUCReparasiLebur.Size.Height}
        objContainer.Size = objSize
        objUserControl.Size = objSize

        objUserControl.Controls.Add(objUCReparasiLebur)

        PopupContainerEdit1.Properties.PopupControl = objContainer
    End Sub

    Private Sub _cm103ProsesSimpanDataRepairLebur()
        Cursor = Cursors.WaitCursor

        Dim pcTargetNoDoc As String = ""
        Dim pcTarget As String = ""
        Dim pcKodeSLocTargetMutasi As String = ""
        Dim pcNamaSLocTargetMutasi As String = ""
        Dim pcNamaTransaksi As String = ""

        Select Case _01cTargetTransaksi.EditValue
            Case "50303"    'Reparasi
                pcTarget = "REPAIR-WAREHOUSE"
                pcTargetNoDoc = "WSREPAIR"
                pcKodeSLocTargetMutasi = "50480"
                pcNamaSLocTargetMutasi = "SLoc-Repair Warehouse"
                pcNamaTransaksi = "MUTASI - REPAIR WAREHOUSE"

            Case "50304"    'Lebur'
                pcTarget = "LEBUR"
                pcTargetNoDoc = "WSLEBUR"
                pcKodeSLocTargetMutasi = "50481"
                pcNamaSLocTargetMutasi = "SLoc-Lebur"
                pcNamaTransaksi = "MUTASI - LEBUR"

        End Select

        Dim pcNoDokumen As String = ""
        Dim objNoDoc As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                  ._prop02String = pcTargetNoDoc}
        pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()

        Dim pdtRepairLebur As New DataTable
        Dim objRepairLebur As New clsWSNasaTemplateDataMedium With {.prop_dtsTABLEMEDIUM = pdtRepairLebur}
        objRepairLebur.dtInitsTABLEMEDIUM()

        Dim pdtData As New DataTable
        Dim objTempSmall As New clsWSNasaTemplateDataSmall With {.prop_dtsTABLESMALL = pdtData}
        objTempSmall.dtInitsTABLESMALL()

        'pdtDataGridAllMutasi ==> dari wsTABLE20 : (dari spWS23KU01DisplayGridRepairLebur)
        For Each dtRow As DataRow In pdtDataGridAllMutasi.Rows
            objRepairLebur.dtAddNewsTABLEMEDIUM(
                                   "", dtRow("k01String"), dtRow("k02String"),
                                   pcTarget, pcNoDokumen, _03cKodeSLocAsal.EditValue,
                                   _03cKodeSLocAsal.Text, dtRow("f35String"), dtRow("f36String"),
                                   "", "", "", "", "", "",
                                   "", "", "", "", "", "",
                                   "", dtRow("f37String"),
                                   dtRow("f01TinyInt"), dtRow("f01SmallInt"), 0,
                                   dtRow("f01Double"), 0.0, 0.0,
                                   Today.Date, "3000-01-01", "3000-01-01",
                                   Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                                   _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            objTempSmall.dtAddNewsTABLESMALL(
                     dtRow("k02String"), "OTOMATIS", pcKodeSLocTargetMutasi,
                     pcNamaSLocTargetMutasi, pcNoDokumen, "ucWS23KU01MUTASI", pcNamaTransaksi,
                     "", "", "", "", "", dtRow("f37String"),
                     0, 0, 0, 0.0, 0.0, 0.0,
                     _04dTanggalTransaksi.EditValue, "3000-01-01", "3000-01-01",
                     "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                     _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

        Next
        Cursor = Cursors.Default

        If objRepairLebur.prop_dtsTABLEMEDIUM.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            Dim objNasa As New clsWSNasaHelper

            'Urutan proses simpan data JANGAN DIUBAH :
            '1. MUTASI SLOC dahulu.
            '2. Baru proses SAVE REPAIRLEBUR -> (sb pd proses simpan ada update NO.INDEXMUTASI dan PCS)
            Dim pnJmlRec As Integer = 0
            pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                    2, "spWSTABLE22MutasiAntarSLoc",
                                    "@tpTemplateSmall", objTempSmall.prop_dtsTABLESMALL)

            Cursor = Cursors.Default
            If pnJmlRec > 0 Then
                'Mutasi ke SLoc "REPAIR-WAREHOUSE"
                pnJmlRec = 0
                pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                    2, "spWSTABLE24Save",
                                    "@tpDataForSaving", objRepairLebur.prop_dtsTABLEMEDIUM)

                If pnJmlRec > 0 Then
                    MsgBox("Proses Simpan Data ... SUKSES...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

                    _cm01BersihkanEntrian()
                Else
                    MsgBox("Proses Simpan Data ... GAGAL... Silahkan recovery ...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
                End If
            Else
                MsgBox("Proses Simpan Data ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Maaf... Data yg akan disimpan tidak ada ... " & Chr(13) &
                   "Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm103SaveDataRepairLebur()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar unt proses Simpan Data ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm103ProsesSimpanDataRepairLebur()
        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

End Class
