using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CrystalBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Breastplate");
			Tooltip.SetDefault("10% increased magic and summon damage"
				+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 20000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) *= 1.1f;
			player.GetDamage(DamageClass.Summon) *= 1.1f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<Items.RadiantPrism>(), 15)
				.AddIngredient(ItemType<Items.ShinyGemstone>(), 25)
				.AddTile(Terraria.ID.TileID.Anvils)
				.Register();
		}
	}
}