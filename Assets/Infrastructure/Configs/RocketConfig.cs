using System.Linq;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [CreateAssetMenu(fileName = "RocketConfig", menuName = "Configs/RocketConfig", order = 2)]
    public sealed class RocketConfig : ScriptableObject
    {
        [SerializeField] private RocketModel[] _models = default;

        public RocketModel GetDataByType(RocketType type)
        {
            return _models.First(item => item.Type == type);
        }
    }
}