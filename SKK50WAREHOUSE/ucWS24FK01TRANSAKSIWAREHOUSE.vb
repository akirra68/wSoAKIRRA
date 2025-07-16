Imports DevExpress.DataAccess.Excel
Imports System.ComponentModel
Imports DevExpress.XtraBars.Docking2010
Imports SKK01CORE
Imports SKK02OBJECTS
Imports DevExpress.DataAccess.Native.Excel
Imports DevExpress.SpreadsheetSource
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Extensions

Public Class ucWS24FK01TRANSAKSIWAREHOUSE
    Implements IDisposable

    Property _prop01User As clsWSNasaUser

    Private pdtKAEAsal As DataTable
    Private pdtKAETujuan As DataTable

    Private pdtGridTransaksi As DataTable

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtKAEAsal = New DataTable
        pdtKAETujuan = New DataTable

        pdtGridTransaksi = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtKAEAsal.Dispose()
        pdtKAETujuan.Dispose()

        pdtGridTransaksi.Dispose()
    End Sub

    Private Sub ucWS24FK01TRANSAKSIWAREHOUSE_Load(sender As Object, e As EventArgs) Handles Me.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        _cm02InitTargetTransaksiWS()

        _cm01BersihkanEntrian()
    End Sub

#End Region

#Region "CUSTOM GENERAL METHOD"
    Private Sub _cm01BersihkanEntrian()
        _01cTargetTransaksiWS.EditValue = ""
        _02cSupplierKAEAsal.EditValue = ""
        _03KAETujuan.EditValue = ""
        _04cSKUTransaksi.EditValue = ""

        _lay02cSupplierKAEAsal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay03KAETujuan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay04cSKUTransaksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        pdtGridTransaksi.Clear()
        _gdTransaksi.__pbWSGrid02ClearGrid()

        _01cTargetTransaksiWS.Focus()
    End Sub

    Private Sub _cm02InitTargetTransaksiWS()
        Cursor = Cursors.WaitCursor

        Dim pdtTargetTransaksiWS As New DataTable
        Using objTargetTransaksiWS As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtTargetTransaksiWS = objTargetTransaksiWS.__pb02GetDataTable21TargetWarehouseByUser("5030")
        End Using

        '********* TEMPORARY *********
        '50304 -> Reparasi Customer.
        '50307 -> Batal Transaksi Warehouse.
        For Each dtRow As DataRow In pdtTargetTransaksiWS.Rows
            If dtRow("f05String") = "50304" Or dtRow("f05String") = "50307" Then
                dtRow.Delete()
            End If
        Next
        pdtTargetTransaksiWS.AcceptChanges()

        If pdtTargetTransaksiWS.Rows.Count > 0 Then
            _01cTargetTransaksiWS.Properties.DataSource = Nothing
            With _01cTargetTransaksiWS
                ._prop01WSDataSource = pdtTargetTransaksiWS
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _01cTargetTransaksiWS._pb01BindingAwalDataSource2Field("Code", "Transaksi Warehouse")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm03InitKAE(ByVal prmcTarget As String)

        Dim pdtTargetKAE As New DataTable
        Using objTargetKAE As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

            If prmcTarget = "ASAL" Then
                pdtKAEAsal.Clear()
                pdtKAEAsal = objTargetKAE.__pb11GetDataSLocKAEStatusStock()
                If pdtKAEAsal.Rows.Count > 0 Then
                    _02cSupplierKAEAsal.Properties.DataSource = Nothing
                    With _02cSupplierKAEAsal
                        ._prop01WSDataSource = pdtKAEAsal
                        ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                        ._prop05WSFieldValueMember = "f05String"
                        ._prop06WSFieldDisplayMember = "f06String"
                    End With
                    _02cSupplierKAEAsal._pb01BindingAwalDataSource2Field("Code", "KAE Asal")
                End If
            Else
                If prmcTarget = "TUJUAN" Then
                    pdtKAETujuan.Clear()
                    pdtKAETujuan = objTargetKAE.__pb02GetDataTable21TargetWarehouseByUser("5040", "50402")
                    If pdtKAETujuan.Rows.Count > 0 Then

                        'delete yg sama dgn KAE-ASAL
                        For Each dtRow As DataRow In pdtKAETujuan.Rows
                            If dtRow("f05String") = _02cSupplierKAEAsal.EditValue Then
                                dtRow.Delete()
                            End If
                        Next
                        pdtKAETujuan.AcceptChanges()

                        _03KAETujuan.Properties.DataSource = Nothing
                        With _03KAETujuan
                            ._prop01WSDataSource = pdtKAETujuan
                            ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                            ._prop05WSFieldValueMember = "f05String"
                            ._prop06WSFieldDisplayMember = "f06String"
                        End With
                        _03KAETujuan._pb01BindingAwalDataSource2Field("Code", "KAE Tujuan")
                    End If
                Else
                    If prmcTarget = "APPROVEMUTASIANTARKAE" Then
                        pdtKAETujuan.Clear()
                        pdtKAETujuan = objTargetKAE.__pb13GetDataSLocKAEApproveMutasiAntarKAE()
                        If pdtKAETujuan.Rows.Count > 0 Then
                            _03KAETujuan.Properties.DataSource = Nothing
                            With _03KAETujuan
                                ._prop01WSDataSource = pdtKAETujuan
                                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                                ._prop05WSFieldValueMember = "f05String"
                                ._prop06WSFieldDisplayMember = "f06String"
                            End With
                            _03KAETujuan._pb01BindingAwalDataSource2Field("Code", "KAE-APPROVE")
                        End If
                    End If
                End If
            End If

        End Using

    End Sub

    Private Sub _cm04InitSupplier()
        Dim pdtTargetSupplier As New DataTable
        Using objTargetSupplier As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtKAEAsal.Clear()
            pdtKAEAsal = objTargetSupplier.__pb12GetDataSupplierStatusStock()
            If pdtKAEAsal.Rows.Count > 0 Then
                _02cSupplierKAEAsal.Properties.DataSource = Nothing
                With _02cSupplierKAEAsal
                    ._prop01WSDataSource = pdtKAEAsal
                    ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                    ._prop05WSFieldValueMember = "f05String"
                    ._prop06WSFieldDisplayMember = "f06String"
                End With
                _02cSupplierKAEAsal._pb01BindingAwalDataSource2Field("Code", "Supplier")
            End If
        End Using
    End Sub

    Private Function _cm05GetNoDocument() As String
        Dim pcIDNoDoc As String = ""

        Select Case _01cTargetTransaksiWS.EditValue
            Case "50301"    'Mutasi Antar SLoc-KAE
                pcIDNoDoc = "WSMUTASIANTARKAE"
            Case "50302"    'Approve Mutasi Antar SLoc-KAE
            Case "50303"    'Reparasi Warehouse
                pcIDNoDoc = "WSREPAIRWAREHOUSE"
            Case "50304"    'Reparasi Customer
                pcIDNoDoc = ""
            Case "50305"    'Lebur
                pcIDNoDoc = "WSLEBUR"
            Case "50306"    'Retur Supplier
                pcIDNoDoc = "WSRETURSUPPLIER"
        End Select

        Dim pcNoDokumen As String = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = pcIDNoDoc}
            pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()
        End Using

        Return pcNoDokumen
    End Function

    Private Function _cm05PrepareDataForSave() As DataTable
        Dim pdtTiny As New DataTable
        Dim objTiny As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtTiny}
        objTiny.dtInitsTABLETINY()

        Dim pcNoDoc As String = ""
        Dim pnAwal As Int16 = 0

        Dim pcKodeKepada As String = "" : Dim pcNamaKepada As String = ""
        Select Case _01cTargetTransaksiWS.EditValue
            Case "50301"    'Mutasi Antar SLoc-KAE
                pcKodeKepada = _03KAETujuan.EditValue
                pcNamaKepada = _03KAETujuan.Text
            Case "50302"    'Approve Mutasi Antar SLoc-KAE
                pcKodeKepada = _03KAETujuan.EditValue
                pcNamaKepada = _03KAETujuan.Text
            Case "50303"    'Reparasi Warehouse
            Case "50304"    'Reparasi Customer
            Case "50305"    'Lebur
            Case "50306"    'Retur Supplier
                pcKodeKepada = _02cSupplierKAEAsal.EditValue
                pcNamaKepada = _02cSupplierKAEAsal.Text
        End Select

        Dim pcAlasan As String = "" : Dim vsMasterSKU As String = ""
        For Each dtRow As DataRow In pdtGridTransaksi.Rows
            If CBool(dtRow("k00Boolean")) Then
                If pnAwal = 0 Then
                    pcNoDoc = _cm05GetNoDocument()
                    pnAwal = pnAwal + 1
                End If

                pcAlasan = ""
                If _01cTargetTransaksiWS.EditValue = "50303" Or
                    _01cTargetTransaksiWS.EditValue = "50305" Or
                    _01cTargetTransaksiWS.EditValue = "50306" Then
                    pcAlasan = dtRow("f40String")
                    vsMasterSKU = dtRow("f51String").ToString()
                End If

                objTiny.dtAddNewsTABLETINY("", dtRow("k03String"), "",
                                           pcKodeKepada, pcNamaKepada, pcNoDoc, pcAlasan, vsMasterSKU,
                                           0, 0, 0, 0.0, 0.0, 0.0,
                                           "3000-01-01", "3000-01-01", "3000-01-01",
                                           _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                                           _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress,
                                           _prop01User._UserProp06IPPublicAddress)
            End If
        Next

        Return objTiny.prop_dtsTABLETINY
    End Function

    Private Sub _cm06SaveAllProses()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin untuk menyimpan data ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            Select Case _01cTargetTransaksiWS.EditValue
                Case "50301"    'Mutasi Antar SLoc-KAE
                    _cm50301_02SaveDataMutasiAntarKAE()

                Case "50302"    'Approve Mutasi Antar SLoc-KAE
                    _cm50302_02SaveDataApproveMutasiAntarKAE()

                Case "50303"    'Reparasi Warehouse
                    _cm50303_05_02SaveDataReparasiLeburReturSupplier("REPAIR")

                Case "50304"    'Reparasi Customer
                Case "50305"    'Lebur
                    _cm50303_05_02SaveDataReparasiLeburReturSupplier("LEBUR")

                Case "50306"    'Retur Supplier
                    _cm50303_05_02SaveDataReparasiLeburReturSupplier("RETURSUPPLIER")

            End Select

        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

