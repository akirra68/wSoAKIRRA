Imports System.ComponentModel

Public Class rptWS24IE02LISTPICKINGSKU
    Implements IDisposable

    Property _prop01DataParent As DataTable
    Property _prop02DataChild As DataTable
    Property _prop03Picker As String

    Private Sub rptWS24IE02LISTPICKINGSKU_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        f15String.Text = "Picker : " & _prop03Picker '=>= f01String

        Dim pdtTableParent As New DataTable("ParentPicking")
        Dim pdtTableChild As New DataTable("ChildPicking")

        pdtTableParent = _prop01DataParent
        pdtTableChild = _prop02DataChild

        Dim dsDataSet As New DataSet("PICKINGBRJ")
        dsDataSet.Tables.Add(pdtTableParent)
        dsDataSet.Tables.Add(pdtTableChild)

        Dim objRelPicking As DataRelation

        objRelPicking = New DataRelation("RELPICKING",
                   New DataColumn() {pdtTableParent.Columns("k02String"), pdtTableParent.Columns("k03String")},
                   New DataColumn() {pdtTableChild.Columns("k01String"), pdtTableChild.Columns("k02String")}, False)
        dsDataSet.Relations.Add(objRelPicking)

        DataSource = dsDataSet
        XrLabel2.DataBindings.Add("Text", dsDataSet, "k02String")     '"[k02String]" 'No.PKB"

        'PARENT
        f02Date.DataBindings.Add("Text", dsDataSet, "k01String")     '= "[k01String]"   '"[f02Date]"
        k02String.DataBindings.Add("Text", dsDataSet, "k02String")     '"[k02String]" 'No.PKB"
        k03String.DataBindings.Add("Text", dsDataSet, "k03String")     '"[k03String]" 'ProductCode"
        f02String.DataBindings.Add("Text", dsDataSet, "f02String")     '"[f02String]" 'Customer"

        f08String.DataBindings.Add("Text", dsDataSet, "f03String")     '"[f03String]" 'Brand" =>= f03String
        f10String.DataBindings.Add("Text", dsDataSet, "f04String")     '"[f04String]" 'Kadar" =>= f04String
        f01SmallInt.DataBindings.Add("Text", dsDataSet, "f01SmallInt")     '"[f01SmallInt]" 'T.Qty"

        'CHILD
        DetailReport.ReportPrintOptions.PrintOnEmptyDataSource = False
        DetailReport.DataMember = "RELPICKING"

        f05String.DataBindings.Add("Text", dsDataSet, "RELPICKING.f05String")     '"[f05String]" '"SKU"
        f01String.DataBindings.Add("Text", dsDataSet, "RELPICKING.f01String")     '"[f01String]" '"BOX"
        f01Int.DataBindings.Add("Text", dsDataSet, "RELPICKING.f01Int")           '"[f01Int]" '"Pcs"

    End Sub
End Class