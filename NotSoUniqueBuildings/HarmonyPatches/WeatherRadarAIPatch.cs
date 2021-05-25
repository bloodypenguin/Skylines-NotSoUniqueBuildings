using System.Runtime.CompilerServices;
using HarmonyLib;

namespace NotSoUniqueBuildings.HarmonyPatches
{
    [HarmonyPatch(typeof(WeatherRadarAI))]
    [HarmonyPatch(nameof(WeatherRadarAI.CanBeBuiltOnlyOnce))]
    internal class WeatherRadarAIPatch
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}