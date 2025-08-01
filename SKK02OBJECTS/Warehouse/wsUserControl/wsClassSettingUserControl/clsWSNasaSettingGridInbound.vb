Imports DevExpress.CodeParser
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSpreadsheet.DocumentFormats.Xlsb

Public Class clsWSNasaSettingGridInbound
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

    Property _prop01cTargetINBOUND As TargetINBOUND
    Property _prop02User As clsWSNasaUser
    Property _prop03Grid As New ucWSGrid
    Property _prop04DataTableMaster As DataTable
    Property _prop05DataTableMaster As DataTable
    Property _prop06DataTableMaster As DataTable
    Property _prop07RepoMasterDelegate As repoWS05Master

    Public Enum TargetINBOUND
        _WSReceiveDOFGFromCITRIX = 0    'Citrix, Repair. Retur dan VendorExternal
        _WSReceiveFGMixFromMergeSplitSKU = 4

        _WSInboundSKU = 10

        'ucWS24FP01INBOUND
        _WSInbound5021InhouseProduksi = 5021
        _WSInbound5022InhouseChain = 5022
        _WSInbound5023RepairWarehouse = 5023
        _WSInbound5024RepairCustomer = 5024
        _WSInbound5025ReturCustomer = 5025
        _WSInbound5026External = 5026
        _WSInbound5027BRJPinjamanMarketing = 5027
        _WSInbound5028ReturKAE = 5028
        _WSInbound5029ReturConsignment = 5029
        _WSPKBConsumeInbound3034 = 3034

        'INBOUND : BULK UPLOAD - XLS
        _WSInboundFromXLS10122024ReturCustomer = 101
        _WSInboundFromXLS11022025ReparasiWarehouse = 102
    End Enum

#Region "form and control - event"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
    End Sub

#End Region

#Region " public - method "

    Public Sub _pbSetting01ReceiveDOFinishGoods()
        _rsRepoSettingFGFromCitrix()
        _cc01CaptionReceiveFGFromCitrix()
        _vs01VisibilityReceiveFGFromCitrix()
        _vs02VisibilityIndexReceiveFGFromCitrix()
        _wr01WriteReceiveFGFromCitrix()
        _ll01LainLainFGFromCitrix()
    End Sub

    Public Sub _pbSetting02InboundSKU()
        _rsRepoSettingInboundSKU()
        _cc01CaptionInboundSKU()
        _vs01VisibilityInboundSKU()
        _vs02VisibilityIndexInboundSKU()
        _wr01WriteInboundSKU()
        _tot01TotalBeratDanLotInboundSKU()
        _sz01SizeWidthColInboundSKU()
        _ll01LainLainInboundSKU()
    End Sub

    Public Sub _pbSetting03MergeSplitSKU()
        _cc01CaptionMergeSplitSKU()
        _vs01VisibilityMergeSplitSKU()
        _vs02VisibilityIndexMergeSplitSKU()
        _wr01WriteMergeSplitSKU()
        _tot01TotPcsDanBeratMergeSplitSKU()
        _ll01LainLainMergeSplitSKU()
    End Sub

    Public Sub _pbCallSetting20WS24FP01INBOUND()
        Select Case _prop01cTargetINBOUND
            Case TargetINBOUND._WSInbound5021InhouseProduksi
                _cmCallSetting5021InhouseProduksi()

            Case TargetINBOUND._WSInbound5022InhouseChain
                _cmCallSetting5022InhouseChain()

            Case TargetINBOUND._WSInbound5023RepairWarehouse
                _cmCallSetting5023RepairWarehouse()

            Case TargetINBOUND._WSInbound5024RepairCustomer

            Case TargetINBOUND._WSInbound5025ReturCustomer
                _cmCallSetting5025ReturCustomer()

            Case TargetINBOUND._WSInbound5026External
                _cmCallSetting5026VendorExternal()

            Case TargetINBOUND._WSInbound5027BRJPinjamanMarketing
                _cmCallSetting5027BRJPinjamanMarketing()

            Case TargetINBOUND._WSInbound5028ReturKAE
                _cmCallSetting5028ReturKAE()

            Case TargetINBOUND._WSInbound5029ReturConsignment
                _cmCallSetting5029ReturConsignment()

            Case TargetINBOUND._WSPKBConsumeInbound3034
                _cmCallSetting3034PKBConsumeInbound()

        End Select
    End Sub

    Public Sub _pbCallSetting21WS24LD01BULKUPLOADXLS()
        Select Case _prop01cTargetINBOUND
            Case TargetINBOUND._WSInboundFromXLS10122024ReturCustomer
                _cmCallSetting101BulkUploadXLSIRC()

            Case TargetINBOUND._WSInboundFromXLS11022025ReparasiWarehouse
                _cmCallSetting102BulkUploadXLSIRPWS()

        End Select
    End Sub
#End Region

    '******* RETIRED *******
    '***********************

#Region "***** Receive DO FinishGoods From Citrix *****"

    Private _rscolf01Memo As repoWS03Picture
    'Private _rscolf27String As repoWS05Master
    'Private _rscolf28String As repoWS05Master

    Private Sub _rsRepoSettingFGFromCitrix()
        Dim pdtSLoc As New DataTable
        pdtSLoc = _prop05DataTableMaster.Copy()

        Dim pdtBox As New DataTable
        pdtBox = _prop04DataTableMaster.Copy()

        _rscolf01Memo = New repoWS03Picture()
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

            ._colf01Memo.ColumnEdit = _rscolf01Memo
            '._colf27String.ColumnEdit = _rscolf27String
            '._colf28String.ColumnEdit = _rscolf28String
        End With
    End Sub

    Private Sub _cc01CaptionReceiveFGFromCitrix()
        With _prop03Grid
            ._colf01Memo.Caption = "Picture"
            ._colf01String.Caption = "DO"              'No.DO
            ._colk02String.Caption = "SKUVendor"       'SKUVendor
            ._colk03String.Caption = "ProductCode"     'ProductCode
            ._colf05String.Caption = "NORO"            'NORO
            ._colf14String.Caption = "Brand"           'Brand/Segment
            ._colf11String.Caption = "TipeBRJ"         'Tipe BRJ
            ._colf07String.Caption = "Warna"           'Warna
            ._colf12String.Caption = "Size"            'Size
            ._colf09String.Caption = "Kadar"           'Kadar
            ._colf22String.Caption = "TypeOrder"       'TypeOrder

            ._colk00Boolean.Caption = "Warna OK ?"
            ._colk00Boolean01.Caption = "Size OK ?"
            ._colf01TinyInt.Caption = "Bundling"
            '._colf27String.Caption = "SLoc"
            '._colf28String.Caption = "Box"

            ._colf01SmallInt.Caption = "TPcs"          'TPcs
            ._colf01Double.Caption = "TBeratGross"     'TBerat Gross
            ._colf01Date.Caption = "TglVendor"         'TglReceiveDataFGDariVendor

            ._colf01Memo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colf01String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colk02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ._colk03String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        End With
    End Sub

    Private Sub _vs01VisibilityReceiveFGFromCitrix()
        With _prop03Grid
            ._colf01String.Visible = True     'No.DO
            ._colk02String.Visible = True     'SKUVendor
            ._colk03String.Visible = True     'ProductCode
            ._colf05String.Visible = True     'NORO
            ._colf14String.Visible = True     'Brand/Segment
            ._colf11String.Visible = True     'Tipe BRJ
            ._colf07String.Visible = True     'Warna
            ._colf12String.Visible = True     'Size
            ._colf09String.Visible = True     'Kadar
            ._colf22String.Visible = True     'TypeOrder
            ._colk00Boolean.Visible = True    '"Warna OK ?"
            ._colk00Boolean01.Visible = True  '"Size OK ?"
            ._colf01TinyInt.Visible = True    '"Bundling"
            ._colf01Memo.Visible = True       '"Picture"
            '._colf27String.Visible = True     '"SLoc"
            '._colf28String.Visible = True     '"Box"
            ._colf01SmallInt.Visible = True   'TPcs
            ._colf01Double.Visible = True     'TBerat Gross
            ._colf01Date.Visible = True       'TglReceiveDataFGDariVendor
        End With

    End Sub

    Private Sub _vs02VisibilityIndexReceiveFGFromCitrix()
        With _prop03Grid
            ._colf01Memo.VisibleIndex = 0       '"Picture"
            ._colf01String.VisibleIndex = 1     'No.DO
            ._colk02String.VisibleIndex = 2     'SKUVendor
            ._colk03String.VisibleIndex = 3     'ProductCode
            ._colf01Double.VisibleIndex = 4     'TBerat Gross
            ._colf01SmallInt.VisibleIndex = 5   'TPcs
            ._colf09String.VisibleIndex = 6     'Kadar
            ._colf22String.VisibleIndex = 7     'TypeOrder
            ._colf01TinyInt.VisibleIndex = 8    'Bundling
            ._colf07String.VisibleIndex = 9     'Warna
            ._colk00Boolean.VisibleIndex = 10   'Warna OK ?
            ._colf12String.VisibleIndex = 11    'Size
            ._colk00Boolean01.VisibleIndex = 12 'Size OK ?
            '._colf27String.VisibleIndex = 13    'SLoc
            '._colf28String.VisibleIndex = 12   'Box
            ._colf05String.VisibleIndex = 14    'NORO
            ._colf14String.VisibleIndex = 15    'Brand/Segment
            ._colf11String.VisibleIndex = 16    'Tipe BRJ
            ._colf01Date.VisibleIndex = 17      'TglReceiveDataFGDariVendor
        End With
    End Sub

    Private Sub _wr01WriteReceiveFGFromCitrix()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False     'Warna OK ?
            ._colk00Boolean01.OptionsColumn.ReadOnly = False   'Size OK ?
            ._colf01TinyInt.OptionsColumn.ReadOnly = False     '"Bundling"
            '._colf27String.OptionsColumn.ReadOnly = True       '"SLoc"
            '._colf28String.OptionsColumn.ReadOnly = False      '"Box"
        End With
    End Sub

    Private Sub _ll01LainLainFGFromCitrix()

        With _prop03Grid
            With ._colk00Boolean     'Warna OK ?
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With

            With ._colk00Boolean01   'Size OK ?
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With

            With ._colf01TinyInt     '"Bundling"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With

            'With ._colf28String      '"Box"
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With
        End With

    End Sub

