using FluentValidation;
using PaintBook.Content.Applicaton.Contracts.DTO;

namespace PaintBook.Content.Applicaton.Contracts.Post
{
    public    class CreatePostCommandvalidatore: AbstractValidator<CreatePostDTO>
    {
        public CreatePostCommandvalidatore()
        {
            //RuleFor(command => command.City).NotEmpty();
            //RuleFor(command => command.Street).NotEmpty();
            //RuleFor(command => command.Country).NotEmpty();
            //RuleFor(command => command.ZipCode).NotEmpty();
            //RuleFor(command => command.Items).Must(ContainOrderItems).WithMessage("No order items found");

        }


    }
}
