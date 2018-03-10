
namespace EqualityTests.Tests.WithEqualsOverride
{
    using Models.WithEqualsOverride;
    using Xunit;

    /// <summary>
    /// TESTS 
    /// <para>With EQUALS and HASHCODE override.</para>
    /// <para>Without == and != override</para>
    /// </summary>
    public class EqualsTests
    {
        PersonOverride _globalPerson1 = new PersonOverride { FirstName = "Enrico", LastName = "Tirotta" };
        PersonOverride _globalPerson2 = new PersonOverride { FirstName = "Enrico", LastName = "Tirotta" };

        [Fact]
        public void EqualsPeopleSuccess()
        {
            Assert.True(_globalPerson1.Equals(_globalPerson2));
        }

        [Fact]
        public void EqualsNullSuccess()
        {
            Assert.False(_globalPerson1.Equals(null));
            Assert.False(_globalPerson2.Equals(null));
        }

        [Fact]
        public void EqualsYourself()
        {
            Assert.True(_globalPerson1.Equals(_globalPerson1));
            Assert.True(_globalPerson2.Equals(_globalPerson2));
        }

        [Fact]
        public void EqualsOPPeopleSuccess()
        {
            Assert.True(_globalPerson1 == _globalPerson2);
            //Expected TRUE, but test fails. No Operator == override
            //Default == operator checks reference equals
        }


    }
}
