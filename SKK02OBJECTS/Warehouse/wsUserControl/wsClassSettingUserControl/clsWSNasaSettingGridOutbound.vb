Imports SKK02OBJECTS.clsWSNasaSettingGridInbound

Public Class clsWSNasaSettingGridOutbound
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

    Property _prop01cTargetReceiveFG As TargetWSOutbound
    Property _prop02User As clsWSNasaUser
    Property _prop03Grid As New ucWSGrid
    Property _prop04DataTableMaster As DataTable

    Property _prop08Progress As repoWS08ProgressBar

    Public Enum TargetWSOutbound
        _wsOutboundSuratJalan = 0
        _WSOutboundSuratJalanAirwayBill = 110
        _WSOutboundSuratJalanPICKUPbyCourier = 111
        _WSOutboundSuratJalanDELIVEREDbyCourier = 112

        _wsOutboundPenjualan = 10

        'PickingList
        _WSOutbound5051PickingListSKU = 505128620
        _WSOutbound5051PickingListProdCode = 505128621
    End Enum

#Region "form and control - event"
    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
    End Sub
#End Region

#Region " public - method "

    Public Sub _pbSetting01SuratJalan()
        _rsRepoSettingSuratJalan()
        _cc01CaptionSuratJalan()
        _vs01VisibilitySuratJalan()
        _vs02VisibilityIndexSuratJalan()
        _wr01WriteSuratJalan()
        _ll01LainLainSuratJalan()
    End Sub

    Public Sub _pbSetting011SuratJalanAirwayBill()
        _rsRepoSettingSuratJalanAirwayBill()
        _cc01CaptionSuratJalanAirwayBill()
        _vs01VisibilitySuratJalanAirwayBill()
        _vs02VisibilityIndexSuratJalanAirwayBill()
        _wr01WriteSuratJalanAirwayBill()
        _ll01LainLainSuratJalanAirwayBill()
    End Sub

    Public Sub _pbSetting012SuratJalanPickupbyCourier()
        _rsRepoSettingSuratJalanPickupbyCourier()
        _cc01CaptionSuratJalanPickupbyCourier()
        _vs01VisibilitySuratJalanPickupbyCourier()
        _vs02VisibilityIndexSuratJalanPickupbyCourier()
        _wr01WriteSuratJalanPickupbyCourier()
        _ll01LainLainSuratJalanPickupbyCourier()
    End Sub

    Public Sub _pbSetting013SuratJalanDeliveredbyCourier()
        _rsRepoSettingSuratJalanDeliveredbyCourier()
        _cc01CaptionSuratJalanDeliveredbyCourier()
        _vs01VisibilitySuratJalanDeliveredbyCourier()
        _vs02VisibilityIndexSuratJalanDeliveredbyCourier()
        _wr01WriteSuratJalanDeliveredbyCourier()
        _ll01LainLainSuratJalanDeliveredbyCourier()
    End Sub

    Public Sub _pbSetting02Penjualan()
        _cc01CaptionPenjualan()
        _vs01VisibilityPenjualan()
        _vs02VisibilityIndexPenjualan()
        _wr01WritePenjualan()
    End Sub

    Public Sub _pbSetting03PickingListSKU()
        _cc01Caption5051PickingListSKU()
        _vs01Visibility5051PickingListSKU()
        _vs02VisibilityIndex5051PickingListSKU()
        _tot01TotalBeratDanLotInbound5051PickingListSKU()
        _wd240707WidthPickingListSKU()
    End Sub

    Public Sub _pbSetting04PickingListProdCode()
        _cc01Caption5051PickingListProdCode()
        _vs01Visibility5051PickingListProdCode()
        _vs02VisibilityIndex5051PickingListProdCode()
        _tot01TotalBeratDanLotInbound5051PickingListProdCode()
        _wd240707WidthPickingListProdCode()
    End Sub
#End Region

