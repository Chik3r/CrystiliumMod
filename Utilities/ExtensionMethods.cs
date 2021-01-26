using Terraria;
using Terraria.ID;

namespace CrystiliumMod.Utilities
{
    public static class ExtensionMethods
    {
        public static bool IsTopSlope(this Tile tile)
        {
            SlopeID slope = tile.Slope;

            if (slope != SlopeID.HalfBrick)
                return slope == SlopeID.SlopeDownRight;

            return true;
        }
    }
}
