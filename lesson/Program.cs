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
            Int16 m = Int16.Parse(Console.ReadLine());

            Console.Write("Введите рост тела(в метрах): ");
            Int16 h = Int16.Parse(Console.ReadLine());

            Console.WriteLine($"ИМТ = {m/(h * h)}");
            #endregion
        }
    }
}
