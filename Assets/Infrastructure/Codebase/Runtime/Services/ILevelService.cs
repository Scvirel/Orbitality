using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public interface ILevelService : IService
    {
        public IEnumerable<GameObject> Planets { get; set; }
        public IEnumerable<GameObject> Rockets { get; set; }

        public void InsertPlanet(GameObject planet);
        public void RemovePlanet(GameObject planet);

        public void InsertRocket(GameObject rocket);
        public void RemoveRocket(GameObject rocket);
    }
}