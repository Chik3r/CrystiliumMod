using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class EnchantedCrystalArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Crystal Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(1);
			projectile.damage = 10;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
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

					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, projType, projectile.damage - 20, 0, Main.myPlayer);
				}
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
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

					Projectile.NewProjectile((projectile.Center.X - 30) + Main.rand.Next(60), (projectile.Center.Y - 30) + Main.rand.Next(60), vel.X, vel.Y, projType, projectile.damage - 20, 0, Main.myPlayer);
				}
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[projectile.type].Value.Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(TextureAssets.Projectile[projectile.type].Value, drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}