using SharpFraction;
using System;
using Xunit;

namespace Test {
    public class UnitTest1 {
        [Fact]
        public void Add() {
            var a = new Fraction(1, 3);
            var b = new Fraction(2, 3);
            Assert.Equal((double)(a + b), (double)new Fraction(1));
        }

        [Fact]
        public void Sub() {
            var a = new Fraction(1, 3);
            var b = new Fraction(2, 3);
            Assert.Equal((double)(a - b), (double)new Fraction(1, 3, true));
        }

        [Fact]
        public void Div() {
            var a = 1 / new Fraction(1, 3);
            Assert.Equal(a, 3);
        }
    }
}
