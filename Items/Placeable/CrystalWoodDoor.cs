using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Placeable
{
	public class CrystalWoodDoor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Wood Door");
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 28;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = TileType<Tiles.CrystalWoodDoorClosed>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.WoodenDoor)
				.AddIngredient(ItemType<CrystalWood>(), 10)
				.AddTile(TileType<Tiles.CrystalWoodWorkbench>())
				.Register();
		}
	}
}