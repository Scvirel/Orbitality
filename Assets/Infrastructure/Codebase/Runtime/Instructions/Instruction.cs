using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public abstract class Instruction : MonoBehaviour, IInstruction
    {
        public abstract void Execute();
    }
}