Imports quartus.CSDK
Imports quartus.Offsets
Imports quartus.CUsefulFuncs
Imports quartus.ENUMS
Imports System.Runtime.InteropServices
Imports System.Drawing

Public Class CESP
    Public Shared pEspPlayer As New CBasePlayer(Nothing)
    Dim rnd As New Random

    Public Structure Color_t
        Dim R As Single
        Dim G As Single
        Dim B As Single
        Dim A As Single
    End Structure

    Public Structure GlowObject_t
        Dim pEntity As Integer
        Dim r As Single
        Dim g As Single
        Dim b As Single
        Dim a As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)>
        Public unk1 As Byte()
        Dim RenderWhenOccluded As Boolean
        Dim RenderWhenUnoccluded As Boolean
        Dim FullBloom As Boolean
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)>
        Public unk2 As Byte()
    End Structure

    Public Structure Clr_s
        Dim r As Byte
        Dim g As Byte
        Dim b As Byte
        Dim a As Byte
    End Structure

    Public clr As New Clr_s
    Dim Col As New Color_t

    Public Sub GlowESP(Esp As Boolean, Toggable As Boolean, Mode As Integer)

        If Toggable Then
            If GetAsyncKeyState(KeyBinds.ESPKey) Then
                If Mode = 1 Then
                    Do
                        GlowESPplayersonly(Esp)
                    Loop Until GetAsyncKeyState(KeyBinds.ESPKey)
                ElseIf Mode = 2 Then
                    Do
                        GlowESPall(Esp)
                    Loop Until GetAsyncKeyState(KeyBinds.ESPKey)
                End If
            End If
        Else
            If Mode = 1 Then
                GlowESPplayersonly(Esp)
            ElseIf Mode = 2 Then
                GlowESPall(Esp)
            End If
        End If
    End Sub

    Public Sub GlowESPplayersonly(Esp As Boolean)
        For i = 1 To MAXPLAYERS
            pEspPlayer.ptr = CBasePlayer.PointerByIndex(i)

            If pEspPlayer.Dormant Then Continue For
            If pEspPlayer.Health < 1 Then Continue For
            If pEspPlayer.Team = pLocalPlayer.Team Then Continue For

            If Esp And pEspPlayer.SpottedByMask Then
                pEspPlayer.Glow(My.Settings.ESPcolorEnemyVisR / 255, My.Settings.ESPcolorEnemyVisG / 255, My.Settings.ESPcolorEnemyVisB / 255, My.Settings.ESPcolorEnemyVisA / 255, True, False, False)
            ElseIf Esp Then
                pEspPlayer.Glow(My.Settings.ESPcolorEnemyR / 255, My.Settings.ESPcolorEnemyG / 255, My.Settings.ESPcolorEnemyB / 255, My.Settings.ESPcolorEnemyA / 255, True, False, False)
            End If
        Next
    End Sub

    Public GlowObject As GlowObject_t

    Public Sub GlowESPall(Esp As Boolean)
        Dim GlowObjectManager As Integer = mem.RdInt(mem.ClientDLL + dwGlowObjectManager)
        Dim GlowObjectCount As Integer = mem.RdInt(mem.ClientDLL + dwGlowObjectManager + &H4)

        If GlowObjectCount > 1 Then
            For i = 1 To GlowObjectCount
                If mem.RdInt(GlowObjectManager + (i * &H38)) Then
                    GlowObject = mem.ReadMemory(Of GlowObject_t)(GlowObjectManager + (i * &H38))
                    If GlowObject.pEntity Then
                        Dim ClassID As Integer = GetClassID(mem.RdInt(GlowObjectManager + (i * &H38)))
                        GlowObject = SetColor(ClassID, GlowObject, mem.RdInt(GlowObjectManager + (i * &H38)))
                        mem.WriteStruct(Of GlowObject_t)(GlowObjectManager + (i * &H38), GlowObject)
                    End If
                End If
            Next
        End If
    End Sub

    Private Function GetClassID(add As Integer) As Integer
        Dim one As Integer = mem.RdInt(add + &H8)
        Dim two As Integer = mem.RdInt(one + 2 * &H4)
        Dim three As Integer = mem.RdInt(two + 1)
        Dim ClassID As Integer = mem.RdInt(three + 20)
        Return ClassID
    End Function

    Private Function SetColor(cID As Integer, GlowObject As GlowObject_t, ptr As Integer) As GlowObject_t
        Select Case cID
            Case ClassID.CSPlayer
                pEspPlayer.ptr = ptr
                If pEspPlayer.Team <> pLocalPlayer.Team Then
                    If pEspPlayer.SpottedByMask Then
                        GlowObject.r = My.Settings.ESPcolorEnemyVisR / 255
                        GlowObject.g = My.Settings.ESPcolorEnemyVisG / 255
                        GlowObject.b = My.Settings.ESPcolorEnemyVisB / 255
                        GlowObject.a = My.Settings.ESPcolorEnemyVisA / 255

                    Else
                        GlowObject.r = My.Settings.ESPcolorEnemyR / 255
                        GlowObject.g = My.Settings.ESPcolorEnemyG / 255
                        GlowObject.b = My.Settings.ESPcolorEnemyB / 255
                        GlowObject.a = My.Settings.ESPcolorEnemyA / 255

                    End If
                Else
                    GlowObject.r = My.Settings.ESPcolorTeammateR / 255
                    GlowObject.g = My.Settings.ESPcolorTeammateG / 255
                    GlowObject.b = My.Settings.ESPcolorTeammateB / 255
                    GlowObject.a = My.Settings.ESPcolorTeammateA / 255
                End If

            Case ClassID.AK47, ClassID.DEagle, ClassID.WeaponAug, ClassID.WeaponBizon, ClassID.WeaponElite, ClassID.WeaponGalilAR, ClassID.WeaponUMP45, ClassID.WeaponMAC10, ClassID.WeaponFiveSeven, ClassID.WeaponTec9, ClassID.WeaponXM1014, ClassID.WeaponSawedoff, ClassID.WeaponAWP, ClassID.WeaponG3SG1, ClassID.WeaponGalil, ClassID.WeaponGlock, ClassID.WeaponHKP2000, ClassID.WeaponM249, ClassID.WeaponM4A1, ClassID.WeaponM3, ClassID.WeaponMP7, ClassID.WeaponMP9, ClassID.WeaponMP5Navy, ClassID.WeaponMag7, ClassID.WeaponNOVA, ClassID.WeaponNegev, ClassID.WeaponP250, ClassID.WeaponP90, ClassID.WeaponSCAR20, ClassID.SCAR17, ClassID.WeaponSG552, ClassID.WeaponSG556, ClassID.WeaponSSG08, ClassID.WeaponBizon
                GlowObject.r = My.Settings.ESPcolorWeaponsR / 255
                GlowObject.g = My.Settings.ESPcolorWeaponsG / 255
                GlowObject.b = My.Settings.ESPcolorWeaponsB / 255
                GlowObject.a = My.Settings.ESPcolorWeaponsA / 255

            Case ClassID.BaseCSGrenadeProjectile, ClassID.DecoyGrenade, ClassID.DecoyProjectile, ClassID.HEGrenade, ClassID.SmokeGrenade, ClassID.MolotovGrenade, ClassID.SmokeGrenadeProjectile, ClassID.MolotovProjectile, ClassID.IncendiaryGrenade, ClassID.Flashbang, ClassID.ParticleSmokeGrenade, ClassID.ParticleFire
                GlowObject.r = My.Settings.ESPcolorGrenadesR / 255
                GlowObject.g = My.Settings.ESPcolorGrenadesG / 255
                GlowObject.b = My.Settings.ESPcolorGrenadesB / 255
                GlowObject.a = My.Settings.ESPcolorGrenadesA / 255

            Case ClassID.C4, ClassID.PlantedC4
                GlowObject.r = My.Settings.ESPcolorBombR / 255
                GlowObject.g = My.Settings.ESPcolorBombG / 255
                GlowObject.b = My.Settings.ESPcolorBombB / 255
                GlowObject.a = My.Settings.ESPcolorBombA / 255

            Case ClassID.Chicken
                GlowObject.r = My.Settings.ESPcolorChickenR / 255
                GlowObject.g = My.Settings.ESPcolorChickenG / 255
                GlowObject.b = My.Settings.ESPcolorChickenB / 255
                GlowObject.a = My.Settings.ESPcolorChickenA / 255

            Case Else
                GlowObject.RenderWhenOccluded = False
                GlowObject.RenderWhenUnoccluded = False
                GlowObject.FullBloom = False
                Return GlowObject
        End Select
        GlowObject.RenderWhenOccluded = True
        GlowObject.RenderWhenUnoccluded = False
        GlowObject.FullBloom = False
        Return GlowObject
    End Function

    Public Function GetRenderColorFromGlowObject(GlowObject As GlowObject_t) As Clr_s
        clr.r = 255 * GlowObject.r
        clr.g = 255 * GlowObject.g
        clr.b = 255 * GlowObject.b
        clr.a = 255 * GlowObject.a
        Return clr
    End Function
End Class