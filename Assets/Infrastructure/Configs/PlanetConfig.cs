using System.Linq;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [CreateAssetMenu(fileName = "PlanetConfig", menuName = "Configs/PlanetConfig", order = 1)]
    public sealed class PlanetConfig : ScriptableObject 
    {
        [SerializeField] private PlanetModel[] _models = default;

        public PlanetModel GetPlanetDataByType(PlanetType type)
        {
            return _models.First(item => item.Type == type);
        }
    }
}