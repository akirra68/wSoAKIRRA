Imports System.ComponentModel
Imports System.Globalization
Imports DevExpress.XtraReports.UI

Public Class xr24LE03RP_SuratJalan
    '========== Author : Aga ==========

    Private Sub xr24LE03RP_SuratJalan_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        cm01InitField()
        cm02DisplaySub()
    End Sub

    Private Sub PageHeader_BeforePrint(sender As Object, e As CancelEventArgs) Handles PageHeader.BeforePrint
        Dim dt As DataTable = CType(Me.DataSource, DataTable)
        Dim ratePym As String = dt.Rows(0)("f10String").ToString()

        If String.IsNullOrWhiteSpace(ratePym) OrElse ratePym = "NON NPWP" Then
            _kopSurat.Visible = False
        End If

        '        Dim groupHeader As New GroupHeaderBand With {
        '    .HeightF = 30,
        '    .RepeatEveryPage = False,
        '    .PageBreak = PageBreak.BeforeBand,
        '    .Level = 0
        '}
        '        groupHeader.GroupFields.Add(New GroupField("[k01String]"))
        '        groupHeader.PageBreak = PageBreak.BeforeBand
        '        groupHeader.RepeatEveryPage = False
        '        ' groupHeader.ResetPageNumber = True
        '        Report.Bands.Add(groupHeader)
    End Sub

#Region "Report Events"

    Private Sub cm01InitField()
        _01NomorSJ.Text = "[k01String]"
        _02Customer.Text = "[f09String]"

        Dim dt As DataTable = CType(Me.DataSource, DataTable)
        Dim distinctK02 = dt.AsEnumerable() _
                .Select(Function(r) r.Field(Of String)("k02String")) _
                .Where(Function(s) Not String.IsNullOrEmpty(s)) _
                .Distinct() _
                .ToList()
        _03NomorOrder.Text = String.Join(", ", distinctK02)
        '_04Notes.Text = ""

        _PrintDate.Text = "Dicetak pada " & Now.ToString("dddd, dd MMMM yyyy", New CultureInfo("id-ID")) & " - " & Now.ToString("HH:mm:ss") & " WIB"
        XrPageInfo1.TextFormatString = "Halaman {0} dari {1}"
    End Sub
    Private Sub cm02DisplaySub()
        '***************************************

        Dim objSubSJ As New xr24LE04SRP_SuratJalan With {
           .DataSource = Me.DataSource
           }
        SubReportSuratJalan.ReportSource = objSubSJ

        '***************************************

        Dim objSubPK As New xr24LE05SRP_Packaging With {
          .DataSource = Me.DataSource
          }
        SubReportPackaging.ReportSource = objSubPK

    End Sub

#End Region
End Class