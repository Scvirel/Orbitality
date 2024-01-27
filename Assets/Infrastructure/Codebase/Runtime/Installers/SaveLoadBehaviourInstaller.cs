using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class SaveLoadBehaviourInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ILoadFromFile>()
                .To<LoadFromFile>()
                .AsSingle();

            Container
                .Bind<ISaveToFile>()
                .To<SaveToFile>()
                .AsSingle();

            Container
                .Bind<IRemoveFile>()
                .To<RemoveFile>()
                .AsSingle();

            Container
                .Bind<IIsFileExist>()
                .To<IsFileExist>()
                .AsSingle();
        }
    }
}