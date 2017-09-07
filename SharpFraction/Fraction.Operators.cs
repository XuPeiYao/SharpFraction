using System;
using System.Collections.Generic;
using System.Text;

namespace SharpFraction {
    public partial struct Fraction {
        public static Fraction operator !(Fraction a) {
            return a.Invert();
        }

        public static Fraction operator +(Fraction a, Fraction b) {
            int lcm = LCM((int)a.Denominator, (int)b.Denominator);
            var aD = lcm / a.Denominator;
            var bD = lcm / b.Denominator;

            var aN = aD * a.Numerator;
            var bN = bD * b.Numerator;
            if (a.IsNegative) aN *= -1;
            if (b.IsNegative) bN *= -1;

            return new Fraction((int)(aN + bN), lcm).Reduce();
        }

        public static Fraction operator -(Fraction a, Fraction b) {
            b.IsNegative = !b.IsNegative;
            return (a + b).Reduce();
        }

        public static Fraction operator *(Fraction a, Fraction b) {
            var result = Fraction.Zero;

            result.IsNegative = a.IsNegative != b.IsNegative;
            result.Numerator = a.Numerator * b.Numerator;
            result.Denominator = a.Denominator * b.Denominator;

            return result.Reduce();
        }

        public static Fraction operator /(Fraction a, Fraction b) {
            return (a * b.Invert()).Reduce();
        }

        public static bool operator ==(Fraction a, Fraction b) {
            return a.Equals(b);
        }

        public static bool operator !=(Fraction a, Fraction b) {
            return !a.Equals(b);
        }

        public static bool operator >(Fraction a, Fraction b) {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <(Fraction a, Fraction b) {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >=(Fraction a, Fraction b) {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator <=(Fraction a, Fraction b) {
            return a.CompareTo(b) <= 0;
        }
    }
}