Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Imports SKK02OBJECTS

Public Class ucWS25DX01STOCKCHECK
    Implements IDisposable

    Public Property _prop01User As clsWSNasaUser

    Private pdtProductCodeStock As DataTable
    Private pdtSkuStock As DataTable

    Private contextMenu As New ContextMenuStrip()

#Region " *** FORM EVENTS *** "
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        pdtProductCodeStock = New DataTable
        pdtSkuStock = New DataTable

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtProductCodeStock.Dispose()
        pdtSkuStock.Dispose()

        BarManager1.Dispose()
        Bar1.Dispose()
        mnuBar01ProductCode.Dispose()
        mnuBar02Refresh.Dispose()
        _gdStockCheck.Dispose()
    End Sub

    Private Sub ucWS25DQ01ORDERMANAGEMENT_Load(sender As Object, e As EventArgs) Handles Me.Load
        _cm01InitControl()
        _cm02ClearControl()
    End Sub



#End Region

#Region " *** CONTROL EVENTS *** "
    Private Sub GridView_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)
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

    Private Sub GridView_MouseUp(sender As Object, e As MouseEventArgs)
        Dim view As GridView = CType(sender, GridView)

        If e.Button = MouseButtons.Right Then
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Location)

            If hitInfo.InRowCell AndAlso hitInfo.Column.FieldName = "f21String" Then
                view.FocusedRowHandle = hitInfo.RowHandle
                view.FocusedColumn = hitInfo.Column

                contextMenu.Show(view.GridControl, e.Location)
            End If
        End If
    End Sub

    Private Sub CopyMenuItem_Click(sender As Object, e As EventArgs)
        Dim view As GridView = CType(rsmnuBar01ProductCode.View, GridView)

        Dim value As Object = view.GetRowCellValue(view.FocusedRowHandle, "f21String")

        'MsgBox(value)

        If value IsNot Nothing Then
            Clipboard.SetText(value.ToString())
        End If

        contextMenu.Hide()
    End Sub

    Private Sub mnuBar03Refresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar02Refresh.ItemClick
        _cm02ClearControl()

    End Sub

#End Region

#Region " *** CUSTOM METHODS *** "
    Private Sub _cm01InitControl()
        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        BarManager1.AllowCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 15

        ' clear control
        LayoutControl1.Visible = False
        LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Bar1.Visible = False

        mnuBar01ProductCode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        mnuBar02Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        _gdStockCheck.Visible = False

        ' show control
        LayoutControl1.Visible = True
        LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Bar1.Visible = True

        mnuBar01ProductCode.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        mnuBar02Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        _gdStockCheck.Visible = True
    End Sub

    Private Sub _cm02ClearControl()
        mnuBar01ProductCode.EditValue = ""

        _gdStockCheck.__pbWSGrid01InitGrid()
        _gdStockCheck.__pbWSGrid02ClearGrid()
        _gdStockCheck.Refresh()

        _cm05RefreshRepoProductCode()
    End Sub

    Private Sub _cm03InitRepoProductCode()
        Cursor = Cursors.WaitCursor
        rsmnuBar01ProductCode.DataSource = ""
        pdtProductCodeStock = Nothing

        Using objNasa = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtProductCodeStock = objNasa._pb08GetDataProductCodePosterStockWHForChecking()

            With rsmnuBar01ProductCode
                .ShowClearButton = False
                .DataSource = pdtProductCodeStock
                .ValueMember = "f21String"
                .DisplayMember = "f21String"
                .PopupFormSize = New Size(700, 0)


                Dim view As GridView = CType(.View, GridView)

                AddHandler view.CustomDrawRowIndicator, AddressOf GridView_CustomDrawRowIndicator
                AddHandler view.MouseUp, AddressOf GridView_MouseUp

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
                    .AddVisible("f21String", "ProductCode")
                    .AddVisible("f27String", "Kadar")
                    .AddVisible("f25String", "Brand")
                    .AddVisible("f12String", "Tipe")
                    .AddVisible("f01SmallInt", "Tot.Qty")
                    .AddVisible("f01Double", "Tot.Gram")
                End With

                ' header and row colour
                With view
                    .Columns("f21String").AppearanceHeader.BackColor = Color.DeepPink
                    .Columns("f21String").AppearanceCell.BackColor = Color.LightPink
                End With

                ' summary on footer
                With view
                    .OptionsView.ShowFooter = True
                    .Columns("f21String").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("f21String").SummaryItem.DisplayFormat = "{0:n0} Rows"
                    .Columns("f01SmallInt").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("f01SmallInt").SummaryItem.FieldName = "f01SmallInt"
                    .Columns("f01SmallInt").SummaryItem.DisplayFormat = "{0:n0}"
                    .Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("f01Double").SummaryItem.FieldName = "f01Double"
                    .Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
                End With

                view.BestFitColumns()

                contextMenu.Items.Clear()
                contextMenu.Items.Add("Copy", Nothing, AddressOf CopyMenuItem_Click)

                AddHandler rsmnuBar01ProductCode.ButtonClick, AddressOf OnRepoButtonClick
            End With
        End Using


        Cursor = Cursors.Default
    End Sub

    Private Sub OnRepoButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ' Ini tombol Clear diklik
            MsgBox("CLEAR BUTTON DITEKAN")
        End If
    End Sub

    Private Sub _cm04InitGridStockCheck(ByVal prmcDataTable As DataTable)
        _gdStockCheck.__pbWSGrid01InitGrid()
        _gdStockCheck.__pbWSGrid02ClearGrid()

        With _gdStockCheck
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSStockCheck
            ._prop03pdtDataSourceGrid = prmcDataTable
        End With
        _gdStockCheck.__pbWSGrid03DisplayGrid()
        _gdStockCheck.Refresh()
        _gdStockCheck.Focus()
    End Sub

    Private Sub _cm05RefreshRepoProductCode()
        _cm03InitRepoProductCode()
    End Sub

    Private Sub _cm06RefreshGrid(ByVal prmcDataTable As DataTable)
        _cm04InitGridStockCheck(prmcDataTable)

    End Sub

    Private Sub mnuBar01ProductCode_EditValueChanged(sender As Object, e As EventArgs) Handles mnuBar01ProductCode.EditValueChanged
        Try
            pdtSkuStock = Nothing

            Using objNasa = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
                pdtSkuStock = objNasa._pb09GetDataSkuPosterStockWHForChecking(mnuBar01ProductCode.EditValue)

                _cm06RefreshGrid(pdtSkuStock)
            End Using

            Clipboard.Clear()
            If mnuBar01ProductCode.EditValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(mnuBar01ProductCode.EditValue.ToString()) Then
                Clipboard.SetText(mnuBar01ProductCode.EditValue.ToString())
            End If

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


#End Region

End Class
