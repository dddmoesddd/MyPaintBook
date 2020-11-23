using CSharpFunctionalExtensions;
using MediatR;
namespace PaintBook.Content.Query
{
    public class GetContentQurery : IRequest<Result<GetContentQueryDTO>>

	{
		public GetContentQurery()
		{
		}
	}
}
