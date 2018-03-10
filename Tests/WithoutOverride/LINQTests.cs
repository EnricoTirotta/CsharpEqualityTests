
namespace EqualityTests.Tests.WithoutOverride
{
    using System.Collections.Generic;
    using Xunit;
    using System.Linq;
    using EqualityTests.Models.WithoutOverride;

    public class LINQTests
    {
        List<PersonNoOverride> people = new List<PersonNoOverride>();
        Identification _globalID = new Identification { email = "mail@mail.com", Phone = "123456" };
        PersonNoOverride _globalPerson = new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" };

        [Fact]
        public void LINQAnySuccess()
        {
            people.Add(_globalPerson);

            PersonNoOverride _localPerson = new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" };
            bool check = people.Any(p => p == _localPerson);

            Assert.True(check);  //Expected TRUE, but test fails
        }

        [Fact]
        public void LINQSingleSuccess()
        {
            people.Add(_globalPerson);

            PersonNoOverride _localPerson = new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" };
            PersonNoOverride query = people.Single(p => p.Equals(_localPerson));
            Assert.NotNull(query); //Expected TRUE, but test Throws an InvalidOperationException. No Single() match

        }

        [Fact]
        public void LINQDistinctSuccess()
        {
            PersonNoOverride _localPerson = new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" };

            people.Add(_globalPerson);
            people.Add(_localPerson);

            int numberDistinctPeople = people.Distinct().Count();

            Assert.Equal(1, numberDistinctPeople);
            //Expected 1, but test fails because result is 2
        }
    }
}
