using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedSapphireStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Sapphire Staff");
			Tooltip.SetDefault("'Colder than tundra'");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 20; //The damage
			Item.DamageType = DamageClass.Summon; //Whether or not it is a magic weapon
			Item.width = 60; //Item width
			Item.height = 60; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 50; //How long it takes for the item to be used
			Item.useAnimation = 50; //How long the animation of the item takes
			Item.knockBack = 7f; //How much knockback the item produces
			Item.UseSound = SoundID.Item30; //The soundeffect played when used
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
			Item.value = 30000;
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileType<Projectiles.SapphirePortal>(); //What the item shoots, retains an int value | *
			Item.shootSpeed = 1f; //How fast the projectile fires
			Item.mana = 80;
			Item.autoReuse = false; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SapphireStaff)
				.AddIngredient(ItemID.Sapphire, 15)
				.AddIngredient(ItemType<ShinyGemstone>(), 10)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
		{
			player.channel = true;
			//Vector2 mouse = new Vector2(Main.mouseX,Main.mouseY) + Main.screenPosition;
			//remove any other owned SapphirePortal projectiles
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile p = Main.projectile[i];
				if (p.active && p.type == Item.shoot && p.owner == player.whoAmI)
				{
					p.active = false;
				}
			}
			//projectile spawns at mouse cursor
			Vector2 value18 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			position = value18;
			return true;
		}
	}
}