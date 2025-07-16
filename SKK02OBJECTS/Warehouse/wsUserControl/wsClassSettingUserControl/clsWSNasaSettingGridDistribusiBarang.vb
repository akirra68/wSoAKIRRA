Imports System.IO
Imports DevExpress.XtraEditors.Repository
Imports SKK02OBJECTS.clsWSNasaSettingGridMutasi

Public Class clsWSNasaSettingGridDistribusiBarang
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

    Property _prop01cTargetDistribusiBarang As TargetDistribusiBarang
    Property _prop02User As clsWSNasaUser
    Property _prop03Grid As New ucWSGrid
    Property _prop04GridParentChild As New ucWSGridParentChild
    Property _prop04DataTableMaster As DataTable

    Public Enum TargetDistribusiBarang
        _TargetWSDistribusiFGPKB = 0
        _TargetWSDistribusiFGApprovePKBSLS = 1
        _TargetWSDistribusiFGApprovePKBFIN = 2
        _TargetWSDistribusiFGOrderViaBulkUploadXLS = 3
        _TargetWSDIstibusiFGOrderManagement = 4
        _TargetWSDIstibusiFGOrderManagementPcode = 41
        _TargetWSDIstibusiFGStockCheck = 5
    End Enum

#Region "form and control - event"
    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
    End Sub
#End Region

#Region " public - method "
    Public Sub __pbSettingGridDistribusiFG()
        Select Case _prop01cTargetDistribusiBarang
            Case TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBFIN,
                 TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBSLS
                _cm01SettingApprovePKB()

            Case TargetDistribusiBarang._TargetWSDistribusiFGPKB
                _cm02SettingDistribusiFGPKB()

            Case TargetDistribusiBarang._TargetWSDistribusiFGOrderViaBulkUploadXLS
                _cm03SettingOrderViaXLS()

            Case TargetDistribusiBarang._TargetWSDIstibusiFGOrderManagement
                _cm04SettingOrderManagement()

            Case TargetDistribusiBarang._TargetWSDIstibusiFGOrderManagementPcode
                _cm041SettingOrderManagementPcode()

            Case TargetDistribusiBarang._TargetWSDIstibusiFGStockCheck
                _cm05SettingStockCheck()
        End Select
    End Sub

    Private Sub _cm01SettingApprovePKB()
        _rsRepoRadioOptionApprovePKB()
        _cc01CaptionApprovePKB()
        _vs01VisibilityApprovePKB()
        _vs02VisibilityIndexApprovePKB()
        _wr01WriteApprovePKB()
        _ll01LainLainApprovePKB()
        _wd240707WidthApprovePKB()
    End Sub

    Private Sub _cm02SettingDistribusiFGPKB()
        _cc01CaptionDistribusiFGPKB()
        _vs01VisibilityDistribusiFGPKB()
        _vs02VisibilityIndexDistribusiFGPKB()
        _tot01TotPcsDanBeratDistribusiFGPKB()
        _ll01LainLainDistribusiFGPKB()
        _wd240707WidthDistribusiFGPKB()
    End Sub

    Private Sub _cm03SettingOrderViaXLS()
        _cc01CaptionOrderViaXLS()
        _vs01VisibilityOrderViaXLS()
        _vs02VisibilityIndexOrderViaXLS()
        _tot01TotPcsDanBeratOrderViaXLS()
        _ll01LainLainOrderViaXLS()
        _wd240707WidthOrderViaXLS()
    End Sub

    Private Sub _cm04SettingOrderManagement()
        _cc01CaptionOrderManagement()
        _vs01VisibilityOrderManagement()
        _vs02VisibilityIndexOrderManagement()
        _wr01WriteOrderManagement()
        _tot01TotRowPcsBeratOrderManagement()
        _ll01LainLainOrderManagement()
        _wd240707WidthOrderManagement()
    End Sub

    Private Sub _cm041SettingOrderManagementPcode()
        _cc01CaptionOrderManagementPcode()
        _vs01VisibilityOrderManagementPcode()
        _vs02VisibilityIndexOrderManagementPcode()
        _wr01WriteOrderManagementPcode()
        _tot01TotRowPcsBeratOrderManagementPcode()
        _ll01LainLainOrderManagementPcode()
        _wd240707WidthOrderManagementPcode()
    End Sub

    Private Sub _cm05SettingStockCheck()
        _cc01CaptionStockCheck()
        _vs01VisibilityStockCheck()
        _vs02VisibilityIndexStockCheck()
        _tot01TotRowPcsBeratStockCheck()
        _ll01LainLainStockCheck()
        _wd240707WidthStockCheck()
    End Sub

#End Region

