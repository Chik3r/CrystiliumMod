using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class RoyalShredder : ModItem
	{
		private Vector2 newVect;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Shredder");
			Tooltip.SetDefault("'Crush your enemies'");
		}

		public override void SetDefaults()
		{
			Item.damage = 54;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.Shatter1>(); //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 14f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			if (Main.rand.Next(2) == 0)
			{
				newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(900, 1800) / 10));
			}
			else
			{
				newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(900, 1800) / 10));
			}

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

			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, projType, damage - 5, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}