#End Region

#Region "***** Inbound SKU *****"

    Private _rscolk02String As repoWS05Master
    Private _rscolk03String As repoWS05Master

    Private Sub _rsRepoSettingInboundSKU()
        Dim pdtSLoc As New DataTable
        pdtSLoc = _prop05DataTableMaster.Copy()

        Dim pdtBox As New DataTable
        pdtBox = _prop04DataTableMaster.Copy()

        _rscolk02String = New repoWS05Master With {._prop_01dtWSNasaMaster = pdtSLoc,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._01SLOC}
        _rscolk02String._01WSNasaBindingDataSource()   'SLOC

        _rscolk03String = New repoWS05Master With {._prop_01dtWSNasaMaster = pdtBox,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX}
        _rscolk03String._01WSNasaBindingDataSource()
        _rscolk03String._02WSNasaFilterGroupMaster("k11String", "SBOX")

        With _prop03Grid
            .GridView1.OptionsView.ColumnAutoWidth = False
            .GridView1.OptionsView.RowAutoHeight = True
            .GridView1.BestFitColumns()

            ._colk02String.ColumnEdit = _rscolk02String
            ._colk03String.ColumnEdit = _rscolk03String
        End With
    End Sub

    Private Sub _cc01CaptionInboundSKU()
        With _prop03Grid
            ._colk01String.Caption = "SKU"     'SKU
            '._colk02String.Caption = "SLoc"     'Nama SLoc
            '._colk03String.Caption = "Box"     'Nama Box
            ._colf01TinyInt.Caption = "Pcs"    'Pcs
            ._colf01Double.Caption = "Gross"     'Berat
        End With
    End Sub

    Private Sub _vs01VisibilityInboundSKU()
        With _prop03Grid
            ._colk01String.Visible = True  'SKU
            '._colk02String.Visible = True  'Nama SLoc
            '._colk03String.Visible = True  'Nama Box
            ._colf01TinyInt.Visible = True  'Pcs
            ._colf01Double.Visible = True  'Berat
        End With
    End Sub

    Private Sub _vs02VisibilityIndexInboundSKU()
        With _prop03Grid
            ._colk01String.VisibleIndex = 0  'SKU
            ._colf01TinyInt.VisibleIndex = 1  'Pcs
            ._colf01Double.VisibleIndex = 2  'Berat
            '._colk02String.VisibleIndex = 3  'Nama SLoc
            '._colk03String.VisibleIndex = 4  'Nama Box
        End With
    End Sub

    Private Sub _wr01WriteInboundSKU()
        'With _prop03Grid
        '    ._colk02String.OptionsColumn.ReadOnly = False  'Nama SLoc
        '    ._colk03String.OptionsColumn.ReadOnly = False  'Nama Box
        'End With
    End Sub

    Private Sub _tot01TotalBeratDanLotInboundSKU()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01TinyInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01TinyInt").SummaryItem.FieldName = "f01TinyInt"
            .Columns("f01TinyInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _sz01SizeWidthColInboundSKU()
        With _prop03Grid
            ._colk01String.Width = 120     'SKU
            '._colk02String.Width = 140     'SLoc
            '._colk03String.Width = 100     'Box
            ._colf01TinyInt.Width = 40    'Pcs
            ._colf01Double.Width = 60     'Berat
        End With
    End Sub

    Private Sub _ll01LainLainInboundSKU()

        'With _prop03Grid
        '    With ._colk02String      '"SLoc"
        '        .AppearanceHeader.BackColor = Color.Gold
        '        .AppearanceCell.BackColor = Color.LightYellow
        '    End With

        '    With ._colk03String      '"Box"
        '        .AppearanceHeader.BackColor = Color.Gold
        '        .AppearanceCell.BackColor = Color.LightYellow
        '    End With
        'End With

    End Sub

#End Region

    '******* END - RETIRED *******
    '*****************************

#Region "***** Merge & Split SKU *****"
    '******************************************************
    '********************** NOT USED **********************
    '******************************************************
    'Private Sub _rsRepoSettingMergeSplitSKU()
    '    _rscolf01Memo = New repoWS03Picture()
    '    With _prop03Grid
    '        .GridView1.OptionsView.ColumnAutoWidth = False
    '        .GridView1.OptionsView.RowAutoHeight = True
    '        .GridView1.BestFitColumns()

    '        ._colf01Memo.ColumnEdit = _rscolf01Memo
    '    End With
    'End Sub
    '******************************************************
    '********************** NOT USED **********************
    '******************************************************

    Private Sub _cc01CaptionMergeSplitSKU()
        With _prop03Grid
            ._colk02String.Caption = "SKU Baru"
            ._colk03String.Caption = "SKU Asal"
            ._colf09String.Caption = "Box"
            ._colf01SmallInt.Caption = "Pcs Asal"
            ._colf01Double.Caption = "Berat Asal"
            ._colf01Int.Caption = "Pcs Proses"
            ._colf02Double.Caption = "Berat Proses"
        End With
    End Sub

    Private Sub _vs01VisibilityMergeSplitSKU()
        With _prop03Grid
            ._colk02String.Visible = True     '"SKU Baru"
            ._colk03String.Visible = True     '"SKU"
            ._colf09String.Visible = True     '"Box"
            ._colf01SmallInt.Visible = True   '"Pcs Asal"
            ._colf01Double.Visible = True     '"Berat Asal"
            ._colf01Int.Visible = True        '"Pcs Proses"
            ._colf02Double.Visible = True     '"Berat Proses"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexMergeSplitSKU()
        With _prop03Grid
            ._colk02String.VisibleIndex = 0     '"SKU Baru"
            ._colk03String.VisibleIndex = 1     '"SKU"
            ._colf09String.VisibleIndex = 2     '"Box"
            ._colf01SmallInt.VisibleIndex = 3   '"Pcs Asal"
            ._colf01Double.VisibleIndex = 4     '"Berat Asal"
            ._colf01Int.VisibleIndex = 5        '"Pcs Proses"
            ._colf02Double.VisibleIndex = 6     '"Berat Proses"
        End With
    End Sub

    Private Sub _wr01WriteMergeSplitSKU()
        With _prop03Grid
            ._colk02String.OptionsColumn.ReadOnly = True     '"SKU Baru"
            ._colk03String.OptionsColumn.ReadOnly = True     '"SKU"
            ._colf09String.OptionsColumn.ReadOnly = True     '"Box"
            ._colf01SmallInt.OptionsColumn.ReadOnly = True   '"Pcs Asal"
            ._colf01Double.OptionsColumn.ReadOnly = True     '"Berat Asal"
            ._colf01Int.OptionsColumn.ReadOnly = True        '"Pcs Proses"
            ._colf02Double.OptionsColumn.ReadOnly = True     '"Berat Proses"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratMergeSplitSKU()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Int").SummaryItem.FieldName = "f01Int"
            .Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f02Double").SummaryItem.FieldName = "f02Double"
            .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainMergeSplitSKU()
        With _prop03Grid

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

            With ._colf01Int
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With

            With ._colf02Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With

        End With

    End Sub

#End Region

#Region "***** ucWS24FP01INBOUND *****"

    Private Sub _cmCallSetting5021InhouseProduksi()
        _cc01CaptionInhouseProduksi()
        _wd240707WidthInboundInhouseProduksi()
        _vs01VisibilityInhouseProduksi()
        _vs02VisibilityIndexInhouseProduksi()
        _wr01WriteInhouseProduksi()
        _tot01TotPcsDanBeratInhouseProduksi()
        _ll01LainLainInhouseProduksi()
    End Sub

    Private Sub _cmCallSetting5022InhouseChain()
        _cc01CaptionInhouseChain()
        _vs01VisibilityInhouseChain()
        _vs02VisibilityIndexInhouseChain()
        _wr01WriteInhouseChain()
        _tot01TotPcsDanBeratInhouseChain()
        _ll01LainLainInhouseChain()
    End Sub

    Private Sub _cmCallSetting5023RepairWarehouse()
        _cc01RepoSettingReparasiWarehouse()
        _cc01CaptionRepairWarehouse()
        _vs01VisibilityRepairWarehouse()
        _vs02VisibilityIndexRepairWarehouse()
        _wr01WriteRepairWarehouse()
        _tot01TotPcsDanBeratRepairWarehouse()
        _ll01LainLainRepairWarehouse()
    End Sub

    'Private Sub _cmCallSetting5023RepairWarehouse()

    '    _cc01CaptionRepairCustomer()
    '    _vs01VisibilityRepairCustomer()
    '    _vs02VisibilityIndexRepairCustomer()
    '    _wr01WriteRepairCustomer()
    '    _tot01TotPcsDanBeratRepairCustomer()
    '    _ll01LainLainRepairCustomer()
    'End Sub

    Private Sub _cmCallSetting5025ReturCustomer()
        _cc01CaptionReturCustomer()
        _vs01VisibilityReturCustomer()
        _vs02VisibilityIndexReturCustomer()
        _wr01WriteReturCustomer()
        _tot01TotPcsDanBeratReturCustomer()
        _ll01LainLainReturCustomer()
    End Sub

    Private Sub _cmCallSetting5026VendorExternal()
        _cc01CaptionVendorExternal()
        _vs01VisibilityVendorExternal()
        _vs02VisibilityIndexVendorExternal()
        _wr01WriteVendorExternal()
        _tot01TotPcsDanBeratVendorExternal()
        _ll01LainLainVendorExternal()
    End Sub

    Private Sub _cmCallSetting5027BRJPinjamanMarketing()
        _cc01CaptionBRJPinjamanMarketing()
        _vs01VisibilityBRJPinjamanMarketing()
        _vs02VisibilityIndexBRJPinjamanMarketing()
        _wr01WriteBRJPinjamanMarketing()
        _tot01TotPcsDanBeratBRJPinjamanMarketing()
        _ll01LainLainBRJPinjamanMarketing()
    End Sub

    Private Sub _cmCallSetting5028ReturKAE()
        _cc01CaptionReturKAE()
        _vs01VisibilityReturKAE()
        _vs02VisibilityIndexReturKAE()
        _wr01WriteReturKAE()
        _tot01TotPcsDanBeratReturKAE()
        _ll01LainLainReturKAE()
        _wd240707WidthReturKAE()
    End Sub

    Private Sub _cmCallSetting5029ReturConsignment()
        _cc01CaptionReturConsignment()
        _vs01VisibilityReturConsignment()
        _vs02VisibilityIndexReturConsignment()
        _wr01WriteReturConsignment()
        _tot01TotPcsDanBeratReturConsignment()
        _ll01LainLainReturConsignment()
        _wd240707WidthReturCONSIGNMENT()
    End Sub

    Private Sub _cmCallSetting3034PKBConsumeInbound()
        _cc01CaptionPKBConsumeInbound()
        _vs01VisibilityPKBConsumeInbound()
        _vs02VisibilityIndexPKBConsumeInbound()
        _wr01WritePKBConsumeInbound()
        _ll01LainLainPKBConsumeInbound()
        _wd240707WidthucWS24IX01PKBCONSUMEINBOUND()
    End Sub

#Region "5021 - Inhouse-Produksi"

    Private _rscolf36String As repoWS05Master
    Private Sub _cc01CaptionInhouseProduksi()
        With _prop07RepoMasterDelegate
            ._prop_01dtWSNasaMaster = _prop06DataTableMaster
            ._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX
        End With
        _prop07RepoMasterDelegate._01WSNasaBindingDataSource()

        '_rscolf36String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop06DataTableMaster,
        '._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX}
        '_rscolf36String._01WSNasaBindingDataSource()

        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colf01Date.Caption = "Tgl.DO"
            ._colk02String.Caption = "SKU"
            ._colf01String.Caption = "ProductCode"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf12String.Caption = "Item"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf08String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf06String.Caption = "No.RO"

            ._colf38String.Caption = "ReservedOrder"

            '._colf36String.ColumnEdit = _rscolf36String
            ._colf36String.ColumnEdit = _prop07RepoMasterDelegate
            ._colf36String.Caption = "Box"
        End With
    End Sub

    Private Sub _vs01VisibilityInhouseProduksi()
        With _prop03Grid
            ._colk00Boolean.Visible = True     '"#"
            ._colf36String.Visible = True     '"SBox"
            ._colf01Date.Visible = True     '"Tgl.Document"
            ._colk02String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"ProductCode"
            ._colf01SmallInt.Visible = True     '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf12String.Visible = True     '"Item"
            ._colf16String.Visible = True     '"Brand"
            ._colf10String.Visible = True     '"Kadar"
            ._colf08String.Visible = True     '"Warna"
            ._colf14String.Visible = True     '"Size"
            ._colf06String.Visible = True     '"NO/RO"
            ._colf38String.Visible = True     '"ReservedPKB"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexInhouseProduksi()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0     '"#"
            ._colf36String.VisibleIndex = 1      '"SBox"
            ._colf38String.VisibleIndex = 2      '"ReservedPKB"
            ._colk02String.VisibleIndex = 3      '"SKU"
            ._colf01String.VisibleIndex = 4      '"ProductCode"
            ._colf10String.VisibleIndex = 5      '"Kadar"
            ._colf16String.VisibleIndex = 6      '"Brand"
            ._colf12String.VisibleIndex = 7      '"Item"
            ._colf08String.VisibleIndex = 8     '"Warna"
            ._colf14String.VisibleIndex = 9     '"Size"
            ._colf06String.VisibleIndex = 10     '"NO/RO"
            ._colf01SmallInt.VisibleIndex = 11    '"Pcs"
            ._colf01Double.VisibleIndex = 12      '"Berat"
            ._colf01Date.VisibleIndex = 13        '"Tgl.Document"

        End With
    End Sub

    Private Sub _wr01WriteInhouseProduksi()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False     '"#"
            ._colf36String.OptionsColumn.ReadOnly = False      '"SBox"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratInhouseProduksi()
        'With _prop03Grid.GridView1
        '    .OptionsView.ShowFooter = True

        '    .Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f01Int").SummaryItem.FieldName = "f01Int"
        '    .Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        '    .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f02Double").SummaryItem.FieldName = "f02Double"
        '    .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        'End With
    End Sub

    Private Sub _ll01LainLainInhouseProduksi()
        With _prop03Grid
            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf36String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf38String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

        End With
    End Sub

    Private Sub _wd240707WidthInboundInhouseProduksi()
        With _prop03Grid
            ._colk00Boolean.Width = 42
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 92
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 92
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 92
            ._colk01String.Width = 92
            ._colk02String.Width = 100
            ._colk03String.Width = 92
            ._colf01String.Width = 97
            ._colf02String.Width = 92
            ._colf03String.Width = 92
            ._colf04String.Width = 92
            ._colf05String.Width = 98
            ._colf06String.Width = 98
            ._colf07String.Width = 98
            ._colf08String.Width = 98
            ._colf09String.Width = 98
            ._colf10String.Width = 98
            ._colf11String.Width = 98
            ._colf12String.Width = 98
            ._colf13String.Width = 98
            ._colf14String.Width = 98
            ._colf15String.Width = 98
            ._colf16String.Width = 98
            ._colf17String.Width = 98
            ._colf18String.Width = 98
            ._colf19String.Width = 98
            ._colf20String.Width = 98
            ._colf21String.Width = 98
            ._colf22String.Width = 98
            ._colf23String.Width = 98
            ._colf24String.Width = 98
            ._colf25String.Width = 98
            ._colf26String.Width = 98
            ._colf27String.Width = 98
            ._colf28String.Width = 98
            ._colf29String.Width = 98
            ._colf30String.Width = 98
            ._colf31String.Width = 98
            ._colf32String.Width = 92
            ._colf33String.Width = 92
            ._colf34String.Width = 92
            ._colf35String.Width = 92
            ._colf36String.Width = 107
            ._colf37String.Width = 92
            ._colf38String.Width = 92
            ._colf39String.Width = 92
            ._colf40String.Width = 92
            ._colf01TinyInt.Width = 98
            ._colf01SmallInt.Width = 36
            ._colf01Int.Width = 98
            ._colf01Double.Width = 59
            ._colf02Double.Width = 98
            ._colf03Double.Width = 98
            ._colf01Date.Width = 83
            ._colf02Date.Width = 98
            ._colf03Date.Width = 92
        End With
    End Sub

#End Region

#Region "5022 - Inhouse-Chain"

    Private Sub _cc01CaptionInhouseChain()
        With _prop03Grid
            ._colk02String.Caption = "SKU"
            ._colf01Double.Caption = "Gr.Gross"
            ._colf02Double.Caption = "Gr.Nett"

            ._colk02String.Width = 125
        End With
    End Sub

    Private Sub _vs01VisibilityInhouseChain()
        With _prop03Grid
            ._colk02String.Visible = True     '"SKU"
            ._colf01Double.Visible = True     '"Wt.Gross"
            ._colf02Double.Visible = True     '"Wt.Nett"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexInhouseChain()
        With _prop03Grid
            ._colk02String.VisibleIndex = 0     '"SKU"
            ._colf01Double.VisibleIndex = 1     '"Wt.Gross"
            ._colf02Double.VisibleIndex = 2     '"Wt.Nett"
        End With
    End Sub

    Private Sub _wr01WriteInhouseChain()
        With _prop03Grid
            ._colk02String.OptionsColumn.ReadOnly = True     '"SKU"
            ._colf01Double.OptionsColumn.ReadOnly = True     '"Wt.Gross"
            ._colf02Double.OptionsColumn.ReadOnly = True     '"Wt.Nett"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratInhouseChain()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

            .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f02Double").SummaryItem.FieldName = "f02Double"
            .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainInhouseChain()
        With _prop03Grid
            With ._colf01Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf02Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

        End With

    End Sub
#End Region

#Region "5023 - Repair-Warehouse"
    Private _rscolf08String As repoWS05Master
    Private _rscolf30String As repoWS05Master
    Private _rscolf31String As repoWS05Master
    Private _rscolf32String As repoWS05Master

    Private Sub _cc01RepoSettingReparasiWarehouse()
        _rscolf08String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop06DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX}
        _rscolf08String._01WSNasaBindingDataSource()

        _rscolf30String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop04DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._04BRAND}
        _rscolf30String._01WSNasaBindingDataSource()
        _rscolf30String._02WSNasaFilterGroupMaster("f02cKodeMaster_v50", "BRAND")

        _rscolf31String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop04DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._05COLOR}
        _rscolf31String._01WSNasaBindingDataSource()
        _rscolf31String._02WSNasaFilterGroupMaster("f02cKodeMaster_v50", "COLOR")

        _rscolf32String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop05DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._06SIZE}
        _rscolf32String._01WSNasaBindingDataSource()

        With _prop03Grid
            .GridView1.OptionsView.ColumnAutoWidth = False
            .GridView1.OptionsView.RowAutoHeight = True
            .GridView1.BestFitColumns()

            ._colf30String.ColumnEdit = _rscolf30String
            ._colf31String.ColumnEdit = _rscolf31String
            ._colf32String.ColumnEdit = _rscolf32String
            ._colf08String.ColumnEdit = _rscolf08String
        End With
    End Sub

    Private Sub _cc01CaptionRepairWarehouse()
        With _prop03Grid
            ._colk03String.Caption = "SKU"
            ._colf01String.Caption = "ProductCode"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf12String.Caption = "Item"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf28String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf04String.Caption = "Vendor"
            ._colf03Date.Caption = "Tgl.Repair"
            ._colf02String.Caption = "No.Doc"

            ._colf01Int.Caption = "Pcs"
            ._colf02Double.Caption = "Gr.Gross"
            ._colf03Double.Caption = "Gr.Nett"
            ._colf30String.Caption = "Brand"
            ._colf31String.Caption = "Warna"
            ._colf32String.Caption = "Size"
            ._colf08String.Caption = "Box"
        End With
    End Sub

    Private Sub _vs01VisibilityRepairWarehouse()
        With _prop03Grid
            ._colk03String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"ProductCode"
            ._colf01SmallInt.Visible = True     '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf12String.Visible = True     '"Item"
            ._colf16String.Visible = True     '"Brand"
            ._colf10String.Visible = True     '"Kadar"
            ._colf28String.Visible = True     '"Warna"
            ._colf14String.Visible = True     '"Size"
            ._colf04String.Visible = True     '"Vendor"
            ._colf03Date.Visible = True     '"Tgl.Repair"
            ._colf02String.Visible = True     '"No.Doc"

            ._colf01Int.Visible = True     '"Pcs"
            ._colf02Double.Visible = True     '"Berat"
            ._colf03Double.Visible = True     '"W.Nett"
            ._colf30String.Visible = True     '"Brand"
            ._colf31String.Visible = True     '"Warna"
            ._colf32String.Visible = True     '"Size"
            ._colf08String.Visible = True     '"SBox"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexRepairWarehouse()
        With _prop03Grid
            ._colk03String.VisibleIndex = 0     '"SKU"
            ._colf01String.VisibleIndex = 1     '"ProductCode"
            ._colf01Int.VisibleIndex = 2     '"Pcs"
            ._colf02Double.VisibleIndex = 3     '"Berat"
            ._colf03Double.VisibleIndex = 4     '"W.Nett"
            ._colf32String.VisibleIndex = 5     '"Size"
            ._colf31String.VisibleIndex = 6     '"Warna"
            ._colf30String.VisibleIndex = 7     '"Brand"
            ._colf08String.VisibleIndex = 8     '"SBox"

            ._colf01SmallInt.VisibleIndex = 9     '"Pcs"
            ._colf01Double.VisibleIndex = 10     '"Berat"
            ._colf12String.VisibleIndex = 11     '"Item"
            ._colf16String.VisibleIndex = 12     '"Brand"
            ._colf10String.VisibleIndex = 13     '"Kadar"
            ._colf28String.VisibleIndex = 14     '"Warna"
            ._colf14String.VisibleIndex = 15     '"Size"
            ._colf04String.VisibleIndex = 16     '"Vendor"
            ._colf03Date.VisibleIndex = 17     '"Tgl.Repair"
            ._colf02String.VisibleIndex = 18     '"No.Doc"
        End With
    End Sub

    Private Sub _wr01WriteRepairWarehouse()
        With _prop03Grid
            ._colf01Int.OptionsColumn.ReadOnly = False     '"Pcs"
            ._colf02Double.OptionsColumn.ReadOnly = False     '"Berat"
            ._colf03Double.OptionsColumn.ReadOnly = False     '"W.Nett"
            ._colf32String.OptionsColumn.ReadOnly = False     '"Size"
            ._colf31String.OptionsColumn.ReadOnly = False     '"Warna"
            ._colf30String.OptionsColumn.ReadOnly = False     '"Brand"
            ._colf08String.OptionsColumn.ReadOnly = False     '"SBox"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratRepairWarehouse()
        'With _prop03Grid.GridView1
        '    .OptionsView.ShowFooter = True

        '    .Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f01Int").SummaryItem.FieldName = "f01Int"
        '    .Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        '    .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f02Double").SummaryItem.FieldName = "f02Double"
        '    .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        'End With
    End Sub

    Private Sub _ll01LainLainRepairWarehouse()
        With _prop03Grid
            With ._colf01Int
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf02Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf03Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf08String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf30String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf31String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf32String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
        End With

    End Sub

