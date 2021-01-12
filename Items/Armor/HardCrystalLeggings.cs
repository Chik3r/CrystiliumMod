using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class HardCrystalLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hard Crystal Leggings");
			Tooltip.SetDefault("Increases maximum minions by 2");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 30000;
			item.rare = 5;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 2;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CrystalShard, 15)
				.AddIngredient(ItemType<Items.EnchantedGeode>(), 10)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}