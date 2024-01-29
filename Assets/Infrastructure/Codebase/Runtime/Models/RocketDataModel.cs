using System;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [Serializable]
    public sealed class RocketDataModel
    {
        public RocketType Type = default;
        public Vector3 Position = default;
        public Quaternion Rotation = default;

        public RocketDataModel(
            RocketType type, 
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