Imports System.ComponentModel

Public Class xr24LE02SRP_PickingList
    Private Sub xr24LE02SRP_PickingList_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        cm01InitField()
    End Sub


    Dim counter As Integer = 0
    Private Sub _01NomorUrut_BeforePrint(sender As Object, e As CancelEventArgs) Handles _01NomorUrut.BeforePrint
        counter += 1

        _01NomorUrut.Text = counter.ToString()
    End Sub



    Private Sub cm01InitField()
        _02Segmen.Text = "[f02String]"
        _03ProductCode.Text = "[k03String]"
        _04MasterCode.Text = "[f01String]"
        _05Qty.Text = "[f01SmallInt]"
        _06Alamat.Text = "[f08String]"
        _07Collection.Text = "[f07String]"
        _08Item.Text = "[f04String]"
        _09Kadar.Text = "[f03String]"
        _10Size.Text = "[f05String]"
        _11Warna.Text = "[f06String]"
        _12Order.Text = "[k01String]"

    End Sub


End Class