using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class CrystalKey : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Key");
			Tooltip.SetDefault("Unlocks the secrets of the shining caves");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 100000;
			Item.rare = 3;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<ShinyGemstone>(), 5)
				.AddIngredient(ItemID.GoldenKey)
				.Register();
		}
	}
}