using MediatR;
using PaintBook.Content.Applicaton.Contracts.MemberRegister;
using System.Threading;
using System.Threading.Tasks;

namespace PaintBook.Content.Application.MemberRegisterationHandler
{
    public sealed class CreateMemberHandler : IRequestHandler<CreateMemberCommands>
    {

        Task<Unit> IRequestHandler<CreateMemberCommands, Unit>.Handle(CreateMemberCommands request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
    public sealed class DeleteMemberHandler : IRequestHandler<DeleteMemberCommands>
    {

        Task<Unit> IRequestHandler<DeleteMemberCommands, Unit>.Handle(DeleteMemberCommands request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

    public sealed class UpdateMemberHandler : IRequestHandler<UpdateMemberCommands>
    {
        Task<Unit> IRequestHandler<UpdateMemberCommands, Unit>.Handle(UpdateMemberCommands request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
