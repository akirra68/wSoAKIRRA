Imports DevExpress.XtraPivotGrid
Imports SKK02OBJECTS.clsWSNasaSettingReportPivot
Imports SKK02OBJECTS.ucReportGrid

Public Class ucWSPivot
    Implements IDisposable

    Public Property _prop01User As clsWSNasaUser
    Public Property _prop02TargetPivot As _pbEnumTargetPivot
    Public Property _prop03pdtDataSourcePivot As New DataTable

#Region "private - repository"
    Private _rscolf01TinyInt As New repoWS02Numeric
    Private _rscolf02TinyInt As New repoWS02Numeric
    Private _rscolf01SmallInt As New repoWS02Numeric
    Private _rscolf02SmallInt As New repoWS02Numeric
    Private _rscolf01Int As New repoWS02Numeric
    Private _rscolf01Double52 As New repoWS02Numeric
    Private _rscolf01Double62 As New repoWS02Numeric
    Private _rscolf01Double162 As New repoWS02Numeric

    Private _rscolf01Date As New repoWS01Date
    Private _rscolf02Date As New repoWS01Date
    Private _rscolf03Date As New repoWS01Date
#End Region

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "private custom - method"

    Private Sub _cm01InitAreaPivot()
        _colk01String.Area = PivotArea.FilterArea   '"k01String"
        _colk02String.Area = PivotArea.FilterArea   '"k02String"
        _colk03String.Area = PivotArea.FilterArea   '"k03String"
        _colf01String.Area = PivotArea.FilterArea   '"f01String"
        _colf02String.Area = PivotArea.FilterArea   '"f02String"
        _colf03String.Area = PivotArea.FilterArea   '"f03String"
        _colf04String.Area = PivotArea.FilterArea   '"f04String"
        _colf05String.Area = PivotArea.FilterArea   '"f05String"
        _colf06String.Area = PivotArea.FilterArea   '"f06String"
        _colf07String.Area = PivotArea.FilterArea   '"f07String"
        _colf08String.Area = PivotArea.FilterArea   '"f08String"
        _colf09String.Area = PivotArea.FilterArea   '"f09String"
        _colf10String.Area = PivotArea.FilterArea   '"f10String"
        _colf11String.Area = PivotArea.FilterArea   '"f11String"
        _colf12String.Area = PivotArea.FilterArea   '"f12String"
        _colf13String.Area = PivotArea.FilterArea   '"f13String"
        _colf14String.Area = PivotArea.FilterArea   '"f14String"
        _colf15String.Area = PivotArea.FilterArea   '"f15String"
        _colf16String.Area = PivotArea.FilterArea   '"f16String"
        _colf17String.Area = PivotArea.FilterArea   '"f17String"
        _colf18String.Area = PivotArea.FilterArea   '"f18String"
        _colf19String.Area = PivotArea.FilterArea   '"f19String"
        _colf20String.Area = PivotArea.FilterArea   '"f20String"
        _colf21String.Area = PivotArea.FilterArea   '"f21String"
        _colf22String.Area = PivotArea.FilterArea   '"f22String"
        _colf23String.Area = PivotArea.FilterArea   '"f23String"
        _colf24String.Area = PivotArea.FilterArea   '"f24String"
        _colf25String.Area = PivotArea.FilterArea   '"f25String"
        _colf26String.Area = PivotArea.FilterArea   '"f26String"
        _colf27String.Area = PivotArea.FilterArea   '"f27String"
        _colf28String.Area = PivotArea.FilterArea   '"f28String"
        _colf29String.Area = PivotArea.FilterArea   '"f29String"
        _colf30String.Area = PivotArea.FilterArea   '"f30String"
        _colf31String.Area = PivotArea.FilterArea   '"f21String"
        _colf32String.Area = PivotArea.FilterArea   '"f22String"
        _colf33String.Area = PivotArea.FilterArea   '"f23String"
        _colf34String.Area = PivotArea.FilterArea   '"f24String"
        _colf35String.Area = PivotArea.FilterArea   '"f25String"
        _colf36String.Area = PivotArea.FilterArea   '"f26String"
        _colf37String.Area = PivotArea.FilterArea   '"f27String"
        _colf38String.Area = PivotArea.FilterArea   '"f28String"
        _colf39String.Area = PivotArea.FilterArea   '"f29String"
        _colf40String.Area = PivotArea.FilterArea   '"f30String"
        _colf01TinyInt.Area = PivotArea.FilterArea   '"f01TinyInt"
        _colf01SmallInt.Area = PivotArea.FilterArea   '"f01SmallInt"
        _colf01Int.Area = PivotArea.FilterArea   '"f01Int"
        _colf01Double.Area = PivotArea.FilterArea   '"f01Double52"
        _colf02Double.Area = PivotArea.FilterArea   '"f01Double62"
        _colf03Double.Area = PivotArea.FilterArea   '"f01Double162"
        _colf01Date.Area = PivotArea.FilterArea   '"f01Date"
        _colf02Date.Area = PivotArea.FilterArea   '"f02Date"
        _colf03Date.Area = PivotArea.FilterArea   '"f03Date"
    End Sub

    Private Sub _cm02InitFieldPivot()
        _colk01String.FieldName = "k01String"
        _colk02String.FieldName = "k02String"
        _colk03String.FieldName = "k03String"
        _colf01String.FieldName = "f01String"
        _colf02String.FieldName = "f02String"
        _colf03String.FieldName = "f03String"
        _colf04String.FieldName = "f04String"
        _colf05String.FieldName = "f05String"
        _colf06String.FieldName = "f06String"
        _colf07String.FieldName = "f07String"
        _colf08String.FieldName = "f08String"
        _colf09String.FieldName = "f09String"
        _colf10String.FieldName = "f10String"
        _colf11String.FieldName = "f11String"
        _colf12String.FieldName = "f12String"
        _colf13String.FieldName = "f13String"
        _colf14String.FieldName = "f14String"
        _colf15String.FieldName = "f15String"
        _colf16String.FieldName = "f16String"
        _colf17String.FieldName = "f17String"
        _colf18String.FieldName = "f18String"
        _colf19String.FieldName = "f19String"
        _colf20String.FieldName = "f20String"
        _colf21String.FieldName = "f21String"
        _colf22String.FieldName = "f22String"
        _colf23String.FieldName = "f23String"
        _colf24String.FieldName = "f24String"
        _colf25String.FieldName = "f25String"
        _colf26String.FieldName = "f26String"
        _colf27String.FieldName = "f27String"
        _colf28String.FieldName = "f28String"
        _colf29String.FieldName = "f29String"
        _colf30String.FieldName = "f30String"
        _colf31String.FieldName = "f31String"
        _colf32String.FieldName = "f32String"
        _colf33String.FieldName = "f33String"
        _colf34String.FieldName = "f34String"
        _colf35String.FieldName = "f35String"
        _colf36String.FieldName = "f36String"
        _colf37String.FieldName = "f37String"
        _colf38String.FieldName = "f38String"
        _colf39String.FieldName = "f39String"
        _colf40String.FieldName = "f40String"
        _colf01TinyInt.FieldName = "f01TinyInt"
        _colf01SmallInt.FieldName = "f01SmallInt"
        _colf01Int.FieldName = "f01Int"
        _colf01Double.FieldName = "f01Double"
        _colf02Double.FieldName = "f02Double"
        _colf03Double.FieldName = "f03Double"
        _colf01Date.FieldName = "f01Date"
        _colf02Date.FieldName = "f02Date"
        _colf03Date.FieldName = "f03Date"
    End Sub

    Private Sub _cm03InitRepoColumn()
        _rscolf01TinyInt._pb01InitRepoNumeric(0)
        _rscolf02TinyInt._pb01InitRepoNumeric(0)
        _rscolf01SmallInt._pb01InitRepoNumeric(0)
        _rscolf02SmallInt._pb01InitRepoNumeric(0)
        _rscolf01Int._pb01InitRepoNumeric(0)
        _rscolf01Double52._pb01InitRepoNumeric(2)
        _rscolf01Double62._pb01InitRepoNumeric(2)
        _rscolf01Double162._pb01InitRepoNumeric(2)

        _rscolf01Date._pb01InitRepoDate()
        _rscolf02Date._pb01InitRepoDate()
        _rscolf03Date._pb01InitRepoDate()
    End Sub

    Private Sub _cm04InitCellFormatNumericDate(ByRef objColumn As PivotGridField,
                                               ByVal prmcIntDoubleDate As String)
        Dim pcDisplayFormat As String
        pcDisplayFormat = ""

        objColumn.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        Select Case prmcIntDoubleDate
            Case "INT"
                pcDisplayFormat = "{0:n0}"
            Case "DBL2"
                pcDisplayFormat = "{0:n2}"
            Case "DBL3"
                pcDisplayFormat = "{0:n3}"
            Case "DATE"
                pcDisplayFormat = "d"
                objColumn.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Case Else
        End Select

        objColumn.CellFormat.FormatString = pcDisplayFormat

    End Sub

    Private Sub _cm05InitRepoCellFormat()
        _cm04InitCellFormatNumericDate(_colf01TinyInt, "INT")
        _cm04InitCellFormatNumericDate(_colf01SmallInt, "INT")
        _cm04InitCellFormatNumericDate(_colf01Int, "INT")
        _cm04InitCellFormatNumericDate(_colf01Double, "DBL2")
        _cm04InitCellFormatNumericDate(_colf02Double, "DBL2")
        _cm04InitCellFormatNumericDate(_colf03Double, "DBL2")
        _cm04InitCellFormatNumericDate(_colf01Date, "DATE")
        _cm04InitCellFormatNumericDate(_colf02Date, "DATE")
        _cm04InitCellFormatNumericDate(_colf03Date, "DATE")
    End Sub

    Private Sub _cm06InitReadOnly()
        _colk01String.Options.ReadOnly = True '"k01String"
        _colk02String.Options.ReadOnly = True '"k02String"
        _colk03String.Options.ReadOnly = True '"k03String"
        _colf01String.Options.ReadOnly = True '"f01String"
        _colf02String.Options.ReadOnly = True '"f02String"
        _colf03String.Options.ReadOnly = True '"f03String"
        _colf04String.Options.ReadOnly = True '"f04String"
        _colf05String.Options.ReadOnly = True '"f05String"
        _colf06String.Options.ReadOnly = True '"f06String"
        _colf07String.Options.ReadOnly = True '"f07String"
        _colf08String.Options.ReadOnly = True '"f08String"
        _colf09String.Options.ReadOnly = True '"f09String"
        _colf10String.Options.ReadOnly = True '"f10String"
        _colf11String.Options.ReadOnly = True '"f11String"
        _colf12String.Options.ReadOnly = True '"f12String"
        _colf13String.Options.ReadOnly = True '"f13String"
        _colf14String.Options.ReadOnly = True '"f14String"
        _colf15String.Options.ReadOnly = True '"f15String"
        _colf16String.Options.ReadOnly = True '"f16String"
        _colf17String.Options.ReadOnly = True '"f17String"
        _colf18String.Options.ReadOnly = True '"f18String"
        _colf19String.Options.ReadOnly = True '"f19String"
        _colf20String.Options.ReadOnly = True '"f20String"
        _colf21String.Options.ReadOnly = True '"f21String"
        _colf22String.Options.ReadOnly = True '"f22String"
        _colf23String.Options.ReadOnly = True '"f23String"
        _colf24String.Options.ReadOnly = True '"f24String"
        _colf25String.Options.ReadOnly = True '"f25String"
        _colf26String.Options.ReadOnly = True '"f26String"
        _colf27String.Options.ReadOnly = True '"f27String"
        _colf28String.Options.ReadOnly = True '"f28String"
        _colf29String.Options.ReadOnly = True '"f29String"
        _colf30String.Options.ReadOnly = True '"f30String"
        _colf31String.Options.ReadOnly = True '"f21String"
        _colf32String.Options.ReadOnly = True '"f22String"
        _colf33String.Options.ReadOnly = True '"f23String"
        _colf34String.Options.ReadOnly = True '"f24String"
        _colf35String.Options.ReadOnly = True '"f25String"
        _colf36String.Options.ReadOnly = True '"f26String"
        _colf37String.Options.ReadOnly = True '"f27String"
        _colf38String.Options.ReadOnly = True '"f28String"
        _colf39String.Options.ReadOnly = True '"f29String"
        _colf40String.Options.ReadOnly = True '"f30String"
        _colf01TinyInt.Options.ReadOnly = True '"f01TinyInt"
        _colf01SmallInt.Options.ReadOnly = True '"f01SmallInt"
        _colf01Int.Options.ReadOnly = True '"f01Int"
        _colf01Double.Options.ReadOnly = True '"f01Double52"
        _colf02Double.Options.ReadOnly = True '"f01Double62"
        _colf03Double.Options.ReadOnly = True '"f01Double162"
        _colf01Date.Options.ReadOnly = True '"f01Date"
        _colf02Date.Options.ReadOnly = True '"f02Date"
        _colf03Date.Options.ReadOnly = True '"f03Date"
    End Sub

    Private Sub _cm07InitVisibilityOFF()
        _colk01String.Visible = False      '"k01String"
        _colk02String.Visible = False      '"k02String"
        _colk03String.Visible = False      '"k03String"
        _colf01String.Visible = False      '"f01String"
        _colf02String.Visible = False      '"f02String"
        _colf03String.Visible = False      '"f03String"
        _colf04String.Visible = False      '"f04String"
        _colf05String.Visible = False      '"f05String"
        _colf06String.Visible = False      '"f06String"
        _colf07String.Visible = False      '"f07String"
        _colf08String.Visible = False      '"f08String"
        _colf09String.Visible = False      '"f09String"
        _colf10String.Visible = False      '"f10String"
        _colf11String.Visible = False      '"f11String"
        _colf12String.Visible = False      '"f12String"
        _colf13String.Visible = False      '"f13String"
        _colf14String.Visible = False      '"f14String"
        _colf15String.Visible = False      '"f15String"
        _colf16String.Visible = False      '"f16String"
        _colf17String.Visible = False      '"f17String"
        _colf18String.Visible = False      '"f18String"
        _colf19String.Visible = False      '"f19String"
        _colf20String.Visible = False      '"f20String"
        _colf21String.Visible = False      '"f21String"
        _colf22String.Visible = False      '"f22String"
        _colf23String.Visible = False      '"f23String"
        _colf24String.Visible = False      '"f24String"
        _colf25String.Visible = False      '"f25String"
        _colf26String.Visible = False      '"f26String"
        _colf27String.Visible = False      '"f27String"
        _colf28String.Visible = False      '"f28String"
        _colf29String.Visible = False      '"f29String"
        _colf30String.Visible = False      '"f30String"
        _colf31String.Visible = False      '"f21String"
        _colf32String.Visible = False      '"f22String"
        _colf33String.Visible = False      '"f23String"
        _colf34String.Visible = False      '"f24String"
        _colf35String.Visible = False      '"f25String"
        _colf36String.Visible = False      '"f26String"
        _colf37String.Visible = False      '"f27String"
        _colf38String.Visible = False      '"f28String"
        _colf39String.Visible = False      '"f29String"
        _colf40String.Visible = False      '"f30String"
        _colf01TinyInt.Visible = False      '"f01TinyInt"
        _colf01SmallInt.Visible = False      '"f01SmallInt"
        _colf01Int.Visible = False      '"f01Int"
        _colf01Double.Visible = False      '"f01Double52"
        _colf02Double.Visible = False      '"f01Double62"
        _colf03Double.Visible = False      '"f01Double162"
        _colf01Date.Visible = False      '"f01Date"
        _colf02Date.Visible = False      '"f02Date"
        _colf03Date.Visible = False      '"f03Date"
    End Sub

