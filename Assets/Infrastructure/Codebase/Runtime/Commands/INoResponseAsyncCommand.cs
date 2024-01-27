using System.Threading.Tasks;

namespace Orbitality.Client.Runtime
{
    public interface INoResponseAsyncCommand<TInput>
    {
        Task Execute(TInput input);
    }
}