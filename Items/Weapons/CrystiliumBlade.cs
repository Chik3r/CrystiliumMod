using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystiliumBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystilium Cleaver");
			Tooltip.SetDefault("Launches crystal embers");
		}

		public override void SetDefaults()
		{
			item.damage = 138;
			item.DamageType = DamageClass.Melee;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.Swing;
			item.knockBack = 6;
			item.value = 80000;
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<CrystiliumBladeProj>();
			item.shootSpeed = 6f;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//create velocity vectors for the projectiles
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / Main.rand.Next(18, 22));
			Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / Main.rand.Next(18, 22));
			Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / Main.rand.Next(8, 12));
			Vector2 newVect4 = origVect.RotatedBy(-System.Math.PI / Main.rand.Next(8, 12));

			//create projectiles
			Projectile.NewProjectile(position.X, position.Y - 20, speedX + ((float)Main.rand.Next(-300, 300) / 100), speedY + ((float)Main.rand.Next(-300, 300) / 100), ProjectileType<CrystiliumBladeProj>(), damage / 3, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y - 20, newVect.X + ((float)Main.rand.Next(-300, 300) / 100), newVect.Y + ((float)Main.rand.Next(-300, 300) / 100), ProjectileType<CrystiliumBladeProj>(), damage / 3, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y - 20, newVect2.X + ((float)Main.rand.Next(-300, 300) / 100), newVect2.Y + ((float)Main.rand.Next(-300, 300) / 100), ProjectileType<CrystiliumBladeProj>(), damage / 3, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y - 20, newVect3.X + ((float)Main.rand.Next(-300, 300) / 100), newVect3.Y + ((float)Main.rand.Next(-300, 300) / 100), ProjectileType<CrystiliumBladeProj>(), damage / 3, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y - 20, newVect4.X + ((float)Main.rand.Next(-300, 300) / 100), newVect4.Y + ((float)Main.rand.Next(-300, 300) / 100), ProjectileType<CrystiliumBladeProj>(), damage / 3, knockBack, player.whoAmI, 0, 0);
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			for (int j = 1; j < 3; j++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				/*		int proj = Projectile.NewProjectile(projectile.Center.X, item.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter"+(1+Main.rand.Next(0,3))), item.damage / 4, 0, Main.myPlayer); */
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<CrystiliumBar>(), 19)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}