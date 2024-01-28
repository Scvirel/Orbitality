using System;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [Serializable]
    public sealed class RocketModel
    {
        public RocketType RocketType = default;
        public Sprite Sprite = default;
        public float Acceleration = default;
        public float Weight = default;
        public int CooldownMSec = default;
        public int Damage = default;
    }
}