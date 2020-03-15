using System.Threading.Tasks;

namespace Sample.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> ExecuteAsync<T, TResult>(T query) where T : IQuery<TResult>;
    }
}
