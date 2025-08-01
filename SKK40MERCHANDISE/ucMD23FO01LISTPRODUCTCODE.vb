Imports DevExpress.CodeParser
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.WinExplorer
Imports DevExpress.XtraPrinting.Native
Imports System.Drawing
Imports SKK02OBJECTS

Public Class ucMD23FO01LISTPRODUCTCODE
    Implements IDisposable

    Public Property prop01cUser As clsUserGEMINI

    Private objGetDataReportGEMINI As clsGetDataReportGEMINI
    Private pdvItemBRJ As DataView
    Private pdvBrand As DataView
    Private pdvColour As DataView
    Private pdvKadar As DataView
    Private pdvCollection As DataView

    Private plDataForFilterDone As Boolean = False

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objGetDataReportGEMINI = New clsGetDataReportGEMINI()
        pdvItemBRJ = New DataView
        pdvBrand = New DataView
        pdvColour = New DataView
        pdvKadar = New DataView
        pdvCollection = New DataView

        plDataForFilterDone = False
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objGetDataReportGEMINI.Dispose()
        pdvItemBRJ.Dispose()
        pdvBrand.Dispose()
        pdvColour.Dispose()
        pdvKadar.Dispose()
        pdvCollection.Dispose()
    End Sub

    Private Sub ucMD23FO01LISTPRODUCTCODE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(prop01cUser._UserProp10Skin)

        _cm01BersihkanEntrian()
        _cm00InitFieldGridGambar()
        _cm00InitFieldGridTabel()
    End Sub
#End Region

