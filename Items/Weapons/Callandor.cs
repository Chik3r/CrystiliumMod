using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Callandor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Callandor");
			Tooltip.SetDefault("'I DID get this off of a Schmo'");
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 36;
			Item.useAnimation = 25;
			Item.useTime = 15;
			Item.useStyle = 5;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.noMelee = true;
			Item.damage = 166;
			Item.knockBack = 4f;
			Item.autoReuse = false;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Melee;
			Item.shoot = ProjectileType<CallandorSlice>();
			Item.shootSpeed = 15f;
			Item.value = 100000;
			Item.rare = 7;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<CallandorSlice>(), damage, knockBack, player.whoAmI);
			Main.projectile[p].scale = 1f;
			return false;
		}
	}
}