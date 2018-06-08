Imports quartus.CSDK
Imports quartus.Offsets
Imports quartus.CUsefulFuncs
Public Class CAimbot

    Private Target As New CBasePlayer(Nothing)
    Private pTriggerPlayer As New CBasePlayer(Nothing)
    Private bounce As Boolean = True

    Public Sub Aimbot(Mode As Integer, Rage As Integer, AimspotRifles As Integer, AimspotPistols As Integer, AimspotSnipers As Integer, FovRifles As Integer, FovPistols As Integer, FovSnipers As Integer, SmoothRifles As Integer, SmoothPistol As Integer, SmoothSnipers As Integer)
        If GetAsyncKeyState(KeyBinds.AimKey) Then
            If pLocalPlayer.ActiveWeapon.Clip > 0 Then

                Dim _FOV1 As Single
                Dim _FOV2 As Single
                Dim _FOV3 As Single
                Dim _StopAfter1Shot As Boolean
                Dim _ID1 As Boolean
                Dim _ID2 As Boolean
                Dim _ID3 As Boolean
                Dim _ID4 As Boolean

                Select Case pLocalPlayer.ActiveWeapon.Type
                    Case ENUMS.WeaponType.Pistol
                        _FOV1 = My.Settings.FovPistols
                        _StopAfter1Shot = True
                        _ID1 = True
                    Case ENUMS.WeaponType.Sniper
                        _FOV2 = My.Settings.FovSnipers
                        _StopAfter1Shot = True
                        _ID2 = True
                    Case ENUMS.WeaponType.Rifle
                        _FOV3 = My.Settings.FovRifles
                        _StopAfter1Shot = False
                        _ID3 = True
                    Case ENUMS.WeaponType.SMG
                        _FOV3 = My.Settings.FovRifles
                        _StopAfter1Shot = False
                        _ID3 = True
                    Case ENUMS.WeaponType.Heavy
                        _FOV3 = My.Settings.FovRifles
                        _StopAfter1Shot = False
                        _ID3 = True
                    Case Else
                        _FOV3 = My.Settings.FovRifles
                        _StopAfter1Shot = True
                        _ID4 = True
                End Select

                If bounce Then
                    _FOV1 /= 10
                    _FOV2 /= 10
                    _FOV3 /= 10

                    If My.Settings.AimMode = 1 Then
                        Dim IncrossIndex As Integer = pLocalPlayer.IncrossIndex
                        If IncrossIndex > 0 And IncrossIndex < 65 Then
                            pTriggerPlayer.ptr = CBasePlayer.PointerByIndex(IncrossIndex)
                            'PISTOLS
                            If ENUMS.WeaponType.Pistol Then
                                If GetTargetFov(My.Settings.AimSpotPistols, My.Settings.RangeBased) Then
                                    If Not Target.ptr = Nothing Then bounce = False

                                    'SNIPERS
                                ElseIf ENUMS.WeaponType.Sniper Then
                                    If GetTargetFov(My.Settings.AimSpotSnipers, My.Settings.RangeBased) Then
                                        If Not Target.ptr = Nothing Then bounce = False

                                        'RIFLES
                                    ElseIf ENUMS.WeaponType.Rifle & ENUMS.WeaponType.SMG & ENUMS.WeaponType.Heavy Then
                                        If GetTargetFov(My.Settings.AimSpotRifles, My.Settings.RangeBased) Then
                                            If Not Target.ptr = Nothing Then bounce = False
                                        End If
                                    Else
                                        bounce = True
                                    End If
                                End If
                            End If
                        End If
                    ElseIf My.Settings.AimMode = 2 Then
                        'PISTOLS
                        If ENUMS.WeaponType.Pistol Then
                            If GetTargetFov(My.Settings.AimSpotPistols, My.Settings.RangeBased) <= _FOV1 Then
                                If Not Target.ptr = Nothing Then bounce = False

                                'SNIPERS
                            ElseIf ENUMS.WeaponType.Sniper Then
                                If GetTargetFov(My.Settings.AimSpotSnipers, My.Settings.RangeBased) <= _FOV2 Then
                                    If Not Target.ptr = Nothing Then bounce = False

                                    'RIFLES
                                ElseIf ENUMS.WeaponType.Rifle & ENUMS.WeaponType.SMG & ENUMS.WeaponType.Heavy <= _FOV3 Then
                                    If GetTargetFov(My.Settings.AimSpotRifles, My.Settings.RangeBased) Then
                                        If Not Target.ptr = Nothing Then bounce = False
                                    End If
                                Else
                                    bounce = True
                                End If
                            End If
                        End If
                    End If

                    If Not bounce And Target.ptr And Not Target.IsJumping Then

                        Dim Ang As New Vec3(0, 0, 0)

                        If My.Settings.RageAim = 1 Then
                            If _ID1 Then
                                Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(My.Settings.AimSpotPistols), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)), My.Settings.SmoothPistols)
                            ElseIf _ID2 Then
                                Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(My.Settings.AimSpotSnipers), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)), My.Settings.SmoothSnipers)
                            ElseIf _ID3 Or _ID4 Then
                                Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(My.Settings.AimSpotRifles), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)), My.Settings.SmoothRifles)
                            End If
                        Else
                            If Target.SpottedByMask And pLocalPlayer.ShotsFired < 1 And _ID1 Then
                                Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(My.Settings.AimSpotPistols), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)), My.Settings.SmoothPistols)
                            ElseIf Target.SpottedByMask And pLocalPlayer.ShotsFired < 1 And _ID2 Then
                                Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(My.Settings.AimSpotSnipers), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)), My.Settings.SmoothSnipers)
                            ElseIf Target.SpottedByMask And _ID3 Then
                                Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(My.Settings.AimSpotRifles), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)), My.Settings.SmoothRifles)
                            ElseIf Target.SpottedByMask And pLocalPlayer.ShotsFired < 1 And _ID4 Then
                                Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(My.Settings.AimSpotRifles), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)), My.Settings.SmoothRifles)
                            End If
                        End If

                        If Ang.x + Ang.y + Ang.z <> 0 Then Engine.SetAngles(ClampAngle(Ang))
                    End If


                    If Not IsValid(Target) Then
                        Sleep(My.Settings.SleepTime)
                        bounce = True
                    End If

                Else
                    bounce = True
                End If
            End If
        End If
    End Sub

    Private Function IsValid(trgt As CBasePlayer)
        If trgt.Health > 0 And Not trgt.Dormant Then Return True Else Return False
    End Function

    Private Function GetTargetFov(Bone As Integer, Rangebased As Boolean) As Single

        If My.Settings.RangeBased Then
            Return GetNextEnemyToCrosshairRangebased(Bone, Target.ptr) / 10
        Else
            Return GetNextEnemyToCrosshair(Bone, Target.ptr)
        End If
    End Function

    Public Function GetNextEnemyToCrosshairRangebased(Bone As Integer, ByRef pPointer As Integer) As Single
        Dim Fov As Single
        Dim pAngles As Vec3 = Engine.ViewAngles()

        Dim PlayerArray(32) As Integer
        Dim AngleArray(32) As Single

        For i As Integer = 1 To 32
            Dim CurPlayer As New CBasePlayer(CBasePlayer.PointerByIndex(i))

            Dim pAngle As Vec3 = CurPlayer.BonePosition(Bone)
            pAngle = CalcAngle(pLocalPlayer.OriginVec, pAngle, pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)
            pAngle = ClampAngle(pAngle)
            Dim iDiff As Single = Get3dDistance(pAngle, pAngles)

            PlayerArray(i) = CurPlayer.ptr
            AngleArray(i) = iDiff
        Next

        Dim ClosestPlayer As Integer = 0
        Dim ClosestAngle As Single = 360

        For i As Integer = 1 To 32
            Dim pPlayer As New CBasePlayer(PlayerArray(i))
            Dim pAngle As Single = AngleArray(i)

            Dim CurPlayerTeam As Integer = pPlayer.Team
            Dim Dormant As Boolean = pPlayer.Dormant
            Dim Health As Integer = pPlayer.Health

            Dim pOriginVec As Vec3 = pPlayer.OriginVec
            pOriginVec.z += 64

            If CurPlayerTeam <> pLocalPlayer.Team And (Not Dormant) And Health > 0 And pAngle < ClosestAngle Then
                ClosestPlayer = pPlayer.ptr
                ClosestAngle = pAngle
                Fov = pAngle
            End If
        Next

        Dim pNearestPlayer As New CBasePlayer(ClosestPlayer)
        Dim myAngle As Vec3 = ClampAngle(Engine.ViewAngles + pLocalPlayer.PunchAngle)
        Dim enemyAngle As Vec3 = CalcAngle(pLocalPlayer.OriginVec, pNearestPlayer.BonePosition(Bone), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)

        Dim AngleY = enemyAngle.y - myAngle.y
        If AngleY < 0 Then AngleY *= -1

        Dim AngleX = enemyAngle.x - myAngle.x
        If AngleX < 0 Then AngleX *= -1

        Dim r = Get3dDistance(pLocalPlayer.OriginVec, pNearestPlayer.OriginVec)

        Dim FovFractionY = Math.Sqrt(2 * r * r - 2 * r * r * Math.Cos(Deg2Rad(AngleY)))
        Dim FovFractionX = Math.Sqrt(2 * r * r - 2 * r * r * Math.Cos(Deg2Rad(AngleX)))

        Fov = Math.Sqrt((FovFractionY * FovFractionY) + (FovFractionX * FovFractionX))
        pPointer = ClosestPlayer

        Return Fov
    End Function

    Public Function Deg2Rad(input As Integer)
        Return input * Math.PI / 180
    End Function

    Public Function GetNextEnemyToCrosshair(Bone As Integer, ByRef pPointer As Integer) As Single
        Dim Fov As Single
        Dim pAngles As Vec3 = Engine.ViewAngles()

        Dim PlayerArray(32) As Integer
        Dim AngleArray(32) As Single


        For i As Integer = 1 To 32
            Dim CurPlayer As New CBasePlayer(CBasePlayer.PointerByIndex(i))

            Dim pAngle As Vec3 = CurPlayer.BonePosition(Bone)
            pAngle = CalcAngle(pLocalPlayer.OriginVec, pAngle, pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset)
            pAngle = ClampAngle(pAngle)
            Dim iDiff As Single = Get3dDistance(pAngle, pAngles)

            PlayerArray(i) = CurPlayer.ptr
            AngleArray(i) = iDiff
        Next

        Dim ClosestPlayer As Integer = 0
        Dim ClosestAngle As Single = 360

        For i As Integer = 1 To 32
            Dim pPlayer As New CBasePlayer(PlayerArray(i))
            Dim pAngle As Single = AngleArray(i)

            Dim CurPlayerTeam As Integer = pPlayer.Team
            Dim Dormant As Boolean = pPlayer.Dormant
            Dim Health As Integer = pPlayer.Health

            Dim pOriginVec As Vec3 = pPlayer.OriginVec

            pOriginVec.z += 64

            If CurPlayerTeam <> pLocalPlayer.Team And (Not Dormant) And Health > 0 And pAngle < ClosestAngle Then
                ClosestPlayer = pPlayer.ptr
                ClosestAngle = pAngle
                Fov = pAngle
            End If
        Next

        pPointer = ClosestPlayer

        Return Fov
    End Function

    Private Function CalcAngle(PlayerPosition As Vec3, EnemyPosition As Vec3, PunchAngle As Vec3, ViewOffset As Vec3)
        Dim RADPI As Single = 57.29578F
        Dim AimAngle As New Vec3(0, 0, 0)
        Dim Delta As New Vec3((PlayerPosition.x - EnemyPosition.x), (PlayerPosition.y - EnemyPosition.y), (PlayerPosition.z + ViewOffset.z) - EnemyPosition.z)
        Dim Hyp As Single = Math.Sqrt((Delta.x * Delta.x) + (Delta.y * Delta.y))

        AimAngle.x = Math.Atan(Delta.z / Hyp) * RADPI - (PunchAngle.x * 2.0)
        AimAngle.y = Math.Atan(Delta.y / Delta.x) * RADPI - (PunchAngle.y * 2.0)
        AimAngle.z = 0

        If Delta.x >= 0.0 Then AimAngle.y += 180.0F


        Return ClampAngle(AimAngle)
    End Function

    Private Function ClampAngle(ViewAngle As Vec3)
        If ViewAngle.x < -89.0F Then ViewAngle.x = -89.0F
        If ViewAngle.x > 89.0F Then ViewAngle.x = 89.0F
        If ViewAngle.y < -180.0F Then ViewAngle.y += 360.0F
        If ViewAngle.y > 180.0F Then ViewAngle.y -= 360.0F
        If ViewAngle.z <> 0.0F Then ViewAngle.z = 0.0F
        ViewAngle.z = 0F
        Return ViewAngle
    End Function

    Public Function Get3dDistance(PlayerPosition As Vec3, EnemyPosition As Vec3)
        Return Math.Sqrt(Math.Pow(EnemyPosition.x - PlayerPosition.x, 2.0F) + Math.Pow(EnemyPosition.y - PlayerPosition.y, 2.0F) + Math.Pow(EnemyPosition.z - PlayerPosition.z, 2.0F))
    End Function

    Public Function SmoothAng(AimAng As Vec3, SmoothPercent As Single)
        If SmoothPercent <= 10 Then Return ClampAngle(AimAng)
        SmoothPercent = SmoothPercent / 10
        Dim Delta As New Vec3(0, 0, 0)
        Dim ViewAngle As Vec3 = Engine.ViewAngles

        Delta.x = ViewAngle.x - AimAng.x
        Delta.y = ViewAngle.y - AimAng.y
        Delta.z = ViewAngle.z - AimAng.z
        Delta = ClampAngle(Delta)

        AimAng.x = ViewAngle.x - Delta.x / SmoothPercent
        AimAng.y = ViewAngle.y - Delta.y / SmoothPercent
        AimAng.z = ViewAngle.z - Delta.z / SmoothPercent

        Return ClampAngle(AimAng)
    End Function


End Class