#Region "***** Surat Jalan : NEW *****"

    'Private _rscolf01Memo As repoWS03Picture
    'Private _rscolf27String As repoWS05Master
    'Private _rscolf28String As repoWS05Master

    Private Sub _rsRepoSettingSuratJalan()
        Dim pdtSLoc As New DataTable
        'pdtSLoc = _prop05DataTableMaster.Copy()

        'Dim pdtBox As New DataTable
        'pdtBox = _prop04DataTableMaster.Copy()

        '_rscolf01Memo = New repoWS03Picture()
        '_rscolf27String = New repoWS05Master With {._prop_01dtWSNasaMaster = pdtSLoc,
        '                                           ._prop_02TargetMaster = repoWS05Master._TargetMaster._01SLOC}
        '_rscolf27String._01WSNasaBindingDataSource()  'SLoc

        '_rscolf28String = New repoWS05Master With {._prop_01dtWSNasaMaster = pdtBox,
        '                                           ._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX}
        '_rscolf28String._01WSNasaBindingDataSource()
        '_rscolf28String._02WSNasaFilterGroupMaster("k11String", "SBOX")

        With _prop03Grid
            .GridView1.OptionsView.ColumnAutoWidth = False
            .GridView1.OptionsView.RowAutoHeight = True
            .GridView1.BestFitColumns()

            '._colf01Memo.ColumnEdit = _rscolf01Memo
            '._colf27String.ColumnEdit = _rscolf27String
            '._colf28String.ColumnEdit = _rscolf28String
        End With
    End Sub

    Private Sub _cc01CaptionSuratJalan()
        '--03PKB,13Customer,15KAE,17TOP,19Brand,21Kadar
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colk00Int.Caption = "##"
            ._colf03String.Caption = "Order"
            ._colf13String.Caption = "Kepada"
            ._colf15String.Caption = "KAE"
            ._colf17String.Caption = "TOP"
            ._colf19String.Caption = "Brand"
            ._colf21String.Caption = "Kadar"
            ._colf32String.Caption = "StatusBRJ"

            ._colf01SmallInt.Caption = "Tot.Qty"          'TPcs
            ._colf01Double.Caption = "Tot.GramGross"     'TBerat Gross

            '._colf01Memo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '._colf01String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '._colk02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '._colk03String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        End With
    End Sub

    Private Sub _vs01VisibilitySuratJalan()
        With _prop03Grid
            ._colk00Boolean.Visible = True     '"#"
            ._colk00Int.Visible = False     '"##"
            ._colf03String.Visible = True     '"PKB"
            ._colf13String.Visible = True     '"Kepada"
            ._colf15String.Visible = True     '"KAE"
            ._colf17String.Visible = True     '"TOP"
            ._colf19String.Visible = True     '"Brand"
            ._colf21String.Visible = True     '"Kadar"
            ._colf32String.Visible = True     '"StatusBRJ"

            ._colf01SmallInt.Visible = True   '"TPcs"          
            ._colf01Double.Visible = True     '"TBeratGross"     
        End With

    End Sub

    Private Sub _vs02VisibilityIndexSuratJalan()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0     '"#"
            ._colk00Int.VisibleIndex = -1     '"##"
            ._colf03String.VisibleIndex = 1     '"PKB"
            ._colf13String.VisibleIndex = 2     '"Kepada"
            ._colf15String.VisibleIndex = 3     '"KAE"
            ._colf17String.VisibleIndex = 4     '"TOP"
            ._colf19String.VisibleIndex = 6     '"Brand"
            ._colf21String.VisibleIndex = 5     '"Kadar"
            ._colf32String.VisibleIndex = 7     '"Kadar"

            ._colf01SmallInt.VisibleIndex = 8   '"TPcs"          
            ._colf01Double.VisibleIndex = 9     '"TBeratGross"   
        End With
    End Sub

    Private Sub _wr01WriteSuratJalan()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False
        End With
    End Sub

    Private Sub _ll01LainLainSuratJalan()

        With _prop03Grid
            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
            'With ._colf01SmallInt     '
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf28String      '"Box"
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With
        End With

    End Sub

#End Region

