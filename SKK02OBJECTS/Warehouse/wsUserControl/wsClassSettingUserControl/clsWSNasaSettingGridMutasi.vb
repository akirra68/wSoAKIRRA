
Imports DevExpress.Data

Public Class clsWSNasaSettingGridMutasi
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

    Property _prop01cTargetReceiveFG As TargetMutasiWSSKU
    Property _prop02User As clsWSNasaUser
    Property _prop03Grid As New ucWSGrid
    Property _prop04DataTableMaster As DataTable

    Public Enum TargetMutasiWSSKU
        _TargetWSSKUMutasiAntarSLoc = 0
        _TargetWSRepairDanLebur = 1

        '_TargetWSRptTrackingSKU = 2
        '_TargetWSRptTrackingPKB = 3

        _TargetWSRptInOutSLoc_IN = 4
        _TargetWSRptInOutSLoc_OUT = 5
        _TargetWSPKBCustomer = 6

        'Report
        _TargetWSRptPosterSaldoCurrent = 20

    End Enum

#Region "form and control - event"
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region " public - method "
    Public Sub _pbSettingGrid()
        Select Case _prop01cTargetReceiveFG
            Case TargetMutasiWSSKU._TargetWSSKUMutasiAntarSLoc
                _pvSetting01MutasiAntarSLoc()

            Case TargetMutasiWSSKU._TargetWSRepairDanLebur
                _pvSetting02RepairDanLebur()

            Case TargetMutasiWSSKU._TargetWSRptInOutSLoc_IN
                _pvSetting04RptInOutSLoc("IN")

            Case TargetMutasiWSSKU._TargetWSRptInOutSLoc_OUT
                _pvSetting04RptInOutSLoc("OUT")

            Case TargetMutasiWSSKU._TargetWSPKBCustomer
                _pvSetting05PKBCustomer()

            Case TargetMutasiWSSKU._TargetWSRptPosterSaldoCurrent
                _pvSetting06RptPosterSaldoCurrent()

        End Select
    End Sub
#End Region

#Region " private - method "
    Private Sub _pvSetting01MutasiAntarSLoc()
        _cc01CaptionMutasiAntarSLoc()
        _vs01VisibilityMutasiAntarSLoc()
        _vs02VisibilityIndexMutasiAntarSLoc()
        _wr01WriteMutasiAntarSLoc()
        _tot01TotalBeratDanLotMutasiAntarSLoc()
        _ll01LainLainMutasiAntarSLoc()
    End Sub

    Private Sub _pvSetting02RepairDanLebur()
        _cc01CaptionRepairLebur()
        _vs01VisibilityRepairLebur()
        _vs02VisibilityIndexRepairLebur()
        _tot01TotalBeratDanLotRepairLebur()
    End Sub

    Private Sub _pvSetting04RptInOutSLoc(ByVal prmcINOUT As String)
        _cc01CaptionRptInOutSLoc(prmcINOUT)
        _vs01VisibilityRptInOutSLoc()
        _vs02VisibilityIndexRptInOutSLoc()
        _tot01TotalBeratDanLotRptInOutSLoc()
    End Sub

    Private Sub _pvSetting05PKBCustomer()
        _cc01CaptionPKBCustomer()
        _vs01VisibilityPKBCustomer()
        _vs02VisibilityIndexPKBCustomer()
        _wr01WriteOnlyPKBCustomer()
        _ll01LainLainPKBCustomer()
        _wd240707WidthPKBCustomer()
    End Sub

    Private Sub _pvSetting06RptPosterSaldoCurrent()
        _cc01CaptionRptPosterSaldoCurrent()
        _vs01VisibilityRptPosterSaldoCurrent()
        _vs02VisibilityIndexRptPosterSaldoCurrent()
    End Sub

#End Region

