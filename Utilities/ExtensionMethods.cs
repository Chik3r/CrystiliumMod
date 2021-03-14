using Terraria;
using Terraria.ID;

namespace CrystiliumMod.Utilities
{
    public static class ExtensionMethods
    {
        public static bool IsTopSlope(this Tile tile)
        {
	        SlopeType slope = tile.Slope;

            if (!tile.IsHalfBlock)
                return slope == SlopeType.SlopeDownRight;

            return true;
        }
    }
}
