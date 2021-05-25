using CitiesHarmony.API;
using ICities;

namespace NotSoUniqueBuildings
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (!HarmonyHelper.IsHarmonyInstalled)
            {
                return;
            }
            Patcher.PatchAll();
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            if (!HarmonyHelper.IsHarmonyInstalled)
            {
                return;
            }
            Patcher.UnpatchAll();
        }
    }
}