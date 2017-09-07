using System;
using System.Collections.Generic;
using System.Text;

namespace SharpFraction {
    public partial struct Fraction {

        public static explicit operator double(Fraction obj) {
            var result = obj.Numerator / (double)obj.Denominator;
            if (obj.IsNegative) result *= -1;
            return result;
        }

        public static explicit operator int(Fraction obj) {
            return (int)(double)obj;
        }
        /*
        public static Fraction FromDouble(double value) {

        }*/

        public static Fraction FromInt(int value) => new Fraction(value);
    }
}
