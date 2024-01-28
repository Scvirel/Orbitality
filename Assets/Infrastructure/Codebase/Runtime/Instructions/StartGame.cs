using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class StartGame : Instruction
    {
        [Inject] private readonly ILoadScene _loadScene = default;
        [Inject] private readonly IUnloadSceneWithState _unloadSceneWithState = default;

        public override void Execute()
        {
            _loadScene.Execute(GameScenes.Battleground, LoadSceneMode.Additive);
            _unloadSceneWithState.Execute(gameObject.scene);

            _isCompleted = true;
        }
    }
}