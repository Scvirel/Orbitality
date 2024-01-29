using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class ShowPausePopup : Instruction
    {
        [Inject] private readonly ILevelService _levelService = default;
        [Inject] private readonly ILevelDataState _levelDataState = default;
        [Inject] private readonly ILoadSceneWithBind _loadSceneWithBind = default;

        public override void Execute()
        {
            _loadSceneWithBind.Execute(
                GameScenes.PausePopup,
                LoadSceneMode.Additive,
                    container => 
                    {
                        container
                            .Bind<ILevelService>()
                            .To<ILevelService>()
                            .FromInstance(_levelService)
                            .AsSingle();

                        container
                            .Bind<ILevelDataState>()
                            .To<ILevelDataState>()
                            .FromInstance(_levelDataState)
                            .AsSingle();
                    }
                );
            Time.timeScale = 0f;
        }
    }
}