#Region "***** Mutasi Antar SLoc *****"

    Private Sub _cc01CaptionMutasiAntarSLoc()
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colk00Int.Caption = "#"
            ._colk02String.Caption = "SKU"           'wsSKU
            ._colf01String.Caption = "ProductCode"   'ProductCode
            ._colf02String.Caption = "DesignCode"    'DesignCode
            ._colf04String.Caption = "Vendor"        'NamaVendor
            ._colf06String.Caption = "NORO"          'NamaNORO
            ._colf08String.Caption = "Warna"         'NamaWarnaEmas
            ._colf10String.Caption = "Kadar"         'NamaKadarEmas
            ._colf12String.Caption = "Tipe"          'NamaTipeBRJ
            ._colf14String.Caption = "Size"          'NamaSize
            ._colf16String.Caption = "Brand"         'NamaBrand
            ._colf18String.Caption = "Material"      'NamaMaterial
            ._colf32String.Caption = "SLoc"         'NamaSLoc (pertama kali)
            ._colf34String.Caption = "Box"           'NamaBox (pertama kali)

            ._colf01TinyInt.Caption = "IndexMutasi"      'index Mutasi
            ._colf01SmallInt.Caption = "Pcs"              'Pcs
            ._colf01Double.Caption = "Berat"              'Berat

            ._colf01Date.Caption = "TglInbound"           'TglInbound
            ._colf02Date.Caption = "TglApproveMutasi"     'TglApproveMutasi
        End With
    End Sub

    Private Sub _vs01VisibilityMutasiAntarSLoc()
        With _prop03Grid
            ._colk00Boolean.Visible = True
            ._colk00Int.Visible = False
            ._colk02String.Visible = True           'wsSKU
            ._colf01String.Visible = True   'ProductCode
            ._colf02String.Visible = False    'DesignCode
            ._colf04String.Visible = True        'NamaVendor
            ._colf06String.Visible = True          'NamaNORO
            ._colf08String.Visible = True         'NamaWarnaEmas
            ._colf10String.Visible = True         'NamaKadarEmas
            ._colf12String.Visible = True          'NamaTipeBRJ
            ._colf14String.Visible = True          'NamaSize
            ._colf16String.Visible = True         'NamaBrand
            ._colf18String.Visible = True      'NamaMaterial
            ._colf32String.Visible = False         'NamaSLoc (pertama kali)
            ._colf34String.Visible = True           'NamaBox (pertama kali)

            ._colf01TinyInt.Visible = False      'index Mutasi
            ._colf01SmallInt.Visible = True              'Pcs
            ._colf01Double.Visible = True              'Berat

            ._colf01Date.Visible = True           'TglInbound
            ._colf02Date.Visible = True     'TglApproveMutasi
        End With
    End Sub

    Private Sub _vs02VisibilityIndexMutasiAntarSLoc()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0
            ._colk00Int.VisibleIndex = -1
            ._colk02String.VisibleIndex = 1           'wsSKU
            ._colf01String.VisibleIndex = 2   'ProductCode
            ._colf02String.VisibleIndex = -1    'DesignCode
            ._colf04String.VisibleIndex = 3        'NamaVendor
            ._colf06String.VisibleIndex = 4          'NamaNORO
            ._colf08String.VisibleIndex = 5         'NamaWarnaEmas
            ._colf10String.VisibleIndex = 6         'NamaKadarEmas
            ._colf12String.VisibleIndex = 7          'NamaTipeBRJ
            ._colf14String.VisibleIndex = 8          'NamaSize
            ._colf16String.VisibleIndex = 9         'NamaBrand
            ._colf18String.VisibleIndex = 10      'NamaMaterial
            ._colf32String.VisibleIndex = -1        'NamaSLoc (pertama kali)
            ._colf34String.VisibleIndex = 11           'NamaBox (pertama kali)

            ._colf01TinyInt.VisibleIndex = -1     'index Mutasi
            ._colf01SmallInt.VisibleIndex = 12              'Pcs
            ._colf01Double.VisibleIndex = 13              'Berat

            ._colf01Date.VisibleIndex = 14           'TglInbound
            ._colf02Date.VisibleIndex = 15     'TglApproveMutasi
        End With
    End Sub

    Private Sub _wr01WriteMutasiAntarSLoc()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False  '
        End With
    End Sub

    Private Sub _tot01TotalBeratDanLotMutasiAntarSLoc()
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

    Private Sub _ll01LainLainMutasiAntarSLoc()
        With _prop03Grid
            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.LightYellow
            End With
        End With
    End Sub

#End Region

