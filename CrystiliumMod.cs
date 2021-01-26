using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod
{
	public class CrystiliumMod : Mod
	{
		internal static CrystiliumMod instance;

		public CrystiliumMod()
		{
			// We need this for the worldgen chest fix.
			if (BuildInfo.tMLVersion < new Version(0, 11, 5))
			{
				throw new Exception("\nThis mod uses functionality only present in the latest tModLoader. Please update tModLoader to use this mod\n\n");
			}

			instance = this;
		}

		public override void Unload()
		{
			instance = null;
		}

		// TODO: Port?
		//public override void Close()
		//{
		//	// Fix a tModLoader bug.
		//	var slots = new int[] {
		//		GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalKing"),
		//		GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows")
		//	};
		//	foreach (var slot in slots) // Other mods crashing during loading can leave Main.music in a weird state.
		//	{
		//		Main.audioSystem.IsTrackPlaying(slot)
		//		if (Main.music.IndexInRange(slot) && Main.music[slot]?.IsPlaying == true)
		//		{
		//			Main.music[slot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.Immediate);
		//		}
		//	}

		//	base.Close();
		//}

		public override void PostSetupContent()
		{
			ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist);
			if (bossChecklist != null)
			{
				bossChecklist.Call(
				"AddBoss",
				11.8f,
				ModContent.NPCType<NPCs.Bosses.CrystalKing>(),
				this,
				"Crystal King",
				(Func<bool>)(() => CrystalWorld.downedCrystalKing),
				ModContent.ItemType<Items.CrypticCrystal>(),
				new List<int> { ModContent.ItemType<Items.Placeable.KingTrophy>(), ModContent.ItemType<Items.Armor.CrystalMask>() },
				new List<int> { ModContent.ItemType<Items.Accessories.CrystalJewel>(), ModContent.ItemType<Items.CrystiliumBar>(), ModContent.ItemType<Items.Weapons.Cryst>(), ModContent.ItemType<Items.Weapons.Callandor>(), ModContent.ItemType<Items.Weapons.QuartzSpear>(), ModContent.ItemType<Items.Weapons.ShiningTrigger>(), ModContent.ItemType<Items.Weapons.Slamborite>(), ModContent.ItemType<Items.Weapons.Shimmer>(), ModContent.ItemType<Items.Weapons.Shatterocket>(), ModContent.ItemType<Items.Weapons.RoyalShredder>() },
				"Right click on a Crystal Fountain with a [i:" + ModContent.ItemType<Items.CrypticCrystal>() + "] in your inventory",
				"",
				"CrystiliumMod/NPCs/Bosses/CrystalKingBossLog");
			}
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			CrystiliumModMessageType msgType = (CrystiliumModMessageType)reader.ReadByte();
			switch (msgType)
			{
				case CrystiliumModMessageType.SpawnBossSpecial:
					NPC.SpawnOnPlayer(whoAmI, ModContent.NPCType<NPCs.Bosses.CrystalKing>());
					break;
				default:
					Logger.Warn("CrystiliumMod: Unknown Message type: " + msgType);
					break;
			}
		}
	}

	enum CrystiliumModMessageType : byte
	{
		SpawnBossSpecial,
	}
}
