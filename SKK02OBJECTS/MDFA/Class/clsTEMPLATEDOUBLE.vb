'********** create .NET Controller : clsTEMPLATEDOUBLE.vb ****************

Public Class clsTEMPLATEDOUBLE
     Implements IDisposable

Public Property prop_dtTEMPLATEDOUBLE As DataTable

Private Function dtCreateTEMPLATEDOUBLE As DataTable
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

     Dim fieldf01String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01String", .DefaultValue = ""}
     dtDataTable.Columns.Add(fieldf01String)

     Dim fieldf02String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f02String", .DefaultValue = ""}
     dtDataTable.Columns.Add(fieldf02String)

     Dim fieldf03String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f03String", .DefaultValue = ""}
     dtDataTable.Columns.Add(fieldf03String)

     Dim fieldf04String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f04String", .DefaultValue = ""}
     dtDataTable.Columns.Add(fieldf04String)

     Dim fieldf05String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f05String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf05String)

        Dim fieldf06String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f06String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf06String)

        Dim fieldf07String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f07String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf07String)

        Dim fieldf08String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f08String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf08String)

        Dim fieldf09String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f09String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf09String)

        Dim fieldf10String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f10String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf10String)

        Dim fieldf01Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f01Double", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf01Double)

     Dim fieldf02Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f02Double", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf02Double)

     Dim fieldf03Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f03Double", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf03Double)

     Dim fieldf04Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f04Double", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf04Double)

     Dim fieldf05Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f05Double", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf05Double)

     Dim fieldf01Double163 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f01Double163", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf01Double163)

     Dim fieldf02Double163 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f02Double163", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf02Double163)

     Dim fieldf03Double163 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f03Double163", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf03Double163)

     Dim fieldf01Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f01Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf01Double160)

     Dim fieldf02Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f02Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf02Double160)

     Dim fieldf03Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f03Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf03Double160)

     Dim fieldf04Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f04Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf04Double160)

     Dim fieldf05Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f05Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf05Double160)

     Dim fieldf06Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f06Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf06Double160)

     Dim fieldf07Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f07Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf07Double160)

     Dim fieldf08Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f08Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf08Double160)

     Dim fieldf09Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f09Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf09Double160)

     Dim fieldf10Double160 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f10Double160", .DefaultValue = 0}
     dtDataTable.Columns.Add(fieldf10Double160)

     Dim fieldf01Datetime As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f01Datetime", .DefaultValue = "3000-01-01"}
     dtDataTable.Columns.Add(fieldf01Datetime)

     Dim fieldf01IDUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01IDUser", .DefaultValue = ""}
     dtDataTable.Columns.Add(fieldf01IDUser)

     Dim fieldf01NamaUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01NamaUser", .DefaultValue = ""}
     dtDataTable.Columns.Add(fieldf01NamaUser)

     Return dtDataTable
End Function

Public Sub dtInitTEMPLATEDOUBLE()
     prop_dtTEMPLATEDOUBLE = Nothing
     prop_dtTEMPLATEDOUBLE = dtCreateTEMPLATEDOUBLE()
     prop_dtTEMPLATEDOUBLE.Clear()
End Sub

    Public Sub dtAddNewTEMPLATEDOUBLE(
           ByVal prmk01String As String, ByVal prmk02String As String, ByVal prmk03String As String,
           ByVal prmk04String As String, ByVal prmk05String As String,
           ByVal prmf01String As String, ByVal prmf02String As String, ByVal prmf03String As String,
           ByVal prmf04String As String, ByVal prmf05String As String, ByVal prmf06String As String,
           ByVal prmf07String As String, ByVal prmf08String As String, ByVal prmf09String As String, ByVal prmf10String As String,
           ByVal prmf01Double As Double, ByVal prmf02Double As Double, ByVal prmf03Double As Double,
           ByVal prmf04Double As Double, ByVal prmf05Double As Double,
           ByVal prmf01Double163 As Double, ByVal prmf02Double163 As Double, ByVal prmf03Double163 As Double,
           ByVal prmf01Double160 As Double, ByVal prmf02Double160 As Double, ByVal prmf03Double160 As Double,
           ByVal prmf04Double160 As Double, ByVal prmf05Double160 As Double, ByVal prmf06Double160 As Double,
           ByVal prmf07Double160 As Double, ByVal prmf08Double160 As Double, ByVal prmf09Double160 As Double, ByVal prmf10Double160 As Double,
           ByVal prmf01Datetime As Date, ByVal prmf01IDUser As String, ByVal prmf01NamaUser As String)

        Dim oDataRow As DataRow = prop_dtTEMPLATEDOUBLE.NewRow()

        oDataRow("k01String") = prmk01String
        oDataRow("k02String") = prmk02String
        oDataRow("k03String") = prmk03String
        oDataRow("k04String") = prmk04String
        oDataRow("k05String") = prmk05String
        oDataRow("f01String") = prmf01String
        oDataRow("f02String") = prmf02String
        oDataRow("f03String") = prmf03String
        oDataRow("f04String") = prmf04String
        oDataRow("f05String") = prmf05String
        oDataRow("f06String") = prmf06String
        oDataRow("f07String") = prmf07String
        oDataRow("f08String") = prmf08String
        oDataRow("f09String") = prmf09String
        oDataRow("f10String") = prmf10String
        oDataRow("f01Double") = prmf01Double
        oDataRow("f02Double") = prmf02Double
        oDataRow("f03Double") = prmf03Double
        oDataRow("f04Double") = prmf04Double
        oDataRow("f05Double") = prmf05Double
        oDataRow("f01Double163") = prmf01Double163
        oDataRow("f02Double163") = prmf02Double163
        oDataRow("f03Double163") = prmf03Double163
        oDataRow("f01Double160") = prmf01Double160
        oDataRow("f02Double160") = prmf02Double160
        oDataRow("f03Double160") = prmf03Double160
        oDataRow("f04Double160") = prmf04Double160
        oDataRow("f05Double160") = prmf05Double160
        oDataRow("f06Double160") = prmf06Double160
        oDataRow("f07Double160") = prmf07Double160
        oDataRow("f08Double160") = prmf08Double160
        oDataRow("f09Double160") = prmf09Double160
        oDataRow("f10Double160") = prmf10Double160
        oDataRow("f01Datetime") = prmf01Datetime
        oDataRow("f01IDUser") = prmf01IDUser
        oDataRow("f01NamaUser") = prmf01NamaUser

        prop_dtTEMPLATEDOUBLE.Rows.Add(oDataRow)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class

'********** end of .NET Controller : clsTEMPLATEDOUBLE.vb ****************
