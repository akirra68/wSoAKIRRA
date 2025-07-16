Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DevExpress.XtraGrid.Views.Grid

Public Class clsWSNasaSettingReportGrid
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

    Property _prop01cTargetGridWSReport As TargetGridWSReport
    Property _prop02Grid As New ucWSGrid
    Property _prop03GridParentChild As New ucWSGridParentChild
    Public Enum TargetGridWSReport
        'Inbound
        _wsInbound200All = 0
        _wsInbound201ByVendor = 201

        'General
        _wsGeneral300Stock = 300
        _wsGeneral301StockProductCode = 301
        _wsCurrentStockSku = 302

        'Outbound
        _wsOutbound350Sale = 350

        'Transaksi Warehouse
        _wsTransaksiWS370Semua = 370

        'STORE ---> rptWS25DX01Store
        _wsStore = 52

        'STORE ---> rptWS25EF01AgregatSJ
        _wsAgergatSJ = 352720

    End Enum

#Region "form and control - event"
    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
    End Sub
#End Region

#Region " custom - method "

    Public Sub __pbCallSettingReportGrid()
        Select Case _prop01cTargetGridWSReport
            Case TargetGridWSReport._wsInbound200All
                _pvSetting200InboundAll()

            Case TargetGridWSReport._wsInbound201ByVendor
            Case TargetGridWSReport._wsGeneral300Stock
                _pvSetting300GeneralStock()

            Case TargetGridWSReport._wsGeneral301StockProductCode
                _pvSetting301GeneralStockProdCode()

            Case TargetGridWSReport._wsCurrentStockSku
                _gdSettingCurrentStock()

            Case TargetGridWSReport._wsOutbound350Sale
                _pvSetting350OutboundSale()

            Case TargetGridWSReport._wsTransaksiWS370Semua
                _pvSetting370TransaksiWSSemua()

            Case TargetGridWSReport._wsStore
                _pvSetting07RptStore()

            Case TargetGridWSReport._wsAgergatSJ
                _pvSetting352720RptAgregatSJ()
        End Select
    End Sub

    Private Sub _pvSetting200InboundAll()
        _cc01CaptionInboundAll()
        _vs01VisibilityInboundAll()
        _vs02VisibilityIndexInboundAll()
        _tot01TotalanInboundAll()
        _ll01LainLainInboundAll()
    End Sub

    Private Sub _pvSetting300GeneralStock()
        _cc01CaptionGeneralStock()
        _vs01VisibilityGeneralStock()
        _vs02VisibilityIndexGeneralStock()
        _tot01TotalanGeneralStock()
        _ll01LainLainGeneralStock()
    End Sub

    Private Sub _gdSettingCurrentStock()
        _cc01CaptionCurrentStockSku()
        _vs01VisibilityCurrentStockSku()
        _vs02VisibilityIndexCurrentStockSku()
        _tot01TotalSummaryFooterCurrentStockSku()
        _ll01LainLainCurrentStockSku()
    End Sub

    Private Sub _pvSetting301GeneralStockProdCode()
        _cc01CaptionGeneralStockProdCode()
        _vs01VisibilityGeneralStockProdCode()
        _vs02VisibilityIndexGeneralStockProdCode()
        _tot01TotalanGeneralStockProdCode()
        _ll01LainLainGeneralStockProdCode()
    End Sub

    Private Sub _pvSetting350OutboundSale()
        _cc01Caption350OutboundSale()
        _vs01Visibility350OutboundSale()
        _vs02VisibilityIndex350OutboundSale()
        _tot01Totalan350OutboundSale()
        _ll01LainLain350OutboundSale()
    End Sub

    Private Sub _pvSetting370TransaksiWSSemua()
        _cc01Caption370TransWSSemua()
        _vs01Visibility370TransWSSemua()
        _vs02VisibilityIndex370TransWSSemua()
        _tot01Totalan370TransWSSemua()
        _ll01LainLain370TransWSSemua()
    End Sub

    Private Sub _pvSetting07RptStore()
        _cc01CaptionRptStore()
        _vs01VisibilityRptStore()
        _vs02VisibilityIndexRptStore()
        _ll01LainLainStore()
        _wd240707WidthStore()
    End Sub

    Private Sub _pvSetting352720RptAgregatSJ()
        _cc01CaptionRptAgregatSJ()
        _vs01VisibilityRptAgregatSJ()
        _vs02VisibilityIndexRptAgregatSJ()
        _ll01LainLainAgregatSJ()
        _wd240707WidthAgergatSJ()
    End Sub
#End Region

