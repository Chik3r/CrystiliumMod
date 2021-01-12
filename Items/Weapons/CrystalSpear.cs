using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystalSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Spear");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.DamageType = DamageClass.Throwing;
			item.channel = true;
			item.noMelee = true;
			item.consumable = true;
			item.maxStack = 999;
			item.shoot = ProjectileType<Projectiles.CrystalSpear>();
			item.useAnimation = 21;
			item.useTime = 21;
			item.shootSpeed = 8.5f;
			item.damage = 21;
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.crit = 12;
			item.rare = ItemRarityID.Orange;
			item.autoReuse = true;
			//item.maxStack = 999;
			//item.consumable = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<RadiantPrism>())
				.AddIngredient(ItemType<ShinyGemstone>())
				.AddIngredient(ItemID.Wood, 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}