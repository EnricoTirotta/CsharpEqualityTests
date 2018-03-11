
namespace EqualityTests.Tests.WithoutOverride
{
    using EqualityTests.Models.WithoutOverride;
    using Xunit;
    using System.Collections;
    using System.Collections.Generic;
    using System;

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
        public void DictionaryContainsSameInstanceValueSuccess()
        {
            dictionary.Add(_globalID, _globalPerson);

            Assert.True(dictionary.ContainsValue(_globalPerson));
        }

        [Fact]
        public void DictionaryContainsKeySuccess()
        {
            dictionary.Add(_globalID, _globalPerson);

            Assert.True(dictionary.ContainsKey(new Identification { email = "mail@mail.com", Phone = "123456" }));
            //Expected TRUE, but test fails
        }

        [Fact]
        public void DictionaryAddSameKeySuccess()
        {
            Identification _sameId = new Identification { email = "mail@mail.com", Phone = "123456" };
            PersonNoOverride _samePerson = new PersonNoOverride { FirstName = "Enrico", LastName = "Tirotta" };

            dictionary.Add(_globalID, _globalPerson);
            dictionary.Add(_sameId, _samePerson);

            Assert.Equal(2,dictionary.Count);
            //We add 2 object with same key
        }

        [Fact]
        public void DictionaryIntAddSameKeyThrows()
        {
            Dictionary<int, string> _localD = new Dictionary<int, string>();

            _localD.Add(1, "hi");

            Assert.Throws<ArgumentException>(()=>_localD.Add(1, "hi i'm a duplicate key"));
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
