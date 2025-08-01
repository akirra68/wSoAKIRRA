Public Class clsWSNasaSettingReportPivot
    Implements IDisposable

#Region "dispose"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

    Property _prop01cTargetPivotWSReport As TargetPivotWSReport
    Property _prop02Pivot As New ucWSPivot

    Public Enum TargetPivotWSReport
        'Inbound
        _wsInbound200All = 0
        _wsInbound201ByVendor = 201

        'General
        _wsGeneral300Stock = 300
        _wsGeneral301StockProductCode = 301

        'Transaksi Sale (Entrian : ucWS24IJ01SALE)
        _wsStockForSale = 70

        'Outbound
        _wsOutbound350Sale = 350

        'Transaksi Warehouse
        _wsTransaksiWS370Semua = 370
    End Enum

#Region "form and control - event"
    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
    End Sub
#End Region

#Region " custom - method "
    Public Sub __pbCallSettingReportPivot()
        Select Case _prop01cTargetPivotWSReport
            Case TargetPivotWSReport._wsInbound200All
                _pvSetting200InboundAll()

            Case TargetPivotWSReport._wsInbound201ByVendor
                _pvSetting201ByVendor()

            Case TargetPivotWSReport._wsGeneral300Stock
                _pvSetting300GeneralStock()

            Case TargetPivotWSReport._wsGeneral301StockProductCode
                _pvSetting301GeneralStockProdCode()

            Case TargetPivotWSReport._wsStockForSale
                _pvSetting70StockForSale()

            Case TargetPivotWSReport._wsOutbound350Sale
                _pvSetting350OutboundSale()

            Case TargetPivotWSReport._wsTransaksiWS370Semua
                _pvSetting370TransaksiWSSemua()
        End Select
    End Sub

    Private Sub _pvSetting200InboundAll()
        _cc01CaptionInboundAll()
        _vs01VisibilityInboundAll()
        _pa01PivotAreaInboundAll()
    End Sub

    Private Sub _pvSetting201ByVendor()

    End Sub

    Private Sub _pvSetting300GeneralStock()
        _cc01CaptionGeneralStock()
        _vs01VisibilityGeneralStock()
        _pa01PivotAreaGeneralStock()
    End Sub

    Private Sub _pvSetting301GeneralStockProdCode()
        _cc01CaptionGeneralStockProdCode()
        _vs01VisibilityGeneralStockProdCode()
        _pa01PivotAreaGeneralStockProdCode()
    End Sub

    Private Sub _pvSetting70StockForSale()
        _cc70PivotCaptionStockForSale()
        _vs70PivotVisibilityStockForSale()
        _pa70PivotAreaStockForSale()
    End Sub

    Private Sub _pvSetting350OutboundSale()
        _cc350pivotCaptionOutboundSale()
        _vs350pivotVisibilityOutboundSale()
        _pa350pivotAreaOutboundSale()
    End Sub

    Private Sub _pvSetting370TransaksiWSSemua()
        _cc01Caption370TransWSSemua()
        _vs01Visibility370TransWSSemua()
        _pa370pivotAreaTransWSSemua()
    End Sub

#End Region

