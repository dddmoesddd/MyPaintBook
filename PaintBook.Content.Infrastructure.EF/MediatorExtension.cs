using CSharpFunctionalExtensions;
using FrameWork.Domian;
using MediatR;
using PaintBook.Content.Infrastructure.EF.PostAndPostInfo;
using System.Linq;
using System.Threading.Tasks;

namespace PaintBook.Content.Infrastructure.EF
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, ContentContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<EntityBase>()
                 .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
