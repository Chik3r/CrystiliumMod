using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class GeodeHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Geode Hamaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.DamageType = DamageClass.Melee;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.axe = 25;
			item.hammer = 85;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 17000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<EnchantedGeode>(), 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(10) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Dusts.Sparkle>());
			}
		}
	}
}