using CrystiliumMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class CrystalFire : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Fire");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(82);
			projectile.hostile = false;
			projectile.DamageType = DamageClass.Magic;
			projectile.width = 28;
			projectile.light = 0.5f;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.damage = 10;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			}
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<CrystalDust>(), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
			}
			return false;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType<CrystalDust>(), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
				Main.player[projectile.owner].statMana += 10;
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