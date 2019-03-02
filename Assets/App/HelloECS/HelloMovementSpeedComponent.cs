using System;
using Unity.Entities;

namespace Assets.App
{
    [Serializable]
    public struct HelloMovementSpeed : IComponentData
    {
        public float Value;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class HelloMovementSpeedComponent : ComponentDataWrapper<HelloMovementSpeed> { }
}
