namespace Task4._2
{
    using System;

    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            RationalNumber other = (RationalNumber)obj;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public int CompareTo(RationalNumber other)
        {
            double thisValue = (double)Numerator / Denominator;
            double otherValue = (double)other.Numerator / other.Denominator;
            return thisValue.CompareTo(otherValue);
        }

        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            int num = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
            int den = r1.Denominator * r2.Denominator;
            return new RationalNumber(num, den);
        }

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            int num = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
            int den = r1.Denominator * r2.Denominator;
            return new RationalNumber(num, den);
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            int num = r1.Numerator * r2.Numerator;
            int den = r1.Denominator * r2.Denominator;
            return new RationalNumber(num, den);
        }

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            int num = r1.Numerator * r2.Denominator;
            int den = r1.Denominator * r2.Numerator;
            return new RationalNumber(num, den);
        }

        public static explicit operator double(RationalNumber rational)
        {
            return (double)rational.Numerator / rational.Denominator;
        }

        public static implicit operator RationalNumber(int value)
        {
            return new RationalNumber(value, 1);
        }
    }
}
