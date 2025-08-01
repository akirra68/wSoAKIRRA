Imports System.Xml
Imports DevExpress.XtraEditors

Public Class ctrlWSNasaTextEdit
    Inherits TextEdit
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

    Public Sub _pb01SettingDisplay(Optional ByVal prmlReadOnly As Boolean = False)
        Font = New Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        Me.ReadOnly = prmlReadOnly

        With Properties
            With .AppearanceReadOnly
                .ForeColor = Color.White
                .BackColor = Color.Green
            End With
        End With

    End Sub

    Public Delegate Sub _dlgTextEditInitValue()
    Public Sub _ivkTextEditInisialisasiNilai()
        If Not String.IsNullOrEmpty(Me.EditValue) Then
            Me.EditValue = ""
            Me.Focus()
        End If
    End Sub

End Class
