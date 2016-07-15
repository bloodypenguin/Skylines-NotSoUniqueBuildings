using System;
using System.Reflection;
using ColossalFramework;
using ICities;

namespace NotSoUniqueBuildings
{
    public class NotSoUniqueBuildings : LoadingExtensionBase, IUserMod
    {
        private static IntPtr ptr;
        private static IntPtr detourPtr;
        private static RedirectCallsState state;
        private static FieldInfo serviceBuildings;

        public string Name
        {
            get { return "NotSoUniqueBuildings"; }
        }

        public string Description
        {
            get
            {
                return "Now you can plop unique buildings as many times as you wish";
            }
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            serviceBuildings = typeof(BuildingManager).GetField("m_serviceBuildings", BindingFlags.Instance | BindingFlags.NonPublic);
            ptr = typeof(BuildingManager).GetMethod("GetServiceBuildings").MethodHandle.GetFunctionPointer();
            detourPtr = typeof(NotSoUniqueBuildings).GetMethod("GetServiceBuildings").MethodHandle.GetFunctionPointer();
            state = RedirectionHelper.PatchJumpTo
                (
                    ptr,
                    detourPtr
                );
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            RedirectionHelper.RevertJumpTo(ptr, state);
        }

        public FastList<ushort> GetServiceBuildings(ItemClass.Service service)
        {
            if (service == ItemClass.Service.Monument)
            {
                var currentTool = Singleton<ToolManager>.instance.m_properties.CurrentTool;
                var tool = currentTool as BuildingTool;
                if (tool != null && tool.m_prefab != null && tool.m_prefab.m_buildingAI is MonumentAI)
                {
                    return new FastList<ushort>();
                }
            }
            if (service <= ItemClass.Service.Office)
            {
                return null;
            }
            var obj = serviceBuildings.GetValue(Singleton<BuildingManager>.instance);
            return obj == null ? null : ((FastList<ushort>[])obj)[(int)(service - 8 - 1)];
        }

    }
}
