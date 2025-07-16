Imports DevExpress.XtraGrid
Imports SKK01CORE
Imports SKK02OBJECTS
Imports Microsoft.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base

Public Class ucGridTreeView
    Implements IDisposable

    Property _prop01TargetTransaksi As TargetGrid

    Property _prop02User As clsUserGEMINI

    Property _prop03NewUserID As String
    Property _prop04NewUserName As String

    Property _prop05Bagian As String
    Property _prop06BagianIndex As String
    Property _prop07Picker As String

    Private _dst As DataSet

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _dst = New DataSet
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "private - custom method"
    Private Sub _cm01InitFieldGrid()
        'parent
        _pcolk01String.FieldName = "k01String"
        _pcolk02String.FieldName = "k02String"
        _pcolf01String.FieldName = "f01String"
        _pcolf02String.FieldName = "f02String"
        _pcolf03String.FieldName = "f03String"
        _pcolf04String.FieldName = "f04String"
        _pcolf05String.FieldName = "f05String"
        _pcolf06String.FieldName = "f06String"
        _pcolf07String.FieldName = "f07String"
        _pcolf08String.FieldName = "f08String"
        _pcolf09String.FieldName = "f09String"
        _pcolf10String.FieldName = "f10String"

        'child
        _ccolk00Boolean.FieldName = "k00Boolean"
        _ccolk00Int.FieldName = "k00Int"
        _ccolk01String.FieldName = "k01String"
        _ccolk02String.FieldName = "k02String"
        _ccolf01String.FieldName = "f01String"
        _ccolf02String.FieldName = "f02String"
        _ccolf03String.FieldName = "f03String"
        _ccolf04String.FieldName = "f04String"
        _ccolf05String.FieldName = "f05String"
        _ccolf06String.FieldName = "f06String"
        _ccolf07String.FieldName = "f07String"
        _ccolf08String.FieldName = "f08String"
        _ccolf09String.FieldName = "f09String"
        _ccolf10String.FieldName = "f10String"

    End Sub

    Private Sub _cm02InitVisibilityOFF()
        'parent
        _pcolk01String.Visible = False '"k01String"
        _pcolk02String.Visible = False '"k02String"
        _pcolf01String.Visible = False '"f01String"
        _pcolf02String.Visible = False '"f02String"
        _pcolf03String.Visible = False '"f03String"
        _pcolf04String.Visible = False '"f04String"
        _pcolf05String.Visible = False '"f05String"
        _pcolf06String.Visible = False '"f06String"
        _pcolf07String.Visible = False '"f07String"
        _pcolf08String.Visible = False '"f08String"
        _pcolf09String.Visible = False '"f09String"
        _pcolf10String.Visible = False '"f10String"

        'child
        _ccolk00Boolean.Visible = False '"k00Boolean"
        _ccolk00Int.Visible = False '"k00Int"
        _ccolk01String.Visible = False '"k01String"
        _ccolk02String.Visible = False '"k02String"
        _ccolf01String.Visible = False '"f01String"
        _ccolf02String.Visible = False '"f02String"
        _ccolf03String.Visible = False '"f03String"
        _ccolf04String.Visible = False '"f04String"
        _ccolf05String.Visible = False '"f05String"
        _ccolf06String.Visible = False '"f06String"
        _ccolf07String.Visible = False '"f07String"
        _ccolf08String.Visible = False '"f08String"
        _ccolf09String.Visible = False '"f09String"
        _ccolf10String.Visible = False '"f10String"

    End Sub

    Private Sub _cm03InitVisibilityIndexOFF()
        'parent
        _pcolk01String.VisibleIndex = -1 '"k01String"
        _pcolk02String.VisibleIndex = -1 '"k02String"
        _pcolf01String.VisibleIndex = -1 '"f01String"
        _pcolf02String.VisibleIndex = -1 '"f02String"
        _pcolf03String.VisibleIndex = -1 '"f03String"
        _pcolf04String.VisibleIndex = -1 '"f04String"
        _pcolf05String.VisibleIndex = -1 '"f05String"
        _pcolf06String.VisibleIndex = -1 '"f06String"
        _pcolf07String.VisibleIndex = -1 '"f07String"
        _pcolf08String.VisibleIndex = -1 '"f08String"
        _pcolf09String.VisibleIndex = -1 '"f09String"
        _pcolf10String.VisibleIndex = -1 '"f10String"

        'child
        _ccolk00Boolean.VisibleIndex = -1  '"k00Boolean"
        _ccolk00Int.VisibleIndex = -1  '"k00Int"
        _ccolk01String.VisibleIndex = -1 '"k01String"
        _ccolk02String.VisibleIndex = -1 '"k02String"
        _ccolf01String.VisibleIndex = -1 '"f01String"
        _ccolf02String.VisibleIndex = -1 '"f02String"
        _ccolf03String.VisibleIndex = -1 '"f03String"
        _ccolf04String.VisibleIndex = -1 '"f04String"
        _ccolf05String.VisibleIndex = -1 '"f05String"
        _ccolf06String.VisibleIndex = -1 '"f06String"
        _ccolf07String.VisibleIndex = -1 '"f07String"
        _ccolf08String.VisibleIndex = -1 '"f08String"
        _ccolf09String.VisibleIndex = -1 '"f09String"
        _ccolf10String.VisibleIndex = -1 '"f10String"

    End Sub

    Private Sub _cm04ReadOnlyGrid()
        'parent
        _pcolk01String.OptionsColumn.ReadOnly = True '"k01String"
        _pcolk02String.OptionsColumn.ReadOnly = True '"k02String"
        _pcolf01String.OptionsColumn.ReadOnly = True '"f01String"
        _pcolf02String.OptionsColumn.ReadOnly = True '"f02String"
        _pcolf03String.OptionsColumn.ReadOnly = True '"f03String"
        _pcolf04String.OptionsColumn.ReadOnly = True '"f04String"
        _pcolf05String.OptionsColumn.ReadOnly = True '"f05String"
        _pcolf06String.OptionsColumn.ReadOnly = True '"f06String"
        _pcolf07String.OptionsColumn.ReadOnly = True '"f07String"
        _pcolf08String.OptionsColumn.ReadOnly = True '"f08String"
        _pcolf09String.OptionsColumn.ReadOnly = True '"f09String"
        _pcolf10String.OptionsColumn.ReadOnly = True '"f10String"

        'child
        _ccolk00Boolean.OptionsColumn.ReadOnly = True  '"k00Boolean"
        _ccolk00Int.OptionsColumn.ReadOnly = True  '"k00Int"
        _ccolk01String.OptionsColumn.ReadOnly = True '"k01String"
        _ccolk02String.OptionsColumn.ReadOnly = True '"k02String"
        _ccolf01String.OptionsColumn.ReadOnly = True '"f01String"
        _ccolf02String.OptionsColumn.ReadOnly = True '"f02String"
        _ccolf03String.OptionsColumn.ReadOnly = True '"f03String"
        _ccolf04String.OptionsColumn.ReadOnly = True '"f04String"
        _ccolf05String.OptionsColumn.ReadOnly = True '"f05String"
        _ccolf06String.OptionsColumn.ReadOnly = True '"f06String"
        _ccolf07String.OptionsColumn.ReadOnly = True '"f07String"
        _ccolf08String.OptionsColumn.ReadOnly = True '"f08String"
        _ccolf09String.OptionsColumn.ReadOnly = True '"f09String"
        _ccolf10String.OptionsColumn.ReadOnly = True '"f10String"

    End Sub

    Private Sub _cm05PropertiesGridONTarget()
        'OFF
        _cm02InitVisibilityOFF()
        _cm03InitVisibilityIndexOFF()

        'ON
        _mp01SettingColumnCaption()
        _mp02SettingVisibilityON()
        _mp03SettingReadWriteON()
    End Sub

