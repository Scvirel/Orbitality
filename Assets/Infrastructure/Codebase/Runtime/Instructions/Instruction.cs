using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public abstract class Instruction : MonoBehaviour, IInstruction
    {
        protected bool _isCompleted = default;
        public virtual bool IsCompleted => _isCompleted;

        public abstract void Execute();
    }
}