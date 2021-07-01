using System;

namespace Lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Программа «Анкета»
            Console.Write("Здравствуйте! Введите своё имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите свою фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("Введите свой возраст: ");
            Int16 age = Int16.Parse(Console.ReadLine());

            Console.Write("Введите свой рост: ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Введите свой вес: ");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Вывод склейкой: ");
            Console.WriteLine(
                "Ваше имя: " + name +
                "\nВаша фамилия: " + surname +
                "\nВаш возраст: " + age +
                "\nВаш рост: " + height +
                "\nВаш вес: " + weight);

            Console.WriteLine("Форматированный вывод: ");
            Console.WriteLine("Ваше имя: {0} \n Ваша фамилия: {1} \n Ваш возраст: {2} \n Ваш рост: {3} \n Ваш вес: {4}",
                name, surname, age, height, weight);

            Console.WriteLine("Форматированный вывод, используя $: ");
            Console.WriteLine($"Ваше имя: {name} \n Ваша фамилия: {surname} \n Ваш возраст: {age} \n Ваш рост: {height} \n Ваш вес: {weight}");

            Console.WriteLine("Перейти к следующей программе");
            Console.ReadKey();
            #endregion
            #region Рассчитать и вывести индекс массы
            Console.Write("Введите массу тела: ");
            double m = double.Parse(Console.ReadLine());

            Console.Write("Введите рост тела(в метрах): ");
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine($"ИМТ = {m / (h * h)}");

            Console.WriteLine("Перейти к следующей программе");
            Console.ReadKey();
            #endregion
            #region Расстояние между точками
            decimal dist = Convert.ToDecimal(getDistance(1.0, 1.0, 2.0, 2.0));

            Console.WriteLine($"Расстояние между точками: {dist.ToString("F2")} ");
            #endregion
            #region Обмен значений int
            // Задание без звездочки
            int a = 1;
            int b = 2;
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"a = {a} b = {b}");

            // Задание со звездочкой
            a = 1333;
            b = 2123;
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            Console.WriteLine($"a = {a} b = {b}");
            #endregion
        }

        static double getDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
