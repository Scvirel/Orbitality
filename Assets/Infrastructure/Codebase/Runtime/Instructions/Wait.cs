using System.Threading.Tasks;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class Wait : Instruction
    {
        [SerializeField] private int _timeMSes = default;

        public override async void Execute()
        {
            await Task.Delay(_timeMSes);

            _isCompleted = true;
        }
    }
}