
namespace EqualityTests.Models
{
    public class HashCodeAlgorithms
    {
        private int Id { get; set; }

        public int AddHash()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                return hash;
            }
        }

        public int AddHash2()
        {
            unchecked
            {
                var hash = 7;
                hash = hash * 13 + Id.GetHashCode();
                return hash;
            }
        }

        public int XorHash()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 ^ Id.GetHashCode();
                return hash;
            }
        }

        public int XorWithPrimeNumber()
        {
            return Id.GetHashCode() ^ 41;
        }

        public int XorHash3()
        {
            unchecked
            {
                var hash = 7;
                hash = hash * 13 ^ Id.GetHashCode();
                return hash;
            }
        }

        public int FNVmodified()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ Id.GetHashCode();
                return hash;
            }
        }
    }
}
