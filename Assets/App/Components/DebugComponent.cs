using System;
using Unity.Entities;

namespace Assets.App.Components
{
    [Serializable]
    public struct DebugData : IComponentData
    {
        public float Horizontal;
        public float Vertical;
    }

    public class DebugComponent : ComponentDataWrapper<DebugData> { }
}