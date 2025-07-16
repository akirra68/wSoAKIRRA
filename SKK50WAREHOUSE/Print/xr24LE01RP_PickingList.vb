Imports System.ComponentModel
Imports System.Globalization
Imports SKK02OBJECTS

Public Class xr24LE01RP_PickingList
    '========== Author : Aga ==========
    'Property _prop01DataParent As DataTable
    'Property _prop02DataChild As DataTable
    Property _prop03Picker As String
    Property _prop04NoPicking As String

#Region "Report - Events"
    Private Sub xr24LE01RP_PickingList_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        cm01InitField()
        cm03displayReport()
    End Sub

    Private Sub cm01InitField()

        _01NomorPicking.Text = _prop04NoPicking

        Dim dt As DataTable = CType(Me.DataSource, DataTable)
        Dim distinctK01 = dt.AsEnumerable() _
                .Select(Function(r) r.Field(Of String)("k01String")) _
                .Where(Function(s) Not String.IsNullOrEmpty(s)) _
                .Distinct() _
                .ToList()

        _01NomorOrder.Text = String.Join(", ", distinctK01)
        _02PIC.Text = _prop03Picker
        _03NamaCustomer.Text = "[k02String]"
        _04TanggalOrder.Text = clsWSNasaOthers.TglDDMMYYYYWithNameMonth(DateValue(GetCurrentColumnValue("f02Date")))

        _PrintDate.Text = "Dicetak pada " & Now.ToString("dddd, dd MMMM yyyy", New CultureInfo("id-ID")) & " - " & Now.ToString("HH:mm:ss") & " WIB"

        XrPageInfo1.TextFormatString = "Halaman {0} dari {1}"
    End Sub

    Private Sub cm03displayReport()

        '***************************************

        Dim objSubPick As New xr24LE02SRP_PickingList With {
           .DataSource = Me.DataSource
           }
        SubReportPickingList.ReportSource = objSubPick

        '***************************************



    End Sub


#End Region



End Class