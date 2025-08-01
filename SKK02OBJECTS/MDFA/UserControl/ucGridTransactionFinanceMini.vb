Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports SKK02OBJECTS.ucGridTransactionFinance

Public Class ucGridTransactionFinanceMini
    Implements IDisposable

    Public Property _prop00User As clsUserGEMINI
    Public Property _prop02pdtDataSource As New DataTable
    Public Property _prop03TargetProses As TargetProses
    Public Property _prop04FinanceHargaEmas As clsFinanceHargaEmas
    Public Property _prop05String As String

#Region "private - repository"

    Private _rscolk00Int As New repoGEMININumeric
    Private _rscolk02Int As New repoGEMININumeric

    Private _rscolf01Int As New repoGEMININumeric
    Private _rscolf02Int As New repoGEMININumeric
    Private _rscolf03Int As New repoGEMININumeric
    Private _rscolf04Int As New repoGEMININumeric
    Private _rscolf05Int As New repoGEMININumeric

    Private _rscolf01Double As New repoGEMININumeric
    Private _rscolf02Double As New repoGEMININumeric
    Private _rscolf03Double As New repoGEMININumeric
    Private _rscolf04Double As New repoGEMININumeric
    Private _rscolf05Double As New repoGEMININumeric

    Private _rscolf01Date As New repoGEMINIDate
    Private _rscolf02Date As New repoGEMINIDate
    Private _rscolf03Date As New repoGEMINIDate

#End Region

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        _rscolk00Int.Dispose()
        _rscolk02Int.Dispose()

        _rscolf01Int.Dispose()
        _rscolf02Int.Dispose()
        _rscolf03Int.Dispose()
        _rscolf04Int.Dispose()
        _rscolf05Int.Dispose()

        _rscolf01Double.Dispose()
        _rscolf02Double.Dispose()
        _rscolf03Double.Dispose()
        _rscolf04Double.Dispose()
        _rscolf05Double.Dispose()

        _rscolf01Date.Dispose()
        _rscolf02Date.Dispose()
        _rscolf03Date.Dispose()
    End Sub

    Private Sub ucGridTransactionFinanceMini_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#End Region

