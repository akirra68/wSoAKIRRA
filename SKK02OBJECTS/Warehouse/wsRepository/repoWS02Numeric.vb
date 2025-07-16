Imports DevExpress.XtraEditors.Repository

Public Class repoWS02Numeric
    Inherits RepositoryItemSpinEdit
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

    Public Sub _pb01InitRepoNumeric(ByVal prmnAngkaDecimal As Int16)
        With Me
            With .Appearance
                .Font = New Font("Courier New", 8, FontStyle.Bold, GraphicsUnit.Point)
                .ForeColor = Color.Navy
            End With
        End With

        Dim pcFormat As String = "n0"
        Select Case prmnAngkaDecimal
            Case 0
                pcFormat = "n0"
            Case 2
                pcFormat = "n2"
            Case 3
                pcFormat = "n3"
        End Select

        With Me
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = pcFormat
            End With
        End With
    End Sub

End Class
