using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class Bootstrap : Instruction
    {
        [SerializeField] private Instruction[] _instructions = default;

        public override void Execute()
        {
            foreach (Instruction instruction in _instructions)
            {
                instruction.Execute();
            }
        }
    }
}