#End Region

#Region "5025 - Retur-Customer"

    Private _rscolf33String As repoWS07ComboBox

    Private Sub _cc01CaptionReturCustomer()
        _rscolf08String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop06DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX}
        _rscolf08String._01WSNasaBindingDataSource()

        Dim pcProsesReturCustomer = New String() {"WAREHOUSE", "REPAIR"}
        _rscolf33String = New repoWS07ComboBox With {._prop01Data = pcProsesReturCustomer}
        _rscolf33String.__pb01InitRepoComboBox()

        With _prop03Grid
            ._colk03String.Caption = "SKU"
            ._colf01String.Caption = "ProductCode"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Gram"
            ._colf12String.Caption = "Item"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf28String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf04String.Caption = "Vendor"
            ._colf03Date.Caption = "Tgl.Sold"
            ._colf02String.Caption = "No.Doc"

            ._colf33String.ColumnEdit = _rscolf33String
            ._colf33String.Caption = "Tujuan"

            ._colf01Int.Caption = "Qty"
            ._colf02Double.Caption = "Gr.Gross"
            ._colf03Double.Caption = "Gr.Nett"

            ._colf08String.ColumnEdit = _rscolf08String
            ._colf08String.Caption = "BOX"
            ._colf34String.Caption = "ALASAN"
        End With
    End Sub

    Private Sub _vs01VisibilityReturCustomer()
        With _prop03Grid
            ._colk03String.Visible = True      '"SKU"
            ._colf01String.Visible = True      '"ProductCode"
            ._colf01SmallInt.Visible = True    '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf12String.Visible = True     '"Item"
            ._colf16String.Visible = True     '"Brand"
            ._colf10String.Visible = True     '"Kadar"
            ._colf28String.Visible = True     '"Warna"
            ._colf14String.Visible = True     '"Size"
            ._colf04String.Visible = True     '"Vendor"
            ._colf03Date.Visible = True     '"Tgl.Sold"
            ._colf02String.Visible = True     '"No.Doc"
            ._colf33String.Visible = True     '"NextProses"

            ._colf01Int.Visible = True        '"Pcs"
            ._colf02Double.Visible = True     '"W.Gross"
            ._colf03Double.Visible = True     '"W.Nett"
            ._colf08String.Visible = True     '"SBOX"
            ._colf34String.Visible = True     '"ALASAN"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexReturCustomer()
        With _prop03Grid
            ._colk03String.VisibleIndex = 1      '"SKU"
            ._colf33String.VisibleIndex = 2     '"NextProses"
            ._colf08String.VisibleIndex = 3     '"SBOX"
            ._colf01Int.VisibleIndex = 4        '"Pcs"
            ._colf02Double.VisibleIndex = 5     '"W.Gross"
            ._colf03Double.VisibleIndex = 6     '"W.Nett"
            ._colf34String.VisibleIndex = 7     '"ALASAN"
            ._colf03Date.VisibleIndex = 8       '"Tgl.Sold"
            ._colf02String.VisibleIndex = 9     '"No.Doc"
            ._colf01String.VisibleIndex = 10      '"ProductCode"
            ._colf01SmallInt.VisibleIndex = 11    '"Pcs"
            ._colf01Double.VisibleIndex = 12     '"Berat"
            ._colf12String.VisibleIndex = 13     '"Item"
            ._colf16String.VisibleIndex = 14     '"Brand"
            ._colf10String.VisibleIndex = 15     '"Kadar"
            ._colf28String.VisibleIndex = 16     '"Warna"
            ._colf14String.VisibleIndex = 17     '"Size"
            ._colf04String.VisibleIndex = 18     '"Vendor"
        End With
    End Sub

    Private Sub _wr01WriteReturCustomer()
        With _prop03Grid
            ._colf08String.OptionsColumn.ReadOnly = False     '"SBOX"
            ._colf33String.OptionsColumn.ReadOnly = False
            ._colf34String.OptionsColumn.ReadOnly = False     '"ALASAN"
            ._colf01Int.OptionsColumn.ReadOnly = False        '"Pcs"
            ._colf02Double.OptionsColumn.ReadOnly = False     '"W.Gross"
            ._colf03Double.OptionsColumn.ReadOnly = False     '"W.Nett"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratReturCustomer()
        'With _prop03Grid.GridView1
        '    .OptionsView.ShowFooter = True

        '    .Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f01Int").SummaryItem.FieldName = "f01Int"
        '    .Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        '    .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f02Double").SummaryItem.FieldName = "f02Double"
        '    .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        'End With
    End Sub

    Private Sub _ll01LainLainReturCustomer()
        With _prop03Grid
            'With ._colf01Int
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf02Double
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n2}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            With ._colf34String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf08String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf33String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf01Int
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf02Double
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf03Double
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

        End With

    End Sub

