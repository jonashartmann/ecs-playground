using UnityEngine;
using Unity.Entities;

namespace Assets.App
{
    public class InputSystem : ComponentSystem
    {
        private ComponentGroup _componentGroup;

        protected override void OnCreateManager()
        {
            _componentGroup = GetComponentGroup(typeof(InputComponent));
        }

        protected override void OnUpdate()
        {
            var inputDataArray = _componentGroup.GetComponentDataArray<InputData>();
            Debug.Log("OnUpdate");

            for (var i = 0; i < inputDataArray.Length; i++)
            {
                var inputData = inputDataArray[i];
                inputData.Horizontal = Input.GetAxis("Horizontal");
                inputData.Vertical = Input.GetAxis("Vertical");
                inputData.KeyLeft = Input.GetKeyUp(KeyCode.A) ? 1 : 0;
                inputData.KeyUp = Input.GetKey(KeyCode.W) ? 1 : 0;
                inputData.KeyRight = Input.GetKey(KeyCode.D) ? 1 : 0;
                inputData.KeyDown = Input.GetKey(KeyCode.S) ? 1 : 0;

            }
        }
    }
}
