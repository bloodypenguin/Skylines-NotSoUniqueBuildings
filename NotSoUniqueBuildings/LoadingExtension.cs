using ICities;
using NotSoUniqueBuildings.Detour;
using NotSoUniqueBuildings.Redirection;

namespace NotSoUniqueBuildings
{
    public class LoadingExtension : LoadingExtensionBase
    {

        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
            BuildingManagerDetour.Initialize();
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            Redirector<BuildingManagerDetour>.Deploy();

        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            Redirector<BuildingManagerDetour>.Revert();
        }
    }
}