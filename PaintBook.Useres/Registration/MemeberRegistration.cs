using PaintBook.Content.WrireModel.Domain.Person;
using System;

namespace PaintBook.Content.WrireModel.Domain.Registration
{
    public  class MemeberRegistration
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public PersonType PersonType { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public MemeberRegistration(Member member)
        {
            CheckForSubscribtionStatus(member.NationalCode);
            RegisterPerson(member);
        }

        private void CheckForSubscribtionStatus(long nationalCode)
        {
            throw new NotImplementedException();
        }

        private Member RegisterPerson(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
