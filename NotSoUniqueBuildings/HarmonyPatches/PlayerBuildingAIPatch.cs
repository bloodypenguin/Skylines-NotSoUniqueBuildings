using System.Runtime.CompilerServices;
using HarmonyLib;

namespace NotSoUniqueBuildings.HarmonyPatches
{
    [HarmonyPatch(typeof(PlayerBuildingAI))]
    [HarmonyPatch(nameof(PlayerBuildingAI.CanBeBuiltOnlyOnce))]
    internal class PlayerBuildingAIPatch
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}