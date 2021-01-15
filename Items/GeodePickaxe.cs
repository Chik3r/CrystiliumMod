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
			Item.damage = 30;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.pick = 150;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 20000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
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