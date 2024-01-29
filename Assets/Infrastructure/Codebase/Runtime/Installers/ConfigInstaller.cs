using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlanetConfig _planetConfig = default;
        [SerializeField] private RocketConfig _rocketConfig = default;

        public override void InstallBindings()
        {
            Container
                .Bind<PlanetConfig>()
                .FromInstance(_planetConfig)
                .AsSingle();

            Container
                .Bind<RocketConfig>()
                .FromInstance(_rocketConfig)
                .AsSingle();
        }
    }
}