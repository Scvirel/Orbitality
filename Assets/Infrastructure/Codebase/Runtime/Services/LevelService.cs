using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class LevelService : ILevelService
    {
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