#End Region

#Region "public custom - method"

    Public Sub _pbWSPivot01InitPivot()
        _cm01InitAreaPivot()
        _cm02InitFieldPivot()
        _cm03InitRepoColumn()
        _cm05InitRepoCellFormat()
        _cm06InitReadOnly()

        'agar waktu pertama kali display, kosong... tanpa header kolom
        _cm07InitVisibilityOFF()
    End Sub

    Public Sub _pbWSPivot02ClearPivot()
        PivotGridControl1.DataSource = Nothing
        PivotGridControl1.Refresh()
    End Sub

    Public Sub _pbWSPivot03DisplayPivot()
        _cm20InstallSettingWSPivot()

        PivotGridControl1.DataSource = Nothing
        PivotGridControl1.RefreshData()
        PivotGridControl1.Refresh()

        PivotGridControl1.DataSource = _prop03pdtDataSourcePivot
        PivotGridControl1.RefreshData()
        PivotGridControl1.Refresh()

        PivotGridControl1.Dock = DockStyle.Fill
    End Sub

    Public Sub _pbWSPivot04DisplayPanelFilter(ByVal prmDisplay As Boolean)
        If prmDisplay Then
            PivotGridControl1.OptionsView.ShowFilterHeaders = True
        Else
            PivotGridControl1.OptionsView.ShowFilterHeaders = False
        End If
    End Sub

