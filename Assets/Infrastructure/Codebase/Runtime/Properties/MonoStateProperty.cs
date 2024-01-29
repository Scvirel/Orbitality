using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public abstract class MonoStateProperty<Type> : MonoBehaviour, IProperty<Type>
    {
        public abstract Type Value { get; set; }
    }
}