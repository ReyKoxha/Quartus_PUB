Imports quartus.Offsets
Imports quartus.CSDK
Public Class CBasePlayer
    Public ptr As Integer

    Public Sub New(Pointer As Integer)
        ptr = Pointer
    End Sub

    Public Shared Function LocalPlayer() As Integer
        Return mem.RdInt(mem.ClientDLL + dwLocalPlayer)
    End Function

    Public Shared Function PointerByIndex(Index As Integer) As Integer
        Return mem.RdInt(mem.ClientDLL + dwEntityList + ((Index - 1) * 16))
    End Function

    Public Function Health() As Integer
        Return mem.RdInt(ptr + m_iHealth)
    End Function

    Public Function FFlags() As Integer
        Return mem.RdInt(ptr + m_fFlags)
    End Function

    Public Function Team() As Integer
        Return mem.RdInt(ptr + m_iTeamNum)
    End Function

    Public Function Dormant() As Boolean
        Return mem.RdInt(ptr + m_bDormant)
    End Function

    Public Function FlashDuration() As Integer
        Return mem.RdFloat(ptr + m_flFlashDuration)
    End Function

    Public Function FlashMaxAlpha() As Integer
        Return mem.RdInt(ptr + m_flFlashMaxAlpha)
    End Function

    Public Function OriginVec() As Vec3
        Return mem.ReadMemory(Of Vec3)(ptr + m_vecOrigin)
    End Function

    Public Function PunchAngle() As Vec3
        Return mem.ReadMemory(Of Vec3)(ptr + m_aimPunchAngle)
    End Function

    Public Function ViewOffset() As Vec3
        Return mem.ReadMemory(Of Vec3)(ptr + m_vecViewOffset)
    End Function

    Public Function Spotted() As Boolean
        Return mem.RdInt(ptr + m_bSpotted)
    End Function

    Public Function ShotsFired() As Integer
        Return mem.RdInt(ptr + m_iShotsFired)
    End Function

    Public Function IncrossIndex()
        Return mem.RdInt(ptr + m_iCrosshairId)
    End Function

    Public Function Name(Index As Integer) As String
        Dim RadarBase As Integer = mem.RdInt(mem.ClientDLL + dwRadarBase)
        Dim Radar As Integer = mem.RdInt(RadarBase + &H20)
        Dim sName As String = mem.RdString(Radar + (&H1EC * (Index) + &H3C))
        Return sName
    End Function

    Public Function IsJumping() As Boolean
        Dim fflags As Integer = mem.RdInt(ptr + m_fFlags)
        If fflags = 770 Or fflags = 774 Then Return True Else Return False
    End Function

    Public Function Immune() As Boolean
        Return mem.RdInt(ptr + m_bGunGameImmunity)
    End Function

    Public Function SpottedByMask() As Boolean
        Try
            Dim y As String = CUsefulFuncs.ConvertToBinary(mem.RdInt(ptr + m_bSpottedByMask), 30)
            Dim x As Char = y(y.Count - mem.RdInt(LocalPlayer() + &H64))
            If x = "1" Then Return True Else Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function BonePosition(BoneID As Integer) As Vec3
        Dim BoneMatrix As Integer = mem.RdInt(ptr + m_dwBoneMatrix)
        Dim buffer As Byte() = New Byte(36) {}
        buffer = mem.RdMem(BoneMatrix + &H30 * BoneID + &HC, 36)
        Return New Vec3(BitConverter.ToSingle(buffer, 0), BitConverter.ToSingle(buffer, 16), BitConverter.ToSingle(buffer, 32))
    End Function

    Public Function ActiveWeapon() As CBaseWeapon
        Dim WeaponIndex As Integer = mem.RdInt(ptr + m_hActiveWeapon) And &HFFFF
        Return New CBaseWeapon(mem.RdInt(mem.ClientDLL + dwEntityList + (WeaponIndex - 1) * &H10))
    End Function


    Public Function Velocity() As Single
        Return mem.ReadMemory(Of Vec3)(LocalPlayer() + m_vecVelocity).Length
    End Function

    Public Sub Glow(Glow_r As Single, Glow_g As Single, Glow_b As Single, Glow_a As Single, Glow_rwo As Boolean, Glow_rwuo As Boolean, Glow_fb As Boolean)
        Dim GlowIndex As Integer = mem.RdInt(ptr + m_iGlowIndex)
        Dim GlowObjectManager As Integer = mem.RdInt(mem.ClientDLL + dwGlowObjectManager)
        Dim GlowObject As CESP.GlowObject_t = mem.ReadMemory(Of CESP.GlowObject_t)(GlowObjectManager + (GlowIndex * &H38))

        GlowObject.r = Glow_r
        GlowObject.g = Glow_g
        GlowObject.b = Glow_b
        GlowObject.a = Glow_a
        GlowObject.RenderWhenOccluded = Glow_rwo
        GlowObject.RenderWhenUnoccluded = Glow_rwuo
        GlowObject.FullBloom = Glow_fb

        mem.WriteStruct(Of CESP.GlowObject_t)(GlowObjectManager + (GlowIndex * &H38), GlowObject)
    End Sub

    Public Structure Clr_s
        Dim r As Byte
        Dim g As Byte
        Dim b As Byte
        Dim a As Byte
    End Structure

    Public clr As New Clr_s

    Public Sub ClrRender(R As Byte, G As Byte, B As Byte, A As Byte)
        clr.r = R
        clr.g = G
        clr.b = B
        clr.a = A
        mem.WriteStruct(Of Clr_s)(ptr + m_clrRender, clr)
    End Sub

    Public Shared Sub ForceJump(val As Integer)
        mem.WrtInt(mem.ClientDLL + dwForceJump, val)
    End Sub

    Public Shared Sub ForceAttack(Delay1 As Integer, Delay2 As Integer, Delay3 As Integer)
        CUsefulFuncs.Sleep(Delay1)
        mem.WrtInt(mem.ClientDLL + dwForceAttack, 5)
        CUsefulFuncs.Sleep(Delay2)
        mem.WrtInt(mem.ClientDLL + dwForceAttack, 4)
        CUsefulFuncs.Sleep(Delay3)
    End Sub

    Public Shared Sub ForceAutopistol(val As Integer)
        mem.WrtInt(mem.ClientDLL + dwForceAttack, val)
    End Sub
End Class
