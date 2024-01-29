using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class LevelServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ILevelService>()
                .To<LevelService>()
                .AsSingle();
        }
    }
}