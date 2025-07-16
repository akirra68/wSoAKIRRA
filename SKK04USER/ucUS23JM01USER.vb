Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucUS23JM01USER
    Implements IDisposable

    Property _prop01User As clsUserGEMINI

    Private pdtMenu As DataTable
    Private pdtUserAccess As DataTable

    Private objHelper As clsNasaHelper

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtMenu = New DataTable
        pdtUserAccess = New DataTable
        objHelper = New clsNasaHelper
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtMenu.Dispose()
        pdtUserAccess.Dispose()
        objHelper.Dispose()
    End Sub

    Private Sub ucUS23JM01USER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'field Grid ListUser
        _col01cNIK.FieldName = "cNIK"
        _col02cNama.FieldName = "cNama"

        With _gdMenu
            ._prop01TargetTransaksi = ucGridTreeView.TargetGrid._01CreateMenu
            ._prop02User = _prop01User
        End With
        _gdMenu._pb01InitGrid()

        _cm01BersihkanEntrian()
        _cm02SettingTreeList()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01BersihkanEntrian()
        Cursor = Cursors.WaitCursor

        _01cNIKUser.EditValue = ""
        _02cNamaUser.EditValue = ""
        _02cNamaUser.Properties.CharacterCasing = CharacterCasing.Upper

        '0.Warehouse.
        '1.Merchandise.
        '2.Marketing.
        '3.Manajerial.
        _03cBagian.SelectedIndex = -1

        _04IsPickerBRJ.Checked = False
        _lay04IsPickerBRJ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _02cNamaUser.Properties.ReadOnly = True
        _01cNIKUser.Properties.Buttons(0).Visible = False

        pdtUserAccess.Clear()
        pdtUserAccess = objHelper._pb03NasaExecSPPROCESStoDataTable(_prop01User._UserProp07TargetNetwork,
                                    clsNasaHelper._pnmDatabaseName.TABLEMASTER, "sp2021UserAccess",)

        _cm03DisplayMenuGridTreeView()
        _cm04ShowGridListUser()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm02SettingTreeList()
        _tlCol01cID.FieldName = "cID"
        _tlCol01cID.Visible = False
        _tlCol02cKeyParent.FieldName = "cKeyParent"
        _tlCol02cKeyParent.Visible = False
        _tlCol03cNIK.FieldName = "cNIK"
        _tlCol04cNama.FieldName = "cNama"

        With _tlUserAccess
            .OptionsBehavior.ReadOnly = False
            .OptionsView.ShowHorzLines = False
            .OptionsView.ShowVertLines = False
            .OptionsView.ShowIndicator = False
            .CollapseToLevel(-1)
        End With

    End Sub

    Private Sub _cm03DisplayMenuGridTreeView()
        _gdMenu._pb02ClearGrid()
        _gdMenu._pb03DisplayGridMenuTreeView()
    End Sub

    Private Sub _cm04ShowGridListUser()
        Dim dtRows() As DataRow

        dtRows = pdtUserAccess.Select(" cKeyParent = 0 ")

        _gdListUser.DataSource = Nothing
        _gdListUser.DataSource = dtRows.CopyToDataTable()
    End Sub

    Private Sub _cm05ReDisplayMenuGridTreeView()
        Cursor = Cursors.WaitCursor

        Dim pdtHasil As New DataTable

        objHelper._prop10SQLCommand = " select * from TABLE21 where f07String = '" & _01cNIKUser.EditValue & "'"
        pdtHasil = objHelper._pb01NasaExecSQLDirectToDataTable(_prop01User._UserProp07TargetNetwork,
                                                               clsNasaHelper._pnmDatabaseName.TABLEMASTER)

        If pdtHasil.Rows.Count > 0 Then
            For Each dtRow As DataRow In pdtHasil.Rows
                _02cNamaUser.EditValue = dtRow("f08String").ToString
                _02cNamaUser.Properties.ReadOnly = True
            Next

            _gdMenu._pb05ReDisplayGridWithUserAccess(pdtHasil)
        Else
            _02cNamaUser.Properties.ReadOnly = False
            _02cNamaUser.Focus()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm06SimpanDataNewUser()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin akan menyimpan data ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _gdMenu._prop03NewUserID = _01cNIKUser.EditValue
            _gdMenu._prop04NewUserName = _02cNamaUser.EditValue

            _gdMenu._prop06BagianIndex = _03cBagian.SelectedIndex
            Select Case _03cBagian.SelectedIndex
                Case 0
                    _gdMenu._prop05Bagian = "Warehouse"
                Case 1
                    _gdMenu._prop05Bagian = "Merchandise"
                Case 2
                    _gdMenu._prop05Bagian = "Marketing"
                Case 3
                    _gdMenu._prop05Bagian = "Manajerial"
            End Select

            _gdMenu._prop07Picker = ""
            If _04IsPickerBRJ.Checked Then
                _gdMenu._prop07Picker = "Picker"
            End If

            If _gdMenu._pb04SimpanDataNewUser() Then
                MsgBox("Simpan Data ... BERHASIL", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _prop01User._UserProp01cTitle)
                _cm01BersihkanEntrian()
            Else
                MsgBox("Simpan Data ... GAGAL", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Simpan Data ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop01User._UserProp01cTitle)
        End If

    End Sub

#End Region

#Region "control - event"

    Private Sub _01cNIKUser_LostFocus(sender As Object, e As EventArgs) Handles _01cNIKUser.LostFocus
        If Not String.IsNullOrEmpty(_01cNIKUser.EditValue) Then
            _cm05ReDisplayMenuGridTreeView()
        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        Dim objView As GridView = CType(sender, GridView)
        Dim pcNIKMersy As String = objView.GetFocusedRowCellValue("cNIKMERSY")

        Dim dtRows() As DataRow

        dtRows = pdtUserAccess.Select(" cNIKMERSY = '" & pcNIKMersy & "'")

        _tlUserAccess.DataSource = Nothing
        _tlUserAccess.DataSource = dtRows.CopyToDataTable()
    End Sub

    Private Sub _mnu01Save_ItemClick(sender As Object, e As ItemClickEventArgs) Handles _mnu01Save.ItemClick
        _cm06SimpanDataNewUser()
    End Sub

    Private Sub _mnu02Clear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles _mnu02Clear.ItemClick
        _cm01BersihkanEntrian()
    End Sub

    Private Sub _03cBagian_EditValueChanged(sender As Object, e As EventArgs) Handles _03cBagian.EditValueChanged
        _04IsPickerBRJ.Checked = False
        _lay04IsPickerBRJ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        If _03cBagian.SelectedIndex > -1 Then
            If _03cBagian.SelectedIndex = 0 Then
                _lay04IsPickerBRJ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If
        End If
    End Sub

#End Region

End Class
