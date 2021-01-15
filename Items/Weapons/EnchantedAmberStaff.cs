using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedAmberStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Amber Staff");
			Tooltip.SetDefault("Creates sharp daggers");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 9;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 30000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<AmberDagger>();
			Item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Amber, 15)
				.AddIngredient(ItemID.AmberStaff)
				.AddIngredient(ItemType<ShinyGemstone>(), 10)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//float SdirX = (Main.MouseWorld.X - player.position.X) * 8.5f;
			//float SdirY = (Main.MouseWorld.Y - player.position.Y) * 8.5f;
			float angle = (float)Math.Atan(12f);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - angle, ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + angle, ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - (2 * angle), ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + (2 * angle), ProjectileType<AmberDagger>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}