#Region " ***** INBOUND : All *****"
    Private Sub _cc01CaptionInboundAll()
        With _prop02Grid
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
            ._colf02String.Caption = "SPK"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "B.Gross"
            ._colf02Double.Caption = "B.Nett"
            ._colf01Date.Caption = "Inbound Citrix"
            ._colf02Date.Caption = "Inbound Mersy"
        End With
    End Sub

    Private Sub _vs01VisibilityInboundAll()
        With _prop02Grid
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
            ._colf02Date.Visible = True       '"Inbound"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexInboundAll()
        With _prop02Grid
            ._colf02Date.VisibleIndex = 0       '"Inbound"
            ._colf01Date.VisibleIndex = 1       '"Inbound"
            ._colf04String.VisibleIndex = 2     '"Vendor"
            ._colk02String.VisibleIndex = 3     '"SKU"
            ._colf01SmallInt.VisibleIndex = 4   '"Pcs"
            ._colf02Double.VisibleIndex = 5     '"B.Nett"
            ._colf01Double.VisibleIndex = 6     '"B.Gross"
            ._colf16String.VisibleIndex = 7     '"Brand"
            ._colf10String.VisibleIndex = 8     '"Kadar"
            ._colf12String.VisibleIndex = 9     '"Item"
            ._colf08String.VisibleIndex = 10     '"Warna"
            ._colf14String.VisibleIndex = 11     '"Size"
            ._colf06String.VisibleIndex = 12     '"NO/RO"
            ._colf01String.VisibleIndex = 13     '"ProductCode"
            ._colf33String.VisibleIndex = 14     '"NoDocVendor"
            ._colf34String.VisibleIndex = 15     '"NoDocWarehouse"
            ._colf02String.VisibleIndex = 16     '"SKU-Asal"
        End With
    End Sub

    Private Sub _tot01TotalanInboundAll()
        With _prop02Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

            .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f02Double").SummaryItem.FieldName = "f02Double"
            .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainInboundAll()
        With _prop02Grid
            With ._colf01SmallInt     '
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01Double    '
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With

            With ._colf02Double    '
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With

            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With
        End With
    End Sub

#End Region

#Region " ***** INBOUND : By Vendor *****"

#End Region

#Region " ***** GENERAL : Stock SKU *****"

    Private Sub _cc01CaptionGeneralStock()
        With _prop02Grid
            ._colk03String.Caption = "SKU"
            ._colf07String.Caption = "Location"
            ._colf01Int.Caption = "Umur"
            ._colf19String.Caption = "Stock"
            ._colf22String.Caption = "Status"
            ._colf17String.Caption = "SKU-Asal"
            ._colf30String.Caption = "SKU-Root"
            ._colf01String.Caption = "ProductCode"
            ._colf26String.Caption = "No.RO"
            ._colf28String.Caption = "Warna"
            ._colf10String.Caption = "Kadar"
            ._colf12String.Caption = "Item"
            ._colf14String.Caption = "Size"
            ._colf16String.Caption = "Brand"
            ._colf04String.Caption = "Vendor"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf01Date.Caption = "Tgl.Inbound"
            ._colf02Date.Caption = "LastUpdated"
        End With
    End Sub

    Private Sub _vs01VisibilityGeneralStock()
        With _prop02Grid
            ._colk03String.Visible = True     '"wsSKU"
            ._colf07String.Visible = True     '"SLoc"
            ._colf01Int.Visible = True     '"Umur"
            ._colf19String.Visible = True     '"Stock"
            ._colf22String.Visible = True     '"Status"
            ._colf17String.Visible = True     '"SKU-Asal"
            ._colf30String.Visible = True     '"SKU-Asal"
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

    Private Sub _vs02VisibilityIndexGeneralStock()
        With _prop02Grid
            ._colf02Date.VisibleIndex = 0       '"Transaksi"
            ._colk03String.VisibleIndex = 1     '"wsSKU"
            ._colf01String.VisibleIndex = 2    '"ProductCode"
            ._colf19String.VisibleIndex = 3     '"Stock"
            ._colf07String.VisibleIndex = 4     '"SLoc"
            ._colf10String.VisibleIndex = 5     '"Kadar"
            ._colf16String.VisibleIndex = 6     '"Brand"
            ._colf12String.VisibleIndex = 7     '"Item"
            ._colf01SmallInt.VisibleIndex = 8   '"Pcs"
            ._colf01Double.VisibleIndex = 9     '"Berat"
            ._colf28String.VisibleIndex = 10    '"Warna"
            ._colf14String.VisibleIndex = 11     '"Size"
            ._colf22String.VisibleIndex = 12     '"Status"
            ._colf26String.VisibleIndex = 13    '"NO/RO"
            ._colf04String.VisibleIndex = 14    '"Vendor"
            ._colf17String.VisibleIndex = 15    '"SKU-Asal"
            ._colf30String.VisibleIndex = 16    '"SKU-Asal"
            ._colf01Date.VisibleIndex = 17      '"Inbound"
            ._colf01Int.VisibleIndex = 18       '"Umur"
        End With
    End Sub

    Private Sub _tot01TotalanGeneralStock()
        With _prop02Grid.GridView1
            .OptionsView.ShowFooter = True
            .Columns("f02Date").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("f02Date").SummaryItem.DisplayFormat = "{0:n0} Rows"

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainGeneralStock()
        With _prop02Grid
            With ._colf01Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With
            With ._colf02Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With
            With ._colf01SmallInt
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With

            With ._colk03String
                .AppearanceHeader.BackColor = Color.DeepPink
                .AppearanceCell.BackColor = Color.LightPink
            End With

            With ._colf01String
                .AppearanceHeader.BackColor = Color.Yellow
                .AppearanceCell.BackColor = Color.LightYellow
            End With

            With ._colf19String
                .AppearanceHeader.BackColor = Color.Green
                .AppearanceCell.BackColor = Color.LightGreen
            End With

            With ._colf07String
                .AppearanceHeader.BackColor = Color.DarkBlue
                .AppearanceCell.BackColor = Color.LightBlue
            End With

            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With

        End With
    End Sub

