using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

namespace Assets.App
{
    public class HelloMovementComponentSystem : JobComponentSystem
    {
        [BurstCompile]
        struct HelloMovementSpeedJob : IJobProcessComponentData<Position, HelloMovementSpeed>
        {
            [ReadOnly] public float dT;

            public void Execute(ref Position position, [ReadOnly] ref HelloMovementSpeed speed)
            {
                // Move something in the +X direction at the speed given by HelloMovementSpeed.
                // If this thing's X position is more than 2x its speed, reset X position to 0.
                float moveSpeed = speed.Value * dT;
                float moveLimit = speed.Value * 2;
                position.Value.x = position.Value.x < moveLimit ? position.Value.x + moveSpeed : 0;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var job = new HelloMovementSpeedJob()
            {
                dT = Time.deltaTime
            };

            return job.Schedule(this, inputDeps);
        }
    }
}
