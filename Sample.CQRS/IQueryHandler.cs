namespace Sample.CQRS
{
	public interface IQueryHandler<in T, out TResult> where T : IQuery<TResult>
	{
		TResult ExecuteAsync(T query);
	}

}