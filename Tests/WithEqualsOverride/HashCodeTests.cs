
namespace EqualityTests.Tests.WithEqualsOverride
{
    using EqualityTests.Models.WithEqualsOverride;
    using Xunit;
    using System.Collections;
    using System.Collections.Generic;


    /// <summary>
    /// TESTS 
    /// <para>With EQUALS and HASHCODE override.</para>
    /// <para>Without == and != override</para>
    /// </summary>
    public class HashCodeTests
    {
        Dictionary<Identification, PersonOverride> dictionary = new Dictionary<Identification, PersonOverride>();
        Identification _globalID = new Identification { email = "mail@mail.com", Phone = "123456" };
        PersonOverride _globalPerson = new PersonOverride { FirstName = "Enrico", LastName = "Tirotta" };

        [Fact]
        public void DictionaryContainsValueSuccess()
        {
            dictionary.Add(_globalID, _globalPerson);

            Assert.True(dictionary.ContainsValue(new PersonOverride { FirstName = "Enrico", LastName = "Tirotta" }));
        }

        [Fact]
        public void DictionaryContainsKeySuccess()
        {
            dictionary.Add(_globalID, _globalPerson);

            Assert.True(dictionary.ContainsKey(new Identification { email = "mail@mail.com", Phone = "123456" }));
        }

        [Fact]
        public void HashTableContainsSuccess()
        {
            Hashtable table = new Hashtable();
            table.Add(_globalID, _globalPerson);

            Assert.True(table.Contains(new Identification { email = "mail@mail.com", Phone = "123456" }));
        }
    }
}
