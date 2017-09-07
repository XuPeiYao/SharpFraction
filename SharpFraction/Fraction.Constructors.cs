using System;

namespace SharpFraction {
    public partial struct Fraction : IEquatable<Fraction>, IComparable<Fraction>, IComparable, ICloneable {
        public static Fraction Zero => new Fraction(0);
        /// <summary>
        /// 取得或設定數值是否為負數
        /// </summary>
        public bool IsNegative { get; set; }

        /// <summary>
        /// 分子
        /// </summary>
        public uint Numerator { get; set; }

        /// <summary>
        /// 分母
        /// </summary>
        public uint Denominator { get; set; }

        public Fraction(int numerator)
            : this(numerator, 1) { }

        public Fraction(int numerator, int denominator) {
            IsNegative = false;
            if (numerator < 0) {
                IsNegative ^= true;
                numerator *= -1;
            }
            if (numerator < 0) {
                IsNegative ^= true;
                denominator *= -1;
            }
            Numerator = (uint)numerator;
            Denominator = (uint)denominator;
            ReduceSelf();
        }

        public Fraction(uint numerator, uint denominator, bool isNegative) {
            Numerator = numerator;
            Denominator = denominator;
            IsNegative = isNegative;
            ReduceSelf();
        }

        public Fraction(Fraction numerator, Fraction denominator) {
            var temp = numerator / denominator;
            Numerator = temp.Numerator;
            Denominator = temp.Denominator;
            IsNegative = temp.IsNegative;
            ReduceSelf();
        }
    }
}
