using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Assets.App.Systems
{
    public class InputDebugSystem : JobComponentSystem
    {
        struct InputDebugJob : IJobProcessComponentData<InputData>
        {
            public void Execute([ReadOnly] ref InputData data)
            {
                //Debug.Log("data.Horizontal: " + data.Horizontal);
                //Debug.Log("data.Vertical: " + data.Vertical);

                if (data.KeyLeft > 0)
                    Debug.Log("Left key pressed!");
                if (data.KeyUp > 0)
                    Debug.Log("Up key pressed!");
                if (data.KeyRight > 0)
                    Debug.Log("Right key pressed!");
                if (data.KeyDown > 0)
                    Debug.Log("Down key pressed!");

            }
        }


        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return base.OnUpdate(inputDeps);
            //var job = new InputDebugJob();

            //return job.Schedule(this, inputDeps);
        }
    }
}