#Region " ***** INBOUND : All *****"
    Private Sub _cc01CaptionInboundAll()
        With _prop02Pivot
            ._colk02String.Caption = "SKU"
            ._colf01String.Caption = "ProductCode"
            ._colf04String.Caption = "Vendor"
            ._colf06String.Caption = "NO/RO"
            ._colf08String.Caption = "Warna"
            ._colf10String.Caption = "Kadar"
            ._colf12String.Caption = "Item"
            ._colf14String.Caption = "Size"
            ._colf16String.Caption = "Brand"
            ._colf33String.Caption = "NoDocVendor"
            ._colf34String.Caption = "NoDocWarehouse"
            ._colf02String.Caption = "SKU-Asal"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "B.Nett"
            ._colf02Double.Caption = "B.Gross"
            ._colf01Date.Caption = "Inbound"
        End With
    End Sub

    Private Sub _vs01VisibilityInboundAll()
        With _prop02Pivot
            ._colk02String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"ProductCode"
            ._colf04String.Visible = True     '"Vendor"
            ._colf06String.Visible = True     '"NO/RO"
            ._colf08String.Visible = True     '"Warna"
            ._colf10String.Visible = True     '"Kadar"
            ._colf12String.Visible = True     '"Item"
            ._colf14String.Visible = True     '"Size"
            ._colf16String.Visible = True     '"Brand"
            ._colf33String.Visible = True     '"NoDocVendor"
            ._colf34String.Visible = True     '"NoDocWarehouse"
            ._colf02String.Visible = True     '"SKU-Asal"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True     '"B.Nett"
            ._colf02Double.Visible = True     '"B.Gross"
            ._colf01Date.Visible = True       '"Inbound"
        End With
    End Sub

    Private Sub _pa01PivotAreaInboundAll()
        With _prop02Pivot
            'Data
            ._colf01SmallInt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea   '"Pcs"
            ._colf01Double.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea     '"Nett"
            ._colf01SmallInt.AreaIndex = 0
            ._colf01Double.AreaIndex = 1

            'Row
            ._colf01Date.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea        '"Inbound"
            ._colf04String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      '"Vendor"
            ._colf16String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      '"Brand"
            ._colf01Date.AreaIndex = 0
            ._colf04String.AreaIndex = 1
            ._colf16String.AreaIndex = 2

            'Coloumn
            ._colf10String.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea   '"Kadar"
            ._colf10String.AreaIndex = 0
        End With

    End Sub

#End Region

#Region " ***** INBOUND : By Vendor *****"

#End Region

#Region " ***** GENERAL : Stock *****"
    Private Sub _cc01CaptionGeneralStock()
        With _prop02Pivot
            ._colk03String.Caption = "wsSKU"
            ._colf07String.Caption = "SLoc"
            ._colf01Int.Caption = "Umur"
            ._colf19String.Caption = "Status"
            ._colf17String.Caption = "SKU-Asal"
            ._colf01String.Caption = "ProductCode"
            ._colf26String.Caption = "NO/RO"
            ._colf28String.Caption = "Warna"
            ._colf10String.Caption = "Kadar"
            ._colf12String.Caption = "Item"
            ._colf14String.Caption = "Size"
            ._colf16String.Caption = "Brand"
            ._colf04String.Caption = "Vendor"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Berat"
            ._colf01Date.Caption = "Tgl.Inbound"
            ._colf02Date.Caption = "Tgl.Transaksi"
        End With
    End Sub

    Private Sub _vs01VisibilityGeneralStock()
        With _prop02Pivot
            ._colk03String.Visible = True     '"wsSKU"
            ._colf07String.Visible = True     '"SLoc"
            ._colf01Int.Visible = True     '"Umur"
            ._colf19String.Visible = True     '"Status"
            ._colf17String.Visible = True     '"SKU-Asal"
            ._colf01String.Visible = True     '"ProductCode"
            ._colf26String.Visible = True     '"NO/RO"
            ._colf28String.Visible = True     '"Warna"
            ._colf10String.Visible = True     '"Kadar"
            ._colf12String.Visible = True     '"Item"
            ._colf14String.Visible = True     '"Size"
            ._colf16String.Visible = True     '"Brand"
            ._colf04String.Visible = True     '"Vendor"
            ._colf01SmallInt.Visible = True     '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf01Date.Visible = True     '"Inbound"
            ._colf02Date.Visible = True     '"Transaksi"
        End With
    End Sub

    Private Sub _pa01PivotAreaGeneralStock()
        With _prop02Pivot
            'Data
            ._colf01SmallInt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea   '"Pcs"
            ._colf01Double.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea     '"Berat"
            ._colf01SmallInt.AreaIndex = 0
            ._colf01Double.AreaIndex = 1

            'Row
            ._colf07String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      '"SLoc"
            ._colf19String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      '"Status"
            ._colf07String.AreaIndex = 0
            ._colf19String.AreaIndex = 1

            'Coloumn
            ._colf10String.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea   '"Kadar"
            ._colf10String.AreaIndex = 0
        End With

    End Sub

