using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedRubyStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Ruby Staff");
			Tooltip.SetDefault("'Feel the fire'");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 19; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 45; //How long it takes for the item to be used
			Item.useAnimation = 45; //How long the animation of the item takes
			Item.knockBack = 7f; //How much knockback the item produces
			Item.UseSound = SoundID.Item30; //The soundeffect played when used
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
			Item.value = 30000;
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileType<Projectiles.FireGem>(); //What the item shoots, retains an int value | *
			Item.shootSpeed = 2f; //How fast the projectile fires
			Item.mana = 20;
			Item.autoReuse = false; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RubyStaff)
				.AddIngredient(ItemID.Ruby, 15)
				.AddIngredient(ItemType<ShinyGemstone>(), 10)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//float SdirX = (Main.MouseWorld.X - player.position.X) * 8.5f;
			//float SdirY = (Main.MouseWorld.Y - player.position.Y) * 8.5f;
			//float angle = (float)Math.Atan(12f);
			Projectile.NewProjectile(position.X - player.width / 2, position.Y - player.height / 2, speedX, speedY, ProjectileType<Projectiles.FireGem>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}