#Region "custom method"

    Private Sub _cm00InitFieldGridGambar()
        'Item
        _01cFilterCodeItem.FieldName = "f03cKodeItemProduct_v50"
        _02cFilterNameItem.FieldName = "f04cNamaItemProduct_v50"
        _03cItemBRJ.Properties.DisplayMember = "f04cNamaItemProduct_v50"
        _03cItemBRJ.Properties.ValueMember = "f03cKodeItemProduct_v50"
        'Brand
        _01cFilterCodeBrand.FieldName = "f05cKodeBrand_v50"
        _02cFilterNameBrand.FieldName = "f06cNamaBrand_v50"
        _04cBrand.Properties.DisplayMember = "f06cNamaBrand_v50"
        _04cBrand.Properties.ValueMember = "f05cKodeBrand_v50"
        'Colour
        _01cFilterCodeColour.FieldName = "f11cKodeColor_v50"
        _02cFilterNameColour.FieldName = "f12cNamaColor_v50"
        _05cColour.Properties.DisplayMember = "f12cNamaColor_v50"
        _05cColour.Properties.ValueMember = "f11cKodeColor_v50"
        'Kadar
        _01cFilterCodeKadar.FieldName = "f09cKodeKadar_v50"
        _02cFilterNameKadar.FieldName = "f10cNamaKadar_v50"
        _06cKadar.Properties.DisplayMember = "f10cNamaKadar_v50"
        _06cKadar.Properties.ValueMember = "f09cKodeKadar_v50"
        'Collection
        _01cFilterCodeCollection.FieldName = "f03cKodeProject_v50"
        _02cFilterCollection.FieldName = "f04cNamaProject_v50"
        _08cCollection.Properties.DisplayMember = "f04cNamaProject_v50"
        _08cCollection.Properties.ValueMember = "f03cKodeProject_v50"

        'Grid
        _col01k01cKodeProduct_v50.FieldName = "k01cKodeProduct_v50"
        _col02nBerat.FieldName = "nBerat"
        _col03f04cNamaItemProduct_v50.FieldName = "f04cNamaItemProduct_v50"
        _col04f06cNamaBrand_v50.FieldName = "f06cNamaBrand_v50"
        _col05f12cNamaColor_v50.FieldName = "f12cNamaColor_v50"
        _col06f10cNamaKadar_v50.FieldName = "f10cNamaKadar_v50"
        _col07f14cNamaSize_v50.FieldName = "f14cNamaSize_v50"
        _col08f04cNamaProject_v50.FieldName = "f04cNamaProject_v50"
        _col09objImageBRJ.FieldName = "objImageBRJ"
        _col10f42dCreatedDate.FieldName = "f42dCreatedDate"

        WinExplorerView1.OptionsView.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto

    End Sub

    Private Sub _cm00InitFieldGridTabel()
        _colMD01k01cKodeProduct_v50.FieldName = "k01cKodeProduct_v50"
        _colMD02f01cNamaProduct_v50.FieldName = "f01cNamaProduct_v50"
        _colMD03f02cKodeDesignMaster_v50.FieldName = "f02cKodeDesignMaster_v50"
        _colMD04f04cNamaProject_v50.FieldName = "f04cNamaProject_v50"
        _colMD05f06cNamaBrand_v50.FieldName = "f06cNamaBrand_v50"
        _colMD06f04cNamaItemProduct_v50.FieldName = "f04cNamaItemProduct_v50"
        _colMD07f08cNamaMaterial_v50.FieldName = "f08cNamaMaterial_v50"
        _colMD08f10cNamaKadar_v50.FieldName = "f10cNamaKadar_v50"
        _colMD09f12cNamaColor_v50.FieldName = "f12cNamaColor_v50"
        _colMD10f20cNamaPlating_v50.FieldName = "f20cNamaPlating_v50"
        _colMD11f14cNamaSize_v50.FieldName = "f14cNamaSize_v50"
        _colMD12f32cNamaWarnaEnamel_v500.FieldName = "f32cNamaWarnaEnamel_v500"
        _colMD13f42dCreatedDate.FieldName = "f42dCreatedDate"

        GridView1.BestFitColumns(True)
    End Sub

    Private Sub _cm01BersihkanEntrian()
        _02dTglPeriodeHingga.EditValue = Date.Today
        _01dTglPeriodeDari.EditValue = DateAdd(DateInterval.Day, -30, _02dTglPeriodeHingga.EditValue)
        _03cItemBRJ.EditValue = ""
        _04cBrand.EditValue = ""
        _05cColour.EditValue = ""
        _06cKadar.EditValue = ""
        _07cMasterORProductCode.EditValue = ""
        _08cCollection.EditValue = ""

        plDataForFilterDone = False
    End Sub

    Private Function _cm02CreateDateSerial(ByVal prmdTanggal As Date) As Date
        Dim pnYear As Integer = 0 : Dim pnMonth As Integer = 0 : Dim pnDay As Integer = 0
        pnYear = 0 : pnMonth = 0 : pnDay = 0

        pnYear = DateAndTime.Year(prmdTanggal)
        pnMonth = DateAndTime.Month(prmdTanggal)
        pnDay = DateAndTime.Day(prmdTanggal)

        Dim pdTanggal As Date = Nothing
        pdTanggal = DateSerial(pnYear, pnMonth, pnDay)

        Return pdTanggal
    End Function

    Private Sub _cm03SetDataForFilter()

        Dim pcSQL As String = ""
        pcSQL = "SELECT DISTINCT a.f03cKodeItemProduct_v50, a.f04cNamaItemProduct_v50, " &
         "a.f05cKodeBrand_v50, a.f06cNamaBrand_v50, a.f11cKodeColor_v50, a.f12cNamaColor_v50, " &
         "a.f09cKodeKadar_v50, a.f10cNamaKadar_v50, b.f03cKodeProject_v50, b.f04cNamaProject_v50 " &
         "FROM MRP..t32PRODUCT AS a " &
         "JOIN MRP..t30DESIGNMASTER AS b " &
         "ON a.f02cKodeDesignMaster_v50 = b.k01cKodeDesignMaster_v50 " &
         "WHERE a.f42dCreatedDate BETWEEN '" & _cm02CreateDateSerial(_01dTglPeriodeDari.EditValue) &
         "' AND '" & _cm02CreateDateSerial(_02dTglPeriodeHingga.EditValue) & "';"
        'Clipboard.SetText(pcSQL)

        With objGetDataReportGEMINI
            ._propTargetReportGEMINI = clsGetDataReportGEMINI.TargetDataReportGEMINI._infoCatalogProduct
        End With

        Dim pdtHasil As New DataTable
        pdtHasil = objGetDataReportGEMINI._info02GetDataDisplayProductCode(prop01cUser._UserProp07TargetNetwork, pcSQL)

        pdvItemBRJ = _cm05dvConvertToView(pdtHasil, "ITEMBRJ")
        _03cItemBRJ.Properties.DataSource = Nothing
        _03cItemBRJ.Properties.DataSource = pdvItemBRJ

        pdvBrand = _cm05dvConvertToView(pdtHasil, "BRAND")
        _04cBrand.Properties.DataSource = Nothing
        _04cBrand.Properties.DataSource = pdvBrand

        pdvColour = _cm05dvConvertToView(pdtHasil, "COLOR")
        _05cColour.Properties.DataSource = Nothing
        _05cColour.Properties.DataSource = pdvColour

        pdvKadar = _cm05dvConvertToView(pdtHasil, "KADAR")
        _06cKadar.Properties.DataSource = Nothing
        _06cKadar.Properties.DataSource = pdvKadar

        pdvCollection = _cm05dvConvertToView(pdtHasil, "COLLECTION")
        _08cCollection.Properties.DataSource = Nothing
        _08cCollection.Properties.DataSource = pdvCollection

        plDataForFilterDone = True
    End Sub

    'update : Kamis, 13 Juli 2023
    'Hari ini pernikahan Arif, tapi aku nggak bisa hadir sb masih sakit (operasi yg ke 3).
    'Selamat Berbahagia dan Menempuh Hidup Baru, RIF ...
    Private Function _cm031BuildFinalFilter(ByVal prmnTarget As Int16) As String
        Dim pcFilterSQL As String = Space(1)

        Select Case prmnTarget
            Case 1  'default filter
                If Not String.IsNullOrEmpty(_03cItemBRJ.EditValue) Then
                    pcFilterSQL = pcFilterSQL + " and a.f03cKodeItemProduct_v50 = '" & _03cItemBRJ.EditValue & "' "
                End If
                If Not String.IsNullOrEmpty(_04cBrand.EditValue) Then
                    pcFilterSQL = pcFilterSQL + " and a.f05cKodeBrand_v50 = '" & _04cBrand.EditValue & "' "
                End If
                If Not String.IsNullOrEmpty(_05cColour.EditValue) Then
                    pcFilterSQL = pcFilterSQL + " and a.f11cKodeColor_v50 = '" & _05cColour.EditValue & "' "
                End If
                If Not String.IsNullOrEmpty(_06cKadar.EditValue) Then
                    pcFilterSQL = pcFilterSQL + " and a.f09cKodeKadar_v50 = '" & _06cKadar.EditValue & "' "
                End If
                If Not String.IsNullOrEmpty(_08cCollection.EditValue) Then
                    pcFilterSQL = pcFilterSQL + " and b.f03cKodeProject_v50 = '" & _08cCollection.EditValue & "' "
                End If

                pcFilterSQL = pcFilterSQL + " order by a.k01cKodeProduct_v50; "
                pcFilterSQL = " where a.f42dCreatedDate between '" & _cm02CreateDateSerial(_01dTglPeriodeDari.EditValue) & "' and '" _
                                                                   & _cm02CreateDateSerial(_02dTglPeriodeHingga.EditValue) & "' " _
                                                                   & pcFilterSQL
            Case 2  'Product Code
                pcFilterSQL = " where a.k01cKodeProduct_v50 = '" & _07cMasterORProductCode.EditValue & "';"

            Case 3  'Master Code 
                pcFilterSQL = " where a.f02cKodeDesignMaster_v50 = '" & _07cMasterORProductCode.EditValue & "' order by a.k01cKodeProduct_v50; "

        End Select

        Return pcFilterSQL
    End Function

    Private Function _cm04GetDataForDisplayProductCode(ByVal prmnTarget As Int16) As DataTable
        Dim sql As String = "
        SELECT 
            a.k01cKodeProduct_v50,
            ISNULL(d.f08nProductEstimasiBerat_n93, 0.0) AS nBerat,
            a.f03cKodeItemProduct_v50, a.f04cNamaItemProduct_v50,
            a.f05cKodeBrand_v50, a.f06cNamaBrand_v50,
            a.f11cKodeColor_v50, a.f12cNamaColor_v50,
            a.f09cKodeKadar_v50, a.f10cNamaKadar_v50,
            a.f13cKodeSize_v50, a.f14cNamaSize_v50, a.f42dCreatedDate,
            b.f03cKodeProject_v50, b.f04cNamaProject_v50,
            CASE WHEN c.f01objGambar IS NOT NULL THEN c.f01objGambar ELSE NULL END AS objImageBRJ
        FROM MRP..t32PRODUCT AS a
        LEFT JOIN MRP..t30DESIGNMASTER AS b ON a.f02cKodeDesignMaster_v50 = b.k01cKodeDesignMaster_v50
        LEFT JOIN GAMBAR..y01GAMBAR AS c ON a.k01cKodeProduct_v50 = c.f02cKodeFGorComponent_v50 COLLATE database_default
        LEFT JOIN MRP..t24COREBOM AS d ON a.k01cKodeProduct_v50 = d.k01cKodeProduct_v50
        " & _cm031BuildFinalFilter(prmnTarget)

        Return ExecuteSQLForCatalogProduct(sql)
    End Function

    Private Function _cm04GetDataForGridTabelProductCode(ByVal prmnTarget As Int16) As DataTable
        Dim sql As String = "
        SELECT 
            a.k01cKodeProduct_v50, a.f01cNamaProduct_v50, a.f02cKodeDesignMaster_v50,
            b.f04cNamaProject_v50,
            a.f06cNamaBrand_v50, a.f04cNamaItemProduct_v50,
            a.f08cNamaMaterial_v50, a.f10cNamaKadar_v50, a.f12cNamaColor_v50,
            a.f20cNamaPlating_v50, a.f14cNamaSize_v50,
            a.f32cNamaWarnaEnamel_v500, a.f42dCreatedDate
        FROM t32PRODUCT AS a
        JOIN t30DESIGNMASTER AS b ON a.f02cKodeDesignMaster_v50 = b.k01cKodeDesignMaster_v50
        " & _cm031BuildFinalFilter(prmnTarget)

        Return ExecuteSQLForCatalogProduct(sql)
    End Function

    Private Function ExecuteSQLForCatalogProduct(sql As String) As DataTable
        With objGetDataReportGEMINI
            ._propTargetReportGEMINI = clsGetDataReportGEMINI.TargetDataReportGEMINI._infoCatalogProduct
        End With

        Return objGetDataReportGEMINI._info02GetDataDisplayProductCode(prop01cUser._UserProp07TargetNetwork, sql)
    End Function

    Private Function _cm05dvConvertToView(ByVal prmdtTable As DataTable, ByVal prmcNamaFilter As String) As DataView

        Dim dtTemp As New DataTable
        Dim dvView As DataView = prmdtTable.DefaultView 'New DataView(prmdtTable)

        Dim pcKolomData As String() = Nothing
        Select Case prmcNamaFilter
            Case "ITEMBRJ"
                pcKolomData = New String() {"f03cKodeItemProduct_v50", "f04cNamaItemProduct_v50"}
            Case "BRAND"
                pcKolomData = New String() {"f03cKodeItemProduct_v50", "f05cKodeBrand_v50", "f06cNamaBrand_v50"}
            Case "COLOR"
                pcKolomData = New String() {"f05cKodeBrand_v50", "f11cKodeColor_v50", "f12cNamaColor_v50"}
            Case "KADAR"
                pcKolomData = New String() {"f11cKodeColor_v50", "f09cKodeKadar_v50", "f10cNamaKadar_v50"}
            Case "COLLECTION"
                pcKolomData = New String() {"f09cKodeKadar_v50", "f03cKodeProject_v50", "f04cNamaProject_v50"}
        End Select

        dtTemp = dvView.ToTable(True, pcKolomData)

        Return New DataView(dtTemp)
    End Function

    Private Sub _cm06FilterDataViewMasterSKK(ByRef prmdvDataFilter As DataView,
                                             ByRef objSearchLookupedit As SearchLookUpEdit,
                                             ByVal prmcFieldYgDiFilter As String,
                                             ByVal prmcStringRowFilter As String)

        With prmdvDataFilter
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With prmdvDataFilter
            .Sort = prmcFieldYgDiFilter
            .RowFilter = prmcStringRowFilter
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        objSearchLookupedit.Properties.DataSource = Nothing
        objSearchLookupedit.Properties.DataSource = prmdvDataFilter
        objSearchLookupedit.Refresh()
    End Sub

    Private Sub _cm07DiplayProductCode(ByVal prmnTarget As Int16)
        Cursor = Cursors.WaitCursor

        Dim pdtDataProductCode As New DataTable
        Dim pdtGridTabelProductCode As New DataTable

        pdtDataProductCode = _cm04GetDataForDisplayProductCode(prmnTarget)
        pdtGridTabelProductCode = _cm04GetDataForGridTabelProductCode(prmnTarget)

        If pdtDataProductCode.Rows.Count > 0 AndAlso pdtGridTabelProductCode.Rows.Count > 0 Then
            GridControl1.DataSource = Nothing
            GridControl1.DataSource = pdtDataProductCode
            GridControl1.Refresh()

            GridControl2.DataSource = Nothing
            GridControl2.DataSource = pdtGridTabelProductCode
            GridControl2.Refresh()
        Else
            MsgBox("Maaf ... data tidak ditemukan ...", vbOKOnly + vbInformation, prop01cUser._UserProp01cTitle)
        End If


        Cursor = Cursors.Default
    End Sub

    Private Sub _cm08Clear()
        _cm01BersihkanEntrian()

        If plDataForFilterDone Then
            pdvItemBRJ.Table.Clear()
            pdvBrand.Table.Clear()
            pdvColour.Table.Clear()
            pdvKadar.Table.Clear()
            pdvCollection.Table.Clear()

            _03cItemBRJ.Properties.DataSource = Nothing
            _03cItemBRJ.Refresh()

            _04cBrand.Properties.DataSource = Nothing
            _04cBrand.Refresh()

            _05cColour.Properties.DataSource = Nothing
            _05cColour.Refresh()

            _06cKadar.Properties.DataSource = Nothing
            _06cKadar.Refresh()

            _08cCollection.Properties.DataSource = Nothing
            _08cCollection.Refresh()
        End If

        GridControl1.DataSource = Nothing
        GridControl1.Refresh()

        GridControl2.DataSource = Nothing
        GridControl2.Refresh()
    End Sub

    Private Function _cm09GetDataDetailCatalogMerchandise(ByVal prmcProductCode As String) As DataTable
        Dim pdtHasil As New DataTable

        Dim pcSQL As String = ""
        'pcSQL = " select 'Product Order' as cTitleMD,k05String as cNoProductOrder, " &
        '        " f24String As cNamaMTOMTS,f25String as cNamaSUBMTOMTS,f26String As cNamaCustomer," &
        '        " f01Int as nQtyOrder,f01Date As dTglInput,f02Date as dTglEstimasiDelivery " &
        '        " from SBU..TABLE50 " &
        '        " where k04String = '" & prmcProductCode & "' " &
        '        " and f15String = ''       --NoProductionOrder" &
        '        " UNION " &
        '        " select 'Production Order' as cTitleMD,k05String as cNoProductOrder , " &
        '        " f15String as cNamaMTOMTS,f17String as cNamaSUBMTOMTS,f19String as cNamaCustomer, " &
        '        " f02Int as nQtyOrder,f01Date As dTglInput,f02Date as dTglEstimasiDelivery " &
        '        " from SBU..TABLE50 " &
        '        " where k04String = '" & prmcProductCode & "' " &
        '        " order by k05String;"
        pcSQL = " select 'Product Order' as f01String,k05String as f02String, " &
                " f24String As f03String,f25String as f04String,f26String As f05String," &
                " f01Int, f01Date, f02Date " &
                " from SBU..TABLE50 " &
                " where k04String = '" & prmcProductCode & "' " &
                " and f15String = ''       --NoProductionOrder" &
                " UNION " &
                " select 'PRODUCTION ORDER' as f01String,k05String as f02String , " &
                " f15String as f03String,f17String as f04String,f19String as f05String, " &
                " f02Int as f01Int, f01Date, f02Date" &
                " from SBU..TABLE50 " &
                " where k04String = '" & prmcProductCode & "' " &
                " order by k05String;"

        objGetDataReportGEMINI._propTargetReportGEMINI = clsGetDataReportGEMINI.TargetDataReportGEMINI._infoCatalogProduct
        pdtHasil = objGetDataReportGEMINI._info03GetDataMerchandiseDetailCatalog(prop01cUser._UserProp07TargetNetwork, pcSQL)

        Return pdtHasil
    End Function

    Private Function _cm10GetDataDetailCatalogBOM(ByVal prmcProductCode As String) As DataTable
        Dim pdtHasil As New DataTable

        Dim pcSQL As String = ""
        pcSQL = " select 't25BOMCASTEDPARTS' as k01String, k02cKodeRubber_v50 as f01String,k03cKodeItemCastedParts_v50 as f02String,f01cItemCastedPartsDesc_v50 as f03String, " &
                "        f05cAssemblyDesc_v50 as f04String, f08cPlatingDesc_v50 as f05String, f10cKodeFinishing_v50 as f06String, " &
                " 	   f02nPcs_int as f01Int, f03nBerat_n92 as f01Double " &
                " from MRP..t25BOMCASTEDPARTS where k01cKodeFinishedGood_v50 = '" & prmcProductCode & "' " &
                " UNION " &
                " select 't26BOMFINDINGCOMPONENT' as k01String, k02cKodeItemFindingComponent_v50 as f01String,f01cItemFindingComponentDesc_v50 as f02String,SPACE(1) as f03String, " &
                "        SPACE(1) as f04String, SPACE(1) as f05String, SPACE(1) as f06String, " &
                "        f02nPcs_int as f01Int,f03nBerat_n92 as f01Double  " &
                " from MRP..t26BOMFINDINGCOMPONENT where k01cKodeFinishedGood_v50 = '" & prmcProductCode & "' " &
                " UNION " &
                " select 't27BOMSTONES' as k01String, k02cKodeStones_v50 as f01String,f01cStonesDesc_v50 as f02String,f04cBrandDesc_v50 as f03String, " &
                "        SPACE(1) as f04String, SPACE(1) as f05String, SPACE(1) as f06String, " &
                "        f05nButir_int as f01Int,f06nBeratGram_n93 as f01Double " &
                " from MRP..t27BOMSTONES where k01cKodeFinishedGood_v50 = '" & prmcProductCode & "'; "

        objGetDataReportGEMINI._propTargetReportGEMINI = clsGetDataReportGEMINI.TargetDataReportGEMINI._infoCatalogProduct
        pdtHasil = objGetDataReportGEMINI._info04GetDataBOMDetailCatalog(prop01cUser._UserProp07TargetNetwork, pcSQL)

        Return pdtHasil
    End Function

    Private Function _cm11GetDataDetailCatalogProduksi(ByVal prmcProductCode As String) As DataTable
        Dim pdtHasil As New DataTable

        Dim pcSQL As String = ""
        pcSQL = " Select b.k01cSKU_v50 as f01String, c.f01cNamaProsesProduksi_v50 as f02String, " &
                " b.f10nQtyLot_int as f01Int,b.f09nBeratMutasi_n92 as f01Double,b.f03dTglMutasi as f01Date " &
                " from NEWCENTRAL..t21CORERK As a " &
                " join NEWCENTRAL..t22POSTERRK As b " &
                " On a.k01cSKU_v50 = b.k01cSKU_v50 " &
                " join NEWCENTRAL..y52PROSESPRODUKSI As c " &
                " On c.k01cIDProsesProduksi_v50 = b.k03cIDProsesProduksi_v50 " &
                " where a.f02cKodeFinishGoods_v50 = '" & prmcProductCode & "' " &
                " order by b.k01cSKU_v50; "

        objGetDataReportGEMINI._propTargetReportGEMINI = clsGetDataReportGEMINI.TargetDataReportGEMINI._infoCatalogProduct
        pdtHasil = objGetDataReportGEMINI._info05GetDataProduksiDetailCatalog(prop01cUser._UserProp07TargetNetwork, pcSQL)

        Return pdtHasil
    End Function