#Region "***** APPROVE PKB-Perintah Kirim Barang *****"
    'Private _rscolf01Memo As repoWS03Picture
    'Private _rscolk00Int As repoWS06RadioGroup
    'Private _rscolk00Int01 As repoWS06RadioGroup

    Private _rscolk00Int As repoWS07LookUpEditAKIRRA
    Private _rscolk00Int01 As repoWS07LookUpEditAKIRRA

    Private Sub _rsRepoRadioOptionApprovePKB()
        '_rscolf01Memo = New repoWS03Picture()
        '_rscolk00Int = New repoWS06RadioGroup()
        '_rscolk00Int01 = New repoWS06RadioGroup("YES")

        _rscolk00Int = New repoWS07LookUpEditAKIRRA()
        _rscolk00Int01 = New repoWS07LookUpEditAKIRRA("YES")

        With _prop03Grid
            .GridView1.OptionsView.ColumnAutoWidth = False
            .GridView1.OptionsView.RowAutoHeight = True
            .GridView1.BestFitColumns()

            '._colf01Memo.ColumnEdit = _rscolf01Memo
            '._colf01Memo.Width = 85


            ._colk00Int.ColumnEdit = _rscolk00Int
            ._colk00Int01.ColumnEdit = _rscolk00Int01

            '._colk00Int.ColumnEdit = _rscolk00Int
            '._colk00Int01.ColumnEdit = _rscolk00Int01

        End With
    End Sub

    Private Sub _cc01CaptionApprovePKB()
        With _prop03Grid
            ._colk00Boolean.Caption = "#"
            ._colk00Int.Caption = "Approval"      '"Approve - SALES"
            ._colk00Int01.Caption = "Approval"  '"Approve - FIN"
            ._colf01Date.Caption = "Tgl.Order"
            ._colk03String.Caption = "No.Order"
            ._colf15String.Caption = "Customer"
            ._colf02String.Caption = "Brand"
            ._colf04String.Caption = "Kadar"
            ._colf17String.Caption = "KAE"
            ._colf01SmallInt.Caption = "T.Qty"
            ._colf01Double.Caption = "T.Gr"
            ._colf23String.Caption = "Approval Status"
            ._colf26String.Caption = "No.PO CMK"
            ._colf29String.Caption = "Alasan Reject / Pending"
        End With

        'With _prop03Grid
        '    ._colf01Memo.Caption = "Picture"
        '    ._colk00Int.Caption = "Sales"      '"Approve - SALES"
        '    ._colk00Int01.Caption = "Finance"  '"Approve - FIN"
        '    ._colf03Date.Caption = "Tgl.Order"
        '    ._colk03String.Caption = "No.Order"
        '    ._colf02String.Caption = "ProductCode"
        '    ._colf10String.Caption = "NamaCustomer"
        '    ._colf12String.Caption = "NamaKAE"
        '    ._colf14String.Caption = "NamaTOP"
        '    ._colf16String.Caption = "NamaBrand"
        '    ._colf18String.Caption = "NamaKadar"
        '    ._colf20String.Caption = "NamaTipeBRJ"
        '    ._colf22String.Caption = "NamaNORO"
        '    ._colf24String.Caption = "NamaSize"
        '    ._colf26String.Caption = "NamaWarna"
        '    ._colf34String.Caption = "NamaApprovedSALES"
        '    ._colf36String.Caption = "NamaApprovedFA"
        '    ._colf40String.Caption = "Note"
        '    ._colf01Date.Caption = "TglApprove.FA"
        '    ._colf02Date.Caption = "TglApprove.SALES"
        '    ._colf01SmallInt.Caption = "Pcs"
        '    ._colf01Double.Caption = "Berat"
        'End With

    End Sub

    Private Sub _vs01VisibilityApprovePKB()
        With _prop03Grid
            If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBSLS Then
                ._colk00Int.Visible = True          '"Approve - SALES"
                ._colk00Int01.Visible = False        '"Approve - FIN"
                ._colf29String.Visible = False   '"Alasan Reject"
            Else
                If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBFIN Then
                    ._colk00Int.Visible = False        '"Approve - SALES"
                    ._colk00Int01.Visible = True      '"Approve - FIN"
                    ._colf29String.Visible = True   '"Alasan Reject"
                End If
            End If
            ._colk00Boolean.Visible = True
            ._colf01Date.Visible = True       '"Tgl.PKB"
            ._colk03String.Visible = True       '"No.PKB" 
            ._colf15String.Visible = True       '"Customer" 
            ._colf02String.Visible = True       '"Brand" 
            ._colf04String.Visible = True       '"Kadar" 
            ._colf17String.Visible = True       '"KAE"
            ._colf01SmallInt.Visible = True       '"T.Qty" 
            ._colf01Double.Visible = True       '"T.Berat"
            ._colf23String.Visible = True   '"Status"
            ._colf26String.Visible = True   '"No.Order CMK"
        End With

        'With _prop03Grid
        '    ._colf01Memo.Visible = True       '"Picture"
        '    If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSApprovePKBbySLS Then
        '        ._colk00Int.Visible = True          '"Approve - SALES"
        '        ._colk00Int01.Visible = False        '"Approve - FIN"
        '    Else
        '        If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSApprovePKBbyFIN Then
        '            ._colk00Int.Visible = False        '"Approve - SALES"
        '            ._colk00Int01.Visible = True      '"Approve - FIN"
        '        End If
        '    End If
        '    ._colf03Date.Visible = True       '"Tgl.Order"
        '    ._colk03String.Visible = True     '"No.Order"
        '    ._colf02String.Visible = True     '"ProductCode"
        '    ._colf10String.Visible = True     '"NamaCustomer"
        '    ._colf12String.Visible = True     '"NamaKAE"
        '    ._colf14String.Visible = True     '"NamaTOP"
        '    ._colf16String.Visible = True     '"NamaBrand"
        '    ._colf18String.Visible = True     '"NamaKadar"
        '    ._colf20String.Visible = True     '"NamaTipeBRJ"
        '    ._colf22String.Visible = True     '"NamaNORO"
        '    ._colf24String.Visible = True     '"NamaSize"
        '    ._colf26String.Visible = True     '"NamaWarna"
        '    ._colf34String.Visible = True     '"NamaApprovedSALES"
        '    ._colf36String.Visible = True     '"NamaApprovedFA"
        '    ._colf40String.Visible = True     '"Note"
        '    ._colf01Date.Visible = True       '"TglApprove.FA"
        '    ._colf02Date.Visible = True       '"TglApprove.SALES"
        '    ._colf01SmallInt.Visible = True   '"Pcs"
        '    ._colf01Double.Visible = True     '"Berat"
        'End With
    End Sub

    Private Sub _vs02VisibilityIndexApprovePKB()
        With _prop03Grid
            ._colk00Boolean.VisibleIndex = 0
            If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBSLS Then
                ._colk00Int.VisibleIndex = 1          '"Approve - SALES"
                ._colk00Int01.VisibleIndex = -1        '"Approve - FIN"
                ._colf01Date.VisibleIndex = 2       '"Tgl.Order"
                ._colk03String.VisibleIndex = 3       '"No.Order" 
                ._colf15String.VisibleIndex = 4       '"Customer" 
                ._colf17String.VisibleIndex = 5       '"KAE"
                ._colf04String.VisibleIndex = 6       '"Kadar" 
                ._colf02String.VisibleIndex = 7       '"Brand" 
                ._colf01SmallInt.VisibleIndex = 8     '"T.Qty" 
                ._colf01Double.VisibleIndex = 9       '"T.Berat"
                ._colf26String.VisibleIndex = 10   '"No.Order CMK"
                ._colf23String.VisibleIndex = 11   '"Status"
                ._colf29String.VisibleIndex = -1   '"Alasan Reject"
            Else
                If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBFIN Then
                    ._colk00Int.VisibleIndex = -1        '"Approve - SALES"
                    ._colk00Int01.VisibleIndex = 1       '"Approve - FIN"
                    ._colf29String.VisibleIndex = 2   '"Alasan Reject"
                    ._colf01Date.VisibleIndex = 3       '"Tgl.Order"
                    ._colk03String.VisibleIndex = 4       '"No.Order" 
                    ._colf15String.VisibleIndex = 5       '"Customer" 
                    ._colf17String.VisibleIndex = 6       '"KAE"
                    ._colf04String.VisibleIndex = 7       '"Kadar" 
                    ._colf02String.VisibleIndex = 8       '"Brand" 
                    ._colf01SmallInt.VisibleIndex = 9     '"T.Qty" 
                    ._colf01Double.VisibleIndex = 10       '"T.Berat"
                    ._colf26String.VisibleIndex = 11   '"No.Order CMK"
                    ._colf23String.VisibleIndex = 12   '"Status"
                End If
            End If

        End With

        'With _prop03Grid
        '    ._colf01Memo.VisibleIndex = 0       '"Picture"
        '    If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSApprovePKBbySLS Then
        '        ._colk00Int.VisibleIndex = 1           '"Approve - SALES"
        '        ._colk00Int01.VisibleIndex = -1        '"Approve - FIN"
        '    Else
        '        If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSApprovePKBbyFIN Then
        '            ._colk00Int.VisibleIndex = -1        '"Approve - SALES"
        '            ._colk00Int01.VisibleIndex = 1       '"Approve - FIN"
        '        End If
        '    End If
        '    ._colf03Date.VisibleIndex = 3       '"Tgl.Order"
        '    ._colk03String.VisibleIndex = 4     '"No.Order"
        '    ._colf02String.VisibleIndex = 5     '"ProductCode"
        '    ._colf10String.VisibleIndex = 6     '"NamaCustomer"
        '    ._colf12String.VisibleIndex = 7     '"NamaKAE"
        '    ._colf01SmallInt.VisibleIndex = 8     '"Pcs"
        '    ._colf01Double.VisibleIndex = 9     '"Berat"
        '    ._colf16String.VisibleIndex = 10     '"NamaBrand"
        '    ._colf18String.VisibleIndex = 11     '"NamaKadar"
        '    ._colf20String.VisibleIndex = 12     '"NamaTipeBRJ"
        '    ._colf14String.VisibleIndex = 13     '"NamaTOP"
        '    ._colf22String.VisibleIndex = 14     '"NamaNORO"
        '    ._colf24String.VisibleIndex = 15    '"NamaSize"
        '    ._colf26String.VisibleIndex = 16     '"NamaWarna"
        '    ._colf34String.VisibleIndex = 17     '"NamaApprovedSALES"
        '    ._colf36String.VisibleIndex = 18     '"NamaApprovedFA"
        '    ._colf40String.VisibleIndex = 19     '"Note"
        '    ._colf01Date.VisibleIndex = 20     '"TglApprove.FA"
        '    ._colf02Date.VisibleIndex = 21     '"TglApprove.SALES"

        'End With

    End Sub

    Private Sub _wr01WriteApprovePKB()
        With _prop03Grid
            ._colk00Boolean.OptionsColumn.ReadOnly = False
            If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBSLS Then
                ._colk00Int.OptionsColumn.ReadOnly = False          '"Approve - SALES"
                ._colk00Int01.OptionsColumn.ReadOnly = True        '"Approve - FIN"
            Else
                If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBFIN Then
                    ._colk00Int.OptionsColumn.ReadOnly = True        '"Approve - SALES"
                    ._colk00Int01.OptionsColumn.ReadOnly = False       '"Approve - FIN"

                    With ._colf29String
                        Dim _rpEdit As New RepositoryItemRichTextEdit
                        .OptionsColumn.ReadOnly = False
                        .OptionsColumn.AllowEdit = True
                        .ColumnEdit = _rpEdit
                    End With

                End If
            End If
        End With
    End Sub

    Private Sub _ll01LainLainApprovePKB()
        With _prop03Grid
            With ._colk00Boolean
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colk00Int
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            With ._colk00Int01
                .AppearanceHeader.BackColor = Color.Gold
                .AppearanceCell.BackColor = Color.PaleGoldenrod
            End With

            If _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBFIN Then
                With ._colf29String
                    .AppearanceHeader.BackColor = Color.Gold
                    .AppearanceCell.BackColor = Color.PaleGoldenrod
                End With
            ElseIf _prop01cTargetDistribusiBarang = TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBSLS Then
                With ._colf29String
                    .AppearanceHeader.BackColor = Color.Empty
                    .AppearanceCell.BackColor = Color.Empty
                End With
            End If

            With ._colf01SmallInt     '"Pcs"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01Double     '"Berat"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With

            With ._colf01Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With

            With .GridView1
                .OptionsView.ShowFooter = True

                With .Columns("k00Int")
                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .SummaryItem.DisplayFormat = "{0:n0} Rows"
                End With

                With .Columns("k00Int01")
                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .SummaryItem.DisplayFormat = "{0:n0} Rows"
                End With

                With .Columns("k03String")
                    .AppearanceHeader.BackColor = Color.DeepPink
                    .AppearanceCell.BackColor = Color.LightPink
                End With

                With .Columns("f15String")
                    .AppearanceHeader.BackColor = Color.Yellow
                    .AppearanceCell.BackColor = Color.LightYellow
                End With

                With .Columns("f17String")
                    .AppearanceHeader.BackColor = Color.Green
                    .AppearanceCell.BackColor = Color.LightGreen
                End With
            End With
        End With
    End Sub

    Private Sub _wd240707WidthApprovePKB()
        With _prop03Grid
            ._colk00Int.MaxWidth = 90
            ._colk00Int01.MaxWidth = 90
            ._colf15String.MaxWidth = 175
            ._colf17String.MaxWidth = 175
            ._colf02String.MaxWidth = 71
            ._colf23String.MaxWidth = 204
            ._colf29String.MaxWidth = 180

            ._colk00Int.Width = 90
            ._colk00Int01.Width = 90
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 79
            ._colk03String.Width = 130
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
            ._colf15String.Width = 241
            ._colf16String.Width = 85
            ._colf17String.Width = 223
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
            ._colf01SmallInt.Width = 50
            ._colf01Int.Width = 85
            ._colf01Double.Width = 85
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 99
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub

