using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Buffs
{
	public class CrystalCharm : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Resonance");
			Description.SetDefault("+1% magic damage");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			//Increase magic damage based on current stacks
			player.magicDamage *= (float)(1 + (player.GetModPlayer<CrystalPlayer>().crystalCharmStacks * .01));
		}

		public override void ModifyBuffTip(ref string tip, ref int rare)
		{
			//Use of myPlayer is OK, as buff tips are not visible by other players
			tip = "+" + Main.LocalPlayer.GetModPlayer<CrystalPlayer>().crystalCharmStacks + "% magic damage";
		}
	}
}