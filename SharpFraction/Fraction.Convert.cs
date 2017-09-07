using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public static implicit operator Fraction(int obj) {
            return new Fraction(obj);
        }

        public static Fraction Parse(string str) {
            if (str.Contains("/")) {
                var args = str.Split(new char[] { '/' }, 2)
                    .Select(x => int.Parse(x)).ToArray();
                return new Fraction(args[0], args[1]);
            } else {
                return new Fraction(int.Parse(str));
            }
        }
    }
}
