using System;
namespace EqualityTests.Models.WithEqualsOverride
{
    public class Entity
    {
        //Example: ID is created by the DB
        public int Id { get; set; }
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

            Entity _entity = (Entity)obj;

            if (this.IsTransient() || _entity.IsTransient())
                return false;
            else
                return Id == _entity.Id;
        }

        private bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                if (!IsTransient())
                {
                    //Your hashcode algorithm here
                    var hash = 17;
                    hash = hash * 23 + Id.GetHashCode();
                    return hash;
                }
                else 
                    return base.GetHashCode();

            }
        }
    }
}
