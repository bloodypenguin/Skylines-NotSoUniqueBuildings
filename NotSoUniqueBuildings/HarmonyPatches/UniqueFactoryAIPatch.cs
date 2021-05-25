using System.Runtime.CompilerServices;
using HarmonyLib;

namespace NotSoUniqueBuildings.HarmonyPatches
{
    [HarmonyPatch(typeof(UniqueFactoryAI))]
    [HarmonyPatch(nameof(UniqueFactoryAI.CanBeBuiltOnlyOnce))]
    internal class UniqueFactoryAIPatch
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}