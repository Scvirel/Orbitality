using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class DeleteSave : Instruction
    {
        [Inject] private readonly IRemoveFile _removeFile = default;

        [SerializeField] private string _saveId = default;
        [SerializeField] private Instruction _switchObjects = default;

        public override void Execute()
        {
            _removeFile.Execute(Application.persistentDataPath + $"/{_saveId}.json");
            _switchObjects.Execute();
        }
    }
}