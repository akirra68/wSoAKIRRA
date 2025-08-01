Imports DevExpress.Skins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking2010
Imports SKK01CORE
Imports SKK02OBJECTS
Imports SKK02OBJECTS.ucWSGridParentChild

Public Class ucWS24H201PROSESPKB
    Implements IDisposable

    Property _prop01User As clsWSNasaUser
    Property _prop02dtPARENT As DataTable
    Property _prop03dtCHILD As DataTable
    Property _prop04dtPROSES As DataTable
    Property _prop05dtPICKER As DataTable
    Property _prop06dtEKSPEDISI As DataTable

    Property _prop07gdParentChild As ucWSGridParentChild

    Property _prop08TargetProsesPKB As TargetProsesPKB

    Public Enum TargetProsesPKB
        _01AirwayBill = 0
        _02CreateSuratJalan = 1
    End Enum

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ucWS24H201PROSESPKB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        If _prop08TargetProsesPKB = TargetProsesPKB._01AirwayBill Then
            mnubar03KAE.Visibility = BarItemVisibility.Never
            mnubar04TOP.Visibility = BarItemVisibility.Never

            _cm01SettingControlReadOnly_AirwayBill()
            _cm02InitControl_AirwayBill()
            _cm03DisplayProsesPKB_AirwayBill()

            '_layAirwaBill01ShipmentOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            _layAirwaBill02Process.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If

        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 10

        If _prop08TargetProsesPKB = TargetProsesPKB._02CreateSuratJalan Then
            mnubar03KAE.Visibility = BarItemVisibility.Always
            mnubar04TOP.Visibility = BarItemVisibility.Always

            _cm5052DisplayProsesPKB_SuratJalan()
            _cm5052InitMasterKAE()
            _cm5052InitMasterTOP()

            '_layAirwaBill01ShipmentOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            _layAirwaBill02Process.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

#End Region

