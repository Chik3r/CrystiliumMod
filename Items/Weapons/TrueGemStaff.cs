using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueGemStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Gem Staff");
			Tooltip.SetDefault("'Ultimate gemstone power'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 3;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 40000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.AmberDagger>();
			Item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<EnchantedRubyStaff>())
				.AddIngredient(ItemType<EnchantedAmberStaff>())
				.AddIngredient(ItemType<EnchantedEmeraldStaff>())
				.AddIngredient(ItemType<EnchantedDiamondStaff>())
				.AddIngredient(ItemType<EnchantedSapphireStaff>())
				.AddIngredient(ItemType<EnchantedTopazStaff>())
				.AddIngredient(ItemType<EnchantedAmethystStaff>())
				.AddIngredient(ItemType<ShinyGemstone>(), 10)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//float SdirX = (Main.MouseWorld.X - player.position.X) * 8.5f;
			//float SdirY = (Main.MouseWorld.Y - player.position.Y) * 8.5f;
			float angle = (float)Math.Atan((float)Main.rand.Next(-12, 12));
			Projectile.NewProjectile(position.X, position.Y, speedX + angle, speedY + Main.rand.Next(-1, 1), ProjectileType<Projectiles.TrueGemFire>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}