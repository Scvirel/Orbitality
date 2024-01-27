using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Orbitality.Client.Runtime
{
    public sealed class UnloadSceneWithState : IUnloadSceneWithState
    {
        public async Task Execute(Scene state)
        {
            try
            {
                if (state != null && state.isLoaded)
                {
                    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

                    AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(state);

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