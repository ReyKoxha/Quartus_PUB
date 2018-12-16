Imports quartus.CSDK
Public Class Offsets
    Public Shared m_bDormant = &HED
    Public Shared m_clrRender = &H70
    Public Shared m_dwInGame = &H108
    Public Shared m_nModelIndex = &H254
    Public Shared m_hViewModel = &H32DC
    Public Shared m_iWorldModelIndex = &H3214
    Public Shared m_szArmsModel = &H3907
    Public Shared m_iObserverMode = &H334C

    Public Shared m_bGunGameImmunity = ofs.Read("netvars", "m_bGungameImmunity")
    Public Shared m_bSpotted = ofs.Read("netvars", "m_bSpotted")
    Public Shared m_bSpottedByMask = ofs.Read("netvars", "m_bSpottedByMask")
    Public Shared m_dwBoneMatrix = ofs.Read("netvars", "m_dwBoneMatrix")
    Public Shared m_fFlags = ofs.Read("netvars", "m_fFlags")
    Public Shared m_iItemIDHigh = ofs.Read("netvars", "m_iItemIDHigh")
    Public Shared m_OriginalOwnerXuidHigh = ofs.Read("netvars", "m_OriginalOwnerXuidHigh")
    Public Shared m_OriginalOwnerXuidLow = ofs.Read("netvars", "m_OriginalOwnerXuidLow")
    Public Shared m_nFallbackPaintKit = ofs.Read("netvars", "m_nFallbackPaintKit")
    Public Shared m_nFallbackSeed = ofs.Read("netvars", "m_nFallbackSeed")
    Public Shared m_nFallbackStatTrak = ofs.Read("netvars", "m_nFallbackStatTrak")
    Public Shared m_flFallbackWear = ofs.Read("netvars", "m_flFallbackWear")
    Public Shared m_iAccountID = ofs.Read("netvars", "m_iAccountID")
    Public Shared m_iHealth = ofs.Read("netvars", "m_iHealth")
    Public Shared m_iTeamNum = ofs.Read("netvars", "m_iTeamNum")
    Public Shared m_flFlashDuration = ofs.Read("netvars", "m_flFlashDuration")
    Public Shared m_flFlashMaxAlpha = ofs.Read("netvars", "m_flFlashMaxAlpha")
    Public Shared m_vecOrigin = ofs.Read("netvars", "m_vecOrigin")
    Public Shared m_aimPunchAngle = ofs.Read("netvars", "m_aimPunchAngle")
    Public Shared m_vecViewOffset = ofs.Read("netvars", "m_vecViewOffset")
    Public Shared m_iShotsFired = ofs.Read("netvars", "m_iShotsFired")
    Public Shared m_iCrosshairId = ofs.Read("netvars", "m_iCrosshairId")
    Public Shared m_hActiveWeapon = ofs.Read("netvars", "m_hActiveWeapon")
    Public Shared m_vecVelocity = ofs.Read("netvars", "m_vecVelocity")
    Public Shared m_iItemDefinitionIndex = ofs.Read("netvars", "m_iItemDefinitionIndex")
    Public Shared m_iGlowIndex = ofs.Read("netvars", "m_iGlowIndex")
    Public Shared m_iClip1 = ofs.Read("netvars", "m_iClip1")
    Public Shared m_hMyWeapons = ofs.Read("netvars", "m_hMyWeapons")
    Public Shared m_iCompetitiveWins = ofs.Read("netvars", "m_iCompetitiveWins")
    Public Shared m_iCompetitiveRanking = ofs.Read("netvars", "m_iCompetitiveRanking")
    Public Shared dwLocalPlayer = ofs.Read("signatures", "dwLocalPlayer")

    Public Shared dwEntityList = FindPattern.Scanf(mem.ClientDLL, "BB????????83FF010F8C????????3BF8", 1, 0, True)
    Public Shared dwClientState = FindPattern.Scanf(mem.EngineDLL, "A1????????33D26A006A0033C989B0", 1, 0, True)
    Public Shared dwForceAttack = FindPattern.Scanf(mem.ClientDLL, "890D????????8B0D????????8BF28BC183CE04", 2, 0, True)
    Public Shared dwForceJump = FindPattern.Scanf(mem.ClientDLL, "8B0D????????8BD68BC183CA02", 2, 0, True)
    Public Shared dwGlowObjectManager = FindPattern.Scanf(mem.ClientDLL, "A1????????A801754B", &H1, &H4, True)
    Public Shared dwRadarBase = FindPattern.Scanf(mem.ClientDLL, "A1????????8B0CB08B01FF50??463B35????????7CEA8B0D", 1, 0, True)
    Public Shared dwViewAngles = FindPattern.Scanf(mem.EngineDLL, "F30F1180????????D94604D905", 4, 0, False)
    Public Shared dwGlobalVars = FindPattern.Scanf(mem.EngineDLL, "68????????68????????FF500885C0", 4, 0, False)
    Public Shared dwPlayerResource = FindPattern.Scanf(mem.ClientDLL, "8B3D????????85FF0F84????????81C7", 2, 0, True)
End Class
