using MediatR;
using PaintBook.Content.Application.PostCommandHandler;
using PaintBook.Content.Applicaton.Contracts.Post;
using System;
using System.Web.Http;

namespace PainBookInterFace
{
    public class PostController:ApiController
    {

        CreatePostCommand _postcommand;
        private readonly IMediator _mediator;

        public PostController(CreatePostCommand postCommand)
        {
            postCommand = _postcommand;
        }
        public void Post()
        {
            _postcommand.comment = "lklk";
            _postcommand.File = "kjkjk";
            _mediator.Send(_postcommand);
        }
    }
}