#Region "***** Repair dan Lebur *****"

    Private Sub _cc01CaptionRepairLebur()
        With _prop03Grid
            ._colk02String.Caption = "SKU"           'wsSKU
            ._colf01String.Caption = "ProductCode"   'ProductCode
            ._colf12String.Caption = "Tipe"          'NamaTipeBRJ
            ._colf16String.Caption = "Brand"         'NamaBrand
            ._colf01TinyInt.Caption = "Pcs"              'Pcs
            ._colf01Double.Caption = "Berat"              'Berat
            ._colf36String.Caption = "Alasan"
            ._colf37String.Caption = "Keterangan"
        End With
    End Sub

    Private Sub _vs01VisibilityRepairLebur()
        With _prop03Grid
            ._colk02String.Visible = True           'wsSKU
            ._colf01String.Visible = True           'ProductCode
            ._colf12String.Visible = True           'NamaTipeBRJ
            ._colf16String.Visible = True           'NamaBrand
            ._colf01TinyInt.Visible = True         'Pcs
            ._colf01Double.Visible = True           'Berat
            ._colf36String.Visible = True           '"Alasan"
            ._colf37String.Visible = True           '"Keterangan"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexRepairLebur()
        With _prop03Grid
            ._colk02String.VisibleIndex = 0           'wsSKU
            ._colf01String.VisibleIndex = 1           'ProductCode
            ._colf12String.VisibleIndex = 2           'NamaTipeBRJ
            ._colf16String.VisibleIndex = 3           'NamaBrand
            ._colf01TinyInt.VisibleIndex = 4         'Pcs
            ._colf01Double.VisibleIndex = 5           'Berat
            ._colf36String.VisibleIndex = 6          '"Alasan"
            ._colf37String.VisibleIndex = 7           '"Keterangan"
        End With
    End Sub

    Private Sub _tot01TotalBeratDanLotRepairLebur()
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

#End Region

#Region "***** Distribusi Barang - PKB Customer *****"
    Private Sub _cc01CaptionPKBCustomer()
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colk03String.Caption = "SKU"
            ._colf19String.Caption = "Stock"
            ._colf07String.Caption = "Location"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf28String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf12String.Caption = "Item"
        End With
    End Sub

    Private Sub _vs01VisibilityPKBCustomer()
        With _prop03Grid
            ._colk00Boolean.Visible = True          '"#"
            ._colk03String.Visible = True   '"SKU"
            ._colf19String.Visible = True   '"Stock"
            ._colf07String.Visible = True   '"Location"
            ._colf01SmallInt.Visible = True   '"Qty"
            ._colf01Double.Visible = True   '"Gram"
            ._colf16String.Visible = True   '"Brand"
            ._colf10String.Visible = True   '"Kadar"
            ._colf28String.Visible = True   '"Warna"
            ._colf14String.Visible = True   '"Size"
            ._colf12String.Visible = True
        End With
    End Sub

    Private Sub _vs02VisibilityIndexPKBCustomer()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0          '"#"
            ._colk03String.VisibleIndex = 1   '"SKU"
            ._colf19String.VisibleIndex = 2   '"Stock"
            ._colf07String.VisibleIndex = 3   '"Location"
            ._colf10String.VisibleIndex = 4   '"Kadar"
            ._colf16String.VisibleIndex = 5   '"Brand"
            ._colf12String.VisibleIndex = 6   ' Tipe
            ._colf28String.VisibleIndex = 7   '"Warna"
            ._colf14String.VisibleIndex = 8   '"Size"
            ._colf01SmallInt.VisibleIndex = 9   '"Qty"
            ._colf01Double.VisibleIndex = 10   '"Gram"
        End With
    End Sub

    Private Sub _wr01WriteOnlyPKBCustomer()
        _prop03Grid._colk00Boolean.OptionsColumn.ReadOnly = False
    End Sub

    Private Sub _ll01LainLainPKBCustomer()
        With _prop03Grid
            With .GridView1
                .OptionsView.ShowFooter = True

                With .Columns("k03String")
                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .SummaryItem.DisplayFormat = "{0:n0} Rows"
                    .AppearanceHeader.BackColor = Color.DeepPink
                    .AppearanceCell.BackColor = Color.LightPink
                End With

                With .Columns("f19String")
                    .AppearanceHeader.BackColor = Color.Yellow
                    .AppearanceCell.BackColor = Color.LightYellow
                End With

                With .Columns("f07String")
                    .AppearanceHeader.BackColor = Color.Green
                    .AppearanceCell.BackColor = Color.LightGreen
                End With

            End With
        End With
    End Sub

    Private Sub _wd240707WidthPKBCustomer()
        With _prop03Grid
            ._colk00Boolean.Width = 40
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 79
            ._colk03String.Width = 117
            ._colf01String.Width = 79
            ._colf02String.Width = 79
            ._colf03String.Width = 79
            ._colf04String.Width = 79
            ._colf05String.Width = 85
            ._colf06String.Width = 85
            ._colf07String.Width = 154
            ._colf08String.Width = 85
            ._colf09String.Width = 85
            ._colf10String.Width = 73
            ._colf11String.Width = 85
            ._colf12String.Width = 85
            ._colf13String.Width = 85
            ._colf14String.Width = 71
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
            ._colf01SmallInt.Width = 56
            ._colf01Int.Width = 85
            ._colf01Double.Width = 76
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub


