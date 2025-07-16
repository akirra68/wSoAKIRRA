Imports DevExpress.CodeParser

Public Class clsWSNasaSettingGridOutboundPKB
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

    Property _prop01cTargetOutboundPKB As TargetWSOutboundPKB
    Property _prop02User As clsWSNasaUser
    Property _prop02objUser As clsUserGEMINI
    Property _prop03GridParentChild As New ucWSGridParentChild
    Property _prop03Grid As New ucWSGrid
    Property _prop04RepoMaster As repoWS05Master
    Property _prop05RepoMaster As repoWS05Master
    Property _prop06RepoMaster As repoWS05Master

    Property _prop07cNomorProses As String

    Property _prop08Progress As repoWS08ProgressBar
    Property _prop09ProgressMiddle As repoWS08ProgressBar



    Public Enum TargetWSOutboundPKB
        _wsOut01RefreshDisplayPKB = 0

        _wsOut10ProsesPKB = 10

        _wsOut30StockForSale = 30
        _wsOut31EntrySKUForSale = 31
        _wsOut5052PKBCreateSuratJalan = 5052
        _wsOut505015PKBProsesSuratJalan = 505015

        _wsTrackingSKU = 41
        _wsTrackingPKB = 42

        _mdTrackingPO = 50

    End Enum

#Region "form and control - event"
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region " public - method "
    Public Sub __pbSettingGridOutboundPKB()

        Select Case _prop01cTargetOutboundPKB
            Case TargetWSOutboundPKB._wsOut01RefreshDisplayPKB
                _cmSetting01RefreshDisplayPKB()

            Case TargetWSOutboundPKB._wsOut10ProsesPKB
                _cmSetting02ProsesPKB()

            Case TargetWSOutboundPKB._wsOut30StockForSale
                _cmSetting30StockForSale()

            Case TargetWSOutboundPKB._wsOut31EntrySKUForSale
                _cmSetting31EntrySKUForSale()

            Case TargetWSOutboundPKB._wsOut5052PKBCreateSuratJalan
                _cmSetting5052CreateSuratJalan()

            Case TargetWSOutboundPKB._wsOut505015PKBProsesSuratJalan
                _cmSetting505015SJProses()

            Case TargetWSOutboundPKB._wsTrackingSKU
                _cmSetting41TrackingSKU()

            Case TargetWSOutboundPKB._wsTrackingPKB
                _cmSetting42TrackingPKB()

            Case TargetWSOutboundPKB._mdTrackingPO
                _cmSetting50TrackingPO()

        End Select

    End Sub
#End Region

#Region " private - method "
    Private Sub _cmSetting01RefreshDisplayPKB()
        _rsRepoSettingRefreshDisplayPKB()
        _cc01CaptionRefreshDisplayPKB()
        _vs01VisibilityRefreshDisplayPKB()
        _vs02VisibilityIndexRefreshDisplayPKB()
        _fx01FixedColumnDisplayPKB()
        _wr01WriteRefreshDisplayPKB()
        _ll01LainLainRefreshDisplayPKB()
        _wd240707WidthRefreshDisplayPKB()
    End Sub

    Private Sub _cmSetting02ProsesPKB()
        _cc01CaptionProsesPKB()
        _vs01VisibilityProsesPKB()
        _vs02VisibilityIndexProsesPKB()
        _tot01TotPcsDanBeratProsesPKB()
        _wd240707WidthucWS24H201PROSESPKB()
    End Sub

    Private Sub _cmSetting30StockForSale()
        _cc30GridCaptionStockForSale()
        _vs30GridVisibilityStockForSale()
        _vs30GridVisibilityIndexStockForSale()
    End Sub

    Private Sub _cmSetting31EntrySKUForSale()
        _cc31GridCaptionEntrySKUForSale()
        _vs31GridVisibilityEntrySKUForSale()
        _vs31GridVisibilityIndexEntrySKUForSale()
        _vs31GridWriteEntrySKUForSale()
    End Sub

    Private Sub _cmSetting5052CreateSuratJalan()
        _cc01Caption5052CreateSJ()
        _vs01Visibility5052CreateSJ()
        _vs02VisibilityIndex5052CreateSJ()
        _wr01Write5052CreateSJ()
        _ll01LainLain5052CreateSJ()
        _wd240707Width5052CreateSJ()
    End Sub

    Private Sub _cmSetting505015SJProses()
        _rsRepoSetting505015SJProses()
        _cc01Caption505015SJProses()
        _vs01Visibility505015SJProses()
        _vs02VisibilityIndex505015SJProses()
        _wr01Write505015SJProses()
        _ll01LainLain505015SJProses()
        _wd240707Width505015SJProses()
    End Sub

    Private Sub _cmSetting41TrackingSKU()
        _cc01CaptionRptTrackingSKU()
        _vs01VisibilityRptTrackingSKU()
        _vs02VisibilityIndexRptTrackingSKU()
        _llLainLain42TrackingSKU()
        _wd240707WidthtrackingSKU()
    End Sub
    Private Sub _cmSetting42TrackingPKB()
        _cc01Caption42TrackingPKB()
        _vs02Visibility42TrtackingPKB()
        _vs02VisibilityIndex42TrtackingPKB()
        _ll03LainLain42TrakingPKB()
        _wd240707WidthtrackingPKB()
    End Sub

    Private Sub _cmSetting50TrackingPO()
        _cc01Caption50TrackingPO()
        _vs02Visibility50TrackingPO()
        _vs02VisibilityIndex50TrackingPO()
        _ll03LainLain50TrackingPO()
        _wd240707WidthtrackingPO()
    End Sub

#End Region

