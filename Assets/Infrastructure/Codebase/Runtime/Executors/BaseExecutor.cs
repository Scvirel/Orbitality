using System;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public abstract class BaseExecutor : MonoBehaviour, ICommand
    {
        [SerializeField] private Instruction _instruction = default;

        public virtual void Execute()
        {
            try
            {
                _instruction.Execute();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
    }
}