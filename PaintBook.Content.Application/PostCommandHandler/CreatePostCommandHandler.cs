using CSharpFunctionalExtensions;
using MediatR;
using PaintBook.Content.Applicaton.Contracts.Post;
using PaintBook.Content.Domain.PostAndPostInfo.Model;
using PaintBook.Content.Domain.PostAndPostInfo.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace PaintBook.Content.Application.PostCommandHandler
{
    public  class CreatePostCommandHandler : IRequestHandler<CreatePostCommand,Result>
    {
       private  IPostRepository _postRepository ;

        public CreatePostCommandHandler()
        {

        }
        public CreatePostCommandHandler(IPostRepository postrepository)
        {
            _postRepository = postrepository;
          
        }

        public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
             var post = new Post(request.File, request.Comment);
             _postRepository.Add(post);
           //  await  _postRepository.UnitOfWork.SaveEntitiesAsync();
            // await _unitofwork.SaveEntitiesAsync(cancellationToken);
            return Result.Success();

        }
    }

    public sealed class DeletePostCammandHandler : IRequestHandler<UpdatePostCommand, Result>
    {
        public Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

    public sealed class UpdateCammandHandler : IRequestHandler<DeletePostCommand, Result>
    {
        public Task<Result> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
