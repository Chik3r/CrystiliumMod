using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class DustbreakPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dustbreak Potion");
			Tooltip.SetDefault("Increases critical strike damage");
		}

		public override void SetDefaults()
		{
			Item.UseSound = SoundID.Item3;
			Item.useStyle = 2;
			Item.useTurn = true;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.width = 12;
			Item.height = 30;
			Item.value = 3000;
			Item.rare = 0;
			Item.buffType = BuffType<Buffs.Dustbreak>();
			Item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<CrystalBottleWater>())
				.AddIngredient(ItemType<RadiantPrism>())
				.AddIngredient(ItemID.GoldOre)
				.AddIngredient(ItemID.Amber)
				.AddIngredient(ItemID.Blinkroot)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}