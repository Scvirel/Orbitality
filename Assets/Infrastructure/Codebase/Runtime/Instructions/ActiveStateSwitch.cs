using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class ActiveStateSwitch : Instruction
    {
        [SerializeField] private GameObject _activate = default;
        [SerializeField] private GameObject _deactivate = default;

        public override void Execute()
        {
            _activate.SetActive(true);
            _deactivate.SetActive(false);

            _isCompleted = true;
        }
    }
}