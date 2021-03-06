using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueTopazStaff : ModItem
	{
		private float DistY = 0f;
		private float DistX = 0f;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Topaz Staff");
			Tooltip.SetDefault("'A storm of a billion grains'");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 43; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 3; //How long it takes for the item to be used
			Item.useAnimation = 60; //How long the animation of the item takes
			Item.knockBack = 0f; //How much knockback the item produces
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
			Item.value = 120000; //How much the item is worth
			Item.rare = ItemRarityID.Yellow; //The rarity of the item
			Item.shoot = ProjectileType<Projectiles.SapphirePortal>();
			Item.shootSpeed = 7f; //How fast the projectile fires
			Item.mana = 90;
			Item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<Items.CrystiliumBar>(), 15)
				.AddIngredient(ItemType<Items.Weapons.EnchantedTopazStaff>())
				.AddIngredient(ItemType<Items.BrokenStaff>())
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
		{
			Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
			if (position.Y <= mouse.Y)
			{
				float Xdis = position.X - mouse.X;  // change myplayer to nearest player in full version
				float Ydis = position.Y - mouse.Y; // change myplayer to nearest player in full version
				float Angle = (float)Math.Atan(Xdis / Ydis);
				float DistXT = (float)(Math.Sin(Angle) * 54);
				float DistYT = (float)(Math.Cos(Angle) * 54);
				DistX = (position.X + DistXT);
				DistY = (position.Y + DistYT);
			}
			if (position.Y > mouse.Y)
			{
				float Xdis = position.X - mouse.X;  // change myplayer to nearest player in full version
				float Ydis = position.Y - mouse.Y; // change myplayer to nearest player in full version
				float Angle = (float)Math.Atan(Xdis / Ydis);
				float DistXT = (float)(Math.Sin(Angle) * 54);
				float DistYT = (float)(Math.Cos(Angle) * 54);
				DistX = (position.X + (0 - DistXT));
				DistY = (position.Y + (0 - DistYT));
			}
			Projectile.NewProjectile(DistX, DistY, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), ProjectileType<Projectiles.SandParticle>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}