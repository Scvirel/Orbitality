using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class ShowPausePopup : Instruction
    {
        [Inject] private readonly ILoadScene _loadScene = default;

        public override void Execute()
        {
            _loadScene.Execute(GameScenes.PausePopup, LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
    }
}