#End Region

#Region " ***** GENERAL : Stock ProductCode *****"

    Private Sub _cc01CaptionGeneralStockProdCode()
        With _prop02Grid
            ._colk02String.Caption = "ProductCode"
            ._colf01String.Caption = "Box"
            ._colf03String.Caption = "Brand"
            ._colf05String.Caption = "Kadar"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Berat"
            ._colf01Int.Caption = "Umur (hari)"
            ._colf01Date.Caption = "Tgl.Inbound"
            ._colf02Date.Caption = "LastUpdated"
        End With
    End Sub

    Private Sub _vs01VisibilityGeneralStockProdCode()
        With _prop02Grid
            ._colk02String.Visible = True     '"Product Code"
            ._colf01String.Visible = True     '"Box"
            ._colf03String.Visible = True     '"Brand"
            ._colf05String.Visible = True     '"Kadar"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf01Int.Visible = True        '"Umur"
            ._colf01Date.Visible = True       '"Inbound"
            ._colf02Date.Visible = True       '"Mutasi"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexGeneralStockProdCode()
        With _prop02Grid
            ._colf02Date.VisibleIndex = 0       '"Mutasi"
            ._colk02String.VisibleIndex = 1     '"Product Code"
            ._colf01String.VisibleIndex = 2     '"Box"
            ._colf03String.VisibleIndex = 4     '"Brand"
            ._colf05String.VisibleIndex = 3     '"Kadar"
            ._colf01SmallInt.VisibleIndex = 5  '"Pcs"
            ._colf01Double.VisibleIndex = 6     '"Berat"
            ._colf01Int.VisibleIndex = 7        '"Umur"
            ._colf01Date.VisibleIndex = 8       '"Inbound"
        End With
    End Sub

    Private Sub _tot01TotalanGeneralStockProdCode()
        With _prop02Grid.GridView1
            .OptionsView.ShowFooter = True
            .Columns("f02Date").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("f02Date").SummaryItem.DisplayFormat = "{0:n0} Rows"

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainGeneralStockProdCode()
        With _prop02Grid
            With ._colf01Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With
            With ._colf02Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With

            With .GridView1
                With .Columns("k02String")
                    .AppearanceHeader.BackColor = Color.DeepPink
                    .AppearanceCell.BackColor = Color.LightPink
                End With
                With .Columns("f01String")
                    .AppearanceHeader.BackColor = Color.Yellow
                    .AppearanceCell.BackColor = Color.LightYellow
                End With
            End With


            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With
        End With
    End Sub

#End Region