#End Region

#Region "5026 - External"

    Private Sub _cc01CaptionVendorExternal()
        With _prop03Grid
            ._colk02String.Caption = "SKU"
            ._colf01Double.Caption = "Gr.Gross"
            ._colf02Double.Caption = "Gr.Nett"

            ._colk02String.Width = 125
        End With
    End Sub

    Private Sub _vs01VisibilityVendorExternal()
        With _prop03Grid
            ._colk02String.Visible = True     '"SKU"
            ._colf01Double.Visible = True     '"Wt.Gross"
            ._colf02Double.Visible = True     '"Wt.Nett"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexVendorExternal()
        With _prop03Grid
            ._colk02String.VisibleIndex = 0     '"SKU"
            ._colf01Double.VisibleIndex = 1     '"Wt.Gross"
            ._colf02Double.VisibleIndex = 2     '"Wt.Nett"
        End With
    End Sub

    Private Sub _wr01WriteVendorExternal()
        With _prop03Grid
            ._colk02String.OptionsColumn.ReadOnly = True     '"SKU"
            ._colf01Double.OptionsColumn.ReadOnly = True     '"Wt.Gross"
            ._colf02Double.OptionsColumn.ReadOnly = True     '"Wt.Nett"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratVendorExternal()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

            .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f02Double").SummaryItem.FieldName = "f02Double"
            .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainVendorExternal()
        With _prop03Grid
            With ._colf01Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With

            With ._colf02Double
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With

        End With
    End Sub
