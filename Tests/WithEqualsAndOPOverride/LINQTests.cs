using System;
namespace EqualityTests.Tests.WithEqualsAndOPOverride
{
    using System.Collections.Generic;
    using Xunit;
    using System.Linq;
    using EqualityTests.Models.WithEqualsAndOPOverride;

    /// <summary>
    /// TESTS 
    /// <para>With EQUALS, HASHCODE and Operators "==" "!=" overrides.</para>
    /// </summary>
    public class LINQTests
    {
        List<PersonComplete> people = new List<PersonComplete>();
        PersonComplete _globalPerson = new PersonComplete { FirstName = "Enrico", LastName = "Tirotta" };

        [Fact]
        public void LINQAnySuccess()
        {
            people.Add(_globalPerson);

            PersonComplete _localPerson = new PersonComplete { FirstName = "Enrico", LastName = "Tirotta" };
            bool check = people.Any(p => p == _localPerson);

            Assert.True(check); 
        }

        [Fact]
        public void LINQSingleSuccess()
        {
            people.Add(_globalPerson);

            PersonComplete _localPerson = new PersonComplete { FirstName = "Enrico", LastName = "Tirotta" };
            PersonComplete query = people.Single(p => p == _localPerson);
            Assert.NotNull(query); 

        }

        [Fact]
        public void LINQDistinctSuccess()
        {
            people.Add(_globalPerson);

            PersonComplete _localPerson = new PersonComplete { FirstName = "Enrico", LastName = "Tirotta" };
            people.Add(_localPerson);

            int numberDistinctPeople = people.Distinct().Count();

            Assert.Equal(1, numberDistinctPeople);

        }
    }
}
