using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Placeable
{
	public class BootlegFountain : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bootleg Crystal Fountain");
			Tooltip.SetDefault("'Looks the same, but is illegal in 48 states'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = TileType<Tiles.BootlegFountain>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<ShinyGemstone>(), 15)
				.AddIngredient(ItemType<RadiantPrism>(), 10)
				.Register();
		}
	}
}