#End Region

#Region "5027 - Retur MKT Pinjaman"

    Private Sub _cc01CaptionBRJPinjamanMarketing()
        _rscolf08String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop06DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX}
        _rscolf08String._01WSNasaBindingDataSource()

        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colk03String.Caption = "SKU"
            ._colf01String.Caption = "ProductCode"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf12String.Caption = "Item"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf28String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf04String.Caption = "Vendor"
            ._colf03Date.Caption = "Tgl.Pinjaman"
            ._colf02String.Caption = "No.Doc"

            ._colf08String.ColumnEdit = _rscolf08String
            ._colf08String.Caption = "Box"
        End With
    End Sub

    Private Sub _vs01VisibilityBRJPinjamanMarketing()
        With _prop03Grid
            ._colk00Boolean.Visible = True     '"#"
            ._colk03String.Visible = True      '"SKU"
            ._colf01String.Visible = True      '"ProductCode"
            ._colf01SmallInt.Visible = True    '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf12String.Visible = True     '"Item"
            ._colf16String.Visible = True     '"Brand"
            ._colf10String.Visible = True     '"Kadar"
            ._colf28String.Visible = True     '"Warna"
            ._colf14String.Visible = True     '"Size"
            ._colf04String.Visible = True     '"Vendor"
            ._colf03Date.Visible = True     '"Tgl.Pinjaman"
            ._colf02String.Visible = True     '"No.Doc"
            ._colf08String.Visible = True     '"SBOX"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexBRJPinjamanMarketing()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0     '"#"
            ._colf08String.VisibleIndex = 1     '"SBOX"
            ._colf02String.VisibleIndex = 2     '"No.Doc"
            ._colk03String.VisibleIndex = 3      '"SKU"
            ._colf01String.VisibleIndex = 4      '"ProductCode"
            ._colf10String.VisibleIndex = 5     '"Kadar"
            ._colf16String.VisibleIndex = 6     '"Brand"
            ._colf12String.VisibleIndex = 7     '"Item"
            ._colf28String.VisibleIndex = 8     '"Warna"
            ._colf14String.VisibleIndex = 9    '"Size"
            ._colf04String.VisibleIndex = 10     '"Vendor"
            ._colf01SmallInt.VisibleIndex = 11    '"Pcs"
            ._colf01Double.VisibleIndex = 12     '"Berat"
            ._colf03Date.VisibleIndex = 13     '"Tgl.Pinjaman"
        End With
    End Sub

    Private Sub _wr01WriteBRJPinjamanMarketing()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False
            ._colf08String.OptionsColumn.ReadOnly = False     '"SBOX"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratBRJPinjamanMarketing()
        'With _prop03Grid.GridView1
        '    .OptionsView.ShowFooter = True

        '    .Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f01Int").SummaryItem.FieldName = "f01Int"
        '    .Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        '    .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f02Double").SummaryItem.FieldName = "f02Double"
        '    .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        'End With
    End Sub

    Private Sub _ll01LainLainBRJPinjamanMarketing()
        With _prop03Grid
            'With ._colf01Int
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf02Double
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n2}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            With ._colf08String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

        End With

    End Sub