#Region "***** 01. Refresh-Display-PKB *****"

    Private Sub _rsRepoSettingRefreshDisplayPKB()
        'pobjProgress = New repoWS08ProgressBar
        'pobjProgress.__pb01InitRepoProgressBar()

        'pobjProgressMiddle = New repoWS08ProgressBar
        'pobjProgressMiddle.__pb01InitRepoProgressBar()

        With _prop03GridParentChild
            ._colf28String.ColumnEdit = _prop04RepoMaster      '"Next Proses"

            Select Case _prop07cNomorProses
                Case "5051"    'Picking 
                    ._colf14String.ColumnEdit = _prop05RepoMaster      '"PICKER"
                    ._colf01Int.ColumnEdit = _prop08Progress           'pobjProgress
                    ._chcolf01Int.ColumnEdit = _prop09ProgressMiddle   'pobjProgressMiddle

                Case "505015"  'Confirm Delivered NON Ekspedisi'
                Case "505012"  'Airway Bill by Ekspedisi'
                    ._colf16String.ColumnEdit = _prop06RepoMaster      '"EKSPEDISI"

                Case "505013"  'Confirm Pickup by Ekspedisi'
                Case "505014"  'Confirm Delivered by Ekspedisi'
                Case "100"     'All Process'
                    ._colf14String.ColumnEdit = _prop05RepoMaster      '"PICKER"
                    ._colf01Int.ColumnEdit = _prop08Progress           'pobjProgress
                    ._chcolf01Int.ColumnEdit = _prop09ProgressMiddle   'pobjProgressMiddle
                    ._colf16String.ColumnEdit = _prop06RepoMaster      '"EKSPEDISI"
            End Select
        End With

    End Sub

    Private Sub _cc01CaptionRefreshDisplayPKB()
        With _prop03GridParentChild
            'Parent
            ._colf02Date.Caption = "Tgl.Order"
            ._colf02String.Caption = "Customer"
            ._colk02String.Caption = "No.Order"
            ._colf04String.Caption = "KAE"
            ._colf06String.Caption = "TOP"
            ._colf08String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf11String.Caption = "Order"
            ._colf12String.Caption = "KodeTransaksiCurrent"
            ._colf13String.Caption = "Current"
            ._colf28String.Caption = "NextProses"
            ._colf29String.Caption = "NamaTransaksiNext"
            ._colf39String.Caption = "Progress"

            ._colf14String.Caption = "Picker"
            ._colf15String.Caption = "NamaPicker"
            ._colf26String.Caption = "No.Picking"
            ._colf16String.Caption = "Ekspedisi"
            ._colf17String.Caption = "NamaEkspedisi"
            ._colf18String.Caption = "No.Resi"

            ._colf01Int.Caption = "Picking"
            ._colk00Int01.Caption = "Tot.Picking"
            ._colf01SmallInt.Caption = "T.Qty"
            ._colf01Double.Caption = "T.Gram"

            'Middle
            ._chcolk03String.Caption = "No.Order"
            ._chcolk02String.Caption = "ProductCode"
            ._chcolf01SmallInt.Caption = "Tot.Qty"
            ._chcolf01Int.Caption = "Picking"
            ._chcolf01Double.Caption = "Tot.Gram"
            ._chcolk00Int.Caption = "Tot.Picking"
            ._chcolf39String.Caption = "Progress"

            'Child
            ._gccolk00Boolean.Caption = "#"
            ._gccolk00Int.Caption = "#"
            ._gccolk01String.Caption = "No.Order"
            ._gccolk02String.Caption = "ProductCode"
            ._gccolk03String.Caption = "SKU"
            ._gccolf01String.Caption = "Storage"
            ._gccolf02String.Caption = "Brand"
            ._gccolf03String.Caption = "Kadar"
            ._gccolf04String.Caption = "Status"
            ._gccolf01SmallInt.Caption = "Qty"
            ._gccolf01Double.Caption = "Gram"
        End With
    End Sub

    Private Sub _vs01VisibilityRefreshDisplayPKB()
        With _prop03GridParentChild
            'Parent
            ._colf02Date.Visible = True         '"Tgl.PKB"
            ._colf02String.Visible = True       '"Customer"
            ._colk02String.Visible = True       '"No.PKB"
            ._colf04String.Visible = True       '"KAE"
            ._colf06String.Visible = True       '"TOP"
            ._colf08String.Visible = True       '"Brand"
            ._colf10String.Visible = True       '"Kadar"
            ._colf11String.Visible = True       '"Order"
            ._colf12String.Visible = False      '"KodeTransaksi"
            ._colf13String.Visible = True       '"Current"
            ._colf28String.Visible = True       '"Next Proses"
            ._colf29String.Visible = False      '"NamaTransaksiNext"

            ._colf14String.Visible = True       '"KodePICKER"
            ._colf15String.Visible = False       '"PICKER"
            ._colf26String.Visible = True       '"No.picking"
            ._colf16String.Visible = True       '"EKSPEDISI"
            ._colf17String.Visible = False       '"NamaEKSPEDISI"
            ._colf18String.Visible = True       '"Resi"

            ._colf01SmallInt.Visible = True     '"T.Qty"
            ._colf01Double.Visible = True       '"T.Berat"
            ._colk00Int01.Visible = False        '"Tot.Picking"

            Select Case _prop07cNomorProses
                Case "5051"    'Picking + Create SuratJalan'
                    ._colf01Int.Visible = True          '"ProgressPicking"
                    ._chcolf01Int.Visible = False       '"ProgressPicking"
                    ._colf39String.Visible = True       'Caption = "Progress"
                    ._chcolf39String.Visible = True     'Caption = "Progress"

                Case "505015"  'Confirm Delivered NON Ekspedisi'
                Case "505012"  'Airway Bill by Ekspedisi'
                Case "505013"  'Confirm Pickup by Ekspedisi'
                Case "505014"  'Confirm Delivered by Ekspedisi'

                Case "100"     'All Process'
                    ._colf01Int.Visible = False          '"ProgressPicking"
                    ._chcolf01Int.Visible = False        '"ProgressPicking"
                    ._colf39String.Visible = True       'Caption = "Progress"
                    ._chcolf39String.Visible = True     'Caption = "Progress"
            End Select

            'Middle
            ._chcolk03String.Visible = False      '"No.PKB"
            ._chcolk02String.Visible = True       '"ProductCode"
            ._chcolf01Int.Visible = True          '"Picking"
            ._chcolf01SmallInt.Visible = True     '"Jml.Pcs"
            ._chcolf01Double.Visible = True       '"Jml.Berat"
            ._chcolk00Int.Visible = True          '"Tot.Picking"

            'Child
            ._gccolk00Boolean.Visible = True      '"#"
            ._gccolk00Int.Visible = False         '"#"
            ._gccolk01String.Visible = False       '"No.PKB"
            ._gccolk02String.Visible = False       '"ProductCode"
            ._gccolk03String.Visible = True       '"SKU"
            ._gccolf01String.Visible = True       '"Storage"
            ._gccolf02String.Visible = True       '"Brand"
            ._gccolf03String.Visible = True       '"Kadar"
            ._gccolf04String.Visible = False      '"Status"
            ._gccolf01SmallInt.Visible = True     '"Qty"
            ._gccolf01Double.Visible = True       '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexRefreshDisplayPKB()
        With _prop03GridParentChild
            'Parent
            ._colf02Date.VisibleIndex = 0           '"Tgl.PKB"
            ._colf02String.VisibleIndex = 1         '"Customer"
            ._colk02String.VisibleIndex = 2         '"No.PKB"
            ._colf12String.VisibleIndex = -1        '"KodeTransaksi"
            ._colf13String.VisibleIndex = 3         '"Current"
            ._colf28String.VisibleIndex = 4          '"Next Proses"
            ._colf29String.VisibleIndex = -1         '"NamaTransaksiNext"
            ._colf14String.VisibleIndex = 5       '"KodePICKER"
            ._colf15String.VisibleIndex = -1       '"PICKER"
            ._colf26String.VisibleIndex = 6       '"No.Picking"

            If (_prop07cNomorProses = "5051" Or _prop07cNomorProses = "100") Then 'Picking + Create SuratJalan'
                ._colf01Int.VisibleIndex = 7            '"ProgressPicking"
                ._colf39String.VisibleIndex = 8       'Caption = "Progress"
                ._colf16String.VisibleIndex = -1       '"EKSPEDISI"
                ._colf17String.VisibleIndex = -1       '"NamaEKSPEDISI"
                ._colf18String.VisibleIndex = -1       '"Resi"
                ._colf04String.VisibleIndex = 9         '"KAE"
                ._colf06String.VisibleIndex = 10         '"TOP"
                ._colf08String.VisibleIndex = 11         '"Brand"
                ._colf10String.VisibleIndex = 12         '"Kadar"
                ._colf11String.VisibleIndex = 13        '"Order"
                ._colf01SmallInt.VisibleIndex = 14      '"T.Qty"
                ._colf01Double.VisibleIndex = 15        '"T.Berat"
                ._colk00Int01.VisibleIndex = -1         '"Tot.Picking"
            Else
                ._colf01Int.VisibleIndex = -1            '"ProgressPicking"
                ._colf16String.VisibleIndex = 7       '"EKSPEDISI"
                ._colf17String.VisibleIndex = -1       '"NamaEKSPEDISI"
                ._colf18String.VisibleIndex = -1       '"Resi"
                ._colf04String.VisibleIndex = 8         '"KAE"
                ._colf06String.VisibleIndex = 9         '"TOP"
                ._colf08String.VisibleIndex = 11         '"Brand"
                ._colf10String.VisibleIndex = 10         '"Kadar"
                ._colf11String.VisibleIndex = 12        '"Order"
                ._colf01SmallInt.VisibleIndex = 13      '"T.Qty"
                ._colf01Double.VisibleIndex = 14        '"T.Berat"
                ._colk00Int01.VisibleIndex = -1         '"Tot.Picking"
                ._colf39String.VisibleIndex = -1       'Caption = "Progress"
            End If

            'Middle
            ._chcolk03String.VisibleIndex = -1      '"No.PKB"
            ._chcolk02String.VisibleIndex = 0      '"ProductCode"
            ._chcolf01SmallInt.VisibleIndex = 1     '"Jml.Pcs"
            ._chcolf01Double.VisibleIndex = 2       '"Jml.Berat"
            If (_prop07cNomorProses = "5051" Or _prop07cNomorProses = "100") Then 'Picking + Create SuratJalan'
                ._chcolf01Int.VisibleIndex = 3          '"Picking"
                ._chcolk00Int.VisibleIndex = 4          '"Tot.Picking"
                ._chcolf39String.VisibleIndex = 5       'Caption = "Progress"
            Else
                ._chcolf01Int.VisibleIndex = -1         '"Picking"
                ._chcolk00Int.VisibleIndex = -1         '"Tot.Picking"
                ._chcolf39String.VisibleIndex = -1       'Caption = "Progress"
            End If

            'Child
            ._gccolk00Boolean.VisibleIndex = 0      '"#"
            ._gccolk00Int.VisibleIndex = -1         '"#"
            ._gccolk01String.VisibleIndex = -1       '"No.PKB"
            ._gccolk02String.VisibleIndex = -1       '"ProductCode"
            ._gccolk03String.VisibleIndex = 1       '"SKU"
            ._gccolf01String.VisibleIndex = 2       '"Storage"
            ._gccolf02String.VisibleIndex = 4       '"Brand"
            ._gccolf03String.VisibleIndex = 3       '"Kadar"
            ._gccolf04String.VisibleIndex = -1      '"Status"
            ._gccolf01SmallInt.VisibleIndex = 5     '"Qty"
            ._gccolf01Double.VisibleIndex = 6       '"Berat"
        End With
    End Sub

    Private Sub _fx01FixedColumnDisplayPKB()
        'With _prop03Grid
        '    ._colf02Date.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left           '"Tgl.PKB"
        '    ._colf02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left         '"Customer"
        '    ._colk02String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left         '"No.PKB"
        '    ._colf13String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left          '"Current"

        '    '._colf04String.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right         '"KAE"
        '    '._colf04String.VisibleIndex = 9         '"KAE"
        '    '._colf06String.VisibleIndex = 10         '"TOP"
        '    '._colf08String.VisibleIndex = 11         '"Brand"
        '    '._colf10String.VisibleIndex = 12         '"Kadar"
        '    '._colf11String.VisibleIndex = 13        '"Order"
        '    '._colf01SmallInt.VisibleIndex = 14      '"T.Qty"
        '    '._colf01Double.VisibleIndex = 15        '"T.Berat"
        'End With
    End Sub

    Private Sub _wr01WriteRefreshDisplayPKB()
        With _prop03GridParentChild
            ._colf28String.OptionsColumn.ReadOnly = False       '"Next Proses"

            Select Case _prop07cNomorProses
                Case "5061"    '	NEW PKB CUSTOMER
                    ._colf14String.OptionsColumn.ReadOnly = True       '"PICKER"

                Case "5051"    'Picking + Create SuratJalan'
                    ._colf14String.OptionsColumn.ReadOnly = True       '"PICKER"
                    ._colf16String.OptionsColumn.ReadOnly = True       '"EKSPEDISI"
                    ._colf18String.OptionsColumn.ReadOnly = True       '"Resi"

                Case "505012"  'Airway Bill by Ekspedisi'
                    ._colf14String.OptionsColumn.ReadOnly = True       '"PICKER"
                    ._colf16String.OptionsColumn.ReadOnly = True       '"EKSPEDISI"
                    ._colf18String.OptionsColumn.ReadOnly = True       '"Resi"

                Case "505013"  'Confirm Pickup by Ekspedisi'
                Case "505014"  'Confirm Delivered by Ekspedisi'
                Case "505015"  'Confirm Delivered NON Ekspedisi'

                Case "100"
                    ._colf14String.OptionsColumn.ReadOnly = True       '"PICKER"
                    ._colf16String.OptionsColumn.ReadOnly = True       '"EKSPEDISI"
                    ._colf18String.OptionsColumn.ReadOnly = True       '"Resi"
            End Select

        End With


    End Sub

    Private Sub _ll01LainLainRefreshDisplayPKB()
        With _prop03GridParentChild
            With ._colf02Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With

            With ._colf28String
                .AppearanceHeader.ForeColor = Color.Navy
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceHeader.Font = New Font("Nirmala UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            End With

            With ._colf39String
                .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .AppearanceCell.Font = New Font("Courier New", 10, FontStyle.Bold, GraphicsUnit.Point)
                .AppearanceCell.ForeColor = Color.DarkBlue
            End With

            With ._chcolf39String
                .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .AppearanceCell.Font = New Font("Courier New", 10, FontStyle.Bold, GraphicsUnit.Point)
                .AppearanceCell.ForeColor = Color.DarkBlue
            End With
        End With
    End Sub

    Private Sub _wd240707WidthRefreshDisplayPKB()

        With _prop03GridParentChild
            ._colk00Boolean.Width = 81
            ._colk00Int.Width = 81
            ._colk00Boolean01.Width = 81
            ._colk00Int01.Width = 81
            ._colf01Memo.Width = 81
            ._colk01String.Width = 81
            ._colk02String.Width = 122
            ._colk03String.Width = 81
            ._colf01String.Width = 81
            ._colf02String.Width = 167
            ._colf03String.Width = 81
            ._colf04String.Width = 109
            ._colf05String.Width = 87
            ._colf06String.Width = 76
            ._colf07String.Width = 87
            ._colf08String.Width = 73
            ._colf09String.Width = 87
            ._colf10String.Width = 64
            ._colf11String.Width = 39
            ._colf12String.Width = 87
            ._colf13String.Width = 215
            ._colf14String.Width = 160
            ._colf15String.Width = 80
            ._colf16String.Width = 94
            ._colf17String.Width = 87
            ._colf18String.Width = 129
            ._colf19String.Width = 87
            ._colf20String.Width = 87
            ._colf21String.Width = 87
            ._colf22String.Width = 87
            ._colf23String.Width = 87
            ._colf24String.Width = 87
            ._colf25String.Width = 87
            ._colf26String.Width = 87
            ._colf27String.Width = 87
            ._colf28String.Width = 215
            ._colf29String.Width = 87
            ._colf30String.Width = 87
            ._colf31String.Width = 87
            ._colf32String.Width = 87
            ._colf33String.Width = 87
            ._colf34String.Width = 87
            ._colf35String.Width = 87
            ._colf36String.Width = 87
            ._colf37String.Width = 87
            ._colf38String.Width = 87
            ._colf39String.Width = 87
            ._colf40String.Width = 87
            ._colf01TinyInt.Width = 87
            ._colf01SmallInt.Width = 64
            ._colf01Int.Width = 75
            ._colf01Double.Width = 78
            ._colf02Double.Width = 87
            ._colf03Double.Width = 87
            ._colf01Date.Width = 87
            ._colf02Date.Width = 105
            ._colf03Date.Width = 87
            ._chcolk00Boolean.Width = 45
            ._chcolk00Int.Width = 81
            ._chcolk01String.Width = 133
            ._chcolk02String.Width = 148
            ._chcolk03String.Width = 164
            ._chcolf01String.Width = 82
            ._chcolf02String.Width = 72
            ._chcolf03String.Width = 60
            ._chcolf04String.Width = 81
            ._chcolf05String.Width = 87
            ._chcolf06String.Width = 87
            ._chcolf07String.Width = 87
            ._chcolf08String.Width = 87
            ._chcolf09String.Width = 87
            ._chcolf10String.Width = 87
            ._chcolf11String.Width = 87
            ._chcolf12String.Width = 87
            ._chcolf13String.Width = 87
            ._chcolf14String.Width = 87
            ._chcolf15String.Width = 87
            ._chcolf16String.Width = 87
            ._chcolf17String.Width = 87
            ._chcolf18String.Width = 87
            ._chcolf19String.Width = 87
            ._chcolf20String.Width = 87
            ._chcolf21String.Width = 87
            ._chcolf22String.Width = 87
            ._chcolf23String.Width = 87
            ._chcolf24String.Width = 87
            ._chcolf25String.Width = 87
            ._chcolf26String.Width = 87
            ._chcolf27String.Width = 87
            ._chcolf28String.Width = 87
            ._chcolf29String.Width = 87
            ._chcolf30String.Width = 87
            ._chcolf31String.Width = 87
            ._chcolf32String.Width = 87
            ._chcolf33String.Width = 87
            ._chcolf34String.Width = 87
            ._chcolf35String.Width = 87
            ._chcolf36String.Width = 87
            ._chcolf37String.Width = 87
            ._chcolf38String.Width = 87
            ._chcolf39String.Width = 87
            ._chcolf40String.Width = 87
            ._chcolf01TinyInt.Width = 87
            ._chcolf01SmallInt.Width = 87
            ._chcolf01Int.Width = 75
            ._chcolf01Double.Width = 87
            ._chcolf02Double.Width = 87
            ._chcolf03Double.Width = 87
            ._chcolf01Date.Width = 87
            ._chcolf02Date.Width = 87
            ._chcolf03Date.Width = 87
            ._gccolk00Boolean.Width = 41
            ._gccolk00Int.Width = 81
            ._gccolk01String.Width = 126
            ._gccolk02String.Width = 117
            ._gccolk03String.Width = 143
            ._gccolf01String.Width = 164
            ._gccolf02String.Width = 139
            ._gccolf03String.Width = 64
            ._gccolf04String.Width = 81
            ._gccolf05String.Width = 87
            ._gccolf06String.Width = 87
            ._gccolf07String.Width = 87
            ._gccolf08String.Width = 87
            ._gccolf09String.Width = 87
            ._gccolf10String.Width = 87
            ._gccolf11String.Width = 87
            ._gccolf12String.Width = 87
            ._gccolf13String.Width = 87
            ._gccolf14String.Width = 87
            ._gccolf15String.Width = 87
            ._gccolf16String.Width = 87
            ._gccolf17String.Width = 87
            ._gccolf18String.Width = 87
            ._gccolf19String.Width = 87
            ._gccolf20String.Width = 87
            ._gccolf21String.Width = 87
            ._gccolf22String.Width = 87
            ._gccolf23String.Width = 87
            ._gccolf24String.Width = 87
            ._gccolf25String.Width = 87
            ._gccolf26String.Width = 87
            ._gccolf27String.Width = 87
            ._gccolf28String.Width = 87
            ._gccolf29String.Width = 87
            ._gccolf30String.Width = 87
            ._gccolf31String.Width = 87
            ._gccolf32String.Width = 87
            ._gccolf33String.Width = 87
            ._gccolf34String.Width = 87
            ._gccolf35String.Width = 87
            ._gccolf36String.Width = 87
            ._gccolf37String.Width = 87
            ._gccolf38String.Width = 87
            ._gccolf39String.Width = 87
            ._gccolf40String.Width = 87
            ._gccolf01TinyInt.Width = 87
            ._gccolf01SmallInt.Width = 87
            ._gccolf01Int.Width = 87
            ._gccolf01Double.Width = 87
            ._gccolf02Double.Width = 87
            ._gccolf03Double.Width = 87
            ._gccolf01Date.Width = 87
            ._gccolf02Date.Width = 87
            ._gccolf03Date.Width = 87
        End With

    End Sub

#End Region

#Region "***** 10. Display-PROSES-PKB *****"

    Private Sub _cc01CaptionProsesPKB()
        With _prop03Grid
            ._colf33String.Caption = "SJ"
            ._colf05String.Caption = "ProductCode"
            ._colf04String.Caption = "SKU"
            '._colf01String.Caption = "Storage"
            '._colf04String.Caption = "Status"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
        End With
    End Sub

    Private Sub _vs01VisibilityProsesPKB()
        With _prop03Grid
            ._colf33String.Visible = True         '"SJ"
            ._colf05String.Visible = True         '"ProductCode"
            ._colf04String.Visible = True         '"SKU"
            '._colf01String.Visible = True         '"Storage"
            '._colf04String.Visible = True         '"Status"
            ._colf01SmallInt.Visible = True         '"Qty"
            ._colf01Double.Visible = True         '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexProsesPKB()
        With _prop03Grid
            ._colf33String.VisibleIndex = 0         '"SJ"
            ._colf05String.VisibleIndex = 1         '"ProductCode"
            ._colf04String.VisibleIndex = 2         '"SKU"
            '._colf01String.VisibleIndex = 2         '"Storage"
            '._colf04String.VisibleIndex = 3         '"Status"
            ._colf01SmallInt.VisibleIndex = 3         '"Qty"
            ._colf01Double.VisibleIndex = 4         '"Berat"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratProsesPKB()
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

    Private Sub _wd240707WidthucWS24H201PROSESPKB()
        With _prop03Grid
            ._colk00Boolean.Width = 79
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 101
            ._colk03String.Width = 98
            ._colf01String.Width = 118
            ._colf02String.Width = 79
            ._colf03String.Width = 79
            ._colf04String.Width = 150
            ._colf05String.Width = 150
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
            ._colf33String.Width = 150
            ._colf34String.Width = 79
            ._colf35String.Width = 79
            ._colf36String.Width = 79
            ._colf37String.Width = 79
            ._colf38String.Width = 79
            ._colf39String.Width = 79
            ._colf40String.Width = 79
            ._colf01TinyInt.Width = 85
            ._colf01SmallInt.Width = 60
            ._colf01Int.Width = 85
            ._colf01Double.Width = 75
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub

#End Region

#Region "***** 30. Display-STOCK-FOR-SALE *****"

    Private Sub _cc30GridCaptionStockForSale()
        With _prop03Grid
            With ._colf01Date
                .Caption = "Tgl"
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With
            ._colf18String.Caption = "No.SuratJalan"
            ._colf02String.Caption = "No.Order"
            ._colf01String.Caption = "ProductCode"
            ._colk03String.Caption = "SKU"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf10String.Caption = "Kadar"
            ._colf16String.Caption = "Brand"
            ._colf12String.Caption = "Item"
            ._colf23String.Caption = "Warna"
            ._colf14String.Caption = "Size"
        End With
    End Sub

    Private Sub _vs30GridVisibilityStockForSale()
        With _prop03Grid
            ._colf01Date.Visible = True         '"Tgl"
            ._colf01String.Visible = True         '"ProductCode"
            ._colf18String.Visible = True       '"No.Surat Jalan"
            ._colf02String.Visible = True       '"No.Order"
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

    Private Sub _vs30GridVisibilityIndexStockForSale()
        With _prop03Grid
            ._colf01Date.VisibleIndex = 0           '"Tgl"
            ._colf18String.VisibleIndex = 1      '"No.Surat Jalan"
            ._colf02String.VisibleIndex = 2      '"No.Order"
            ._colf01String.VisibleIndex = 3         '"ProductCode"
            ._colk03String.VisibleIndex = 4         '"SKU"
            ._colf01SmallInt.VisibleIndex = 5       '"Pcs"
            ._colf01Double.VisibleIndex = 6         '"Berat"
            ._colf10String.VisibleIndex = 7         '"Kadar"
            ._colf16String.VisibleIndex = 8         '"Brand"
            ._colf23String.VisibleIndex = 9         '"Warna"
            ._colf12String.VisibleIndex = 10         '"Item"
            ._colf14String.VisibleIndex = 11         '"Size"
        End With
    End Sub

#End Region

#Region "***** 31. Display-ENTRY-SKU-FOR-SALE *****"

    Private Sub _cc31GridCaptionEntrySKUForSale()
        With _prop03Grid
            With ._colf01Date
                .Caption = "Tgl"
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With
            ._colf18String.Caption = "No.SJ"
            ._colf40String.Caption = "No.SJ Settle"
            ._colf02String.Caption = "No.Order"
            ._colf20String.Caption = "No.GJ"
            ._colf05String.Caption = "Customer"
            ._colf22String.Caption = "TOP"
            ._colf01String.Caption = "ProductCode"
            ._colk03String.Caption = "SKU"
            ._colf01SmallInt.Caption = "Pcs"
            ._colf01Double.Caption = "Gr"
            ._colf10String.Caption = "Kadar"
            ._colf16String.Caption = "Brand"
            ._colf12String.Caption = "Item"
            ._colf23String.Caption = "Warna"
            ._colf14String.Caption = "Size"
        End With
    End Sub

    Private Sub _vs31GridVisibilityEntrySKUForSale()
        With _prop03Grid
            ._colf01Date.Visible = True         '"Tgl"
            ._colf18String.Visible = True       '"No.Surat Jalan"
            ._colf40String.Visible = True
            ._colf02String.Visible = True       '"No.Order"
            ._colf20String.Visible = True         '"No.GJ"
            ._colf05String.Visible = True         '"Customer"
            ._colf22String.Visible = True         '"TOP"
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

    Private Sub _vs31GridVisibilityIndexEntrySKUForSale()
        With _prop03Grid
            ._colf01Date.VisibleIndex = 0           '"Tgl"
            ._colf18String.VisibleIndex = 1      '"No.Surat Jalan"
            ._colf40String.VisibleIndex = 2
            ._colf02String.VisibleIndex = 3     '"No.Order"
            ._colf20String.VisibleIndex = 4         '"No.GJ"
            ._colf05String.VisibleIndex = 5         '"Customer"
            ._colf22String.VisibleIndex = 6         '"TOP"
            ._colf01String.VisibleIndex = 7         '"ProductCode"
            ._colk03String.VisibleIndex = 8         '"SKU"
            ._colf01SmallInt.VisibleIndex = 9       '"Pcs"
            ._colf01Double.VisibleIndex = 10         '"Berat"
            ._colf10String.VisibleIndex = 11         '"Kadar"
            ._colf16String.VisibleIndex = 12        '"Brand"
            ._colf23String.VisibleIndex = 13         '"Warna"
            ._colf12String.VisibleIndex = 14         '"Item"
            ._colf14String.VisibleIndex = 15         '"Size"
        End With
    End Sub
    Private Sub _vs31GridWriteEntrySKUForSale()
        With _prop03Grid
            With ._colf20String
                .OptionsColumn.ReadOnly = False         '"No.GJ"
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
        End With
    End Sub

#End Region

#Region "***** 5052. Display-Create-SuratJalan (ucWS24H201PROSESPKB) *****"
    Private Sub _cc01Caption5052CreateSJ()
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colf02Date.Caption = "Tgl.Order"
            ._colk02String.Caption = "No.Order"
            ._colf02String.Caption = "Kepada"
            ._colf08String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf06String.Caption = "TOP"
            ._colf04String.Caption = "KAE"
        End With
    End Sub

    Private Sub _vs01Visibility5052CreateSJ()
        With _prop03Grid
            ._colk00Boolean.Visible = True         '"#"
            ._colf02Date.Visible = True         '"Tgl.PKB"
            ._colk02String.Visible = True         '"PKB"
            ._colf02String.Visible = True         '"Kepada"
            ._colf08String.Visible = True         '"Brand"
            ._colf10String.Visible = True         '"Kadar"
            ._colf01SmallInt.Visible = True         '"Pcs"
            ._colf01Double.Visible = True         '"Berat"
            ._colf06String.Visible = True         '"TOP"
            ._colf04String.Visible = True         '"KAE"
        End With
    End Sub

    Private Sub _vs02VisibilityIndex5052CreateSJ()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0         '"#"
            ._colf02Date.VisibleIndex = 1            '"Tgl.PKB"
            ._colk02String.VisibleIndex = 2         '"PKB"
            ._colf02String.VisibleIndex = 3         '"Kepada"
            ._colf08String.VisibleIndex = 5         '"Brand"
            ._colf10String.VisibleIndex = 4         '"Kadar"
            ._colf01SmallInt.VisibleIndex = 6         '"Pcs"
            ._colf01Double.VisibleIndex = 7        '"Berat"
            ._colf06String.VisibleIndex = 8         '"TOP"
            ._colf04String.VisibleIndex = 9         '"KAE"
        End With
    End Sub

    Private Sub _wr01Write5052CreateSJ()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False       '"Next Proses"
        End With
    End Sub

    Private Sub _ll01LainLain5052CreateSJ()
        With _prop03GridParentChild
            With ._colf02Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With
            With ._colk00Boolean
                .AppearanceHeader.ForeColor = Color.Navy
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceHeader.Font = New Font("Nirmala UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            End With

            With ._colf06String
                .AppearanceHeader.ForeColor = Color.Navy
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceHeader.Font = New Font("Nirmala UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            End With

            With ._colf04String
                .AppearanceHeader.ForeColor = Color.Navy
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceHeader.Font = New Font("Nirmala UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            End With
        End With
    End Sub

    Private Sub _wd240707Width5052CreateSJ()
        With _prop03Grid
            ._colk00Boolean.Width = 40         '"#"
            ._colf02Date.Width = 85           '"Tgl.PKB"
            ._colk02String.Width = 120         '"PKB"
            ._colf02String.Width = 200         '"Kepada"
            ._colf08String.Width = 60         '"Brand"
            ._colf10String.Width = 60         '"Kadar"
            ._colf01SmallInt.Width = 40         '"Pcs"
            ._colf01Double.Width = 70         '"Berat"
            ._colf06String.Width = 100         '"TOP"
            ._colf04String.Width = 200         '"KAE"
        End With
    End Sub

#End Region

#Region "***** 5052-505015. SuratJalan Proses (ucWS24G301OUTBOUNDPKB) *****"

    Private Sub _rsRepoSetting505015SJProses()
        With _prop03GridParentChild
            ._colf29String.ColumnEdit = _prop04RepoMaster      '"Next.SJ"
        End With
    End Sub

    Public Sub _cc01Caption505015SJProses()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.Caption = "#"
            ._colf01Date.Caption = "Tgl.Order"
            ._colk02String.Caption = "SuratJalan"
            ._colf02String.Caption = "Customer"
            ._colf04String.Caption = "KAE"
            ._colf06String.Caption = "TOP"
            ._colf08String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf15String.Caption = "No.Order"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf12String.Caption = "KodeTransaksiCurrentSJ"
            ._colf13String.Caption = "Current.SJ"
            ._colf28String.Caption = "KodeTransaksiNextProsesSJ"
            ._colf29String.Caption = "Next.SJ"
            ._colf20String.Caption = "Ekspedisi"
            ._colf21String.Caption = "No.Resi"

            'Middle
            ._chcolf33String.Caption = "SJ"
            ._chcolf03String.Caption = "No.Order"
            ._chcolf05String.Caption = "ProductCode"
            ._chcolf01SmallInt.Caption = "Tot.Qty"
            ._chcolf01Double.Caption = "Tot.Gram"
            ._chcolf02String.Caption = "Picker"

            'Child
            ._gccolf33String.Caption = "SJ"
            ._gccolf03String.Caption = "No.Order"
            ._gccolf05String.Caption = "ProductCode"
            ._gccolf04String.Caption = "SKU"
            ._gccolf01SmallInt.Caption = "Qty"
            ._gccolf01Double.Caption = "Gram"
        End With
    End Sub

    Public Sub _vs01Visibility505015SJProses()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.Visible = True
            ._colf01Date.Visible = True           '"Tgl.SJ"
            ._colk02String.Visible = True         '"SuratJalan"
            ._colf02String.Visible = True         '"Customer"
            ._colf04String.Visible = True         '"KAE"
            ._colf06String.Visible = True         '"TOP"
            ._colf08String.Visible = True         '"Brand"
            ._colf10String.Visible = True         '"Kadar"
            ._colf15String.Visible = True         '"Order"
            ._colf01SmallInt.Visible = True       '"Pcs"
            ._colf01Double.Visible = True         '"Berat"
            ._colf12String.Visible = False        '"KodeTransaksiCurrentSJ"
            ._colf13String.Visible = True         '"Current.SJ"
            ._colf28String.Visible = False        '"KodeTransaksiNextProsesSJ"
            ._colf29String.Visible = True         '"Next.SJ"
            ._colf20String.Visible = True         '"Ekspedisi"
            ._colf21String.Visible = True         '"No.Resi"

            'Middle
            ._chcolf33String.Visible = False        '"SJ"
            ._chcolf03String.Visible = True         '"PKB"
            ._chcolf05String.Visible = True         '"ProductCode"
            ._chcolf01SmallInt.Visible = True       '"Jml.Pcs"
            ._chcolf01Double.Visible = True         '"Jml.Berat"
            ._chcolf02String.Visible = True         '"Picker"

            'Child
            ._gccolf33String.Visible = False        '"SJ"
            ._gccolf03String.Visible = False        '"PKB"
            ._gccolf05String.Visible = False        '"ProductCode"
            ._gccolf04String.Visible = True         '"SKU"
            ._gccolf01SmallInt.Visible = True       '"Pcs"
            ._gccolf01Double.Visible = True         '"Berat"
        End With

    End Sub

    Public Sub _vs02VisibilityIndex505015SJProses()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.VisibleIndex = 0
            ._colf01Date.VisibleIndex = 1           '"Tgl.SJ"
            ._colk02String.VisibleIndex = 2         '"SuratJalan"
            ._colf02String.VisibleIndex = 3         '"Customer"

            ._colf12String.VisibleIndex = -1        '"KodeTransaksiCurrentSJ"
            ._colf13String.VisibleIndex = 4         '"Current.SJ"
            ._colf28String.VisibleIndex = -1        '"KodeTransaksiNextProsesSJ"
            ._colf29String.VisibleIndex = 5         '"Next.SJ"

            ._colf01SmallInt.VisibleIndex = 6       '"Pcs"
            ._colf01Double.VisibleIndex = 7         '"Berat"
            ._colf08String.VisibleIndex = 8         '"Brand"
            ._colf10String.VisibleIndex = 9         '"Kadar"
            ._colf06String.VisibleIndex = 10         '"TOP"
            ._colf04String.VisibleIndex = 11         '"KAE"
            ._colf15String.VisibleIndex = 12        '"Order"
            ._colf20String.VisibleIndex = 13        '"Ekspedisi"
            ._colf21String.VisibleIndex = 14        '"No.Resi"

            'Middle
            ._chcolf33String.VisibleIndex = -1        '"SJ"
            ._chcolf03String.VisibleIndex = 0         '"PKB"
            ._chcolf05String.VisibleIndex = 1         '"ProductCode"
            ._chcolf01SmallInt.VisibleIndex = 2       '"Jml.Pcs"
            ._chcolf01Double.VisibleIndex = 3         '"Jml.Berat"
            ._chcolf02String.VisibleIndex = 4         '"Picker"

            'Child
            ._gccolk01String.VisibleIndex = -1        '"SJ"
            ._gccolk02String.VisibleIndex = -1        '"PKB"
            ._gccolk03String.VisibleIndex = -1        '"ProductCode"
            ._gccolf04String.VisibleIndex = 0         '"SKU"
            ._gccolf01SmallInt.VisibleIndex = 1       '"Pcs"
            ._gccolf01Double.VisibleIndex = 2         '"Berat"
        End With

    End Sub

    Public Sub _wr01Write505015SJProses()
        With _prop03GridParentChild
            ._colf29String.OptionsColumn.ReadOnly = False      '"Next.SJ"
        End With
    End Sub

    Public Sub _ll01LainLain505015SJProses()
        With _prop03GridParentChild
            With ._colf01Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With
            ._colk00Boolean.OptionsColumn.ReadOnly = False

            With ._colf13String
                .AppearanceHeader.ForeColor = Color.Yellow
                .AppearanceHeader.BackColor = Color.Green
                .AppearanceHeader.Font = New Font("Nirmala UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            End With

            With ._colf29String
                .AppearanceHeader.ForeColor = Color.Navy
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceHeader.Font = New Font("Nirmala UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            End With

        End With
    End Sub

    Private Sub _wd240707Width505015SJProses()
        With _prop03GridParentChild
            ._colk00Boolean.Width = 48
            ._colk00Int.Width = 81
            ._colk00Boolean01.Width = 81
            ._colk00Int01.Width = 81
            ._colf01Memo.Width = 81
            ._colk01String.Width = 81
            ._colk02String.Width = 128
            ._colk03String.Width = 81
            ._colf01String.Width = 81
            ._colf02String.Width = 128
            ._colf03String.Width = 81
            ._colf04String.Width = 100
            ._colf05String.Width = 87
            ._colf06String.Width = 58
            ._colf07String.Width = 87
            ._colf08String.Width = 51
            ._colf09String.Width = 87
            ._colf10String.Width = 51
            ._colf11String.Width = 87
            ._colf12String.Width = 87
            ._colf13String.Width = 86
            ._colf14String.Width = 87
            ._colf15String.Width = 69
            ._colf16String.Width = 87
            ._colf17String.Width = 87
            ._colf18String.Width = 87
            ._colf19String.Width = 87
            ._colf20String.Width = 68
            ._colf21String.Width = 60
            ._colf22String.Width = 87
            ._colf23String.Width = 87
            ._colf24String.Width = 87
            ._colf25String.Width = 87
            ._colf26String.Width = 87
            ._colf27String.Width = 87
            ._colf28String.Width = 87
            ._colf29String.Width = 63
            ._colf30String.Width = 87
            ._colf31String.Width = 87
            ._colf32String.Width = 87
            ._colf33String.Width = 87
            ._colf34String.Width = 87
            ._colf35String.Width = 87
            ._colf36String.Width = 87
            ._colf37String.Width = 87
            ._colf38String.Width = 87
            ._colf39String.Width = 87
            ._colf40String.Width = 87
            ._colf01TinyInt.Width = 87
            ._colf01SmallInt.Width = 38
            ._colf01Int.Width = 87
            ._colf01Double.Width = 51
            ._colf02Double.Width = 87
            ._colf03Double.Width = 87
            ._colf01Date.Width = 72
            ._colf02Date.Width = 87
            ._colf03Date.Width = 87
            ._chcolk00Boolean.Width = 81
            ._chcolk00Int.Width = 81
            ._chcolk01String.Width = 81
            ._chcolk02String.Width = 81
            ._chcolk03String.Width = 81
            ._chcolf01String.Width = 81
            ._chcolf02String.Width = 150
            ._chcolf03String.Width = 158
            ._chcolf04String.Width = 81
            ._chcolf05String.Width = 126
            ._chcolf06String.Width = 87
            ._chcolf07String.Width = 87
            ._chcolf08String.Width = 87
            ._chcolf09String.Width = 87
            ._chcolf10String.Width = 87
            ._chcolf11String.Width = 87
            ._chcolf12String.Width = 87
            ._chcolf13String.Width = 87
            ._chcolf14String.Width = 87
            ._chcolf15String.Width = 87
            ._chcolf16String.Width = 87
            ._chcolf17String.Width = 87
            ._chcolf18String.Width = 87
            ._chcolf19String.Width = 87
            ._chcolf20String.Width = 87
            ._chcolf21String.Width = 87
            ._chcolf22String.Width = 87
            ._chcolf23String.Width = 87
            ._chcolf24String.Width = 87
            ._chcolf25String.Width = 87
            ._chcolf26String.Width = 87
            ._chcolf27String.Width = 87
            ._chcolf28String.Width = 87
            ._chcolf29String.Width = 87
            ._chcolf30String.Width = 87
            ._chcolf31String.Width = 87
            ._chcolf32String.Width = 87
            ._chcolf33String.Width = 87
            ._chcolf34String.Width = 87
            ._chcolf35String.Width = 87
            ._chcolf36String.Width = 87
            ._chcolf37String.Width = 87
            ._chcolf38String.Width = 87
            ._chcolf39String.Width = 87
            ._chcolf40String.Width = 87
            ._chcolf01TinyInt.Width = 87
            ._chcolf01SmallInt.Width = 74
            ._chcolf01Int.Width = 87
            ._chcolf01Double.Width = 87
            ._chcolf02Double.Width = 87
            ._chcolf03Double.Width = 87
            ._chcolf01Date.Width = 87
            ._chcolf02Date.Width = 87
            ._chcolf03Date.Width = 87
            ._gccolk00Boolean.Width = 81
            ._gccolk00Int.Width = 81
            ._gccolk01String.Width = 81
            ._gccolk02String.Width = 81
            ._gccolk03String.Width = 81
            ._gccolf01String.Width = 129
            ._gccolf02String.Width = 114
            ._gccolf03String.Width = 81
            ._gccolf04String.Width = 125
            ._gccolf05String.Width = 87
            ._gccolf06String.Width = 87
            ._gccolf07String.Width = 87
            ._gccolf08String.Width = 87
            ._gccolf09String.Width = 87
            ._gccolf10String.Width = 87
            ._gccolf11String.Width = 87
            ._gccolf12String.Width = 87
            ._gccolf13String.Width = 87
            ._gccolf14String.Width = 87
            ._gccolf15String.Width = 87
            ._gccolf16String.Width = 87
            ._gccolf17String.Width = 87
            ._gccolf18String.Width = 87
            ._gccolf19String.Width = 87
            ._gccolf20String.Width = 87
            ._gccolf21String.Width = 87
            ._gccolf22String.Width = 87
            ._gccolf23String.Width = 87
            ._gccolf24String.Width = 87
            ._gccolf25String.Width = 87
            ._gccolf26String.Width = 87
            ._gccolf27String.Width = 87
            ._gccolf28String.Width = 87
            ._gccolf29String.Width = 87
            ._gccolf30String.Width = 87
            ._gccolf31String.Width = 87
            ._gccolf32String.Width = 87
            ._gccolf33String.Width = 87
            ._gccolf34String.Width = 87
            ._gccolf35String.Width = 87
            ._gccolf36String.Width = 87
            ._gccolf37String.Width = 87
            ._gccolf38String.Width = 87
            ._gccolf39String.Width = 87
            ._gccolf40String.Width = 87
            ._gccolf01TinyInt.Width = 87
            ._gccolf01SmallInt.Width = 74
            ._gccolf01Int.Width = 87
            ._gccolf01Double.Width = 87
            ._gccolf02Double.Width = 87
            ._gccolf03Double.Width = 87
            ._gccolf01Date.Width = 87
            ._gccolf02Date.Width = 87
            ._gccolf03Date.Width = 87
        End With
    End Sub

#End Region

#Region "***** 41. Rpt Tracking SKU (rptWS23LH01TrackingSKU) *****"
    Private Sub _cc01CaptionRptTrackingSKU()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.Caption = "#"
            ._colk03String.Caption = "SKU"
            ._colf03String.Caption = "Transaksi"
            ._colf07String.Caption = "Location"
            '._colf13String.Caption = "Approved By"
            '._colf14String.Caption = "Approved Via"
            ._colf19String.Caption = "Stock"
            ._colf20String.Caption = "Note"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            '._colf02Date.Caption = "Tgl Mutasi"
            ._colf01Datetime.Caption = "LastUpdated"

            'Child
            ._chcolf03String.Caption = "Transaksi"
            ._chcolf07String.Caption = "Location"
            '._chcolf13String.Caption = "Approved By"
            '._chcolf14String.Caption = "Approved Via"
            ._chcolf19String.Caption = "Stock"
            ._chcolf20String.Caption = "Note"
            ._chcolf01SmallInt.Caption = "Qty"
            ._chcolf01Double.Caption = "Gram"
            '._chcolf02Date.Caption = "Tgl Mutasi"
            ._chcolf01Datetime.Caption = "TimeLog"
        End With
    End Sub

    Private Sub _vs01VisibilityRptTrackingSKU()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.Visible = True
            ._colk03String.Visible = True           '"Transaksi"
            ._colf03String.Visible = True           '"Transaksi"
            ._colf07String.Visible = True           '"SLoc"
            '._colf13String.Visible = True           '"Approved By"
            '._colf14String.Visible = True           '"Approved Via"
            ._colf19String.Visible = True           '"Status"
            ._colf20String.Visible = True           '"Note"
            ._colf01SmallInt.Visible = True           '"Pcs"
            ._colf01Double.Visible = True           '"Berat"
            '._colf02Date.Visible = True           '"Tgl Mutasi"
            ._colf01Datetime.Visible = True           '"lastupdated"

            'Child
            ._chcolf03String.Visible = True           '"Transaksi"
            ._chcolf07String.Visible = True           '"SLoc"
            '._colf13String.Visible = True           '"Approved By"
            '._colf14String.Visible = True           '"Approved Via"
            ._chcolf19String.Visible = True           '"Status"
            ._chcolf20String.Visible = True           '"Note"
            ._chcolf01SmallInt.Visible = True           '"Pcs"
            ._chcolf01Double.Visible = True           '"Berat"
            '._colf02Date.Visible = True           '"Tgl Mutasi"
            ._chcolf01Datetime.Visible = True           '"Tgl Approved"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexRptTrackingSKU()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.VisibleIndex = 0
            ._colf01Datetime.VisibleIndex = 1             '"Tgl Approved"
            ._colk03String.VisibleIndex = 2           '"SKU"
            ._colf19String.VisibleIndex = 3           '"Status"
            ._colf07String.VisibleIndex = 4           '"SLoc"
            ._colf03String.VisibleIndex = 5           '"Transaksi"
            '._colf02Date.VisibleIndex = 2             '"Tgl Mutasi"
            '._colf13String.VisibleIndex = 4           '"Approved By"
            '._colf14String.VisibleIndex = 5           '"Approved Via"
            ._colf01SmallInt.VisibleIndex = 6         '"Pcs"
            ._colf01Double.VisibleIndex = 7           '"Berat"
            ._colf20String.VisibleIndex = 8           '"Note"

            'Child
            ._chcolf01Datetime.VisibleIndex = 0             '"Tgl Approved"
            ._chcolf19String.VisibleIndex = 1           '"Status"
            ._chcolf07String.VisibleIndex = 2           '"SLoc"
            ._chcolf03String.VisibleIndex = 3           '"Transaksi"
            '._chcolf02Date.VisibleIndex = 2             '"Tgl Mutasi"
            '._chcolf13String.VisibleIndex = 4           '"Approved By"
            '._chcolf14String.VisibleIndex = 5           '"Approved Via"
            ._chcolf01SmallInt.VisibleIndex = 4         '"Pcs"
            ._chcolf01Double.VisibleIndex = 5           '"Berat"
            ._chcolf20String.VisibleIndex = 6           '"Note"
        End With
    End Sub

    Public Sub _llLainLain42TrackingSKU()
        With _prop03GridParentChild
            With ._colf01Datetime
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss.fff"
            End With
            With ._chcolf01Datetime
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.DateTime
                    .FormatString = "dd/MM/yyyy HH:mm:ss.fff"
                End With
            End With

            With .GridView1
                .OptionsView.ShowFooter = True
                With .Columns("f01Datetime")
                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .SummaryItem.DisplayFormat = "{0:n0} Rows"
                End With

                With .Columns("k03String")
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

            With .GridView2
                .OptionsView.ShowFooter = True
                With .Columns("f01Datetime")
                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .SummaryItem.DisplayFormat = "{0:n0} Rows"
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

            ._colk00Boolean.OptionsColumn.ReadOnly = False
            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With
            With .GridView2
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With
        End With
    End Sub

    Private Sub _wd240707WidthtrackingSKU()
        With _prop03GridParentChild
            ._colk00Boolean.Width = 81
            ._colk00Int.Width = 81
            ._colk00Boolean01.Width = 81
            ._colk00Int01.Width = 81
            ._colf01Memo.Width = 81
            ._colk01String.Width = 81
            ._colk02String.Width = 120
            ._colk03String.Width = 106
            ._colf01String.Width = 81
            ._colf02String.Width = 182
            ._colf03String.Width = 208
            ._colf04String.Width = 81
            ._colf05String.Width = 87
            ._colf06String.Width = 87
            ._colf07String.Width = 191
            ._colf08String.Width = 87
            ._colf09String.Width = 87
            ._colf10String.Width = 87
            ._colf11String.Width = 89
            ._colf12String.Width = 87
            ._colf13String.Width = 155
            ._colf14String.Width = 87
            ._colf15String.Width = 87
            ._colf16String.Width = 87
            ._colf17String.Width = 87
            ._colf18String.Width = 87
            ._colf19String.Width = 160
            ._colf20String.Width = 273
            ._colf21String.Width = 87
            ._colf22String.Width = 87
            ._colf23String.Width = 87
            ._colf24String.Width = 87
            ._colf25String.Width = 87
            ._colf26String.Width = 87
            ._colf27String.Width = 87
            ._colf28String.Width = 87
            ._colf29String.Width = 87
            ._colf30String.Width = 87
            ._colf31String.Width = 87
            ._colf32String.Width = 87
            ._colf33String.Width = 87
            ._colf34String.Width = 87
            ._colf35String.Width = 87
            ._colf36String.Width = 87
            ._colf37String.Width = 87
            ._colf38String.Width = 87
            ._colf39String.Width = 87
            ._colf40String.Width = 87
            ._colf01TinyInt.Width = 87
            ._colf01SmallInt.Width = 46
            ._colf01Int.Width = 87
            ._colf01Double.Width = 58
            ._colf02Double.Width = 87
            ._colf03Double.Width = 87
            ._colf01Date.Width = 87
            ._colf02Date.Width = 87
            ._colf03Date.Width = 87
            ._chcolk00Boolean.Width = 81
            ._chcolk00Int.Width = 81
            ._chcolk01String.Width = 81
            ._chcolk02String.Width = 81
            ._chcolk03String.Width = 139
            ._chcolf01String.Width = 81
            ._chcolf02String.Width = 81
            ._chcolf03String.Width = 227
            ._chcolf04String.Width = 81
            ._chcolf05String.Width = 87
            ._chcolf06String.Width = 87
            ._chcolf07String.Width = 206
            ._chcolf08String.Width = 87
            ._chcolf09String.Width = 87
            ._chcolf10String.Width = 87
            ._chcolf11String.Width = 87
            ._chcolf12String.Width = 87
            ._chcolf13String.Width = 240
            ._chcolf14String.Width = 87
            ._chcolf15String.Width = 87
            ._chcolf16String.Width = 87
            ._chcolf17String.Width = 87
            ._chcolf18String.Width = 87
            ._chcolf19String.Width = 184
            ._chcolf20String.Width = 281
            ._chcolf21String.Width = 87
            ._chcolf22String.Width = 87
            ._chcolf23String.Width = 87
            ._chcolf24String.Width = 87
            ._chcolf25String.Width = 87
            ._chcolf26String.Width = 87
            ._chcolf27String.Width = 87
            ._chcolf28String.Width = 87
            ._chcolf29String.Width = 87
            ._chcolf30String.Width = 87
            ._chcolf31String.Width = 87
            ._chcolf32String.Width = 87
            ._chcolf33String.Width = 87
            ._chcolf34String.Width = 87
            ._chcolf35String.Width = 87
            ._chcolf36String.Width = 87
            ._chcolf37String.Width = 87
            ._chcolf38String.Width = 87
            ._chcolf39String.Width = 87
            ._chcolf40String.Width = 87
            ._chcolf01TinyInt.Width = 87
            ._chcolf01SmallInt.Width = 51
            ._chcolf01Int.Width = 87
            ._chcolf01Double.Width = 64
            ._chcolf02Double.Width = 87
            ._chcolf03Double.Width = 87
            ._chcolf01Date.Width = 87
            ._chcolf02Date.Width = 87
            ._chcolf03Date.Width = 87
            ._gccolk00Boolean.Width = 81
            ._gccolk00Int.Width = 81
            ._gccolk01String.Width = 81
            ._gccolk02String.Width = 81
            ._gccolk03String.Width = 81
            ._gccolf01String.Width = 81
            ._gccolf02String.Width = 81
            ._gccolf03String.Width = 81
            ._gccolf04String.Width = 81
            ._gccolf05String.Width = 87
            ._gccolf06String.Width = 87
            ._gccolf07String.Width = 87
            ._gccolf08String.Width = 87
            ._gccolf09String.Width = 87
            ._gccolf10String.Width = 87
            ._gccolf11String.Width = 87
            ._gccolf12String.Width = 87
            ._gccolf13String.Width = 87
            ._gccolf14String.Width = 87
            ._gccolf15String.Width = 87
            ._gccolf16String.Width = 87
            ._gccolf17String.Width = 87
            ._gccolf18String.Width = 87
            ._gccolf19String.Width = 87
            ._gccolf20String.Width = 87
            ._gccolf21String.Width = 87
            ._gccolf22String.Width = 87
            ._gccolf23String.Width = 87
            ._gccolf24String.Width = 87
            ._gccolf25String.Width = 87
            ._gccolf26String.Width = 87
            ._gccolf27String.Width = 87
            ._gccolf28String.Width = 87
            ._gccolf29String.Width = 87
            ._gccolf30String.Width = 87
            ._gccolf31String.Width = 87
            ._gccolf32String.Width = 87
            ._gccolf33String.Width = 87
            ._gccolf34String.Width = 87
            ._gccolf35String.Width = 87
            ._gccolf36String.Width = 87
            ._gccolf37String.Width = 87
            ._gccolf38String.Width = 87
            ._gccolf39String.Width = 87
            ._gccolf40String.Width = 87
            ._gccolf01TinyInt.Width = 87
            ._gccolf01SmallInt.Width = 87
            ._gccolf01Int.Width = 87
            ._gccolf01Double.Width = 87
            ._gccolf02Double.Width = 87
            ._gccolf03Double.Width = 87
            ._gccolf01Date.Width = 87
            ._gccolf02Date.Width = 87
            ._gccolf03Date.Width = 87
        End With
    End Sub



#End Region

#Region "***** 42. Rpt Tracking PKB (rptWS23LH01TrackingSKU) *****"

    Public Sub _cc01Caption42TrackingPKB()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.Caption = "#"
            ._colk02String.Caption = "No.Order"
            ._colf02String.Caption = "Customer"
            ._colf11String.Caption = "JenisOrder"
            ._colf13String.Caption = "Proses"
            ._colf01SmallInt.Caption = "Qty.Order"
            ._colf01Double.Caption = "Gr.Order"
            ._colf01Datetime.Caption = "OrderDate"
            'Child
            ._chcolf13String.Caption = "Proses"
            ._chcolk03String.Caption = "No.Doc"
            ._chcolf20String.Caption = "Ekspedisi"
            ._chcolf18String.Caption = "Picker"
            ._chcolf21String.Caption = "No.Resi"
            ._chcolf02Double.Caption = "Gr.Picking"
            ._chcolf01Int.Caption = "Qty.Picking"
            ._chcolf01Datetime.Caption = "TimeLog"

        End With
    End Sub

    Public Sub _vs02Visibility42TrtackingPKB()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.Visible = True
            ._colk02String.Visible = True         '"No.PKB"
            ._colf02String.Visible = True         '"Customer"
            ._colf11String.Visible = True         '"Jenis Order"
            ._colf13String.Visible = True         '"Proses"
            ._colf01SmallInt.Visible = True         '"Pcs.PKB"
            ._colf01Double.Visible = True         '"B.PKB"
            ._colf01Datetime.Visible = True         '"Tgl.PKB"
            'Child
            ._chcolf13String.Visible = True         '"Proses"
            ._chcolk03String.Visible = True         '"Status"
            ._chcolf20String.Visible = True         '"Ekspedisi"
            ._chcolf18String.Visible = True         '"Picker"
            ._chcolf21String.Visible = True         '"No.Resi"
            ._chcolf02Double.Visible = True         '"B.Picking"
            ._chcolf01Int.Visible = True         '"Pcs.Picking"
            ._chcolf01Datetime.Visible = True         '"tgl.Proses"
        End With
    End Sub

    Public Sub _vs02VisibilityIndex42TrtackingPKB()
        With _prop03GridParentChild
            'Parent
            ._colk00Boolean.VisibleIndex = 0
            ._colf01Datetime.VisibleIndex = 1       ' "Tgl.PKB"
            ._colk02String.VisibleIndex = 2       ' "No.PKB"
            ._colf11String.VisibleIndex = 3      ' "Jenis Order"
            ._colf02String.VisibleIndex = 4       ' "Customer"
            ._colf13String.VisibleIndex = 5       ' "Proses"
            ._colf01SmallInt.VisibleIndex = 6       ' "Pcs.PKB"
            ._colf01Double.VisibleIndex = 7       ' "B.PKB"
            'Child
            ._chcolf01Datetime.VisibleIndex = 0         '"tgl.Proses"
            ._chcolk03String.VisibleIndex = 1       ' "Nodoc"
            ._chcolf13String.VisibleIndex = 2       ' "Proses"
            ._chcolf18String.VisibleIndex = 3       ' "Picker"
            ._chcolf20String.VisibleIndex = 4       ' "Ekspedisi"
            ._chcolf21String.VisibleIndex = 5       ' "No.Resi"
            ._chcolf02Double.VisibleIndex = 7      ' "B.Picking"
            ._chcolf01Int.VisibleIndex = 6       ' "Pcs.Picking"
            ._chcolf02Date.VisibleIndex = -1       ' "tgl.SuratJalan"
            ._chcolf03Date.VisibleIndex = -1       ' "tgl.Delivered"

        End With
    End Sub

    Public Sub _ll03LainLain42TrakingPKB()
        With _prop03GridParentChild
            With ._colf01Datetime
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.DateTime
                    .FormatString = "dd/MM/yyyy HH:mm:ss"
                End With
            End With
            With ._chcolf01Datetime
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.DateTime
                    .FormatString = "dd/MM/yyyy HH:mm:ss.fff"
                End With
            End With

            With .GridView1
                .OptionsView.ShowFooter = True
                With .Columns("k02String")
                    .AppearanceHeader.BackColor = Color.DeepPink
                    .AppearanceCell.BackColor = Color.LightPink
                End With

                With .Columns("f11String")
                    .AppearanceHeader.BackColor = Color.Yellow
                    .AppearanceCell.BackColor = Color.LightYellow
                End With

                With .Columns("f02String")
                    .AppearanceHeader.BackColor = Color.Green
                    .AppearanceCell.BackColor = Color.LightGreen
                End With

                With .Columns("f13String")
                    .AppearanceHeader.BackColor = Color.Blue
                    .AppearanceCell.BackColor = Color.LightBlue
                End With
            End With

            With .GridView2
                .OptionsView.ShowFooter = True
                With .Columns("f01Datetime")
                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .SummaryItem.DisplayFormat = "{0:n0} Rows"
                End With

                With .Columns("f13String")
                    .AppearanceHeader.BackColor = Color.Blue
                    .AppearanceCell.BackColor = Color.LightBlue
                End With
            End With

            ._colk00Boolean.OptionsColumn.ReadOnly = False
            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With

            With .GridView2
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With
        End With
    End Sub

    Private Sub _wd240707WidthtrackingPKB()
        With _prop03GridParentChild
            ._colk00Boolean.Width = 81
            ._colk00Int.Width = 81
            ._colk00Boolean01.Width = 81
            ._colk00Int01.Width = 81
            ._colf01Memo.Width = 81
            ._colk01String.Width = 81
            ._colk02String.Width = 120
            ._colk03String.Width = 81
            ._colf01String.Width = 81
            ._colf02String.Width = 182
            ._colf03String.Width = 81
            ._colf04String.Width = 81
            ._colf05String.Width = 87
            ._colf06String.Width = 87
            ._colf07String.Width = 87
            ._colf08String.Width = 87
            ._colf09String.Width = 87
            ._colf10String.Width = 87
            ._colf11String.Width = 89
            ._colf12String.Width = 87
            ._colf13String.Width = 155
            ._colf14String.Width = 87
            ._colf15String.Width = 87
            ._colf16String.Width = 87
            ._colf17String.Width = 87
            ._colf18String.Width = 87
            ._colf19String.Width = 87
            ._colf20String.Width = 87
            ._colf21String.Width = 87
            ._colf22String.Width = 87
            ._colf23String.Width = 87
            ._colf24String.Width = 87
            ._colf25String.Width = 87
            ._colf26String.Width = 87
            ._colf27String.Width = 87
            ._colf28String.Width = 87
            ._colf29String.Width = 87
            ._colf30String.Width = 87
            ._colf31String.Width = 87
            ._colf32String.Width = 87
            ._colf33String.Width = 87
            ._colf34String.Width = 87
            ._colf35String.Width = 87
            ._colf36String.Width = 87
            ._colf37String.Width = 87
            ._colf38String.Width = 87
            ._colf39String.Width = 87
            ._colf40String.Width = 87
            ._colf01TinyInt.Width = 87
            ._colf01SmallInt.Width = 87
            ._colf01Int.Width = 87
            ._colf01Double.Width = 87
            ._colf02Double.Width = 87
            ._colf03Double.Width = 87
            ._colf01Date.Width = 87
            ._colf02Date.Width = 87
            ._colf03Date.Width = 87
            ._chcolk00Boolean.Width = 81
            ._chcolk00Int.Width = 81
            ._chcolk01String.Width = 81
            ._chcolk02String.Width = 81
            ._chcolk03String.Width = 139
            ._chcolf01String.Width = 81
            ._chcolf02String.Width = 81
            ._chcolf03String.Width = 81
            ._chcolf04String.Width = 81
            ._chcolf05String.Width = 87
            ._chcolf06String.Width = 87
            ._chcolf07String.Width = 87
            ._chcolf08String.Width = 87
            ._chcolf09String.Width = 87
            ._chcolf10String.Width = 87
            ._chcolf11String.Width = 87
            ._chcolf12String.Width = 87
            ._chcolf13String.Width = 240
            ._chcolf14String.Width = 87
            ._chcolf15String.Width = 87
            ._chcolf16String.Width = 87
            ._chcolf17String.Width = 87
            ._chcolf18String.Width = 87
            ._chcolf19String.Width = 87
            ._chcolf20String.Width = 112
            ._chcolf21String.Width = 87
            ._chcolf22String.Width = 87
            ._chcolf23String.Width = 87
            ._chcolf24String.Width = 87
            ._chcolf25String.Width = 87
            ._chcolf26String.Width = 87
            ._chcolf27String.Width = 87
            ._chcolf28String.Width = 87
            ._chcolf29String.Width = 87
            ._chcolf30String.Width = 87
            ._chcolf31String.Width = 87
            ._chcolf32String.Width = 87
            ._chcolf33String.Width = 87
            ._chcolf34String.Width = 87
            ._chcolf35String.Width = 87
            ._chcolf36String.Width = 87
            ._chcolf37String.Width = 87
            ._chcolf38String.Width = 87
            ._chcolf39String.Width = 87
            ._chcolf40String.Width = 87
            ._chcolf01TinyInt.Width = 87
            ._chcolf01SmallInt.Width = 87
            ._chcolf01Int.Width = 87
            ._chcolf01Double.Width = 87
            ._chcolf02Double.Width = 87
            ._chcolf03Double.Width = 87
            ._chcolf01Date.Width = 87
            ._chcolf02Date.Width = 87
            ._chcolf03Date.Width = 87
            ._gccolk00Boolean.Width = 81
            ._gccolk00Int.Width = 81
            ._gccolk01String.Width = 81
            ._gccolk02String.Width = 81
            ._gccolk03String.Width = 81
            ._gccolf01String.Width = 81
            ._gccolf02String.Width = 81
            ._gccolf03String.Width = 81
            ._gccolf04String.Width = 81
            ._gccolf05String.Width = 87
            ._gccolf06String.Width = 87
            ._gccolf07String.Width = 87
            ._gccolf08String.Width = 87
            ._gccolf09String.Width = 87
            ._gccolf10String.Width = 87
            ._gccolf11String.Width = 87
            ._gccolf12String.Width = 87
            ._gccolf13String.Width = 87
            ._gccolf14String.Width = 87
            ._gccolf15String.Width = 87
            ._gccolf16String.Width = 87
            ._gccolf17String.Width = 87
            ._gccolf18String.Width = 87
            ._gccolf19String.Width = 87
            ._gccolf20String.Width = 87
            ._gccolf21String.Width = 87
            ._gccolf22String.Width = 87
            ._gccolf23String.Width = 87
            ._gccolf24String.Width = 87
            ._gccolf25String.Width = 87
            ._gccolf26String.Width = 87
            ._gccolf27String.Width = 87
            ._gccolf28String.Width = 87
            ._gccolf29String.Width = 87
            ._gccolf30String.Width = 87
            ._gccolf31String.Width = 87
            ._gccolf32String.Width = 87
            ._gccolf33String.Width = 87
            ._gccolf34String.Width = 87
            ._gccolf35String.Width = 87
            ._gccolf36String.Width = 87
            ._gccolf37String.Width = 87
            ._gccolf38String.Width = 87
            ._gccolf39String.Width = 87
            ._gccolf40String.Width = 87
            ._gccolf01TinyInt.Width = 87
            ._gccolf01SmallInt.Width = 87
            ._gccolf01Int.Width = 87
            ._gccolf01Double.Width = 87
            ._gccolf02Double.Width = 87
            ._gccolf03Double.Width = 87
            ._gccolf01Date.Width = 87
            ._gccolf02Date.Width = 87
            ._gccolf03Date.Width = 87
        End With
    End Sub


#End Region


#Region "***** 50. Tracking PO (ucMD23JP01TRACKINGPO) *****"

    Public Sub _cc01Caption50TrackingPO()
        With _prop03GridParentChild
            'Parent
            ._colf01Date.Caption = "InputDate"
            ._colf21String.Caption = "No.PO"
            ._colk04String.Caption = "Product Code"
            ._colf02Date.Caption = "ETA MD"
            ._colk05String.Caption = "NO. PO"
            ._colf25String.Caption = "NO. PO(to PPIC)"
            ._colf02String.Caption = "Brand"
            ._colf04String.Caption = "Tipe BRJ"
            ._colf06String.Caption = "Warna"
            ._colf08String.Caption = "Kadar"
            ._colf10String.Caption = "Size"
            ._colf12String.Caption = "Collection"
            ._colf19String.Caption = "Customer"
            ._colf15String.Caption = "Tipe Produksi"
            ._colf17String.Caption = "Sub Tipe Produksi"
            ._colf01Int.Caption = "Qty"
            ._colf02Double.Caption = "Est To.Berat"
            'Child
            ._chcolk03String.Caption = "SPK"
            ._chcolf01String.Caption = "Proses"
            ._chcolf01Int.Caption = "Qty"
            ._chcolf01Double.Caption = "Total Berat"
            ._chcolf01Date.Caption = "ETA PPIC"
            ._chcolf02Date.Caption = "Tanggal FG"
            ._chcolf02Int.Caption = "Total Waktu"
        End With
    End Sub

    Public Sub _vs02Visibility50TrackingPO()
        With _prop03GridParentChild
            'Parent
            ._colf01Date.Visible = True   ' "Input Date"
            ._colf21String.Visible = True   ' "No. PO"
            ._colk04String.Visible = True   ' "Product Code"
            ._colf02Date.Visible = True   ' "ETA MD"
            ._colk05String.Visible = True   ' "NO. PO"
            ._colf25String.Visible = True   ' "NO. PO(to PPIC)"
            ._colf02String.Visible = True   ' "Brand"
            ._colf04String.Visible = True   ' "Tipe BRJ"
            ._colf06String.Visible = True   ' "Warna"
            ._colf08String.Visible = True   ' "Kadar"
            ._colf10String.Visible = True   ' "Size"
            ._colf12String.Visible = True   ' "Collection"
            ._colf19String.Visible = True   ' "Customer"
            ._colf15String.Visible = True   ' "Tipe Produksi"
            ._colf17String.Visible = True   ' "Sub Tipe Produksi"
            ._colf01Int.Visible = True   ' "Qty"
            ._colf02Double.Visible = True   ' "Est To.Berat"
            'Child
            ._chcolk03String.Visible = True    ' "SKU"
            ._chcolf01String.Visible = True    ' "Proses"
            ._chcolf01Int.Visible = True    ' "Qty"
            ._chcolf01Double.Visible = True    ' "Total Berat"
            ._chcolf01Date.Visible = True    ' "ETA PPIC"
            ._chcolf02Date.Visible = True    ' "Tanggal FG"
            ._chcolf02Int.Visible = True    ' "Total Waktu"
        End With
    End Sub

    Public Sub _vs02VisibilityIndex50TrackingPO()
        With _prop03GridParentChild
            'Parent
            ._colf01Date.VisibleIndex = 0  '   ' "Input Date"
            ._colf21String.VisibleIndex = 1  '   ' "No. PO"
            ._colk04String.VisibleIndex = 2  '   ' "Product Code"
            ._colf02Date.VisibleIndex = 3  '   ' "ETA MD"
            ._colk05String.VisibleIndex = 4  '   ' "NO. PO"
            ._colf25String.VisibleIndex = 5  '   ' "NO. PO(to PPIC)"
            ._colf02String.VisibleIndex = 6  '   ' "Brand"
            ._colf04String.VisibleIndex = 7  '   ' "Tipe BRJ"
            ._colf06String.VisibleIndex = 8  '   ' "Warna"
            ._colf08String.VisibleIndex = 9  '   ' "Kadar"
            ._colf10String.VisibleIndex = 10 '   ' "Size"
            ._colf12String.VisibleIndex = 11  '   ' "Collection"
            ._colf19String.VisibleIndex = 12  '   ' "Customer"
            ._colf15String.VisibleIndex = 13  '   ' "Tipe Produksi"
            ._colf17String.VisibleIndex = 14  '   ' "Sub Tipe Produksi"
            ._colf01Int.VisibleIndex = 15   ' "Qty"
            ._colf02Double.VisibleIndex = 16  '   ' "Est To.Berat"
            'Child
            ._chcolk03String.VisibleIndex = 0  ' "SKU"
            ._chcolf01String.VisibleIndex = 1   ' "Proses"
            ._chcolf01Int.VisibleIndex = 2   ' "Qty"
            ._chcolf01Double.VisibleIndex = 3   ' "Total Berat"
            ._chcolf01Date.VisibleIndex = 4   ' "ETA PPIC"
            ._chcolf02Date.VisibleIndex = 5   ' "Tanggal FG"
            ._chcolf02Int.VisibleIndex = 6   ' "Total Waktu"

        End With
    End Sub

    Public Sub _ll03LainLain50TrackingPO()
        With _prop03GridParentChild
            ._colk00Boolean.OptionsColumn.ReadOnly = False
            With .GridView1
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With

            With .GridView2
                .OptionsSelection.MultiSelect = True
                .Appearance.FocusedRow.BackColor = Color.FromArgb(162, 210, 255)
                .Appearance.SelectedRow.BackColor = Color.FromArgb(162, 210, 255)
            End With

            With ._chcolf01Date '"ETA"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.DateTime
                    .FormatString = "d"
                End With
                .OptionsColumn.ReadOnly = False
                '.AppearanceHeader.BackColor = Color.FromArgb(216, 226, 220)
                .AppearanceCell.BackColor = Color.FromArgb(216, 226, 220)
            End With

            With ._chcolf02Date '"ETA"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.DateTime
                    .FormatString = "d"
                End With
                .OptionsColumn.ReadOnly = False
                ' .AppearanceHeader.BackColor = Color.FromArgb(216, 226, 220)
                .AppearanceCell.BackColor = Color.FromArgb(216, 226, 220)
            End With

        End With
    End Sub

    Private Sub _wd240707WidthtrackingPO()
        With _prop03GridParentChild
            ._colk00Boolean.Width = 81
            ._colk00Int.Width = 81
            ._colk00Boolean01.Width = 81
            ._colk00Int01.Width = 81
            ._colf01Memo.Width = 81
            ._colk01String.Width = 81
            ._colk02String.Width = 120
            ._colk03String.Width = 81
            ._colf01String.Width = 81
            ._colf02String.Width = 86
            ._colf03String.Width = 81
            ._colf04String.Width = 81
            ._colf05String.Width = 87
            ._colf06String.Width = 87
            ._colf07String.Width = 87
            ._colf08String.Width = 87
            ._colf09String.Width = 87
            ._colf10String.Width = 87
            ._colf11String.Width = 89
            ._colf12String.Width = 160
            ._colf13String.Width = 155
            ._colf14String.Width = 87
            ._colf15String.Width = 104
            ._colf16String.Width = 87
            ._colf17String.Width = 119
            ._colf18String.Width = 87
            ._colf19String.Width = 152
            ._colf20String.Width = 87
            ._colf21String.Width = 87
            ._colf22String.Width = 87
            ._colf23String.Width = 87
            ._colf24String.Width = 104
            ._colf25String.Width = 171
            ._colf26String.Width = 170
            ._colf27String.Width = 87
            ._colf28String.Width = 87
            ._colf29String.Width = 87
            ._colf30String.Width = 87
            ._colf31String.Width = 87
            ._colf32String.Width = 87
            ._colf33String.Width = 87
            ._colf34String.Width = 87
            ._colf35String.Width = 87
            ._colf36String.Width = 87
            ._colf37String.Width = 87
            ._colf38String.Width = 87
            ._colf39String.Width = 87
            ._colf40String.Width = 87
            ._colf01TinyInt.Width = 87
            ._colf01SmallInt.Width = 87
            ._colf01Int.Width = 43
            ._colf01Double.Width = 87
            ._colf02Double.Width = 87
            ._colf03Double.Width = 87
            ._colf01Date.Width = 91
            ._colf02Date.Width = 87
            ._colf03Date.Width = 87
            ._chcolk00Boolean.Width = 81
            ._chcolk00Int.Width = 81
            ._chcolk01String.Width = 81
            ._chcolk02String.Width = 100
            ._chcolk03String.Width = 139
            ._chcolf01String.Width = 194
            ._chcolf02String.Width = 81
            ._chcolf03String.Width = 81
            ._chcolf04String.Width = 81
            ._chcolf05String.Width = 87
            ._chcolf06String.Width = 87
            ._chcolf07String.Width = 87
            ._chcolf08String.Width = 87
            ._chcolf09String.Width = 87
            ._chcolf10String.Width = 87
            ._chcolf11String.Width = 87
            ._chcolf12String.Width = 87
            ._chcolf13String.Width = 240
            ._chcolf14String.Width = 87
            ._chcolf15String.Width = 87
            ._chcolf16String.Width = 87
            ._chcolf17String.Width = 87
            ._chcolf18String.Width = 87
            ._chcolf19String.Width = 87
            ._chcolf20String.Width = 112
            ._chcolf21String.Width = 87
            ._chcolf22String.Width = 87
            ._chcolf23String.Width = 87
            ._chcolf24String.Width = 87
            ._chcolf25String.Width = 87
            ._chcolf26String.Width = 87
            ._chcolf27String.Width = 87
            ._chcolf28String.Width = 87
            ._chcolf29String.Width = 87
            ._chcolf30String.Width = 87
            ._chcolf31String.Width = 87
            ._chcolf32String.Width = 87
            ._chcolf33String.Width = 87
            ._chcolf34String.Width = 87
            ._chcolf35String.Width = 87
            ._chcolf36String.Width = 87
            ._chcolf37String.Width = 87
            ._chcolf38String.Width = 87
            ._chcolf39String.Width = 87
            ._chcolf40String.Width = 87
            ._chcolf01TinyInt.Width = 87
            ._chcolf01SmallInt.Width = 87
            ._chcolf01Int.Width = 85
            ._chcolf01Double.Width = 81
            ._chcolf02Double.Width = 87
            ._chcolf03Double.Width = 87
            ._chcolf01Date.Width = 136
            ._chcolf02Date.Width = 87
            ._chcolf03Date.Width = 87
            ._gccolk00Boolean.Width = 81
            ._gccolk00Int.Width = 81
            ._gccolk01String.Width = 81
            ._gccolk02String.Width = 81
            ._gccolk03String.Width = 81
            ._gccolf01String.Width = 81
            ._gccolf02String.Width = 81
            ._gccolf03String.Width = 81
            ._gccolf04String.Width = 81
            ._gccolf05String.Width = 87
            ._gccolf06String.Width = 87
            ._gccolf07String.Width = 87
            ._gccolf08String.Width = 87
            ._gccolf09String.Width = 87
            ._gccolf10String.Width = 87
            ._gccolf11String.Width = 87
            ._gccolf12String.Width = 87
            ._gccolf13String.Width = 87
            ._gccolf14String.Width = 87
            ._gccolf15String.Width = 87
            ._gccolf16String.Width = 87
            ._gccolf17String.Width = 87
            ._gccolf18String.Width = 87
            ._gccolf19String.Width = 87
            ._gccolf20String.Width = 87
            ._gccolf21String.Width = 87
            ._gccolf22String.Width = 87
            ._gccolf23String.Width = 87
            ._gccolf24String.Width = 87
            ._gccolf25String.Width = 87
            ._gccolf26String.Width = 87
            ._gccolf27String.Width = 87
            ._gccolf28String.Width = 87
            ._gccolf29String.Width = 87
            ._gccolf30String.Width = 87
            ._gccolf31String.Width = 87
            ._gccolf32String.Width = 87
            ._gccolf33String.Width = 87
            ._gccolf34String.Width = 87
            ._gccolf35String.Width = 87
            ._gccolf36String.Width = 87
            ._gccolf37String.Width = 87
            ._gccolf38String.Width = 87
            ._gccolf39String.Width = 87
            ._gccolf40String.Width = 87
            ._gccolf01TinyInt.Width = 87
            ._gccolf01SmallInt.Width = 87
            ._gccolf01Int.Width = 87
            ._gccolf01Double.Width = 87
            ._gccolf02Double.Width = 87
            ._gccolf03Double.Width = 87
            ._gccolf01Date.Width = 87
            ._gccolf02Date.Width = 87
            ._gccolf03Date.Width = 87
        End With
    End Sub



#End Region

End Class
