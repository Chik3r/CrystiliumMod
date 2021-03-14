using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.NPCs
{
	public class CrystalZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Zombie");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults()
		{
			NPC.width = 18;
			NPC.height = 40;
			NPC.damage = 21;
			NPC.defense = 12;
			NPC.lifeMax = 120;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 300f;
			NPC.knockBackResist = 0.75f;
			NPC.aiStyle = 3;
			AIType = NPCID.Skeleton;
			AnimationType = NPCID.Zombie;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == TileType<Tiles.CrystalBlock>() ? 8f : 0f;
		}

		// TODO: GetGoreSlot
		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				//spawn initial set
				for (int i = 1; i <= 3; i++)
				{
					Gore.NewGore(NPC.position, NPC.velocity, Find<ModGore>("CrystiliumMod/Crystal_Zombie_Gore_" + i).Type);
				}
				//spawn a couple extra bits
				Gore.NewGore(NPC.position, NPC.velocity, Find<ModGore>("CrystiliumMod/Crystal_Zombie_Gore_1").Type);
				Gore.NewGore(NPC.position, NPC.velocity, Find<ModGore>("CrystiliumMod/Crystal_Zombie_Gore_1").Type);
			}
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(new CommonDrop(ItemType<Items.ShinyGemstone>(), 2));
		}

		public override void AI()
		{
			Vector3 RGB = new Vector3(0f, 0.75f, 1.5f);
			float multiplier = 1;
			float max = 2.25f;
			float min = 1.0f;
			RGB *= multiplier;
			if (RGB.X > max)
			{
				multiplier = 0.5f;
			}
			if (RGB.X < min)
			{
				multiplier = 1.5f;
			}
			Lighting.AddLight(NPC.position, RGB.X, RGB.Y, RGB.Z);
			if (Main.rand.Next(150) == 0)
			{
				for (int h = 0; h < 3; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;

					int projType = 0;
					switch (Main.rand.Next(0, 3))
					{
						case 0:
							projType = ProjectileType<ShatterEnemy1>();
							break;
						case 1:
							projType = ProjectileType<ShatterEnemy2>();
							break;
						case 2:
							projType = ProjectileType<ShatterEnemy3>();
							break;
					}

					Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y + 20, vel.X, vel.Y, projType, 18, 0, Main.myPlayer);
				}
			}
		}
	}
}