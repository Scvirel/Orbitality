namespace Orbitality.Client.Runtime
{
    public interface IInstruction : ICommand
    { }
    public interface IInstruction<TInput> : INoResponseCommand<TInput>
    { }
}