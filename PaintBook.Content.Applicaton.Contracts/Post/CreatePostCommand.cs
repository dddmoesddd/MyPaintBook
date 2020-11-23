using CSharpFunctionalExtensions;
using MediatR;

namespace PaintBook.Content.Applicaton.Contracts.Post
{
    public class CreatePostCommand : IRequest<Result>
    {
        public string File { get; set; }
        public string Comment { get; set; }
        public string PostInfo { get; set; }
        public CreatePostCommand()
        {

        }
        public CreatePostCommand(string file, string comment, string postInfo)
        {
            File = file;
            Comment = comment;
            PostInfo = postInfo;
        }
    }
    public abstract class UpdatePostCommand : IRequest<Result>
    {
    }
    public abstract class DeletePostCommand : IRequest<Result>
    {
    }
}
