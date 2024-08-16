using wormix_core.Controllers.Http.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;

[ApiPost("craft/upgrade_weapon")]
public class UpgradeWeaponController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        return new UpgradeWeaponResult
        {
            Result = 0,
            RecipeId = ((UpgradeWeapon)gameSerializable).RecipeId
        };
    }
}