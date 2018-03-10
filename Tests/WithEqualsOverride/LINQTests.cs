
namespace EqualityTests.Tests.WithEqualsOverride
{
    using System.Collections.Generic;
    using Xunit;
    using System.Linq;
    using EqualityTests.Models.WithEqualsOverride;

    public class LINQTests
    {
        List<PersonOverride> people = new List<PersonOverride>();
        Identification _globalID = new Identification { email = "mail@mail.com", Phone = "123456" };
        PersonOverride _globalPerson = new PersonOverride { FirstName = "Enrico", LastName = "Tirotta" };

        [Fact]
        public void LINQAnySuccess()
        {
            people.Add(_globalPerson);

            PersonOverride _localPerson = new PersonOverride { FirstName = "Enrico", LastName = "Tirotta" };
            //bool check = people.Any(p => p == _psOne); == FAILS << no override
            bool check = people.Any(p => p.Equals(_localPerson));

            Assert.True(check); 
        }

        [Fact]
        public void LINQSingleSuccess()
        {
            people.Add(_globalPerson);

            PersonOverride _localPerson = new PersonOverride { FirstName = "Enrico", LastName = "Tirotta" };
            PersonOverride query = people.Single(p => p.Equals(_localPerson));
            Assert.NotNull(query);

        }

        [Fact]
        public void LINQDistinctSuccess()
        {
            people.Add(_globalPerson);

            PersonOverride _localPerson = new PersonOverride { FirstName = "Enrico", LastName = "Tirotta" };
            people.Add(_localPerson);

            int numberDistinctPeople = people.Distinct().Count();

            Assert.Equal(1, numberDistinctPeople);
        }
    }
}
