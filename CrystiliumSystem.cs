using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace CrystiliumMod
{
	public class CrystiliumSystem : ModSystem
	{
		// TODO: Find out how GetSoundSlot works on 1.4
		//public override void UpdateMusic(ref int music, ref MusicPriority priority)
		//{
		//	if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
		//	{
		//		return;
		//	}
		//	Player player = Main.LocalPlayer;
		//	if (player.GetModPlayer<CrystalPlayer>().ZoneCrystal)
		//	{
		//		// TODO: alt music possibly.
		//		//var normalMusic = this.GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows");
		//		//if(music != normalMusic && Main.rand.NextBool(10))
		//		music = GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows");
		//		priority = MusicPriority.BiomeMedium;
		//	}
		//}
	}
}
