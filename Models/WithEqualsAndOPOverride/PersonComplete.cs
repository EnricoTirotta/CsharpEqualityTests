
namespace EqualityTests.Models.WithEqualsAndOPOverride
{
    public class PersonComplete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            //1- Guard against null  
            if (obj == null)  
                return false;  
  
            //2 - Check reference equality 
            if (ReferenceEquals(this, obj))  
                return true;  
  
            //3 - Check type
            if (this.GetType() != obj.GetType())  
                return false;  

            //4 - Casting
            PersonComplete _localP = (PersonComplete)obj;

            //5 - Custom equality behaviour
            return FirstName == _localP.FirstName && LastName == _localP.LastName;
        }

        public static bool operator ==(PersonComplete a, PersonComplete b)
        {
            //Reference equality
            if (ReferenceEquals(a, b))
                return true;

            //Call == op in OBJECT class with (object) casting. 
            //Avoid a==null or b==null: the CLR calls the overload version
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