#End Region

#Region "event - pivot"
    Private Sub PivotGridControl1_ShownEditor(sender As Object, e As PivotCellEditEventArgs) Handles PivotGridControl1.ShownEditor
        PivotGridControl1.ActiveEditor.Properties.ReadOnly = True
    End Sub
#End Region

#Region "********** method private - UPDATE/CHANGE **********"

    Public Enum _pbEnumTargetPivot
        'Report
        _rptWS01PosterSaldoCurrent = 0

        'Report - Inbound
        _WSRptInbound200All = 200
        _WSRptInbound201ByVendor = 201

        'Report - General
        _WSRptGeneral300Stock = 300
        _WSRptGeneral301StockProductCode = 301

        'Transaksi SALE (entrian :> ucWS24IJ01SALE)
        _wsStockForSale = 70

        'Outbound - Sale
        _wsOutbound350Sale = 350

        'Report - Transaksi Warehouse - Semua
        _wsRptTransaksiWS370Semua = 370
    End Enum

    Private Sub _cm20InstallSettingWSPivot()
        Select Case _prop02TargetPivot
            Case _pbEnumTargetPivot._WSRptInbound200All
                _cm50SettingWS24B3REPORT()

            Case _pbEnumTargetPivot._WSRptGeneral300Stock, _pbEnumTargetPivot._WSRptGeneral301StockProductCode,
                 _pbEnumTargetPivot._wsOutbound350Sale, _pbEnumTargetPivot._wsRptTransaksiWS370Semua
                _cm50SettingWS24B3REPORT()

            Case _pbEnumTargetPivot._wsStockForSale
                _cm70SettingWSTransaksiSale()

        End Select
    End Sub

    Private Sub _cm50SettingWS24B3REPORT()
        Cursor = Cursors.WaitCursor

        Using objPivotSettingWS24B3REPORT As clsWSNasaSettingReportPivot = New clsWSNasaSettingReportPivot With {._prop02Pivot = Me}
            Select Case _prop02TargetPivot
                Case _pbEnumTargetPivot._WSRptInbound200All
                    objPivotSettingWS24B3REPORT._prop01cTargetPivotWSReport = TargetPivotWSReport._wsInbound200All

                Case _pbEnumTargetPivot._WSRptInbound201ByVendor
                    objPivotSettingWS24B3REPORT._prop01cTargetPivotWSReport = TargetPivotWSReport._wsInbound201ByVendor

                Case _pbEnumTargetPivot._WSRptGeneral300Stock
                    objPivotSettingWS24B3REPORT._prop01cTargetPivotWSReport = TargetPivotWSReport._wsGeneral300Stock

                Case _pbEnumTargetPivot._WSRptGeneral301StockProductCode
                    objPivotSettingWS24B3REPORT._prop01cTargetPivotWSReport = TargetPivotWSReport._wsGeneral301StockProductCode

                Case _pbEnumTargetPivot._wsOutbound350Sale
                    objPivotSettingWS24B3REPORT._prop01cTargetPivotWSReport = TargetPivotWSReport._wsOutbound350Sale

                Case _pbEnumTargetPivot._wsRptTransaksiWS370Semua
                    objPivotSettingWS24B3REPORT._prop01cTargetPivotWSReport = TargetPivotWSReport._wsTransaksiWS370Semua
            End Select

            objPivotSettingWS24B3REPORT.__pbCallSettingReportPivot()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm70SettingWSTransaksiSale()
        Cursor = Cursors.WaitCursor

        Using objPivotSettingWSSale As clsWSNasaSettingReportPivot = New clsWSNasaSettingReportPivot With {._prop01cTargetPivotWSReport = TargetPivotWSReport._wsStockForSale,
                                                                                                           ._prop02Pivot = Me}
            objPivotSettingWSSale.__pbCallSettingReportPivot()
        End Using

        Cursor = Cursors.Default
    End Sub

