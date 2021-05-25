using CitiesHarmony.API;
using ICities;

namespace NotSoUniqueBuildings
{
    public class NotSoUniqueBuildings : IUserMod
    {
        
        public string Name => "Not So Unique Buildings";

        public string Description => "Now you can plop unique buildings as many times as you wish";

        public void OnEnabled() {
            HarmonyHelper.EnsureHarmonyInstalled();
        }
    }
}
