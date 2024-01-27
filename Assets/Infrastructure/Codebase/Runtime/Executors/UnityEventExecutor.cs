using UnityEngine.Events;

namespace Orbitality.Client.Runtime
{
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
}