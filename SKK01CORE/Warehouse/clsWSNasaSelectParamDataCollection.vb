Imports System.Data
Imports Microsoft.Data.SqlClient.Server

Public Class clsWSNasaSelectParamDataCollection
    Inherits List(Of clsWSNasaSelectParamData)
    Implements IEnumerable(Of SqlDataRecord)
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

    Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator(Of SqlDataRecord) Implements IEnumerable(Of SqlDataRecord).GetEnumerator

        Dim ret As New SqlDataRecord(New SqlMetaData("f01nTargetSPParent_int", SqlDbType.Int),
                                     New SqlMetaData("f02nTargetSPChild_int", SqlDbType.Int),
                                     New SqlMetaData("f03nTargetExec_int", SqlDbType.Int),
                                     New SqlMetaData("f01cParamString", SqlDbType.VarChar, 50),
                                     New SqlMetaData("f02cParamString", SqlDbType.VarChar, 50),
                                     New SqlMetaData("f03cParamString", SqlDbType.VarChar, 50),
                                     New SqlMetaData("f01nParamNumerik", SqlDbType.Decimal),
                                     New SqlMetaData("f02nParamNumerik", SqlDbType.Decimal),
                                     New SqlMetaData("f01dParamDate", SqlDbType.Date),
                                     New SqlMetaData("f02dParamDate", SqlDbType.Date))

        For Each data As clsWSNasaSelectParamData In Me
            ret.SetInt32(0, data.f01nTargetSPParent_int)
            ret.SetInt32(1, data.f02nTargetSPChild_int)
            ret.SetInt32(2, data.f03nTargetExec_int)
            ret.SetString(3, data.f01cParamString)
            ret.SetString(4, data.f02cParamString)
            ret.SetString(5, data.f03cParamString)
            ret.SetDecimal(6, data.f01nParamNumerik)
            ret.SetDecimal(7, data.f02nParamNumerik)
            ret.SetDateTime(8, data.f01dParamDate)
            ret.SetDateTime(9, data.f02dParamDate)
            Yield ret
        Next
    End Function

    Public Sub _pb01AddNew(ByVal prmf01nTargetSPParent_int As Int16, ByVal prmf02nTargetSPChild_int As Int16, ByVal prmf03nTargetExec_int As Int16,
                      ByVal prmf01cParamString As String, ByVal prmf02cParamString As String, ByVal prmf03cParamString As String,
                      ByVal prmf01nParamNumerik As Double, ByVal prmf02nParamNumerik As Double,
                      ByVal prmf01dParamDate As Date, ByVal prmf02dParamDate As Date)

        Me.Add(New clsWSNasaSelectParamData With {
                .f01nTargetSPParent_int = prmf01nTargetSPParent_int, .f02nTargetSPChild_int = prmf02nTargetSPChild_int, .f03nTargetExec_int = prmf03nTargetExec_int,
                .f01cParamString = prmf01cParamString, .f02cParamString = prmf02cParamString, .f03cParamString = prmf03cParamString,
                .f01nParamNumerik = prmf01nParamNumerik, .f02nParamNumerik = prmf02nParamNumerik,
                .f01dParamDate = prmf01dParamDate, .f02dParamDate = prmf02dParamDate})
    End Sub

End Class
