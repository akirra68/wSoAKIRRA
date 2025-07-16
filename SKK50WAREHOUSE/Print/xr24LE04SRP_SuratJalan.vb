Imports System.ComponentModel

Public Class xr24LE04SRP_SuratJalan

    '========== Author : Fragile ==========

    Private Sub xr24LE04SRP_SuratJalan_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        cm01InitField()
    End Sub


    Dim counter As Integer = 0
    Private Sub _01NomorUrut_BeforePrint(sender As Object, e As CancelEventArgs) Handles _01NomorUrut.BeforePrint
        counter += 1

        _01NomorUrut.Text = counter.ToString()
    End Sub

    Private Sub cm01InitField()
        _02Segmen.Text = "[f04String]"
        _03SKU.Text = "[f02String]"
        _04MasterCode.Text = "[f01String]"
        _05ProductCode.Text = "[k03String]"
        _06Item.Text = "[f06String]"
        _07Kadar.Text = "[f05String]"
        _08Size.Text = "[f07String]"
        _09Warna.Text = "[f08String]"
        _10Berat.Text = "[f01Double]"
        _11Qty.Text = "[f01SmallInt]"
        _12NomorOrder.Text = "[k02String]"
        _13PIC.Text = "[f03String]"
        _14Customer.Text = "[f09String]"
    End Sub

End Class
