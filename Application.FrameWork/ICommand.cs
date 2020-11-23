using CSharpFunctionalExtensions;

namespace FrameWork.Application
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }

}
