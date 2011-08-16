using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LinqBits.Test
{
    [TestFixture]
    public class When_Array_of_Array_of_Int
    {
        [Test]
        public void Then_ToJoinString_Should_produce_valid_string_with_separator_start_and_end()
        {
            // Arrange
            var ar = new[] { new int[]{}, new []{1}, new []{2,3} };
            // Act
            var s = ar.ToJoinedString("{", (a, sb) => sb.Append(a.ToJoinedString()), ",", "}");
            // Assert
            Assert.AreEqual(s,"{,1,23}");
        }
        [Test]
        public void Then_ToJoinString_Should_produce_valid_string()
        {
            // Arrange
            var ar = new[] { new int[] { }, new[] { 1 }, new[] { 2, 3 } };
            // Act
            var s = ar.ToJoinedString((a, sb) => sb.Append(a.ToJoinedString()));
            // Assert
            Assert.AreEqual(s,"123");
        }
        [Test]
        public void Then_ToJoinStringBuilder_Should_produce_valid_string()
        {
            // Arrange
            var ar = new[] { new int[] { }, new[] { 1 }, new[] { 2, 3 } };
            // Act
            var s = ar.ToJoinedString((a, sb) => a.ToJoinedStringBuilder(sb));
            // Assert
            Assert.AreEqual(s,"123");
        }
        [Test]
        public void Then_ToJoinString_Should_produce_valid_string_with_separator()
        {
            // Arrange
            var ar = new[] { new int[] { }, new[] { 1 }, new[] { 2, 3 } };
            // Act
            var s = ar.SelectMany(a=>(IEnumerable<int>)(a)).ToJoinedString(",");
            // Assert
            Assert.AreEqual(s,"1,2,3");
        }
        [Test]
        public void Then_ToJoinStringBuilder_Should_produce_valid_string_with_separator()
        {
            // Arrange
            var ar = new[] { new int[] { }, new[] { 1 }, new[] { 2, 3 } };
            // Act
            var s = ar.ToJoinedString((a, sb) => a.ToJoinedStringBuilder(sb, ","), ",");
            // Assert
            Assert.AreEqual(s, ",1,2,3");
        }
        [Test]
        public void Then_ToJoinStringBuilder_Should_produce_valid_string_with_separator_start_and_end()
        {
            // Arrange
            var ar = new[] { new int[] { }, new[] { 1 }, new[] { 2, 3 } };
            // Act
            var s = ar.ToJoinedString((a, sb) => a.ToJoinedStringBuilder(sb, "{", ",", "}"), "," );
            // Assert
            Assert.AreEqual(s, "{},{1},{2,3}");
        }
    }
}