#End Region


#Region "***** Rpt. InOut SLoc *****"
    Private Sub _cc01CaptionRptInOutSLoc(ByVal prmcINOUT As String)
        With _prop03Grid
            ._colk03String.Caption = "SKU"
            If prmcINOUT = "IN" Then
                ._colf01String.Caption = "IN - SLoc"
            Else
                ._colf01String.Caption = "OUT - SLoc"
            End If

            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Berat"
            ._colf03Date.Caption = "Tanggal"
        End With
    End Sub

    Private Sub _vs01VisibilityRptInOutSLoc()
        With _prop03Grid
            ._colk03String.Visible = True           '"SKU"
            ._colf01String.Visible = True           '"SLoc - IN"
            ._colf01SmallInt.Visible = True           '"Pcs"
            ._colf01Double.Visible = True           '"Berat"
            ._colf03Date.Visible = True           '"Tanggal"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexRptInOutSLoc()
        With _prop03Grid
            ._colf03Date.VisibleIndex = 0           '"Tanggal"
            ._colk03String.VisibleIndex = 1          '"SKU"
            ._colf01String.VisibleIndex = 2           '"SLoc - IN"
            ._colf01SmallInt.VisibleIndex = 3           '"Pcs"
            ._colf01Double.VisibleIndex = 4           '"Berat"
        End With
    End Sub

    Private Sub _tot01TotalBeratDanLotRptInOutSLoc()
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
#End Region

