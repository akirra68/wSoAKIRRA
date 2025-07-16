<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucReportMersy
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
        components = New ComponentModel.Container()
        DashboardViewer1 = New DevExpress.DashboardWin.DashboardViewer(components)
        CType(DashboardViewer1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DashboardViewer1
        ' 
        DashboardViewer1.Appearance.BackColor = Color.FromArgb(CByte(210), CByte(210), CByte(210))
        DashboardViewer1.Appearance.Options.UseBackColor = True
        DashboardViewer1.AsyncMode = True
        DashboardViewer1.Dock = DockStyle.Fill
        DashboardViewer1.Location = New Point(0, 0)
        DashboardViewer1.Name = "DashboardViewer1"
        DashboardViewer1.Size = New Size(931, 597)
        DashboardViewer1.TabIndex = 0
        ' 
        ' ucReportMersy
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(DashboardViewer1)
        Name = "ucReportMersy"
        Size = New Size(931, 597)
        CType(DashboardViewer1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DashboardViewer1 As DevExpress.DashboardWin.DashboardViewer

End Class
