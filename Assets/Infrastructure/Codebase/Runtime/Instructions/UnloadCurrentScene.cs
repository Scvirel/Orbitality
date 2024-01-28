using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class UnloadCurrentScene : Instruction
    {
        [Inject] private readonly IUnloadSceneWithState _unloadSceneWithState = default;

        public override async void Execute()
        {
            await _unloadSceneWithState.Execute(gameObject.scene);

            _isCompleted = true;
        }
    }
}