#Region "private - custom method"

    Private Sub _cm01InitFieldGrid()
        GridView1.OptionsView.ColumnAutoWidth = False

        colk00Boolean.FieldName = "k00Boolean"
        colk00Int.FieldName = "k00Int"

        colk03String.FieldName = "k03String"
        colk04String.FieldName = "k04String"
        colk05String.FieldName = "k05String"

        colf01String.FieldName = "f01String"
        colf02String.FieldName = "f02String"
        colf03String.FieldName = "f03String"
        colf04String.FieldName = "f04String"
        colf05String.FieldName = "f05String"

        colf01Int.FieldName = "f01Int"
        colf02Int.FieldName = "f02Int"
        colf03Int.FieldName = "f03Int"
        colf04Int.FieldName = "f04Int"
        colf05Int.FieldName = "f05Int"

        colf01Double.FieldName = "f01Double"
        colf02Double.FieldName = "f02Double"
        colf03Double.FieldName = "f03Double"
        colf04Double.FieldName = "f04Double"
        colf05Double.FieldName = "f05Double"

        colf01Date.FieldName = "f01Date"
        colf02Date.FieldName = "f02Date"
        colf03Date.FieldName = "f03Date"

    End Sub

    Private Sub _cm02InitRepoColumn()
        _rscolk00Int._01InitRepoInteger()
        _rscolk02Int._01InitRepoInteger()

        _rscolf01Int._01InitRepoInteger()
        _rscolf02Int._01InitRepoInteger()
        _rscolf03Int._01InitRepoInteger()
        _rscolf04Int._01InitRepoInteger()
        _rscolf05Int._01InitRepoInteger()

        _rscolf01Double._02InitRepoDoubleMoney(3)
        _rscolf02Double._02InitRepoDoubleMoney(3)
        _rscolf03Double._02InitRepoDoubleMoney(3)
        _rscolf04Double._02InitRepoDoubleMoney(3)
        _rscolf05Double._02InitRepoDoubleMoney(3)

        _rscolf01Date._01InitRepoDate()
        _rscolf02Date._01InitRepoDate()
        _rscolf03Date._01InitRepoDate()

    End Sub

    Private Sub _cm03InitColumnEdit()
        colf01Int.ColumnEdit = _rscolf01Int
        colf02Int.ColumnEdit = _rscolf02Int
        colf03Int.ColumnEdit = _rscolf03Int
        colf04Int.ColumnEdit = _rscolf04Int
        colf05Int.ColumnEdit = _rscolf05Int

        colf01Double.ColumnEdit = _rscolf01Double
        colf02Double.ColumnEdit = _rscolf02Double
        colf03Double.ColumnEdit = _rscolf03Double
        colf04Double.ColumnEdit = _rscolf04Double
        colf05Double.ColumnEdit = _rscolf05Double

        colf01Date.ColumnEdit = _rscolf01Date
        colf02Date.ColumnEdit = _rscolf02Date
        colf03Date.ColumnEdit = _rscolf03Date
    End Sub

    Private Sub _cm04InitGridSummaryItem(ByRef objColumn As GridColumn,
                                         ByVal prmcFieldName As String,
                                         ByVal prmcIntDouble As String)
        Dim pcDisplayFormat As String
        pcDisplayFormat = ""

        Select Case prmcIntDouble
            Case "INT"
                pcDisplayFormat = "{0:n0}"
            Case "DBL"
                pcDisplayFormat = "{0:n2}"
        End Select

        Dim objGridSummaryItem As New GridSummaryItem
        With objGridSummaryItem
            .DisplayFormat = pcDisplayFormat
            .FieldName = prmcFieldName
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With

    End Sub

    Private Sub _cm05SettingColumnSummary()
        _cm04InitGridSummaryItem(colk00Int, "k00Int", "INT")
        _cm04InitGridSummaryItem(colf01Int, "f01Int", "INT")
        _cm04InitGridSummaryItem(colf02Int, "f02Int", "INT")
        _cm04InitGridSummaryItem(colf03Int, "f03Int", "INT")
        _cm04InitGridSummaryItem(colf04Int, "f04Int", "INT")
        _cm04InitGridSummaryItem(colf05Int, "f05Int", "INT")
        _cm04InitGridSummaryItem(colf01Double, "f01Double", "DBL")
        _cm04InitGridSummaryItem(colf02Double, "f02Double", "DBL")
        _cm04InitGridSummaryItem(colf03Double, "f03Double", "DBL")
        _cm04InitGridSummaryItem(colf04Double, "f04Double", "DBL")
        _cm04InitGridSummaryItem(colf05Double, "f05Double", "DBL")
    End Sub

    Private Sub _cm06InitVisibilityOFF()
        colk00Boolean.Visible = False
        colk00Int.Visible = False

        colk03String.Visible = False
        colk04String.Visible = False
        colk05String.Visible = False

        colf01String.Visible = False
        colf02String.Visible = False
        colf03String.Visible = False
        colf04String.Visible = False
        colf05String.Visible = False

        colf01Int.Visible = False
        colf02Int.Visible = False
        colf03Int.Visible = False
        colf04Int.Visible = False
        colf05Int.Visible = False

        colf01Double.Visible = False
        colf02Double.Visible = False
        colf03Double.Visible = False
        colf04Double.Visible = False
        colf05Double.Visible = False

        colf01Date.Visible = False
        colf02Date.Visible = False
        colf03Date.Visible = False

    End Sub

    Private Sub _cm07InitVisibilityIndexOFF()
        colk00Boolean.VisibleIndex = -1
        colk00Int.VisibleIndex = -1

        colk03String.VisibleIndex = -1
        colk04String.VisibleIndex = -1
        colk05String.VisibleIndex = -1

        colf01String.VisibleIndex = -1
        colf02String.VisibleIndex = -1
        colf03String.VisibleIndex = -1
        colf04String.VisibleIndex = -1
        colf05String.VisibleIndex = -1

        colf01Int.VisibleIndex = -1
        colf02Int.VisibleIndex = -1
        colf03Int.VisibleIndex = -1
        colf04Int.VisibleIndex = -1
        colf05Int.VisibleIndex = -1

        colf01Double.VisibleIndex = -1
        colf02Double.VisibleIndex = -1
        colf03Double.VisibleIndex = -1
        colf04Double.VisibleIndex = -1
        colf05Double.VisibleIndex = -1

        colf01Date.VisibleIndex = -1
        colf02Date.VisibleIndex = -1
        colf03Date.VisibleIndex = -1

    End Sub

    Private Sub _cm08ReadOnlyGrid()
        colk00Boolean.OptionsColumn.ReadOnly = False
        colk00Int.OptionsColumn.ReadOnly = False

        colk03String.OptionsColumn.ReadOnly = True
        colk04String.OptionsColumn.ReadOnly = True
        colk05String.OptionsColumn.ReadOnly = True

        colf01String.OptionsColumn.ReadOnly = True
        colf02String.OptionsColumn.ReadOnly = True
        colf03String.OptionsColumn.ReadOnly = True
        colf04String.OptionsColumn.ReadOnly = True
        colf05String.OptionsColumn.ReadOnly = True

        colf01Int.OptionsColumn.ReadOnly = True
        colf02Int.OptionsColumn.ReadOnly = True
        colf03Int.OptionsColumn.ReadOnly = True
        colf04Int.OptionsColumn.ReadOnly = True
        colf05Int.OptionsColumn.ReadOnly = True

        colf01Double.OptionsColumn.ReadOnly = True
        colf02Double.OptionsColumn.ReadOnly = True
        colf03Double.OptionsColumn.ReadOnly = True
        colf04Double.OptionsColumn.ReadOnly = True
        colf05Double.OptionsColumn.ReadOnly = True

        colf01Date.OptionsColumn.ReadOnly = True
        colf02Date.OptionsColumn.ReadOnly = True
        colf03Date.OptionsColumn.ReadOnly = True

    End Sub

    Private Sub _cm09PropertiesGridONTarget()
        'OFF
        _cm06InitVisibilityOFF()
        _cm07InitVisibilityIndexOFF()

        'ON
        _mp01SettingRepoColoumn()
        _mp03SettingVisibilityON()
        _mp02SettingColumnCaption()
        _mp04SettingWriteColumn()
    End Sub