#End Region

#Region " ***** GENERAL : Stock ProductCode *****"

    Private Sub _cc01CaptionGeneralStockProdCode()
        With _prop02Pivot
            ._colk02String.Caption = "Product Code"
            ._colf01String.Caption = "Box"
            ._colf03String.Caption = "Brand"
            ._colf05String.Caption = "Kadar"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Berat"
            ._colf01Int.Caption = "Umur"
            ._colf01Date.Caption = "Inbound"
        End With
    End Sub

    Private Sub _vs01VisibilityGeneralStockProdCode()
        With _prop02Pivot
            ._colk02String.Visible = True     '"Product Code"
            ._colf01String.Visible = True     '"Box"
            ._colf03String.Visible = True     '"Brand"
            ._colf05String.Visible = True     '"Kadar"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf01Int.Visible = True        '"Umur"
            ._colf01Date.Visible = True       '"Inbound"
        End With
    End Sub

    Private Sub _pa01PivotAreaGeneralStockProdCode()
        With _prop02Pivot
            'Data
            ._colf01SmallInt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea   '"Pcs"
            ._colf01Double.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea     '"Berat"
            ._colf01SmallInt.AreaIndex = 0
            ._colf01Double.AreaIndex = 1

            'Row
            ._colk02String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      'ProdCode
            ._colf01String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      'Box
            ._colk02String.AreaIndex = 0
            ._colf01String.AreaIndex = 1

            'Coloumn
            ._colf05String.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea   '"Kadar"
            ._colf05String.AreaIndex = 0
        End With

    End Sub

#End Region

#Region " ***** SALE : STOCK *****"

    Private Sub _cc70PivotCaptionStockForSale()
        With _prop02Pivot
            ._colf01Date.Caption = "Tgl"
            ._colf01String.Caption = "ProductCode"
            ._colk03String.Caption = "SKU"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Berat"
            ._colf10String.Caption = "Kadar"
            ._colf16String.Caption = "Brand"
            ._colf12String.Caption = "Item"
            ._colf23String.Caption = "Warna"
            ._colf14String.Caption = "Size"
        End With
    End Sub

    Private Sub _vs70PivotVisibilityStockForSale()
        With _prop02Pivot
            ._colf01Date.Visible = True         '"Tgl"
            ._colf01String.Visible = True         '"ProductCode"
            ._colk03String.Visible = True         '"SKU"
            ._colf01SmallInt.Visible = True         '"Pcs"
            ._colf01Double.Visible = True         '"Berat"
            ._colf10String.Visible = True         '"Kadar"
            ._colf16String.Visible = True         '"Brand"
            ._colf12String.Visible = True         '"Item"
            ._colf23String.Visible = True         '"Warna"
            ._colf14String.Visible = True         '"Size"
        End With
    End Sub

    Private Sub _pa70PivotAreaStockForSale()
        With _prop02Pivot
            'Data
            ._colf01SmallInt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea   '"Pcs"
            ._colf01Double.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea     '"Berat"
            ._colf01SmallInt.AreaIndex = 0
            ._colf01Double.AreaIndex = 1

            'Row
            ._colf12String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      'Item
            ._colf16String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      'Brand
            ._colf12String.AreaIndex = 0
            ._colf16String.AreaIndex = 1

            'Coloumn
            ._colf10String.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea   '"Kadar"
            ._colf10String.AreaIndex = 0
        End With

    End Sub

#End Region

