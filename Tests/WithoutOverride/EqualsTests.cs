
namespace EqualityTests.Tests.WithoutOverride
{
    using Models.WithoutOverride;
    using Xunit;

    public class EqualsTests
    {
        PersonNoOverride _globalPerson1 = new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" };
        PersonNoOverride _globalPerson2 = new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" };

        [Fact]
        public void EqualsPeopleSuccess()
        {
            Assert.True(_globalPerson1.Equals(_globalPerson2));
            //Expected TRUE, but test fails
        }

    }
}
