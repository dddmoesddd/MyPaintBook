using FrameWork.Domian;
using PaintBook.Content.Domain.PostAndPostInfo.Events;
using System;
using System.Collections.Generic;

namespace PaintBook.Content.Domain.PostAndPostInfo.Model
{
    public class Post : EntityBase, IAggregateRoot
    {
        public string File { get; private set; }

        private  List<string> _comments;
        public IList<string> Comment { get { return _comments.AsReadOnly(); } }
        public string Caption { get; set; }
        public PostInfo PostInfo { get; private set; }
        public DateTime CreatedDateTime {get; private set; }
        public long UserIDCreatorPost { get; private set; }
        public bool IsDeleted { get; private set; }

        public Post()
        {

        }
        public   Post(string  file,string comment)
        {
            File = file;
            CreatedDateTime = DateTime.Now;
            UserIDCreatorPost = 12;
            Id = 11981;
            IsDeleted = false;
            Caption = "jhjh";
            //_comments = new List<string>();

            //_comments.Add(comment);

            this.AddDomainEvent(new PostCreatedEvent(UserIDCreatorPost, CreatedDateTime));

        }

        public void  PostDelet()
        { }

        public void PostUpdate()
        { }

    }
}
