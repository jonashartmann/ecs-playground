using System;
using Unity.Entities;

namespace Assets.App
{
    [Serializable]
    public struct InputData : IComponentData
    {
        public float Horizontal;
        public float Vertical;
        public int KeyLeft;
        public int KeyUp;
        public int KeyRight;
        public int KeyDown;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class InputComponent : ComponentDataWrapper<InputData>
    {

    }
}