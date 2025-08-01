Imports DevExpress.Charts.Model
Imports DevExpress.XtraScheduler
Imports SKK02OBJECTS.clsWSNasaSettingGridOutbound

Public Class clsWSNasaSettingGridTransaksiWarehouse
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

    Property _prop01cTargetTransaksiWS As TargetWSTransaksi
    Property _prop02User As clsWSNasaUser
    Property _prop03Grid As New ucWSGrid

    Public Enum TargetWSTransaksi
        _01WSTransaksiMutasiAntarKAE = 0
        _02WSTransaksiApproveMutasiAntarKAE = 1
        _03WSTransaksiReparasiLeburWS = 2
        _04WSTransaksiReparasiCust = 3
        _06WSTransaksiReturSupplier = 4
    End Enum

#Region "form and control - event"
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Me.Dispose()
    End Sub
#End Region

#Region " public - method "

    Public Sub _pbSettingTransaksiWarehouse()
        Select Case _prop01cTargetTransaksiWS
            Case TargetWSTransaksi._01WSTransaksiMutasiAntarKAE
                _pvSetting01WSTransaksiMutasiAntarKAE()

            Case TargetWSTransaksi._02WSTransaksiApproveMutasiAntarKAE
                _pvSetting02WSTransaksiApproveMutasiAntarKAE()

            Case TargetWSTransaksi._03WSTransaksiReparasiLeburWS
                _pvSetting03WSTransaksiReparasiLeburWS()

            Case TargetWSTransaksi._04WSTransaksiReparasiCust
                '***** Under Construction *****

            Case TargetWSTransaksi._06WSTransaksiReturSupplier
                _pvSetting06WSTransaksiReturSupplier()
        End Select
    End Sub

#End Region

#Region " private - method "
    Private Sub _pvSetting01WSTransaksiMutasiAntarKAE()
        _cc01CaptionWSTransaksiMutasiAntarKAE()
        _vs01VisibilityWSTransaksiMutasiAntarKAE()
        _vs02VisibilityIndexWSTransaksiMutasiAntarKAE()
        _wr01WriteWSTransaksiMutasiAntarKAE()
        _ll01LainLainWSTransaksiMutasiAntarKAE()
    End Sub

    Private Sub _pvSetting02WSTransaksiApproveMutasiAntarKAE()
        _cc01CaptionWSTransaksiApproveMutasiAntarKAE()
        _vs01VisibilityWSTransaksiApproveMutasiAntarKAE()
        _vs02VisibilityIndexWSTransaksiApproveMutasiAntarKAE()
        _wr01WriteWSTransaksiApproveMutasiAntarKAE()
        _ll01LainLainWSTransaksiApproveMutasiAntarKAE()
    End Sub

    Private Sub _pvSetting03WSTransaksiReparasiLeburWS()
        _cc01CaptionWSTransaksiReparasiLeburWarehouse()
        _vs01VisibilityWSTransaksiReparasiLeburWarehouse()
        _vs02VisibilityIndexWSTransaksiReparasiLeburWarehouse()
        _wr01WriteWSTransaksiReparasiLeburWarehouse()
        _ll01LainLainWSTransaksiReparasiLeburWarehouse()
        _wd240707WidthTransaksiReparasiLeburWarehouse()
    End Sub

    'private Sub _pvSetting04WSTransaksiReparasiCust()

    'End Sub

    Private Sub _pvSetting06WSTransaksiReturSupplier()
        _cc01CaptionWSTransaksiReturSupplier()
        _vs01VisibilityWSTransaksiReturSupplier()
        _vs02VisibilityIndexWSTransaksiReturSupplier()
        _wr01WriteWSTransaksiReturSupplier()
        _ll01LainLainWSTransaksiReturSupplier()
    End Sub

#End Region

