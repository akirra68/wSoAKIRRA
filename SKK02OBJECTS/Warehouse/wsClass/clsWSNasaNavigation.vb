Imports DevExpress.Images
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors

Public Class clsWSNasaNavigation
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

    Property _prop01User As String
    Property _prop02XtraUserControl As XtraUserControl

    Private OfficeNavigationBar1 As OfficeNavigationBar
    Private NavigationBarItem1 As NavigationBarItem

#Region "form - event"
    Public Sub New()
        OfficeNavigationBar1 = New OfficeNavigationBar()
        OfficeNavigationBar1.ShowPeekFormOnItemHover = True
        AddHandler OfficeNavigationBar1.QueryPeekFormContent, AddressOf OfficeNavigationBar1_QueryPeekFormContent

        NavigationBarItem1 = New NavigationBarItem()
        NavigationBarItem1.Name = "NavigationBarItem1"
        _cm01SetControlImage(NavigationBarItem1, "datalabels.svg")

        OfficeNavigationBar1.Items.AddRange(New NavigationBarItem() {NavigationBarItem1})

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        OfficeNavigationBar1.Dispose()
        NavigationBarItem1.Dispose()
        Me.Dispose()
    End Sub
#End Region

#Region "custom - method"
    Const DX_NAME_PREFIX As String = "DX:"
    Const FILE_NAME_PREFIX As String = "FILE:"
    Const RESOURCES_NAME_PREFIX As String = "RESOURCES:"

    Private Sub _cm01SetControlImage(ByVal target As NavigationBarItem, ByVal ImageName As String)
        Dim imageOptions = New DevExpress.Utils.ImageOptions()

        If ImageName.StartsWith(DX_NAME_PREFIX) Then
            If ImageName.EndsWith(".svg") Then imageOptions.SvgImage = ImageResourceCache.[Default].GetSvgImage(ImageName.Substring(DX_NAME_PREFIX.Length))

            If ImageName.EndsWith(".png") Then
                imageOptions.Image = ImageResourceCache.[Default].GetImage(ImageName.Substring(DX_NAME_PREFIX.Length))
            End If
        End If

        target.ImageOptions.Image = imageOptions.Image
    End Sub

    Private Sub _cm02SettingNavigation()

    End Sub
#End Region

#Region "control - event"
    Private Sub OfficeNavigationBar1_QueryPeekFormContent(sender As Object, e As QueryPeekFormContentEventArgs)
        If e.Item.Name = NavigationBarItem1.Name Then
            e.Control = _prop02XtraUserControl()
        End If
    End Sub

#End Region

End Class
