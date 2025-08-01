<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucGridDetailCatalog
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
        colf01String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf02String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf03String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf04String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf05String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf06String = New DevExpress.XtraGrid.Columns.GridColumn()
        colf01Int = New DevExpress.XtraGrid.Columns.GridColumn()
        colf01Double = New DevExpress.XtraGrid.Columns.GridColumn()
        colf01Date = New DevExpress.XtraGrid.Columns.GridColumn()
        colf02Date = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(GridControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GridControl1
        ' 
        GridControl1.Dock = DockStyle.Fill
        GridControl1.Location = New Point(0, 0)
        GridControl1.MainView = GridView1
        GridControl1.Name = "GridControl1"
        GridControl1.Size = New Size(973, 468)
        GridControl1.TabIndex = 0
        GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
        ' 
        ' GridView1
        ' 
        GridView1.Appearance.FooterPanel.Font = New Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        GridView1.Appearance.FooterPanel.ForeColor = Color.Navy
        GridView1.Appearance.FooterPanel.Options.UseFont = True
        GridView1.Appearance.FooterPanel.Options.UseForeColor = True
        GridView1.Appearance.HeaderPanel.Font = New Font("Nirmala UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        GridView1.Appearance.HeaderPanel.ForeColor = Color.Navy
        GridView1.Appearance.HeaderPanel.Options.UseFont = True
        GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridView1.Appearance.Row.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {colf01String, colf02String, colf03String, colf04String, colf05String, colf06String, colf01Int, colf01Double, colf01Date, colf02Date})
        GridView1.GridControl = GridControl1
        GridView1.Name = "GridView1"
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' colf01String
        ' 
        colf01String.Caption = "GridColumn1"
        colf01String.MinWidth = 30
        colf01String.Name = "colf01String"
        colf01String.Visible = True
        colf01String.VisibleIndex = 0
        colf01String.Width = 112
        ' 
        ' colf02String
        ' 
        colf02String.Caption = "GridColumn2"
        colf02String.MinWidth = 30
        colf02String.Name = "colf02String"
        colf02String.Visible = True
        colf02String.VisibleIndex = 1
        colf02String.Width = 112
        ' 
        ' colf03String
        ' 
        colf03String.Caption = "GridColumn3"
        colf03String.MinWidth = 30
        colf03String.Name = "colf03String"
        colf03String.Visible = True
        colf03String.VisibleIndex = 2
        colf03String.Width = 112
        ' 
        ' colf04String
        ' 
        colf04String.Caption = "GridColumn4"
        colf04String.MinWidth = 30
        colf04String.Name = "colf04String"
        colf04String.Visible = True
        colf04String.VisibleIndex = 3
        colf04String.Width = 112
        ' 
        ' colf05String
        ' 
        colf05String.Caption = "GridColumn5"
        colf05String.MinWidth = 30
        colf05String.Name = "colf05String"
        colf05String.Visible = True
        colf05String.VisibleIndex = 4
        colf05String.Width = 112
        ' 
        ' colf06String
        ' 
        colf06String.Caption = "GridColumn6"
        colf06String.MinWidth = 30
        colf06String.Name = "colf06String"
        colf06String.Visible = True
        colf06String.VisibleIndex = 5
        colf06String.Width = 112
        ' 
        ' colf01Int
        ' 
        colf01Int.Caption = "GridColumn7"
        colf01Int.MinWidth = 30
        colf01Int.Name = "colf01Int"
        colf01Int.Visible = True
        colf01Int.VisibleIndex = 6
        colf01Int.Width = 112
        ' 
        ' colf01Double
        ' 
        colf01Double.Caption = "GridColumn8"
        colf01Double.MinWidth = 30
        colf01Double.Name = "colf01Double"
        colf01Double.Visible = True
        colf01Double.VisibleIndex = 7
        colf01Double.Width = 112
        ' 
        ' colf01Date
        ' 
        colf01Date.Caption = "GridColumn9"
        colf01Date.MinWidth = 30
        colf01Date.Name = "colf01Date"
        colf01Date.Visible = True
        colf01Date.VisibleIndex = 8
        colf01Date.Width = 112
        ' 
        ' colf02Date
        ' 
        colf02Date.Caption = "GridColumn10"
        colf02Date.MinWidth = 30
        colf02Date.Name = "colf02Date"
        colf02Date.Visible = True
        colf02Date.VisibleIndex = 9
        colf02Date.Width = 112
        ' 
        ' ucGridDetailCatalog
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GridControl1)
        Name = "ucGridDetailCatalog"
        Size = New Size(973, 468)
        CType(GridControl1, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colf01String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf02String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf03String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf04String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf05String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf06String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf01Int As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf01Double As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf01Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colf02Date As DevExpress.XtraGrid.Columns.GridColumn
End Class