#End Region

    '#Region "***** REPORT *****"

    '#Region "***** Report : Poster Saldo Current *****"

    '    Private Sub _cmrptWS01PosterSaldoCurrentSetup()
    '        _cmrptWS01CaptionPosterSaldoCurrent()
    '        _cmrptWS01VisibilityPosterSaldoCurrent()
    '        _cmrptWS01PivotAreaPosterSaldoCurrent()
    '        '_cmrptWS01CurrentStockPOSTER04SettingOthers()
    '    End Sub

    '    Private Sub _cmrptWS01CaptionPosterSaldoCurrent()
    '        _colk01String.Caption = "SKU"                '	wsSKU
    '        _colk02String.Caption = "Document"           '	NoDocumentTransaksiMutasi
    '        _colk03String.Caption = "Form"               '	NamaFormTransaksiMutasiDiMERSY
    '        _colf01String.Caption = "Sloc.Asal"          '	NamaStorageLocationAsal
    '        _colf02String.Caption = "Sloc.Current"       '	NamaStorageLocationCurrent
    '        _colf03String.Caption = "Box"                '	NamaStorageBoxCurrent
    '        _colf04String.Caption = "Mutasi"             '	Mutasi By  (Nama User )
    '        _colf05String.Caption = "Approved"           '	Approved By (Nama User)
    '        _colf06String.Caption = "AsalStock"          '	SINGLE/MIX (asal wsSKU)
    '        _colf07String.Caption = "Status"             '	Status (INTRANSIT/STOCK/RESERVED/PROSES/FINISH)
    '        _colf08String.Caption = "Note"               '	Note Mutasi  (SLoc Current )

    '        _colf11String.Caption = "Vendor"        'NamaVendor
    '        _colf12String.Caption = "No/RO"         'NamaNORO
    '        _colf13String.Caption = "Warna"         'NamaWarnaEmas
    '        _colf14String.Caption = "Kadar"         'NamaKadarEmas
    '        _colf15String.Caption = "Item"          'NamaTipeBRJ
    '        _colf16String.Caption = "Size"          'NamaSize
    '        _colf17String.Caption = "Brand"         'NamaBrand
    '        _colf18String.Caption = "Raw"           'NamaMaterial
    '        _colf19String.Caption = "Gender"        'NamaGender
    '        _colf20String.Caption = "Engrave"       'NamaEngrave
    '        _colf21String.Caption = "Finding"       'NamaFinding
    '        _colf22String.Caption = "Plating"       'NamaPlating
    '        _colf23String.Caption = "Finishing"     'NamaFinishing
    '        _colf24String.Caption = "StoneType"     'NamaStoneType

    '        _colf01SmallInt.Caption = "Pcs"              '	Pcs  (SLoc Current)
    '        _colf01Double.Caption = "Berat"              '	Berat  (SLoc Current)
    '        _colf01Date.Caption = "INBOUND"              '	Tgl INBOUND  wsSKU
    '        _colf02Date.Caption = "Mutasi"               '	Tgl Approved Mutasi SLoc
    '        _colf01Int.Caption = "Umur"                 '	Aging Stock
    '    End Sub

    '    Private Sub _cmrptWS01VisibilityPosterSaldoCurrent()
    '        _colk01String.Visible = True       '	wsSKU
    '        _colk02String.Visible = True       '	NoDocumentTransaksiMutasi
    '        _colk03String.Visible = True       '	NamaFormTransaksiMutasiDiMERSY
    '        _colf01String.Visible = True       '	NamaStorageLocationAsal
    '        _colf02String.Visible = True       '	NamaStorageLocationCurrent
    '        _colf03String.Visible = True       '	NamaStorageBoxCurrent
    '        _colf04String.Visible = True       '	Mutasi By  (Nama User )
    '        _colf05String.Visible = True       '	Approved By (Nama User)
    '        _colf06String.Visible = True       '	SINGLE/MIX (asal wsSKU)
    '        _colf07String.Visible = True       '	Status (INTRANSIT/STOCK/RESERVED/PROSES/FINISH)
    '        _colf08String.Visible = True       '	Note Mutasi  (SLoc Current )

    '        _colf11String.Visible = True       'NamaVendor
    '        _colf12String.Visible = True       'NamaNORO
    '        _colf13String.Visible = True       'NamaWarnaEmas
    '        _colf14String.Visible = True       'NamaKadarEmas
    '        _colf15String.Visible = True       'NamaTipeBRJ
    '        _colf16String.Visible = True       'NamaSize
    '        _colf17String.Visible = True       'NamaBrand
    '        _colf18String.Visible = True       'NamaMaterial
    '        _colf19String.Visible = True       'NamaGender
    '        _colf20String.Visible = True       'NamaEngrave
    '        _colf21String.Visible = True       'NamaFinding
    '        _colf22String.Visible = True       'NamaPlating
    '        _colf23String.Visible = True       'NamaFinishing
    '        _colf24String.Visible = True       'NamaStoneType

    '        _colf01SmallInt.Visible = True     'Pcs  (SLoc Current)
    '        _colf01Double.Visible = True       'Berat  (SLoc Current)
    '        _colf01Date.Visible = True         'Tgl INBOUND  wsSKU
    '        _colf02Date.Visible = True         'Tgl Approved Mutasi SLoc
    '        _colf01Int.Visible = True         'Aging Stock
    '    End Sub

    '    Private Sub _cmrptWS01PivotAreaPosterSaldoCurrent()
    '        'Data
    '        _colf01SmallInt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea   '"Pcs"
    '        _colf01Double.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea     '"Gram"
    '        _colf01SmallInt.AreaIndex = 0 '"Pcs"
    '        _colf01Double.AreaIndex = 1   '"Gram"

    '        'Row
    '        _colf02String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      '"SLoc Current"
    '        _colf15String.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea      '"Tipe BRJ"
    '        _colf02String.AreaIndex = 0
    '        _colf15String.AreaIndex = 1

    '        'Coloumn
    '        _colf14String.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea   '"Kadar"
    '        _colf14String.AreaIndex = 0
    '    End Sub

    '    'Private Sub _cmrptWS01CurrentStockPOSTER04SettingOthers()
    '    '    PivotGridControl1.BestFitColumnArea()
    '    '    PivotGridControl1.BestFitRowArea()

    '    '    With PivotGridControl1
    '    '        With .OptionsView
    '    '            .ShowColumnGrandTotalHeader = True
    '    '            .ShowColumnGrandTotals = True
    '    '            .ShowRowGrandTotalHeader = True
    '    '            .ShowRowGrandTotals = True
    '    '            .ShowRowTotals = True
    '    '        End With
    '    '    End With
    '    'End Sub

    '#End Region

    '#End Region

End Class