#Region "***** WS.Transaksi - Mutasi Antar KAE *****"
    Private Sub _cc01CaptionWSTransaksiMutasiAntarKAE()
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colk00Int.Caption = "#"
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
        End With
    End Sub

    Private Sub _vs01VisibilityWSTransaksiMutasiAntarKAE()
        With _prop03Grid
            ._colk00Boolean.Visible = True    '"#"
            ._colk00Int.Visible = False       '"#"
            ._colk03String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"ProductCode"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf12String.Visible = True     '"Item"
            ._colf16String.Visible = True     '"Brand"
            ._colf10String.Visible = True     '"Kadar"
            ._colf28String.Visible = True     '"Warna"
            ._colf14String.Visible = True     '"Size"
            ._colf04String.Visible = True     '"Vendor"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexWSTransaksiMutasiAntarKAE()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0     '"#"
            ._colk00Int.VisibleIndex = -1     '"#"
            ._colk03String.VisibleIndex = 1     '"SKU"
            ._colf01String.VisibleIndex = 2     '"ProductCode"
            ._colf10String.VisibleIndex = 3     '"Kadar"
            ._colf16String.VisibleIndex = 4     '"Brand"
            ._colf12String.VisibleIndex = 5     '"Item"
            ._colf28String.VisibleIndex = 6     '"Warna"
            ._colf14String.VisibleIndex = 7     '"Size"
            ._colf04String.VisibleIndex = 8    '"Vendor"
            ._colf01SmallInt.VisibleIndex = 9   '"Pcs"
            ._colf01Double.VisibleIndex = 10    '"Berat"
        End With
    End Sub

    Private Sub _wr01WriteWSTransaksiMutasiAntarKAE()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False
        End With
    End Sub

    Private Sub _ll01LainLainWSTransaksiMutasiAntarKAE()
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

#Region "***** WS.Transaksi - Approve Mutasi Antar KAE *****"
    Private Sub _cc01CaptionWSTransaksiApproveMutasiAntarKAE()

    End Sub

    Private Sub _vs01VisibilityWSTransaksiApproveMutasiAntarKAE()

    End Sub

    Private Sub _vs02VisibilityIndexWSTransaksiApproveMutasiAntarKAE()

    End Sub

    Private Sub _wr01WriteWSTransaksiApproveMutasiAntarKAE()

    End Sub

    Private Sub _ll01LainLainWSTransaksiApproveMutasiAntarKAE()

    End Sub
#End Region

#Region "***** WS.Transaksi - Reparasi & Lebur Warehouse *****"
    Private Sub _cc01CaptionWSTransaksiReparasiLeburWarehouse()
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
            ._colf40String.Caption = "Alasan"
        End With
    End Sub

    Private Sub _vs01VisibilityWSTransaksiReparasiLeburWarehouse()
        With _prop03Grid
            ._colk03String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"ProductCode"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf12String.Visible = True     '"Item"
            ._colf16String.Visible = True     '"Brand"
            ._colf10String.Visible = True     '"Kadar"
            ._colf28String.Visible = True     '"Warna"
            ._colf14String.Visible = True     '"Size"
            ._colf04String.Visible = True     '"Vendor"
            ._colf40String.Visible = True     '"Alasan"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexWSTransaksiReparasiLeburWarehouse()
        With _prop03Grid
            ._colk03String.VisibleIndex = 1     '"SKU"
            ._colf40String.VisibleIndex = 0     '"Alasan"
            ._colf01String.VisibleIndex = 2     '"ProductCode"
            ._colf10String.VisibleIndex = 3     '"Kadar"
            ._colf16String.VisibleIndex = 4     '"Brand"
            ._colf12String.VisibleIndex = 5     '"Item"
            ._colf28String.VisibleIndex = 6     '"Warna"
            ._colf14String.VisibleIndex = 7     '"Size"
            ._colf04String.VisibleIndex = 8    '"Vendor"
            ._colf01SmallInt.VisibleIndex = 9   '"Pcs"
            ._colf01Double.VisibleIndex = 10     '"Berat"
        End With
    End Sub

    Private Sub _wr01WriteWSTransaksiReparasiLeburWarehouse()
        With _prop03Grid
            ._colf40String.OptionsColumn.ReadOnly = False
        End With
    End Sub

    Private Sub _ll01LainLainWSTransaksiReparasiLeburWarehouse()
        With _prop03Grid
            'With ._colf01SmallInt     '
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With

            With ._colf40String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
        End With
    End Sub

    Private Sub _wd240707WidthTransaksiReparasiLeburWarehouse()
        With _prop03Grid
            ._colk00Boolean.Width = 92
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 92
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 92
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 92
            ._colk01String.Width = 92
            ._colk02String.Width = 106
            ._colk03String.Width = 92
            ._colf01String.Width = 102
            ._colf02String.Width = 92
            ._colf03String.Width = 92
            ._colf04String.Width = 125
            ._colf05String.Width = 98
            ._colf06String.Width = 98
            ._colf07String.Width = 98
            ._colf08String.Width = 98
            ._colf09String.Width = 98
            ._colf10String.Width = 59
            ._colf11String.Width = 98
            ._colf12String.Width = 94
            ._colf13String.Width = 98
            ._colf14String.Width = 57
            ._colf15String.Width = 98
            ._colf16String.Width = 72
            ._colf17String.Width = 230
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
            ._colf28String.Width = 117
            ._colf29String.Width = 98
            ._colf30String.Width = 98
            ._colf31String.Width = 98
            ._colf32String.Width = 92
            ._colf33String.Width = 92
            ._colf34String.Width = 92
            ._colf35String.Width = 92
            ._colf36String.Width = 92
            ._colf37String.Width = 92
            ._colf38String.Width = 92
            ._colf39String.Width = 92
            ._colf40String.Width = 92
            ._colf01TinyInt.Width = 98
            ._colf01SmallInt.Width = 43
            ._colf01Int.Width = 98
            ._colf01Double.Width = 55
            ._colf02Double.Width = 98
            ._colf03Double.Width = 98
            ._colf01Date.Width = 98
            ._colf02Date.Width = 98
            ._colf03Date.Width = 92
        End With
    End Sub

