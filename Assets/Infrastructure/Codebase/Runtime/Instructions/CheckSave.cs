using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class CheckSave : Instruction
    {
        [Inject] private readonly IIsFileExist _isFileExist = default;

        [SerializeField] private string _saveId = default;
        [SerializeField] private Instruction _switchObjects = default;

        public override void Execute()
        {
            if (_isFileExist.Execute(Application.persistentDataPath + $"/{_saveId}.json"))
            {
                _switchObjects.Execute();
            }
        }
    }
}