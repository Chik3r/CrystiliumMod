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
			item.width = 40;
			item.height = 40;
			item.value = 30000;
			item.rare = ItemRarityID.Orange;
			item.defense = 3;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Magic) *= 1.1f;
			player.GetDamage(DamageClass.Ranged) *= 1.1f;
			player.GetCrit(DamageClass.Magic) += 10;
			player.GetCrit(DamageClass.Ranged) += 10;
		}
	}
}