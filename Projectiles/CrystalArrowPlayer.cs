using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class CrystalArrowPlayer : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Arrow");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(1);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
				for (int h = 0; h < 2; h++)
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

					Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, projType, Projectile.damage, 0, Projectile.owner);
				}
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
				for (int h = 0; h < 7; h++)
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

					Projectile.NewProjectile((Projectile.Center.X - 30) + Main.rand.Next(60), (Projectile.Center.Y - 30) + Main.rand.Next(60), vel.X, vel.Y, projType, Projectile.damage - 6, 0, Projectile.owner);
				}
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}