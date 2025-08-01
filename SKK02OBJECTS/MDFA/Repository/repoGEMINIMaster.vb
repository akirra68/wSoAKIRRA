Imports DevExpress.DataProcessing.InMemoryDataProcessor
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class repoGEMINIMaster
    Inherits RepositoryItemSearchLookUpEdit
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

    Public Enum DatabaseMaster
        dbSBUMasterTABLE02 = 0
        dbTABLEMASTERMasterTABLE02 = 1
    End Enum

    Public Property _prop_01dtGEMINIMaster As New DataTable
    Public Property _prop_02cGEMINIDatabaseMaster As DatabaseMaster

    Private dvGEMINIMaster As New DataView
    Private objColValueMember As GridColumn
    Private objColDisplayMember As GridColumn

    '--------------------------------
    'SBU..TABLE02
    'k01String = GroupMaster
    'k02String = KeyCodeMaster
    'k03String = NamaMaster
    '================================
    'TABLEMASTER..TABLE02
    'k02String = Kode Master
    'f01String = Nama Master
    'f02String = Kode GroupMaster
    'f03String = Nama GroupMaster
    '--------------------------------

    Public Sub _01GEMINIBindingDataSource()
        Dim pcfieldValueMember As String = ""
        Dim pcfieldDisplayMember As String = ""

        If _prop_02cGEMINIDatabaseMaster = DatabaseMaster.dbSBUMasterTABLE02 Then
            pcfieldValueMember = "k02String"
            pcfieldDisplayMember = "k03String"
        Else
            If _prop_02cGEMINIDatabaseMaster = DatabaseMaster.dbTABLEMASTERMasterTABLE02 Then
                pcfieldValueMember = "k02String"
                pcfieldDisplayMember = "f01String"
            End If
        End If

        objColValueMember = New GridColumn With {.Caption = "Code", .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = "Desc", .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}

        Dim objGridView As GridView = New GridView()
        With objGridView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember})
            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)

            With .Appearance.HeaderPanel
                .Font = New Font("Tahoma", 8, FontStyle.Bold, GraphicsUnit.Point)
                .ForeColor = Color.Red
                .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End With
        End With

        objGridView.Columns(pcfieldValueMember).Width = 100
        objGridView.Columns(pcfieldDisplayMember).Width = 200

        With Me
            .View = objGridView
            .PopupBorderStyle = PopupBorderStyles.Simple
            .PopupFormSize = New Size(400, 400)

            .NullText = ""
            .DisplayMember = pcfieldDisplayMember
            .ValueMember = pcfieldValueMember

        End With

        dvGEMINIMaster = dvGEMINIValueMaster()
        Me.DataSource = dvGEMINIMaster
    End Sub

    Public Sub _02GEMINIFilterGroupMaster(ByVal prmcFieldFilter As String, ByVal prmcValueFilter As String)
        'Dim pcSort As String = ""
        'If _prop_02cGEMINIDatabaseMaster = DatabaseMaster.dbSBUMasterTABLE02 Then
        '    pcSort = "k01String"
        'Else
        '    If _prop_02cGEMINIDatabaseMaster = DatabaseMaster.dbTABLEMASTERMasterTABLE02 Then
        '        pcSort = "f02String"
        '    End If
        'End If

        With dvGEMINIMaster
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With dvGEMINIMaster
            .Sort = prmcFieldFilter
            .RowFilter = String.Format(" {0} = '{1}' ", prmcFieldFilter, prmcValueFilter)
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Me.DataSource = Nothing
        Me.DataSource = dvGEMINIMaster
    End Sub

    '--------------------------------
    'SBU..TABLE02
    'k01String = GroupMaster
    'k02String = KeyCodeMaster
    'k03String = NamaMaster
    '================================
    'TABLEMASTER..TABLE02
    'k02String = Kode Master
    'f01String = Nama Master
    'f02String = Kode GroupMaster
    'f03String = Nama GroupMaster
    '--------------------------------

    Private Function dvGEMINIValueMaster() As DataView
        Dim pcKolomData As String() = New String() {"", "", ""}
        If _prop_02cGEMINIDatabaseMaster = DatabaseMaster.dbSBUMasterTABLE02 Then
            pcKolomData = New String() {"k01String", "k02String", "k03String"}
        Else
            If _prop_02cGEMINIDatabaseMaster = DatabaseMaster.dbTABLEMASTERMasterTABLE02 Then
                pcKolomData = New String() {"k02String", "f01String", "f02String", "f03String"}
            End If
        End If

        Dim dtTemp As New DataTable
        Dim dvView As DataView = New DataView(_prop_01dtGEMINIMaster)

        dtTemp = dvView.ToTable(True, pcKolomData)
        dvGEMINIValueMaster = New DataView(dtTemp)

        Return dvGEMINIValueMaster
    End Function


End Class
