using System;
namespace EqualityTests.Tests.WithEqualsAndOPOverride
{
    using Models.WithEqualsAndOPOverride;
    using Xunit;

    /// <summary>
    /// TESTS 
    /// <para>With EQUALS, HASHCODE and Operators "==" "!=" overrides.</para>
    /// </summary>
    public class EqualsTests
    {
        PersonComplete _globalPerson1 = new PersonComplete { FirstName = "Enrico", LastName = "Tirotta" };
        PersonComplete _globalPerson2 = new PersonComplete { FirstName = "Enrico", LastName = "Tirotta" };

        // x.Equals(null) always false
        [Fact]
        public void EqualsOPNullSuccess()
        {
            Assert.False(_globalPerson1 == null);
            Assert.False(_globalPerson2 == null);
        }

        // x.Equals(x) always true
        [Fact] 
        public void EqualsOPYourself()
        {
            Assert.True(_globalPerson1 == _globalPerson1);
            Assert.True(_globalPerson2 == _globalPerson2);
        }

        [Fact]
        public void EqualsOPPeopleSuccess()
        {
            Assert.True(_globalPerson1 == _globalPerson2);
        }
    }
}
