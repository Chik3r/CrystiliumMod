using CrystiliumMod.Projectiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Buffs
{
	public class CrystalLeak : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Crystal Leak");
			Description.SetDefault("Creates dangerous crystals");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			LongerExpertDebuff = false;
		}

		private float ticks = 0f;

		public override void Update(Player player, ref int buffIndex)
		{
			if (++ticks >= 6f)
			{
				ticks = 0f;
				int projType = 0;
				switch (Main.rand.Next(0, 3))
				{
					case 0:
						projType = ProjectileType<Shatter1>();
						break;
					case 1:
						projType = ProjectileType<Shatter2>();
						break;
					case 2:
						projType = ProjectileType<Shatter3>();
						break;
				}
				Projectile.NewProjectile((player.Center.X - 125) + Main.rand.Next(250), (player.Center.Y - 125) + Main.rand.Next(250), 0f, 0f, projType, 14, 0, Main.myPlayer);
			}
		}
	}
}