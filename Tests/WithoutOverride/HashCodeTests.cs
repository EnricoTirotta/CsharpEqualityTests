
namespace EqualityTests.Tests.WithoutOverride
{
    using EqualityTests.Models.WithoutOverride;
    using Xunit;
    using System.Collections;
    using System.Collections.Generic;

    public class HashCodeTests
    {
        Dictionary<Identification, PersonNoOverride> dictionary = new Dictionary<Identification, PersonNoOverride>();
        Identification _globalID = new Identification { email = "mail@mail.com", Phone = "123456" };
        PersonNoOverride _globalPerson = new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" };

        [Fact]
        public void DictionaryContainsValueSuccess()
        {
            dictionary.Add(_globalID, _globalPerson);

            Assert.True(dictionary.ContainsValue(new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" }));
            //Expected TRUE, but test fails

        }

        [Fact]
        public void DictionaryContainsKeySuccess()
        {
            dictionary.Add(_globalID, _globalPerson);

            Assert.True(dictionary.ContainsKey(new Identification { email = "mail@mail.com", Phone = "123456" }));
            //Expected TRUE, but test fails
        }

        [Fact]
        public void HashTableContainsSuccess()
        {
            Hashtable table = new Hashtable();
            table.Add(_globalID, _globalPerson);

            Assert.True(table.Contains(new Identification { email = "mail@mail.com", Phone = "123456" })); //False - Test fails
            //Expected TRUE, but test fails
        }
    }
}
