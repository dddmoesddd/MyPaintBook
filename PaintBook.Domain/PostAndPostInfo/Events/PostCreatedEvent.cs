using MediatR;
using System;

namespace PaintBook.Content.Domain.PostAndPostInfo.Events
{
    public   class PostCreatedEvent:INotification
    {
        long UserID { get; set; }
        DateTime PostDateCreated { get; set; }

        public PostCreatedEvent(long userId, DateTime postCreated)
        {
            UserID = userId;
            PostDateCreated = postCreated;
        }
        public  void NotificationFollowerHandller()
        {



        }

    }
}