#Region "***** Surat Jalan : AIRWAY BILL by Courier *****"

    Private _rscolf12String As repoWS05Master

    Private Sub _rsRepoSettingSuratJalanAirwayBill()
        _rscolf12String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop04DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._03COURIER}
        _rscolf12String._01WSNasaBindingDataSource()
        _rscolf12String._02WSNasaFilterGroupMaster("k11String", "COURIER")

        With _prop03Grid
            .GridView1.OptionsView.ColumnAutoWidth = False
            .GridView1.OptionsView.RowAutoHeight = True
            .GridView1.BestFitColumns()

            ._colf12String.ColumnEdit = _rscolf12String
        End With
    End Sub

    Private Sub _cc01CaptionSuratJalanAirwayBill()

        With _prop03Grid
            ._colk02String.Caption = "SuratJalan"
            ._colk03String.Caption = "No.Order"
            ._colf02String.Caption = "Customer"
            ._colf04String.Caption = "KAE"
            ._colf10String.Caption = "Kadar"
            ._colf01Date.Caption = "Tgl.SJ"
            ._colf01SmallInt.Caption = "Tot.Qty"
            ._colf01Double.Caption = "Tot.GramGross"
            ._colf12String.Caption = "Ekspedisi"
            ._colf14String.Caption = "No.Resi"

            '._colf01Memo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '._colf01String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '._colk02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '._colk03String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        End With
    End Sub

    Private Sub _vs01VisibilitySuratJalanAirwayBill()
        With _prop03Grid
            ._colk02String.Visible = True     '"SuratJalan"
            ._colk03String.Visible = True     '"No. Order"
            ._colf02String.Visible = True     '"Customer"
            ._colf04String.Visible = True     '"KAE"
            ._colf10String.Visible = True     '"Kadar"
            ._colf01Date.Visible = True       '"Tgl.SJ"
            ._colf01SmallInt.Visible = True   '"TPcs"
            ._colf01Double.Visible = True     '"TBeratGross"
            ._colf12String.Visible = True     '"Courier"
            ._colf14String.Visible = True     '"No.Resi"   
        End With

    End Sub

    Private Sub _vs02VisibilityIndexSuratJalanAirwayBill()
        With _prop03Grid
            ._colk02String.VisibleIndex = 0     '"SuratJalan"
            ._colk03String.VisibleIndex = 1     '"No. Order"
            ._colf02String.VisibleIndex = 2     '"Customer"
            ._colf04String.VisibleIndex = 3     '"KAE"
            ._colf10String.VisibleIndex = 4     '"Kadar"
            ._colf01Date.VisibleIndex = 5       '"Tgl.SJ"
            ._colf01SmallInt.VisibleIndex = 6   '"TPcs"
            ._colf01Double.VisibleIndex = 7     '"TBeratGross"
            ._colf12String.VisibleIndex = 8     '"Courier"
            ._colf14String.VisibleIndex = 9     '"No.Resi"
        End With
    End Sub

    Private Sub _wr01WriteSuratJalanAirwayBill()
        With _prop03Grid
            ._colf12String.OptionsColumn.ReadOnly = False
            ._colf14String.OptionsColumn.ReadOnly = False
        End With
    End Sub

    Private Sub _ll01LainLainSuratJalanAirwayBill()

        With _prop03Grid
            'With ._colf01SmallInt     '
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            With ._colf12String      '"Courier"
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf14String      '"No.Resi"
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
        End With

    End Sub

#End Region

