Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository

Public Class repoWS06RadioGroup
    Inherits RepositoryItemRadioGroup
    Implements IDisposable

#Region "dispose"
    Private disposedValue As Boolean

    Protected Overrides Sub Dispose(disposing As Boolean)
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

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private _ItemApprove As RadioGroupItem
    Private _ItemReject As RadioGroupItem
    Private _ItemPendingFA As RadioGroupItem

    Public Sub New(Optional isFA As String = "NO")
        _ItemApprove = New RadioGroupItem With {.Value = 1, .Description = "Approve"}
        _ItemReject = New RadioGroupItem With {.Value = 2, .Description = "Reject"}
        _ItemPendingFA = New RadioGroupItem With {.Value = 3, .Description = "Pending"}

        If isFA = "YES" Then
            With Me
                .Columns = 3
                .Items.Add(_ItemApprove)
                .Items.Add(_ItemReject)
                .Items.Add(_ItemPendingFA)
                .ItemHorzAlignment = DevExpress.XtraEditors.RadioItemHorzAlignment.Near
            End With
        Else
            With Me
                .Columns = 2
                .Items.Add(_ItemApprove)
                .Items.Add(_ItemReject)
                .ItemHorzAlignment = DevExpress.XtraEditors.RadioItemHorzAlignment.Near
            End With
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
    End Sub

End Class
