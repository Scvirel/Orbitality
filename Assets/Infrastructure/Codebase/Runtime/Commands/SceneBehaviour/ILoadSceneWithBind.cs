using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public interface ILoadSceneWithBind : INoResponseCommand<string, LoadSceneMode, Action<DiContainer>>
    { }
}