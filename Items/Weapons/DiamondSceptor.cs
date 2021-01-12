using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class DiamondSceptor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Scepter");
			Tooltip.SetDefault("Launches an explosive diamond");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.DamageType = DamageClass.Magic;
			item.mana = 15;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ProjectileType<Projectiles.AmberDagger>();
			item.shootSpeed = 8f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.LightPurple;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(30) + 13));

			//create the first two projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<DiamondBomb>(), damage, knockBack, item.playerIndexTheItemIsReservedFor, 0f, 1f);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, ProjectileType<DiamondBomb>(), damage, knockBack, item.playerIndexTheItemIsReservedFor, 0f, 2f);

			//generate the remaining projectiles
			for (int i = 3; i <= 2; i++)
			{
				Vector2 randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(30) + 13));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, ProjectileType<DiamondBomb>(), damage, knockBack, item.playerIndexTheItemIsReservedFor, 0f, i);
			}
			return false;
		}
	}
}