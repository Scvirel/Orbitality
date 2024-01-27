using UnityEngine.SceneManagement;

namespace Orbitality.Client.Runtime
{
    public sealed class LoadScene : ILoadScene
    {
        public void Execute(string name, LoadSceneMode mode)
        {
            SceneManager.LoadScene(name, mode);
        }
    }
}