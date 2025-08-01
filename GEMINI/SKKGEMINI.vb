'*****************************************************************
'*        Created : Jum'at, 27 September 2024 - 11:19  WIB         *
'*****************************************************************
'*            Hari ini awal dari PROJECT wSo             * 
'*****************************************************************
Imports System.Net
Imports System.Threading
Imports DevExpress.Skins
Imports DevExpress.Utils.Extensions

Public Class SKKGEMINI

    <STAThread>
    Public Shared Sub Main()

        'SEBAB CultureInfo SERVER-nya : English
        'ini akan berpengaruh ke Devexpress control DATEEDIT
        Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-US")

        DevExpress.UserSkins.BonusSkins.Register()
        SkinManager.EnableFormSkins()
        SkinManager.EnableMdiFormSkins()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Basic"

        Application.Run(New frmLoginAKIRRA())

    End Sub

End Class
