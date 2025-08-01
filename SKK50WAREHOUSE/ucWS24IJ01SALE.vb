Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin
Imports DevExpress.Skins
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Commands
Imports DevExpress.XtraEditors
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucWS24IJ01SALE
    Implements IDisposable
    Implements clsRefreshTab

    Property _prop01User As clsWSNasaUser

    Private pdtStock As DataTable

    Private pdtEntrySale As DataTable
    Private objEntrySale As clsWSNasaTemplateDataLarge

    Private pcKodeProsesSALE As String
    Private pcNamaProsesSALE As String

    Private _cachedCustomerTable As DataTable = Nothing
    Private _cachedTOPTable As DataTable = Nothing


#Region "form - event"

    Public Sub New()


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtStock = New DataTable

        pdtEntrySale = New DataTable
        objEntrySale = New clsWSNasaTemplateDataLarge With {.prop_dtsTABLELARGE = pdtEntrySale}
        objEntrySale.dtInitsTABLELARGE()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtStock.Dispose()

        pdtEntrySale.Dispose()
        objEntrySale.Dispose()

        Me.Dispose()
    End Sub

    Private Sub ucWS24IJ01SALE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        _cm01InitDataControl()
        _cm02BersihkanEntrian()

        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 10

        TabPane1.SelectedPage = TabDetailStock
    End Sub

    Public Sub RefreshData() Implements clsRefreshTab.RefreshTab

        ' _cm03InitGrid()
    End Sub



#End Region

