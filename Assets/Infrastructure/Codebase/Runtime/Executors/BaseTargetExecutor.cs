using System;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public abstract class BaseTargetExecutor<TInput> : MonoBehaviour, INoResponseCommand<TInput>
    {
        [SerializeField] private Instruction<TInput> _instruction = default; 

        public virtual void Execute(TInput input)
        {
            try
            {
                _instruction.Execute(input);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
    }
}