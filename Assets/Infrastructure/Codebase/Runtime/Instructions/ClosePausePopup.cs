using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class ClosePausePopup : Instruction
    {
        [Inject] private readonly IUnloadSceneWithState _unloadSceneWithState = default;

        public override void Execute()
        {
            Time.timeScale = 1f;
            _unloadSceneWithState.Execute(gameObject.scene);
        }
    }
}