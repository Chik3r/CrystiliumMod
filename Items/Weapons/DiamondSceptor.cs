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
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = ProjectileType<Projectiles.AmberDagger>();
			Item.shootSpeed = 8f;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.LightPurple;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(30) + 13));

			//create the first two projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<DiamondBomb>(), damage, knockBack, Item.playerIndexTheItemIsReservedFor, 0f, 1f);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, ProjectileType<DiamondBomb>(), damage, knockBack, Item.playerIndexTheItemIsReservedFor, 0f, 2f);

			//generate the remaining projectiles
			for (int i = 3; i <= 2; i++)
			{
				Vector2 randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(30) + 13));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, ProjectileType<DiamondBomb>(), damage, knockBack, Item.playerIndexTheItemIsReservedFor, 0f, i);
			}
			return false;
		}
	}
}