Imports DevExpress.XtraPivotGrid
Imports SKK02OBJECTS.ucReportGrid

Public Class ucReportPivot
    Implements IDisposable

    Property _prop01User As clsUserGEMINI
    Property _prop02TargetReport As TargetReportPivot
    Property _prop03pdtDataSourcePivot As DataTable

#Region "private - repository"
    Private _rscolk02Int As New repoGEMININumeric

    Private _rscolf01Int As New repoGEMININumeric
    Private _rscolf02Int As New repoGEMININumeric
    Private _rscolf03Int As New repoGEMININumeric
    Private _rscolf04Int As New repoGEMININumeric
    Private _rscolf05Int As New repoGEMININumeric
    Private _rscolf06Int As New repoGEMININumeric
    Private _rscolf07Int As New repoGEMININumeric

    Private _rscolf01Double As New repoGEMININumeric
    Private _rscolf02Double As New repoGEMININumeric
    Private _rscolf03Double As New repoGEMININumeric
    Private _rscolf04Double As New repoGEMININumeric
    Private _rscolf05Double As New repoGEMININumeric
    Private _rscolf06Double As New repoGEMININumeric
    Private _rscolf07Double As New repoGEMININumeric

    Private _rscolf01Double16 As New repoGEMININumeric
    Private _rscolf02Double16 As New repoGEMININumeric
    Private _rscolf03Double16 As New repoGEMININumeric
    Private _rscolf04Double16 As New repoGEMININumeric
    Private _rscolf05Double16 As New repoGEMININumeric

    Private _rscolf01Date As New repoGEMINIDate
    Private _rscolf02Date As New repoGEMINIDate
    Private _rscolf03Date As New repoGEMINIDate
    Private _rscolf04Date As New repoGEMINIDate
    Private _rscolf05Date As New repoGEMINIDate

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "form - event"
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "private custom - method"
    Private Sub _cm01InitAreaPivot()
        colk01String.Area = PivotArea.FilterArea   '"k01String"
        colk02Int.Area = PivotArea.FilterArea   '"k02Int"
        colk03String.Area = PivotArea.FilterArea   '"k03String"
        colk04String.Area = PivotArea.FilterArea   '"k04String"
        colk05String.Area = PivotArea.FilterArea   '"k05String"
        colf01String.Area = PivotArea.FilterArea   '"f01String"
        colf02String.Area = PivotArea.FilterArea   '"f02String"
        colf03String.Area = PivotArea.FilterArea   '"f03String"
        colf04String.Area = PivotArea.FilterArea   '"f04String"
        colf05String.Area = PivotArea.FilterArea   '"f05String"
        colf06String.Area = PivotArea.FilterArea   '"f06String"
        colf07String.Area = PivotArea.FilterArea   '"f07String"
        colf08String.Area = PivotArea.FilterArea   '"f08String"
        colf09String.Area = PivotArea.FilterArea   '"f09String"
        colf10String.Area = PivotArea.FilterArea   '"f10String"
        colf11String.Area = PivotArea.FilterArea   '"f11String"
        colf12String.Area = PivotArea.FilterArea   '"f12String"
        colf13String.Area = PivotArea.FilterArea   '"f13String"
        colf14String.Area = PivotArea.FilterArea   '"f14String"
        colf15String.Area = PivotArea.FilterArea   '"f15String"
        colf16String.Area = PivotArea.FilterArea   '"f16String"
        colf17String.Area = PivotArea.FilterArea   '"f17String"
        colf18String.Area = PivotArea.FilterArea   '"f18String"
        colf19String.Area = PivotArea.FilterArea   '"f19String"
        colf20String.Area = PivotArea.FilterArea   '"f20String"
        colf21String.Area = PivotArea.FilterArea   '"f21String"
        colf22String.Area = PivotArea.FilterArea   '"f22String"
        colf23String.Area = PivotArea.FilterArea   '"f23String"
        colf24String.Area = PivotArea.FilterArea   '"f24String"
        colf25String.Area = PivotArea.FilterArea   '"f25String"
        colf26String.Area = PivotArea.FilterArea   '"f26String"
        colf27String.Area = PivotArea.FilterArea   '"f27String"
        colf28String.Area = PivotArea.FilterArea   '"f28String"
        colf29String.Area = PivotArea.FilterArea   '"f29String"
        colf30String.Area = PivotArea.FilterArea   '"f30String"
        colf01Memo.Area = PivotArea.FilterArea   '"f01Memo"
        colf01Int.Area = PivotArea.FilterArea   '"f01Int"
        colf02Int.Area = PivotArea.FilterArea   '"f02Int"
        colf03Int.Area = PivotArea.FilterArea   '"f03Int"
        colf04Int.Area = PivotArea.FilterArea   '"f04Int"
        colf05Int.Area = PivotArea.FilterArea   '"f05Int"
        colf06Int.Area = PivotArea.FilterArea   '"f06Int"
        colf07Int.Area = PivotArea.FilterArea   '"f07Int"
        colf01Double.Area = PivotArea.FilterArea   '"f01Double"
        colf02Double.Area = PivotArea.FilterArea   '"f02Double"
        colf03Double.Area = PivotArea.FilterArea   '"f03Double"
        colf04Double.Area = PivotArea.FilterArea   '"f04Double"
        colf05Double.Area = PivotArea.FilterArea   '"f05Double"
        colf06Double.Area = PivotArea.FilterArea   '"f06Double"
        colf07Double.Area = PivotArea.FilterArea   '"f07Double"

        colf01Double16.Area = PivotArea.FilterArea   '"f01Double16"
        colf02Double16.Area = PivotArea.FilterArea   '"f02Double16"
        colf03Double16.Area = PivotArea.FilterArea   '"f03Double6"
        colf04Double16.Area = PivotArea.FilterArea   '"f04Double16"
        colf05Double16.Area = PivotArea.FilterArea   '"f05Double16"

        colf01Date.Area = PivotArea.FilterArea   '"f01Date"
        colf02Date.Area = PivotArea.FilterArea   '"f02Date"
        colf03Date.Area = PivotArea.FilterArea   '"f03Date"
        colf04Date.Area = PivotArea.FilterArea   '"f04Date"
        colf05Date.Area = PivotArea.FilterArea   '"f05Date"
    End Sub

    Private Sub _cm02InitFieldPivot()
        colk01String.FieldName = "k01String"
        colk02Int.FieldName = "k02Int"
        colk03String.FieldName = "k03String"
        colk04String.FieldName = "k04String"
        colk05String.FieldName = "k05String"
        colf01String.FieldName = "f01String"
        colf02String.FieldName = "f02String"
        colf03String.FieldName = "f03String"
        colf04String.FieldName = "f04String"
        colf05String.FieldName = "f05String"
        colf06String.FieldName = "f06String"
        colf07String.FieldName = "f07String"
        colf08String.FieldName = "f08String"
        colf09String.FieldName = "f09String"
        colf10String.FieldName = "f10String"
        colf11String.FieldName = "f11String"
        colf12String.FieldName = "f12String"
        colf13String.FieldName = "f13String"
        colf14String.FieldName = "f14String"
        colf15String.FieldName = "f15String"
        colf16String.FieldName = "f16String"
        colf17String.FieldName = "f17String"
        colf18String.FieldName = "f18String"
        colf19String.FieldName = "f19String"
        colf20String.FieldName = "f20String"
        colf21String.FieldName = "f21String"
        colf22String.FieldName = "f22String"
        colf23String.FieldName = "f23String"
        colf24String.FieldName = "f24String"
        colf25String.FieldName = "f25String"
        colf26String.FieldName = "f26String"
        colf27String.FieldName = "f27String"
        colf28String.FieldName = "f28String"
        colf29String.FieldName = "f29String"
        colf30String.FieldName = "f30String"
        colf01Memo.FieldName = "f01Memo"
        colf01Int.FieldName = "f01Int"
        colf02Int.FieldName = "f02Int"
        colf03Int.FieldName = "f03Int"
        colf04Int.FieldName = "f04Int"
        colf05Int.FieldName = "f05Int"
        colf06Int.FieldName = "f06Int"
        colf07Int.FieldName = "f07Int"
        colf01Double.FieldName = "f01Double"
        colf02Double.FieldName = "f02Double"
        colf03Double.FieldName = "f03Double"
        colf04Double.FieldName = "f04Double"
        colf05Double.FieldName = "f05Double"
        colf06Double.FieldName = "f06Double"
        colf07Double.FieldName = "f07Double"

        colf01Double16.FieldName = "f01Double16"
        colf02Double16.FieldName = "f02Double16"
        colf03Double16.FieldName = "f03Double16"
        colf04Double16.FieldName = "f04Double16"
        colf05Double16.FieldName = "f05Double16"

        colf01Date.FieldName = "f01Date"
        colf02Date.FieldName = "f02Date"
        colf03Date.FieldName = "f03Date"
        colf04Date.FieldName = "f04Date"
        colf05Date.FieldName = "f05Date"
    End Sub

    Private Sub _cm03InitRepoColumn()
        _rscolk02Int._01InitRepoInteger()

        _rscolf01Int._01InitRepoInteger()
        _rscolf02Int._01InitRepoInteger()
        _rscolf03Int._01InitRepoInteger()
        _rscolf04Int._01InitRepoInteger()
        _rscolf05Int._01InitRepoInteger()
        _rscolf06Int._01InitRepoInteger()
        _rscolf07Int._01InitRepoInteger()

        _rscolf01Double._02InitRepoDoubleMoney(3)
        _rscolf02Double._02InitRepoDoubleMoney(3)
        _rscolf03Double._02InitRepoDoubleMoney(3)
        _rscolf04Double._02InitRepoDoubleMoney(3)
        _rscolf05Double._02InitRepoDoubleMoney(3)
        _rscolf06Double._02InitRepoDoubleMoney(3)
        _rscolf07Double._02InitRepoDoubleMoney(3)

        _rscolf01Double16._02InitRepoDoubleMoney(3)
        _rscolf02Double16._02InitRepoDoubleMoney(3)
        _rscolf03Double16._02InitRepoDoubleMoney(3)
        _rscolf04Double16._02InitRepoDoubleMoney(3)
        _rscolf05Double16._02InitRepoDoubleMoney(3)

        _rscolf01Date._01InitRepoDate()
        _rscolf02Date._01InitRepoDate()
        _rscolf03Date._01InitRepoDate()
        _rscolf04Date._01InitRepoDate()
        _rscolf05Date._01InitRepoDate()

    End Sub

    Private Sub _cm04InitCellFormatNumericDate(ByRef objColumn As PivotGridField, ByVal prmcIntDoubleDate As String)
        Dim pcDisplayFormat As String
        pcDisplayFormat = ""

        objColumn.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        Select Case prmcIntDoubleDate
            Case "INT"
                pcDisplayFormat = "{0:n0}"
            Case "DBL"
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
        _cm04InitCellFormatNumericDate(colk02Int, "INT")
        _cm04InitCellFormatNumericDate(colf01Int, "INT")
        _cm04InitCellFormatNumericDate(colf02Int, "INT")
        _cm04InitCellFormatNumericDate(colf03Int, "INT")
        _cm04InitCellFormatNumericDate(colf04Int, "INT")
        _cm04InitCellFormatNumericDate(colf05Int, "INT")
        _cm04InitCellFormatNumericDate(colf06Int, "INT")
        _cm04InitCellFormatNumericDate(colf07Int, "INT")

        _cm04InitCellFormatNumericDate(colf01Double, "DBL")
        _cm04InitCellFormatNumericDate(colf02Double, "DBL")
        _cm04InitCellFormatNumericDate(colf03Double, "DBL")
        _cm04InitCellFormatNumericDate(colf04Double, "DBL")
        _cm04InitCellFormatNumericDate(colf05Double, "DBL")
        _cm04InitCellFormatNumericDate(colf06Double, "DBL")
        _cm04InitCellFormatNumericDate(colf07Double, "DBL")

        _cm04InitCellFormatNumericDate(colf01Double16, "DBL3")
        _cm04InitCellFormatNumericDate(colf02Double16, "DBL3")
        _cm04InitCellFormatNumericDate(colf03Double16, "DBL3")
        _cm04InitCellFormatNumericDate(colf04Double16, "DBL3")
        _cm04InitCellFormatNumericDate(colf05Double16, "DBL3")

        _cm04InitCellFormatNumericDate(colf01Date, "DATE")
        _cm04InitCellFormatNumericDate(colf02Date, "DATE")
        _cm04InitCellFormatNumericDate(colf03Date, "DATE")
        _cm04InitCellFormatNumericDate(colf04Date, "DATE")
        _cm04InitCellFormatNumericDate(colf05Date, "DATE")

    End Sub

    Private Sub _cm06InitReadOnly()

        colk01String.Options.ReadOnly = True '"k01String"
        colk02Int.Options.ReadOnly = True '"k02Int"
        colk03String.Options.ReadOnly = True '"k03String"
        colk04String.Options.ReadOnly = True '"k04String"
        colk05String.Options.ReadOnly = True '"k05String"
        colf01String.Options.ReadOnly = True '"f01String"
        colf02String.Options.ReadOnly = True '"f02String"
        colf03String.Options.ReadOnly = True '"f03String"
        colf04String.Options.ReadOnly = True '"f04String"
        colf05String.Options.ReadOnly = True '"f05String"
        colf06String.Options.ReadOnly = True '"f06String"
        colf07String.Options.ReadOnly = True '"f07String"
        colf08String.Options.ReadOnly = True '"f08String"
        colf09String.Options.ReadOnly = True '"f09String"
        colf10String.Options.ReadOnly = True '"f10String"
        colf11String.Options.ReadOnly = True '"f11String"
        colf12String.Options.ReadOnly = True '"f12String"
        colf13String.Options.ReadOnly = True '"f13String"
        colf14String.Options.ReadOnly = True '"f14String"
        colf15String.Options.ReadOnly = True '"f15String"
        colf16String.Options.ReadOnly = True '"f16String"
        colf17String.Options.ReadOnly = True '"f17String"
        colf18String.Options.ReadOnly = True '"f18String"
        colf19String.Options.ReadOnly = True '"f19String"
        colf20String.Options.ReadOnly = True '"f20String"
        colf21String.Options.ReadOnly = True '"f21String"
        colf22String.Options.ReadOnly = True '"f22String"
        colf23String.Options.ReadOnly = True '"f23String"
        colf24String.Options.ReadOnly = True '"f24String"
        colf25String.Options.ReadOnly = True '"f25String"
        colf26String.Options.ReadOnly = True '"f26String"
        colf27String.Options.ReadOnly = True '"f27String"
        colf28String.Options.ReadOnly = True '"f28String"
        colf29String.Options.ReadOnly = True '"f29String"
        colf30String.Options.ReadOnly = True '"f30String"
        colf01Memo.Options.ReadOnly = True '"f01Memo"
        colf01Int.Options.ReadOnly = True '"f01Int"
        colf02Int.Options.ReadOnly = True '"f02Int"
        colf03Int.Options.ReadOnly = True '"f03Int"
        colf04Int.Options.ReadOnly = True '"f04Int"
        colf05Int.Options.ReadOnly = True '"f05Int"
        colf06Int.Options.ReadOnly = True '"f06Int"
        colf07Int.Options.ReadOnly = True '"f07Int"
        colf01Double.Options.ReadOnly = True '"f01Double"
        colf02Double.Options.ReadOnly = True '"f02Double"
        colf03Double.Options.ReadOnly = True '"f03Double"
        colf04Double.Options.ReadOnly = True '"f04Double"
        colf05Double.Options.ReadOnly = True '"f05Double"
        colf06Double.Options.ReadOnly = True '"f06Double"
        colf07Double.Options.ReadOnly = True '"f07Double"

        colf01Double16.Options.ReadOnly = True '"f01Double"
        colf02Double16.Options.ReadOnly = True '"f02Double"
        colf03Double16.Options.ReadOnly = True '"f03Double"
        colf04Double16.Options.ReadOnly = True '"f04Double"
        colf05Double16.Options.ReadOnly = True '"f05Double"

        colf01Date.Options.ReadOnly = True '"f01Date"
        colf02Date.Options.ReadOnly = True '"f02Date"
        colf03Date.Options.ReadOnly = True '"f03Date"
        colf04Date.Options.ReadOnly = True '"f04Date"
        colf05Date.Options.ReadOnly = True '"f05Date"

    End Sub

    Private Sub _cm07InitVisibilityOFF()

        colk01String.Visible = False
        colk02Int.Visible = False
        colk03String.Visible = False
        colk04String.Visible = False
        colk05String.Visible = False

        colf01String.Visible = False
        colf02String.Visible = False
        colf03String.Visible = False
        colf04String.Visible = False
        colf05String.Visible = False
        colf06String.Visible = False
        colf07String.Visible = False
        colf08String.Visible = False
        colf09String.Visible = False
        colf10String.Visible = False
        colf11String.Visible = False
        colf12String.Visible = False
        colf13String.Visible = False
        colf14String.Visible = False
        colf15String.Visible = False
        colf16String.Visible = False
        colf17String.Visible = False
        colf18String.Visible = False
        colf19String.Visible = False
        colf20String.Visible = False
        colf21String.Visible = False
        colf22String.Visible = False
        colf23String.Visible = False
        colf24String.Visible = False
        colf25String.Visible = False
        colf26String.Visible = False
        colf27String.Visible = False
        colf28String.Visible = False
        colf29String.Visible = False
        colf30String.Visible = False

        colf01Memo.Visible = False
        colf01Int.Visible = False
        colf02Int.Visible = False
        colf03Int.Visible = False
        colf04Int.Visible = False
        colf05Int.Visible = False
        colf06Int.Visible = False
        colf07Int.Visible = False

        colf01Double.Visible = False
        colf02Double.Visible = False
        colf03Double.Visible = False
        colf04Double.Visible = False
        colf05Double.Visible = False
        colf06Double.Visible = False
        colf07Double.Visible = False

        colf01Double16.Visible = False
        colf02Double16.Visible = False
        colf03Double16.Visible = False
        colf04Double16.Visible = False
        colf05Double16.Visible = False

        colf01Date.Visible = False
        colf02Date.Visible = False
        colf03Date.Visible = False
        colf04Date.Visible = False
        colf05Date.Visible = False

    End Sub

    Private Sub _cm08PropertiesPivotONTarget()
        _mp01ShowPivot()
    End Sub

    Private Sub _cm09SettingControlPivot()
        With PivotGridControl1
            With .OptionsView
                .ShowColumnGrandTotalHeader = True
                .ShowColumnGrandTotals = True
                .ShowRowGrandTotalHeader = True
                .ShowRowGrandTotals = True
                .ShowRowTotals = True
            End With

            'Select Case prop02TargetPivot
            '    Case TargetReportFinance._FARPT01SemuaPenerimaanFaktur
            '        With .OptionsView
            '            .ShowColumnGrandTotalHeader = False
            '            .ShowColumnGrandTotals = False
            '            .ShowRowGrandTotalHeader = False
            '            .ShowRowGrandTotals = False
            '            .ShowRowTotals = False
            '        End With
            'End Select
        End With

    End Sub

