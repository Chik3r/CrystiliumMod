using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Backgrounds
{
	public class CrystalUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.LocalPlayer.GetModPlayer<CrystalPlayer>().ZoneCrystal;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = Mod.GetBackgroundSlot("Backgrounds/CrystalBiomeUG0.rawimg");
			textureSlots[1] = Mod.GetBackgroundSlot("Backgrounds/CrystalBiomeUG1.rawimg");
			textureSlots[2] = Mod.GetBackgroundSlot("Backgrounds/CrystalBiomeUG2.rawimg");
			textureSlots[3] = Mod.GetBackgroundSlot("Backgrounds/CrystalBiomeUG3.rawimg");
		}
	}
}