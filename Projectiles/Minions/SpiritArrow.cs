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
			ProjectileID.Sets.MinionShot[projectile.type] = true;
		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			//projectile.ranged = false;
			projectile.DamageType = DamageClass.Summon;
			projectile.damage = 105;
			projectile.width = 10;
			projectile.penetrate = 5;
			projectile.height = 20;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(0, projectile.Center);
			return base.OnTileCollide(oldVelocity);
		}
	}
}