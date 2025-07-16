Imports System.ComponentModel

Public Class xr24LE05SRP_Packaging
    Private Sub xr24LE05SRP_Packaging_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        cm01InitField()
    End Sub

    Private Sub cm01InitField()
        _01Pouch.Text = ""
        _02KartuKadar.Text = ""
        _03InsertCard.Text = ""
        _04PlastikOPP.Text = ""
        _05BoxWR.Text = ""
        _06BoxSN.Text = ""
    End Sub
End Class