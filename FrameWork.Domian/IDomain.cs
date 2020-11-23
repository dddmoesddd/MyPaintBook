using System;
using System.Collections.Generic;

namespace FrameWork.Domian
{
    public  interface IDomainEvent
    {
    }

    public  interface  IBus
    {
        void Send(string  message);
    }


    public class MessageBus
    {

        private readonly IBus _bus;
        public MessageBus(IBus bus)
        {
            _bus = bus;
        }

        public void PostCreatedMessage(string userid, string postid)
        {
            _bus.Send("dsdds");
        }
    }


    public  class EventDispatcher
    {
        private readonly MessageBus _messageBus;
        public EventDispatcher(MessageBus messagebus)
        {
            _messageBus = messagebus; 
        }

        public void  Dispatch(IEnumerable<IDomainEvent> events)
        {
            foreach (IDomainEvent ev in events)
            {
                Dispatch(ev);
            }
        }

        private void Dispatch(IDomainEvent ev)
        {
            //switch ()
            //{

            //}

            _messageBus.PostCreatedMessage("", "");
        }
    }

 
}
