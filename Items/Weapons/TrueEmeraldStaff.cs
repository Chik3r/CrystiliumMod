using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueEmeraldStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Emerald staff");
			Tooltip.SetDefault("'Blow all your enemies away'");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 65;
			item.DamageType = DamageClass.Magic;
			item.mana = 9;
			item.width = 40;
			item.height = 40;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 120000; //How much the item is worth
			item.rare = ItemRarityID.Yellow; //The rarity of the item
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<Projectiles.AmberDagger>();
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<Items.CrystiliumBar>(), 15)
				.AddIngredient(ItemType<Items.Weapons.EnchantedEmeraldStaff>())
				.AddIngredient(ItemType<Items.BrokenStaff>())
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX + Main.rand.Next(-3, 3), speedY + Main.rand.Next(-3, 3), ProjectileType<Projectiles.TrueLeaf>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}