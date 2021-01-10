namespace Sample.CQRS
{
	public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, int>
	{
		public int HandleAsync(CreateProductCommand command)
		{ 
			return 99;
		}
	}
}
