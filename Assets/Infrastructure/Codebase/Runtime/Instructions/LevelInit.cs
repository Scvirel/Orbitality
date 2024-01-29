using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class LevelInit : Instruction
    {
        [Inject] private readonly ILevelService _levelService = default;
        [Inject] private readonly ILevelDataState _levelDataState = default;

        [SerializeField] private Transform _planetSpawnPoint = default;
        [Inject] private readonly PlanetEntryExecutor.Factory _planetFactory = default;
        [Inject] private readonly PlanetConfig _planetConfig = default;
        [Inject] private readonly RocketEntryExecutor.Factory _rocketFactory = default;
        [Inject] private readonly RocketConfig _rocketConfig = default;

        [SerializeField] private GameObject _sun = default;

        public override void Execute()
        {
            _levelService.InsertPlanet(_sun);

            SpawnPlanets();

            if (_levelDataState.Value.Rockets != null)
            {
                SpawnRockets();
            }
        }

        private void SpawnPlanets()
        {
            List<PlanetDto> planetsToSpawn = new List<PlanetDto>();
            foreach (PlayerDataModel player in _levelDataState.Value.Players)
            {
                PlanetModel planet = _planetConfig.GetPlanetDataByType(player.ControlledPlanet.Type);
                planetsToSpawn.Add(
                    new PlanetDto(
                        planet.Type,
                        planet.Sprite,
                        planet.OrbitRotationSpeed,
                        planet.AxisRotationSpeed,
                        player.ControlledPlanet.Position,
                        player.Id,
                        player.Type
                        )
                    );
            }
            CreatePlanets(planetsToSpawn);
        }
        private void CreatePlanets(IEnumerable<PlanetDto> planets)
        {
            foreach (PlanetDto planet in planets)
            {
                PlanetEntryExecutor executor = _planetFactory.Create();
                executor.transform.SetParent(_planetSpawnPoint);
                executor.gameObject.transform.localScale = Vector3.one;
                executor.Execute(planet);

                _levelService.InsertPlanet(executor.gameObject);
            }
        }

        private void SpawnRockets()
        {
            List<RocketDto> rocketsToSpawn = new List<RocketDto>();

            foreach (RocketDataModel rocket in _levelDataState.Value.Rockets)
            {
                RocketModel rocketData = _rocketConfig.GetDataByType(rocket.Type);

                rocketsToSpawn.Add(
                    new RocketDto(
                        rocket.Type,
                        rocketData.Sprite,
                        rocketData.Speed,
                        rocketData.CooldownSec,
                        rocketData.Damage,
                        rocket.Position,
                        rocket.Rotation
                        )
                    );
            }

            CreateRockets(rocketsToSpawn);
        }

        private void CreateRockets(IEnumerable<RocketDto> rockets)
        {
            foreach (RocketDto rocket in rockets)
            {
                RocketEntryExecutor executor = _rocketFactory.Create();
                executor.gameObject.transform.localScale = Vector3.one;
                executor.Execute(rocket);

                _levelService.InsertRocket(executor.gameObject);
            }
        }
    }
}