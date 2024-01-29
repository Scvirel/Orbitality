using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class FactoryInstaller : MonoInstaller
    {
        [SerializeField] private PlanetEntryExecutor _planetEntryExecutor = default;
        [SerializeField] private RocketEntryExecutor _rocketEntryExecutor = default;

        public override void InstallBindings()
        {
            Container
                .BindFactory<PlanetEntryExecutor, PlanetEntryExecutor.Factory>()
                .FromComponentInNewPrefab(_planetEntryExecutor)
                .AsSingle();

            Container
                .BindFactory<RocketEntryExecutor, RocketEntryExecutor.Factory>()
                .FromComponentInNewPrefab(_rocketEntryExecutor)
                .AsSingle();
        }
    }
}