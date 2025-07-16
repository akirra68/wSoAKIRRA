<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucGridTransactionFinanceMini
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        GridControl1 = New DevExpress.XtraGrid.GridControl()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        colk00Boolean = New DevExpress.XtraGrid.Columns.GridColumn()
        _rscolk00Boolean = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        colk00Int = New DevExpress.XtraGrid.Columns.GridColumn()
        colf01String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf02String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf03String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf04String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf05String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf01Int = New DevExpress.XtraGrid.Columns.GridColumn()
        colf02Int = New DevExpress.XtraGrid.Columns.GridColumn()
        colf03Int = New DevExpress.XtraGrid.Columns.GridColumn()
        colf04Int = New DevExpress.XtraGrid.Columns.GridColumn()
        colf05Int = New DevExpress.XtraGrid.Columns.GridColumn()
        colf01Double = New DevExpress.XtraGrid.Columns.GridColumn()
        colf02Double = New DevExpress.XtraGrid.Columns.GridColumn()
        colf03Double = New DevExpress.XtraGrid.Columns.GridColumn()
        colf04Double = New DevExpress.XtraGrid.Columns.GridColumn()
        colf05Double = New DevExpress.XtraGrid.Columns.GridColumn()
        colf01Date = New DevExpress.XtraGrid.Columns.GridColumn()
        colf02Date = New DevExpress.XtraGrid.Columns.GridColumn()
        colf03Date = New DevExpress.XtraGrid.Columns.GridColumn()
        colk05String = New DevExpress.XtraGrid.Columns.GridColumn()
        colk04String = New DevExpress.XtraGrid.Columns.GridColumn()
        colk03String = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(GridControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_rscolk00Boolean, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GridControl1
        ' 
        GridControl1.Dock = DockStyle.Fill
        GridControl1.Location = New Point(0, 0)
        GridControl1.MainView = GridView1
        GridControl1.Name = "GridControl1"
        GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {_rscolk00Boolean})
        GridControl1.Size = New Size(600, 339)
        GridControl1.TabIndex = 0
        GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
        ' 
        ' GridView1
        ' 
        GridView1.Appearance.HeaderPanel.Font = New Font("Nirmala UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        GridView1.Appearance.HeaderPanel.ForeColor = Color.Navy
        GridView1.Appearance.HeaderPanel.Options.UseFont = True
        GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridView1.Appearance.Row.Font = New Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {colk00Boolean, colk00Int, colk03String, colk04String, colk05String, colf01String, colf02String, colf03String, colf04String, colf05String, colf01Int, colf02Int, colf03Int, colf04Int, colf05Int, colf01Double, colf02Double, colf03Double, colf04Double, colf05Double, colf01Date, colf02Date, colf03Date})
        GridView1.GridControl = GridControl1
        GridView1.Name = "GridView1"
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' colk00Boolean
        ' 
        colk00Boolean.Caption = "GridColumn1"
        colk00Boolean.ColumnEdit = _rscolk00Boolean
        colk00Boolean.MinWidth = 30
        colk00Boolean.Name = "colk00Boolean"
        colk00Boolean.Visible = True
        colk00Boolean.VisibleIndex = 0
        colk00Boolean.Width = 112
        ' 
        ' _rscolk00Boolean
        ' 
        _rscolk00Boolean.AutoHeight = False
        _rscolk00Boolean.Name = "_rscolk00Boolean"
        _rscolk00Boolean.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        _rscolk00Boolean.ValueGrayed = False
        ' 
        ' colk00Int
        ' 
        colk00Int.Caption = "GridColumn2"
        colk00Int.MinWidth = 30
        colk00Int.Name = "colk00Int"
        colk00Int.Visible = True
        colk00Int.VisibleIndex = 1
        colk00Int.Width = 112
        ' 
        ' colf01String
        ' 
        colf01String.Caption = "GridColumn3"
        colf01String.MinWidth = 30
        colf01String.Name = "colf01String"
        colf01String.Visible = True
        colf01String.VisibleIndex = 5
        colf01String.Width = 112
        ' 
        ' colf02String
        ' 
        colf02String.Caption = "GridColumn4"
        colf02String.MinWidth = 30
        colf02String.Name = "colf02String"
        colf02String.Visible = True
        colf02String.VisibleIndex = 6
        colf02String.Width = 112
        ' 
        ' colf03String
        ' 
        colf03String.Caption = "GridColumn5"
        colf03String.MinWidth = 30
        colf03String.Name = "colf03String"
        colf03String.Visible = True
        colf03String.VisibleIndex = 7
        colf03String.Width = 112
        ' 
        ' colf04String
        ' 
        colf04String.Caption = "GridColumn1"
        colf04String.MinWidth = 30
        colf04String.Name = "colf04String"
        colf04String.Visible = True
        colf04String.VisibleIndex = 8
        colf04String.Width = 112
        ' 
        ' colf05String
        ' 
        colf05String.Caption = "GridColumn2"
        colf05String.MinWidth = 30
        colf05String.Name = "colf05String"
        colf05String.Visible = True
        colf05String.VisibleIndex = 9
        colf05String.Width = 112
        ' 
        ' colf01Int
        ' 
        colf01Int.Caption = "GridColumn1"
        colf01Int.MinWidth = 30
        colf01Int.Name = "colf01Int"
        colf01Int.Visible = True
        colf01Int.VisibleIndex = 10
        colf01Int.Width = 112
        ' 
        ' colf02Int
        ' 
        colf02Int.Caption = "GridColumn2"
        colf02Int.MinWidth = 30
        colf02Int.Name = "colf02Int"
        colf02Int.Visible = True
        colf02Int.VisibleIndex = 11
        colf02Int.Width = 112
        ' 
        ' colf03Int
        ' 
        colf03Int.Caption = "GridColumn3"
        colf03Int.MinWidth = 30
        colf03Int.Name = "colf03Int"
        colf03Int.Visible = True
        colf03Int.VisibleIndex = 12
        colf03Int.Width = 112
        ' 
        ' colf04Int
        ' 
        colf04Int.Caption = "GridColumn4"
        colf04Int.MinWidth = 30
        colf04Int.Name = "colf04Int"
        colf04Int.Visible = True
        colf04Int.VisibleIndex = 13
        colf04Int.Width = 112
        ' 
        ' colf05Int
        ' 
        colf05Int.Caption = "GridColumn5"
        colf05Int.MinWidth = 30
        colf05Int.Name = "colf05Int"
        colf05Int.Visible = True
        colf05Int.VisibleIndex = 14
        colf05Int.Width = 112
        ' 
        ' colf01Double
        ' 
        colf01Double.Caption = "GridColumn1"
        colf01Double.MinWidth = 30
        colf01Double.Name = "colf01Double"
        colf01Double.Visible = True
        colf01Double.VisibleIndex = 15
        colf01Double.Width = 112
        ' 
        ' colf02Double
        ' 
        colf02Double.Caption = "GridColumn2"
        colf02Double.MinWidth = 30
        colf02Double.Name = "colf02Double"
        colf02Double.Visible = True
        colf02Double.VisibleIndex = 16
        colf02Double.Width = 112
        ' 
        ' colf03Double
        ' 
        colf03Double.Caption = "GridColumn3"
        colf03Double.MinWidth = 30
        colf03Double.Name = "colf03Double"
        colf03Double.Visible = True
        colf03Double.VisibleIndex = 17
        colf03Double.Width = 112
        ' 
        ' colf04Double
        ' 
        colf04Double.Caption = "GridColumn4"
        colf04Double.MinWidth = 30
        colf04Double.Name = "colf04Double"
        colf04Double.Visible = True
        colf04Double.VisibleIndex = 18
        colf04Double.Width = 112
        ' 
        ' colf05Double
        ' 
        colf05Double.Caption = "GridColumn5"
        colf05Double.MinWidth = 30
        colf05Double.Name = "colf05Double"
        colf05Double.Visible = True
        colf05Double.VisibleIndex = 19
        colf05Double.Width = 112
        ' 
        ' colf01Date
        ' 
        colf01Date.Caption = "GridColumn1"
        colf01Date.MinWidth = 30
        colf01Date.Name = "colf01Date"
        colf01Date.Visible = True
        colf01Date.VisibleIndex = 20
        colf01Date.Width = 112
        ' 
        ' colf02Date
        ' 
        colf02Date.Caption = "GridColumn2"
        colf02Date.MinWidth = 30
        colf02Date.Name = "colf02Date"
        colf02Date.Visible = True
        colf02Date.VisibleIndex = 21
        colf02Date.Width = 112
        ' 
        ' colf03Date
        ' 
        colf03Date.Caption = "GridColumn3"
        colf03Date.MinWidth = 30
        colf03Date.Name = "colf03Date"
        colf03Date.Visible = True
        colf03Date.VisibleIndex = 22
        colf03Date.Width = 112
        ' 
        ' colk05String
        ' 
        colk05String.Caption = "GridColumn1"
        colk05String.MinWidth = 30
        colk05String.Name = "colk05String"
        colk05String.Visible = True
        colk05String.VisibleIndex = 4
        colk05String.Width = 112
        ' 
        ' colk04String
        ' 
        colk04String.Caption = "GridColumn2"
        colk04String.MinWidth = 30
        colk04String.Name = "colk04String"
        colk04String.Visible = True
        colk04String.VisibleIndex = 3
        colk04String.Width = 112
        ' 
        ' colk03String
        ' 
        colk03String.Caption = "GridColumn3"
        colk03String.MinWidth = 30
        colk03String.Name = "colk03String"
        colk03String.Visible = True
        colk03String.VisibleIndex = 2
        colk03String.Width = 112
        ' 
        ' ucGridTransactionFinanceMini
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GridControl1)
        Name = "ucGridTransactionFinanceMini"
        Size = New Size(600, 339)
        CType(GridControl1, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(_rscolk00Boolean, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colk00Boolean As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colk00Int As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf01String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf02String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf03String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf04String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf05String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf01Int As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf02Int As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf03Int As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf04Int As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf05Int As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf01Double As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf02Double As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf03Double As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf04Double As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf05Double As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf01Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf02Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf03Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _rscolk00Boolean As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colk03String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colk04String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colk05String As DevExpress.XtraGrid.Columns.GridColumn
End Class
