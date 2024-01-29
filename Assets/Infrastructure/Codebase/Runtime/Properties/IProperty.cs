namespace Orbitality.Client.Runtime
{
    public interface IProperty<Type>
    {
        public Type Value { get; set; }
    }
}