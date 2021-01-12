using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class PrismBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism Blade");
			Tooltip.SetDefault("Consumes life.");
		}

		public override void SetDefaults()
		{
			item.damage = 277;
			item.DamageType = DamageClass.Melee;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.Swing;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool? UseItem(Player player)
		{
			for (int j = 1; j < 20; j++)
			{
				player.statLife--;
			}
			if (player.statLife <= 0)
			{
				//Main.player[item.owner].KillMe(9999, 1, true, " sacrificed too much");
			}
			return true;
		}
	}
}