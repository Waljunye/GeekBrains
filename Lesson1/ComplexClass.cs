using System;

namespace Lesson1
{
	public class ComplexClass
	{
		private double Re
		{
			get
			{
				return Re;
			}
			set
			{
				Re = value;
			}
		}
		private double Im
		{
			get
			{
				return Im;
			}
			set
			{
				Im = value;
			}
		}
		public ComplexClass(double Re, double Im)
		{
			this.Re = Re;
			this.Im = Im;
		}
		public ComplexClass()
        {
			Re = 0;
			Im = 0;
        }
        public ComplexClass Plus(ComplexClass o)
        {
            ComplexClass res = new ComplexClass();
            res.Re = Re + o.Re;
            res.Im = Im + o.Im;
            return res;
        }
        public ComplexClass Minus(ComplexClass o)
        {
            ComplexClass res = new ComplexClass();
            res.Re = Re + o.Re;
            res.Im = Im + o.Im;

            return res;
        }
        public ComplexClass Divide(ComplexClass o)
        {
            ComplexClass res = new ComplexClass();
            if (o.Re == 0 || o.Im == 0)
            {
                throw new Exception("На ноль делить нельзя!");
            }
            else
            {
                res.Im = Re / o.Re;
                res.Im = Im / o.Im;
                return res;
            }

        }
        public ComplexClass Multiply(ComplexClass o)
        {
            ComplexClass res = new ComplexClass();
            res.Re = Re * o.Re;
            res.Im = Im * o.Im;

            return res;
        }

    }
}
