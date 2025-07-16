Imports DevExpress.Office.PInvoke
Imports SKK02OBJECTS

Public Class ucMD23GN01DETAILCATALOGPRODUCT
    Implements IDisposable

    Public Property _prop01Picture As Image
    Public Property _prop02pdtDetailCatalogMerchandise As New DataTable
    Public Property _prop03pdtDetailCatalogBOM As New DataTable
    Public Property _prop04pdtDetailCatalogProduksi As New DataTable

#Region "event - form"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        _prop01Picture.Dispose()
        _prop02pdtDetailCatalogMerchandise.Dispose()
        _prop03pdtDetailCatalogBOM.Dispose()
        _prop04pdtDetailCatalogProduksi.Dispose()
    End Sub

    Private Sub ucMD23GN01DETAILCATALOGPRODUCT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _01Picture.Image = _prop01Picture
        _cm06DisplayAll()
    End Sub

#End Region

#Region "method - custom"

    Private Sub _cm01DisplayBOMCastedPart()

        If _prop03pdtDetailCatalogBOM.Rows.Count > 0 Then
            _oTab02BOM.Caption = "Bill of Materials (" & _prop03pdtDetailCatalogBOM.Rows.Count.ToString & ")"

            Dim pdtRow As DataRow()
            pdtRow = _prop03pdtDetailCatalogBOM.Select(" k01String = 't25BOMCASTEDPARTS'")

            If pdtRow.Count > 0 Then
                Dim pdtHasil As New DataTable
                pdtHasil = pdtRow.CopyToDataTable()

                Dim objGridCastedPart As ucGridDetailCatalog = New ucGridDetailCatalog With {._prop01TargetTransaksi = ucGridDetailCatalog.TargetInfoDetailCatalog._dcBOMCastedPart,
                                                                                             ._prop02pdtDataSourceGrid = pdtHasil}

                objGridCastedPart._pb01InitGrid()
                objGridCastedPart._pb03DisplayGridTransaction()

                _GroupBOM01CastedPart.Controls.Add(objGridCastedPart)
            End If
        Else
            _oTab02BOM.Caption = "Bill of Materials (0)"
        End If

    End Sub

    Private Sub _cm02DisplayBOMFCI()
        If _prop03pdtDetailCatalogBOM.Rows.Count > 0 Then
            Dim pdtRow As DataRow()
            pdtRow = _prop03pdtDetailCatalogBOM.Select(" k01String = 't26BOMFINDINGCOMPONENT'")

            If pdtRow.Count > 0 Then
                Dim pdtHasil As New DataTable
                pdtHasil = pdtRow.CopyToDataTable()

                Dim objGridFCI As ucGridDetailCatalog = New ucGridDetailCatalog With {._prop01TargetTransaksi = ucGridDetailCatalog.TargetInfoDetailCatalog._dcBOMFCI,
                                                                                      ._prop02pdtDataSourceGrid = pdtHasil}

                objGridFCI._pb01InitGrid()
                objGridFCI._pb03DisplayGridTransaction()

                _GroupBOM02FCI.Controls.Add(objGridFCI)
            End If
        End If
    End Sub

    Private Sub _cm03DisplayBOMStone()
        If _prop03pdtDetailCatalogBOM.Rows.Count > 0 Then
            Dim pdtRow As DataRow()
            pdtRow = _prop03pdtDetailCatalogBOM.Select(" k01String = 't27BOMSTONES'")

            If pdtRow.Count > 0 Then
                Dim pdtHasil As New DataTable
                pdtHasil = pdtRow.CopyToDataTable()

                Dim objGridStone As ucGridDetailCatalog = New ucGridDetailCatalog With {._prop01TargetTransaksi = ucGridDetailCatalog.TargetInfoDetailCatalog._dcBOMStone,
                                                                                      ._prop02pdtDataSourceGrid = pdtHasil}

                objGridStone._pb01InitGrid()
                objGridStone._pb03DisplayGridTransaction()

                _GroupBOM03Stone.Controls.Add(objGridStone)
            End If
        End If
    End Sub

    Private Sub _cm04DisplayMerchandise()

        If _prop02pdtDetailCatalogMerchandise.Rows.Count > 0 Then
            Dim objGridMerchandise As ucGridDetailCatalog = New ucGridDetailCatalog With {._prop01TargetTransaksi = ucGridDetailCatalog.TargetInfoDetailCatalog._dcMerchandise,
                                                                                          ._prop02pdtDataSourceGrid = _prop02pdtDetailCatalogMerchandise}

            objGridMerchandise._pb01InitGrid()
            objGridMerchandise._pb03DisplayGridTransaction()

            _GroupMerchandise.Controls.Add(objGridMerchandise)
            _GroupMerchandise.Text = ""

            _oTab03Merchandise.Caption = "Merchandise (" & _prop02pdtDetailCatalogMerchandise.Rows.Count.ToString & ")"
        Else
            _GroupMerchandise.Text = "Data di MERCHANDISE ... KOSONG."
            _oTab03Merchandise.Caption = "Merchandise (0)"
        End If

    End Sub

    Private Sub _cm05DisplayProduksi()

        If _prop04pdtDetailCatalogProduksi.Rows.Count > 0 Then
            Dim objGridProduksi As ucGridDetailCatalog = New ucGridDetailCatalog With {._prop01TargetTransaksi = ucGridDetailCatalog.TargetInfoDetailCatalog._dcProduksi,
                                                                                       ._prop02pdtDataSourceGrid = _prop04pdtDetailCatalogProduksi}

            objGridProduksi._pb01InitGrid()
            objGridProduksi._pb03DisplayGridTransaction()

            _GroupProduksi.Controls.Add(objGridProduksi)
            _GroupProduksi.Text = ""
            _oTab04Production.Caption = "Production (" & _prop04pdtDetailCatalogProduksi.Rows.Count.ToString & ")"
        Else
            _GroupProduksi.Text = "Data di PRODUKSI ... KOSONG."
            _oTab04Production.Caption = "Production (0)"
        End If

    End Sub

    Private Sub _cm06DisplayAll()
        Cursor = Cursors.WaitCursor

        _cm01DisplayBOMCastedPart()
        _cm02DisplayBOMFCI()
        _cm03DisplayBOMStone()
        _cm04DisplayMerchandise()
        _cm05DisplayProduksi()


        Cursor = Cursors.Default
    End Sub

#End Region

#Region "event - control"

#End Region

End Class
