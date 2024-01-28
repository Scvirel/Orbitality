using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [CreateAssetMenu(fileName = "RocketConfig", menuName = "Configs/RocketConfig", order = 2)]
    public sealed class RocketConfig : ScriptableObject
    {
        [SerializeField] private RocketModel[] _models = default;
    }
}