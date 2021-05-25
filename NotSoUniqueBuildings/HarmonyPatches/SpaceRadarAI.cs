using System.Runtime.CompilerServices;
using HarmonyLib;

namespace NotSoUniqueBuildings.HarmonyPatches
{
    [HarmonyPatch(typeof(SpaceRadarAI))]
    [HarmonyPatch(nameof(SpaceRadarAI.CanBeBuiltOnlyOnce))]
    internal class SpaceRadarAIPatch
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}