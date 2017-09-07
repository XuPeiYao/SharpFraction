using System;
using System.Collections.Generic;
using System.Text;

namespace SharpFraction {
    public partial struct Fraction {
        /// <summary>
        /// 求兩數值之最小公倍數
        /// </summary>
        private static int LCM(int m, int n) {
            return m * n / GCD(m, n);
        }

        /// <summary>
        /// 求兩數值之最大公因數
        /// </summary>
        private static int GCD(int m, int n) {
            if (n == 0)
                return m;
            else
                return GCD(n, m % n);
        }

        public void ReduceSelf() {
            int gcd = GCD((int)Numerator, (int)Denominator);
            Numerator /= (uint)gcd;
            Denominator /= (uint)gcd;
        }

        public Fraction Reduce() {
            int gcd = GCD((int)Numerator, (int)Denominator);
            return new Fraction(
                Numerator / (uint)gcd,
                Denominator / (uint)gcd,
                IsNegative);
        }

        public Fraction Invert() {
            return new Fraction(Denominator, Numerator, IsNegative);
        }

        public Fraction Abs() {
            return new Fraction(Numerator, Denominator, false);
        }

        public bool Equals(Fraction other) {
            var a = Reduce();
            var b = other.Reduce();
            return a.IsNegative == b.IsNegative &&
                   a.Numerator == b.Numerator &&
                   a.Denominator == b.Denominator;
        }

        public override bool Equals(object obj) {
            if (obj is Fraction other) {
                return Equals(other);
            } else {
                return false;
            }
        }

        public int CompareTo(Fraction other) {
            int lcm = LCM((int)Denominator, (int)other.Denominator);

            var aD = lcm / Denominator;
            var bD = lcm / other.Denominator;

            var diff = aD * Numerator;
            var diff_ = bD * other.Numerator;
            if (IsNegative) {
                diff *= -1;
            }
            if (other.IsNegative) {
                diff_ *= -1;
            }
            diff -= diff_;

            if (diff == 0) {
                return 0;
            } else if (diff > 0) {
                return 1;
            } else {
                return -1;
            }
        }

        public int CompareTo(object obj) {
            if (obj is Fraction other) {
                return CompareTo(other);
            } else {
                throw new ArgumentException($"{nameof(obj)}參數應為{typeof(Fraction)}");
            }
        }

        public object Clone() {
            return new Fraction(Numerator, Denominator, IsNegative);
        }

        public override string ToString() {
            return
                (IsNegative ? "-" : "") +
                Numerator + "/" + Denominator;
        }
    }
}
