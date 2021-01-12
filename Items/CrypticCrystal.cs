using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class CrypticCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryptic Crystal");
			Tooltip.SetDefault("Use at the heart of the Crystal"
				+ "\n'Boast of thy Treasures, and Dragons will come...'");
		}

		public override void SetDefaults()
		{
			item.consumable = true;
			item.rare = 7;
		}

		public override bool CanUseItem(Player player)
		{
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Ectoplasm, 10)
				.AddIngredient(ItemID.CrystalShard, 10)
				.AddIngredient(ItemType<EnchantedGeode>(), 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}