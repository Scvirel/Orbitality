using UnityEngine.SceneManagement;

namespace Orbitality.Client.Runtime
{
    public interface ILoadScene : INoResponseCommand<string, LoadSceneMode>
    { }
}