#Region " ***** outbound : sale *****"

    Private Sub _cc350pivotCaptionOutboundSale()
        With _prop02Pivot
            ._colk02String.Caption = "Doc.Sell"
            ._colk03String.Caption = "SKU"
            ._colf01String.Caption = "Doc.SJ"
            ._colf02String.Caption = "Doc.Order"
            ._colf04String.Caption = "KAE"
            ._colf06String.Caption = "Customer"
            ._colf08String.Caption = "TOP"
            ._colf09String.Caption = "Sell"
            ._colf11String.Caption = "Brand"
            ._colf13String.Caption = "Kadar"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Berat"
            ._colf02Date.Caption = "Sold"
        End With
    End Sub

    Private Sub _vs350pivotVisibilityOutboundSale()
        With _prop02Pivot
            ._colk02String.Visible = True     '"Doc.Sell"
            ._colk03String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"Doc.SJ"
            ._colf02String.Visible = True     '"Doc.PKB"
            ._colf04String.Visible = True     '"KAE"
            ._colf06String.Visible = True     '"Customer"
            ._colf08String.Visible = True     '"TOP"
            ._colf09String.Visible = True     '"Sell"
            ._colf11String.Visible = True     '"Brand"
            ._colf13String.Visible = True     '"Kadar"
            ._colf01SmallInt.Visible = True     '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf02Date.Visible = True     '"Sold"
        End With
    End Sub

    Private Sub _pa350pivotAreaOutboundSale()
        With _prop02Pivot
            'Data
            ._colf01SmallInt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea   '"Pcs"
            ._colf01Double.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea     '"Berat"
            ._colf01SmallInt.AreaIndex = 0
            ._colf01Double.AreaIndex = 1

            'Row
            ._colf02Date.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea        'date
            ._colf11String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      'brand
            ._colf06String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      'customer
            ._colf02Date.AreaIndex = 0
            ._colf11String.AreaIndex = 1
            ._colf06String.AreaIndex = 2

            'Coloumn
            ._colf09String.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea   '"Sell"
            ._colf13String.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea   '"Kadar"
            ._colf09String.AreaIndex = 0
            ._colf13String.AreaIndex = 1
        End With
    End Sub

#End Region

#Region " ***** transaksi warehouse : semua *****"

    Private Sub _cc01Caption370TransWSSemua()
        With _prop02Pivot
            ._colk03String.Caption = "SKU"
            ._colf01String.Caption = "No.Doc"
            ._colf02String.Caption = "Target"
            ._colf03String.Caption = "ProductCode"
            ._colf06String.Caption = "Kepada"
            ._colf12String.Caption = "Box"
            ._colf14String.Caption = "Brand"
            ._colf16String.Caption = "Kadar"
            ._colf20String.Caption = "Note"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Berat"
            ._colf02Date.Caption = "Tanggal"
        End With
    End Sub

    Private Sub _vs01Visibility370TransWSSemua()
        With _prop02Pivot
            ._colk03String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"No.Doc"
            ._colf02String.Visible = True     '"Target"
            ._colf03String.Visible = True     '"ProductCode"
            ._colf06String.Visible = True     '"Kepada"
            ._colf12String.Visible = True     '"Box"
            ._colf14String.Visible = True     '"Brand"
            ._colf16String.Visible = True     '"Kadar"
            ._colf20String.Visible = True     '"Note"
            ._colf01SmallInt.Visible = True     '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf02Date.Visible = True     '"Tanggal"
        End With

    End Sub

    Private Sub _pa370pivotAreaTransWSSemua()
        With _prop02Pivot
            'Data
            ._colf01SmallInt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea   '"Pcs"
            ._colf01Double.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea     '"Berat"
            ._colf01SmallInt.AreaIndex = 0
            ._colf01Double.AreaIndex = 1

            'Row
            ._colf02Date.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea        'date
            ._colf16String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      'kadar
            ._colf02Date.AreaIndex = 0
            ._colf16String.AreaIndex = 1

            'Coloumn
            ._colf02String.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea   '"Target"
            ._colf02String.AreaIndex = 0
        End With
    End Sub
#End Region

End Class