#Region "custom - method (AirwayBill)"
    Private Sub _cm01SettingControlReadOnly_AirwayBill()
        '_02f02StringCustomer._pb01SettingDisplay(True)
        '_03k02StringNoPKB._pb01SettingDisplay(True)
        '_04f04StringKAE._pb01SettingDisplay(True)
        '_05f06StringTOP._pb01SettingDisplay(True)
        '_06f08StringBrand._pb01SettingDisplay(True)
        '_07f10StringKadar._pb01SettingDisplay(True)
        '_08f11StringTipeOrder._pb01SettingDisplay(True)
        '_09f01SmallIntTQty._pb01SettingDisplay(0, True)
        '_10f01DoubleTBerat._pb01SettingDisplay(2, True)

        _11f13StringCurrentProses.Properties.ReadOnly = True

        _12f29StringNextProses.Properties.ReadOnly = True


    End Sub

    Private Sub _cm02InitControl_AirwayBill()
        With _11f13StringCurrentProses
            ._prop01WSDataSource = _prop04dtPROSES
            ._prop02WSDaftarField = New String() {"f05String", "f06String"}
            ._prop05WSFieldValueMember = "f05String"
            ._prop06WSFieldDisplayMember = "f06String"
        End With
        _11f13StringCurrentProses._pb01BindingAwalDataSource2Field("Code", "Current Proses")

        'With _13f15StringPICKER
        '    ._prop01WSDataSource = _prop05dtPICKER
        '    ._prop02WSDaftarField = New String() {"f05String", "f06String"}
        '    ._prop05WSFieldValueMember = "f05String"
        '    ._prop06WSFieldDisplayMember = "f06String"
        'End With
        '_13f15StringPICKER._pb01BindingAwalDataSource2Field("Code", "Picker")

        With _14f17StringEKSPEDISI
            ._prop01WSDataSource = _prop06dtEKSPEDISI
            ._prop02WSDaftarField = New String() {"k13String", "k14String"}
            ._prop05WSFieldValueMember = "k13String"
            ._prop06WSFieldDisplayMember = "k14String"
        End With
        _14f17StringEKSPEDISI._pb01BindingAwalDataSource2Field("Code", "Ekspedisi")
    End Sub

    Private Sub _cm03DisplayProsesPKB_AirwayBill()
        'Parent
        For Each dtRow As DataRow In _prop02dtPARENT.Rows
            '_01f02DateTglPKB.EditValue = dtRow("f01Date")              'dtRow("f02Date")
            '_02f02StringCustomer.EditValue = dtRow("f02String")
            '_03k02StringNoPKB.EditValue = dtRow("k02String")
            '_04f04StringKAE.EditValue = dtRow("f04String")
            '_05f06StringTOP.EditValue = dtRow("f06String")
            '_06f08StringBrand.EditValue = dtRow("f08String")
            '_07f10StringKadar.EditValue = dtRow("f10String")
            '_08f11StringTipeOrder.EditValue = dtRow("f15String")
            '_09f01SmallIntTQty.EditValue = dtRow("f01SmallInt")
            '_10f01DoubleTBerat.EditValue = dtRow("f01Double")

            _11f13StringCurrentProses.EditValue = dtRow("f12String")
            _12f29StringNextProses.EditValue = "505012"                 'dtRow("f28String")
            _14f17StringEKSPEDISI.EditValue = dtRow("f16String")
            _15f18StringResi.EditValue = dtRow("f18String")

            If Not String.IsNullOrEmpty(dtRow("f16String").ToString) Then
                _14f17StringEKSPEDISI.ReadOnly = True
            End If

            If Not String.IsNullOrEmpty(dtRow("f18String").ToString) Then
                _15f18StringResi._pb01SettingDisplay(True)
            End If

        Next

        'Child
        With _gdProsesPKB
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSOut10ProsesPKB
            ._prop03pdtDataSourceGrid = _prop03dtCHILD
        End With
        _gdProsesPKB.__pbWSGrid01InitGrid()
        _gdProsesPKB.__pbWSGrid03DisplayGrid()

        Dim pdtPROSESNext As New DataTable
        pdtPROSESNext = _prop04dtPROSES.Select("f03String = '" & _11f13StringCurrentProses.EditValue & "'").CopyToDataTable

        With _12f29StringNextProses
            ._prop01WSDataSource = pdtPROSESNext
            ._prop02WSDaftarField = New String() {"f05String", "f06String"}
            ._prop05WSFieldValueMember = "f05String"
            ._prop06WSFieldDisplayMember = "f06String"
        End With
        _12f29StringNextProses._pb01BindingAwalDataSource2Field("Code", "Next Proses")

        _12f29StringNextProses.Focus()
    End Sub

    '************** NOT USED **************
    '**************************************
    'Private Sub _cm04PrepareSaveData()
    '    Dim pcNoDokumen As String = ""
    '    Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = "WSAIRBILL"}
    '        pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()
    '    End Using

    '    Dim pcNoProsesMasterPKB As String = ""
    '    Dim pcNamaProsesMasterPKB As String = ""

    '    For Each dtRow As DataRow In _prop02dtPARENT.Rows
    '        dtRow("f27String") = pcNoDokumen
    '        dtRow("f28String") = _12f29StringNextProses.EditValue    '"KodeTransaksiNext"
    '        dtRow("f29String") = _12f29StringNextProses.Text         '"Next Proses"
    '        dtRow("f16String") = _14f17StringEKSPEDISI.EditValue     '"KodeEKSPEDISI"
    '        dtRow("f17String") = _14f17StringEKSPEDISI.Text          '"EKSPEDISI"
    '        dtRow("f18String") = _15f18StringResi.EditValue          '"Resi"
    '        pcNoProsesMasterPKB = dtRow("f24String")
    '        pcNamaProsesMasterPKB = dtRow("f25String")
    '    Next
    '    _prop02dtPARENT.AcceptChanges()

    '    For Each dtRow As DataRow In _prop03dtCHILD.Rows
    '        dtRow("f11String") = pcNoDokumen
    '        dtRow("f28String") = _12f29StringNextProses.EditValue    '"KodeTransaksiNext"
    '        dtRow("f29String") = _12f29StringNextProses.Text         '"Next Proses"
    '        dtRow("f16String") = _14f17StringEKSPEDISI.EditValue     '"KodeEKSPEDISI"
    '        dtRow("f17String") = _14f17StringEKSPEDISI.Text          '"EKSPEDISI"
    '        dtRow("f18String") = _15f18StringResi.EditValue          '"Resi"
    '        dtRow("f19String") = pcNoProsesMasterPKB
    '        dtRow("f20String") = pcNamaProsesMasterPKB
    '    Next
    '    _prop03dtCHILD.AcceptChanges()
    'End Sub

    'Private Function _cm05PrepareSaveDataParent() As DataTable


    '    Dim pdtParent As New DataTable
    '    Dim objParent As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtParent}
    '    objParent.dtInitsTABLEMEDIUMPLUSPLUS()

    '    For Each dtRow As DataRow In _prop02dtPARENT.Rows
    '        objParent.dtAddNewsTABLEMEDIUMPLUS(dtRow("k01String"), dtRow("k02String"), dtRow("k03String"),
    '                dtRow("f01String"), dtRow("f02String"), dtRow("f03String"), dtRow("f04String"), dtRow("f05String"),
    '                dtRow("f06String"), dtRow("f07String"), dtRow("f08String"), dtRow("f09String"), dtRow("f10String"),
    '                dtRow("f11String"), dtRow("f12String"), dtRow("f13String"), dtRow("f14String"), dtRow("f15String"),
    '                dtRow("f16String"), dtRow("f17String"), dtRow("f18String"), dtRow("f19String"), dtRow("f20String"),
    '                dtRow("f21String"), dtRow("f22String"), dtRow("f23String"), dtRow("f24String"), dtRow("f25String"),
    '                dtRow("f26String"), dtRow("f27String"), dtRow("f28String"), dtRow("f29String"), dtRow("f30String"),
    '                dtRow("f01TinyInt"), dtRow("f01SmallInt"), dtRow("f01Int"), 0, 0,
    '                dtRow("f01Double"), dtRow("f02Double"), dtRow("f03Double"), 0.0, 0.0,
    '                dtRow("f01Date"), dtRow("f02Date"), dtRow("f03Date"), "3000-01-01", "3000-01-01",
    '                "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
    '    Next

    '    Return objParent.prop_dtsTABLEMEDIUMPLUS
    'End Function

    'Private Function _cm05PrepareSaveDataChild() As DataTable
    '    Dim pdtChild As New DataTable
    '    Dim objChild As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtChild}
    '    objChild.dtInitsTABLEMEDIUMPLUSPLUS()

    '    For Each dtRow As DataRow In _prop03dtCHILD.Rows
    '        objChild.dtAddNewsTABLEMEDIUMPLUS(dtRow("k01String"), dtRow("k02String"), dtRow("k03String"),
    '                dtRow("f01String"), dtRow("f02String"), dtRow("f03String"), dtRow("f04String"), dtRow("f05String"),
    '                dtRow("f06String"), dtRow("f07String"), dtRow("f08String"), dtRow("f09String"), dtRow("f10String"),
    '                dtRow("f11String"), dtRow("f12String"), dtRow("f13String"), dtRow("f14String"), dtRow("f15String"),
    '                dtRow("f16String"), dtRow("f17String"), dtRow("f18String"), dtRow("f19String"), dtRow("f20String"),
    '                dtRow("f21String"), dtRow("f22String"), dtRow("f23String"), dtRow("f24String"), dtRow("f25String"),
    '                dtRow("f26String"), dtRow("f27String"), dtRow("f28String"), dtRow("f29String"), dtRow("f30String"),
    '                dtRow("f01TinyInt"), dtRow("f01SmallInt"), dtRow("f01Int"), 0, 0,
    '                dtRow("f01Double"), dtRow("f02Double"), dtRow("f03Double"), 0.0, 0.0,
    '                dtRow("f01Date"), dtRow("f02Date"), dtRow("f03Date"), "3000-01-01", "3000-01-01",
    '                "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
    '    Next

    '    Return objChild.prop_dtsTABLEMEDIUMPLUS
    'End Function

    Private Function _cm04PrepareSaveAirwayBillParent(ByVal prmcNoDokumen As String) As DataTable
        Dim pdtParent As New DataTable
        Dim objParent As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtParent}
        objParent.dtInitsTABLETINY()

        For Each dtRow As DataRow In _prop02dtPARENT.Rows
            objParent.dtAddNewsTABLETINY(prmcNoDokumen, dtRow("k02String"), "",
                      _14f17StringEKSPEDISI.EditValue, _14f17StringEKSPEDISI.Text, _15f18StringResi.EditValue, "", "",
                      0, 0, 0, 0.0, 0.0, 0.0,
                      "3000-01-01", "3000-01-01",
                      "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                      _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
        Next

        Return objParent.prop_dtsTABLETINY
    End Function

    Private Function _cm04PrepareSaveAirwayBillChild(ByVal prmcNoDokumen As String) As DataTable
        Dim pdtChild As New DataTable
        Dim objChild As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtChild}
        objChild.dtInitsTABLETINY()

        For Each dtRow As DataRow In _prop03dtCHILD.Rows
            objChild.dtAddNewsTABLETINY(prmcNoDokumen, dtRow("f04String"), "",
                      _14f17StringEKSPEDISI.Text, _15f18StringResi.EditValue, dtRow("f24String"), dtRow("f25String"), "",
                      0, 0, 0, 0.0, 0.0, 0.0,
                      "3000-01-01", "3000-01-01",
                      "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                      _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

        Next

        Return objChild.prop_dtsTABLETINY
    End Function

    Private Function _cm04PrepareSaveAirwayBillResi(ByVal prmcNoDokumen As String) As DataTable
        Dim pdtResi As New DataTable
        Dim objResi As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtResi}
        objResi.dtInitsTABLETINY()

        objResi.dtAddNewsTABLETINY("", prmcNoDokumen, _15f18StringResi.EditValue,
                      _16cNamaKurir.EditValue, _14f17StringEKSPEDISI.EditValue, _14f17StringEKSPEDISI.Text, "", "",
                      0, 0, _18nTotBiayaKirim.EditValue,
                      _17nTotBeratPaketKG.EditValue, 0.0, 0.0,
                      Today.Date, "3000-01-01",
                      Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                      _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

        Return objResi.prop_dtsTABLETINY
    End Function

    Private Sub _cm06ProsesSaveDataAirwayBill()
        Cursor = Cursors.WaitCursor

        Dim pcNoDokumen As String = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = "WSAIRBILL"}
            pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()
        End Using

        Dim pdtParent As New DataTable
        pdtParent = _cm04PrepareSaveAirwayBillParent(pcNoDokumen)

        Dim pdtChild As New DataTable
        pdtChild = _cm04PrepareSaveAirwayBillChild(pcNoDokumen)

        Dim pdtResi As New DataTable
        pdtResi = _cm04PrepareSaveAirwayBillResi(pcNoDokumen)

        Dim pnJmlRec As Integer
        Using objOutbound As clsWSNasaHelper = New clsWSNasaHelper
            pnJmlRec = objOutbound._pbWSNasaHelperExec01SPSQLProses(_prop01User._UserProp08TargetNetwork,
                                   clsWSNasaHelper._pnmDatabaseName.WS, 2, "spWSOutboundPKB505012AirwayBillSave",
                                   "@DataParent", pdtParent, "@DataChild", pdtChild, "@DataResi", pdtResi)
        End Using

        Cursor = Cursors.Default

        If pnJmlRec > 0 Then
            MsgBox("Proses Simpan Data ... SUKSES.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

            _prop07gdParentChild._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._Target505015PKBProsesSuratJalan
            _prop07gdParentChild.__pbWSGridParentChild01InitGrid()
            _prop07gdParentChild.__pbWSGridParentChild02Clear()
            _prop07gdParentChild.__pbWSGridParentChild03Display()

            'Dim objData As _dlgUpdateAirwayBill = AddressOf _prop07gdParentChild.__ivkUpdateAirwayBill
            'objData.Invoke(_03k02StringNoPKB.EditValue, _14f17StringEKSPEDISI.EditValue, _14f17StringEKSPEDISI.Text, _15f18StringResi.EditValue)

            Me.ParentForm.Close()
        End If
    End Sub

    Private Sub _cm07SaveProsesPKB()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin untuk menyimpan data ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            If _prop08TargetProsesPKB = TargetProsesPKB._01AirwayBill Then
                If _14f17StringEKSPEDISI.EditValue <> "" And _15f18StringResi.EditValue <> "" Then
                    _cm06ProsesSaveDataAirwayBill()
                Else
                    Dim pcPesan As String = ""
                    If _14f17StringEKSPEDISI.EditValue = "" Then
                        pcPesan = "Maaf... data EKSPEDISI masih ... KOSONG..."
                    Else
                        If _15f18StringResi.EditValue = "" Then
                            pcPesan = "Maaf... data RESI masih ... KOSONG..."
                        End If
                    End If

                    MsgBox(pcPesan, vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
                End If
            Else
                If _prop08TargetProsesPKB = TargetProsesPKB._02CreateSuratJalan Then
                    If _cm5052ValidasiDataBeforeSave() Then
                        _cm5052SaveData_SuratJalan()
                    End If
                End If
            End If
        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm08CancelProses()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin untuk membatalkan proses ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            Me.ParentForm.Close()
        End If
    End Sub

#End Region

#Region "custom - method (SuratJalan)"
    Private Sub _cm5052InitMasterKAE()
        Cursor = Cursors.WaitCursor
        Dim pdtKAE As New DataTable

        Using objMaster As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtKAE = objMaster.__pb02GetDataTable21TargetWarehouseByUser("5040", 50402)
        End Using

        _col01KAECode.FieldName = "f05String"
        _col02KAENama.FieldName = "f06String"

        With rsmnubar03KAE
            .DataSource = pdtKAE
            .ValueMember = "f05String"
            .DisplayMember = "f06String"
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm5052InitMasterTOP()
        Cursor = Cursors.WaitCursor

        Dim pdtMasterTOP As New DataTable
        Using objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtMasterTOP = objTargetTransaksi.__pb01GetDataMasterWarehouseBerdasarkanGroup("TOP")
        End Using

        If pdtMasterTOP.Rows.Count > 0 Then
            _col01TOPCode.FieldName = "k13String"
            _col02TOPNama.FieldName = "k14String"

            With rsmnubar04TOP
                .DataSource = pdtMasterTOP
                .ValueMember = "k13String"
                .DisplayMember = "k14String"
            End With
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm5052DisplayProsesPKB_SuratJalan()
        With _gdProsesPKB
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._wsOut5052PKBCreateSuratJalan
            ._prop03pdtDataSourceGrid = _prop02dtPARENT
        End With
        _gdProsesPKB.__pbWSGrid01InitGrid()
        _gdProsesPKB.__pbWSGrid03DisplayGrid()

        _gdProsesPKB.__pbWSGridVisibilityCheckSelectAll(True)
    End Sub

    Private Sub _cm5052SaveData_SuratJalan()
        Dim pdtDataSJ() As DataRow
        pdtDataSJ = _gdProsesPKB._prop03pdtDataSourceGrid.Select(" k00Boolean = " & True)

        If pdtDataSJ.Count > 0 Then

            Dim pdtWSTable28 As New DataTable
            Dim objWSTable28 As New clsWSNasaTemplateDataMedium With {.prop_dtsTABLEMEDIUM = pdtWSTable28}
            objWSTable28.dtInitsTABLEMEDIUM()

            Cursor = Cursors.WaitCursor

            ' ===================== UPDATED BY AKIRRA - 15/04/2025 =====================
            ' change No.SJ to specific order

            Dim pcOrderType = ""
            For Each dtRow As DataRow In pdtDataSJ
                Dim fullOrderType As String = dtRow("k02String").ToString()
                pcOrderType = If(fullOrderType.Length >= 2, fullOrderType.Substring(0, 2), fullOrderType)
                'MsgBox(pcOrderType)
            Next

            Dim pcKodeNoDocSJ = ""
            If pcOrderType = "CO" Then
                pcKodeNoDocSJ = "WSSJCUSTOMER"
            ElseIf pcOrderType = "PO" Then
                pcKodeNoDocSJ = "WSSJCUSTOMERPO"
            ElseIf pcOrderType = "SS" Then
                pcKodeNoDocSJ = "WSSJKAE"
            ElseIf pcOrderType = "CS" Then
                pcKodeNoDocSJ = "WSSJCONSIGNMENT"
            ElseIf pcOrderType = "MO" Then
                pcKodeNoDocSJ = "WSSJMARKETING"
            ElseIf pcOrderType = "GO" Then
                pcKodeNoDocSJ = "WSSJMARKETINGGO"
            ElseIf pcOrderType = "XB" Then
                pcKodeNoDocSJ = "WSSJPAMERAN"
                'ElseIf pcOrderType = "IN" Then
                '    pcKodeNoDocSJ = "WSSJ ?"    ' sj internal gak ada ya? yaudah
            Else
                pcKodeNoDocSJ = "WSSURATJALAN"
            End If

            ' ======================================================================

            Dim pcNoDocSJ As String = ""
            Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = pcKodeNoDocSJ}
                pcNoDocSJ = objNoDoc._pb51GetDataIncNoDocWarehouse()
            End Using

            For Each dtRow As Object In pdtDataSJ
                objWSTable28.dtAddNewsTABLEMEDIUM("", pcNoDocSJ, dtRow("k02String"),
                               dtRow("f01String"), dtRow("f02String"), dtRow("f03String"), dtRow("f04String"), dtRow("f05String"),
                               dtRow("f06String"), dtRow("f07String"), dtRow("f08String"), dtRow("f09String"), dtRow("f10String"),
                               "NEW", "", "", "", dtRow("f11String"), "", "", "", "", "",
                               0, dtRow("f01SmallInt"), 0, dtRow("f01Double"), 0.0, 0.0,
                               Today.Date, "3000-01-01", "3000-01-01",
                               "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                               _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            Next

            Dim pnJmlRec As Integer
            Using objOutbound As clsWSNasaHelper = New clsWSNasaHelper
                pnJmlRec = objOutbound._pbWSNasaHelperExec01SPSQLProses(_prop01User._UserProp08TargetNetwork,
                                                                      clsWSNasaHelper._pnmDatabaseName.WS, 2, "spWSOutboundPKB5052CreateSuratJalan2833",
                                                                      "@tpDataForSaving", objWSTable28.prop_dtsTABLEMEDIUM)
            End Using

            Cursor = Cursors.Default

            If pnJmlRec > 0 Then
                MsgBox("Proses Simpan Data ... SUKSES.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

                _prop07gdParentChild.__pbWSGridParentChild01InitGrid()
                _prop07gdParentChild.__pbWSGridParentChild02Clear()
                _prop07gdParentChild.__pbWSGridParentChild03Display("100")

                Me.ParentForm.Close()
            End If
        Else
            MsgBox("Maaf ... Silahkan pilih PKB untuk SURATJALAN terlebih dahulu ...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If


    End Sub

    Private Function _cm5052ValidasiDataBeforeSave() As Boolean
        Dim plDataOK As Boolean = True
        Dim plAwal As Boolean = True
        Dim pcKodeKAE As String = ""
        Dim pcKodeTOP As String = ""

        For Each dtRow As DataRow In _gdProsesPKB._prop03pdtDataSourceGrid.Rows
            If CBool(dtRow("k00Boolean")) Then
                If plAwal Then
                    pcKodeKAE = dtRow("f03String")
                    pcKodeTOP = dtRow("f05String")
                Else
                    If plDataOK Then
                        If pcKodeKAE = dtRow("f03String") And pcKodeTOP = dtRow("f05String") Then
                            plDataOK = True
                        Else
                            plDataOK = False
                        End If
                    End If
                End If
            End If
        Next

        If Not plDataOK Then
            MsgBox("Maaf ... data SURAT JALAN, masing2 data TOP dan KAE ... HARUS SAMA ....", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

        Return plDataOK
    End Function

    Private Sub _cm5052UpdateKAEdanTOP(ByVal prmcTargetKAEorTOP As String)

        For Each dtRow As DataRow In _gdProsesPKB._prop03pdtDataSourceGrid.Rows
            If CBool(dtRow("k00Boolean")) Then
                Select Case prmcTargetKAEorTOP
                    Case "KAE"
                        dtRow("f03String") = mnubar03KAE.EditValue
                        dtRow("f04String") = rsmnubar03KAE.GetDisplayText(mnubar03KAE.EditValue)

                    Case "TOP"
                        dtRow("f05String") = mnubar04TOP.EditValue
                        dtRow("f06String") = rsmnubar04TOP.GetDisplayText(mnubar04TOP.EditValue)

                End Select
            End If
        Next

        _gdProsesPKB._prop03pdtDataSourceGrid.AcceptChanges()
        _gdProsesPKB.Refresh()
    End Sub

#End Region

#Region "control - event"

    Private Sub mnubar01Save_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnubar01Save.ItemClick
        Me.ActiveControl = Nothing

        _cm07SaveProsesPKB()
    End Sub

    Private Sub mnubar02Cancel_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubar02Cancel.ItemClick
        Me.ActiveControl = Nothing

        _cm08CancelProses()
    End Sub

    Private Sub mnubar03KAE_EditValueChanged(sender As Object, e As EventArgs) Handles mnubar03KAE.EditValueChanged
        Me.ActiveControl = Nothing

        If mnubar03KAE.EditValue <> "" Then
            _cm5052UpdateKAEdanTOP("KAE")
        End If
    End Sub

    Private Sub mnubar04TOP_EditValueChanged(sender As Object, e As EventArgs) Handles mnubar04TOP.EditValueChanged
        Me.ActiveControl = Nothing

        If mnubar04TOP.EditValue <> "" Then
            _cm5052UpdateKAEdanTOP("TOP")
        End If
    End Sub

#End Region

End Class
