Imports DevExpress
Imports DevExpress.LookAndFeel

Public Class _clsSkinHelper

    Private Shared ReadOnly AllSkins As String() = {
        "Coffee", "Office 2019 Colorful", "Office 2019 White",
        "Visual Studio 2013 Blue", "The Bezier", "DevExpress Style", "Seven", "Seven Classic",
        "Pumpkin", "iMaginary", "Liquid Sky", "Valentine", "Springtime",
        "Summer 2008", "Stardust"
    }

    ''' <summary>
    ''' apply random skins to all environment 
    ''' </summary>
    Public Shared Sub pbm01ApplyRandomSkins(_objUserProp As clsUserGEMINI, _objUserPropWS As clsWSNasaUser)
        Dim _objRand As New Random()
        Dim vsRandSkins As String = AllSkins(_objRand.Next(AllSkins.Length))

        UserLookAndFeel.Default.UseDefaultLookAndFeel = False
        UserLookAndFeel.Default.SetSkinStyle(vsRandSkins)
        _objUserProp._UserProp10Skin = vsRandSkins
        _objUserPropWS._UserProp10Skin = vsRandSkins

    End Sub
End Class