#Region " ***** GENERAL : Stock SKU *****"

    Private Sub _cc01CaptionCurrentStockSku()
        With _prop03GridParentChild
            ._colk00Boolean.Caption = "#"
            ._colf01Datetime.Caption = "LastUpdate"
            ._colk03String.Caption = "SKU"
            ._colf21String.Caption = "ProductCode"
            ._colf18String.Caption = "Stock"
            ._colf07String.Caption = "CurrentLoc"
            ._colf05String.Caption = "PreviousLoc"
            ._colf25String.Caption = "Brand"
            ._colf27String.Caption = "Kadar"
            ._colf02Int.Caption = "KadarNum"
            ._colf12String.Caption = "Type"
            ._colf08String.Caption = "Colour"
            ._colf14String.Caption = "Size"
            ._colf40String.Caption = "Collection"
            ._colf06String.Caption = "RO"
            ._colf22String.Caption = "Status"
            ._colf09String.Caption = "Box"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Gram"
            ._colf17String.Caption = "PreviousSKU"
            ._colf30String.Caption = "RootSKU"
            ._colf20String.Caption = "Notes"
            ._colf04String.Caption = "Manufacturer"
            ._colf01Int.Caption = "Ages"
            ._colf36String.Caption = "No.DO"
            ._colf01Date.Caption = "Tgl.Inbound"
            ._colf03String.Caption = "No.Order"
            ._colf03Date.Caption = "Tgl.Order"
            ._colf33String.Caption = "No.SJ"
            ._colf02Date.Caption = "Tgl.SJ"
        End With
    End Sub

    Private Sub _vs01VisibilityCurrentStockSku()
        With _prop03GridParentChild
            ._colk00Boolean.Visible = True   '"#"
            ._colf01Datetime.Visible = True   '"LastUpdate"
            ._colk03String.Visible = True   '"SKU"
            ._colf21String.Visible = True   '"ProductCode"
            ._colf18String.Visible = True   '"Stock"
            ._colf07String.Visible = True   '"CurrentLoc"
            ._colf05String.Visible = True   '"PreviousLoc"
            ._colf25String.Visible = True   '"Brand"
            ._colf27String.Visible = True   '"Kadar"
            ._colf02Int.Visible = True   '"KadarNum"
            ._colf12String.Visible = True   '"Type"
            ._colf08String.Visible = True   '"Colour"
            ._colf14String.Visible = True   '"Size"
            ._colf40String.Visible = True   '"Collection"
            ._colf06String.Visible = True   '"RO"
            ._colf22String.Visible = True   '"Status"
            ._colf09String.Visible = True   '"Box"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True   '"Gram"
            ._colf17String.Visible = True   '"PreviousSKU"
            ._colf30String.Visible = True   '"RootSKU"
            ._colf20String.Visible = True   '"Notes"
            ._colf04String.Visible = True   '"Manufacturer"
            ._colf01Int.Visible = True   '"Ages"
            ._colf36String.Visible = True   '"No.DO"
            ._colf01Date.Visible = True   '"Tgl.Inbound"
            ._colf03String.Visible = True   '"No.Order"
            ._colf03Date.Visible = True   '"Tgl.Order"
            ._colf33String.Visible = True   '"No.SJ"
            ._colf02Date.Visible = True   '"Tgl.SJ"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexCurrentStockSku()
        With _prop03GridParentChild
            ._colk00Boolean.VisibleIndex = 0  '"#"
            ._colf01Datetime.VisibleIndex = 1  '"LastUpdate"
            ._colk03String.VisibleIndex = 2  '"SKU"
            ._colf21String.VisibleIndex = 3  '"ProductCode"
            ._colf18String.VisibleIndex = 4  '"Stock"
            ._colf07String.VisibleIndex = 5  '"CurrentLoc"
            ._colf05String.VisibleIndex = 6  '"PreviousLoc"
            ._colf25String.VisibleIndex = 7  '"Brand"
            ._colf27String.VisibleIndex = 8  '"Kadar"
            ._colf02Int.VisibleIndex = 9  '"KadarNum"
            ._colf12String.VisibleIndex = 10  '"Type"
            ._colf08String.VisibleIndex = 11  '"Colour"
            ._colf14String.VisibleIndex = 12  '"Size"
            ._colf40String.VisibleIndex = 13  '"Collection"
            ._colf06String.VisibleIndex = 14  '"RO"
            ._colf22String.VisibleIndex = 15  '"Status"
            ._colf09String.VisibleIndex = 16  '"Box"
            ._colf01SmallInt.VisibleIndex = 17  '"Pcs"
            ._colf01Double.VisibleIndex = 18  '"Gram"
            ._colf17String.VisibleIndex = 19  '"PreviousSKU"
            ._colf30String.VisibleIndex = 20  '"RootSKU"
            ._colf20String.VisibleIndex = 21  '"Notes"
            ._colf04String.VisibleIndex = 22  '"Manufacturer"
            ._colf01Int.VisibleIndex = 23  '"Ages"
            ._colf36String.VisibleIndex = 24  '"No.DO"
            ._colf01Date.VisibleIndex = 25  '"Tgl.Inbound"
            ._colf03String.VisibleIndex = 26  '"No.Order"
            ._colf03Date.VisibleIndex = 27  '"Tgl.Order"
            ._colf33String.VisibleIndex = 28  '"No.SJ"
            ._colf02Date.VisibleIndex = 29  '"Tgl.SJ"

        End With
    End Sub

    Private Sub _tot01TotalSummaryFooterCurrentStockSku()
        With _prop03GridParentChild
            .GridView1.OptionsView.ShowFooter = True

            ._colf01Datetime.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            ._colf01Datetime.SummaryItem.DisplayFormat = "{0:n0} Rows"

            ._colf01SmallInt.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            ._colf01SmallInt.SummaryItem.DisplayFormat = "{0:n0}"

            ._colf01Double.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            ._colf01Double.SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainCurrentStockSku()
        With _prop03GridParentChild
            With .GridView1
                .Appearance.HeaderPanel.Font = New Font("Segoe UI", 8.5, FontStyle.Bold)
                .Appearance.HeaderPanel.ForeColor = Color.Navy
                .Appearance.HeaderPanel.Options.UseFont = True
                .Appearance.HeaderPanel.Options.UseForeColor = True

                .Appearance.Row.Font = New Font("Cambria", 8.25)
                .Appearance.Row.ForeColor = Color.Navy
                .Appearance.Row.Options.UseFont = True
                .Appearance.Row.Options.UseForeColor = True

                .Appearance.FocusedRow.Font = New Font("Cambria", 8.25, FontStyle.Italic)
                .Appearance.FocusedRow.ForeColor = Color.DarkSlateGray
                .Appearance.FocusedRow.Options.UseFont = True
                .Appearance.FocusedRow.Options.UseForeColor = True

                .Appearance.FooterPanel.Font = New Font("Segoe UI", 8.5, FontStyle.Bold)
                .Appearance.FooterPanel.ForeColor = Color.Navy
                .Appearance.FooterPanel.Options.UseFont = True
                .Appearance.FooterPanel.Options.UseForeColor = True

                .OptionsFind.AlwaysVisible = True
                .OptionsView.ShowAutoFilterRow = True
                .IndicatorWidth = 50
            End With

            With ._colk00Boolean
                .OptionsColumn.ReadOnly = False
                .Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With

            With ._colf01Datetime
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm"
                .Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With

            With ._colf01SmallInt
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With

            With ._colk03String
                .AppearanceHeader.BackColor = Color.DeepPink
                .AppearanceCell.BackColor = Color.LightPink
                .Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With

            With ._colf21String
                .AppearanceHeader.BackColor = Color.Yellow
                .AppearanceCell.BackColor = Color.LightYellow
                .Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With

            With ._colf18String
                .AppearanceHeader.BackColor = Color.Green
                .AppearanceCell.BackColor = Color.LightGreen
                .Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With

            With ._colf07String
                .AppearanceHeader.BackColor = Color.DarkBlue
                .AppearanceCell.BackColor = Color.LightBlue
                .Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With


        End With
    End Sub