#End Region

#Region "***** Distribusi FG - Perintah Kirim Barang *****"
    Private Sub _cc01CaptionDistribusiFGPKB()
        With _prop03Grid
            ._colk02String.Caption = "ProductCode"
            ._colk03String.Caption = "No.Order"
            ._colf02String.Caption = "Brand"
            ._colf04String.Caption = "Kadar"
            ._colf06String.Caption = "Item"
            ._colf15String.Caption = "Customer"
            ._colf17String.Caption = "Sales"
            ._colf01SmallInt.Caption = "Qty"
            ._colf01Double.Caption = "Gram"
        End With
    End Sub

    Private Sub _vs01VisibilityDistribusiFGPKB()
        With _prop03Grid
            ._colk02String.Visible = True       '"ProductCode" 
            ._colk03String.Visible = True       '"No.PKB"
            ._colf02String.Visible = True       '"Brand"
            ._colf04String.Visible = True       '"Kadar"
            ._colf06String.Visible = True       '"Item" 
            ._colf15String.Visible = True       '"Customer"
            ._colf17String.Visible = True       '"Sales"
            ._colf01SmallInt.Visible = True       '"Qty"
            ._colf01Double.Visible = True       '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexDistribusiFGPKB()
        With _prop03Grid
            ._colk02String.VisibleIndex = 1       '"ProductCode" 
            ._colk03String.VisibleIndex = 0       '"No.PKB"
            ._colf15String.VisibleIndex = 2       '"Customer"
            ._colf17String.VisibleIndex = 3       '"Sales"
            ._colf02String.VisibleIndex = 5       '"Brand"
            ._colf04String.VisibleIndex = 4       '"Kadar"
            ._colf06String.VisibleIndex = 6       '"Item" 
            ._colf01SmallInt.VisibleIndex = 7     '"Qty"
            ._colf01Double.VisibleIndex = 8       '"Berat"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratDistribusiFGPKB()
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

    Private Sub _ll01LainLainDistribusiFGPKB()
        With _prop03Grid
            With .GridView1
                With .Columns("k03String")
                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .SummaryItem.DisplayFormat = "{0:n0} Rows"
                    .AppearanceHeader.BackColor = Color.DeepPink
                    .AppearanceCell.BackColor = Color.LightPink
                End With

                With .Columns("k02String")
                    .AppearanceHeader.BackColor = Color.Yellow
                    .AppearanceCell.BackColor = Color.LightYellow
                End With
            End With

            With ._colf01SmallInt     '"Pcs"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01Double     '"Berat"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With
        End With
    End Sub

    Private Sub _wd240707WidthDistribusiFGPKB()
        With _prop03Grid
            ._colk00Boolean.Width = 79
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 112
            ._colk03String.Width = 130
            ._colf01String.Width = 79
            ._colf02String.Width = 97
            ._colf03String.Width = 79
            ._colf04String.Width = 67
            ._colf05String.Width = 85
            ._colf06String.Width = 132
            ._colf07String.Width = 85
            ._colf08String.Width = 85
            ._colf09String.Width = 85
            ._colf10String.Width = 85
            ._colf11String.Width = 85
            ._colf12String.Width = 85
            ._colf13String.Width = 85
            ._colf14String.Width = 85
            ._colf15String.Width = 253
            ._colf16String.Width = 85
            ._colf17String.Width = 217
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
            ._colf01SmallInt.Width = 54
            ._colf01Int.Width = 85
            ._colf01Double.Width = 62
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub

