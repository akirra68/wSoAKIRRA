Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports SKK02OBJECTS

Public Class rptWS23LH01TrackingSKU
    Implements IDisposable

    Public Property _prop01User As clsWSNasaUser

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub rptWS23LH01TrackingSKU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        Bar1.Visible = True
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 10

        '_gdTrackingSKUPKB.__pbWSGridVisibilityCheckSelectAll(False)
        _gdTrackingSKUPKB.__pbWSGridParentChild01InitGrid()

        _cm01InitDataControl()
        _cm00Visibility(False)

    End Sub

#End Region

#Region "custom - method"
    Private Sub _cm00Visibility(ByVal showItems As Boolean)
        If showItems = False Then
            mnu03Datedari.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mnu03DateKe.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mnu02WSSKUTracking.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mnu05Display.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Else
            mnu03Datedari.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnu03DateKe.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnu02WSSKUTracking.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnu05Display.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        End If

    End Sub
    Private Sub _cm01InitDataControl()
        Cursor = Cursors.WaitCursor

        Dim _pdtWSSKUTracking As New DataTable
        Dim _pdtCustomer As New DataTable
        Dim _pdtJenisOrder As New DataTable
        Dim prmcTarget As String

        Dim objNasa As New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
        If mnu01TargetTracking.EditValue = "SKU" Then
            '"WS-SKU"
            _pdtWSSKUTracking = objNasa._pb04GetDataSKU4TrackingSKU()
            prmcTarget = "SKU"
        Else
            If mnu01TargetTracking.EditValue = "ORDER" Then
                '"WS-ORDER"
                _pdtWSSKUTracking = objNasa._pb041GetDataSKU4TrackingPKB()
                prmcTarget = "No.Order"
            End If
        End If

        Using objNasaMaster As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            _pdtCustomer = objNasaMaster.__pb04GetDataTable52Customer()
        End Using

        _pdtJenisOrder = objNasa._pb042GetDataJenisOrder4TrackingPKB

        _colk02StringSKU.FieldName = "k03String"

        ' ===================== CREATED BY AKIRRA - 25/06/03 =====================
        ' mengubah repo agar lebih bagus.
        With rsmnuBar02WSSKU
            .DataSource = Nothing
            .DataSource = _pdtWSSKUTracking
            .ValueMember = "k03String"
            .DisplayMember = "k03String"

            Dim view As GridView = CType(.View, GridView)

            AddHandler view.CustomDrawRowIndicator, AddressOf RepoGridView_CustomDrawRowIndicator

            view.IndicatorWidth = 45

            ' setting grid font 
            Dim customFontHeader As New Font("Nirmala UI", 8, FontStyle.Bold)
            Dim customFontCell As New Font("Courier New", 8, FontStyle.Regular)
            Dim customFontFooter As New Font("Courier New", 8, FontStyle.Bold)

            With view.Appearance
                .Row.Font = customFontCell                ' Baris data
                .HeaderPanel.Font = customFontHeader        ' Header kolom
                .HeaderPanel.ForeColor = Color.Navy        ' Header kolom
                .FooterPanel.Font = customFontFooter        ' footer font
                .FooterPanel.ForeColor = Color.Navy         ' footer font colour
            End With

            ' init column
            With view.Columns
                .Clear()
                .AddVisible("k03String", prmcTarget)
                .AddVisible("f01Datetime", "LastUpdated")
            End With

            ' setting display format
            With view.Columns("f01Datetime")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm"
            End With

            ' summary on footer
            With view
                .OptionsView.ShowFooter = True
                .Columns("k03String").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                .Columns("k03String").SummaryItem.DisplayFormat = "{0:n0} Rows"
            End With

            view.BestFitColumns()
        End With
        ' =======================================================================

        'With rsmnuBar02WSSKU
        '    .ValueMember = "k03String"
        '    .DisplayMember = "k03String"

        '    .DataSource = Nothing
        '    .DataSource = _pdtWSSKUTracking
        'End With

        mnu03DateKe.EditValue = Date.Today
        mnu03Datedari.EditValue = DateAdd(DateInterval.Day, -31, mnu03DateKe.EditValue)

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm02DisplayData()
        _cm01InitDataControl()

        Dim targetGrid As ucWSGridParentChild.__TargetGridParentChild

        Select Case mnu01TargetTracking.EditValue
            Case "ORDER"
                targetGrid = ucWSGridParentChild.__TargetGridParentChild._WSRptTrackingPKB
            Case "SKU"
                targetGrid = ucWSGridParentChild.__TargetGridParentChild._WSRptTrackingSKU
            Case Else
                Exit Sub ' keluar jika tidak ada pilihan yang cocok
        End Select

        With _gdTrackingSKUPKB
            ._prop01User = _prop01User
            ._prop02TargetGridParentChild = targetGrid
            ._prop01Date = mnu03Datedari.EditValue
            ._prop02Date = mnu03DateKe.EditValue
            ._prop03String = mnu02WSSKUTracking.EditValue

            .__pbWSGridParentChild01InitGrid()
            .__pbWSGridParentChild02Clear()
            .__pbWSGridParentChild03Display()
        End With
    End Sub