#Region "***** Surat Jalan : PICKUP by Courier  *****"

    Private _rscolf02Date As repoWS01Date

    Private Sub _rsRepoSettingSuratJalanPickupbyCourier()

        _rscolf02Date = New repoWS01Date
        _rscolf02Date._pb01InitRepoDate()

        With _prop03Grid
            .GridView1.OptionsView.ColumnAutoWidth = False
            .GridView1.OptionsView.RowAutoHeight = True
            .GridView1.BestFitColumns()

            ._colf02Date.ColumnEdit = _rscolf02Date
        End With
    End Sub

    Private Sub _cc01CaptionSuratJalanPickupbyCourier()

        With _prop03Grid
            ._colk02String.Caption = "SuratJalan"
            ._colk03String.Caption = "No.Order"
            ._colf02String.Caption = "Customer"
            ._colf04String.Caption = "KAE"
            ._colf10String.Caption = "Kadar"
            ._colf13String.Caption = "Ekspedisi"
            ._colf14String.Caption = "No.Resi"
            ._colf01SmallInt.Caption = "Tot.QTY"
            ._colf01Double.Caption = "Tot.GramGross"
            ._colf01Date.Caption = "Tgl.SJ"
            ._colf02Date.Caption = "Tgl.ConfirmPickup"

            ._colk02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colk03String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf04String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf10String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf13String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf14String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        End With
    End Sub

    Private Sub _vs01VisibilitySuratJalanPickupbyCourier()
        With _prop03Grid
            ._colk02String.Visible = True     '"SuratJalan"
            ._colk03String.Visible = True     '"No. Order"
            ._colf02String.Visible = True     '"Customer"
            ._colf04String.Visible = True     '"KAE"
            ._colf10String.Visible = True     '"Kadar"
            ._colf13String.Visible = True     '"Ekspedisi"
            ._colf14String.Visible = True     '"No.Resi"
            ._colf01SmallInt.Visible = True   '"TPcs"
            ._colf01Double.Visible = True     '"TBeratGross"
            ._colf01Date.Visible = True       '"Tgl.SJ"
            ._colf02Date.Visible = True       '"Tgl.Pickup"
        End With

    End Sub

    Private Sub _vs02VisibilityIndexSuratJalanPickupbyCourier()
        With _prop03Grid
            ._colk02String.VisibleIndex = 0     '"SuratJalan"
            ._colk03String.VisibleIndex = 1     '"No. Order"
            ._colf02String.VisibleIndex = 2     '"Customer"
            ._colf04String.VisibleIndex = 3     '"KAE"
            ._colf10String.VisibleIndex = 4     '"Kadar"
            ._colf13String.VisibleIndex = 5     '"Ekspedisi"
            ._colf14String.VisibleIndex = 6     '"No.Resi"
            ._colf01SmallInt.VisibleIndex = 7   '"TPcs"
            ._colf01Double.VisibleIndex = 8     '"TBeratGross"
            ._colf01Date.VisibleIndex = 9       '"Tgl.SJ"
            ._colf02Date.VisibleIndex = 10      '"Tgl.Pickup"
        End With
    End Sub

    Private Sub _wr01WriteSuratJalanPickupbyCourier()
        With _prop03Grid
            ._colf02Date.OptionsColumn.ReadOnly = False
        End With
    End Sub

    Private Sub _ll01LainLainSuratJalanPickupbyCourier()

        With _prop03Grid
            'With ._colf01SmallInt     '
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            With ._colf02Date      '"Tgl. Pickup"
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

        End With

    End Sub

#End Region

#Region "***** Surat Jalan : DELIVERD by Courier  *****"
    Private _rscolf03Date As repoWS01Date

    Private Sub _rsRepoSettingSuratJalanDeliveredbyCourier()

        _rscolf03Date = New repoWS01Date
        _rscolf03Date._pb01InitRepoDate()

        With _prop03Grid
            .GridView1.OptionsView.ColumnAutoWidth = False
            .GridView1.OptionsView.RowAutoHeight = True
            .GridView1.BestFitColumns()

            ._colf03Date.ColumnEdit = _rscolf03Date
        End With
    End Sub

    Private Sub _cc01CaptionSuratJalanDeliveredbyCourier()

        With _prop03Grid
            ._colk02String.Caption = "SuratJalan"
            ._colk03String.Caption = "No.Order"
            ._colf02String.Caption = "Customer"
            ._colf04String.Caption = "KAE"
            ._colf10String.Caption = "Kadar"
            ._colf13String.Caption = "Ekspedisi"
            ._colf14String.Caption = "No.Resi"
            ._colf15String.Caption = "StatusBRJ"
            ._colf01SmallInt.Caption = "Tot.QTY"
            ._colf01Double.Caption = "Tot.GramGross"
            ._colf01Date.Caption = "Tgl.SJ"
            ._colf03Date.Caption = "Tgl.ConfirmDelivered"

            ._colk02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colk03String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf04String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf10String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf13String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf14String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        End With
    End Sub

    Private Sub _vs01VisibilitySuratJalanDeliveredbyCourier()
        With _prop03Grid
            ._colk02String.Visible = True     '"SuratJalan"
            ._colk03String.Visible = True     '"No. Order"
            ._colf02String.Visible = True     '"Customer"
            ._colf04String.Visible = True     '"KAE"
            ._colf10String.Visible = True     '"Kadar"
            ._colf13String.Visible = True     '"Ekspedisi"
            ._colf14String.Visible = True     '"No.Resi"
            ._colf15String.Visible = True     '"StatusBRJ"
            ._colf01SmallInt.Visible = True   '"TPcs"
            ._colf01Double.Visible = True     '"TBeratGross"
            ._colf01Date.Visible = True       '"Tgl.SJ"
            ._colf03Date.Visible = True       '"Tgl.Delivered"
        End With

    End Sub

    Private Sub _vs02VisibilityIndexSuratJalanDeliveredbyCourier()
        With _prop03Grid
            ._colk02String.VisibleIndex = 0     '"SuratJalan"
            ._colk03String.VisibleIndex = 1     '"No. Order"
            ._colf02String.VisibleIndex = 2     '"Customer"
            ._colf04String.VisibleIndex = 3     '"KAE"
            ._colf10String.VisibleIndex = 4     '"Kadar"
            ._colf13String.VisibleIndex = 5     '"Ekspedisi"
            ._colf14String.VisibleIndex = 6     '"No.Resi"
            ._colf15String.VisibleIndex = 7     '"StatusBRJ"
            ._colf01SmallInt.VisibleIndex = 8   '"TPcs"
            ._colf01Double.VisibleIndex = 9     '"TBeratGross"
            ._colf01Date.VisibleIndex = 10       '"Tgl.SJ"
            ._colf03Date.VisibleIndex = 11      '"Tgl.Delivered"
        End With
    End Sub

    Private Sub _wr01WriteSuratJalanDeliveredbyCourier()
        With _prop03Grid
            ._colf03Date.OptionsColumn.ReadOnly = False
        End With
    End Sub

    Private Sub _ll01LainLainSuratJalanDeliveredbyCourier()

        With _prop03Grid
            'With ._colf01SmallInt     '
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            With ._colf03Date      '"Tgl. Delivered"
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

        End With

    End Sub

