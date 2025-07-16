Imports DevExpress.XtraEditors

Public Class ctrlWSNasaSpinEdit
    Inherits SpinEdit
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

    Public Sub _pb01SettingDisplay(ByVal prmnAngkaDecimal As Int16, Optional ByVal prmlReadOnly As Boolean = False)
        Font = New Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        Me.ReadOnly = prmlReadOnly

        With Properties
            With .AppearanceReadOnly
                .ForeColor = Color.White
                .BackColor = Color.Green
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
            With .Properties.DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = pcFormat
            End With
        End With
    End Sub

    Public Delegate Function _dlgGetData() As Integer
    Public Delegate Sub _dlgSetData(ByVal prmnValue As Integer)

    Public Function __GetDataIvk() As Integer
        Return Me.EditValue
    End Function

    Public Sub __SetDataIvk(ByVal prmnValue As Integer)
        Me.EditValue = 0
        Me.EditValue = prmnValue
        Me.Refresh()
    End Sub


End Class
