namespace Sample.CQRS
{
	public interface ICommandHandler<in T, out TResult> where T : ICommand
    {
        TResult HandleAsync(T command);
    }

    public interface ICommandHandler<in T> where T : ICommand
    {
        void HandleAsync(T command);
    }
}
