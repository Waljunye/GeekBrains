using System;

namespace Lesson1
{
	public class ComplexClass
	{
		private double ReC
		{
            get; set;
		}
		private double ImC
		{
            get; set;
		}
		public ComplexClass(double Re, double Im)
		{
			ReC = Re;
			ImC = Im;
		}
		public ComplexClass()
        {
			ReC = 0;
			ImC = 0;
        }
        public ComplexClass Plus(ComplexClass o)
        {
            ComplexClass res = new ComplexClass();
            res.ReC = ReC + o.ReC;
            res.ImC = ImC + o.ImC;
            return res;
        }
        public ComplexClass Minus(ComplexClass o)
        {
            ComplexClass res = new ComplexClass();
            res.ReC = ReC + o.ReC;
            res.ImC = ImC + o.ImC;

            return res;
        }
        public ComplexClass Divide(ComplexClass o)
        {
            ComplexClass res = new ComplexClass();
            if (o.ReC == 0 || o.ImC == 0)
            {
                throw new Exception("На ноль делить нельзя!");
            }
            else
            {
                res.ReC = ReC / o.ReC;
                res.ImC = ImC / o.ImC;
                return res;
            }

        }
        public ComplexClass Multiply(ComplexClass o)
        {
            ComplexClass res = new ComplexClass();
            res.ReC = ReC * o.ReC;
            res.ImC = ImC * o.ImC;

            return res;
        }

        public override string ToString()
        {
            //((Im != 0)?" + " + Im + "i": " ")
            return $"{((ReC != 0) ? ReC + ((ImC != 0) ? " + " + ImC + "i" : "") : (ImC != 0) ? ImC + "i" : "0")}";
            return $"{((ReC != 0) ? ReC + ((ImC != 0) ? " + " + ImC + "i" : "") : (ImC != 0) ? ImC + "i" : "0")}";
        }

    }
}