#End Region

#Region "control - event"

    Private Sub onInfoDetailButtonClick(ByVal sender As Object, ByVal e As WinExplorerViewHtmlElementEventArgs)
        Cursor = Cursors.WaitCursor

        Dim objRec As DataRowView
        objRec = CType(e.DataItem, DataRowView)

        Dim pdtDataView As New DataView
        pdtDataView = objRec.DataView

        Dim pdtDetailCatalogMerchandise As New DataTable
        Dim pdtDetailCatalogBOM As New DataTable
        Dim pdtDetailCatalogProduksi As New DataTable

        Dim pcProductCode As String = objRec.Item("k01cKodeProduct_v50")

        pdtDetailCatalogMerchandise = _cm09GetDataDetailCatalogMerchandise(pcProductCode)
        pdtDetailCatalogBOM = _cm10GetDataDetailCatalogBOM(pcProductCode)
        pdtDetailCatalogProduksi = _cm11GetDataDetailCatalogProduksi(pcProductCode)

        Dim objImageByte As Byte() = CType(objRec.Item("objImageBRJ"), Byte())
        Dim ms As System.IO.Stream = New System.IO.MemoryStream(objImageByte)

        Dim myimage As Image
        myimage = Image.FromStream(ms)

        Cursor = Cursors.Default

        Dim objDetailCatalog As ucMD23GN01DETAILCATALOGPRODUCT = New ucMD23GN01DETAILCATALOGPRODUCT With {
                                                                .Dock = DockStyle.Fill,
                                                                ._prop01Picture = myimage,
                                                                ._prop02pdtDetailCatalogMerchandise = pdtDetailCatalogMerchandise,
                                                                ._prop03pdtDetailCatalogBOM = pdtDetailCatalogBOM,
                                                                ._prop04pdtDetailCatalogProduksi = pdtDetailCatalogProduksi}

        Dim frmDetailCatalog As New Form With {.Text = "Product Code : " & pcProductCode, .Height = 500, .Width = 1000, .StartPosition = FormStartPosition.CenterScreen}
        frmDetailCatalog.Controls.Add(objDetailCatalog)
        frmDetailCatalog.Show()
    End Sub

    Private Sub _otblProsesFilterTanggal_Click(sender As Object, e As EventArgs) Handles _otblProsesFilterTanggal.Click
        _cm03SetDataForFilter()
    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Display
                _cm07DiplayProductCode(1)

            Case 200  'Clear
                _cm08Clear()

        End Select
    End Sub

    Private Sub _03cItemBRJ_EditValueChanged(sender As Object, e As EventArgs) Handles _03cItemBRJ.EditValueChanged
        If plDataForFilterDone Then
            Dim pcKolomFilter As String = String.Format(" {0} = '{1}' ", "f03cKodeItemProduct_v50", _03cItemBRJ.EditValue)
            _cm06FilterDataViewMasterSKK(pdvBrand, _04cBrand, "f03cKodeItemProduct_v50", pcKolomFilter)
        End If
    End Sub

    Private Sub _04cBrand_EditValueChanged(sender As Object, e As EventArgs) Handles _04cBrand.EditValueChanged
        If plDataForFilterDone Then
            Dim pcKolomFilter As String = String.Format(" {0} = '{1}' ", "f05cKodeBrand_v50", _04cBrand.EditValue)
            _cm06FilterDataViewMasterSKK(pdvColour, _05cColour, "f05cKodeBrand_v50", pcKolomFilter)
        End If
    End Sub

    Private Sub _05cColour_EditValueChanged(sender As Object, e As EventArgs) Handles _05cColour.EditValueChanged
        If plDataForFilterDone Then
            Dim pcKolomFilter As String = String.Format(" {0} = '{1}' ", "f11cKodeColor_v50", _05cColour.EditValue)
            _cm06FilterDataViewMasterSKK(pdvKadar, _06cKadar, "f11cKodeColor_v50", pcKolomFilter)
        End If
    End Sub

    Private Sub _06cKadar_EditValueChanged(sender As Object, e As EventArgs) Handles _06cKadar.EditValueChanged
        If plDataForFilterDone Then
            Dim pcKolomFilter As String = String.Format(" {0} = '{1}' ", "f09cKodeKadar_v50", _06cKadar.EditValue)
            _cm06FilterDataViewMasterSKK(pdvCollection, _08cCollection, "f09cKodeKadar_v50", pcKolomFilter)
        End If
    End Sub


    Private Sub _07cMasterORProductCode_KeyDown(sender As Object, e As KeyEventArgs) Handles _07cMasterORProductCode.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            If Not String.IsNullOrEmpty(_07cMasterORProductCode.EditValue) Then
                If _07cMasterORProductCode.EditValue.ToString.Contains("-") Then
                    'Product Code
                    _cm07DiplayProductCode(2)
                Else
                    'Master Code
                    _cm07DiplayProductCode(3)
                End If
            End If
        End If
    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Cursor = Cursors.WaitCursor

        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("Maaf ... ada library yg harus terinstall, silahkan hub IT.", "Error")
            Return
        End If

        GridControl2.ShowPrintPreview()

        Cursor = Cursors.Default
    End Sub


#End Region

End Class
