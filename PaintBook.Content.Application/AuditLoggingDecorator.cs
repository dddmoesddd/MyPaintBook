using CSharpFunctionalExtensions;
using FrameWork.Application;
using Newtonsoft.Json;
using System;

namespace PaintBook.Content.Application
{
    public sealed class AuditLoggingDecorator<TCommand> : ICommandHandler<TCommand>
       where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;

        public AuditLoggingDecorator(ICommandHandler<TCommand> handler)
        {
            _handler = handler;
        }

        public Result Handle(TCommand command)
        {
            string commandJson = JsonConvert.SerializeObject(command);

            // Use proper logging here
            Console.WriteLine($"Command of type {command.GetType().Name}: {commandJson}");

            return _handler.Handle(command);
        }
    }
}
