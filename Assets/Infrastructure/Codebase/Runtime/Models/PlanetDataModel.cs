using System;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [Serializable]
    public sealed class PlanetDataModel
    {
        public PlanetType Type = default;
        public Vector3 Position = default;
        public Quaternion Rotation = default;

        public PlanetDataModel(
            PlanetType type, 
            Vector3 position, 
            Quaternion rotation
            )
        {
            Type = type;
            Position = position;
            Rotation = rotation;
        }
    }
}