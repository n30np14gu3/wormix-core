namespace wormix_core.Pragmatix.Wormix.PvP;

public static class Actions
{
    public const uint WormLeft = 4096;
    public const uint WormRight = 4097;
    public const uint WormStop = 4098;
    public const uint WormJumpForward = 4099;
    public const uint WormJumpBack = 4100;
    public const uint WormJumpShoot = 4101;
    public const uint WormUse = 4358;
    public const uint WormBeef = 4103;
    
    public const uint CsUp = 8192;
    public const uint CsDown = 8193;
    public const uint CsLeft = 8194;
    public const uint CsRight = 8195;
    public const uint CsCharge = 8196;
    public const uint CsRelease = 8197;
    public const uint CsPouint = 8710;
    public const uint CsCounter = 8455;
    public const uint CsSet = 8456;
    
    public const uint WpnUpPress = 12288;
    public const uint WpnUpRelease = 12289;
    public const uint WpnDownPress = 12290;
    public const uint WpnDownRelease = 12291;
    public const uint WpnLeftPress = 12292;
    public const uint WpnLeftRelease = 12293;
    public const uint WpnRightPress = 12294;
    public const uint WpnRightRelease = 12295;
    public const uint WpnCharge = 12296;
    
    public const uint UiWeaponSelect = 16640;
    public const uint UiWeaponActivate = 16385;
    public const uint UiWeaponDeactivate = 16386;
    
    public const uint GameNextTurn = 20480;
    private const uint ParamCountMask = 3840;

    public static uint ParamCount(uint cmdId) => (cmdId & ParamCountMask) >> 8;
}