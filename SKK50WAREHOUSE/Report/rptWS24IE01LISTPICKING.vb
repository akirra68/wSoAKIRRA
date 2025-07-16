Imports System.ComponentModel

Public Class rptWS24IE01LISTPICKING
    Implements IDisposable

    Property _prop01Picker As String

    Private Sub rptWS24IE01LISTPICKING_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        f15String.Text = "Picker : " & _prop01Picker '=>= f01String

        f02Date.Text = "[k01String]"   '"[f02Date]"
        k02String.Text = "[k02String]" 'No.PKB"
        k03String.Text = "[k03String]" 'ProductCode"
        f02String.Text = "[f02String]" 'Customer"

        f08String.Text = "[f03String]" 'Brand" =>= f03String
        f10String.Text = "[f04String]" 'Kadar" =>= f04String
        f01SmallInt.Text = "[f01SmallInt]" 'T.Qty"
    End Sub
End Class