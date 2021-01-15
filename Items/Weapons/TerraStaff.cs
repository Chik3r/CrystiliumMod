using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class TerraStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultimate Gem Staff");
			Tooltip.SetDefault("'Ultimate gemstone power'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 96;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 3;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 100000;
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<AmberDagger>();
			Item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<TrueRubyStaff>())
				.AddIngredient(ItemType<TrueEmeraldStaff>())
				.AddIngredient(ItemType<TrueDiamondStaff>())
				.AddIngredient(ItemType<TrueSapphireStaff>())
				.AddIngredient(ItemType<TrueAmethystStaff>())
				.AddIngredient(ItemType<TrueTopazStaff>())
				.AddIngredient(ItemType<TrueAmberStaff>())
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(20) + 8));

			//create the first two projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockBack, player.whoAmI, 0f, 1f);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockBack, player.whoAmI, 0f, 2f);

			//generate the remaining projectiles
			for (int i = 3; i <= 7; i++)
			{
				Vector2 randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(20) + 8));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, ProjectileType<Projectiles.TrueGems.TerraGemProj>(), damage, knockBack, player.whoAmI, 0f, i);
			}
			return false;
		}
	}
}