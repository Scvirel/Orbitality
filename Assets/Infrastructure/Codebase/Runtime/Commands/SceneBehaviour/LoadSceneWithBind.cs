using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class LoadSceneWithBind : ILoadSceneWithBind
    {
        [Inject] private readonly ZenjectSceneLoader _zenjectSceneLoader = default;

        public void Execute(string name, LoadSceneMode mode, Action<DiContainer> bind)
        {
            _zenjectSceneLoader.LoadScene(name, mode, bind);
        }
    }
}