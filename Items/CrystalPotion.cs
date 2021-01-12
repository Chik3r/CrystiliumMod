using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class CrystalPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Potion");
			Tooltip.SetDefault("Makes shards of crystals damage nearby enemies.");
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
			item.value = 3000;
			item.rare = 0;
			item.buffType = BuffType<Buffs.CrystalLeak>();
			item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<CrystalBottleWater>())
				.AddIngredient(ItemType<ShinyGemstone>())
				.AddIngredient(ItemID.Moonglow)
				.AddIngredient(ItemID.Diamond)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}