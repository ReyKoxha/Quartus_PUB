Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports quartus.CUsefulFuncs
Imports quartus.CSDK
Imports System.Drawing
Imports quartus.ENUMS

Public Class GUI
    ' AIMBOT
    ' ENABLED
    Private Sub FlatToggle12_CheckedChanged(sender As Object) Handles FlatToggle12.CheckedChanged
        If Me.FlatToggle12.Checked = True Then
            My.Settings.Aimbot = True
        ElseIf Me.FlatToggle12.Checked = False Then
            My.Settings.Aimbot = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' MODE
    Private Sub FlatToggle1_CheckedChanged(sender As Object) Handles FlatToggle1.CheckedChanged
        If Me.FlatToggle1.Checked = True Then
            My.Settings.AimMode = 2
            RageAim.Show()
            FlatLabel14.Show()
            FlatLabel17.Show()
            FlatLabel18.Show()
            FlatLabel19.Show()
            FOVRiflesBar.Show()
            FOVPistolsBar.Show()
            FOVSnipersBar.Show()
        ElseIf Me.FlatToggle1.Checked = False Then
            My.Settings.AimMode = 1
            RageAim.Hide()
            FlatLabel14.Hide()
            FlatLabel17.Hide()
            FlatLabel18.Hide()
            FlatLabel19.Hide()
            FOVRiflesBar.Hide()
            FOVPistolsBar.Hide()
            FOVSnipersBar.Hide()
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' MODE
    Private Sub RageAim_CheckedChanged(sender As Object) Handles RageAim.CheckedChanged
        If Me.RageAim.Checked = True Then
            My.Settings.RageAim = 1
        ElseIf Me.RageAim.Checked = False Then
            My.Settings.RageAim = 0
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' RANGEBASED
    Private Sub FlatToggle13_CheckedChanged(sender As Object) Handles FlatToggle13.CheckedChanged
        If Me.FlatToggle13.Checked = True Then
            My.Settings.RangeBased = True
        ElseIf Me.FlatToggle13.Checked = False Then
            My.Settings.RangeBased = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' Rifles
    Private Sub SmoothingRiflesBar_Scroll(sender As Object) Handles SmoothingRiflesBar.Scroll
        My.Settings.SmoothRifles = Me.SmoothingRiflesBar.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FlatTrackBar4_Scroll(sender As Object) Handles FlatTrackBar4.Scroll
        My.Settings.AimSpotRifles = Me.FlatTrackBar4.Value
        My.Settings.Save()
        Settings.Load()
    End Sub


    Private Sub FOVRiflesBar_Scroll(sender As Object) Handles FOVRiflesBar.Scroll
        My.Settings.FovRifles = Me.FOVRiflesBar.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' Pistols
    Private Sub SmoothingPistolsBar_Scroll(sender As Object) Handles SmoothingPistolsBar.Scroll
        My.Settings.SmoothPistols = Me.SmoothingPistolsBar.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FlatTrackBar5_Scroll(sender As Object) Handles FlatTrackBar5.Scroll
        My.Settings.AimSpotPistols = Me.FlatTrackBar5.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FOVPistolsBar_Scroll(sender As Object) Handles FOVPistolsBar.Scroll
        My.Settings.FovPistols = Me.FOVPistolsBar.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' Snipers
    Private Sub SmoothingSnipersBar_Scroll(sender As Object) Handles SmoothingSnipersBar.Scroll
        My.Settings.SmoothSnipers = Me.SmoothingSnipersBar.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FlatTrackBar6_Scroll(sender As Object) Handles FlatTrackBar6.Scroll
        My.Settings.AimSpotSnipers = Me.FlatTrackBar6.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FOVSnipersBar_Scroll(sender As Object) Handles FOVSnipersBar.Scroll
        My.Settings.FovSnipers = Me.FOVSnipersBar.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' Delay
    Private Sub FlatTrackBar1_Scroll(sender As Object) Handles FlatTrackBar1.Scroll
        My.Settings.SleepTime = Me.FlatTrackBar1.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' ESP
    ' ENABLED
    Private Sub FlatToggle15_CheckedChanged(sender As Object) Handles FlatToggle15.CheckedChanged
        If Me.FlatToggle15.Checked = True Then
            My.Settings.ESP = True
        ElseIf Me.FlatToggle15.Checked = False Then
            My.Settings.ESP = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' MODE
    Private Sub FlatToggle14_CheckedChanged(sender As Object) Handles FlatToggle14.CheckedChanged
        If Me.FlatToggle14.Checked = True Then
            My.Settings.ESPmode = 2
        ElseIf Me.FlatToggle14.Checked = False Then
            My.Settings.ESPmode = 1
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' TOGGABLE
    Private Sub FlatToggle16_CheckedChanged(sender As Object) Handles FlatToggle16.CheckedChanged
        If Me.FlatToggle16.Checked = True Then
            My.Settings.Toggable = True
        ElseIf Me.FlatToggle16.Checked = False Then
            My.Settings.Toggable = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' DEFINE COLOR ACTIONS
    Private Sub EnColor_Click(sender As Object, e As EventArgs) Handles EnColor.Click
        Dim ColorSelectorInstance = New ColorSelector(ClickedButtonEvent.Enemy)
        ColorSelectorInstance.Show()
    End Sub

    Private Sub VisEnColor_Click(sender As Object, e As EventArgs) Handles VisEnColor.Click
        Dim ColorSelectorInstance = New ColorSelector(ClickedButtonEvent.VisibleEnemy)
        ColorSelectorInstance.Show()
    End Sub

    Private Sub TmColor_Click(sender As Object, e As EventArgs) Handles TmColor.Click
        Dim ColorSelectorInstance = New ColorSelector(ClickedButtonEvent.Team)
        ColorSelectorInstance.Show()
    End Sub

    Private Sub WpColor_Click(sender As Object, e As EventArgs) Handles WpColor.Click
        Dim ColorSelectorInstance = New ColorSelector(ClickedButtonEvent.Weapon)
        ColorSelectorInstance.Show()
    End Sub

    Private Sub GdColor_Click(sender As Object, e As EventArgs) Handles GdColor.Click
        Dim ColorSelectorInstance = New ColorSelector(ClickedButtonEvent.Grenade)
        ColorSelectorInstance.Show()
    End Sub

    Private Sub BbColor_Click(sender As Object, e As EventArgs) Handles BbColor.Click
        Dim ColorSelectorInstance = New ColorSelector(ClickedButtonEvent.Bomb)
        ColorSelectorInstance.Show()
    End Sub

    Private Sub CkColor_Click(sender As Object, e As EventArgs) Handles CkColor.Click
        Dim ColorSelectorInstance = New ColorSelector(ClickedButtonEvent.Chicken)
        ColorSelectorInstance.Show()
    End Sub

    ' TRIGGER
    ' ENABLED
    Private Sub FlatToggle18_CheckedChanged(sender As Object) Handles FlatToggle18.CheckedChanged
        If Me.FlatToggle18.Checked = True Then
            My.Settings.Trigger = True
        ElseIf Me.FlatToggle18.Checked = False Then
            My.Settings.Trigger = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' MODE
    Private Sub FlatToggle17_CheckedChanged(sender As Object) Handles FlatToggle17.CheckedChanged
        If FlatToggle17.Checked = False Then
            My.Settings.TriggerMode = 1
            FlatToggle33.Show()
            FlatLabel20.Show()
        ElseIf FlatToggle17.Checked = True Then
            My.Settings.TriggerMode = 2
            FlatToggle33.Hide()
            FlatLabel20.Hide()
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' RAGEMODE
    Private Sub FlatToggle33_CheckedChanged(sender As Object) Handles FlatToggle33.CheckedChanged
        If FlatToggle33.Checked = True Then
            My.Settings.RageMode = 1
        ElseIf FlatToggle33.Checked = False Then
            My.Settings.RageMode = 0
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' DELAY
    Private Sub FlatTrackBar2_Scroll(sender As Object) Handles FlatTrackBar2.Scroll
        My.Settings.DelayTime = Me.FlatTrackBar2.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FlatTrackBar3_Scroll(sender As Object) Handles FlatTrackBar3.Scroll
        My.Settings.DelayAfterShotTime = Me.FlatTrackBar3.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' MISC
    ' BHOP
    Private Sub FlatToggle22_CheckedChanged(sender As Object) Handles FlatToggle22.CheckedChanged
        If FlatToggle22.Checked = True Then
            My.Settings.Bhop = True
        ElseIf FlatToggle22.Checked = False Then
            My.Settings.Bhop = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' RADAR
    Private Sub FlatToggle19_CheckedChanged(sender As Object) Handles FlatToggle19.CheckedChanged
        If FlatToggle19.Checked = True Then
            My.Settings.Radar = True
        ElseIf FlatToggle19.Checked = False Then
            My.Settings.Radar = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' Fastclicker
    Private Sub FlatToggle20_CheckedChanged(sender As Object) Handles FlatToggle20.CheckedChanged
        If FlatToggle20.Checked = True Then
            My.Settings.Autopistol = True
        ElseIf FlatToggle20.Checked = False Then
            My.Settings.Autopistol = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' NoFlash
    Private Sub FlatToggle21_CheckedChanged(sender As Object) Handles FlatToggle21.CheckedChanged
        If FlatToggle21.Checked = True Then
            My.Settings.Noflash = True
        ElseIf FlatToggle21.Checked = False Then
            My.Settings.Noflash = False
        End If
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' NoFlash
    Private Sub NoFlashBar_Scroll(sender As Object) Handles NoFlashBar.Scroll
        My.Settings.NoflashMaxAlpha = Me.NoFlashBar.Value
        My.Settings.Save()
        Settings.Load()
    End Sub

    ' KEYS
    Private Sub FlatTextBox38_TextChanged(sender As Object, e As EventArgs) Handles FlatTextBox38.TextChanged
        Try
            Dim TRIGGERKEY As Integer = Integer.Parse(FlatTextBox38.Text)
            My.Settings.TriggerKey = TRIGGERKEY
        Catch
        End Try
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FlatTextBox40_TextChanged(sender As Object, e As EventArgs) Handles FlatTextBox40.TextChanged
        Try
            Dim AIMKEY As Integer = Integer.Parse(FlatTextBox40.Text)
            My.Settings.AimKey = AIMKEY
        Catch
        End Try
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FlatTextBox37_TextChanged(sender As Object, e As EventArgs) Handles FlatTextBox37.TextChanged
        Try
            Dim ESPKEY As Integer = Integer.Parse(FlatTextBox37.Text)
            My.Settings.ESPKey = ESPKEY
        Catch
        End Try
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub FlatTextBox39_TextChanged(sender As Object, e As EventArgs) Handles FlatTextBox39.TextChanged
        Try
            Dim APKEY As Integer = Integer.Parse(FlatTextBox39.Text)
            My.Settings.APKey = APKEY
        Catch
        End Try
        My.Settings.Save()
        Settings.Load()
    End Sub

    Private Sub GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadValues()
        Refresh()
        ' GENERAL
        Me.TopMost = True
        Me.FlatTabControl2.SizeMode = TabSizeMode.Normal
        Settings.Load()
    End Sub

    Function LoadValues()
        ' LOAD VALUES
        'AIMBOT
        FlatToggle12.Checked = My.Settings.Aimbot

        If My.Settings.AimMode = 2 Then
            FlatToggle1.Checked = True
            RageAim.Show()
            FlatLabel14.Show()
            FlatLabel17.Show()
            FlatLabel18.Show()
            FlatLabel19.Show()
            FOVRiflesBar.Show()
            FOVPistolsBar.Show()
            FOVSnipersBar.Show()
        ElseIf My.Settings.AimMode = 1 Then
            FlatToggle1.Checked = False
            RageAim.Hide()
            FlatLabel14.Hide()
            FlatLabel17.Hide()
            FlatLabel18.Hide()
            FlatLabel19.Hide()
            FOVRiflesBar.Hide()
            FOVPistolsBar.Hide()
            FOVSnipersBar.Hide()
        End If

        RageAim.Checked = My.Settings.RageAim
        FlatToggle13.Checked = My.Settings.RangeBased

        FOVPistolsBar.Value = My.Settings.FovPistols
        FOVRiflesBar.Value = My.Settings.FovRifles
        FOVSnipersBar.Value = My.Settings.FovSnipers

        SmoothingPistolsBar.Value = My.Settings.SmoothPistols
        SmoothingRiflesBar.Value = My.Settings.SmoothRifles
        SmoothingSnipersBar.Value = My.Settings.SmoothSnipers

        FlatTrackBar5.Value = My.Settings.AimSpotPistols
        FlatTrackBar4.Value = My.Settings.AimSpotRifles
        FlatTrackBar6.Value = My.Settings.AimSpotSnipers

        FlatTrackBar1.Value = My.Settings.SleepTime

        ' ESP
        FlatToggle15.Checked = My.Settings.ESP

        If My.Settings.ESPmode = 2 Then
            FlatToggle14.Checked = True
        ElseIf My.Settings.ESPmode = 1 Then
            FlatToggle14.Checked = False
        End If

        FlatToggle16.Checked = My.Settings.Toggable

        ' TRIGGER
        FlatToggle18.Checked = My.Settings.Trigger

        If My.Settings.TriggerMode = 2 Then
            FlatToggle17.Checked = True
            FlatToggle33.Hide()
            FlatLabel20.Hide()
        ElseIf My.Settings.TriggerMode = 1 Then
            FlatToggle17.Checked = False
            FlatToggle33.Show()
            FlatLabel20.Show()
        End If

        FlatToggle33.Checked = My.Settings.RageMode
        FlatTrackBar2.Value = My.Settings.DelayTime
        FlatTrackBar3.Value = My.Settings.DelayAfterShotTime

        ' MISC
        FlatToggle22.Checked = My.Settings.Bhop
        FlatToggle19.Checked = My.Settings.Radar
        FlatToggle20.Checked = My.Settings.Autopistol
        FlatToggle21.Checked = My.Settings.Noflash
        NoFlashBar.Value = My.Settings.NoflashMaxAlpha

        ' KEYS
        FlatTextBox40.Text = My.Settings.AimKey
        FlatTextBox38.Text = My.Settings.TriggerKey
        FlatTextBox37.Text = My.Settings.ESPKey
        FlatTextBox39.Text = My.Settings.APKey
#Disable Warning BC42105 ' Die Funktion gibt nicht für alle Codepfade einen Wert zurück.
    End Function
#Enable Warning BC42105 ' Die Funktion gibt nicht für alle Codepfade einen Wert zurück.

    Private Sub FlatButton3_Click(sender As Object, e As EventArgs) Handles FlatButton3.Click
        My.Settings.Save()
        Me.Close()
    End Sub
End Class