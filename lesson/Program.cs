using System;

namespace Lesson
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // Волков Матвей
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

            Pause();
            #endregion
            #region Рассчитать и вывести индекс массы
            // Просто введите ззначения, можно с плавающей точкой, можно без
            Console.Write("Введите массу тела: ");
            double m = double.Parse(Console.ReadLine());

            Console.Write("Введите рост тела(в метрах): ");
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine($"ИМТ = {m / (h * h)}");

            Pause();
            #endregion
            #region Расстояние между точками
            // Тут по сути просто метод. 
            double dist = getDistance(1.0, 1.0, 2.0, 2.0);

            Console.WriteLine("Расстояние между точками: {0:F2} ", dist);
            Pause();
            #endregion
            #region Обмен значений int
            // Задание без звездочки
            Console.Write("Введите значение a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b: ");
            int b = int.Parse(Console.ReadLine());
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"a = {a} b = {b}");
            Console.WriteLine("В данном примере использовались 3 переменные, что не очень.");

            // Задание со звездочкой
            Console.Write("Еще раз введите значение a: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b: ");
            b = int.Parse(Console.ReadLine());
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            Console.WriteLine($"a = {a} b = {b}");
            Console.WriteLine("Тут уже по другому, я использовал исключающее или и с легкостью поменял значения переменных местами тремя операциями");
            Console.WriteLine("PS: До этой штуки сложно догадаться, но я ее и раньше знал");

            Pause();
            #endregion
            #region Текст-центрист
            // Тут все просто. 1 свойство - параметр, 2 - x велечина
            // Также есть реализация с y, этот параметр пишется сразу после x
            Print("Матвей", Console.WindowWidth / 2);
            Print("Волков", Console.WindowWidth / 2);
            Print("Сургут", Console.WindowWidth / 2);
            Pause();
            #endregion
        }

        static double getDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static void Print(string msg, int x, int y)
        {
            for (int i = 0; i <= y; i++)
            {
                Console.Write("\n");
            }
            for (int i = 0; i <= x; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(msg);
        }

        static void Print(string msg, int x)
        {
            for (int i = 0; i <= x; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(msg);
        }

        static void Print(string msg, bool newLine = true)
        {

            if (newLine)
            {
                Console.WriteLine(msg);
            } else
            {
                Console.Write(msg);
            }
        }
        static void Pause()
        {
            Console.WriteLine("Pause. Press any button to continue...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
