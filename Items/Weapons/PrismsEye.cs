using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class PrismsEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism's Eye");
			Tooltip.SetDefault("A spectral bow assists you");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.QueenSpiderStaff); //only here for values we haven't defined ourselves yet
			Item.damage = 105;  //placeholder damage :3
			Item.mana = 40;	//somehow I think this might be too much...? -thegamemaster1234
			Item.width = 40;
			Item.height = 40;
			Item.value = 80000;
			Item.rare = 8;
			Item.knockBack = 2.5f;
			Item.UseSound = SoundID.Item25;
			Item.shoot = ProjectileType<Projectiles.Minions.SpiritBow>();
			Item.shootSpeed = 0f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			
			//projectile spawns at mouse cursor
			Vector2 value18 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			position = value18;
			return true;
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim(true);
			}
			return base.UseItem(player);
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