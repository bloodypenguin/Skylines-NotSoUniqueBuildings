using System.Runtime.CompilerServices;
using HarmonyLib;

namespace NotSoUniqueBuildings.HarmonyPatches
{
    [HarmonyPatch(typeof(MonumentAI))]
    [HarmonyPatch(nameof(MonumentAI.CanBeBuiltOnlyOnce))]
    internal class MonumentAIPatch
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}