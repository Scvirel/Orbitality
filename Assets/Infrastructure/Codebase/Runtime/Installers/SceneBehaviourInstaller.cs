using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class SceneBehaviourInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ILoadScene>()
                .To<LoadScene>()
                .AsSingle();

            Container
                .Bind<IUnloadSceneWithName>()
                .To<UnloadSceneWithName>()
                .AsSingle();

            Container
                .Bind<IUnloadSceneWithState>()
                .To<UnloadSceneWithState>()
                .AsSingle();

        }
    }
}