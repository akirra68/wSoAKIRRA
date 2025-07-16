Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DevExpress.Utils.Internal
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Data.SqlClient
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucMD23JP01TRACKINGPO
    Implements IDisposable

    Public Property _prop01User As clsUserGEMINI

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ucMD23JP01TRACKINGPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        Bar1.Visible = True
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 10

        _cm00ClearControl()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm00ClearControl()
        mnuBarDateKe.EditValue = Date.Today
        mnuBarDateDari.EditValue = DateAdd(DateInterval.Day, -10, mnuBarDateKe.EditValue)

        _gdTrackingPO.__pbWSGridParentChild02Clear()
        _gdTrackingPO.__pbWSGridParentChild01InitGrid()
    End Sub

    Private Sub _cm01DisplayTrackingPO()
        With _gdTrackingPO
            ._prop01objUser = _prop01User
            ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._MDTrackingPO
            ._prop01Date = mnuBarDateDari.EditValue
            ._prop02Date = mnuBarDateKe.EditValue

            .__pbWSGridParentChild01InitGrid()
            .__pbWSGridParentChild02Clear()
            .__pbWSGridParentChild03Display()
        End With
    End Sub


    '========== NOT USED ==========
    'Private Sub _cm01InitFieldGridPO()
    '    GridView1.IndicatorWidth = 50
    '    GridView2.IndicatorWidth = 50
    '    GridView3.IndicatorWidth = 50
    '    GridView4.IndicatorWidth = 50

    '    _colPO01f01Date.FieldName = "f01Date"      'Tanggal
    '    _colPO02f21String.FieldName = "f21String"  'No. PO
    '    _colPO03k04String.FieldName = "k04String"  'Product Code
    '    _colPO16f02Date.FieldName = "f02Date"      'Tanggal
    '    _colPO04k05String.FieldName = "k05String"  'Product Order
    '    _colPO05f02String.FieldName = "f02String"  'Brand
    '    _colPO06f04String.FieldName = "f04String"  'TipeBRJ
    '    _colPO07f06String.FieldName = "f06String"  'Warna
    '    _colPO08f08String.FieldName = "f08String"  'Kadar
    '    _colPO09f10String.FieldName = "f10String"  'Size
    '    _colPO10f12String.FieldName = "f12String"  'Project
    '    _colPO11f26String.FieldName = "f26String"  'Customer
    '    _colPO12f24String.FieldName = "f24String"  'TipeProduksi
    '    _colPO13f25String.FieldName = "f25String"  'SubTipeProduksi
    '    _colPO14f01Int.FieldName = "f01Int"        'Qty
    '    _colPO15f02Double.FieldName = "f02Double"  'Est To.Berat
    'End Sub

    'Private Sub _cm02InitFieldGridTrackingMD()
    '    'Mutasi
    '    _colk01cSKU_v50.FieldName = "k01cSKU_v50"
    '    _colTrackerf01cNamaProsesProduksi_v50.FieldName = "f01cNamaProsesProduksi_v50"
    '    _colTrackerf05dTglApproved.FieldName = "f05dTglApproved"
    '    _colTrackerf10nQtyLot_int.FieldName = "f10nQtyLot_int"
    '    _colTrackerf09nBeratMutasi_n92.FieldName = "f09nBeratMutasi_n92"

    '    _colk01cSKU_v50.BestFit()
    '    _colTrackerf01cNamaProsesProduksi_v50.BestFit()
    '    _colTrackerf05dTglApproved.BestFit()
    '    _colTrackerf10nQtyLot_int.BestFit()
    '    _colTrackerf09nBeratMutasi_n92.BestFit()

    '    '_colTrackerMD5201f21String.FieldName = "f21String"  'No. PO
    '    '_colTrackerMD5202f02Date.FieldName = "f02Date"      'Tanggal
    '    '_colTrackerMD5203k04String.FieldName = "k04String"  'ProductCode
    '    '_colTrackerMD5204f29String.FieldName = "f29String"  'NoDokumen
    '    '_colTrackerMD5205f30String.FieldName = "f30String"  'Status MD
    '    '_colTrackerMD5206f01Memo.FieldName = "f01Memo"      'Note

    '    '_colTrackerMD5201f21String.BestFit()
    '    '_colTrackerMD5202f02Date.BestFit()
    '    '_colTrackerMD5203k04String.BestFit()
    '    '_colTrackerMD5204f29String.BestFit()
    '    '_colTrackerMD5205f30String.BestFit()
    '    '_colTrackerMD5206f01Memo.BestFit()
    'End Sub

    'Private Sub _cm03InitFieldGridTrackingProduction()
    '    'SKU
    '    _colTrackerPROD01k01cNoPRO_v50.FieldName = "    "    'SKU
    '    _colTrackerPROD02f21String.FieldName = "f21String"            'No. PO
    '    _colTrackerPROD03k04String.FieldName = "k04String"            'ProductCode

    '    _colTrackerPROD01k01cNoPRO_v50.BestFit()
    '    _colTrackerPROD02f21String.BestFit()
    '    _colTrackerPROD03k04String.BestFit()


    'End Sub

    'Private Sub _cm04ProsesDisplayTrackingPO()
    '    Dim _dst As New DataSet
    '    _dst.Clear()
    '    _dst.Relations.Clear()

    '    Dim _sqldataadapter As SqlDataAdapter

    '    Const consFieldnTarget As String = "@tpParamSQLSelect"
    '    Const consNamaSP As String = "spMDTransaksi"

    '    Dim objParamParent As clsNasaSelectParamDataCollection
    '    objParamParent = New clsNasaSelectParamDataCollection

    '    Dim objParamChildMD As clsNasaSelectParamDataCollection
    '    objParamChildMD = New clsNasaSelectParamDataCollection

    '    Dim objParamChildPRODSKU As clsNasaSelectParamDataCollection
    '    objParamChildPRODSKU = New clsNasaSelectParamDataCollection

    '    Dim objParamChildPRODMUTASI As clsNasaSelectParamDataCollection
    '    objParamChildPRODMUTASI = New clsNasaSelectParamDataCollection

    '    Dim objConnSBU As New clsNasaDatabaseConnection

    '    Using objConn As New SqlConnection(objConnSBU._cm03NasaConnectionDBSBU(_prop01User._UserProp07TargetNetwork))

    '        objConn.Open()

    '        objParamParent._01AddNew(7, 0, 0, "", "", "", 0, 0, mnuBarDateDari.EditValue, mnuBarDateKe.EditValue)
    '        Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
    '            objCommand.Parameters.AddWithValue(consFieldnTarget, objParamParent).SqlDbType = SqlDbType.Structured

    '            _sqldataadapter = New SqlDataAdapter(objCommand)
    '            _sqldataadapter.Fill(_dst, "ParentTable")
    '        End Using

    '        objParamChildMD._01AddNew(4, 0, 0, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
    '        Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
    '            objCommand.Parameters.AddWithValue(consFieldnTarget, objParamChildMD).SqlDbType = SqlDbType.Structured

    '            _sqldataadapter = New SqlDataAdapter(objCommand)
    '            _sqldataadapter.Fill(_dst, "ChildTable")
    '        End Using

    '        objParamChildPRODSKU._01AddNew(5, 0, 0, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
    '        Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
    '            objCommand.Parameters.AddWithValue(consFieldnTarget, objParamChildPRODSKU).SqlDbType = SqlDbType.Structured

    '            _sqldataadapter = New SqlDataAdapter(objCommand)
    '            _sqldataadapter.Fill(_dst, "ChildProdSKU")
    '        End Using

    '        objParamChildPRODMUTASI._01AddNew(8, 0, 0, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
    '        Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
    '            objCommand.Parameters.AddWithValue(consFieldnTarget, objParamChildPRODMUTASI).SqlDbType = SqlDbType.Structured

    '            _sqldataadapter = New SqlDataAdapter(objCommand)
    '            _sqldataadapter.Fill(_dst, "ChildProdMUTASI")
    '        End Using

    '        Dim _pcNamaRelasiMerchandise As String = "Merchandise"
    '        Dim _pcNamaRelasiProduksiSKU As String = "Produksi - SKU"
    '        Dim _pcNamaRelasiProduksiMutasi As String = "Produksi - PROSES"

    '        Dim objDataRelationMD As DataRelation = New DataRelation(_pcNamaRelasiMerchandise,
    '                                                               New DataColumn() {_dst.Tables("ParentTable").Columns("f21String")},
    '                                                               New DataColumn() {_dst.Tables("ChildTable").Columns("f21String")}, False)

    '        Dim objDataRelationPRODSKU As DataRelation = New DataRelation(_pcNamaRelasiProduksiSKU,
    '                                                               New DataColumn() {_dst.Tables("ChildTable").Columns("f21String")},
    '                                                               New DataColumn() {_dst.Tables("ChildProdSKU").Columns("PO")}, False)

    '        Dim objDataRelationPRODMUTASI As DataRelation = New DataRelation(_pcNamaRelasiProduksiMutasi,
    '                                                               New DataColumn() {_dst.Tables("ParentTable").Columns("k04String")},
    '                                                               New DataColumn() {_dst.Tables("ChildProdMUTASI").Columns("k04String")}, False)

    '        _dst.Relations.AddRange(New DataRelation() {objDataRelationPRODMUTASI})
    '        ' _dst.Relations.AddRange(New DataRelation() {objDataRelationMD, objDataRelationPRODSKU, objDataRelationPRODMUTASI})

    '        'Dim nodeMerchandise As GridLevelNode = New GridLevelNode() With {.LevelTemplate = GridView2,
    '        '                                                                 .RelationName = _pcNamaRelasiMerchandise}

    '        'Dim nodeProdSKU As GridLevelNode = New GridLevelNode() With {.LevelTemplate = GridView3,
    '        '                                                             .RelationName = _pcNamaRelasiProduksiSKU}

    '        Dim nodeProdMutasi As GridLevelNode = New GridLevelNode() With {.LevelTemplate = GridView2,
    '                                                                        .RelationName = _pcNamaRelasiProduksiMutasi}

    '        GridControl1.DataSource = Nothing
    '        GridControl1.DataSource = _dst.Tables("ParentTable")

    '        With GridControl1.LevelTree.Nodes
    '            .AddRange(New GridLevelNode() {nodeProdMutasi})
    '            'nodeMerchandise, nodeProdSKU, '  })

    '        End With

    '        GridView1.OptionsView.ColumnAutoWidth = False
    '        GridView1.BestFitColumns(True)

    '        GridView2.OptionsView.ColumnAutoWidth = False
    '        GridView2.BestFitColumns(True)

    '        GridView3.OptionsView.ColumnAutoWidth = False
    '        GridView3.BestFitColumns(True)

    '        GridView4.OptionsView.ColumnAutoWidth = False
    '        GridView4.BestFitColumns(True)

    '        objConn.Close()
    '    End Using

    '    objParamParent.Dispose()
    '    objParamChildMD.Dispose()
    '    objParamChildPRODSKU.Dispose()
    '    objParamChildPRODMUTASI.Dispose()
    'End Sub

    'Private Sub _cm05DisplayTrackingPO()
    '    Cursor = Cursors.WaitCursor

    '    _cm04ProsesDisplayTrackingPO()

    '    Cursor = Cursors.WaitCursor
    'End Sub

    'Private Sub _cm06ClearTrackingPO()
    '    GridControl1.DataSource = Nothing
    '    GridControl1.Refresh()
    'End Sub

#End Region

#Region "control - event"

    Private Sub mnuBarDisplay_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBarDisplay.ItemClick
        _cm01DisplayTrackingPO()
    End Sub
    Private Sub mnuBarBtnClear_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBarBtnClear.ItemClick
        _cm00ClearControl()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        _gdTrackingPO.__pbWSGridParentChild04CreateSettingColumnWidth("trackingPO")

    End Sub

#End Region

End Class
