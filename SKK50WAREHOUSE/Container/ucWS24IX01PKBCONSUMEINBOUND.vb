Imports SKK02OBJECTS
Imports SKK02OBJECTS.ucWSGrid

Public Class ucWS24IX01PKBCONSUMEINBOUND
    Implements IDisposable

    Property _prop01User As clsWSNasaUser
    Property _prop02DataPKB As DataTable
    Property _prop03Grid As ucWSGrid

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ucWS24IX01PKBCONSUMEINBOUND_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        _cm01InitGrid()
    End Sub

#End Region

#Region "custom - method"
    Private Sub _cm01InitGrid()

        With _gdInboundConsumePKB
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSPKBConsumeInbound3034
            ._prop03pdtDataSourceGrid = _prop02DataPKB
        End With
        _gdInboundConsumePKB.__pbWSGrid01InitGrid()
        _gdInboundConsumePKB.__pbWSGrid03DisplayGrid()

    End Sub

    Private Sub _cm02ProsesReservedPKB()
        Dim objReservedPKB As __dlgSetUpdateField = AddressOf _prop03Grid._ivkUpdateReservedPKB
        For Each dtRow As DataRow In _gdInboundConsumePKB._prop03pdtDataSourceGrid.Rows
            If dtRow("k00Boolean") Then
                objReservedPKB.Invoke(dtRow("k03String"), dtRow("f01Int"))
            End If
        Next
    End Sub

#End Region

#Region "control - event"

    Private Sub mnubar01Save_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnubar01Save.ItemClick
        '_gdInboundConsumePKB.__pbWSGrid04CreateSettingColumnWidth("ucWS24IX01PKBCONSUMEINBOUND")
        'MsgBox("Done ...")

        _cm02ProsesReservedPKB()
    End Sub

#End Region

End Class
