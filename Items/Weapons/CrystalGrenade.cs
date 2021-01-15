using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystalGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Grenade");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Grenade);
			Item.damage = 35;
			Item.useTime = 60;
			Item.value = 1000;
			Item.useAnimation = 60;
			Item.rare = 3;
			Item.shoot = ProjectileType<Projectiles.CrystalGrenadeProj>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(5)
				.AddIngredient(ItemID.Grenade, 5)
				.AddIngredient(ItemType<ShinyGemstone>())
				.Register();
		}
	}
}