#Region "***** Rpt. Poster Saldo Current *****"
    Private Sub _cc01CaptionRptPosterSaldoCurrent()
        With _prop03Grid
            ._colk01String.Caption = "SKU"                '	wsSKU
            ._colk02String.Caption = "Document"           '	NoDocumentTransaksiMutasi
            ._colk03String.Caption = "Form"               '	NamaFormTransaksiMutasiDiMERSY
            ._colf01String.Caption = "Sloc.Asal"          '	NamaStorageLocationAsal
            ._colf02String.Caption = "Sloc.Current"       '	NamaStorageLocationCurrent
            ._colf03String.Caption = "Box"                '	NamaStorageBoxCurrent
            ._colf04String.Caption = "Mutasi"             '	Mutasi By  (Nama User )
            ._colf05String.Caption = "Approved"           '	Approved By (Nama User)
            ._colf06String.Caption = "AsalStock"          '	SINGLE/MIX (asal wsSKU)
            ._colf07String.Caption = "Status"             '	Status (INTRANSIT/STOCK/RESERVED/PROSES/FINISH)
            ._colf08String.Caption = "Note"               '	Note Mutasi  (SLoc Current )

            ._colf11String.Caption = "Vendor"        'NamaVendor
            ._colf12String.Caption = "No/RO"         'NamaNORO
            ._colf13String.Caption = "Warna"         'NamaWarnaEmas
            ._colf14String.Caption = "Kadar"         'NamaKadarEmas
            ._colf15String.Caption = "Item"          'NamaTipeBRJ
            ._colf16String.Caption = "Size"          'NamaSize
            ._colf17String.Caption = "Brand"         'NamaBrand
            ._colf18String.Caption = "Raw"           'NamaMaterial
            ._colf19String.Caption = "Gender"        'NamaGender
            ._colf20String.Caption = "Engrave"       'NamaEngrave
            ._colf21String.Caption = "Finding"       'NamaFinding
            ._colf22String.Caption = "Plating"       'NamaPlating
            ._colf23String.Caption = "Finishing"     'NamaFinishing
            ._colf24String.Caption = "StoneType"     'NamaStoneType

            ._colf01SmallInt.Caption = "Pcs"              '	Pcs  (SLoc Current)
            ._colf01Double.Caption = "Berat"              '	Berat  (SLoc Current)
            ._colf01Date.Caption = "INBOUND"              '	Tgl INBOUND  wsSKU
            ._colf02Date.Caption = "Mutasi"               '	Tgl Approved Mutasi SLoc
            ._colf01Int.Caption = "Umur"               '	Aging Stock
        End With
    End Sub

    Private Sub _vs01VisibilityRptPosterSaldoCurrent()
        With _prop03Grid
            ._colk01String.Visible = True       '	wsSKU
            ._colk02String.Visible = True       '	NoDocumentTransaksiMutasi
            ._colk03String.Visible = True       '	NamaFormTransaksiMutasiDiMERSY
            ._colf01String.Visible = True       '	NamaStorageLocationAsal
            ._colf02String.Visible = True       '	NamaStorageLocationCurrent
            ._colf03String.Visible = True       '	NamaStorageBoxCurrent
            ._colf04String.Visible = True       '	Mutasi By  (Nama User )
            ._colf05String.Visible = True       '	Approved By (Nama User)
            ._colf06String.Visible = True       '	SINGLE/MIX (asal wsSKU)
            ._colf07String.Visible = True       '	Status (INTRANSIT/STOCK/RESERVED/PROSES/FINISH)
            ._colf08String.Visible = True       '	Note Mutasi  (SLoc Current )

            ._colf11String.Visible = True     'NamaVendor
            ._colf12String.Visible = True     'NamaNORO
            ._colf13String.Visible = True     'NamaWarnaEmas
            ._colf14String.Visible = True     'NamaKadarEmas
            ._colf15String.Visible = True     'NamaTipeBRJ
            ._colf16String.Visible = True     'NamaSize
            ._colf17String.Visible = True     'NamaBrand
            ._colf18String.Visible = True     'NamaMaterial
            ._colf19String.Visible = True     'NamaGender
            ._colf20String.Visible = True     'NamaEngrave
            ._colf21String.Visible = True     'NamaFinding
            ._colf22String.Visible = True     'NamaPlating
            ._colf23String.Visible = True     'NamaFinishing
            ._colf24String.Visible = True     'NamaStoneType

            ._colf01SmallInt.Visible = True     '	Pcs  (SLoc Current)
            ._colf01Double.Visible = True       '	Berat  (SLoc Current)
            ._colf01Date.Visible = True         '	Tgl INBOUND  wsSKU
            ._colf02Date.Visible = True         '	Tgl Approved Mutasi SLoc
            ._colf01Int.Visible = True         '	Aging Stock
        End With
    End Sub

    Private Sub _vs02VisibilityIndexRptPosterSaldoCurrent()
        With _prop03Grid
            ._colk01String.VisibleIndex = 0       '	wsSKU
            ._colk02String.VisibleIndex = 1       '	NoDocumentTransaksiMutasi
            ._colf07String.VisibleIndex = 2       '	Status (INTRANSIT/STOCK/RESERVED/PROSES/FINISH)
            ._colf08String.VisibleIndex = 3       '	Note Mutasi  (SLoc Current )
            ._colf02String.VisibleIndex = 4       '	NamaStorageLocationCurrent
            ._colf01SmallInt.VisibleIndex = 5     '	Pcs  (SLoc Current)
            ._colf01Double.VisibleIndex = 6       '	Berat  (SLoc Current)
            ._colf01Date.VisibleIndex = 7         '	Tgl INBOUND  wsSKU
            ._colf02Date.VisibleIndex = 8         '	Tgl Approved Mutasi SLoc
            ._colf01Int.VisibleIndex = 9          '	Aging Stock

            ._colk03String.VisibleIndex = 10       '	NamaFormTransaksiMutasiDiMERSY
            ._colf03String.VisibleIndex = 11       '	NamaStorageBoxCurrent
            ._colf01String.VisibleIndex = 12       '	NamaStorageLocationAsal

            ._colf04String.VisibleIndex = 13       '	Mutasi By  (Nama User )
            ._colf05String.VisibleIndex = 14       '	Approved By (Nama User)
            ._colf06String.VisibleIndex = 15       '	SINGLE/MIX (asal wsSKU)

            ._colf11String.VisibleIndex = 16     'NamaVendor
            ._colf12String.VisibleIndex = 17     'NamaNORO
            ._colf13String.VisibleIndex = 18     'NamaWarnaEmas
            ._colf14String.VisibleIndex = 19     'NamaKadarEmas
            ._colf15String.VisibleIndex = 20     'NamaTipeBRJ
            ._colf16String.VisibleIndex = 21     'NamaSize
            ._colf17String.VisibleIndex = 22     'NamaBrand
            ._colf18String.VisibleIndex = 23     'NamaMaterial
            ._colf19String.VisibleIndex = 24     'NamaGender
            ._colf20String.VisibleIndex = 25     'NamaEngrave
            ._colf21String.VisibleIndex = 26     'NamaFinding
            ._colf22String.VisibleIndex = 27     'NamaPlating
            ._colf23String.VisibleIndex = 28     'NamaFinishing
            ._colf24String.VisibleIndex = 29     'NamaStoneType
        End With
    End Sub
#End Region

End Class
