namespace Orbitality.Client.Runtime
{
    public interface INoResponseCommand<in TInput>
    {
        void Execute(TInput input);
    }
    public interface INoResponseCommand<in TInput1, in TInput2>
    {
        void Execute(TInput1 input1, TInput2 input2);
    }
}