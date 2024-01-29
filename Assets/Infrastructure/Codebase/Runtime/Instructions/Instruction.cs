using UnityEngine;
using UnityEngine.Windows;

namespace Orbitality.Client.Runtime
{
    public abstract class Instruction : MonoBehaviour, IInstruction
    {
        protected bool _isCompleted = default;
        public virtual bool IsCompleted => _isCompleted;

        public abstract void Execute();
    }

    public abstract class Instruction<TInput> : MonoBehaviour, IInstruction<TInput>
    {
        protected bool _isCompleted = default;
        public virtual bool IsCompleted => _isCompleted;

        public abstract void Execute(TInput input);
    }
}