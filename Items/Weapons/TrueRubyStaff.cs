﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	internal class TrueRubyStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Ruby Staff");
			Tooltip.SetDefault("Shoots homing fireballs of doom");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 30; //The damage
			item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.useTime = 5; //How long it takes for the item to be used
			item.useAnimation = 5; //How long the animation of the item takes
			item.knockBack = 1f; //How much knockback the item produces
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
			item.value = 120000; //How much the item is worth
			item.rare = ItemRarityID.Yellow; //The rarity of the item
			item.shoot = ProjectileType<Projectiles.TrueRubyProjectile>(); //What the item shoots, retains an int value | *
			item.shootSpeed = 7f; //How fast the projectile fires
			item.mana = 2;
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<Items.CrystiliumBar>(), 15)
				.AddIngredient(ItemType<Items.Weapons.EnchantedRubyStaff>())
				.AddIngredient(ItemType<Items.BrokenStaff>())
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}