#End Region

#Region "*** 5028 - Retur KAE ***"

    Private Sub _cc01CaptionReturKAE()
        _rscolf08String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop06DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX}
        _rscolf08String._01WSNasaBindingDataSource()

        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colf08String.ColumnEdit = _rscolf08String
            ._colf08String.Caption = "Box"
            ._colf03Date.Caption = "Tgl.Mutasi"
            ._colf02String.Caption = "No.Order"
            ._colf01String.Caption = "ProductCode"
            ._colk03String.Caption = "SKU"
            ._colf12String.Caption = "Item"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf28String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
        End With
    End Sub

    Private Sub _vs01VisibilityReturKAE()
        With _prop03Grid
            ._colk00Boolean.Visible = True   '"#"
            ._colf08String.Visible = True   '"SBOX"
            ._colf03Date.Visible = True   '"Tgl.Mutasi"
            ._colf02String.Visible = True   '"No.Order"
            ._colf01String.Visible = True   '"ProductCode"
            ._colk03String.Visible = True   '"SKU"
            ._colf12String.Visible = True   '"Item"
            ._colf16String.Visible = True   '"Brand"
            ._colf10String.Visible = True   '"Kadar"
            ._colf28String.Visible = True   '"Warna"
            ._colf14String.Visible = True   '"Size"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True   '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexReturKAE()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0   '"#"
            ._colf08String.VisibleIndex = 1   '"SBOX"
            ._colf02String.VisibleIndex = 2   '"No.Order"
            ._colf01String.VisibleIndex = 3   '"ProductCode"
            ._colk03String.VisibleIndex = 4   '"SKU"
            ._colf10String.VisibleIndex = 5   '"Kadar"
            ._colf16String.VisibleIndex = 6   '"Brand"
            ._colf12String.VisibleIndex = 7   '"Item"
            ._colf28String.VisibleIndex = 8   '"Warna"
            ._colf14String.VisibleIndex = 9   '"Size"
            ._colf01SmallInt.VisibleIndex = 10   '"Pcs"
            ._colf01Double.VisibleIndex = 11   '"Berat"
            ._colf03Date.VisibleIndex = 12   '"Tgl.Mutasi"

        End With
    End Sub

    Private Sub _wr01WriteReturKAE()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False
            ._colf08String.OptionsColumn.ReadOnly = False     '"SBOX"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratReturKAE()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("k00Boolean").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("k00Boolean").SummaryItem.DisplayFormat = "{0:n0} Rows"

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainReturKAE()
        With _prop03Grid
            With ._colf08String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
            With ._colf03Date
                .AppearanceHeader.BackColor = Color.DeepPink
                .AppearanceCell.BackColor = Color.LightPink
            End With
            With ._colf02String
                .AppearanceHeader.BackColor = Color.Yellow
                .AppearanceCell.BackColor = Color.LightYellow
            End With
            With ._colf01String
                .AppearanceHeader.BackColor = Color.Green
                .AppearanceCell.BackColor = Color.LightGreen
            End With
            With ._colk03String
                .AppearanceHeader.BackColor = Color.Blue
                .AppearanceCell.BackColor = Color.LightBlue
            End With

        End With
    End Sub

    Private Sub _wd240707WidthReturKAE()
        With _prop03Grid

        End With
    End Sub

