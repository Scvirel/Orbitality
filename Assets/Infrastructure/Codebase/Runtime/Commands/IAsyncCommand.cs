using System.Threading.Tasks;

namespace Orbitality.Client.Runtime
{
    public interface IAsyncCommand<in TInput, TOutput>
    {
        Task<TOutput> Execute(TInput input);
    }
}