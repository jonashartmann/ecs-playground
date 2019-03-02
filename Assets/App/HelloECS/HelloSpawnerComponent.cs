using System;
using Unity.Entities;
using UnityEngine;

namespace Assets.App
{
    [Serializable]
    public struct HelloSpawner : ISharedComponentData
    {
        public GameObject Prefab;
    }

    public class HelloSpawnerComponent : SharedComponentDataWrapper<HelloSpawner> { }
}