#End Region

#Region "public - method : Setting Grid"

    Public Sub _pb01InitGrid()
        _cm01InitFieldGrid()
        _cm02InitRepoColumn()
        _cm03InitColumnEdit()
        _cm05SettingColumnSummary()

        'agar waktu pertama kali display, kosong... tanpa header kolom
        _cm06InitVisibilityOFF()
        _cm07InitVisibilityIndexOFF()
        _cm08ReadOnlyGrid()
    End Sub

    Public Sub _pb02ClearGrid()
        GridControl1.DataSource = Nothing
        GridControl1.Refresh()
    End Sub

    Public Sub _pb03DisplayGridTransaction()
        _cm09PropertiesGridONTarget()

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = _prop02pdtDataSource

        GridView1.BestFitColumns()

        Me.Dock = DockStyle.Fill
    End Sub

    Public Function _pb04AddNewDataToGridParent() As DataTable

        Dim pdtDataHasil As New DataTable

        If _prop03TargetProses = TargetProses._01FA23GV01NOFAKTUR_UPDATE Then
            Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin melakukan TAMBAH DATA ... ?", vbYesNo + MsgBoxStyle.Question, _prop00User._UserProp01cTitle)

            If plYes = MsgBoxResult.Yes Then
                Dim dtRows As DataRow()
                dtRows = _prop02pdtDataSource.Select(" k00Boolean = " & True)
                pdtDataHasil = dtRows.CopyToDataTable()
            Else
                MsgBox("TAMBAH DATA ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop00User._UserProp01cTitle)
            End If
        End If

        Return pdtDataHasil
    End Function

    Public Function _pb05GetStringKeyEntity() As String
        Dim pcString As String = ""

        Dim pIsFirst As Boolean = True

        For Each dtRow As DataRow In _prop02pdtDataSource.Rows
            If CBool(dtRow("k00Boolean")) Then
                If pIsFirst Then
                    pcString = " (f01String = '" & dtRow("f01String") & "' and f14String = '" & dtRow("f03String") & "') "
                    pIsFirst = False
                Else
                    pcString = pcString & " or (f01String = '" & dtRow("f01String") & "' and f14String = '" & dtRow("f03String") & "') "
                End If
            End If
        Next

        Return pcString
    End Function

    Public Function _pb06GetIdentitasEntity() As String
        Dim pcString As String = ""
        Dim pnJmlIdentitasYES As Int16 = 0
        Dim pnJmlIdentitasNON As Int16 = 0

        For Each dtRow As DataRow In _prop02pdtDataSource.Rows
            If CBool(dtRow("k00Boolean")) Then
                If Not String.IsNullOrEmpty(dtRow("f03String")) Then
                    pcString = dtRow("f03String")

                    If pcString = "YES" Then
                        pnJmlIdentitasYES = 1
                    Else
                        pnJmlIdentitasNON = 1
                    End If

                End If
            End If
        Next

        'Ini berarti Identitas yg dipilih ada 2, dan itu tidak boleh.
        'HANYA SATU Identitas yg BOLEH dipilih.
        If (pnJmlIdentitasYES + pnJmlIdentitasNON) = 2 Then
            pcString = "ERROR"
        End If

        Return pcString
    End Function

#End Region

#Region "event - control"

    Private Sub _rscolk00Boolean_CheckedChanged(sender As Object, e As EventArgs) Handles _rscolk00Boolean.CheckedChanged
        GridView1.PostEditor()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName = "k00Boolean" Then

            If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                GridView1.SetFocusedRowCellValue("k00Int", 1)
            Else
                GridView1.SetFocusedRowCellValue("k00Int", 0)
            End If

            GridView1.RefreshData()

        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim View As GridView = TryCast(sender, GridView)

        If e.RowHandle >= 0 Then
            Dim nCheck As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))
            If nCheck = 1 Then
                e.Appearance.BackColor = Color.LightYellow
            Else
                e.Appearance.BackColor = Color.White
            End If
        End If
    End Sub

