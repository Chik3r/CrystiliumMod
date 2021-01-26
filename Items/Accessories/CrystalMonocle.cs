using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace CrystiliumMod.Items.Accessories
{
	public class CrystalMonocle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Monocle");
			Tooltip.SetDefault("+10% Magic and ranged damage and Crit chance"
				+"\n+10% Magic and ranged critical strike chance"
				+"\nColorful distortion");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = 30000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 3;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Magic) *= 1.1f;
			player.GetDamage(DamageClass.Ranged) *= 1.1f;
			player.GetCritChance(DamageClass.Magic) += 10;
			player.GetCritChance(DamageClass.Ranged) += 10;
		}
	}
}