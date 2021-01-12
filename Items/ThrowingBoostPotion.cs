using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class ThrowingBoostPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwing Boost Potion");
			Tooltip.SetDefault("Increases throwing damage");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 30;
			item.consumable = true;
			item.width = 12;
			item.height = 30;
			item.value = 3000;
			item.rare = 0;
			item.buffType = BuffType<Buffs.ThrowingBoost>();
			item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<CrystalBottleWater>())
				.AddIngredient(ItemType<ShinyGemstone>())
				.AddIngredient(ItemID.Deathweed)
				.AddIngredient(ItemID.Emerald)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}