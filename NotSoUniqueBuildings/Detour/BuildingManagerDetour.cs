using System.Reflection;
using ColossalFramework;
using NotSoUniqueBuildings.Redirection.Attributes;

namespace NotSoUniqueBuildings.Detour
{
    [TargetType(typeof(BuildingManager))]
    public class BuildingManagerDetour : BuildingManager
    {
        private static FieldInfo _serviceBuildings;

        public static void Initialize()
        {
            _serviceBuildings = typeof(BuildingManager).GetField("m_serviceBuildings", BindingFlags.Instance | BindingFlags.NonPublic);
        }


        [RedirectMethod]
        public new FastList<ushort> GetServiceBuildings(ItemClass.Service service)
        {
            int publicServiceIndex = ItemClass.GetPublicServiceIndex(service);
            //begin mod
            if (service == ItemClass.Service.Monument)
            {
                var currentTool = Singleton<ToolManager>.instance.m_properties.CurrentTool;
                var tool = currentTool as BuildingTool;
                if (tool?.m_prefab?.m_buildingAI is MonumentAI)
                {
                    return new FastList<ushort>();
                }
            }
            //end mod
            if (publicServiceIndex != -1)
                return this.m_serviceBuildings[publicServiceIndex];
            return (FastList<ushort>)null;
        }

        private FastList<ushort>[] m_serviceBuildings => (FastList<ushort>[])_serviceBuildings.GetValue(BuildingManager.instance);
    }
}