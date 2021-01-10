namespace Sample.CQRS
{
	public interface ICommandWithResult<T> : ICommand where T : struct
    {
        
    }
}
