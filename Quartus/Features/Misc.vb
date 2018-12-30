Imports quartus.CSDK
Imports quartus.Offsets
Imports quartus.CUsefulFuncs
Imports System.Threading
Imports Microsoft.VisualBasic.Devices

Public Class CMisc

    Private pRadarPlayer As New CBasePlayer(Nothing)

    Public Sub Bhop()
        If GetAsyncKeyState(32) And pLocalPlayer.Velocity > 20 Then
            Dim fflags As Integer = pLocalPlayer.FFlags
            If fflags < 263 And fflags <> 257 Then
                CBasePlayer.ForceJump(4)
            Else
                CBasePlayer.ForceJump(5)
            End If
        End If
    End Sub

    Public Sub Radar()
    For i = 1 To MAXPLAYERS
        pRadarPlayer.ptr = CBasePlayer.PointerByIndex(i)
        If pRadarPlayer.Spotted = 0 And pRadarPlayer.Health > 0 And Not pRadarPlayer.Dormant Then mem.WrtInt(pRadarPlayer.ptr + m_bSpotted, 1)
    Next
End Sub

    Public Sub Noflash(value As Integer)
        If pLocalPlayer.FlashMaxAlpha <> value Then
            mem.WrtFloat(pLocalPlayer.ptr + m_flFlashMaxAlpha, value)
        End If
    End Sub

    Public Sub AutoPistol()
        If pLocalPlayer.ActiveWeapon.Type = ENUMS.WeaponType.Pistol Then
            If GetAsyncKeyState(KeyBinds.APKey) Then
                CBasePlayer.ForceAutopistol(5)
                Sleep(15)
                CBasePlayer.ForceAutopistol(4)
            End If
        End If
    End Sub
End Class


