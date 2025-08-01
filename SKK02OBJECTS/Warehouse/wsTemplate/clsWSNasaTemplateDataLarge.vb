'********** create .NET Controller : clsControllersTABLELARGE.vb ****************

Public Class clsWSNasaTemplateDataLarge
    Implements IDisposable

    Public Property prop_dtsTABLELARGE As DataTable

    Private Function dtCreatesTABLELARGE() As DataTable
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

        Dim fieldf11String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f11String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf11String)

        Dim fieldf12String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f12String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf12String)

        Dim fieldf13String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f13String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf13String)

        Dim fieldf14String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f14String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf14String)

        Dim fieldf15String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f15String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf15String)

        Dim fieldf16String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f16String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf16String)

        Dim fieldf17String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f17String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf17String)

        Dim fieldf18String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f18String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf18String)

        Dim fieldf19String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f19String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf19String)

        Dim fieldf20String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f20String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf20String)

        Dim fieldf21String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f21String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf21String)

        Dim fieldf22String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f22String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf22String)

        Dim fieldf23String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f23String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf23String)

        Dim fieldf24String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f24String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf24String)

        Dim fieldf25String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f25String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf25String)

        Dim fieldf26String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f26String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf26String)

        Dim fieldf27String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f27String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf27String)

        Dim fieldf28String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f28String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf28String)

        Dim fieldf29String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f29String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf29String)

        Dim fieldf30String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f30String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf30String)

        Dim fieldf31String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f31String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf31String)

        Dim fieldf32String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f32String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf32String)

        Dim fieldf33String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f33String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf33String)

        Dim fieldf34String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f34String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf34String)

        Dim fieldf35String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f35String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf35String)

        Dim fieldf36String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f36String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf36String)

        Dim fieldf37String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f37String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf37String)

        Dim fieldf38String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f38String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf38String)

        Dim fieldf39String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f39String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf39String)

        Dim fieldf40String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f40String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf40String)

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

    Public Sub dtInitsTABLELARGE()
        prop_dtsTABLELARGE = Nothing
        prop_dtsTABLELARGE = dtCreatesTABLELARGE()
        prop_dtsTABLELARGE.Clear()
    End Sub

    Public Sub dtAddNewsTABLELARGE(
           ByVal prmk01String As String, ByVal prmk02String As String, ByVal prmk03String As String,
           ByVal prmf01String As String, ByVal prmf02String As String, ByVal prmf03String As String,
           ByVal prmf04String As String, ByVal prmf05String As String, ByVal prmf06String As String,
           ByVal prmf07String As String, ByVal prmf08String As String, ByVal prmf09String As String,
           ByVal prmf10String As String, ByVal prmf11String As String, ByVal prmf12String As String,
           ByVal prmf13String As String, ByVal prmf14String As String, ByVal prmf15String As String,
           ByVal prmf16String As String, ByVal prmf17String As String, ByVal prmf18String As String,
           ByVal prmf19String As String, ByVal prmf20String As String, ByVal prmf21String As String,
           ByVal prmf22String As String, ByVal prmf23String As String, ByVal prmf24String As String,
           ByVal prmf25String As String, ByVal prmf26String As String, ByVal prmf27String As String,
           ByVal prmf28String As String, ByVal prmf29String As String, ByVal prmf30String As String,
           ByVal prmf31String As String, ByVal prmf32String As String, ByVal prmf33String As String,
           ByVal prmf34String As String, ByVal prmf35String As String, ByVal prmf36String As String,
           ByVal prmf37String As String, ByVal prmf38String As String, ByVal prmf39String As String,
           ByVal prmf40String As String, ByVal prmf01TinyInt As Integer, ByVal prmf01SmallInt As Integer,
           ByVal prmf01Int As Integer, ByVal prmf01Double As Double, ByVal prmf02Double As Double,
           ByVal prmf03Double As Double, ByVal prmf01Date As Date, ByVal prmf02Date As Date,
           ByVal prmf01Datetime As Date, ByVal prmf01IDUser As String, ByVal prmf01NamaUser As String,
           ByVal prmf01ComputerName As String, ByVal prmf02ComputerIPPrivate As String, ByVal prmf03ComputerIPPublic As String)

        Dim oDataRow As DataRow = prop_dtsTABLELARGE.NewRow()

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
        oDataRow("f11String") = prmf11String
        oDataRow("f12String") = prmf12String
        oDataRow("f13String") = prmf13String
        oDataRow("f14String") = prmf14String
        oDataRow("f15String") = prmf15String
        oDataRow("f16String") = prmf16String
        oDataRow("f17String") = prmf17String
        oDataRow("f18String") = prmf18String
        oDataRow("f19String") = prmf19String
        oDataRow("f20String") = prmf20String
        oDataRow("f21String") = prmf21String
        oDataRow("f22String") = prmf22String
        oDataRow("f23String") = prmf23String
        oDataRow("f24String") = prmf24String
        oDataRow("f25String") = prmf25String
        oDataRow("f26String") = prmf26String
        oDataRow("f27String") = prmf27String
        oDataRow("f28String") = prmf28String
        oDataRow("f29String") = prmf29String
        oDataRow("f30String") = prmf30String
        oDataRow("f31String") = prmf31String
        oDataRow("f32String") = prmf32String
        oDataRow("f33String") = prmf33String
        oDataRow("f34String") = prmf34String
        oDataRow("f35String") = prmf35String
        oDataRow("f36String") = prmf36String
        oDataRow("f37String") = prmf37String
        oDataRow("f38String") = prmf38String
        oDataRow("f39String") = prmf39String
        oDataRow("f40String") = prmf40String
        oDataRow("f01TinyInt") = prmf01TinyInt
        oDataRow("f01SmallInt") = prmf01SmallInt
        oDataRow("f01Int") = prmf01Int
        oDataRow("f01Double") = prmf01Double
        oDataRow("f02Double") = prmf02Double
        oDataRow("f03Double") = prmf03Double
        oDataRow("f01Date") = prmf01Date
        oDataRow("f02Date") = prmf02Date
        oDataRow("f01Datetime") = prmf01Datetime
        oDataRow("f01IDUser") = prmf01IDUser
        oDataRow("f01NamaUser") = prmf01NamaUser
        oDataRow("f01ComputerName") = prmf01ComputerName
        oDataRow("f02ComputerIPPrivate") = prmf02ComputerIPPrivate
        oDataRow("f03ComputerIPPublic") = prmf03ComputerIPPublic

        prop_dtsTABLELARGE.Rows.Add(oDataRow)
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

'********** end of .NET Controller : clsControllersTABLELARGE.vb ****************
