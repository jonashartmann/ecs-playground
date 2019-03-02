using Unity.Entities;
using Unity.Transforms;

namespace Assets.App
{
    public class HelloSpawnerSystem : ComponentSystem
    {
        private ComponentGroup _spawners;

        protected override void OnCreateManager()
        {
            _spawners = GetComponentGroup(typeof(HelloSpawner), typeof(Position));
        }

        protected override void OnUpdate()
        {
            // Get all the spawners in the scene.
            var spawners = _spawners.GetEntityArray().ToArray();

            foreach (var spawner in spawners)
            {
                // Create an entity from the prefab set on the spawner component.
                var prefab = EntityManager.GetSharedComponentData<HelloSpawner>(spawner).Prefab;
                var entity = EntityManager.Instantiate(prefab);

                // Copy the position of the spawner to the new entity.
                var position = EntityManager.GetComponentData<Position>(spawner);
                EntityManager.SetComponentData(entity, position);

                // Destroy the spawner so this system only runs once.
                EntityManager.DestroyEntity(spawner);
            }

        }
    }
}
