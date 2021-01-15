using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class PrismaticBoomstick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prismatic Boomstick");
			Tooltip.SetDefault("Launches rainbow beams");
		}

		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.PrismSlug>(); //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				Projectile.NewProjectile(position.X - 8, position.Y + 8, speedX + ((float)Main.rand.Next(-200, 200) / 100), speedY + ((float)Main.rand.Next(-200, 200) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
	}
}