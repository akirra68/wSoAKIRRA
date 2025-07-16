Public Class clsTEMPLATEGEMINIFINANCE
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

    Public Property prop_dtTABLEGEMINIFINANCE As DataTable

    Private Function dtCreateTABLEGEMINIFINANCE() As DataTable
        Dim dtDataTable As New DataTable

        Dim fieldk01String As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "k01String", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldk01String)

        Dim fieldk02Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "k02Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldk02Int)

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

        Dim fieldf01Memo As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01Memo", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf01Memo)

        Dim fieldf02Memo As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Byte[]"), .ColumnName = "f02Memo", .DefaultValue = Nothing}
        dtDataTable.Columns.Add(fieldf02Memo)

        Dim fieldf01Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f01Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf01Int)

        Dim fieldf02Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f02Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf02Int)

        Dim fieldf03Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f03Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf03Int)

        Dim fieldf04Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f04Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf04Int)

        Dim fieldf05Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f05Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf05Int)

        Dim fieldf06Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f06Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf06Int)

        Dim fieldf07Int As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Int32"), .ColumnName = "f07Int", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf07Int)

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

        Dim fieldf06Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f06Double", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf06Double)

        Dim fieldf07Double As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f07Double", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf07Double)

        Dim fieldf01Double16 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f01Double16", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf01Double16)

        Dim fieldf02Double16 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f02Double16", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf02Double16)

        Dim fieldf03Double16 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f03Double16", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf03Double16)

        Dim fieldf04Double16 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f04Double16", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf04Double16)

        Dim fieldf05Double16 As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.Double"), .ColumnName = "f05Double16", .DefaultValue = 0}
        dtDataTable.Columns.Add(fieldf05Double16)

        Dim fieldf01Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f01Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf01Date)

        Dim fieldf02Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f02Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf02Date)

        Dim fieldf03Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f03Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf03Date)

        Dim fieldf04Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f04Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf04Date)

        Dim fieldf05Date As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f05Date", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf05Date)

        Dim fieldf01Datetime As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f01Datetime", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf01Datetime)

        Dim fieldf02Datetime As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.DateTime"), .ColumnName = "f02Datetime", .DefaultValue = "3000-01-01"}
        dtDataTable.Columns.Add(fieldf02Datetime)

        Dim fieldf01IDUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01IDUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf01IDUser)

        Dim fieldf02IDUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f02IDUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf02IDUser)

        Dim fieldf01NamaUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f01NamaUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf01NamaUser)

        Dim fieldf02NamaUser As DataColumn = New DataColumn() With {.DataType = Type.GetType("System.String"), .ColumnName = "f02NamaUser", .DefaultValue = ""}
        dtDataTable.Columns.Add(fieldf02NamaUser)

        Return dtDataTable
    End Function

    Public Sub dtInitTABLEGEMINIFINANCE()
        prop_dtTABLEGEMINIFINANCE = Nothing
        prop_dtTABLEGEMINIFINANCE = dtCreateTABLEGEMINIFINANCE()
        prop_dtTABLEGEMINIFINANCE.Clear()
    End Sub

    'ByVal prmf02Memo As Byte(),
    Public Sub dtAddNewTABLEGEMINIFINANCE(ByVal prmk01String As String, ByVal prmk02Int As Integer, ByVal prmk03String As String, ByVal prmk04String As String, ByVal prmk05String As String,
                                   ByVal prmf01String As String, ByVal prmf02String As String, ByVal prmf03String As String, ByVal prmf04String As String, ByVal prmf05String As String,
                                   ByVal prmf06String As String, ByVal prmf07String As String, ByVal prmf08String As String, ByVal prmf09String As String, ByVal prmf10String As String,
                                   ByVal prmf11String As String, ByVal prmf12String As String, ByVal prmf13String As String, ByVal prmf14String As String, ByVal prmf15String As String,
                                   ByVal prmf16String As String, ByVal prmf17String As String, ByVal prmf18String As String, ByVal prmf19String As String, ByVal prmf20String As String,
                                   ByVal prmf21String As String, ByVal prmf22String As String, ByVal prmf23String As String, ByVal prmf24String As String, ByVal prmf25String As String,
                                   ByVal prmf26String As String, ByVal prmf27String As String, ByVal prmf28String As String, ByVal prmf29String As String, ByVal prmf30String As String,
                                   ByVal prmf01Memo As String,
                                   ByVal prmf01Int As Integer, ByVal prmf02Int As Integer, ByVal prmf03Int As Integer, ByVal prmf04Int As Integer, ByVal prmf05Int As Integer, ByVal prmf06Int As Integer, ByVal prmf07Int As Integer,
                                   ByVal prmf01Double As Double, ByVal prmf02Double As Double, ByVal prmf03Double As Double, ByVal prmf04Double As Double, ByVal prmf05Double As Double, ByVal prmf06Double As Double, ByVal prmf07Double As Double,
                                   ByVal prmf01Double16 As Double, ByVal prmf02Double16 As Double, ByVal prmf03Double16 As Double, ByVal prmf04Double16 As Double, ByVal prmf05Double16 As Double,
                                   ByVal prmf01Date As Date, ByVal prmf02Date As Date, ByVal prmf03Date As Date, ByVal prmf04Date As Date, ByVal prmf05Date As Date,
                                   ByVal prmf01Datetime As Date, ByVal prmf02Datetime As Date, ByVal prmf01IDUser As String, ByVal prmf02IDUser As String, ByVal prmf01NamaUser As String, ByVal prmf02NamaUser As String)

        Dim oDataRow As DataRow = prop_dtTABLEGEMINIFINANCE.NewRow()

        oDataRow("k01String") = prmk01String
        oDataRow("k02Int") = prmk02Int
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
        oDataRow("f01Memo") = prmf01Memo
        'oDataRow("f02Memo") = prmf02Memo
        oDataRow("f01Int") = prmf01Int
        oDataRow("f02Int") = prmf02Int
        oDataRow("f03Int") = prmf03Int
        oDataRow("f04Int") = prmf04Int
        oDataRow("f05Int") = prmf05Int
        oDataRow("f06Int") = prmf06Int
        oDataRow("f07Int") = prmf07Int
        oDataRow("f01Double") = prmf01Double
        oDataRow("f02Double") = prmf02Double
        oDataRow("f03Double") = prmf03Double
        oDataRow("f04Double") = prmf04Double
        oDataRow("f05Double") = prmf05Double
        oDataRow("f06Double") = prmf06Double
        oDataRow("f07Double") = prmf07Double
        oDataRow("f01Double16") = prmf01Double16
        oDataRow("f02Double16") = prmf02Double16
        oDataRow("f03Double16") = prmf03Double16
        oDataRow("f04Double16") = prmf04Double16
        oDataRow("f05Double16") = prmf05Double16
        oDataRow("f01Date") = prmf01Date
        oDataRow("f02Date") = prmf02Date
        oDataRow("f03Date") = prmf03Date
        oDataRow("f04Date") = prmf04Date
        oDataRow("f05Date") = prmf05Date
        oDataRow("f01Datetime") = prmf01Datetime
        oDataRow("f02Datetime") = prmf02Datetime
        oDataRow("f01IDUser") = prmf01IDUser
        oDataRow("f02IDUser") = prmf02IDUser
        oDataRow("f01NamaUser") = prmf01NamaUser
        oDataRow("f02NamaUser") = prmf02NamaUser

        prop_dtTABLEGEMINIFINANCE.Rows.Add(oDataRow)
    End Sub

End Class
