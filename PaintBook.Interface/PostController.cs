using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaintBook.Content.Applicaton.Contracts.Post;
using PaintBook.Interface.VIewModel;
using System.IO;

namespace PaintBook.Interface
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        CreatePostCommand _postcommand;
        private IMediator _mediator;
        public PostController()
        {

        }
        public PostController(IMediator mediatore)
        {
            _mediator = mediatore;
        }

        
        public void Post([FromBody] CreatePostViewModel CreatePostViewModel)
        {
          
            _postcommand = new CreatePostCommand(CreatePostViewModel.File, CreatePostViewModel.Comment, CreatePostViewModel.PostInfo);
            _mediator.Send(_postcommand);

        }

        public static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration["ContentConnectionString"];
        }
    }
}