#End Region

#Region "***** PKB - ORDER via BULK UPLOAD XLS *****"
    Private Sub _cc01CaptionOrderViaXLS()
        With _prop03Grid
            ._colk02String.Caption = "ProductCode"
            ._colf02String.Caption = "Brand"
            ._colf04String.Caption = "Kadar"
            ._colf06String.Caption = "Item"
            ._colf15String.Caption = "Customer"
            ._colf17String.Caption = "Sales"
            ._colf01Int.Caption = "OrderQty"
            ._colf01SmallInt.Caption = "StockQty"
            ._colf01Double.Caption = "StockGram"
        End With
    End Sub

    Private Sub _vs01VisibilityOrderViaXLS()
        With _prop03Grid
            ._colk02String.Visible = True       '"ProductCode" 
            ._colf02String.Visible = True       '"Brand"
            ._colf04String.Visible = True       '"Kadar"
            ._colf06String.Visible = True       '"Item" 
            ._colf15String.Visible = True       '"Customer"
            ._colf17String.Visible = True       '"Sales"
            ._colf01Int.Visible = True          '"QtyOrder"
            ._colf01SmallInt.Visible = True     '"Qty"
            ._colf01Double.Visible = True       '"Berat"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexOrderViaXLS()
        With _prop03Grid
            ._colk02String.VisibleIndex = 0       '"ProductCode" 
            ._colf15String.VisibleIndex = 1       '"Customer"
            ._colf17String.VisibleIndex = 2       '"Sales"
            ._colf04String.VisibleIndex = 3       '"Kadar"
            ._colf02String.VisibleIndex = 4       '"Brand"
            ._colf06String.VisibleIndex = 5       '"Item" 
            ._colf01Int.VisibleIndex = 6          '"QtyOrder"
            ._colf01SmallInt.VisibleIndex = 7     '"Qty"
            ._colf01Double.VisibleIndex = 8       '"Berat"
        End With
    End Sub

    Private Sub _tot01TotPcsDanBeratOrderViaXLS()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Int").SummaryItem.FieldName = "f01Int"
            .Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainOrderViaXLS()
        With _prop03Grid
            With .GridView1
                With .Columns("k02String")
                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .SummaryItem.DisplayFormat = "{0:n0} Rows"
                    .AppearanceHeader.BackColor = Color.DeepPink
                    .AppearanceCell.BackColor = Color.LightPink
                End With
            End With

            With ._colf01Int     '"Pcs"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01SmallInt     '"Pcs"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n0}"
                End With
            End With

            With ._colf01Double     '"Berat"
                With .DisplayFormat
                    .FormatType = DevExpress.Utils.FormatType.Numeric
                    .FormatString = "{0:n2}"
                End With
            End With
        End With
    End Sub

    Private Sub _wd240707WidthOrderViaXLS()
        With _prop03Grid
            ._colk00Boolean.Width = 79
            ._colk00Int.Width = 75
            ._colk00Boolean01.Width = 79
            ._colk00Int01.Width = 75
            ._colk00Boolean02.Width = 79
            ._colk00Int02.Width = 75
            ._colf01Memo.Width = 79
            ._colk01String.Width = 79
            ._colk02String.Width = 112
            ._colk03String.Width = 130
            ._colf01String.Width = 79
            ._colf02String.Width = 97
            ._colf03String.Width = 79
            ._colf04String.Width = 52
            ._colf05String.Width = 85
            ._colf06String.Width = 132
            ._colf07String.Width = 85
            ._colf08String.Width = 85
            ._colf09String.Width = 85
            ._colf10String.Width = 85
            ._colf11String.Width = 85
            ._colf12String.Width = 85
            ._colf13String.Width = 85
            ._colf14String.Width = 85
            ._colf15String.Width = 253
            ._colf16String.Width = 85
            ._colf17String.Width = 217
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
            ._colf01SmallInt.Width = 62
            ._colf01Int.Width = 66
            ._colf01Double.Width = 70
            ._colf02Double.Width = 85
            ._colf03Double.Width = 85
            ._colf01Date.Width = 85
            ._colf02Date.Width = 85
            ._colf03Date.Width = 79
        End With
    End Sub

