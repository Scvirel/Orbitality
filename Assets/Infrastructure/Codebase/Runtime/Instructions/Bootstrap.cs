using System.Threading.Tasks;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class Bootstrap : Instruction
    {
        [SerializeField] private Instruction[] _instructions = default;

        public override async void Execute()
        {
            await ExecuteInstructions();

            _isCompleted = true;
        }

        private async Task ExecuteInstructions()
        {
            foreach (Instruction instruction in _instructions)
            {
                instruction.Execute();

                while (!instruction.IsCompleted)
                {
                    await Task.Yield();
                }
            }
        }
    }
}