#End Region

#Region "event - pivot"
    Private Sub PivotGridControl1_ShownEditor(sender As Object, e As DevExpress.XtraPivotGrid.PivotCellEditEventArgs) Handles PivotGridControl1.ShownEditor
        PivotGridControl1.ActiveEditor.Properties.ReadOnly = True
    End Sub

    Private Sub PivotGridControl1_DoubleClick(sender As Object, e As EventArgs) Handles PivotGridControl1.DoubleClick
        Cursor = Cursors.WaitCursor

        If Not PivotGridControl1.IsPrintingAvailable Then
            MessageBox.Show("Maaf ... ada library yg harus terinstall, silahkan hub IT.", "Error")
            Return
        End If

        PivotGridControl1.ShowPrintPreview()

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "public custom - method"
    Public Sub _pb01InitPivot()
        _cm01InitAreaPivot()
        _cm02InitFieldPivot()
        _cm03InitRepoColumn()
        _cm05InitRepoCellFormat()
        _cm06InitReadOnly()

        'agar waktu pertama kali display, kosong... tanpa header kolom
        _cm07InitVisibilityOFF()
    End Sub

    Public Sub _pb02ClearPivot()
        PivotGridControl1.DataSource = Nothing
        PivotGridControl1.Refresh()
    End Sub

    Public Sub _pb03DisplayReportPivot()
        _cm08PropertiesPivotONTarget()

        PivotGridControl1.DataSource = Nothing
        PivotGridControl1.RefreshData()
        PivotGridControl1.Refresh()

        PivotGridControl1.DataSource = _prop03pdtDataSourcePivot
        PivotGridControl1.RefreshData()
        PivotGridControl1.Refresh()

        PivotGridControl1.Dock = DockStyle.Fill
    End Sub

    Public Sub _pb04DisplayPanelFilter(ByVal prmDisplay As Boolean)
        If prmDisplay Then
            PivotGridControl1.OptionsView.ShowFilterHeaders = True
        Else
            PivotGridControl1.OptionsView.ShowFilterHeaders = False
        End If
    End Sub

#End Region

#Region "********** method private - UPDATE CHANGE **********"
    Public Enum TargetReportPivot
        _FARpt01SelisihRate = 0
    End Enum

    Private Sub _mp01ShowPivot()
        _cm09SettingControlPivot()

        Select Case _prop02TargetReport
            Case TargetReportPivot._FARpt01SelisihRate
        End Select
    End Sub

#End Region

#Region "***** 70. FA - SELISIH RATE  *****"

#End Region
End Class
