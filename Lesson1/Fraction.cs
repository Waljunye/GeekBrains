using System;

namespace Lesson1
{
	public class Fraction
	{
		private double numerator { get; set; }
		private double denominator { get; set; }
		
		public Fraction(double _numerator = 0, double _denominator = 1)
		{
			numerator = _numerator;
			if (_denominator != 0)
            {
				denominator = _denominator;
			}else
            {
				throw new Exception("Знаменатель не может быть 0, так как на 0 делить нельзя!");
            }
			
		}

		public static Fraction Plus(Fraction o1, Fraction o2) 
        {
			double _numerator1 = o1.numerator;
			double _numerator2 = o2.numerator;
			double resNumerator;
			double _denominator1 = o1.denominator;
			double _denominator2 = o2.denominator;
			int resDenominator = 0;
			// Это я так ищу Наименьший общий знаменатель)
			while (true)
            {
				if (resDenominator % _denominator1 == 0 && resDenominator % _denominator2 == 0 && resDenominator != 0)
                {
					break;

                }else
                {
					resDenominator++;
                }
            }
			_numerator1 *= resDenominator / _denominator1;
			_numerator2 *= resDenominator / _denominator2;
			resNumerator = _numerator1 + _numerator2;
			return new Fraction(resNumerator, resDenominator);

		}
		public static Fraction Minus(Fraction o1, Fraction o2)
		{
			double _numerator1 = o1.numerator;
			double _numerator2 = o2.numerator;
			double resNumerator;
			double _denominator1 = o1.denominator;
			double _denominator2 = o2.denominator;
			int resDenominator = 0;
			// Это я так ищу Наименьший общий знаменатель)
			while (true)
			{
				if (resDenominator % _denominator1 == 0 && resDenominator % _denominator2 == 0 && resDenominator != 0)
				{
					break;

				}
				else
				{
					resDenominator++;
				}
			}
			_numerator1 *= resDenominator / _denominator1;
			_numerator2 *= resDenominator / _denominator2;
			resNumerator = _numerator1 - _numerator2;
			return new Fraction(resNumerator, resDenominator);
		}
		public static Fraction Multiply(Fraction o1, Fraction o2)
		{
			return new Fraction(o1.numerator * o2.numerator, o1.denominator * o2.denominator);
		}
		public static Fraction Divide(Fraction o1, Fraction o2)
		{
			return new Fraction(o1.numerator * o2.denominator, o1.denominator * o2.numerator);
		}
        public override string ToString()
        {
			return $"{numerator}/{denominator}";
        }
    }
}

