using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystalEdge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Edge");
			Tooltip.SetDefault("'Drenched in holy water'");
		}

		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 30000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 1f;

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

				Projectile.NewProjectile(hitbox.X + Main.rand.Next(40), hitbox.Y + Main.rand.Next(40), vel.X, vel.Y, projType, Item.damage, 0, Main.myPlayer);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			for (int j = 1; j < 3; j++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				/*		int proj = Projectile.NewProjectile(projectile.Center.X, item.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter"+(1+Main.rand.Next(0,3))), item.damage / 4, 0, Main.myPlayer); */
			}
		}
	}
}