#End Region

#Region "***** Penjualan *****"

    Private Sub _cc01CaptionPenjualan()
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colk00Int.Caption = "#"
            ._colk03String.Caption = "SKU"
            ._colf19String.Caption = "Brand"
            ._colf21String.Caption = "Kadar"
            ._colf23String.Caption = "Item"
            ._colf27String.Caption = "Size"
            ._colf29String.Caption = "Warna"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
        End With
    End Sub

    Private Sub _vs01VisibilityPenjualan()
        With _prop03Grid
            ._colk00Boolean.Visible = True     '"#"
            ._colk00Int.Visible = False     '"#"
            ._colk03String.Visible = True     '"SKU"
            ._colf19String.Visible = True     '"Brand"
            ._colf21String.Visible = True     '"Kadar"
            ._colf23String.Visible = True     '"Item"
            ._colf27String.Visible = True     '"Size"
            ._colf29String.Visible = True     '"Warna"
            ._colf01SmallInt.Visible = True     '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexPenjualan()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0     '"#"
            ._colk00Int.VisibleIndex = -1     '"#"
            ._colk03String.VisibleIndex = 1     '"SKU"
            ._colf19String.VisibleIndex = 3     '"Brand"
            ._colf21String.VisibleIndex = 2     '"Kadar"
            ._colf23String.VisibleIndex = 4     '"Item"
            ._colf27String.VisibleIndex = 5     '"Size"
            ._colf29String.VisibleIndex = 6     '"Warna"
            ._colf01SmallInt.VisibleIndex = 7     '"Pcs"
            ._colf01Double.VisibleIndex = 8     '"Berat"
        End With
    End Sub

    Private Sub _wr01WritePenjualan()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False

            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
        End With


    End Sub

#End Region

