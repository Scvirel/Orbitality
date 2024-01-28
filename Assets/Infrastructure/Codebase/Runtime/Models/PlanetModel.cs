using System;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [Serializable]
    public sealed class PlanetModel
    {
        public PlanetType PlanetType = default;
        public Sprite Sprite = default;
        public float OrbitRotationSpeed = default;
        public float AxisRotationSpeed = default;
    }
}