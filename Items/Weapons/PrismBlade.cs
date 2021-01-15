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
			Item.damage = 277;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.LightPurple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
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