#Region "***** 5051. Picking List - SKU (ucWS24HG01PICKING) *****"
    Private Sub _cc01Caption5051PickingListSKU()
        With _prop03Grid
            ._colk01String.Caption = "No.Order"
            ._colk02String.Caption = "ProductCode"
            ._colk03String.Caption = "SKU"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
        End With
    End Sub

    Private Sub _vs01Visibility5051PickingListSKU()
        With _prop03Grid
            ._colk01String.Visible = True     '"No.Order"
            ._colk02String.Visible = True     '"ProductCode"
            ._colk03String.Visible = True     '"SKU"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndex5051PickingListSKU()
        With _prop03Grid
            ._colk01String.VisibleIndex = 1     '"No.Order"
            ._colk02String.VisibleIndex = 2     '"ProductCode"
            ._colk03String.VisibleIndex = 3     '"SKU"
            ._colf01SmallInt.VisibleIndex = 4   '"Pcs"
            ._colf01Double.VisibleIndex = 5     '"Berat"
        End With
    End Sub

    Private Sub _tot01TotalBeratDanLotInbound5051PickingListSKU()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _wd240707WidthPickingListSKU()
        With _prop03Grid
            ._colk00Boolean.Width = 79
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 116
            ._colk02String.Width = 97
            ._colk03String.Width = 102
            ._colf01String.Width = 79
            ._colf02String.Width = 79
            ._colf03String.Width = 79
            ._colf04String.Width = 79
            ._colf05String.Width = 85
            ._colf06String.Width = 85
            ._colf07String.Width = 85
            ._colf08String.Width = 85
            ._colf09String.Width = 85
            ._colf10String.Width = 85
            ._colf11String.Width = 85
            ._colf12String.Width = 85
            ._colf13String.Width = 85
            ._colf14String.Width = 85
            ._colf15String.Width = 85
            ._colf16String.Width = 85
            ._colf17String.Width = 85
            ._colf18String.Width = 85
            ._colf19String.Width = 85
            ._colf20String.Width = 85
            ._colf21String.Width = 85
            ._colf22String.Width = 85
            ._colf23String.Width = 85
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
            ._colf39String.Width = 79
            ._colf40String.Width = 79
            ._colf01TinyInt.Width = 85
            ._colf01SmallInt.Width = 29
            ._colf01Int.Width = 85
            ._colf01Double.Width = 47
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub

#End Region

#Region "***** 5051. Picking List - Product Code (ucWS24HG01PICKING) *****"

    Private Sub _cc01Caption5051PickingListProdCode()
        _prop08Progress = New repoWS08ProgressBar
        _prop08Progress.__pb01InitRepoProgressBar()

        With _prop03Grid
            ._colk01String.Caption = "No.Order"
            ._colk02String.Caption = "ProductCode"
            ._colf01SmallInt.Caption = "Tot.Qty"
            ._colf01Double.Caption = "Tot.Gram"

            ._colf01Int.ColumnEdit = _prop08Progress
            ._colf01Int.Caption = "%"
            ._colk03String.Caption = "Progress"
        End With
    End Sub

    Private Sub _vs01Visibility5051PickingListProdCode()
        With _prop03Grid
            ._colk01String.Visible = True     '"No.Order"
            ._colk02String.Visible = True     '"ProductCode"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True     '"Berat"

            ._colf01Int.Visible = True        '"%%"
            ._colk03String.Visible = True     '"Progress"
        End With
    End Sub

    Private Sub _vs02VisibilityIndex5051PickingListProdCode()
        With _prop03Grid
            ._colk01String.VisibleIndex = 1     '"No.Order"
            ._colk02String.VisibleIndex = 2     '"ProductCode"
            ._colf01SmallInt.VisibleIndex = 3   '"Pcs"
            ._colf01Double.VisibleIndex = 4     '"Berat"

            ._colf01Int.VisibleIndex = 5        '"%%"
            ._colk03String.VisibleIndex = 6     '"Progress"
        End With
    End Sub

    Private Sub _tot01TotalBeratDanLotInbound5051PickingListProdCode()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _wd240707WidthPickingListProdCode()
        With _prop03Grid
            ._colk00Boolean.Width = 79
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 118
            ._colk02String.Width = 93
            ._colk03String.Width = 79
            ._colf01String.Width = 79
            ._colf02String.Width = 79
            ._colf03String.Width = 79
            ._colf04String.Width = 79
            ._colf05String.Width = 85
            ._colf06String.Width = 85
            ._colf07String.Width = 85
            ._colf08String.Width = 85
            ._colf09String.Width = 85
            ._colf10String.Width = 85
            ._colf11String.Width = 85
            ._colf12String.Width = 85
            ._colf13String.Width = 85
            ._colf14String.Width = 85
            ._colf15String.Width = 85
            ._colf16String.Width = 85
            ._colf17String.Width = 85
            ._colf18String.Width = 85
            ._colf19String.Width = 85
            ._colf20String.Width = 85
            ._colf21String.Width = 85
            ._colf22String.Width = 85
            ._colf23String.Width = 85
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
            ._colf39String.Width = 79
            ._colf40String.Width = 79
            ._colf01TinyInt.Width = 85
            ._colf01SmallInt.Width = 36
            ._colf01Int.Width = 74
            ._colf01Double.Width = 50
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub

#End Region

End Class
