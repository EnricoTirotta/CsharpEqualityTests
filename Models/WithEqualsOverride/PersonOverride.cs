using System;
namespace EqualityTests.Models.WithEqualsOverride
{
    public class PersonOverride
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            //null
            if (obj == null)
                return false;

            //Same object
            if (ReferenceEquals(this, obj))
                return true;

            //Different type
            if (this.GetType() != obj.GetType())
                return false;

            PersonOverride id = (PersonOverride)obj;

            return FirstName == id.FirstName && LastName == id.LastName;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + (FirstName != null ? FirstName.GetHashCode() : 0);
                hash = hash * 23 + (LastName != null ? LastName.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
