using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class GeodePickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Geode Pickaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.DamageType = DamageClass.Melee;
			item.width = 40;
			item.height = 40;
			item.useTime = 13;
			item.useAnimation = 13;
			item.pick = 150;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 20000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<EnchantedGeode>(), 12)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}