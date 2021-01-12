using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Accessories
{
	public class RubyRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruby Ring");
			Tooltip.SetDefault("Your melee weapon flickers with heat");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = Item.sellPrice(0, 0, 85, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			// 20% chance of having Magma Stone effect each frame, equivalent of 20% chance of fire each strike
			if (Main.rand.Next(5) == 0)
				player.magmaStone = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.IronBar, 4)
				.AddIngredient(ItemID.Ruby, 3)
				.Register();
		}
	}
}