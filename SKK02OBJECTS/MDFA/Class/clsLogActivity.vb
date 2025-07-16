Imports SKK01CORE
Imports SKK01CORE.clsNasaHelper

Public Class clsLogActivity
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

    Private objHelper As clsNasaHelper

#Region "form - event"
    Public Sub New()
        objHelper = New clsNasaHelper()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objHelper.Dispose()
    End Sub

#End Region

#Region "Sync : custom method - public"
    Public Function _pb01LogActivity(ByVal prmnTargetServer012 As Int16,
                                     ByVal prmcNIK As String,
                                     ByVal prmcCompName As String,
                                     ByVal prmcIPAddress As String,
                                     ByVal prmcGroupLOG As String,
                                     ByVal prmcLog As String) As Integer

        Dim pcSQL As String = ""
        pcSQL = " insert into TABLE01 (k02String,k03String,k04String,k05String,f01Log) " &
                                 " values ('" & prmcNIK & "','" &
                                                prmcCompName & "','" &
                                                prmcIPAddress & "','" &
                                                prmcGroupLOG & "','" &
                                                prmcLog.Trim & "')"

        objHelper._prop10SQLCommand = pcSQL

        Dim pnHasil As Integer = 0
        pnHasil = objHelper._pb01NasaExecSQLDirect(prmnTargetServer012, _pnmDatabaseName.LOG, 1)

        Return pnHasil
    End Function

#End Region

End Class
