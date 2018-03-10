
namespace EqualityTests.Models.WithEqualsOverride
{
    public class PersonOverride
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
            PersonOverride _localP = (PersonOverride)obj;  

            //5 - Custom equality behavior
            return FirstName == _localP.FirstName 
                   && LastName == _localP.LastName; 
        }

        public bool Equals(PersonOverride p)
        {
            if (p == null)
                return false;

            //Same object
            if (ReferenceEquals(this, p))
                return true;

            return FirstName == p.FirstName && LastName == p.LastName;
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
