using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Gemshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemshot");
			Tooltip.SetDefault("Converts arrows into enchanted crystal arrows");
		}

		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.LightPurple;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 3; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<Projectiles.EnchantedCrystalArrow>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}