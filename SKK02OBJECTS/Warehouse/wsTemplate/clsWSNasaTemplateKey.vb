Public Class clsWSNasaTemplateKey
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

    Public Property prop_dtKEY As DataTable

    Private Function dtCreateKEY() As DataTable
        Dim dtDataTable As New DataTable

        Dim fieldk01String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k01String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk01String)

        Dim fieldk02String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k02String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk02String)

        Dim fieldk03String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k03String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk03String)

        Dim fieldk04String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k04String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk04String)

        Dim fieldk05String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k05String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk05String)

        Return dtDataTable
    End Function

    Public Sub dtInitKEY()
        prop_dtKEY = Nothing
        prop_dtKEY = dtCreateKEY()
        prop_dtKEY.Clear()
    End Sub

    Public Sub dtAddNewKEY(ByVal prmk01String As String, ByVal prmk02String As String, ByVal prmk03String As String, ByVal prmk04String As String, ByVal prmk05String As String)

        Dim oDataRow As DataRow = prop_dtKEY.NewRow()

        oDataRow("k01String") = prmk01String
        oDataRow("k02String") = prmk02String
        oDataRow("k03String") = prmk03String
        oDataRow("k04String") = prmk04String
        oDataRow("k05String") = prmk05String

        prop_dtKEY.Rows.Add(oDataRow)
    End Sub

End Class
