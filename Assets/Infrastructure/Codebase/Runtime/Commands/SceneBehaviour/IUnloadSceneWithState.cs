using UnityEngine.SceneManagement;

namespace Orbitality.Client.Runtime
{
    public interface IUnloadSceneWithState : INoResponseAsyncCommand<Scene>
    { }
}