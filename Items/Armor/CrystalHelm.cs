using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CrystalHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Helm");
			Tooltip.SetDefault("8% increased magic and summon damage"
				+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 15000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) *= 1.08f;
			player.GetDamage(DamageClass.Summon) *= 1.08f;
			player.maxMinions += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<CrystalBreastplate>() && legs.type == ItemType<CrystalLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Walking leaves behind damaging crystals";
			if (player.moveSpeed != 0)
			{
				player.AddBuff(BuffType<Buffs.CrystalLeak>(), 2);
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<RadiantPrism>(), 10)
				.AddIngredient(ItemType<ShinyGemstone>(), 15)
				.AddTile(Terraria.ID.TileID.Anvils)
				.Register();
		}
	}
}