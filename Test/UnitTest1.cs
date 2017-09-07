using SharpFraction;
using System;
using Xunit;

namespace Test {
    public class UnitTest1 {
        [Fact]
        public void Test1() {
            var k = new Fraction(1, 3);
            var k2 = new Fraction(3, 3, true);
            var c = (double)(k + k2);

            Assert.Equal((double)(k + k2), (double)new Fraction(-2, 3));
        }
    }
}