#End Region

#Region " *** ORDER MANAGEMENT *** "
    ' BY NO. ORDER
    Private Sub _cc01CaptionOrderManagement()
        With _prop04GridParentChild
            'Parent
            ._colk00Boolean.Caption = "#"
            ._colk00Int.Caption = "#"
            ._colf01Date.Caption = "Tgl.Order"
            ._colk03String.Caption = "No.Order"
            ._colf03String.Caption = "Customer"
            ._colf05String.Caption = "KAE"
            ._colf07String.Caption = "Brand"
            ._colf09String.Caption = "Kadar"
            ._colf01SmallInt.Caption = "T.Qty"
            ._colf01Double.Caption = "T.Gr"
            ._colf12String.Caption = "Order Status"
            ._colf01Datetime.Caption = "LastUpdated"
            ._colk00Boolean01.Caption = "HasOST"

            'Child
            ._chcolf01String.Caption = "ProductCode"
            ._chcolf01SmallInt.Caption = "OrderQty"
            ._chcolf01TinyInt.Caption = "StockQty"
            ._chcolf01Int.Caption = "OutstandingQty"
            ._chcolf02Int.Caption = "CheckoutQty"
            ._chcolf01Double.Caption = "OrderGr"
            ._chcolf02Double.Caption = "CheckoutGr"
        End With
    End Sub

    Private Sub _vs01VisibilityOrderManagement()
        With _prop04GridParentChild
            'Parent
            ._colk00Boolean.Visible = True   '"#"
            ._colk00Int.Visible = True   '"#"
            ._colf01Date.Visible = True   '"Tgl.Order"
            ._colk03String.Visible = True   '"No.Order"
            ._colf03String.Visible = True   '"Customer"
            ._colf05String.Visible = True   '"KAE"
            ._colf07String.Visible = True   '"Brand"
            ._colf09String.Visible = True   '"Kadar"
            ._colf01SmallInt.Visible = True   '"Tot.QTY"
            ._colf01Double.Visible = True   '"Tot.Berat"
            ._colf12String.Visible = True   '"Status"
            ._colf01Datetime.Visible = True   '"LastUpdate"
            ._colk00Boolean01.Visible = True   '"HASOST"

            'Child
            ._chcolf01String.Visible = True   '"ProductCode"
            ._chcolf01Double.Visible = True   '"Berat"
            ._chcolf01SmallInt.Visible = True   '"OrderQTY"
            ._chcolf01TinyInt.Visible = True   '"StockQTY"
            ._chcolf01Int.Visible = True   '"OutstandingQTY"
            ._chcolf02Int.Visible = True   '"CheckoutQTY"
            ._chcolf02Double.Visible = True   '"CheckoutGr"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexOrderManagement()
        With _prop04GridParentChild
            'Parent
            ._colk00Int.VisibleIndex = -1  '"#"
            ._colk00Boolean.VisibleIndex = 0  '"#"
            ._colf01Datetime.VisibleIndex = 1   '"LastUpdate"
            ._colk03String.VisibleIndex = 2   '"No.Order"
            ._colf03String.VisibleIndex = 3   '"Customer"
            ._colf05String.VisibleIndex = 4   '"KAE"
            ._colf09String.VisibleIndex = 5   '"Kadar"
            ._colf07String.VisibleIndex = 6   '"Brand"
            ._colf01SmallInt.VisibleIndex = 7   '"Tot.QTY"
            ._colf01Double.VisibleIndex = 8   '"Tot.Berat"
            ._colf01Date.VisibleIndex = 9  '"Tgl.Order"
            ._colf12String.VisibleIndex = 10   '"Status"
            ._colk00Boolean01.VisibleIndex = 11   '"HASOST"

            'Child
            ._chcolf01String.VisibleIndex = 0   '"ProductCode"
            ._chcolf01SmallInt.VisibleIndex = 1   '"OrderQTY"
            ._chcolf01TinyInt.VisibleIndex = 2   '"StockQTY"
            ._chcolf01Int.VisibleIndex = 4   '"OutstandingQTY"
            ._chcolf02Int.VisibleIndex = 5   '"CheckoutQTY"
            ._chcolf01Double.VisibleIndex = 6   '"Berat"
            ._chcolf02Double.VisibleIndex = 7   '"CheckoutGr"
        End With
    End Sub

    Private Sub _wr01WriteOrderManagement()
        With _prop04GridParentChild
            ._colk00Boolean.OptionsColumn.ReadOnly = False
            '._colk00Boolean01.OptionsColumn.ReadOnly = False
        End With
    End Sub

    Private Sub _tot01TotRowPcsBeratOrderManagement()
        With _prop04GridParentChild.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01Datetime").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("f01Datetime").SummaryItem.DisplayFormat = "{0:n0} Rows"

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With

        With _prop04GridParentChild.GridView2
            .OptionsView.ShowFooter = True
            .Columns("f01String").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("f01String").SummaryItem.DisplayFormat = "{0:n0} Rows"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

            .Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f02Double").SummaryItem.FieldName = "f02Double"
            .Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"

            .Columns("f02Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f02Int").SummaryItem.FieldName = "f02Int"
            .Columns("f02Int").SummaryItem.DisplayFormat = "{0:n0}"
        End With
    End Sub

    Private Sub _ll01LainLainOrderManagement()
        With _prop04GridParentChild
            With ._colf01Datetime
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss.fff"
            End With

            With ._colf01Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With

            'With ._colk00Boolean01
            '    .ColumnEdit = Nothing ' pastikan tidak pakai RepositoryItemCheckEdit
            '    .UnboundType = DevExpress.Data.UnboundColumnType.String
            '    .UnboundExpression = "Iif([k00Boolean01] = True, 'Yes', 'No')"
            'End With

            With .GridView1
                With .Columns("k00Boolean")
                    .AppearanceHeader.BackColor = Color.Gold
                    .AppearanceCell.BackColor = Color.PaleGoldenrod
                End With

                With .Columns("k03String")
                    .AppearanceHeader.BackColor = Color.DeepPink
                    .AppearanceCell.BackColor = Color.LightPink
                End With

                With .Columns("f03String")
                    .AppearanceHeader.BackColor = Color.Yellow
                    .AppearanceCell.BackColor = Color.LightYellow
                End With
            End With

            With .GridView2
                With .Columns("f01String")
                    .AppearanceHeader.BackColor = Color.Salmon
                    .AppearanceCell.BackColor = Color.LightSalmon
                End With

                With .Columns("f01SmallInt")
                    .AppearanceHeader.BackColor = Color.Gray
                    .AppearanceCell.BackColor = Color.LightGray
                End With

                With .Columns("f01TinyInt")
                    .AppearanceHeader.BackColor = Color.Cyan
                    .AppearanceCell.BackColor = Color.LightCyan
                End With

                With .Columns("f01Int")
                    .AppearanceHeader.BackColor = Color.Coral
                    .AppearanceCell.BackColor = Color.LightCoral
                End With
            End With
        End With

    End Sub

    Private Sub _wd240707WidthOrderManagement()
        ' lanjut nanti - 25/04/24 - AKIRRA

        With _prop04GridParentChild
            ._colf01Datetime.MaxWidth = 169
            ._colf05String.MaxWidth = 195
            ._colf03String.MaxWidth = 195
            ._colf07String.MaxWidth = 71
            ._colf12String.MaxWidth = 184

            ._chcolf01String.MinWidth = 150
        End With

    End Sub

    ' BY PRODUCT CODE
    Private Sub _cc01CaptionOrderManagementPcode()
        With _prop04GridParentChild
            'Parent
            ._colf01Datetime.Caption = "LastUpdated"
            ._colf01String.Caption = "Product Code"
            ._colf09String.Caption = "Kadar"
            ._colf07String.Caption = "Brand"
            ._colf11String.Caption = "Item"
            ._colf01Int.Caption = "StockQty"
            ._colf01SmallInt.Caption = "Tot.OrderQty"
            ._colf01Double.Caption = "Tot.OrderGram"

            'Child
            ._chcolf01Date.Caption = "Tgl.Order"
            ._chcolk03String.Caption = "No.Order"
            ._chcolf22String.Caption = "JenisOrder"
            ._chcolf03String.Caption = "Customer"
            ._chcolf05String.Caption = "KAE"
            ._chcolf01SmallInt.Caption = "OrderQty"
            ._chcolf01Double.Caption = "OrderGram"
            ._chcolf12String.Caption = "Status"
            ._chcolf17String.Caption = "Notes"
            ._chcolf01Datetime.Caption = "LastUpdated"

        End With
    End Sub

    Private Sub _vs01VisibilityOrderManagementPcode()
        With _prop04GridParentChild
            'Parent
            ._colf01Datetime.Visible = True   '"LastUpdate"
            ._colf01String.Visible = True   '"Product Code"
            ._colf09String.Visible = True   '"Kadar"
            ._colf07String.Visible = True   '"Brand"
            ._colf11String.Visible = True   '"Item"
            ._colf01Int.Visible = True   '"StockQty"
            ._colf01SmallInt.Visible = True   '"Tot.OrderQty"
            ._colf01Double.Visible = True   '"Tot.OrderGram"

            'Child
            ._chcolf01Date.Visible = True   '"Tgl.Order"
            ._chcolk03String.Visible = True   '"No.Order"
            ._chcolf22String.Visible = True    '"JenisOrder"
            ._chcolf03String.Visible = True   '"Customer"
            ._chcolf05String.Visible = True   '"KAE"
            ._chcolf01SmallInt.Visible = True   '"OrderQty"
            ._chcolf01Double.Visible = True   '"OrderGram"
            ._chcolf12String.Visible = True   '"Status"
            ._chcolf17String.Visible = True   '"Notes"
            ._chcolf01Datetime.Visible = True   '"LastUpdate"

        End With
    End Sub

    Private Sub _vs02VisibilityIndexOrderManagementPcode()
        With _prop04GridParentChild
            ._colf01Datetime.VisibleIndex = 0   '"LastUpdate"
            ._colf01String.VisibleIndex = 1   '"Product Code"
            ._colf09String.VisibleIndex = 2   '"Kadar"
            ._colf07String.VisibleIndex = 3   '"Brand"
            ._colf11String.VisibleIndex = 4   '"Item"
            ._colf01Int.VisibleIndex = 5   '"StockQty"
            ._colf01SmallInt.VisibleIndex = 6   '"Tot.OrderQty"
            ._colf01Double.VisibleIndex = 7   '"Tot.OrderGram"

            'Child
            ._chcolf01Date.VisibleIndex = 0   '"Tgl.Order"
            ._chcolk03String.VisibleIndex = 1   '"No.Order"
            ._chcolf22String.VisibleIndex = 2    '"JenisOrder"
            ._chcolf03String.VisibleIndex = 3   '"Customer"
            ._chcolf05String.VisibleIndex = 4   '"KAE"
            ._chcolf01SmallInt.VisibleIndex = 5   '"OrderQty"
            ._chcolf01Double.VisibleIndex = 6   '"OrderGram"
            ._chcolf12String.VisibleIndex = 7   '"Status"
            ._chcolf17String.VisibleIndex = 8   '"Notes"
            ._chcolf01Datetime.VisibleIndex = 9   '"LastUpdate"
        End With
    End Sub

    Private Sub _wr01WriteOrderManagementPcode()

    End Sub

    Private Sub _tot01TotRowPcsBeratOrderManagementPcode()
        With _prop04GridParentChild.GridView1
            .OptionsView.ShowFooter = True

            .Columns("f01Datetime").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("f01Datetime").SummaryItem.DisplayFormat = "{0:n0} Rows"
        End With

        With _prop04GridParentChild.GridView2
            .OptionsView.ShowFooter = True
            .Columns("f01Date").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("f01Date").SummaryItem.DisplayFormat = "{0:n0} Rows"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

            .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
            .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"
        End With
    End Sub

    Private Sub _ll01LainLainOrderManagementPcode()
        With _prop04GridParentChild
            With ._colf01Datetime
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss.fff"
            End With

            With ._chcolf01Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With

            With ._chcolf01Datetime
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss.fff"
            End With

            With .GridView1
                With .Columns("f01String")
                    .AppearanceHeader.BackColor = Color.DeepPink
                    .AppearanceCell.BackColor = Color.LightPink
                End With
            End With

            With .GridView2
                With .Columns("k03String")
                    .AppearanceHeader.BackColor = Color.Salmon
                    .AppearanceCell.BackColor = Color.LightSalmon
                End With

                With .Columns("f22String")
                    .AppearanceHeader.BackColor = Color.Gray
                    .AppearanceCell.BackColor = Color.LightGray
                End With

                With .Columns("f03String")
                    .AppearanceHeader.BackColor = Color.Cyan
                    .AppearanceCell.BackColor = Color.LightCyan
                End With
            End With
        End With

    End Sub

    Private Sub _wd240707WidthOrderManagementPcode()
        ' lanjut nanti - 25/04/24 - AKIRRA

    End Sub


