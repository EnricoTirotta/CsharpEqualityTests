namespace EqualityTests.Tests.WithoutOverride
{
    using System;
    using Xunit;

    public class ObjectEquality
    {
        [Fact]
        public void ReferenceEqualitySuccess()
        {
            Object a = new object();
            Object b = a;
            Assert.True(ReferenceEquals(a, b));

            Object c = b;
            Assert.True(ReferenceEquals(a, c)); 
        }

        [Fact]
        public void ReferenceEqualityFails()
        {
            Object a = new object();
            Object b = new object();
            Assert.False(ReferenceEquals(a, b));
        }
    }
}
