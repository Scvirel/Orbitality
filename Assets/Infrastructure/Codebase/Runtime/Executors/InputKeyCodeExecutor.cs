using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class InputKeyCodeExecutor : BaseExecutor
    {
        [SerializeField] private KeyCode _keyCode = default;

        private void Update()
        {
            if (Input.GetKeyUp(_keyCode))
            {
                base.Execute();
            }
        }
    }
}