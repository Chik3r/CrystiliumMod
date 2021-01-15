using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles.Minions
{
	public class SpiritArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.MinionShot[Projectile.type] = true;
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			//projectile.ranged = false;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.damage = 105;
			Projectile.width = 10;
			Projectile.penetrate = 5;
			Projectile.height = 20;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(0, Projectile.Center);
			return base.OnTileCollide(oldVelocity);
		}
	}
}