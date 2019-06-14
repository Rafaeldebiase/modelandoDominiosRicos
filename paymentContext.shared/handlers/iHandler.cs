using PaymentContext.Shared.Command;

namespace PaymentContext.Shared.Handles
{
    public interface IHandler<T> where T: ICommand
    {
        ICommandResult Handle(T Command);
    }
}