#End Region


#Region " ***** outbound : sale *****"

    Private Sub _cc01Caption350OutboundSale()
        With _prop02Grid
            ._colk02String.Caption = "Doc.Sell"
            ._colk03String.Caption = "SKU"
            ._colf01String.Caption = "Doc.SJ"
            ._colf20String.Caption = "Doc.GJ"
            ._colf02String.Caption = "Doc.Order"
            ._colf04String.Caption = "KAE"
            ._colf06String.Caption = "Customer"
            ._colf08String.Caption = "TOP"
            ._colf09String.Caption = "Sell"
            ._colf11String.Caption = "Brand"
            ._colf13String.Caption = "Kadar"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Gr"
            ._colf02Date.Caption = "Sold"
        End With
    End Sub

    Private Sub _vs01Visibility350OutboundSale()
        With _prop02Grid
            ._colk02String.Visible = True     '"Doc.Sell"
            ._colk03String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"Doc.SJ"
            ._colf20String.Visible = True     '"Doc.SJ"
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

    Private Sub _vs02VisibilityIndex350OutboundSale()
        With _prop02Grid
            ._colf02Date.VisibleIndex = 0       '"Sold"
            ._colf09String.VisibleIndex = 1     '"Sell"
            ._colk03String.VisibleIndex = 2     '"SKU"
            ._colf06String.VisibleIndex = 3     '"Customer"
            ._colf08String.VisibleIndex = 4     '"TOP"
            ._colf01SmallInt.VisibleIndex = 5   '"Pcs"
            ._colf01Double.VisibleIndex = 6     '"Berat"
            ._colf11String.VisibleIndex = 7     '"Brand"
            ._colf13String.VisibleIndex = 8     '"Kadar"
            ._colf04String.VisibleIndex = 9     '"KAE"
            ._colk02String.VisibleIndex = 10    '"Doc.Sell"
            ._colf01String.VisibleIndex = 11    '"Doc.SJ"
            ._colf02String.VisibleIndex = 12    '"Doc.PKB"
            ._colf20String.VisibleIndex = 13    '"Doc.GJ"
        End With
    End Sub

    Private Sub _tot01Totalan350OutboundSale()
        With _prop02Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLain350OutboundSale()
        With _prop02Grid
            With ._colf01SmallInt
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With

            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With
        End With
    End Sub

