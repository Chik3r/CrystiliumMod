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
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 96;
			item.DamageType = DamageClass.Magic;
			item.mana = 3;
			item.width = 40;
			item.height = 40;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 100000;
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<AmberDagger>();
			item.shootSpeed = 10f;
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