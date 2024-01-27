using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Orbitality.Client.Runtime
{
    public sealed class UnloadSceneWithName : IUnloadSceneWithName
    {
        public async Task Execute(string name)
        {
            Scene scene = SceneManager.GetSceneByName(name);

            try
            {
                if (scene != null && scene.isLoaded)
                {
                    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

                    AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(scene);

                    asyncOperation.completed += (operation) =>
                    {
                        if (operation.isDone)
                        {
                            tcs.SetResult(true);
                        }
                    };

                    await tcs.Task;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
    }
}