#End Region

#Region "*** 5029 - Retur Consignment ***"

    Private Sub _cc01CaptionReturConsignment()
        _rscolf08String = New repoWS05Master With {._prop_01dtWSNasaMaster = _prop06DataTableMaster,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._02BOX}
        _rscolf08String._01WSNasaBindingDataSource()

        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colf08String.ColumnEdit = _rscolf08String
            ._colf08String.Caption = "Box"
            ._colf03Date.Caption = "Tgl.Mutasi"
            ._colf02String.Caption = "No.Order"
            ._colf01String.Caption = "ProductCode"
            ._colk03String.Caption = "SKU"
            ._colf12String.Caption = "Item"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf28String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
        End With
    End Sub

    Private Sub _vs01VisibilityReturConsignment()
        With _prop03Grid
            ._colk00Boolean.Visible = True   '"#"
            ._colf08String.Visible = True   '"SBOX"
            ._colf03Date.Visible = True   '"Tgl.Mutasi"
            ._colf02String.Visible = True   '"No.Order"
            ._colf01String.Visible = True   '"ProductCode"
            ._colk03String.Visible = True   '"SKU"
            ._colf12String.Visible = True   '"Item"
            ._colf16String.Visible = True   '"Brand"
            ._colf10String.Visible = True   '"Kadar"
            ._colf28String.Visible = True   '"Warna"
            ._colf14String.Visible = True   '"Size"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True   '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexReturConsignment()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0   '"#"
            ._colf08String.VisibleIndex = 1   '"SBOX"
            ._colf02String.VisibleIndex = 2   '"No.Order"
            ._colf01String.VisibleIndex = 3   '"ProductCode"
            ._colk03String.VisibleIndex = 4   '"SKU"
            ._colf10String.VisibleIndex = 5   '"Kadar"
            ._colf16String.VisibleIndex = 6   '"Brand"
            ._colf12String.VisibleIndex = 7   '"Item"
            ._colf28String.VisibleIndex = 8   '"Warna"
            ._colf14String.VisibleIndex = 9   '"Size"
            ._colf01SmallInt.VisibleIndex = 10   '"Pcs"
            ._colf01Double.VisibleIndex = 11   '"Berat"
            ._colf03Date.VisibleIndex = 12   '"Tgl.Mutasi"

        End With
    End Sub

    Private Sub _wr01WriteReturConsignment()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False
            ._colf08String.OptionsColumn.ReadOnly = False     '"SBOX"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratReturConsignment()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("k00Boolean").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("k00Boolean").SummaryItem.DisplayFormat = "{0:n0} Rows"

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainReturConsignment()
        With _prop03Grid
            With ._colf08String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
            With ._colf03Date
                .AppearanceHeader.BackColor = Color.DeepPink
                .AppearanceCell.BackColor = Color.LightPink
            End With
            With ._colf02String
                .AppearanceHeader.BackColor = Color.Yellow
                .AppearanceCell.BackColor = Color.LightYellow
            End With
            With ._colf01String
                .AppearanceHeader.BackColor = Color.Green
                .AppearanceCell.BackColor = Color.LightGreen
            End With
            With ._colk03String
                .AppearanceHeader.BackColor = Color.Blue
                .AppearanceCell.BackColor = Color.LightBlue
            End With

        End With
    End Sub

    Private Sub _wd240707WidthReturCONSIGNMENT()
        With _prop03Grid

        End With
    End Sub

#End Region

#Region "***** PKB CONSUME INBUND *****"

    Private Sub _cc01CaptionPKBConsumeInbound()
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colf22String.Caption = "JenisOrder"
            ._colf01Date.Caption = "Tgl.Order"
            ._colk03String.Caption = "No.Order"
            ._colf15String.Caption = "Customer"
            ._colf01SmallInt.Caption = "Qty.Order"
            ._colf01Int.Caption = "Qty.OST"
        End With
    End Sub

    Private Sub _vs01VisibilityPKBConsumeInbound()
        With _prop03Grid
            ._colk00Boolean.Visible = True     '"#"
            ._colf22String.Visible = True      '"JenisOrder"
            ._colf01Date.Visible = True        '"Tgl.PKB"
            ._colk03String.Visible = True      '"No.PKB"
            ._colf15String.Visible = True      '"Customer"
            ._colf01SmallInt.Visible = True    '"Qty.PKB"
            ._colf01Int.Visible = True         '"Qty.OST"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexPKBConsumeInbound()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0     '"#"
            ._colf22String.VisibleIndex = 1      '"JenisOrder"
            ._colf01Date.VisibleIndex = 2        '"Tgl.PKB"
            ._colk03String.VisibleIndex = 3      '"No.PKB"
            ._colf15String.VisibleIndex = 4      '"Customer"
            ._colf01SmallInt.VisibleIndex = 5    '"Qty.PKB"
            ._colf01Int.VisibleIndex = 6         '"Qty.OST"
        End With
    End Sub

    Private Sub _wr01WritePKBConsumeInbound()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False     '"#"
        End With
    End Sub

    Private Sub _ll01LainLainPKBConsumeInbound()
        With _prop03Grid
            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With
        End With
    End Sub

    Private Sub _wd240707WidthucWS24IX01PKBCONSUMEINBOUND()
        With _prop03Grid
            ._colk00Boolean.Width = 37
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 79
            ._colk03String.Width = 136
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
            ._colf15String.Width = 281
            ._colf16String.Width = 85
            ._colf17String.Width = 85
            ._colf18String.Width = 85
            ._colf19String.Width = 85
            ._colf20String.Width = 85
            ._colf21String.Width = 85
            ._colf22String.Width = 68
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
            ._colf01SmallInt.Width = 64
            ._colf01Int.Width = 68
            ._colf01Double.Width = 85
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 95
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub

#End Region

#End Region

#Region "***** ucWS24LD01BULKUPLOADXLS *****"

    Private Sub _cmCallSetting101BulkUploadXLSIRC()
        _cc01CaptionIRC()
        _vs01VisibilityIRC()
        _vs02VisibilityIndexIRC()
        _wr01WriteIRC()
        _tot01TotPcsDanBeratIRC()
        _ll01LainLainIRC()
        _wd01SetLebarKolomIRC()
    End Sub

    Private Sub _cmCallSetting102BulkUploadXLSIRPWS()
        _cc01CaptionIRPWS()
        _vs01VisibilityIRPWS()
        _vs02VisibilityIndexIRPWS()
        _wr01WriteIRPWS()
        _tot01TotPcsDanBeratIRPWS()
        _ll01LainLainIRPWS()
        _wd01SetLebarKolomIRPWS()
    End Sub

