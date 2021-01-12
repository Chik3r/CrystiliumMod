using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class ManaDrainer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Drainer");
			Tooltip.SetDefault("Steals mana");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 18; //The damage
			item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.useTime = 4; //How long it takes for the item to be used
			item.useAnimation = 4; //How long the animation of the item takes
			item.knockBack = 7f; //How much knockback the item produces
			item.UseSound = SoundID.Item30; //The soundeffect played when used
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.mana = 20;
			item.shoot = ProjectileType<Projectiles.ManaBeam>();
			item.shootSpeed = 16f;
			item.autoReuse = true;
		}
	}
}