using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Orbitality.Client.Runtime
{
    public sealed class AwakeExecutor : BaseExecutor
    {
        private void Awake()
        {
            base.Execute();
        }
    }
}