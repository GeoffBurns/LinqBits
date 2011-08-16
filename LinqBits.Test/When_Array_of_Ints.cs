
using NUnit.Framework;

namespace LinqBits.Test
{
    [TestFixture]
    public class When_Array_of_Ints
    {
        [Test]
        public void Then_ToJoinString_Should_produce_valid_string()
        {
            // Arrange
            var ar = new[] {1, 2, 3};
            // Act
            var s = ar.ToJoinedString();
            // Assert
            Assert.That(s.Equals("123"));
        }

        [Test]
        public void Then_WithSeparator_ToJoinString_Should_produce_valid_string()
        {
            // Arrange
            var ar = new[] { 1, 2, 3 };
            // Act
            var s = ar.WithSeparator("{",",","}").ToJoinedString();
            // Assert
            Assert.AreEqual(s,"{1,2,3}");
        }
    }
}