#Region "custom - method"

    Private Sub _cm01InitDataControl()
        Cursor = Cursors.WaitCursor

        Dim pdtTargetPenjualan As New DataTable

        Using objTargetPenjualan As New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtTargetPenjualan = objTargetPenjualan._pb10GetDataTargetPenjualan()
        End Using

        Dim pdtCustomer As New DataTable
        Dim pdtExhibition As New DataTable
        Dim pdtTOP As New DataTable

        Using objNasaMaster As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            _cachedCustomerTable = objNasaMaster.__pb04GetDataTable52Customer()
            pdtCustomer = objNasaMaster.__pb04GetDataTable52Customer()
            pdtExhibition = objNasaMaster.__pb05GetDataTable21Pameran()
            pdtTOP = objNasaMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("TOP")
            _cachedTOPTable = objNasaMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("TOP")
        End Using

        Dim pdtMenuKAE As New DataTable
        Dim dtRowKAE() As DataRow
        dtRowKAE = pdtTargetPenjualan.Select("f28String = '5062'")
        If dtRowKAE.Count > 0 Then
            pdtMenuKAE = dtRowKAE.CopyToDataTable()
        End If

        Dim pdtMenuConsignment As New DataTable
        Dim dtRowConsignment() As DataRow
        dtRowConsignment = pdtTargetPenjualan.Select("f28String = '5063'")
        If dtRowConsignment.Count > 0 Then
            pdtMenuConsignment = dtRowConsignment.CopyToDataTable()
        End If

        _cm011InitControl(pdtMenuKAE, pdtMenuConsignment)
        _cm011InitControl01(pdtCustomer, pdtExhibition)
        _cm011InitControl02(pdtTOP)



        Cursor = Cursors.Default
    End Sub

    Private Sub _cm011InitControl(ByVal prmdtSalesSelling As DataTable, ByVal prmdtConsignment As DataTable)
        _colf06String.FieldName = "f06String"
        _colf06String1.FieldName = "f06String"

        _colf07String.FieldName = "f07String"
        _colf07String1.FieldName = "f07String"

        With rsmnuBar11SalesSelling
            .DataSource = prmdtSalesSelling
            .ValueMember = "f06String"
            .DisplayMember = "f07String"
        End With

        With rsmnuBar12Consignment
            .DataSource = prmdtConsignment
            .ValueMember = "f06String"
            .DisplayMember = "f07String"
        End With
    End Sub

    Private Sub _cm011InitControl01(ByVal prmdtCustomer As DataTable, ByVal prmdtExhibition As DataTable)
        _colk02StringCust.FieldName = "k02String"
        _colk03StringCust.FieldName = "k03String"

        _colf05StringExh.FieldName = "f05String"
        _colf06StringExh.FieldName = "f06String"

        With rsmnuBar04Kepada
            .DataSource = prmdtCustomer
            .ValueMember = "k02String"
            .DisplayMember = "k03String"
        End With

        With rsmnuBar13Exhibition
            .DataSource = prmdtExhibition
            .ValueMember = "f05String"
            .DisplayMember = "f06String"
        End With
    End Sub

    Private Sub _cm011InitControl02(ByVal prmdtTOP As DataTable)
        _colk13StringTOP.FieldName = "k13String"
        _colk14StringTOP.FieldName = "k14String"

        With rsmnuBar06TOP
            .DataSource = prmdtTOP
            .ValueMember = "k13String"
            .DisplayMember = "k14String"
        End With
    End Sub

    Private Sub _cm02BersihkanEntrian()
        mnuBar02TglPenjualan.EditValue = Today.Date

        mnuBar04Kepada.Visibility = BarItemVisibility.Never
        mnuBar04Kepada.EditValue = ""
        mnuBar06TOP.EditValue = ""

        mnuBar11SalesSelling.EditValue = ""
        rsmnuBar11SalesSelling.NullValuePrompt = ""

        mnuBar13Exhibition.EditValue = ""
        rsmnuBar13Exhibition.NullValuePrompt = ""

        mnuBar12Consignment.EditValue = ""
        rsmnuBar12Consignment.NullValuePrompt = ""

        pcKodeProsesSALE = ""
        pcNamaProsesSALE = ""

        TabPenjualan.Caption = ""
        _gdPenjualan.__pbWSGrid02ClearGrid()
        _pvSummaryStock._pbWSPivot02ClearPivot()
        _gdDetailStock.__pbWSGrid02ClearGrid()

    End Sub

    Private Sub _cm03DisplayStockForSale(ByVal prmcKodeTargetSale As String, Optional ByVal prmcSLoc As String = "")
        'SLS :> "5062"   '"NEW PKB KAE"
        'CSG :> "5063"   '"NEW PKB CONSIGNMENT"
        'EXH :> "5066"   '"NEW PKB EXHIBITION"
        Cursor = Cursors.WaitCursor

        pdtStock.Clear()
        _gdDetailStock.__pbWSGrid02ClearGrid()

        Using objStock As New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
            pdtStock = objStock._pb30GetDataStockForSaleSalesConsign(prmcKodeTargetSale, prmcSLoc)
        End Using

        With _gdDetailStock
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSStockForSale
            ._prop03pdtDataSourceGrid = pdtStock
        End With
        _gdDetailStock.__pbWSGrid01InitGrid()
        _gdDetailStock.__pbWSGrid03DisplayGrid()

        With _pvSummaryStock
            ._prop01User = _prop01User
            ._prop02TargetPivot = ucWSPivot._pbEnumTargetPivot._wsStockForSale
            ._prop03pdtDataSourcePivot = pdtStock
        End With
        _pvSummaryStock._pbWSPivot01InitPivot()
        _pvSummaryStock._pbWSPivot03DisplayPivot()

        objEntrySale.prop_dtsTABLELARGE.Clear()
        With _gdPenjualan
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSEntrySKUForSale
            ._prop03pdtDataSourceGrid = objEntrySale.prop_dtsTABLELARGE

        End With
        _gdPenjualan.__pbWSGrid01InitGrid()
        _gdPenjualan.__pbWSGrid03DisplayGrid()

        TabPane1.SelectedPage = TabPenjualan

        'f01Date,f01String,k03String,f01SmallInt,f01Double,f10String,f16String,f12String,f23String,f14String
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm10ProcessSaveSale()

        Dim setKodeCustomerMaster As New HashSet(Of String)(_cachedCustomerTable.AsEnumerable().Select(Function(r) r.Field(Of String)("k02String")))
        Dim setKodeTOPMaster As New HashSet(Of String)(_cachedTOPTable.AsEnumerable().Select(Function(r) r.Field(Of String)("k13String")))

        Dim listInvalidCustomerSKU As New List(Of String)
        For Each dtRow As DataRow In _gdPenjualan._prop03pdtDataSourceGrid.Rows
            Dim pcKodeCustomer As String = dtRow("f04String").ToString().Trim()
            Dim pcKodeTOP As String = dtRow("f21String").ToString().Trim()
            If Not setKodeCustomerMaster.Contains(pcKodeCustomer) Then
                listInvalidCustomerSKU.Add(dtRow("k03String").ToString().Trim())
            End If
            If Not setKodeTOPMaster.Contains(pcKodeTOP) Then
                listInvalidCustomerSKU.Add(dtRow("k03String").ToString().Trim())
            End If
        Next

        If listInvalidCustomerSKU.Count > 0 Then
            Dim pesan As String = "Please check the Customer Code or TOP Code information below — some entries are invalid and were not saved:" & vbCrLf &
                              String.Join(vbCrLf, listInvalidCustomerSKU)
            MsgBox(pesan, vbExclamation, _prop01User._UserProp01cTitle)

            ' Simpan pesan ke file sementara
            Dim filePath As String = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "MERSY_tDirectSelling_Invalid.txt")
            System.IO.File.WriteAllText(filePath, pesan)

            ' Buka file tersebut dengan Notepad
            Process.Start("notepad.exe", filePath)
            Exit Sub
        End If

        Dim pdtPenjualan As New DataTable
        pdtPenjualan = _cm11PrepareSaveSale()

        If pdtPenjualan.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            Dim objNasa As New clsWSNasaHelper
            Dim pnJmlRec As Integer = 0
            pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                2, "spWSTABLE29Save", "@tpDataForSaving", pdtPenjualan)

            Cursor = Cursors.Default

            MsgBox("Data has been saved successfully.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

            _cm02BersihkanEntrian()
        Else
            MsgBox("Hmm... Hmm... Hmm...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

    Private Function _cm11PrepareSaveSale() As DataTable
        Dim pdtPenjualanKAE As New DataTable
        Dim objPenjualanKAE As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtPenjualanKAE}
        objPenjualanKAE.dtInitsTABLEMEDIUMPLUSPLUS()

        Dim dicNoDocByCustomer As New Dictionary(Of String, String)

        For Each dtRow As DataRow In _gdPenjualan._prop03pdtDataSourceGrid.Rows
            Dim pcKodeSLoc As String = ""
            Dim pcNamaSLoc As String = ""
            If pcKodeProsesSALE = "CSG" Then
                pcKodeSLoc = dtRow("f08String")
                pcNamaSLoc = dtRow("f09String")
            Else
                pcKodeSLoc = dtRow("f06String")
                pcNamaSLoc = dtRow("f07String")
            End If

            Dim pcKodeCustomer As String = dtRow("f04String")
            Dim pcNoDoc As String = ""

            If Not dicNoDocByCustomer.ContainsKey(pcKodeCustomer) Then
                Using objNoDoc As New clsWSNasaSelect4AllProsesMaster With {
            ._prop01User = _prop01User,
            ._prop02String = "WSPENJUALAN"
        }
                    pcNoDoc = objNoDoc._pb51GetDataIncNoDocWarehouse()
                    If pcNoDoc <> "" Then
                        dicNoDocByCustomer.Add(pcKodeCustomer, pcNoDoc)
                    End If
                End Using
            Else
                pcNoDoc = dicNoDocByCustomer(pcKodeCustomer)
            End If

            If pcNoDoc <> "" Then
                objPenjualanKAE.dtAddNewsTABLEMEDIUMPLUS(
                    "", pcNoDoc, dtRow("k03String"),
                    dtRow("f18String"), dtRow("f02String"), pcKodeSLoc, pcNamaSLoc, pcKodeCustomer,
                    dtRow("f05String"), dtRow("f21String"), dtRow("f22String"), pcNamaProsesSALE, "",
                    dtRow("f16String"), "", dtRow("f10String"), "", "", "", "", "", "", dtRow("f20String"),
                    "", "", "", "", "", "", "", "", "", dtRow("f40String"),
                    dtRow("f01TinyInt"), dtRow("f01SmallInt"), 0, 0, 0, dtRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
                    dtRow("f01Date"), mnuBar02TglPenjualan.EditValue, "3000-01-01", "3000-01-01", "3000-01-01",
                    "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            End If
        Next

        Return objPenjualanKAE.prop_dtsTABLEMEDIUMPLUS
    End Function



#End Region

#Region "public - method"
    Public Delegate Sub __dlgSaveData()

    Public Sub _ivkSaveSalesSelling()
        _cm10ProcessSaveSale()
    End Sub
#End Region

#Region "control - event"

    Private Sub mnuBar03SKU_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar03SKU.ItemClick
        Dim plDataOK As Boolean = True

        If pcKodeProsesSALE = "" Then
            plDataOK = False
            MsgBox("Please fill in the Sales Target before continuing.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

        If plDataOK Then

            Dim objSKUSale As New ucWS24HG01PICKING With {._prop01User = _prop01User,
                                                            ._prop02TargetSKU = ucWS24HG01PICKING._pbEnumTargetSKU._SKUSale,
                                                            ._prop04Grid = _gdPenjualan,
                                                            ._prop05DataStock = pdtStock,
                                                            ._prop07FormSale = Me,
                                                            ._prop08CustomerCode = If(pcKodeProsesSALE = "CSG", mnuBar12Consignment.EditValue, mnuBar04Kepada.EditValue),
                                                            ._prop09Customer = If(pcKodeProsesSALE = "CSG", rsmnuBar12Consignment.GetDisplayText(mnuBar12Consignment.EditValue), rsmnuBar04Kepada.GetDisplayText(mnuBar04Kepada.EditValue)),
                                                            ._prop10TOPCode = mnuBar06TOP.EditValue,
                                                            ._prop11TOP = rsmnuBar06TOP.GetDisplayText(mnuBar06TOP.EditValue),
                                                            ._prop12ProsesSale = pcKodeProsesSALE,
                                                            .Dock = DockStyle.Fill}


            Dim objSize As New Size With {.Width = objSKUSale.Size.Width - 600,
                                          .Height = objSKUSale.Size.Height - 320}

            Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                                .MinimizeBox = False, .ShowIcon = False,
                                                .StartPosition = FormStartPosition.CenterScreen,
                                                .Text = "SKU Scanning | " & _prop01User._UserProp01cTitle}
            frmModal.AddControl(objSKUSale)

            frmModal.ShowDialog()
        End If

    End Sub

    Private Sub mnuBar05Save_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar05Save.ItemClick
        _cm10ProcessSaveSale()
    End Sub

    Private Sub mnuBar11SalesSelling_EditValueChanged(sender As Object, e As EventArgs) Handles mnuBar11SalesSelling.EditValueChanged
        ' ===================== UPDATED BY AKIRRA - 16/04/25 =====================
        ' agar ketika mengubah target penjualan, maka value pada textboxt di reset.
        Dim val = mnuBar11SalesSelling.EditValue
        _cm02BersihkanEntrian()
        rsmnuBar11SalesSelling.NullValuePrompt = rsmnuBar11SalesSelling.GetDisplayText(val)


        ' ======================================================================

        'SLS :> "5062"   '"NEW PKB KAE"
        pcKodeProsesSALE = "SLS"
        pcNamaProsesSALE = "SALESSELLING"
        _cm03DisplayStockForSale(pcKodeProsesSALE, val)

        mnuBar04Kepada.Visibility = BarItemVisibility.Always
        TabPenjualan.Caption = "SalesSelling : " & rsmnuBar11SalesSelling.GetDisplayText(val)
    End Sub

    Private Sub mnuBar12Consignment_EditValueChanged(sender As Object, e As EventArgs) Handles mnuBar12Consignment.EditValueChanged
        Dim val = mnuBar12Consignment.EditValue
        mnuBar11SalesSelling.EditValue = ""
        rsmnuBar11SalesSelling.NullValuePrompt = ""

        mnuBar13Exhibition.EditValue = ""
        rsmnuBar13Exhibition.NullValuePrompt = ""

        rsmnuBar12Consignment.NullValuePrompt = rsmnuBar12Consignment.GetDisplayText(val)

        'CSG :> "5063"   '"NEW PKB CONSIGNMENT"
        pcKodeProsesSALE = "CSG"
        pcNamaProsesSALE = "CONSIGNMENT"
        _cm03DisplayStockForSale(pcKodeProsesSALE, val)

        mnuBar04Kepada.Visibility = BarItemVisibility.Never
        TabPenjualan.Caption = "Consignment : " & rsmnuBar12Consignment.GetDisplayText(val)


    End Sub

    Private Sub mnuBar13Exhibition_EditValueChanged(sender As Object, e As EventArgs) Handles mnuBar13Exhibition.EditValueChanged
        Dim val = mnuBar13Exhibition.EditValue
        _cm02BersihkanEntrian()
        rsmnuBar13Exhibition.NullValuePrompt = rsmnuBar13Exhibition.GetDisplayText(val)

        'EXH :> "5066"   '"NEW PKB EXHIBITION"
        pcKodeProsesSALE = "EXH"
        pcNamaProsesSALE = "EXHIBITION"
        _cm03DisplayStockForSale(pcKodeProsesSALE, val)

        mnuBar04Kepada.Visibility = BarItemVisibility.Always
        TabPenjualan.Caption = "Exhibition : " & rsmnuBar13Exhibition.GetDisplayText(val)
    End Sub



    Private Sub mnuBar1TargetPenjualan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar1TargetPenjualan.ItemClick
        _cm01InitDataControl()
    End Sub


#End Region

End Class

'***** Master Customer   *****
'Select * From TABLE52 Order By k03String;

'***** Master Exhibition *****
'Select * From TABLEMASTER..TABLE21 Where f03String = '5040' and f01Int = 50405 and f10String = 'OPEN' order by f05String