#End Region

#Region " ***** transaksi ws : semua *****"

    Private Sub _cc01Caption370TransWSSemua()
        With _prop02Grid
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
        With _prop02Grid
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

    Private Sub _vs02VisibilityIndex370TransWSSemua()
        With _prop02Grid
            ._colf02String.VisibleIndex = 0     '"Target"
            ._colf02Date.VisibleIndex = 1       '"Tanggal"
            ._colf01String.VisibleIndex = 2     '"No.Doc"
            ._colf03String.VisibleIndex = 3     '"ProductCode"
            ._colk03String.VisibleIndex = 4     '"SKU"
            ._colf01SmallInt.VisibleIndex = 5   '"Pcs"
            ._colf01Double.VisibleIndex = 6     '"Berat"
            ._colf14String.VisibleIndex = 7     '"Brand"
            ._colf16String.VisibleIndex = 8     '"Kadar"
            ._colf20String.VisibleIndex = 9     '"Note"
            ._colf12String.VisibleIndex = 10    '"Box"
            ._colf06String.VisibleIndex = 11    '"Kepada"
        End With
    End Sub

    Private Sub _tot01Totalan370TransWSSemua()
        With _prop02Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLain370TransWSSemua()
        With _prop02Grid
            With ._colf01SmallInt
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With

        End With
    End Sub
#End Region