#End Region

#Region "********** method private - UPDATE/CHANGE **********"

    Public Enum TargetProses
        'Transaksi
        _01FA23GV01NOFAKTUR_UPDATE = 0

        'Repo
        _01FA61REPOENTITY = 20
    End Enum

    Private Sub _mp01SettingRepoColoumn()
        Select Case _prop03TargetProses
            Case TargetProses._01FA23GV01NOFAKTUR_UPDATE

            Case Else

        End Select
    End Sub

    Private Sub _mp02SettingColumnCaption()
        Select Case _prop03TargetProses
            Case TargetProses._01FA23GV01NOFAKTUR_UPDATE
                _cc01CaptionCol620ProformaNoFaktur()

            Case TargetProses._01FA61REPOENTITY
                _cc01CaptionCol61RepoEntity()

            Case Else

        End Select
    End Sub

    Private Sub _mp03SettingVisibilityON()
        Select Case _prop03TargetProses
            Case TargetProses._01FA23GV01NOFAKTUR_UPDATE
                _vs01VisibilityCol620Proforma()
                _vs02VisibilityIndex620Proforma()

            Case TargetProses._01FA61REPOENTITY
                _vs01VisibilityCol61RepoEntity()
                _vs02VisibilityIndex61RepoEntity()

            Case Else

        End Select
    End Sub

    Private Sub _mp04SettingWriteColumn()
        Select Case _prop03TargetProses
            Case TargetProses._01FA23GV01NOFAKTUR_UPDATE
                _wr01WriteCol620Proforma()

            Case TargetProses._01FA61REPOENTITY
                _wr01WriteCol61RepoEntity()

            Case Else

        End Select
    End Sub

#End Region

