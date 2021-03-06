using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class SolarSickle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Crystal Sickle");
			Tooltip.SetDefault("'Shines with the ember of sunset'");
		}

		public override void SetDefaults()
		{
			Item.damage = 166;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 600000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.SolarCrystal>();
			Item.shootSpeed = 11f;
			Item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//create velocity vectors for the two angled projectiles (outwards at PI/15 radians)
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / 15);
			Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 15);

			//create three Crystishae projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI, 0, 0);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<CrystiliumBar>(), 15)
				.AddIngredient(ItemID.FragmentSolar, 15)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}