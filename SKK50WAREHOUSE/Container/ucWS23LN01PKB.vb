Imports DevExpress.XtraEditors
Imports SKK01CORE
Imports SKK02OBJECTS
Imports SKK02OBJECTS.ucWSGrid
Imports SKK02OBJECTS.ucWSGridParentChild

Public Class ucWS23LN01PKB
    Implements IDisposable

    Public Property _prop01User As clsWSNasaUser
    Public Property _prop02WSGrid As ucWSGrid
    Public Property _prop03DataSmall As DataTable
    Public Property _prop04RuleStock As String
    Public Property _prop05DataPKBSKU As clsWSNasaTemplateDataLarge
    Public Property _prop06DataPKBProductCode As clsWSNasaTemplateDataMediumPlus
    Public Property _prop07DataPKBMerchaindise As clsWSNasaTemplateDataTiny

    Private pcPerhatian As String = "PERHATIAN :" & Space(12) & "'RESERVED' akan mengakibatkan SKU di LOCK pada database, sehingga SKU tersebut tidak bisa dilakukan mutasi lagi. Apabila anda ragu, JANGAN LAKUKAN 'RESERVED'."

    Private dtParent As DataTable
    Private dtChild As DataTable    ' ini unt Display Grid ParentChild (delegate)
    Private dtChildSave As DataTable

    Private pdtProductCode As DataTable
    Private pcNoDocument As String = ""

    Private pcTargetTransaksi As String = ""

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dtParent = New DataTable
        dtChild = New DataTable
        dtChildSave = New DataTable

        pdtProductCode = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        dtParent.Dispose()
        dtChild.Dispose()
        dtChildSave.Dispose()

        pdtProductCode.Dispose()

        Me.Dispose()
    End Sub

    Private Sub ucWS23LN01PKBCUSTOMER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)
        Cursor = Cursors.WaitCursor

        _cm01InitControlProductCode()
        _cm04CreateTableParentChild()

        pcTargetTransaksi = ""
        For Each dtRow As DataRow In _prop03DataSmall.Rows
            pcTargetTransaksi = dtRow("k01String")
        Next

        _cm09VisibilityControl()
        pcNoDocument = ""

        'ini memang sengaja di HIDE, sb unt yg SKU bikin rancu
        _01cPKBBasedOn.SelectedIndex = 0

        _lay01cPKBBasedOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _10nQtyPKBOSTProductCode._pb01SettingDisplay(0, True)
        _11nQtySaldoProductCode._pb01SettingDisplay(0, True)

        _gdSKU.__pbWSGridVisibilityCheckSelectAll(False)

        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 10

        Cursor = Cursors.Default

        _02cProductCode.Focus()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01InitControlProductCode()
        Cursor = Cursors.WaitCursor

        Using objNasa = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtProductCode = objNasa._pb02GetDataProductCodePosterStock(_prop04RuleStock)

            With _02cProductCode
                ._prop01WSDataSource = pdtProductCode
                ._prop02WSDaftarField = New String() {"f01String", "f12String", "f16String", "f10String", "f06String", "f14String", "f08String", "f09String", "f15String"}
                ._prop05WSFieldValueMember = "f01String"
                ._prop06WSFieldDisplayMember = "f01String"
                ._prop07WSKeyKolomFilterUntSelect = "f01String"
            End With
            _02cProductCode._pb03BindingAwalDataSource4Field("f01String", "ProductCode", "f10String", "Kadar",
                                                             "f16String", "Brand", "f12String", "Tipe")
        End Using

        _03nTotQtyPKB._pb01SettingDisplay(0, False)
        With _04nTotPO
            ._pb01SettingDisplay(0, True)
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm02FillImage()
        Cursor = Cursors.WaitCursor

        Dim pdtGambar As New DataTable
        Using objGetMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                       ._prop02String = _02cProductCode.EditValue}
            pdtGambar = objGetMaster._pb02GetDataGambarFromProductCode()

            If pdtGambar.Rows.Count > 0 Then
                For Each dtRow As DataRow In pdtGambar.Rows
                    _objPicture.EditValue = dtRow("f01objGambar")
                Next
            End If

        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm03FillGridSKU()
        Cursor = Cursors.WaitCursor

        Dim pdtData As New DataTable
        Using objClass = New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User,
                                                                   ._prop02String = _02cProductCode.EditValue}
            pdtData = Nothing
            pdtData = objClass._pb02GetDataSKUPKBCustomer()

            'For Each dtRow As DataRow In pdtData.Rows
            '    If dtRow("f19String") <> "STOCK" Then
            '        dtRow.Delete()
            '    End If
            'Next
            'pdtData.AcceptChanges()

            _gdSKU._prop03pdtDataSourceGrid = Nothing

            With _gdSKU
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSPKBCustomer
                ._prop03pdtDataSourceGrid = pdtData
                ._prop11objSpinEdit = _03nTotQtyPKB
                ._prop12objSpinEdit = _04nTotPO
            End With
            _gdSKU.__pbWSGrid01InitGrid()
            _gdSKU.__pbWSGrid03DisplayGrid()
            _gdSKU.__pbWSGridVisibilityCheckSelectAll(False)

        End Using

        If _01cPKBBasedOn.SelectedIndex = 0 Then
            _cm31SettingGridCheckBox(False)
        Else
            _cm31SettingGridCheckBox(True)
        End If

        Dim pdtProductCode As New DataTable
        Using objclsProductCode As clsWSNasaSelect4CtrlRepoProses = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtProductCode = objclsProductCode._pb07GetDataStockOSTProdCodePKB(_02cProductCode.EditValue)
        End Using

        For Each dtRow As DataRow In pdtProductCode.Rows
            _10nQtyPKBOSTProductCode.EditValue = dtRow("f01Int")
            _11nQtySaldoProductCode.EditValue = dtRow("f02Int")
        Next

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm04CreateTableParentChild()
        'PARENT
        dtParent = New DataTable("dtParent")
        dtParent.Columns.Add("f01String", GetType(String))
        dtParent.Columns.Add("f02String", GetType(String))
        dtParent.Columns.Add("f03String", GetType(String))
        dtParent.Columns.Add("f04String", GetType(String))
        dtParent.Columns.Add("f05String", GetType(String))
        dtParent.Columns.Add("f06String", GetType(String))
        dtParent.Columns.Add("f07String", GetType(String))

        'CHILD
        dtChild = New DataTable("dtChild")
        dtChild.Columns.Add("f01String", GetType(String))   'ProductCode
        dtChild.Columns.Add("f02String", GetType(String))   'UniqKey wsSKU
        dtChild.Columns.Add("f03String", GetType(String))   'wsSKU
        dtChild.Columns.Add("f04String", GetType(String))   'Kode SLoc
        dtChild.Columns.Add("f05String", GetType(String))   'Nama SLoc
        dtChild.Columns.Add("f06String", GetType(String))   'Kode Box
        dtChild.Columns.Add("f07String", GetType(String))   'Nama Box
        dtChild.Columns.Add("f01Int", GetType(Integer))     'Index wsSKU
        dtChild.Columns.Add("f02Int", GetType(Integer))     'Pcs
        dtChild.Columns.Add("f01Double", GetType(Double))   'Berat

        dtChild.Columns.Add("f08String", GetType(String))   'Kode NORO
        dtChild.Columns.Add("f09String", GetType(String))   'Nama NORO
        dtChild.Columns.Add("f10String", GetType(String))   'Kode Warna 
        dtChild.Columns.Add("f11String", GetType(String))   'Nama Warna
        dtChild.Columns.Add("f12String", GetType(String))   'Kode Kadar
        dtChild.Columns.Add("f13String", GetType(String))   'Nama Kadar
        dtChild.Columns.Add("f14String", GetType(String))   'Kode TipeBRJ
        dtChild.Columns.Add("f15String", GetType(String))   'Nama TipeBRJ
        dtChild.Columns.Add("f16String", GetType(String))   'Kode Size
        dtChild.Columns.Add("f17String", GetType(String))   'Nama Size
        dtChild.Columns.Add("f18String", GetType(String))   'Kode Brand
        dtChild.Columns.Add("f19String", GetType(String))   'Nama Brand

        dtChildSave = dtChild.Copy
    End Sub

    Private Sub _cm05BersihkanEntrian()
        _02cProductCode.EditValue = ""
        _03nTotQtyPKB.EditValue = 0
        _04nTotPO.EditValue = 0
        _05dTglETA.EditValue = Today.AddDays(20)
        _06cBrand.EditValue = ""
        _07cKadar.EditValue = ""
        _08cItem.EditValue = ""
        _10nQtyPKBOSTProductCode.EditValue = 0
        _11nQtySaldoProductCode.EditValue = 0

        _objPicture.EditValue = Nothing

        _gdSKU.__pbWSGrid02ClearGrid()
        _gdSKU.__pbWSGridVisibilityCheckSelectAll(False)

        _02cProductCode.Focus()
    End Sub

    Private Sub _cm06SaveToDataTable()
        '"f01String", "ProductCode", "f12String", "TipeBRJ",
        '"f16String", "Brand", "f10String", "Kadar"
        'f06String : NORO, f14String : Size, f08String : Warna

        Dim dtRows() As DataRow
        dtRows = _02cProductCode._pb05GetRecordTerpilih()

        Dim pcProductCode As String = ""
        Dim IsExistProdCode() As DataRow = Nothing
        Dim isExist As Boolean = False

        For Each dtRow As Object In dtRows
            pcProductCode = ""
            pcProductCode = dtRow("f01String").ToString

            If dtParent.Rows.Count > 0 Then
                IsExistProdCode = dtParent.Select("f01String = '" & pcProductCode & "'")

                isExist = False
                For Each dtRowProdCode As Object In IsExistProdCode
                    If pcProductCode = dtRowProdCode("f01String").ToString Then
                        isExist = True
                    End If
                Next

                If Not isExist Then
                    dtParent.Rows.Add(dtRow("f01String"), dtRow("f12String"), dtRow("f16String"),
                                      dtRow("f10String"), dtRow("f06String"), dtRow("f14String"),
                                      dtRow("f08String"))
                End If
            Else
                dtParent.Rows.Add(dtRow("f01String"), dtRow("f12String"), dtRow("f16String"),
                                  dtRow("f10String"), dtRow("f06String"), dtRow("f14String"),
                                  dtRow("f08String"))
            End If

            pcProductCode = ""
            IsExistProdCode = Nothing
        Next
        '*************************** NOT USED ****************************************
        'Dim dtParentCopy As New DataTable
        'dtParentCopy = dtParent.Copy
        'Dim dtTemp As New DataTable
        'Dim dvView As DataView = New DataView(dtParentCopy)

        'dtParent = dvView.ToTable(True, New String() {"f01String", "f02String", "f03String", "f04String", "f05String", "f06String", "f07String"})
        '*************************** END NOT USED ************************************

        For Each dtRow As DataRow In _gdSKU._prop03pdtDataSourceGrid.Rows
            ' If CBool(dtRow("k00Boolean")) Then

            dtChild.Rows.Add(_02cProductCode.EditValue, dtRow("k02String"), dtRow("k03String"),
                                 dtRow("f06String"), dtRow("f07String"), dtRow("f08String"),
                                 dtRow("f09String"), dtRow("f01TinyInt"), dtRow("f01SmallInt"), dtRow("f01Double"),
                                 dtRow("f05String"), dtRow("f26String"), dtRow("f27String"), dtRow("f28String"),
                                 dtRow("f29String"), dtRow("f10String"), dtRow("f11String"), dtRow("f12String"),
                                 dtRow("f13String"), dtRow("f14String"), dtRow("f15String"), dtRow("f16String"))

            dtChildSave.Rows.Add(_02cProductCode.EditValue, dtRow("k02String"), dtRow("k03String"),
                                 dtRow("f06String"), dtRow("f07String"), dtRow("f08String"),
                                 dtRow("f09String"), dtRow("f01TinyInt"), dtRow("f01SmallInt"), dtRow("f01Double"),
                                 dtRow("f05String"), dtRow("f26String"), dtRow("f27String"), dtRow("f28String"),
                                 dtRow("f29String"), dtRow("f10String"), dtRow("f11String"), dtRow("f12String"),
                                 dtRow("f13String"), dtRow("f14String"), dtRow("f15String"), dtRow("f16String"))
            'End If
        Next
    End Sub

    Private Function _cm07ProsesSavePKB() As Integer
        Cursor = Cursors.WaitCursor

        Dim dtChildDistinct As New DataTable

        Dim plRecChild As Boolean = False
        If _01cPKBBasedOn.SelectedIndex = 0 Then       'PRODUCT CODE
            plRecChild = True
        Else
            If _01cPKBBasedOn.SelectedIndex = 1 Then   'STOCK KEEPING UNIT
                If dtChild.Rows.Count > 0 Then
                    plRecChild = True
                End If
            End If
        End If

        If plRecChild Then
            Dim pcJenisOrder As String = ""
            For Each dtRowPKB As DataRow In _prop03DataSmall.Rows
                pcJenisOrder = dtRowPKB("f07String").ToString
            Next

            Dim vsIdAutoApproveFIN As String = ""
            Dim vsNamaAutoApproveFIN As String = ""
            Dim vdaTglAutoApproveFIN As Date = "3000-01-01"

            Dim vsIdAutoApproveSLS As String = ""
            Dim vsNamaAutoApproveSLS As String = ""
            Dim vdaTglAutoApproveSLS As Date = "3000-01-01"

            'Select Case pcTargetTransaksi
            '    Case "5061", "5063"    'CUSTOMER("5061"), CONSIGMENT("5063")
            '    ' ***** NO *****
            '    Case "5062", "5064", "5065", "5066"    'KAE("5062"),MARKETING("5064"),INTERNAL("5065"),PAMERAN("5066")
            '        pcIDUserApprover = "ADMIN"
            '        pcNamaUserApprover = "ADMIN"
            '        pdTglApprovedFA = Today.Date
            'End Select

            ' HANYA APPROVAL SALES
            Select Case pcTargetTransaksi
                Case "5062"    'KAE("5062")
                    vsIdAutoApproveFIN = "ADMIN"
                    vsNamaAutoApproveFIN = "ADMIN"
                    vdaTglAutoApproveFIN = Today.Date
            End Select

            ' HANYA APPROVAL FINANCE
            Select Case pcTargetTransaksi
                Case "5064", "5065"    'MARKETING("5064"),INTERNAL("5065")
                    vsIdAutoApproveSLS = "ADMIN"
                    vsNamaAutoApproveSLS = "ADMIN"
                    vdaTglAutoApproveSLS = Today.Date
            End Select

            If pcNoDocument = "" Then
                pcNoDocument = _cm10GetNewNomorDocument(pcJenisOrder)
            End If

            'Dim pdtData As New DataTable
            'Dim objPKBCustomer As New clsWSNasaTemplateDataLarge With {.prop_dtsTABLELARGE = pdtData}
            'objPKBCustomer.dtInitsTABLELARGE()

            Dim pnTotQtyPKB As Int32 = 0
            If _01cPKBBasedOn.SelectedIndex = 1 Then   'STOCK KEEPING UNIT
                For Each dtRow As DataRow In dtChildSave.Rows
                    For Each dtRowPKB As DataRow In _prop03DataSmall.Rows

                        _prop05DataPKBSKU.dtAddNewsTABLELARGE(
                        "", dtRow("f02String"), pcNoDocument,
                        dtRow("f03String"), dtRow("f01String"), dtRowPKB("k01String"), dtRowPKB("k02String"), dtRow("f04String"),
                        dtRow("f05String"), dtRow("f06String"), dtRow("f07String"), dtRowPKB("k03String"), dtRowPKB("f01String"),
                        dtRowPKB("f02String"), dtRowPKB("f03String"), dtRowPKB("f04String"), dtRowPKB("f05String"), dtRow("f18String"),
                        dtRow("f19String"), dtRow("f12String"), dtRow("f13String"), dtRow("f14String"), dtRow("f15String"),
                        dtRow("f08String"), dtRow("f09String"), dtRow("f16String"), dtRow("f17String"), dtRow("f10String"),
                        dtRow("f11String"), "", "", dtRowPKB("f07String"), "PKBSKU",
                        "", "", vsIdAutoApproveSLS, vsNamaAutoApproveSLS, vsIdAutoApproveFIN, vsNamaAutoApproveFIN, "", "", "", dtRowPKB("f10String"),
                        dtRow("f01Int"), dtRow("f02Int"), 0,
                        dtRow("f01Double"), 0.0, 0.0,
                        vdaTglAutoApproveSLS, vdaTglAutoApproveFIN,
                        Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                        _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

                        pnTotQtyPKB = pnTotQtyPKB + dtRow("f02Int")
                    Next
                Next

                _03nTotQtyPKB.EditValue = pnTotQtyPKB
            End If

            'Dim pdtPKBProductCode As New DataTable
            'pdtPKBProductCode = _cm12GetPRODUCTCODEtoSave(pcNoDocument, pcIDUserApprover, pcNamaUserApprover, pdTglApprovedFA)
            _cm12GetPRODUCTCODEtoSave(pcNoDocument, vsIdAutoApproveFIN, vsNamaAutoApproveFIN, vdaTglAutoApproveFIN, vsIdAutoApproveSLS, vsNamaAutoApproveSLS, vdaTglAutoApproveSLS)

            'Dim pdtPOMerchandise As New DataTable
            'pdtPOMerchandise = Nothing

            If _04nTotPO.EditValue > 0 Then
                'pdtPOMerchandise = _ps01DataPOMerchandise()
                _ps01DataPOMerchandise()
            End If

            '*********************************************************************************
            '****************************** NOT USED *****************************************
            '******   sudah dipindah mjd satu ke form ucWS23LL01DISTRIBUSIFINISHGOODS   ******
            '*********************************************************************************
            'Dim objNasaHelper As New clsWSNasaHelper
            'pnJmlRec = objNasaHelper._pbWSNasaHelperExec01SPSQLProses(
            '           _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
            '           2, mdWSNasaConst._pbWSNamaSPSAVE03TABLE30PKBProductCode,
            '           mdWSNasaConst._pbWSNamaSPParamData02DataForSaving, objPKBCustomer.prop_dtsTABLELARGE,
            '           mdWSNasaConst._pbWSNamaSPParamData04DataPOMerchandise, pdtPOMerchandise,
            '           "@tpDataForSaving30", pdtPKBProductCode)
            '**********************************************************************
            '****************************** NOT USED ******************************
            '**********************************************************************

            Dim objGridDistribusiPKB As __dlgRefreshPKB
            objGridDistribusiPKB = AddressOf _prop02WSGrid._ivkRefreshDisplayGrid
            objGridDistribusiPKB.Invoke(_prop06DataPKBProductCode.prop_dtsTABLEMEDIUMPLUS)

        Else
            MsgBox("Maaf ... Data masih kosong ...." & Chr(13) & "Proses Display Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

        Cursor = Cursors.Default

        Return 1
    End Function

    '******************************
    '********** NOT USED **********
    '******************************
    'Private _IsFirst As Boolean = True
    'Private Sub _cm08DisplayGridParent()
    '    'Dim objGridParent As __dlgBindingManual
    '    'If _IsFirst Then
    '    '    objGridParent = AddressOf _prop02gdParentChild.__ivkDisplayPKBCustomer
    '    '    objGridParent.Invoke(dtParent, dtChild)
    '    'Else
    '    '    objGridParent = AddressOf _prop02gdParentChild.__ivkDisplayPKBCustomerRefresh
    '    '    objGridParent.Invoke(dtParent, dtChild)
    '    'End If
    '    '_IsFirst = False
    'End Sub
    '******************************
    '********** NOT USED **********
    '******************************

    Private Sub _cm08SavePKB()
        '_gdSKU.__pbWSGrid04CreateSettingColumnWidth("ucWS23LN01PKB")

        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar unt proses Create Order ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor

            Dim pcProductCodeCurrent As String = ""
            pcProductCodeCurrent = _02cProductCode.EditValue

            'JANGAN DIUBAH URUTANNYA.
            _cm06SaveToDataTable()
            If _cm07ProsesSavePKB() > 0 Then

                _cm05BersihkanEntrian()

                If pdtProductCode.Rows.Count <= 1 Then
                    _02cProductCode.Properties.DataSource = Nothing
                    _02cProductCode.Refresh()
                Else
                    For Each dtRow As DataRow In pdtProductCode.Select(" f01String = '" & pcProductCodeCurrent & "' or (not ( f09String = '" & pcKodeKadar & "' and f15String = '" & pcKodeBrand & "'))")
                        If (dtRow("f01String").ToString = pcProductCodeCurrent) Or
                           (Not (dtRow("f09String").ToString = pcKodeKadar And dtRow("f15String").ToString = pcKodeBrand)) Then
                            dtRow.Delete()
                        End If
                    Next
                    pdtProductCode.AcceptChanges()

                    _02cProductCode.Properties.DataSource = Nothing
                    _02cProductCode.Properties.DataSource = pdtProductCode
                    _02cProductCode.Refresh()

                End If

                'kosongkan data agar tidak REDUDANT DI WSTABLE25
                dtChildSave.Clear()

                MsgBox("Proses Create Order ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            Else
                MsgBox("Maaf ... Proses Create Order ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If

            Cursor = Cursors.Default
        Else
            MsgBox("Maaf ... Proses Create Order ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

    Private Sub _cm09VisibilityControl()
        _03nTotQtyPKB.EditValue = 0
        _04nTotPO.EditValue = 0
        _05dTglETA.EditValue = Today.Date

        _lay03nTotQuantity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay04nTotPO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay05dTglETA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        Select Case pcTargetTransaksi
            Case "5061"    'Perintah Kirim FG : CUSTOMER
                _lay03nTotQuantity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay04nTotPO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay05dTglETA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Case "5062"    'Perintah Kirim FG : KAE
                _lay03nTotQuantity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay04nTotPO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Case "5063"    'Perintah Kirim FG : CONSIGMENT
                _lay03nTotQuantity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay04nTotPO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Case "5064"    'Perintah Kirim FG : MARKETING 
                _lay03nTotQuantity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay04nTotPO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Case "5065"    'Perintah Kirim FG : INTERNAL
                _lay03nTotQuantity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay04nTotPO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Case "5066"    'Perintah Kirim FG : PAMERAN
                _lay03nTotQuantity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay04nTotPO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        End Select
    End Sub

    Private Function _cm10GetNewNomorDocument(Optional ByVal prmcJenisOrder As String = "") As String
        Dim pcTargetNoDoc As String = ""

        Select Case pcTargetTransaksi
            Case "5061"    'Perintah Kirim FG : CUSTOMER
                If prmcJenisOrder = "CO" Then
                    pcTargetNoDoc = "WSPKBCUSTOMER"
                Else
                    pcTargetNoDoc = "WSPKBCUSTOMERPO"
                End If

            Case "5062"    'Perintah Kirim FG : KAE
                pcTargetNoDoc = "WSPKBKAE"
            Case "5063"    'Perintah Kirim FG : CONSIGMENT
                pcTargetNoDoc = "WSPKBCONSIGMENT"
            Case "5064"    'Perintah Kirim FG : MARKETING
                'pcTargetNoDoc = "WSPKBMARKETING"

                ' ===================== UPDATED BY AKIRRA - 250410 =====================
                ' memisah nodoc antara jenis order PINJAMAN (MO*) dan GIVEAWAY (GO*) pada MARKETING.

                If prmcJenisOrder = "PINJAMAN" Then
                    pcTargetNoDoc = "WSPKBMARKETING"
                Else
                    pcTargetNoDoc = "WSPKBMARKETINGGO"
                End If

                ' ======================================================================
            Case "5065"    'Perintah Kirim FG : INTERNAL
                pcTargetNoDoc = "WSPKBINTERNAL"
            Case "5066"    'Perintah Kirim FG : PAMERAN
                pcTargetNoDoc = "WSPKBPAMERAN"
        End Select

        Dim pcNoDokumen As String = ""
        Dim objNoDoc As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                  ._prop02String = pcTargetNoDoc}
        pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()

        Return pcNoDokumen
    End Function

    Private pcKodeKadar As String = ""
    Private pcKodeBrand As String = ""
    Private Sub _cm11DisplayBrandKadarItem()
        _02cProductCode._prop07WSKeyKolomFilterUntSelect = "f01String"

        Dim pdDataRow() As DataRow
        pdDataRow = _02cProductCode._pb05GetRecordTerpilih()

        For Each dtItem As Object In pdDataRow
            _06cBrand.EditValue = dtItem("f16String").ToString
            _07cKadar.EditValue = dtItem("f10String").ToString
            _08cItem.EditValue = dtItem("f12String").ToString

            pcKodeKadar = dtItem("f09String").ToString
            pcKodeBrand = dtItem("f15String").ToString
        Next
    End Sub

    Private Sub _cm12GetPRODUCTCODEtoSave(ByVal prmcNoDocPKB As String, ByVal vsIdAutoApproveFIN As String,
                                               ByVal vsNamaAutoApproveFIN As String, ByVal vdaTglAutoApproveFIN As Date, ByVal vsIdAutoApproveSLS As String,
                                               ByVal vsNamaAutoApproveSLS As String, ByVal vdaTglAutoApproveSLS As Date)

        Dim pcTargetPKB As String = ""
        Dim pcJenisPKB As String = ""
        If _01cPKBBasedOn.SelectedIndex = 0 Then       'PRODUCT CODE
            pcJenisPKB = "PKBPRODUCTCODE"
            pcTargetPKB = "PRODUCTCODE"
        Else
            If _01cPKBBasedOn.SelectedIndex = 1 Then   'STOCK KEEPING UNIT
                pcJenisPKB = "PKBSKU"
                pcTargetPKB = "SKU"
            End If
        End If

        Dim pnBeratPerPcs As Double = 0.0

        Dim objgdPKBCustomer As __dlgGetDataDouble = AddressOf _gdSKU._ivkGetDataBrtPerPcsPKBCustomer
        pnBeratPerPcs = objgdPKBCustomer.Invoke(pcTargetPKB)

        Dim pcKodeCust As String = "" : Dim pcNamaCust As String = ""
        Dim pcKodeKAE As String = "" : Dim pcNamaKAE As String = ""
        Dim pcKodeTOP As String = "" : Dim pcNamaTOP As String = ""
        Dim pcJenisOrder As String = "" : Dim pcNotes As String = ""
        For Each dtRowPKB As DataRow In _prop03DataSmall.Rows
            pcKodeCust = dtRowPKB("k03String")
            pcNamaCust = dtRowPKB("f01String")
            pcKodeKAE = dtRowPKB("f02String")
            pcNamaKAE = dtRowPKB("f03String")

            pcKodeTOP = dtRowPKB("f04String")
            pcNamaTOP = dtRowPKB("f05String")
            pcJenisOrder = dtRowPKB("f07String")
            pcNotes = dtRowPKB("f10String")
        Next

        Dim pcKodeTransaksiPKB As String = pcTargetTransaksi
        Dim pcNamaTransaksiPKB As String = ""
        Select Case pcTargetTransaksi
            Case "5061"    'Perintah Kirim FG : CUSTOMER
                Select Case pcJenisOrder
                    Case "CO" : pcNamaTransaksiPKB = "NEW ORDER | CUSTOMER-CO"
                    Case "PO" : pcNamaTransaksiPKB = "NEW ORDER | CUSTOMER-PO"
                End Select

            Case "5062"    'Perintah Kirim FG : KAE
                pcNamaTransaksiPKB = "NEW ORDER | KAE"

            Case "5063"    'Perintah Kirim FG : CONSIGMENT
                pcNamaTransaksiPKB = "NEW ORDER | CONSIGMENT"

            Case "5064"    'Perintah Kirim FG : MARKETING
                Select Case pcJenisOrder
                    Case "PINJAMAN" : pcNamaTransaksiPKB = "NEW ORDER | MKT-PINJAMAN"
                    Case "GIFTAWAY" : pcNamaTransaksiPKB = "NEW ORDER | MKT-GIVEAWAY"
                End Select

            Case "5065"    'Perintah Kirim FG : INTERNAL
                pcNamaTransaksiPKB = "NEW ORDER | INTERNAL-SALE"

            Case "5066"    'Perintah Kirim FG : PAMERAN
                pcNamaTransaksiPKB = "NEW ORDER | EXHIBITION"
        End Select

        'Dim pdtTable As New DataTable
        'Dim objSmall As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtTable}
        'objSmall.dtInitsTABLEMEDIUMPLUSPLUS()

        For Each dtRow As DataRow In _gdSKU._prop03pdtDataSourceGrid.Rows
            _prop06DataPKBProductCode.dtAddNewsTABLEMEDIUMPLUS("", _02cProductCode.EditValue, prmcNoDocPKB,
                    dtRow("f15String"), dtRow("f16String"), dtRow("f29String"), dtRow("f10String"), dtRow("f11String"),
                    dtRow("f12String"), vsIdAutoApproveSLS, vsNamaAutoApproveSLS, vsIdAutoApproveFIN, vsNamaAutoApproveFIN,
                    "", "", pcJenisPKB, pcKodeCust, pcNamaCust, pcKodeKAE, pcNamaKAE, pcKodeTOP, pcNamaTOP, pcKodeTransaksiPKB,
                    pcNamaTransaksiPKB, pcJenisOrder, "PENDING", pcKodeTransaksiPKB, pcNamaTransaksiPKB, "", "", "", "", "",
                    0, _03nTotQtyPKB.EditValue, 0, 0, 0,
                    (pnBeratPerPcs * _03nTotQtyPKB.EditValue), 0.0, 0.0, 0.0, 0.0,
                    Today.Date, vdaTglAutoApproveSLS, vdaTglAutoApproveFIN, "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            Exit For
        Next

    End Sub

    Private Sub _cm13HitungTotalPO()
        Dim nStock As Int32 = Convert.ToInt32(_11nQtySaldoProductCode.EditValue)
        Dim nOutstanding As Int32 = Convert.ToInt32(_10nQtyPKBOSTProductCode.EditValue)
        Dim nOrder As Int32 = Convert.ToInt32(_03nTotQtyPKB.EditValue)

        Dim availableQty As Int32 = nStock - nOutstanding
        Dim pnJmlPO As Int32 = Math.Max(0, nOrder - Math.Max(0, availableQty))

        _04nTotPO.EditValue = pnJmlPO

        'Dim pnJmlPO As Int32 = _11nQtySaldoProductCode.EditValue - _10nQtyPKBOSTProductCode.EditValue - _03nTotQtyPKB.EditValue

        '_04nTotPO.EditValue = If(pnJmlPO < 0, Math.Abs(pnJmlPO), 0)
    End Sub

#End Region

#Region "PKB - Product Code"
    Private Sub _cm31SettingGridCheckBox(ByVal prmlShow As Boolean)
        Dim objGridCheckBox As __dlgSetVisibilityCheckBox = AddressOf _gdSKU._ivkSetVisibilityCheckBox
        objGridCheckBox.Invoke(prmlShow)
    End Sub

#End Region

#Region "PO ==> MERCHANDISE"

    Private Sub _ps01DataPOMerchandise()
        Cursor.Current = Cursors.WaitCursor

        Dim pcTargetPKB As String = ""
        If _01cPKBBasedOn.SelectedIndex = 0 Then    'ProdCode
            pcTargetPKB = "PRODUCTCODE"
        Else
            If _01cPKBBasedOn.SelectedIndex = 1 Then    'PKB-SKU
                pcTargetPKB = "SKU"
            End If
        End If

        Dim pnBeratPerPcs As Double = 0.0

        Dim objgdPKBCustomer As __dlgGetDataDouble = AddressOf _gdSKU._ivkGetDataBrtPerPcsPKBCustomer
        pnBeratPerPcs = objgdPKBCustomer.Invoke(pcTargetPKB)

        Dim pcKodeCustomer As String = ""
        Dim pcNamaCustomer As String = ""
        For Each dtRowPKB As DataRow In _prop03DataSmall.Rows
            'f26 = Customer ==> kode : f29
            pcNamaCustomer = dtRowPKB("f01String") '_01cCustomer.Text
            pcKodeCustomer = dtRowPKB("k03String") '_01cCustomer.EditValue
        Next

        'Dim pdtTiny As New DataTable
        'Dim objTempTiny As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtTiny}
        'objTempTiny.dtInitsTABLETINY()

        _prop07DataPKBMerchaindise.dtAddNewsTABLETINY(
            _02cProductCode.EditValue, pcNoDocument, pcKodeCustomer,
            pcNamaCustomer, "ucWS23LN01PKB", "PERINTAH KIRIM BRG : CUSTOMER", "", "",
            0, _04nTotPO.EditValue, 0,
            pnBeratPerPcs, Format((pnBeratPerPcs * _04nTotPO.EditValue), "N2"), 0.0,
            Today.Date, _05dTglETA.EditValue,
            "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
            _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

        Cursor.Current = Cursors.Default

    End Sub

    '**********************************************************************
    '****************************** NOT USED ******************************
    '******   sudah digantikan dengan spWSTABLE25SaveShipmentOrder   ******
    '**********************************************************************
    'Private Async Sub _ps01SavePOMerchandise()
    '    Cursor.Current = Cursors.WaitCursor

    '    Dim pdtHasil As New DataTable

    '    Dim objParamCollection As clsWSNasaSelectParamDataCollection = New clsWSNasaSelectParamDataCollection()
    '    objParamCollection._pb01AddNew(0, 0, 0, _02cProductCode.EditValue, "", "", 0, 0, "3000-01-01", "3000-01-01")

    '    Dim objHelper As New clsWSNasaHelper
    '    pdtHasil = objHelper._pbWSNasaHelperExec04SPSELECTToDataTable(_prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS, objParamCollection, "spMD23CreateOrderDesignMaster", "@tpParamSQLSelect")

    '    objParamCollection.Dispose()

    '    Dim pcNumberOrderMD As String = ""
    '    Dim objMaster As New clsGetDataMasterGEMINI()
    '    pcNumberOrderMD = Await objMaster._pb03IncNumberMaster_Async(_prop01User._UserProp08TargetNetwork, "MNORDERMD", "cNOMORDOKUMEN")

    '    Dim objgdPKBCustomer As __dlgGetDataDouble = AddressOf _gdSKU._ivkGetDataBrtPerPcsPKBCustomer
    '    Dim pnBeratPerPcs As Double = objgdPKBCustomer.Invoke()

    '    For Each dtRow As DataRow In pdtHasil.Rows
    '        dtRow("k05String") = pcNumberOrderMD

    '        'f24 = Tipeproduksi    ==> kode : f27
    '        dtRow("f24String") = "MAKE TO ORDER" '_02cTipeProduksi.Text
    '        dtRow("f27String") = "MTO" '_02cTipeProduksi.EditValue

    '        'f25 = SubTipeProduksi ==> kode : f28
    '        dtRow("f25String") = "EXISTING MODEL" '_03cSubTipeProduksi.Text
    '        dtRow("f28String") = "MTO01" '_03cSubTipeProduksi.EditValue

    '        For Each dtRowPKB As DataRow In _prop03DataSmall.Rows
    '            'f26 = Customer ==> kode : f29
    '            dtRow("f26String") = dtRowPKB("f01String") '_01cCustomer.Text
    '            dtRow("f29String") = dtRowPKB("k03String") '_01cCustomer.EditValue
    '        Next

    '        dtRow("f01Int") = _04nTotPO.EditValue
    '        dtRow("f01Double") = pnBeratPerPcs
    '        dtRow("f02Double") = pnBeratPerPcs * _04nTotPO.EditValue

    '        dtRow("f01Date") = Today.Date
    '        dtRow("f02Date") = _05dTglETA.EditValue
    '    Next
    '    pdtHasil.AcceptChanges()

    '    Dim objProductOrder As clsGetDataProsesTransaksiGEMINI = New clsGetDataProsesTransaksiGEMINI
    '    Dim pnJmlRec As Integer = Await objProductOrder._tr01NasaExecDirectAllDB_Async(_prop01User._UserProp08TargetNetwork, clsGetDataProsesTransaksiGEMINI._pnmDatabaseName.SBU,
    '                                                                2, "spTABLE50Save", "@tpTEMPLATEGEMINI", pdtHasil)
    '    Cursor.Current = Cursors.Default
    'End Sub
    '**********************************************************************
    '****************************** NOT USED ******************************
    '**********************************************************************

#End Region

#Region "control - event"

    Private Sub _01cPKBBasedOn_EditValueChanged(sender As Object, e As EventArgs) Handles _01cPKBBasedOn.EditValueChanged
        If _gdSKU._prop03pdtDataSourceGrid.Rows.Count > 0 Then
            If _01cPKBBasedOn.SelectedIndex = 0 Then
                _cm31SettingGridCheckBox(False)
            Else
                _cm31SettingGridCheckBox(True)
            End If
        End If
    End Sub

    Private Sub _20mnuBarSubmit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _20mnuBarSubmit.ItemClick
        If _03nTotQtyPKB.EditValue > 0 Then
            _cm08SavePKB()
        Else
            MsgBox("Maaf ... Order Qty tidak boleh NOL (0) ...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _21mnuBarClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _21mnuBarClear.ItemClick
        _cm05BersihkanEntrian()
    End Sub

    Private Sub _02cProductCode_EditValueChanged(sender As Object, e As EventArgs) Handles _02cProductCode.EditValueChanged

        If Not String.IsNullOrEmpty(_02cProductCode.EditValue) Then
            _cm02FillImage()
            _cm03FillGridSKU()
            _cm11DisplayBrandKadarItem()

            With _03nTotQtyPKB
                .Focus()
                .EditValue = 0
            End With
        End If
    End Sub

    Private Sub _03nTotQtyPKB_EditValueChanged(sender As Object, e As EventArgs) Handles _03nTotQtyPKB.EditValueChanged
        _cm13HitungTotalPO()
    End Sub

    Private Sub _03nTotQtyPKB_GotFocus(sender As Object, e As EventArgs) Handles _03nTotQtyPKB.GotFocus
        _cm13HitungTotalPO()
    End Sub




#End Region

End Class
