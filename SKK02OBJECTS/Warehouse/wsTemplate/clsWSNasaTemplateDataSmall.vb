'********** create .NET Controller : clsControllersTABLESMALL.vb ****************

Public Class clsWSNasaTemplateDataSmall
    Implements IDisposable

    Public Property prop_dtsTABLESMALL As DataTable

    Private Function dtCreatesTABLESMALL() As DataTable
        Dim dtDataTable As New DataTable

        Dim fieldk01String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k01String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk01String)

        Dim fieldk02String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k02String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk02String)

        Dim fieldk03String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k03String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk03String)

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

        Dim fieldf01TinyInt As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f01TinyInt", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf01TinyInt)

        Dim fieldf01SmallInt As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f01SmallInt", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf01SmallInt)

        Dim fieldf01Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f01Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf01Int)

        Dim fieldf01Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f01Double", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf01Double)

        Dim fieldf02Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f02Double", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf02Double)

        Dim fieldf03Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f03Double", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf03Double)

        Dim fieldf01Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f01Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf01Date)

        Dim fieldf02Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f02Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf02Date)

        Dim fieldf03Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f03Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf03Date)

        Dim fieldf01Datetime As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f01Datetime", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf01Datetime)

        Dim fieldf01IDUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01IDUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf01IDUser)

        Dim fieldf01NamaUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01NamaUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf01NamaUser)

        Dim fieldf01ComputerName As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01ComputerName", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf01ComputerName)

        Dim fieldf02ComputerIPPrivate As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f02ComputerIPPrivate", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf02ComputerIPPrivate)

        Dim fieldf03ComputerIPPublic As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f03ComputerIPPublic", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf03ComputerIPPublic)

        Return dtDataTable
    End Function

    Public Sub dtInitsTABLESMALL()
        prop_dtsTABLESMALL = Nothing
        prop_dtsTABLESMALL = dtCreatesTABLESMALL()
        prop_dtsTABLESMALL.Clear()
    End Sub

    Public Sub dtAddNewsTABLESMALL(
                                  ByVal prmk01String As String, ByVal prmk02String As String, ByVal prmk03String As String,
                                  ByVal prmf01String As String, ByVal prmf02String As String, ByVal prmf03String As String,
                                  ByVal prmf04String As String, ByVal prmf05String As String, ByVal prmf06String As String,
                                  ByVal prmf07String As String, ByVal prmf08String As String, ByVal prmf09String As String,
                                  ByVal prmf10String As String,
                                  ByVal prmf01TinyInt As Integer, ByVal prmf01SmallInt As Integer, ByVal prmf01Int As Integer,
                                  ByVal prmf01Double As Double, ByVal prmf02Double As Double, ByVal prmf03Double As Double,
                                  ByVal prmf01Date As Date, ByVal prmf02Date As Date, ByVal prmf03Date As Date,
                                  ByVal prmf01Datetime As Date, ByVal prmf01IDUser As String, ByVal prmf01NamaUser As String,
                                  ByVal prmf01ComputerName As String, ByVal prmf02ComputerIPPrivate As String, ByVal prmf03ComputerIPPublic As String)

        Dim oDataRow As DataRow = prop_dtsTABLESMALL.NewRow()

        oDataRow("k01String") = prmk01String
        oDataRow("k02String") = prmk02String
        oDataRow("k03String") = prmk03String
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
        oDataRow("f01TinyInt") = prmf01TinyInt
        oDataRow("f01SmallInt") = prmf01SmallInt
        oDataRow("f01Int") = prmf01Int
        oDataRow("f01Double") = prmf01Double
        oDataRow("f02Double") = prmf02Double
        oDataRow("f03Double") = prmf03Double
        oDataRow("f01Date") = prmf01Date
        oDataRow("f02Date") = prmf02Date
        oDataRow("f03Date") = prmf03Date
        oDataRow("f01Datetime") = prmf01Datetime
        oDataRow("f01IDUser") = prmf01IDUser
        oDataRow("f01NamaUser") = prmf01NamaUser
        oDataRow("f01ComputerName") = prmf01ComputerName
        oDataRow("f02ComputerIPPrivate") = prmf02ComputerIPPrivate
        oDataRow("f03ComputerIPPublic") = prmf03ComputerIPPublic

        prop_dtsTABLESMALL.Rows.Add(oDataRow)
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

'********** end of .NET Controller : clsControllersTABLESMALL.vb ****************
