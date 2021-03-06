using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class StardustScepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Crystal Scepter");
			Tooltip.SetDefault("'The glimmer of stars resides with you'");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.QueenSpiderStaff); //only here for values we haven't defined ourselves yet
			Item.damage = 100;  //placeholder damage :3
			Item.mana = 40;	//somehow I think this might be too much...? -thegamemaster1234
			Item.width = 40;
			Item.height = 40;
			Item.value = 600000;
			Item.rare = 10;
			Item.knockBack = 2.5f;
			Item.UseSound = SoundID.Item25;
			Item.shoot = ProjectileType<Projectiles.StardustDiamond>();
			Item.shootSpeed = 0f;
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//remove any other owned StardustDiamond projectiles, just like any other sentry minion
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile p = Main.projectile[i];
				if (p.active && p.type == Item.shoot && p.owner == player.whoAmI)
				{
					p.active = false;
				}
			}
			//projectile spawns at mouse cursor
			Vector2 value18 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			position = value18;
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<CrystiliumBar>(), 15)
				.AddIngredient(ItemID.FragmentStardust, 15)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}