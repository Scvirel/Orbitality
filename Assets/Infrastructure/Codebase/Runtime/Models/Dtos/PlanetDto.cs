using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class PlanetDto
    {
        public PlanetType Type = default;
        public Sprite Sprite = default;
        public float OrbitRotationSpeed = default;
        public float AxisRotationSpeed = default;
        public Vector3 Position = default;
        public string OwnerId = default;
        public PlayerType PlayerType = default;

        public PlanetDto(
            PlanetType type,
            Sprite sprite,
            float orbitRotationSpeed,
            float axisRotationSpeed,
            Vector3 position,
            string ownerId,
            PlayerType playerType)
        {
            Type = type;
            Sprite = sprite;
            OrbitRotationSpeed = orbitRotationSpeed;
            AxisRotationSpeed = axisRotationSpeed;
            Position = position;
            OwnerId = ownerId;
            PlayerType = playerType;
        }
    }
}