#End Region

#Region "public - method"

    Public Sub _pb01InitGrid()
        _cm01InitFieldGrid()

        'agar waktu pertama kali display, kosong... tanpa header kolom
        _cm02InitVisibilityOFF()
        _cm03InitVisibilityIndexOFF()
        _cm04ReadOnlyGrid()
    End Sub

    Public Sub _pb02ClearGrid()
        GridControl1.DataSource = Nothing
        GridControl1.Refresh()
    End Sub

    Public Sub _pb03DisplayGridMenuTreeView()
        Cursor = Cursors.WaitCursor

        _cm05PropertiesGridONTarget()

        _dst.Clear()
        _dst.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        '**** Call 104,0,X ****
        Const consFieldnTarget As String = "@tpParamSQLSelect"
        Const consNamaSP As String = "sp100EXECUTESELECT"

        Dim objParamParent As New clsNasaSelectParamDataCollection

        Dim objParamChildUser As New clsNasaSelectParamDataCollection

        Dim objConnSBU As New clsNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnSBU._cm01NasaConnectionDBTABLEMASTER(_prop02User._UserProp07TargetNetwork))

            objConn.Open()

            objParamParent._01AddNew(104, 0, 5, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
                objCommand.Parameters.AddWithValue(consFieldnTarget, objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_dst, "ParentTable")
            End Using

            objParamChildUser._01AddNew(104, 0, 6, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
                objCommand.Parameters.AddWithValue(consFieldnTarget, objParamChildUser).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_dst, "ChildTable")
            End Using

            Dim _pcNamaRelasiChild As String = "Child"

            Dim objDataRelationChild As DataRelation = New DataRelation(_pcNamaRelasiChild,
                                                                   New DataColumn() {_dst.Tables("ParentTable").Columns("f03String")},
                                                                   New DataColumn() {_dst.Tables("ChildTable").Columns("f03String")}, False)

            _dst.Relations.AddRange(New DataRelation() {objDataRelationChild})

            Dim nodeChild As GridLevelNode = New GridLevelNode() With {.LevelTemplate = GridView2,
                                                                       .RelationName = _pcNamaRelasiChild}

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _dst.Tables("ParentTable")

            With GridControl1.LevelTree.Nodes
                .AddRange(New GridLevelNode() {nodeChild})
            End With

            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.BestFitColumns(True)
            GridView1.OptionsDetail.ShowDetailTabs = False
            GridView1.ExpandAllGroups()

            GridView2.OptionsView.ColumnAutoWidth = False
            GridView2.BestFitColumns(True)
            GridView2.OptionsDetail.ShowDetailTabs = False
            GridView2.ExpandAllGroups()

            objConn.Close()
        End Using

        objParamParent.Dispose()
        objParamChildUser.Dispose()

        Me.Dock = DockStyle.Fill

        Cursor = Cursors.Default
    End Sub

    Public Function _pb04SimpanDataNewUser() As Boolean
        Cursor = Cursors.WaitCursor

        Dim objHelper As New clsNasaHelper
        Dim pnHasilExec As Int32 = 0

        Dim pcSQL As String

        For Each dtRow As DataRow In _dst.Tables("ChildTable").Rows
            If dtRow("k00Boolean") Then
                pcSQL = ""
                pcSQL = " delete TABLEMASTER..TABLE20 where k02String = '" & _prop03NewUserID & "'"
                objHelper._prop10SQLCommand = pcSQL
                pnHasilExec = objHelper._pb01NasaExecSQLDirect(_prop02User._UserProp07TargetNetwork,
                                                 clsNasaHelper._pnmDatabaseName.TABLEMASTER, 1)

                pcSQL = ""
                pcSQL = " delete TABLEMASTER..TABLE21 where f07String = '" & _prop03NewUserID & "'"
                objHelper._prop10SQLCommand = pcSQL
                pnHasilExec = objHelper._pb01NasaExecSQLDirect(_prop02User._UserProp07TargetNetwork,
                                                 clsNasaHelper._pnmDatabaseName.TABLEMASTER, 1)

                Exit For
            End If
        Next

        Dim plJmlRec As Int32 = 0
        For Each dtRow As DataRow In _dst.Tables("ChildTable").Rows
            pcSQL = ""

            If dtRow("k00Boolean") Then
                plJmlRec = plJmlRec + 1

                pcSQL = " INSERT INTO TABLEMASTER..TABLE21 " &
                        " (k01String,k02String,f01String,f02String,f03String,f04String,f05String,f06String,f07String,f08String,f09String,f10String,f11String,f12String,f13String,f14String,f15String,f01Int,f02Int,f01Datetime,f01IDUser,f01NamaUser) " &
                        "  VALUES ('','USERACCESS','" & dtRow("f01String") & "','" & dtRow("f02String") & "','" & dtRow("f03String") & "','" & dtRow("f04String") & "','" & dtRow("f05String") & "','" & dtRow("f06String") & "','" & _prop03NewUserID & "','" & _prop04NewUserName & "','" & dtRow("f09String") & "','" & dtRow("f10String") & "','" & dtRow("f11String") & "','" & dtRow("f12String") & "','','',''," & dtRow("f01Int") & "," & dtRow("f02Int") & ",'" & Now & "','aris','arisnjp') "

                objHelper._prop10SQLCommand = pcSQL
                pnHasilExec = objHelper._pb01NasaExecSQLDirect(_prop02User._UserProp07TargetNetwork,
                                                 clsNasaHelper._pnmDatabaseName.TABLEMASTER, 1)
            End If
        Next

        If plJmlRec > 0 Then
            pcSQL = ""
            pcSQL = "INSERT INTO TABLEMASTER..TABLE20 " &
            " (k01String,k02String,f01String,f02String,f03String,f04String,f05String,f06String,f07String,f01StringMax,f02StringMax,f01Int,f02Int,f01Datetime,f01IDUser,f01NamaUser) " &
            "  Select '','" & _prop03NewUserID & "','" & _prop04NewUserName.ToUpper() & "','" & _prop05Bagian.ToUpper & "','" & _prop07Picker & "',f04String,f05String,f06String,f07String,f01StringMax,f02StringMax," & _prop06BagianIndex & ",f02Int,getdate(),'aris','arisnjp' " &
            "  From TABLEMASTER..TABLE20 Where k02String = '100000';"
            '**** k02String = '100000' adalah TEMPLATE - NEWUSER *****

            objHelper._prop10SQLCommand = pcSQL
            pnHasilExec = objHelper._pb01NasaExecSQLDirect(_prop02User._UserProp07TargetNetwork,
                                             clsNasaHelper._pnmDatabaseName.TABLEMASTER, 1)
        End If

        Dim plHasil As Boolean = False
        If plJmlRec > 0 And pnHasilExec > 0 Then
            plHasil = True
        End If

        Cursor = Cursors.Default

        Return plHasil
    End Function

    Public Sub _pb05ReDisplayGridWithUserAccess(ByVal prmdtUserAccess As DataTable)
        Cursor = Cursors.WaitCursor

        For Each dtRowUA As DataRow In prmdtUserAccess.Rows
            For Each dtChild As DataRow In _dst.Tables("ChildTable").Rows
                If dtRowUA("f05String") = dtChild("f05String") Then
                    dtChild("k00Boolean") = True
                    dtChild("k00Int") = 1
                End If
                dtChild.AcceptChanges()
            Next
        Next

        _dst.Tables("ChildTable").AcceptChanges()

        GridControl1.RefreshDataSource()

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "control - event"

    Private Sub _rsccolk00Boolean_CheckedChanged(sender As Object, e As EventArgs) Handles _rsccolk00Boolean.CheckedChanged
        GridView2.PostEditor()
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged

        If _prop01TargetTransaksi = TargetGrid._01CreateMenu And e.Column.FieldName = "k00Boolean" Then

            If CType(GridView2.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                GridView2.SetFocusedRowCellValue("k00Int", 1)
            Else
                GridView2.SetFocusedRowCellValue("k00Int", 0)
            End If

            GridView2.RefreshData()
        End If

    End Sub

#End Region

#Region "********** method private - UPDATE/CHANGE **********"

    Public Enum TargetGrid
        _01CreateMenu = 0
        _02UserAccessMenu = 1
    End Enum

    Private Sub _mp01SettingColumnCaption()
        Select Case _prop01TargetTransaksi
            Case TargetGrid._01CreateMenu
                _cc01CaptionCreateMenu()

            Case TargetGrid._02UserAccessMenu
                _cc01CaptionUserAccess()

        End Select
    End Sub

    Private Sub _mp02SettingVisibilityON()
        Select Case _prop01TargetTransaksi
            Case TargetGrid._01CreateMenu
                _vs01VisibilityCreateMenu()
                _vs02VisibilityIndexCreateMenu()

            Case TargetGrid._02UserAccessMenu
                _vs01VisibilityUserAccess()
                _vs02VisibilityIndexUserAccess()
        End Select
    End Sub

    Private Sub _mp03SettingReadWriteON()
        Select Case _prop01TargetTransaksi
            Case TargetGrid._01CreateMenu
                _rw01ReadWriteCreateMenu()

        End Select
    End Sub

#End Region

#Region "********** grid : CreateMenu **********"
    Private Sub _cc01CaptionCreateMenu()

        _pcolf04String.Caption = "Group Menu"

        _ccolk00Boolean.Caption = "#"
        _ccolf06String.Caption = "Menu"

        _pcolf04String.Width = 700
        _ccolk00Boolean.Width = 50
        _ccolf06String.Width = 300
    End Sub

    Private Sub _vs01VisibilityCreateMenu()
        _pcolf04String.Visible = True  '"Group Menu"

        _ccolk00Boolean.Visible = True  '"#"
        _ccolf06String.Visible = True  '"Menu"
    End Sub

    Private Sub _vs02VisibilityIndexCreateMenu()
        _pcolf04String.VisibleIndex = 0 '"Group Menu"

        _ccolk00Boolean.VisibleIndex = 0 '"#"
        _ccolf06String.VisibleIndex = 1 '"Menu"

    End Sub

    Private Sub _rw01ReadWriteCreateMenu()
        _ccolk00Boolean.OptionsColumn.ReadOnly = False '"#"
    End Sub

#End Region

#Region "********** grid : UserAccess **********"

    Private Sub _cc01CaptionUserAccess()
        _pcolf07String.Caption = "NIK"
        _pcolf08String.Caption = "Nama"

        _ccolf04String.Caption = "Group Menu"
    End Sub

    Private Sub _vs01VisibilityUserAccess()
        _pcolf07String.Visible = True  '"NIK"
        _pcolf08String.Visible = True  '"Nama"

        _ccolf04String.Visible = True  '"Group Menu"
    End Sub

    Private Sub _vs02VisibilityIndexUserAccess()
        _pcolf07String.VisibleIndex = 0  '"NIK"
        _pcolf08String.VisibleIndex = 1  '"Nama"

        _ccolf04String.VisibleIndex = 0  '"Group Menu"
    End Sub

#End Region

End Class
