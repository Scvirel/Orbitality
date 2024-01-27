using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class LoadDefaultScenes : Instruction
    {
        [Inject] private readonly ILoadScene _loadScene = default;

        public override void Execute()
        {
            _loadScene.Execute(GameScenes.Camera, LoadSceneMode.Additive);
            _loadScene.Execute(GameScenes.EventSystem, LoadSceneMode.Additive);
        }
    }
}