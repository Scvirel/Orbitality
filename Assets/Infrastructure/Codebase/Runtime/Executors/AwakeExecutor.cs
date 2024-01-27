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

    public abstract class UnityEventExecutor : BaseExecutor
    {
        protected abstract UnityEvent MainEvent { get; }

        protected virtual void Awake()
        {
            MainEvent.AddListener(Next);
        }
        protected virtual void OnDestroy() 
        {
            MainEvent.RemoveListener(Next);
        }

        private void Next()
        {
            base.Execute();
        }
    }

    public sealed class ButtonExecutor : UnityEventExecutor
    {
        [SerializeField] private Button _button = default;

        protected override UnityEvent MainEvent => _button.onClick;
    }
}