#Region "***** FA Repo Entity (pada BILLING ataupun SETTLEMENT) ==> form : ucFA23HH01BILLING dan ucFA23GU01SETTLEMENTAR *****"
    Private Sub _cc01CaptionCol61RepoEntity()
        colk00Boolean.Caption = "#"

        colf03String.Caption = "Identity"
        colf01String.Caption = "Code"
        colf02String.Caption = "Name"
        colf01Double.Caption = "OST AR"
    End Sub

    Private Sub _vs01VisibilityCol61RepoEntity()
        colk00Boolean.Visible = True   '"#"

        colf03String.Visible = True   '"Identity"
        colf01String.Visible = True   '"Code"
        colf02String.Visible = True   '"Name"
        colf01Double.Visible = True   '"OST AR"
    End Sub

    Private Sub _vs02VisibilityIndex61RepoEntity()
        colk00Boolean.VisibleIndex = 0   '"#"

        colf03String.VisibleIndex = 1   '"Identity"
        colf01String.VisibleIndex = 2   '"Code"
        colf02String.VisibleIndex = 3   '"Name"
        colf01Double.VisibleIndex = 4   '"OST AR"
    End Sub

    Private Sub _wr01WriteCol61RepoEntity()
        colk00Boolean.OptionsColumn.ReadOnly = False '"#"
    End Sub

#End Region

#Region "***** FA ProformaInvoice (grid CREATE/UPDATE/DELETE) ==> form : ucFA23GV01PROFORMAINVOICE *****"

    Private Sub _cc01CaptionCol620ProformaNoFaktur()
        colk00Boolean.Caption = "#"

        colk03String.Caption = "No.Faktur"
        colk04String.Caption = "CO/PO"
        colk05String.Caption = "SJ"
        colf04String.Caption = "Brand"
        colf01Int.Caption = "Kadar"
        colf02Int.Caption = "PcsCMK"
        colf03Int.Caption = "PcsSKK"
        colf02Double.Caption = "BeratCMK"
        colf03Double.Caption = "BeratSKK"
        colf01Double.Caption = "TotBerat"
        colf01Date.Caption = "TglFaktur"
        colf02Date.Caption = "TglJT"
    End Sub

    Private Sub _vs01VisibilityCol620Proforma()
        colk00Boolean.Visible = True   '"#"

        'VISIBLE
        colk03String.Visible = True   '"No.Faktur"
        colk04String.Visible = True   '"CO/PO"
        colk05String.Visible = True   '"SJ"
        colf04String.Visible = True   '"Brand"
        colf01Int.Visible = True   '"Kadar"
        colf02Int.Visible = True   '"PcsCMK"
        colf03Int.Visible = True   '"PcsSKK"
        colf02Double.Visible = True   '"BeratCMK"
        colf03Double.Visible = True   '"BeratCMK"
        colf01Double.Visible = True   '"TotBerat"
        colf01Date.Visible = True   '"TglFaktur"
        colf02Date.Visible = True   '"TglJT"

    End Sub

    Private Sub _vs02VisibilityIndex620Proforma()
        colk00Boolean.VisibleIndex = 0 '"#"
        'VISIBLE
        colk03String.VisibleIndex = 1   '"No.Faktur"
        colk04String.VisibleIndex = 2   '"CO/PO"
        colk05String.VisibleIndex = 3   '"SJ"
        colf04String.VisibleIndex = 4   '"Brand"
        colf01Int.VisibleIndex = 5   '"Kadar"
        colf02Int.VisibleIndex = 6   '"PcsCMK"
        colf03Int.VisibleIndex = 7   '"PcsSKK"
        colf02Double.VisibleIndex = 8   '"BeratCMK"
        colf03Double.VisibleIndex = 9   '"BeratCMK"
        colf01Double.VisibleIndex = 10   '"TotBerat"
        colf01Date.VisibleIndex = 11   '"TglFaktur"
        colf02Date.VisibleIndex = 12   '"TglJT"

    End Sub

    Private Sub _wr01WriteCol620Proforma()
        colk00Boolean.OptionsColumn.ReadOnly = False '"#"
    End Sub

#End Region

End Class
