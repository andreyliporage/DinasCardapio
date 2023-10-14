using DinasCardapio.Shared.Commands;

namespace DinasCardapio.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
