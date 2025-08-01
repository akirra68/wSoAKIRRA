Imports SKK02OBJECTS

Public Class ucWS24JV01CORRECTION
    Implements IDisposable

    Property _prop01User As clsWSNasaUser

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ucWS24JV01CORRECTION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)
    End Sub

#End Region

#Region "custom - method"
#End Region

#Region "control - event"
#End Region
End Class
