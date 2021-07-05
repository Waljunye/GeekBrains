using System;
using System.Threading;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Авторизация

            byte guess = 1;
            bool isLoggined = false;

            do
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();
                if (login != "root")
                {
                    // Не ругайте! Дело было ночью, мне было нечего делать))
                    Console.WriteLine($"Неверно введен логин! Осталось {3 - guess} {(3 - guess >= 2 ? "попытки" : (3 - guess == 1 ? "попытка" : "попыток"))}");

                } else if(password != "foobar")
                {
                    Console.WriteLine($"Неверно введен пароль! Осталось {3 - guess} {(3 - guess >= 2 ? "попытки" : (3 - guess == 1 ? "попытка" : "попыток" ))}");
                } else
                {
                    Console.WriteLine("Есть!");
                    isLoggined = true;
                    break;
                }
            } while (++guess <= 3);

            if (!isLoggined) return;

            #endregion
            #region Минимальное значение из трех
            Console.WriteLine("Минимальное значение из трех(1 задание)");

            Console.Write("Введите первое значение: ");
            int param1 = int.Parse(Console.ReadLine());
            Console.Write("Введите второе значение: ");
            int param2 = int.Parse(Console.ReadLine());
            Console.Write("Введите третье значение: ");
            int param3 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Минимальное значение из чисел {param1}, {param2}, {param3} это {MinValue(param1, param2, param3)}"); ; ;
            #endregion
            #region Подсчет количества цифр в числе
            Console.Write("Введите число: ");
            int param = int.Parse(Console.ReadLine());
            Console.WriteLine($"Количество цифр в числе {param} равно {CountOfNumbersInNumber(param)}");
            #endregion
            #region Практика циклов + Сумма всех введенных нечетных положительных чисел
            int inp = 0;
            int sum = 0;
            do
            {
                Console.Write("Введите число (При вводе 0 программа завершится): ");
                inp = int.Parse(Console.ReadLine());
                if (inp % 2 != 0 && inp > 0)
                {
                    sum += inp;
                }
            } while (inp != 0);

            Console.WriteLine($"Сумма всех введенных нечетных положительных чисел = {sum}");
            #endregion
            #region Прокаченный индекс массы тела
            Console.Write("Введите масу тела(в килограммах): ");
            double m = double.Parse(Console.ReadLine());

            Console.Write("Введите рост тела(в метрах): ");
            double h = double.Parse(Console.ReadLine());

            double IMB = m / (h * h);

            string needMoreMass = "Индекс массы тела маловат, нужно поднабрать!";
            string normal = "Индекс массы тела самое то";
            string needLessMass = "Индекс массы тела большеват, нужно похудеть";

            Console.WriteLine(IMB < 18.5 ? needMoreMass : (IMB >= 18.5 && IMB < 25 ? normal : needLessMass));  ;
            #endregion
            #region Рекурсивный метод для вывода чисел ОТ a ДО b
            Console.Write("Введите число ОТ: ");
            int from = int.Parse(Console.ReadLine());

            Console.Write("Введите число ДО: ");
            int to = int.Parse(Console.ReadLine());

            PrintNumbers(from, to);
            #endregion
            #region *Рекурсивный метод для получения суммы чисел ОТ a ДО b 
            Console.Write("Введите число ОТ: ");
            from = int.Parse(Console.ReadLine());

            Console.Write("Введите число ДО: ");
            to = int.Parse(Console.ReadLine());

            Console.WriteLine($"Сумма чисел ОТ {from} до {to} равна {RecursiveSumOfNumbers(from, to)}");
            #endregion
            #region Хорошие числа
            // Я обязательно запущу это на xeon platinum
            int answ = 0;
            int sumOfDigit = 0;
            // * 
            DateTime start = DateTime.Now;
            for (int i = 1; i <= 1_000_000_000; i++)
            {
                Console.WriteLine($"Сейчас обрабатывается число: {i}");
                foreach (char ch in i.ToString())
                {
                    sumOfDigit += int.Parse(ch.ToString());
                }
                if (i % sumOfDigit == 0)
                {
                    answ++;
                }
                sumOfDigit = 0;

            }
            Console.WriteLine($"Всего \"Хороших\" чисел: {answ}");
            // *
            Console.WriteLine($"Время выполнения алгоритма: {(DateTime.Now - start).ToString()}");
            #endregion
        }

        /// <summary>
        /// Собственно, первое задание. 3 конструкции if / else if, только запутаннее
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Третье число</param>
        /// <returns></returns>
        static int MinValue(int a, int b, int c)
        {
            return a <= b ? (a <= c ? a : c) : b <= a ? (b <= c ? b : c) : c <= a ? (c <= b ? c : b) : 0;   
        }

        /// <summary>
        /// Подсчет количества цифр в числе
        /// </summary>
        /// <param name="num">Число</param>
        /// <returns></returns>
        static int CountOfNumbersInNumber(int num)
        {
            string numString = num.ToString();
            int retValue = 0;
            foreach (char _ in numString){
                retValue++;
            }
            return retValue;
        }

        /// <summary>
        /// Рекурсивный метод для вывода чисел ОТ a ДО b
        /// </summary>
        /// <param name="a">ОТ</param>
        /// <param name="b">ДО</param>
        static void PrintNumbers(int a, int b)
        {
            if(a > b)
            {
                Console.WriteLine("Программа выполнена");
            } else
            {
                Console.Write($"{a}\t");
                PrintNumbers(a + 1, b);
            }
        }

        /// <summary>
        /// *Рекурсивный метод для получения суммы чисел ОТ a ДО b 
        /// </summary>
        /// <param name="a">ОТ</param>
        /// <param name="b">ДО</param>
        /// <returns>Сумма ОТ a ДО b</returns>
        static int RecursiveSumOfNumbers(int a, int b)
        {
            if (a > b)
            {
                return 0;
            }
            else
            {
                return a + RecursiveSumOfNumbers(a + 1, b);
            }
        }
    }
}
