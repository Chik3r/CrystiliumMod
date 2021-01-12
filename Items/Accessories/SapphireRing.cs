using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Accessories
{
	public class SapphireRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphire Ring");
			Tooltip.SetDefault("5% increased melee speed");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = Item.sellPrice(0, 0, 70, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeSpeed += .05f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.TungstenBar, 4)
				.AddIngredient(ItemID.Sapphire, 3)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.SilverBar, 4)
				.AddIngredient(ItemID.Sapphire, 3)
				.Register();
		}
	}
}