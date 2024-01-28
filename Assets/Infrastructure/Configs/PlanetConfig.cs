using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [CreateAssetMenu(fileName = "PlanetConfig", menuName = "Configs/PlanetConfig", order = 1)]
    public sealed class PlanetConfig : ScriptableObject 
    {
        [SerializeField] private PlanetModel[] _models = default;
    }
}