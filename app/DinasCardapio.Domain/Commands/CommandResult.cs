using DinasCardapio.Shared.Commands;

namespace DinasCardapio.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, dynamic? data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic? Data { get; set; }
    }
}