#End Region

#Region "control - event"

    Private Sub mnu01TargetTracking_EditValueChanged(sender As Object, e As EventArgs) Handles mnu01TargetTracking.EditValueChanged

        '_cm01InitDataControl()
        _cm00Visibility(True)

        ' _lay01WSSKUTracking.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        With _gdTrackingSKUPKB
            ._prop01User = _prop01User
            .__pbWSGridParentChild02Clear()

            If mnu01TargetTracking.EditValue = "SKU" Then
                mnu02WSSKUTracking.Caption = "SKU"
                mnu02WSSKUTracking.EditValue = Nothing

                ' ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSRptTrackingSKU
                ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._WSRptTrackingSKU
                .__pbWSGridVisibilityCheckSelectAll(True, False)
                '  _cm02DisplayData()
            Else
                If mnu01TargetTracking.EditValue = "ORDER" Then
                    mnu02WSSKUTracking.Caption = "No.Order"
                    mnu02WSSKUTracking.EditValue = Nothing

                    ' ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSRptTrackingPKB
                    ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._WSRptTrackingPKB
                    .__pbWSGridVisibilityCheckSelectAll(True, False)

                    '  _gdTrackingSKUPKB.__pbWSGridParentChild01InitGrid()
                    ' _gdTrackingSKUPKB.__pbWSGridParentChild02Clear()
                End If
            End If
        End With
        '  _gdTrackingSKUPKB.__pbWSGrid01InitGrid()
        _gdTrackingSKUPKB.__pbWSGridParentChild01InitGrid()
        _cm02DisplayData()
    End Sub

    Private Sub mnu02WSSKUTracking_EditValueChanged(sender As Object, e As EventArgs) Handles mnu02WSSKUTracking.EditValueChanged
        _cm02DisplayData()
    End Sub

    Private Sub mnu03Datedari_EditValueChanged(sender As Object, e As EventArgs) Handles mnu03Datedari.EditValueChanged
        _cm02DisplayData()
    End Sub

    Private Sub mnu03DateKe_EditValueChanged(sender As Object, e As EventArgs) Handles mnu03DateKe.EditValueChanged
        _cm02DisplayData()
    End Sub
    Private Sub mnu05Display_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnu05Display.ItemClick
        _cm02DisplayData()
    End Sub

    Private Sub RepoGridView_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle + 1
        End If

        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center

            e.Cache.DrawString("No.", e.Appearance.Font, Brushes.Black, e.Bounds, sf)
            e.Handled = True
        End If
    End Sub

    ''=========================
    ''SETTING WIDTH GRID
    'Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
    '    Select Case mnu01TargetTracking.EditValue
    '        Case "ORDER"
    '            _gdTrackingSKUPKB.__pbWSGridParentChild04CreateSettingColumnWidth("trackingPKB")
    '        Case "SKU"
    '            _gdTrackingSKUPKB.__pbWSGridParentChild04CreateSettingColumnWidth("trackingSKU")
    '        Case Else
    '            Exit Sub ' keluar jika tidak ada pilihan yang cocok
    '    End Select
    'End Sub

#End Region

End Class
