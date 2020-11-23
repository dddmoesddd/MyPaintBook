using FrameWork.Domian;
using System;
using System.Collections.Generic;

namespace PaintBook.Content.WrireModel.Domain.Person
{
    public  class Member : EntityBase, IAggregateRoot
    {
        public long NationalCode { get;private  set; }
        public string FullName { get;private  set; }
        public List<long> Tel { get;private  set; }
        public bool IsActive { get; private set; } 
        public DateTime Age { get;private set; }
        public void CreatPost() { }
        public void CreateCourse() { }

    }
}
