using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Orbitality.Client.Runtime
{
    public sealed class ButtonExecutor : UnityEventExecutor
    {
        [SerializeField] private Button _button = default;

        protected override UnityEvent MainEvent => _button.onClick;
    }
}