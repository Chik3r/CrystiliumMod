using CrystiliumMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Glowstrike : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowstrike");
			Tooltip.SetDefault("Summons a deadly fireball");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.DamageType = DamageClass.Magic;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<CrystalFire>();
			item.shootSpeed = 20f;
		}
	}
}