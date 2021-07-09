using System;

namespace Lesson1
{
    class Program
    {
        public struct Complex
        {
            public double Re;
            public double Im;

            public override string ToString()
            {
                //((Im != 0)?" + " + Im + "i": " ")
                return $"{((Re != 0) ? Re + ((Im != 0) ? " + " + Im + "i" : "") : (Im != 0) ? Im + "i" : "0")}";
            }

            public Complex Plus(Complex o)
            {
                Complex res;
                res.Re = Re + o.Re;
                res.Im = Im + o.Im;
                return res;
            }
            public Complex Minus(Complex o)
            {
                Complex res;
                res.Re = Re + o.Re;
                res.Im = Im + o.Im;

                return res;
            }
            public Complex Divide(Complex o)
            {
                Complex res;
                if (o.Re == 0 || o.Im == 0)
                {
                    throw new Exception("На ноль делить нельзя!");
                }
                else
                {
                    res.Re = Re / o.Re;
                    res.Im = Im / o.Im;
                    return res;
                }

            }
            public Complex Multiply(Complex o)
            {
                Complex res;
                res.Re = Re * o.Re;
                res.Im = Im * o.Im;

                return res;
            }
        }
        static void Main(string[] args)
        {
            #region Демонстрация Работы структуры Complex
            Complex Test;
            Complex Test2;
            Console.Write("Введите действительную часть первого числа: ");
            if (!double.TryParse(Console.ReadLine(), out Test.Re))
            {
                throw new Exception("Введенная строка не может быть составным элементом комплексного числа");
            }
            Console.Write("Введите мнимую часть первого числа: ");
            if (!double.TryParse(Console.ReadLine(), out Test.Im))
            {
                throw new Exception("Введенная строка не может быть составным элементом комплексного числа");
            }
            Console.Write("Введите действительную часть второго числа: ");
            if (!double.TryParse(Console.ReadLine(), out Test2.Re))
            {
                throw new Exception("Введенная строка не может быть составным элементом комплексного числа");
            }
            Console.Write("Введите мнимую часть второго числа: ");
            if (!double.TryParse(Console.ReadLine(), out Test2.Im))
            {
                throw new Exception("Введенная строка не может быть составным элементом комплексного числа");
            }
            // toString 
            Console.WriteLine($"Метод toString() {Test}");

            // Plus 
            Console.WriteLine($"Сумма комплексных чисел {Test} и {Test2} равны {Test.Plus(Test2)}");

            // Minus 
            Console.WriteLine($"Разность комплексных чисел {Test} и {Test2} равны {Test.Minus(Test2)}");

            // Divide
            Console.WriteLine($"Частное комплексных чисел {Test} и {Test2} равны {Test.Divide(Test2)}");

            // Multiply
            Console.WriteLine($"Произведение комплексных чисел {Test} и {Test2} равны {Test.Multiply(Test2)}");



            double Re1;
            Console.Write("Введите действительную часть первого числа: ");
            if (!double.TryParse(Console.ReadLine(), out Re1))
            {
                throw new Exception("Введенная строка не может быть составным элементом комплексного числа");
            }
            double Im1;
            Console.Write("Введите мнимую часть первого числа: ");
            if (!double.TryParse(Console.ReadLine(), out Im1))
            {
                throw new Exception("Введенная строка не может быть составным элементом комплексного числа");
            }
            double Re2;
            Console.Write("Введите действительную часть второго числа: ");
            if (!double.TryParse(Console.ReadLine(), out Re2))
            {
                throw new Exception("Введенная строка не может быть составным элементом комплексного числа");
            }
            double Im2;
            Console.Write("Введите мнимую часть второго числа: ");
            if (!double.TryParse(Console.ReadLine(), out Im2))
            {
                throw new Exception("Введенная строка не может быть составным элементом комплексного числа");
            }
            ComplexClass complexClass1 = new ComplexClass(Re1, Im1);
            ComplexClass complexClass2 = new ComplexClass(Re2, Im2);
            Console.Write("Выберите операцию: ");

            switch (Console.ReadLine())
            {
                case "+":
                    {
                        Console.WriteLine($"Сумма комплексных чисел {complexClass1} и {complexClass2} равны {complexClass1.Plus(complexClass2)}");
                        break;
                    }
                case "-":
                    {
                        Console.WriteLine($"Разность комплексных чисел {complexClass1} и {complexClass2} равны {complexClass1.Minus(complexClass2)}");
                        break;
                    }
                case "*":
                    {
                        Console.WriteLine($"Произведение комплексных чисел {complexClass1} и {complexClass2} равны {complexClass1.Multiply(complexClass2)}");
                        break;
                    }
                case "/":
                    {
                        Console.WriteLine($"Частное комплексных чисел {complexClass1} и {complexClass2} равны {complexClass1.Divide(complexClass2)}");
                        break;
                    }


                    #endregion
            }
        }
    }
}
