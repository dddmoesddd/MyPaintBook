using MediatR;
using System.Collections.Generic;

namespace FrameWork.Domian
{
    public abstract class EntityBase 
    {
        /// <summary>
        ///   cant  go  to aggreagate root
        /// </summary>
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents =>
        _domainEvents?.AsReadOnly();
        int _Id;
        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public override bool Equals(object obj)
        {
            var entity = obj as EntityBase;
            if (entity == null) return false;

            return this.Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return 1;
            //return new HashCodeBuilder().Append(this.Id).ToHashCode();
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

    }
}