#Region "101. BulkUpload XLS : Retur-Customer IRC"

    Private Sub _cc01CaptionIRC()

        With _prop03Grid
            ._colf34String.Caption = "No.DocInbound"
            ._colf22String.Caption = "Customer"
            ._colf01String.Caption = "ProductCode"
            ._colf36String.Caption = "OldSKU"
            ._colk02String.Caption = "NewSKU"

            ._colf40String.FieldName = "f51String"
            ._colf40String.Caption = "RootSKU"

            ._colf39String.FieldName = "f43String"
            ._colf39String.Caption = "Status"

            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Gram"

            ._colf12String.Caption = "Item"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf08String.Caption = "Warna"
            ._colf14String.Caption = "Size"

            ._colf20String.Caption = "Box"
            ._colf38String.Caption = "Tujuan"

            ._colf23String.Caption = "Alasan"
        End With
    End Sub

    Private Sub _vs01VisibilityIRC()
        With _prop03Grid
            ._colf34String.Visible = True      '"No.DocInbound"
            ._colf22String.Visible = True      '"Customer"
            ._colf01String.Visible = True      '"ProductCode"
            ._colf36String.Visible = True      '"SKU.LAMA"
            ._colk02String.Visible = True      '"SKU.BARU"
            ._colf01SmallInt.Visible = True    '"Pcs"
            ._colf01Double.Visible = True      '"Berat"

            ._colf12String.Visible = True      '"Item"
            ._colf16String.Visible = True      '"Brand"
            ._colf10String.Visible = True      '"Kadar"
            ._colf08String.Visible = True      '"Warna"
            ._colf14String.Visible = True      '"Size"

            ._colf20String.Visible = True      '"Box"
            ._colf38String.Visible = True      '"Tujuan"
            ._colf39String.Visible = True      '"Status"
            ._colf40String.Visible = True      '"RootSKU"
            ._colf23String.Visible = True      '"Alasan"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexIRC()
        With _prop03Grid
            ._colf34String.VisibleIndex = 0      '"No.DocInbound"
            ._colf22String.VisibleIndex = 1      '"Customer"
            ._colf01String.VisibleIndex = 2      '"ProductCode"
            ._colf36String.VisibleIndex = 3      '"SKU.LAMA"
            ._colk02String.VisibleIndex = 4      '"SKU.BARU"
            ._colf40String.VisibleIndex = 5      '"SKU ROOT"
            ._colf01SmallInt.VisibleIndex = 6      '"Pcs"
            ._colf01Double.VisibleIndex = 7      '"Berat"

            ._colf16String.VisibleIndex = 8      '"Brand"
            ._colf10String.VisibleIndex = 9      '"Kadar"
            ._colf12String.VisibleIndex = 10      '"Item"
            ._colf08String.VisibleIndex = 11      '"Warna"
            ._colf14String.VisibleIndex = 12      '"Size"

            ._colf20String.VisibleIndex = 13      '"Box"
            ._colf39String.VisibleIndex = 14      '"Status"
            ._colf38String.VisibleIndex = 15      '"Tujuan"
            ._colf23String.VisibleIndex = 16      '"Alasan"
        End With
    End Sub

    Private Sub _wr01WriteIRC()
        With _prop03Grid
            ._colf08String.OptionsColumn.ReadOnly = True     '"SBOX"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratIRC()
        'With _prop03Grid.GridView1
        '    .OptionsView.ShowFooter = True

        '    .Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f01Int").SummaryItem.FieldName = "f01Int"
        '    .Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        '    .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    .Columns("f02Double").SummaryItem.FieldName = "f02Double"
        '    .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        'End With
    End Sub

    Private Sub _ll01LainLainIRC()
        With _prop03Grid
            'With ._colf01Int
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf02Double
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n2}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf34String
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf08String
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf33String
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf01Int
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf02Double
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            'With ._colf03Double
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

        End With

    End Sub

    Private Sub _wd01SetLebarKolomIRC()
        With _prop03Grid
            ._colk00Boolean.Width = 79
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 86
            ._colk03String.Width = 79
            ._colf01String.Width = 103
            ._colf02String.Width = 79
            ._colf03String.Width = 79
            ._colf04String.Width = 79
            ._colf05String.Width = 85
            ._colf06String.Width = 85
            ._colf07String.Width = 85
            ._colf08String.Width = 85
            ._colf09String.Width = 85
            ._colf10String.Width = 54
            ._colf11String.Width = 85
            ._colf12String.Width = 85
            ._colf13String.Width = 85
            ._colf14String.Width = 49
            ._colf15String.Width = 85
            ._colf16String.Width = 62
            ._colf17String.Width = 85
            ._colf18String.Width = 85
            ._colf19String.Width = 85
            ._colf20String.Width = 77
            ._colf21String.Width = 85
            ._colf22String.Width = 156
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
            ._colf34String.Width = 172
            ._colf35String.Width = 79
            ._colf36String.Width = 108
            ._colf37String.Width = 79
            ._colf38String.Width = 79
            ._colf39String.Width = 79
            ._colf40String.Width = 79
            ._colf01TinyInt.Width = 85
            ._colf01SmallInt.Width = 34
            ._colf01Int.Width = 85
            ._colf01Double.Width = 56
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub

#End Region

#Region "102. BulkUpload XLS : Inbound Reparasi Warehouse (IRPWS)"

    Private Sub _cc01CaptionIRPWS()
        With _prop03Grid
            ._colf03Date.Caption = "Tgl.Repair"
            ._colf36String.Caption = "SKU Repair"
            ._colf01String.Caption = "ProductCode"
            ._colf08String.Caption = "Warna"
            ._colf10String.Caption = "Kadar"
            ._colf12String.Caption = "Item"
            ._colf14String.Caption = "Size"
            ._colf16String.Caption = "Brand"
            ._colf01SmallInt.Caption = "Qty"
            ._colf02Double.Caption = "Gram"
        End With
    End Sub

    Private Sub _vs01VisibilityIRPWS()
        With _prop03Grid
            ._colf03Date.Visible = True      '"Tgl.Repair"
            ._colf36String.Visible = True      '"SKU Repair"
            ._colf01String.Visible = True      '"ProductCode"
            ._colf08String.Visible = True      '"Warna"
            ._colf10String.Visible = True      '"Kadar"
            ._colf12String.Visible = True      '"Item"
            ._colf14String.Visible = True      '"Size"
            ._colf16String.Visible = True      '"Brand"
            ._colf01SmallInt.Visible = True      '"Pcs"
            ._colf02Double.Visible = True      '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexIRPWS()
        With _prop03Grid
            ._colf03Date.VisibleIndex = 0      '"Tgl.Repair"
            ._colf36String.VisibleIndex = 1      '"SKU Repair"
            ._colf01String.VisibleIndex = 2      '"ProductCode"
            ._colf16String.VisibleIndex = 3      '"Brand"
            ._colf10String.VisibleIndex = 4      '"Kadar"
            ._colf12String.VisibleIndex = 5      '"Item"
            ._colf08String.VisibleIndex = 6      '"Warna"
            ._colf14String.VisibleIndex = 7      '"Size"
            ._colf01SmallInt.VisibleIndex = 8      '"Pcs"
            ._colf02Double.VisibleIndex = 9      '"Berat"
        End With
    End Sub

    Private Sub _wr01WriteIRPWS()

    End Sub

    Private Sub _tot01TotPcsDanBeratIRPWS()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f02Double").SummaryItem.FieldName = "f02Double"
            .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainIRPWS()

    End Sub

    Private Sub _wd01SetLebarKolomIRPWS()
        With _prop03Grid
            ._colk00Boolean.Width = 79
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 79
            ._colk03String.Width = 79
            ._colf01String.Width = 106
            ._colf02String.Width = 79
            ._colf03String.Width = 79
            ._colf04String.Width = 79
            ._colf05String.Width = 85
            ._colf06String.Width = 85
            ._colf07String.Width = 85
            ._colf08String.Width = 166
            ._colf09String.Width = 85
            ._colf10String.Width = 58
            ._colf11String.Width = 85
            ._colf12String.Width = 141
            ._colf13String.Width = 85
            ._colf14String.Width = 138
            ._colf15String.Width = 85
            ._colf16String.Width = 115
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
            ._colf36String.Width = 114
            ._colf37String.Width = 79
            ._colf38String.Width = 79
            ._colf39String.Width = 79
            ._colf40String.Width = 79
            ._colf01TinyInt.Width = 85
            ._colf01SmallInt.Width = 48
            ._colf01Int.Width = 85
            ._colf01Double.Width = 85
            ._colf02Double.Width = 69
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 84
        End With
    End Sub

#End Region

#End Region

End Class
