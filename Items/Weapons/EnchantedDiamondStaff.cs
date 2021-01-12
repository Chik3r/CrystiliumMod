using CrystiliumMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedDiamondStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Diamond Staff");
			Tooltip.SetDefault("'Zap!'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 13; //The damage
			item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.useTime = 75; //How long it takes for the item to be used
			item.useAnimation = 75; //How long the animation of the item takes
			item.knockBack = 7f; //How much knockback the item produces
			item.UseSound = SoundID.Item30; //The soundeffect played when used
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
			item.value = 30000;
			item.rare = ItemRarityID.Orange;
			item.shoot = ProjectileType<GiantDiamond>(); //What the item shoots, retains an int value | *
			item.shootSpeed = 6f; //How fast the projectile fires
			item.mana = 20;
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DiamondStaff)
				.AddIngredient(ItemID.Diamond, 15)
				.AddIngredient(ItemType<ShinyGemstone>(), 15)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}