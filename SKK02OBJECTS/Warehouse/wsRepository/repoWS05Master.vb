Imports DevExpress.XtraCharts.Native
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class repoWS05Master
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

    Public Property _prop_01dtWSNasaMaster As New DataTable
    Public Property _prop_02TargetMaster As _TargetMaster

    Private dvWSNasaMaster As New DataView
    Private objColValueMember As GridColumn
    Private objColDisplayMember As GridColumn

    Public Enum _TargetMaster
        _01SLOC = 0
        _02BOX = 1
        _03COURIER = 2
        _04BRAND = 3
        _05COLOR = 4
        _06SIZE = 5
        _07NEXTPROSES = 6
        _08PICKER = 7
    End Enum

    Public Sub _01WSNasaBindingDataSource()
        Dim pcfieldValueMember As String = ""
        Dim pcfieldDisplayMember As String = ""
        Dim pcTitle As String = ""

        Select Case _prop_02TargetMaster
            Case _TargetMaster._01SLOC
                pcfieldValueMember = "f05String"
                pcfieldDisplayMember = "f06String"
                pcTitle = "SLOC"

            Case _TargetMaster._02BOX                   'TABLE50
                pcfieldValueMember = "k13String"
                pcfieldDisplayMember = "k14String"
                pcTitle = "BOX"

            Case _TargetMaster._03COURIER               'TABLE50
                pcfieldValueMember = "k13String"
                pcfieldDisplayMember = "k14String"
                pcTitle = "EKSPEDISI"

            Case _TargetMaster._04BRAND
                pcfieldValueMember = "k01cKodeFieldValueMaster_v50"
                pcfieldDisplayMember = "f01cIsiFieldValueMaster_v50"
                pcTitle = "BRAND"

            Case _TargetMaster._05COLOR
                pcfieldValueMember = "k01cKodeFieldValueMaster_v50"
                pcfieldDisplayMember = "f01cIsiFieldValueMaster_v50"
                pcTitle = "COLOR"

            Case _TargetMaster._06SIZE
                pcfieldValueMember = "k01cKodeFieldValueMaster_v50"
                pcfieldDisplayMember = "f01cIsiFieldValueMaster_v50"
                pcTitle = "SIZE"

            Case _TargetMaster._07NEXTPROSES               'TABLE21
                pcfieldValueMember = "f05String"
                pcfieldDisplayMember = "f06String"
                pcTitle = "NextProses"

            Case _TargetMaster._08PICKER                   'TABLE21
                pcfieldValueMember = "f05String"
                pcfieldDisplayMember = "f06String"
                pcTitle = "PICKER"

        End Select

        objColValueMember = New GridColumn With {.Caption = "Code", .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = pcTitle, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}

        Dim objGridView As GridView = New GridView()
        With objGridView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember})
            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)

            With .Appearance.HeaderPanel
                .Font = New Font("Nirmala UI", 8, FontStyle.Bold, GraphicsUnit.Point)
                .ForeColor = Color.Red
                .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End With
        End With

        objGridView.Columns(pcfieldValueMember).Width = 100
        objGridView.Columns(pcfieldDisplayMember).Width = 200

        With Me
            .PopupView = objGridView
            .PopupBorderStyle = PopupBorderStyles.Simple
            .PopupFormSize = New Size(400, 400)

            .NullText = ""
            .DisplayMember = pcfieldDisplayMember
            .ValueMember = pcfieldValueMember

        End With

        dvWSNasaMaster = dvWSNasaValueMaster()
        Me.DataSource = dvWSNasaMaster
    End Sub

    Public Sub _02WSNasaFilterGroupMaster(ByVal prmcFieldFilter As String, ByVal prmcValueFilter As String)

        With dvWSNasaMaster
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With dvWSNasaMaster
            .Sort = prmcFieldFilter
            .RowFilter = String.Format(" {0} = '{1}' ", prmcFieldFilter, prmcValueFilter)
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Me.DataSource = Nothing
        Me.DataSource = dvWSNasaMaster
    End Sub

    Private Function dvWSNasaValueMaster() As DataView
        Dim pcKolomData As String() = Nothing ' New String() {"", "", ""}

        Select Case _prop_02TargetMaster
            Case _TargetMaster._01SLOC
                pcKolomData = New String() {"f05String", "f06String"}

            Case _TargetMaster._02BOX, _TargetMaster._03COURIER
                pcKolomData = New String() {"k11String", "k13String", "k14String"}

            Case _TargetMaster._04BRAND, _TargetMaster._05COLOR, _TargetMaster._06SIZE
                pcKolomData = New String() {"k01cKodeFieldValueMaster_v50", "f01cIsiFieldValueMaster_v50", "f02cKodeMaster_v50"}

            Case _TargetMaster._07NEXTPROSES
                pcKolomData = New String() {"f03String", "f05String", "f06String"}

            Case _TargetMaster._08PICKER
                pcKolomData = New String() {"f05String", "f06String"}

        End Select

        Dim dtTemp As New DataTable
        Dim dvView As DataView = New DataView(_prop_01dtWSNasaMaster)

        dtTemp = dvView.ToTable(True, pcKolomData)
        dvWSNasaValueMaster = New DataView(dtTemp)

        Return dvWSNasaValueMaster
    End Function

    Public Delegate Sub __dlgFilterData(ByVal prmcColumnFilter As String, ByVal prmcValueFilter As String)
    Public Sub __ivkDisplayHasilFilter(ByVal prmcFieldFilter As String, ByVal prmcDataValueFilter As String)
        With dvWSNasaMaster
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With dvWSNasaMaster
            .Sort = prmcFieldFilter
            .RowFilter = String.Format(" {0} = '{1}' ", prmcFieldFilter, prmcDataValueFilter)
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Me.DataSource = Nothing
        Me.DataSource = dvWSNasaMaster
    End Sub

    Public Sub __ivkAddNewSBox(ByVal prmcKode As String, ByVal prmcNama As String)
        Dim objNewSBox As DataRow

        objNewSBox = _prop_01dtWSNasaMaster.NewRow()
        objNewSBox("k11String") = "SBOX"
        objNewSBox("k13String") = prmcKode
        objNewSBox("k14String") = prmcNama
        _prop_01dtWSNasaMaster.Rows.Add(objNewSBox)

        _01WSNasaBindingDataSource()
        _02WSNasaFilterGroupMaster("k11String", "SBOX")

    End Sub

End Class
