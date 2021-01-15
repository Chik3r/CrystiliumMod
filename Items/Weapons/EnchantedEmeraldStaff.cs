using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedEmeraldStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Emerald staff");
			Tooltip.SetDefault("'Wield the power of the forest'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 27;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 11;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 30000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.Leaf>();
			Item.shootSpeed = 1f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 55f * 0.0174f;//45 degrees converted to radians
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY) * 3;
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
			speedX = baseSpeed * (float)Math.Sin(randomAngle);
			speedY = baseSpeed * (float)Math.Cos(randomAngle);
			Projectile.NewProjectile(position.X, position.Y, speedX - 0.5f, speedY - 0.5f, ProjectileType<Projectiles.Leaf>(), damage, knockBack, player.whoAmI);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.EmeraldStaff)
				.AddIngredient(ItemID.Emerald, 15)
				.AddIngredient(ItemType<ShinyGemstone>(), 10)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}