using System.Threading.Tasks;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class UnloadCurrentScene : Instruction
    {
        [Inject] private readonly IUnloadSceneWithState _unloadSceneWithState = default;

        public override async void Execute()
        {
            await Task.Delay(100);
            await _unloadSceneWithState.Execute(gameObject.scene);
        }
    }
}