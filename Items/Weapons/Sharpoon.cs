using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Sharpoon : ModItem
	{
		private Vector2 newVect;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharp Shooter");
			Tooltip.SetDefault("'Smooth as a crystal'");
		}

		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 48;
			Item.useAnimation = 48;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 11f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			for (int X = 0; X <= 4; X++)
			{
				if (Main.rand.Next(2) == 0)
				{
					newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				}
				else
				{
					newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				}
				newVect *= 0.4f;

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

				Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, projType, damage - 9, knockBack, player.whoAmI, 0f, 0f);
			}
			return true;
		}
	}
}