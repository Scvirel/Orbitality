using System;
using UnityEngine;

namespace Orbitality.Client.Runtime
{
    [Serializable]
    public sealed class RocketDto
    {
        public RocketType Type = default;
        public Sprite Sprite = default;
        public float Speed = default;
        public int CooldownMSec = default;
        public int Damage = default;
        public Vector3 Position = default;
        public Quaternion Rotation = default;

        public RocketDto(
            RocketType type,
            Sprite sprite,
            float speed,
            int cooldownMSec,
            int damage,
            Vector3 position,
            Quaternion rotation)
        {
            Type = type;
            Sprite = sprite;
            Speed = speed;
            CooldownMSec = cooldownMSec;
            Damage = damage;
            Position = position;
            Rotation = rotation;
        }
    }
}