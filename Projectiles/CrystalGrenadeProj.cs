using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class CrystalGrenadeProj : ModProjectile
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "CrystiliumMod/Items/Weapons/CrystalGrenade";
			return true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Grenade);
			projectile.name = "Crystal Grenade";
			projectile.timeLeft = 120;
			projectile.width = 26;
			projectile.height = 28;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			for (int h = 0; h < 25; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter" + (1 + Main.rand.Next(0, 3))), (int)(projectile.damage * .425), 0, Main.myPlayer);
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = true;
			}
		}
	}
}