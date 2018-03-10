using System;
namespace EqualityTests.Models.WithEqualsAndOPOverride
{
    public class PersonComplete
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

            PersonComplete id = (PersonComplete)obj;

            return FirstName == id.FirstName && LastName == id.LastName;
        }

        public static bool operator ==(PersonComplete a, PersonComplete b)
        {
            //Reference equality
            if (ReferenceEquals(a, b))
                return true;

            //Call == op in OBJECT class with (object) casting. 
            //Avoid a==null or b==null: the Language Runtime calls the overload version
            //to causing an infinite loop.
            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(PersonComplete a, PersonComplete b)
        {
            return !(a == b);
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
