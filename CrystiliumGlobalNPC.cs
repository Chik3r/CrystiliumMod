using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod
{
	public class CrystiliumGlobalNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.Mothron)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<Items.BrokenStaff>(), 4));
			}
		}
	}
}