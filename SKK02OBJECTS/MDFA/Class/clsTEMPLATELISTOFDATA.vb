Public Class clsTEMPLATELISTOFDATA
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

    Public Property prop_dtLISTOFDATA As DataTable

    Private Function dtCreateLISTOFDATA() As DataTable
        Dim dtDataTable As New DataTable

        Dim fieldk01String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k01String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk01String)

        Dim fieldf01String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf01String)

        Dim fieldf01Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f01Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf01Int)

        Dim fieldf01Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f01Double", .DefaultValue = 0.0}
        dtDataTable.Columns.Add(fieldf01Double)

        Dim fieldf01Money As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f01Money", .DefaultValue = 0.0}
        dtDataTable.Columns.Add(fieldf01Money)

        Dim fieldf01Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f01Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf01Date)

        Return dtDataTable
    End Function

    Public Sub dtInitLISTOFDATA()
        prop_dtLISTOFDATA = Nothing
        prop_dtLISTOFDATA = dtCreateLISTOFDATA()
        prop_dtLISTOFDATA.Clear()
    End Sub

    Public Sub dtAddNewISTOFDATA(ByVal prmk01String As String, ByVal prmf01String As String, ByVal prmf01Int As Integer, ByVal prmf01Double As Double, ByVal prmf01Money As Double, ByVal prmf01Date As Date)

        Dim oDataRow As DataRow = prop_dtLISTOFDATA.NewRow()

        oDataRow("k01String") = prmk01String
        oDataRow("f01String") = prmf01String
        oDataRow("f01Int") = prmf01Int
        oDataRow("f01Double") = prmf01Double
        oDataRow("f01Money") = prmf01Money
        oDataRow("f01Date") = prmf01Date

        prop_dtLISTOFDATA.Rows.Add(oDataRow)
    End Sub

End Class
