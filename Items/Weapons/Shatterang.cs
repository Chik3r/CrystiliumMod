using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Shatterang : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shatterang");
		}

		public override void SetDefaults()
		{
			item.damage = 90;
			item.DamageType = DamageClass.Throwing;
			item.width = 30;
			item.height = 30;
			item.useTime = 25;
			item.useAnimation = 25;
			item.noUseGraphic = true;
			item.useStyle = ItemUseStyleID.Swing;
			item.knockBack = 3;
			item.value = 80000;
			item.rare = ItemRarityID.Yellow;
			item.shootSpeed = 16f;
			item.shoot = ProjectileType<Projectiles.ShatterangProj>();
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)		 //this make that you can shoot only 1 boomerang at once
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
				{
					return false;
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<CrystiliumBar>(), 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}