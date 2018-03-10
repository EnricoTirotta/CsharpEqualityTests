using System;
namespace EqualityTests.Models.WithEqualsOverride
{
    public class Identification
    {
        public string Phone { get; set; }
        public string email { get; set; }

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

            Identification id = (Identification)obj;

            return Phone == id.Phone && email == id.email;
		}

		public override int GetHashCode()
		{
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + (Phone != null ? Phone.GetHashCode() : 0);
                hash = hash * 23 + (email != null ? email.GetHashCode() : 0);
                return hash;
            }
		}
	}
}