#End Region

#Region "***** WS.Transaksi - Retur Supplier *****"
    Private Sub _cc01CaptionWSTransaksiReturSupplier()
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colk00Int.Caption = "#"
            ._colk03String.Caption = "SKU"
            ._colf01String.Caption = "ProductCode"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
            ._colf12String.Caption = "Item"
            ._colf16String.Caption = "Brand"
            ._colf10String.Caption = "Kadar"
            ._colf28String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf17String.Caption = "Alasan"
        End With
    End Sub

    Private Sub _vs01VisibilityWSTransaksiReturSupplier()
        With _prop03Grid
            ._colk00Boolean.Visible = True    '"#"
            ._colk00Int.Visible = False       '"#"
            ._colk03String.Visible = True     '"SKU"
            ._colf01String.Visible = True     '"ProductCode"
            ._colf01SmallInt.Visible = True   '"Pcs"
            ._colf01Double.Visible = True     '"Berat"
            ._colf12String.Visible = True     '"Item"
            ._colf16String.Visible = True     '"Brand"
            ._colf10String.Visible = True     '"Kadar"
            ._colf28String.Visible = True     '"Warna"
            ._colf14String.Visible = True     '"Size"
            ._colf17String.Visible = True     ' "Alasan"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexWSTransaksiReturSupplier()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0     '"#"
            ._colk00Int.VisibleIndex = -1     '"#"
            ._colk03String.VisibleIndex = 2     '"SKU"
            ._colf01String.VisibleIndex = 3     '"ProductCode"
            ._colf10String.VisibleIndex = 4     '"Kadar"
            ._colf16String.VisibleIndex = 5     '"Brand"
            ._colf12String.VisibleIndex = 6     '"Item"
            ._colf28String.VisibleIndex = 7     '"Warna"
            ._colf14String.VisibleIndex = 8     '"Size"
            ._colf01SmallInt.VisibleIndex = 9   '"Pcs"
            ._colf01Double.VisibleIndex = 10     '"Berat"
            ._colf17String.VisibleIndex = 1    ' "Alasan"
        End With
    End Sub

    Private Sub _wr01WriteWSTransaksiReturSupplier()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False
            ._colf17String.OptionsColumn.ReadOnly = False
        End With
    End Sub

    Private Sub _ll01LainLainWSTransaksiReturSupplier()
        With _prop03Grid
            'With ._colf01SmallInt     '
            '    With .DisplayFormat
            '        .FormatType = DevExpress.Utils.FormatType.Numeric
            '        .FormatString = "{0:n0}"
            '    End With
            '    .AppearanceHeader.BackColor = Color.Gold
            '    .AppearanceCell.BackColor = Color.LightYellow
            'End With
            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colf17String
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With
        End With
    End Sub
#End Region

End Class

'Private Sub _cc01Caption
'Private Sub _vs01Visibility
'Private Sub _vs02VisibilityIndex
'Private Sub _wr01Write
'Private Sub _ll01LainLain