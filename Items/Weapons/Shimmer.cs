using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Shimmer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shimmer");
			Tooltip.SetDefault("Rain lead on the enemy");
		}

		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				Projectile.NewProjectile(position.X - 8, position.Y + 8, speedX + ((float)Main.rand.Next(-300, 300) / 100), speedY + ((float)Main.rand.Next(-300, 300) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
	}
}