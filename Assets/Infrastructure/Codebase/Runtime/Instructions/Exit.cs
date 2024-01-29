using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class Exit : Instruction
    {
        [Inject] private readonly ILoadScene _loadScene = default;
        [Inject] private readonly IUnloadSceneWithName _uloadSceneWithName = default;

        public override void Execute()
        {
            _loadScene.Execute(GameScenes.Menu, LoadSceneMode.Additive);

            _uloadSceneWithName.Execute(GameScenes.Battleground);
            _uloadSceneWithName.Execute(GameScenes.GameOver);
        }
    }
}