#Region "***** Rpt. Store *****"
    Private Sub _cc01CaptionRptStore()
        With _prop02Grid
            ._colk00Boolean.Caption = "#"
            ._colf01String.Caption = "Account Code"
            ._colk03String.Caption = "Account Name"
            ._colk02String.Caption = "Store Code"
            ._colf02String.Caption = "Store Name"
            ._colf05String.Caption = "Status"
            ._colf06String.Caption = "Store Type"
            ._colf11String.Caption = "Region"
            ._colf39String.Caption = "Store Address"
            ._colf17String.Caption = "Store Phone Number"
            ._colf19String.Caption = "Owner"
            ._colf20String.Caption = "Owner's Birthdate"
            ._colf21String.Caption = "Owner Phone Number"
            ._colf40String.Caption = "Owner Address"
            ._colf18String.Caption = "Email"
            ._colf22String.Caption = "KTP"
            ._colf04String.Caption = "NPWP"
            ._colf07String.Caption = "PIC/SM/ADMIN"
            ._colf08String.Caption = "Store Discount"
            ._colf23String.Caption = "KAE"
        End With
    End Sub

    Private Sub _vs01VisibilityRptStore()
        With _prop02Grid
            ._colk00Boolean.Visible = True  ' "#"
            ._colf01String.Visible = True  ' "Account Code"
            ._colf02String.Visible = True  ' "Account Name"
            ._colk02String.Visible = True  ' "Store Code"
            ._colk03String.Visible = True  ' "Store Name"
            ._colf05String.Visible = True  ' "Status"
            ._colf06String.Visible = True  ' "Store Type"
            ._colf11String.Visible = True  ' "Region"
            ._colf39String.Visible = True  ' "Store Address"
            ._colf17String.Visible = True  ' "Store Phone Number"
            ._colf19String.Visible = True  ' "Owner"
            ._colf20String.Visible = True  ' "Owner's Birthdate"
            ._colf21String.Visible = True  ' "Owner Phone Number"
            ._colf40String.Visible = True  ' "Owner Address"
            ._colf18String.Visible = True  ' "Email"
            ._colf22String.Visible = True  ' "KTP"
            ._colf04String.Visible = True  ' "NPWP"
            ._colf07String.Visible = True  ' "PIC/SM/ADMIN"
            ._colf08String.Visible = True  ' "Store Discount"
            ._colf23String.Visible = True  ' "KAE"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexRptStore()
        With _prop02Grid
            ._colk00Boolean.VisibleIndex = 0   ' "#"
            ._colf01String.VisibleIndex = 1 ' "Account Code"
            ._colk03String.VisibleIndex = 2  ' "Store Name"
            ._colk02String.VisibleIndex = 3 ' "Store Code"
            ._colf02String.VisibleIndex = 4 ' "Account Name"
            ._colf05String.VisibleIndex = 5 ' "Status"
            ._colf06String.VisibleIndex = 6 ' "Store Type"
            ._colf11String.VisibleIndex = 7  ' "Region"
            ._colf39String.VisibleIndex = 8  ' "Store Address"
            ._colf17String.VisibleIndex = 9  ' "Store Phone Number"
            ._colf19String.VisibleIndex = 10  ' "Owner"
            ._colf20String.VisibleIndex = 11 ' "Owner's Birthdate"
            ._colf21String.VisibleIndex = 12  ' "Owner Phone Number"
            ._colf40String.VisibleIndex = 13  ' "Owner Address"
            ._colf18String.VisibleIndex = 14  ' "Email"
            ._colf22String.VisibleIndex = 15  ' "KTP"
            ._colf04String.VisibleIndex = 16  ' "NPWP"
            ._colf07String.VisibleIndex = 17  ' "PIC/SM/ADMIN"
            ._colf08String.VisibleIndex = 18  ' "Store Discount"
            ._colf23String.VisibleIndex = 19 ' "KAE"
        End With
    End Sub

    Private Sub _ll01LainLainStore()
        With _prop02Grid
            With ._colk00Boolean
                .OptionsColumn.ReadOnly = False
            End With

            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With
        End With
    End Sub

    Private Sub _wd240707WidthStore()
        With _prop02Grid
            ._colk00Boolean.Width = 27
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 77
            ._colk03String.Width = 181
            ._colf01String.Width = 93
            ._colf02String.Width = 79
            ._colf03String.Width = 323
            ._colf04String.Width = 65
            ._colf05String.Width = 86
            ._colf06String.Width = 135
            ._colf07String.Width = 95
            ._colf08String.Width = 96
            ._colf09String.Width = 85
            ._colf10String.Width = 85
            ._colf11String.Width = 135
            ._colf12String.Width = 85
            ._colf13String.Width = 85
            ._colf14String.Width = 85
            ._colf15String.Width = 85
            ._colf16String.Width = 85
            ._colf17String.Width = 120
            ._colf18String.Width = 178
            ._colf19String.Width = 147
            ._colf20String.Width = 97
            ._colf21String.Width = 126
            ._colf22String.Width = 146
            ._colf23String.Width = 184
            ._colf24String.Width = 85
            ._colf25String.Width = 85
            ._colf26String.Width = 85
            ._colf27String.Width = 85
            ._colf28String.Width = 85
            ._colf29String.Width = 85
            ._colf30String.Width = 85
            ._colf31String.Width = 85
            ._colf32String.Width = 79
            ._colf33String.Width = 79
            ._colf34String.Width = 79
            ._colf35String.Width = 79
            ._colf36String.Width = 79
            ._colf37String.Width = 79
            ._colf38String.Width = 79
            ._colf39String.Width = 431
            ._colf40String.Width = 437
            ._colf01TinyInt.Width = 85
            ._colf01SmallInt.Width = 49
            ._colf01Int.Width = 85
            ._colf01Double.Width = 88
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 94
        End With
    End Sub



#End Region