#Region "50301 - Mutasi Antar SLoc-KAE"
    Private Sub _cm50301_01DisplayDataStockKAE()
        pdtGridTransaksi.Clear()

        Cursor = Cursors.WaitCursor
        'getdata DATA STOCK SLoc-KAE unt Mutasi Antar SLoc-KAE (spWS43Sele4PivotGridProses -> 3,0,16)
        Using objClass = New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
            pdtGridTransaksi = objClass._pb11GetDataStockKAE(_02cSupplierKAEAsal.EditValue)
        End Using
        Cursor = Cursors.Default

        If pdtGridTransaksi.Rows.Count > 0 Then
            _gdTransaksi.__pbWSGrid02ClearGrid()
            With _gdTransaksi
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSTransaksi01MutasiAntarKAE
                ._prop03pdtDataSourceGrid = pdtGridTransaksi
            End With
            _gdTransaksi.__pbWSGrid01InitGrid()
            _gdTransaksi.__pbWSGrid03DisplayGrid()
        Else
            MsgBox("Maaf ... DATA STOCK KAE tidak ditemukan ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm50301_02SaveDataMutasiAntarKAE()
        Dim pdtDataMutasiKAE As New DataTable
        pdtDataMutasiKAE = _cm05PrepareDataForSave()

        If pdtDataMutasiKAE.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            Dim objNasa As New clsWSNasaHelper
            Dim pnJmlRec As Integer = 0
            pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                2, "spWSTransaksi01MutasiAntarKAE", "@tpDataForSaving", pdtDataMutasiKAE)

            Cursor = Cursors.Default

            MsgBox("Proses Simpan Data ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf ... TIDAK ADA data MUTASI ANTAR KAE yg akan disimpan.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

#Region "50302 - Approve Mutasi Antar SLoc-KAE"
    Private Sub _cm50302_01DisplayDataApproveMutasiAntarKAE()
        pdtGridTransaksi.Clear()

        Cursor = Cursors.WaitCursor
        'getdata SLoc-KAE unt APPROVE Mutasi Antar SLoc-KAE (spWS43Sele4PivotGridProses -> 3,0,17)
        Using objClass = New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
            pdtGridTransaksi = objClass._pb14GetDataAPPROVEMUTASIANTARKAE(_03KAETujuan.EditValue)
        End Using
        Cursor = Cursors.Default

        If pdtGridTransaksi.Rows.Count > 0 Then
            _gdTransaksi.__pbWSGrid02ClearGrid()
            With _gdTransaksi
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSTransaksi01MutasiAntarKAE
                ._prop03pdtDataSourceGrid = pdtGridTransaksi
            End With
            _gdTransaksi.__pbWSGrid01InitGrid()
            _gdTransaksi.__pbWSGrid03DisplayGrid()
        Else
            MsgBox("Maaf ... DATA APPROVE MUTASI ANTAR KAE tidak ditemukan ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm50302_02SaveDataApproveMutasiAntarKAE()
        Dim pdtApproveMutasiKAE As New DataTable
        pdtApproveMutasiKAE = _cm05PrepareDataForSave()

        If pdtApproveMutasiKAE.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            Dim objNasa As New clsWSNasaHelper
            Dim pnJmlRec As Integer = 0
            pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                2, "spWSTransaksi04ApproveMutasiAntarKAE", "@tpDataForSaving", pdtApproveMutasiKAE)

            Cursor = Cursors.Default

            MsgBox("Proses Simpan Data ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf ... TIDAK ADA data APPROVE MUTASI ANTAR KAE yg akan disimpan.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub
#End Region

#Region "50303 - Reparasi Warehouse : 50305 - Lebur"
    Private Sub _cm50303_05_01DisplayDataReparasiLebur()
        pdtGridTransaksi.Clear()

        Cursor = Cursors.WaitCursor
        'getdata DATA STOCK untuk Reparasi dan Lebur (spWS43Sele4PivotGridProses -> 3,0,18)
        Using objClass = New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
            pdtGridTransaksi = objClass._pb12GetDataStockForRepairLebur()
        End Using
        Cursor = Cursors.Default

        If pdtGridTransaksi.Rows.Count > 0 Then
            _gdTransaksi.__pbWSGrid02ClearGrid()
            With _gdTransaksi
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSTransaksi03ReparasiLebur
                ._prop03pdtDataSourceGrid = pdtGridTransaksi
            End With
            _gdTransaksi.__pbWSGrid01InitGrid()
            _gdTransaksi.__pbWSGrid03DisplayGrid()
        Else
            MsgBox("Maaf ... DATA STOCK Warehouse tidak ditemukan ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm50303_05_02SaveDataReparasiLeburReturSupplier(ByVal prmcRepairLeburReturSupplier As String)
        Dim pdtDataReparasiWS As New DataTable
        pdtDataReparasiWS = _cm05PrepareDataForSave()

        Dim pcJudul As String = ""
        If pdtDataReparasiWS.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            Dim pcNamaSP As String = ""

            If prmcRepairLeburReturSupplier = "REPAIR" Then
                pcNamaSP = "spWSTransaksi02ReparasiWS"
                pcJudul = "REPARASI WAREHOUSE"
            Else
                If prmcRepairLeburReturSupplier = "LEBUR" Then
                    pcNamaSP = "spWSTransaksi03Lebur"
                    pcJudul = "LEBUR"
                Else
                    If prmcRepairLeburReturSupplier = "RETURSUPPLIER" Then
                        pcNamaSP = "spWSTransaksi04ReturSupplier"
                        pcJudul = "RETUR SUPPLIER"
                    End If
                End If
            End If

            Dim objNasa As New clsWSNasaHelper
            Dim pnJmlRec As Integer = 0
            pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                2, pcNamaSP, "@tpDataForSaving", pdtDataReparasiWS)

            Cursor = Cursors.Default

            MsgBox("Proses Simpan Data ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf ... TIDAK ADA data " & pcJudul & " yg akan disimpan.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm50303_05_03TransaksiRepairWarehouse()
        Dim plYes As MsgBoxResult = MsgBox("Apakah ini proses REPAIR WAREHOUSE melalui 'BULK UPLOAD - XLSX' ... ?", vbYesNoCancel + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim objBulkUploadXLS As New ucWS24LD01BULKUPLOADXLS With {._prop01User = _prop01User,
                                                                      ._prop02TargetBULKUPLOADXLS = ucWS24LD01BULKUPLOADXLS._pbEnumTargetBULKUPLOADXLS._TRANSAKSIRepairWarehouse}

            Dim objSize As New Size With {.Width = objBulkUploadXLS.Size.Width,
                                          .Height = objBulkUploadXLS.Size.Height + 50}

            Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                               .MinimizeBox = False, .ShowIcon = False,
                                               .StartPosition = FormStartPosition.CenterScreen,
                                               .Text = "Bulk Upload Repair | " & _prop01User._UserProp01cTitle,
                                               .Dock = DockStyle.Fill}
            frmModal.AddControl(objBulkUploadXLS)

            Cursor = Cursors.Default

            frmModal.ShowDialog()
        ElseIf plYes = MsgBoxResult.No Then
            _cm50303_05_01DisplayDataReparasiLebur()
        Else
            _cm01BersihkanEntrian()
        End If
    End Sub

    Private Sub _cm50303_05_04TransaksiLebur()
        Dim plYes As MsgBoxResult = MsgBox("Apakah ini proses LEBUR melalui 'BULK UPLOAD - XLSX' ... ?", vbYesNoCancel + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim objBulkUploadXLS As New ucWS24LD01BULKUPLOADXLS With {._prop01User = _prop01User,
                                                                      ._prop02TargetBULKUPLOADXLS = ucWS24LD01BULKUPLOADXLS._pbEnumTargetBULKUPLOADXLS._TRANSAKSILeburWarehouse}

            Dim objSize As New Size With {.Width = objBulkUploadXLS.Size.Width,
                                          .Height = objBulkUploadXLS.Size.Height + 50}

            Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                               .MinimizeBox = False, .ShowIcon = False,
                                               .StartPosition = FormStartPosition.CenterScreen,
                                               .Text = "Bulk Upload Lebur | " & _prop01User._UserProp01cTitle,
                                               .Dock = DockStyle.Fill}
            frmModal.AddControl(objBulkUploadXLS)

            Cursor = Cursors.Default

            frmModal.ShowDialog()
        ElseIf plYes = MsgBoxResult.No Then
            _cm50303_05_01DisplayDataReparasiLebur()
        Else
            _cm01BersihkanEntrian()
        End If
    End Sub

#End Region

#Region "50304 - Reparasi Customer"

#End Region

#Region "50306 - Retur Supplier"

    Private Sub _cm50306_01DisplayDataReturSupplier()
        pdtGridTransaksi.Clear()

        Cursor = Cursors.WaitCursor
        'getdata DATA STOCK untuk Retur Supplier (spWS43Sele4PivotGridProses -> 3,0,19)
        Using objClass = New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
            pdtGridTransaksi = objClass._pb13GetDataStockSupplier(_02cSupplierKAEAsal.EditValue)
        End Using
        Cursor = Cursors.Default

        If pdtGridTransaksi.Rows.Count > 0 Then
            _gdTransaksi.__pbWSGrid02ClearGrid()
            With _gdTransaksi
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSTransaksi05ReturSupplier
                ._prop03pdtDataSourceGrid = pdtGridTransaksi
            End With
            _gdTransaksi.__pbWSGrid01InitGrid()
            _gdTransaksi.__pbWSGrid03DisplayGrid()
        Else
            MsgBox("Maaf ... DATA STOCK Warehouse tidak ditemukan ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

#Region "control - event"

    Private Sub _01cTargetTransaksiWS_EditValueChanged(sender As Object, e As EventArgs) Handles _01cTargetTransaksiWS.EditValueChanged
        If Not String.IsNullOrEmpty(_01cTargetTransaksiWS.EditValue) Then
            _02cSupplierKAEAsal.EditValue = ""
            _03KAETujuan.EditValue = ""
            _04cSKUTransaksi.EditValue = ""

            _lay02cSupplierKAEAsal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            _lay03KAETujuan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            _lay04cSKUTransaksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            ' ===================== UPDATED BY AKIRRA - 16/04/25 =====================
            ' agar ketika merubah target, maka grid akan terefresh ulang (sekaligus dengan header dan row numbernya).
            _gdTransaksi.__pbWSGrid01InitGrid()
            _gdTransaksi.__pbWSGrid02ClearGrid()
            ' ======================================================================

            Select Case _01cTargetTransaksiWS.EditValue
                Case "50301"    'Mutasi Antar SLoc-KAE
                    _lay02cSupplierKAEAsal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay02cSupplierKAEAsal.Text = "Location Asal"
                    _cm03InitKAE("ASAL")

                Case "50302"    'Approve Mutasi Antar SLoc-KAE
                    _lay03KAETujuan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay03KAETujuan.Text = "KAE Approve"
                    _cm03InitKAE("APPROVEMUTASIANTARKAE")

                Case "50303"    'Reparasi Warehouse
                    _cm50303_05_03TransaksiRepairWarehouse()
                    '_cm50303_05_01DisplayDataReparasiLebur()

                Case "50304"    'Reparasi Customer
                Case "50305"    'Lebur
                    _cm50303_05_04TransaksiLebur()
                    '_cm50303_05_01DisplayDataReparasiLebur()


                Case "50306"    'Retur Supplier
                    _lay02cSupplierKAEAsal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay02cSupplierKAEAsal.Text = "Kepada"
                    _cm04InitSupplier()
            End Select

        End If
    End Sub

    Private Sub _02cSupplierKAEAsal_EditValueChanged(sender As Object, e As EventArgs) Handles _02cSupplierKAEAsal.EditValueChanged
        If Not String.IsNullOrEmpty(_02cSupplierKAEAsal.EditValue) Then
            Select Case _01cTargetTransaksiWS.EditValue
                Case "50301"    'Mutasi Antar SLoc-KAE
                    _lay03KAETujuan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay03KAETujuan.Text = "Kepada"
                    _cm03InitKAE("TUJUAN")

                Case "50306"    'Retur Supplier
                    _cm50306_01DisplayDataReturSupplier()
            End Select
        End If
    End Sub

    Private Sub _03KAETujuan_EditValueChanged(sender As Object, e As EventArgs) Handles _03KAETujuan.EditValueChanged
        If Not String.IsNullOrEmpty(_03KAETujuan.EditValue) Then

            Select Case _01cTargetTransaksiWS.EditValue
                Case "50301"    'Mutasi Antar SLoc-KAE
                    _cm50301_01DisplayDataStockKAE()

                Case "50302"    'Approve Mutasi Antar SLoc-KAE
                    _cm50302_01DisplayDataApproveMutasiAntarKAE()
            End Select
        End If
    End Sub

    Private Sub _04cSKUTransaksi_EditValueChanged(sender As Object, e As EventArgs) Handles _04cSKUTransaksi.EditValueChanged
        If Not String.IsNullOrEmpty(_04cSKUTransaksi.EditValue) Then

        End If
    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Save
                _cm06SaveAllProses()

            Case 200  'Clear
                _cm01BersihkanEntrian()

        End Select
    End Sub

#End Region

End Class

