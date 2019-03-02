using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

namespace Assets.App.Systems
{
    public class MovementSystem : JobComponentSystem
    {
        [BurstCompile]
        struct InputDebugJob : IJobProcessComponentData<Position>
        {
            [ReadOnly] public int KeyLeft;
            [ReadOnly] public int KeyRight;
            [ReadOnly] public int KeyUp;
            [ReadOnly] public int KeyDown;
            [ReadOnly] public float dT;

            public void Execute(ref Position position)
            {
                float moveSpeed = 10 * dT;
                float moveLimit = 10 * 2;

                if (KeyLeft > 0)
                    position.Value.x = position.Value.x > -moveLimit ? position.Value.x - moveSpeed : 0;
                if (KeyRight > 0)
                    position.Value.x = position.Value.x < moveLimit ? position.Value.x + moveSpeed : 0;
                if (KeyUp > 0)
                    position.Value.y = position.Value.y < moveLimit ? position.Value.y + moveSpeed : 0;
                if (KeyDown > 0)
                    position.Value.y = position.Value.y > -moveLimit ? position.Value.y - moveSpeed : 0;
            }
        }


        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var job = new InputDebugJob()
            {
                dT = Time.deltaTime,
                KeyLeft = Input.GetKeyUp(KeyCode.A) ? 1 : 0,
                KeyUp = Input.GetKey(KeyCode.W) ? 1 : 0,
                KeyRight = Input.GetKey(KeyCode.D) ? 1 : 0,
                KeyDown = Input.GetKey(KeyCode.S) ? 1 : 0
            };

            return job.Schedule(this, inputDeps);
        }
    }
}
