using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class LevelService : ILevelService
    {
        [Inject] private readonly ILoadScene _loadScene = default;

        private List<GameObject> _planets = new List<GameObject>();
        public IEnumerable<GameObject> Planets 
        { 
            get => _planets; 
            set => _planets = value.ToList();
        }

        private List<GameObject> _rockets = new List<GameObject>();
        public IEnumerable<GameObject> Rockets 
        { 
            get => _rockets; 
            set => _rockets.ToList();
        }

        public void InsertPlanet(GameObject planet)
        {
            _planets.Add(planet);
        }
        public void RemovePlanet(GameObject planet)
        {
            _planets.Remove(planet);

            //Todo remove Plug
            if (_planets.Count == 1 || planet.GetComponent<PlanetDataState>().Value.PlayerType == PlayerType.RealPlayer)
            {
                _loadScene.Execute(GameScenes.GameOver, LoadSceneMode.Additive);
            }
        }

        public void InsertRocket(GameObject rocket)
        {
            _rockets.Add(rocket);
        }
        public void RemoveRocket(GameObject rocket)
        {
            _rockets.Remove(rocket);
        }
    }
}