#End Region

#Region "*** STOCK CHECK ***"
    Private Sub _cc01CaptionStockCheck()
        With _prop03Grid
            ._colk03String.Caption = "SKU"
            ._colf19String.Caption = "Stock"
            ._colf07String.Caption = "Location"
            ._colf09String.Caption = "Box"
            ._colf22String.Caption = "Status"
            ._colf08String.Caption = "Warna"
            ._colf14String.Caption = "Size"
            ._colf01Double.Caption = "Gram"
            ._colf03Date.Caption = "Tgl.Inbound"
            ._colf03String.Caption = "Umur"
        End With
    End Sub

    Private Sub _vs01VisibilityStockCheck()
        With _prop03Grid
            ._colk03String.Visible = True   '"SKU"
            ._colf19String.Visible = True   '"Stock"
            ._colf07String.Visible = True   '"Location"
            ._colf09String.Visible = True   '"Storage Box"
            ._colf22String.Visible = True   '"Status"
            ._colf08String.Visible = True   '"Warna"
            ._colf14String.Visible = True   '"Size"
            ._colf01Double.Visible = True   '"Berat"
            ._colf03Date.Visible = True   '"Tgl.Inbound"
            ._colf03String.Visible = True   '"Umur"
        End With
    End Sub

    Private Sub _vs02VisibilityIndexStockCheck()
        With _prop03Grid
            ._colk03String.VisibleIndex = 0   '"SKU"
            ._colf19String.VisibleIndex = 1   '"Stock"
            ._colf07String.VisibleIndex = 2   '"Location"
            ._colf09String.VisibleIndex = 3   '"Storage Box"
            ._colf22String.VisibleIndex = 4   '"Status"
            ._colf08String.VisibleIndex = 5   '"Warna"
            ._colf14String.VisibleIndex = 6   '"Size"
            ._colf01Double.VisibleIndex = 7   '"Berat"
            ._colf03Date.VisibleIndex = 8   '"Tgl.Inbound"
            ._colf03String.VisibleIndex = 9   '"Umur"
        End With
    End Sub

    Private Sub _tot01TotRowPcsBeratStockCheck()
        With _prop03Grid.GridView1
            .OptionsView.ShowFooter = True

            .Columns("k03String").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("k03String").SummaryItem.DisplayFormat = "{0:n0} Rows"

            .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("f01Double").SummaryItem.FieldName = "f01Double"
            .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub _ll01LainLainStockCheck()
        With _prop03Grid
            With ._colf03Date
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy"
            End With

            With .GridView1
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
        End With

    End Sub

    Private Sub _wd240707WidthStockCheck()
        With _prop03Grid
            ' lanjut nanti - 28/04/24 - AKIRRA
        End With
    End Sub
#End Region
End Class
