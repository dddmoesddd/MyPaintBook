using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace PaintBook.Content.WrireModel.Domain.Person
{
    public class Address : ValueObject
    {
        public   string MemmberAddress { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }

    }
}
