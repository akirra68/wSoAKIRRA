Public Class clsWSNasaTemplateTableMaster
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

    Public Property prop_dtMASTER As DataTable

    Private Function dtCreateMASTER() As DataTable
        Dim dtDataTable As New DataTable

        Dim fieldk10String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k10String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk10String)

        Dim fieldk11String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k11String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk11String)

        Dim fieldk12String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k12String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk12String)

        Dim fieldk13String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k13String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk13String)

        Dim fieldk14String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k14String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk14String)

        Dim fieldk15String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k15String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk15String)

        Dim fieldf10String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f10String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf10String)

        Dim fieldf11String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f11String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf11String)

        Dim fieldf12String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f12String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf12String)

        Dim fieldf10TinyInt As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f10TinyInt", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf10TinyInt)

        Dim fieldf10SmallInt As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f10SmallInt", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf10SmallInt)

        Dim fieldf10Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f10Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf10Int)

        Dim fieldf11Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f11Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf11Int)

        Dim fieldf10SmallDouble As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f10SmallDouble", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf10SmallDouble)

        Dim fieldf10Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f10Double", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf10Double)

        Dim fieldf10Double16 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f10Double16", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf10Double16)

        Dim fieldf10Datetime As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f10Datetime", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf10Datetime)

        Dim fieldf11Datetime As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f11Datetime", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf11Datetime)

        Dim fieldf10IDUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f10IDUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf10IDUser)

        Dim fieldf11IDUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f11IDUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf11IDUser)

        Dim fieldf10NamaUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f10NamaUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf10NamaUser)

        Dim fieldf11NamaUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f11NamaUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf11NamaUser)

        Return dtDataTable
    End Function

    Public Sub dtInitMASTER()
        prop_dtMASTER = Nothing
        prop_dtMASTER = dtCreateMASTER()
        prop_dtMASTER.Clear()
    End Sub

    Public Sub dtAddNewMASTER(ByVal prmk10String As String, ByVal prmk11String As String,
                             ByVal prmk12String As String, ByVal prmk13String As String,
                             ByVal prmk14String As String, ByVal prmk15String As String,
                             ByVal prmf10String As String, ByVal prmf11String As String,
                             ByVal prmf12String As String, ByVal prmf10TinyInt As Integer,
                             ByVal prmf10SmallInt As Integer, ByVal prmf10Int As Integer,
                             ByVal prmf11Int As Integer, ByVal prmf10SmallDouble As Double,
                             ByVal prmf10Double As Double, ByVal prmf10Double16 As Double,
                             ByVal prmf10Datetime As DateTime, ByVal prmf11Datetime As DateTime,
                             ByVal prmf10IDUser As String, ByVal prmf11IDUser As String,
                             ByVal prmf10NamaUser As String, ByVal prmf11NamaUser As String)

        Dim oDataRow As DataRow = prop_dtMASTER.NewRow()

        oDataRow("k10String") = prmk10String
        oDataRow("k11String") = prmk11String
        oDataRow("k12String") = prmk12String
        oDataRow("k13String") = prmk13String
        oDataRow("k14String") = prmk14String
        oDataRow("k15String") = prmk15String
        oDataRow("f10String") = prmf10String
        oDataRow("f11String") = prmf11String
        oDataRow("f12String") = prmf12String
        oDataRow("f10TinyInt") = prmf10TinyInt
        oDataRow("f10SmallInt") = prmf10SmallInt
        oDataRow("f10Int") = prmf10Int
        oDataRow("f11Int") = prmf11Int
        oDataRow("f10SmallDouble") = prmf10SmallDouble
        oDataRow("f10Double") = prmf10Double
        oDataRow("f10Double16") = prmf10Double16
        oDataRow("f10Datetime") = prmf10Datetime
        oDataRow("f11Datetime") = prmf11Datetime
        oDataRow("f10IDUser") = prmf10IDUser
        oDataRow("f11IDUser") = prmf11IDUser
        oDataRow("f10NamaUser") = prmf10NamaUser
        oDataRow("f11NamaUser") = prmf11NamaUser

        prop_dtMASTER.Rows.Add(oDataRow)
    End Sub

End Class
