using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class ShatterangProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shatterang");
		}

		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = 3;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			//projectile.magic = false;
			Projectile.penetrate = 10;
			Projectile.timeLeft = 600;
			Projectile.light = 0.5f;
			Projectile.extraUpdates = 1;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int h = 0; h < 22; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;

				int projType = 0;
				switch (Main.rand.Next(0, 3))
				{
					case 0:
						projType = ProjectileType<Shatter1>();
						break;
					case 1:
						projType = ProjectileType<Shatter2>();
						break;
					case 2:
						projType = ProjectileType<Shatter3>();
						break;
				}

				Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y + 20, vel.X, vel.Y, projType, Projectile.damage / 3, 0, Main.myPlayer);
			}
		}
	}
}