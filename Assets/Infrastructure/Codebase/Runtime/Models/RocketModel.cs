using System;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [Serializable]
    public sealed class RocketModel
    {
        public RocketType Type = default;
        public Sprite Sprite = default;
        public float Speed = default;
        public int CooldownMSec = default;
        public int Damage = default;
    }
}