#Region "***** Rpt. AgregatSJ *****"
    Private Sub _cc01CaptionRptAgregatSJ()
        With _prop02Grid
            ._colk01String.Caption = "NO.Order"
            ._colk03String.Caption = "NO.SJ"
            ._colf01String.Caption = "Toko/Penerima"
            ._colf02String.Caption = "SKU"
            ._colf03String.Caption = "Brand"
            ._colf04String.Caption = "Product Code"
            ._colf05String.Caption = "Master Code"
            ._colf06String.Caption = "Item"
            ._colf07String.Caption = "Kadar Emas"
            ._colf08String.Caption = "Size"
            ._colf09String.Caption = "Color"
            ._colf01Double.Caption = "Weight Zircon"
            ._colf02Double.Caption = "Weight"
            ._colf01Int.Caption = "Quantity"
            ._colf13String.Caption = "Collection"
            ._colf02Int.Caption = "Model atau Design Age"
            ._colf11String.Caption = "Segmen"
            ._colf12String.Caption = "Keterangan"
            ._colf10String.Caption = "Status"
        End With
    End Sub

    Private Sub _vs01VisibilityRptAgregatSJ()
        With _prop02Grid
            ._colk01String.Visible = True   ' "No.PO"
            ._colk03String.Visible = True   ' "No.SJ"
            ._colf01String.Visible = True   ' "Penerima"
            ._colf02String.Visible = True   ' "SKU"
            ._colf03String.Visible = True   ' "Brand"
            ._colf04String.Visible = True   ' "Product Code"
            ._colf05String.Visible = True   ' "Master Code"
            ._colf06String.Visible = True   ' "Item"
            ._colf07String.Visible = True   ' "Kadar Emas"
            ._colf08String.Visible = True   ' "Size"
            ._colf09String.Visible = True   ' "Color"
            ._colf01Double.Visible = True   ' "Weight Zircon"
            ._colf02Double.Visible = True   ' "Weight"
            ._colf01Int.Visible = True   ' "Quantity"
            ._colf13String.Visible = True   ' "Collection"
            ._colf02Int.Visible = True   ' "Model atau Design Age"
            ._colf11String.Visible = True   ' "Segmen"
            ._colf12String.Visible = True   ' "Keterangan"
            ._colf10String.Visible = True   ' "Status"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexRptAgregatSJ()
        With _prop02Grid
            ._colk01String.VisibleIndex = 0  ' "No.PO"
            ._colk03String.VisibleIndex = 1  ' "No.SJ"
            ._colf01String.VisibleIndex = 2  ' "Penerima"
            ._colf02String.VisibleIndex = 3  ' "SKU"
            ._colf03String.VisibleIndex = 4  ' "Brand"
            ._colf04String.VisibleIndex = 5  ' "Product Code"
            ._colf05String.VisibleIndex = 6  ' "Master Code"
            ._colf06String.VisibleIndex = 7  ' "Item"
            ._colf07String.VisibleIndex = 8  ' "Kadar Emas"
            ._colf08String.VisibleIndex = 9  ' "Size"
            ._colf09String.VisibleIndex = 10  ' "Color"
            ._colf01Double.VisibleIndex = 11  ' "Weight Zircon"
            ._colf02Double.VisibleIndex = 12  ' "Weight"
            ._colf01Int.VisibleIndex = 13  ' "Quantity"
            ._colf13String.VisibleIndex = 14  ' "Collection"
            ._colf02Int.VisibleIndex = 15  ' "Model atau Design Age"
            ._colf11String.VisibleIndex = 16  ' "Segmen"
            ._colf12String.VisibleIndex = 17  ' "Keterangan"
            ._colf10String.VisibleIndex = 18  ' "Status"
        End With
    End Sub

    Private Sub _ll01LainLainAgregatSJ()
        With _prop02Grid

            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With

            ._colk01String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colk03String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            With ._colf02Int
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0} days"
                End With
            End With
            With ._colf01Int
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0} pcs"
                End With
            End With
        End With
    End Sub

    Private Sub _wd240707WidthAgergatSJ()
        With _prop02Grid
            ._colk00Boolean.Width = 79
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 79
            ._colk03String.Width = 115
            ._colf01String.Width = 152
            ._colf02String.Width = 121
            ._colf03String.Width = 77
            ._colf04String.Width = 111
            ._colf05String.Width = 89
            ._colf06String.Width = 75
            ._colf07String.Width = 90
            ._colf08String.Width = 73
            ._colf09String.Width = 85
            ._colf10String.Width = 85
            ._colf11String.Width = 73
            ._colf12String.Width = 85
            ._colf13String.Width = 85
            ._colf14String.Width = 85
            ._colf15String.Width = 85
            ._colf16String.Width = 85
            ._colf17String.Width = 109
            ._colf18String.Width = 183
            ._colf19String.Width = 179
            ._colf20String.Width = 158
            ._colf21String.Width = 146
            ._colf22String.Width = 128
            ._colf23String.Width = 189
            ._colf24String.Width = 85
            ._colf25String.Width = 85
            ._colf26String.Width = 85
            ._colf27String.Width = 85
            ._colf28String.Width = 85
            ._colf29String.Width = 85
            ._colf30String.Width = 85
            ._colf31String.Width = 85
            ._colf32String.Width = 79
            ._colf33String.Width = 79
            ._colf34String.Width = 79
            ._colf35String.Width = 79
            ._colf36String.Width = 79
            ._colf37String.Width = 79
            ._colf38String.Width = 79
            ._colf39String.Width = 285
            ._colf40String.Width = 354
            ._colf01TinyInt.Width = 85
            ._colf01SmallInt.Width = 49
            ._colf01Int.Width = 85
            ._colf01Double.Width = 88
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 94
        End With
    End Sub

#End Region
End Class




