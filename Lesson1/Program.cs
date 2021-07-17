using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson1
{
    static class Message
    {
        private static char[] sep = new char[] { ' ', ',', '!', '?', '.' };
        public static void InputLenghtWords(string message, int leng)
        {
            
            string[] splitedWords = message.Split(Message.sep, StringSplitOptions.RemoveEmptyEntries);
            foreach(string word in splitedWords)
            {
                if (word.Length == leng)
                {
                    Console.Write(word + " ");
                }
            }
            Console.Write("\n");
        }
        public static string DeleteWordWithEndChar(string message, char ch)
        {
            StringBuilder sb = new StringBuilder(message);
            string[] splitedWords = message.Split(Message.sep, StringSplitOptions.RemoveEmptyEntries);
            foreach(string word in splitedWords)
            {
                if (word[word.Length - 1] == ch)
                {
                    sb.Replace(word, "");
                }
            }
            return sb.ToString();
        }
        public static string FindMaxLenghtWord(string message)
        {
            string[] splitedWords = message.Split(Message.sep, StringSplitOptions.RemoveEmptyEntries);
            int max = 0;
            string maxWord = "";
            foreach(string word in splitedWords)
            {
                if(word.Length >= max)
                {
                    maxWord = word;
                    max = word.Length;
                } 
            }
            return maxWord;
        }
        public static string ReturnMaxLenghtWords(string message)
        {
            StringBuilder sb = new StringBuilder();
            string[] splitedWords = message.Split(Message.sep, StringSplitOptions.RemoveEmptyEntries);
            int max = 0;
            string maxWord = "";
            foreach (string word in splitedWords)
            {
                if (word.Length >= max)
                {
                    maxWord = word;
                    max = word.Length;
                }
            }
            foreach (string word in splitedWords)
            {
                if (word.Length == max)
                {
                    sb.Append(word + " ");
                }
            }
            return sb.ToString();
        }
        private static string Inverse(string message)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < message.Length; i++)
            {
                sb.Append(message[message.Length - i - 1]);
            }
            return sb.ToString();
        }

        public static bool IsInversed(string s1, string s2)
        {
            if (s1 == Inverse(s2))
            {
                return true;
            }
            return false;
        }
    }
    // Волков Матвей
    class Program
    {
        /// <summary>
        /// Проверка логина. Корректным логином будет строка от 2 до 10 символов, 
        /// содержащая только буквы латинского алфавита или цифры,
        /// при этом цифра не может быть первой.
        /// </summary>
        /// <param name="log">LOGIN/Логин</param>
        /// <returns>bool(Прошел ли логин проверку, ДА(true)/НЕТ(false))</returns>
        public static bool LoginRegex(string log)
        {
            Regex regex = new Regex(@"(^[a-zA-Z]{1,1})([a-zA-Z0-9]{1,8}$)");
            Console.WriteLine(log.Length);
            return regex.IsMatch(log);
        }
        static void Main(string[] args)
        {
            
            #region Проверка логина
            LoginRegex("dfasd1");
            #endregion
            #region Статический класс Message
            // Я вставил рыбу, потому что не придумал ничего лучше
            string mess = "Lorem ipsum dolor sit amet, consectetur adipiscingf elit, sed do eiusmod tempor incididuntf ut labore et dolore magna aliqua";
            Console.WriteLine($"Исходное сообщение: {mess}");


            Console.WriteLine("\nВывести только те слова сообщения, которые содержат не более n букв:");
            Console.Write("Введите желаемое количество букв в слове: ");
            int len = int.Parse(Console.ReadLine());

            Message.InputLenghtWords(mess, len);



            Console.WriteLine("\nУдалить из сообщения все слова, которые заканчиваются на заданный символ");
            Console.Write("Введите символ: ");
            char ch = char.Parse(Console.ReadLine());

            Console.WriteLine(Message.DeleteWordWithEndChar(mess, ch));



            Console.WriteLine("\nНайти самое длинное слово сообщения: ");
            Console.WriteLine(Message.FindMaxLenghtWord(mess));



            Console.WriteLine("\nСформировать строку с помощью StringBuilder из самых длинных слов сообщения");
            Console.WriteLine(Message.ReturnMaxLenghtWords(mess));
            #endregion
            #region Является ли перестановкой
            Console.WriteLine("\nЯвляется ли перестановкой");

            Console.Write("Введите первую строку: ");
            string msg01 = Console.ReadLine();

            Console.Write("Введите вторую строку: ");
            string msg02 = Console.ReadLine();

            Console.WriteLine(Message.IsInversed(msg01, msg02));
            #endregion
            #region ЕГЭ
            int count = int.Parse(Console.ReadLine());
            double[] rating = new double[count];
            string[] names = new string[count];
            double min01 = 6;
            string minName01 = "";
            double min02 = 6;
            string minName02 = "";
            double min03 = 6;
            string minName03 = "";
            if (count < 3)
            {
                throw new Exception("Слишком мало учеников(от 10 до 100)");

            }
            else if (count > 100)
            {
                throw new Exception("Слишком много учеников(от 10 до 100)");
            }
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                if (input.Length > 5)
                {
                    throw new Exception("Слишком много параметров!");
                }
                if (input[0].Length > 20)
                {
                    throw new Exception("Фамилия не может быть больше 20 символов!");
                }
                if (input[1].Length > 15)
                {
                    throw new Exception("Имя не может быть больше 15 символов!");
                }
                if ((byte.Parse(input[2]) > 5 && byte.Parse(input[2]) < 1) || (byte.Parse(input[3]) > 5 && byte.Parse(input[3]) < 1) || (byte.Parse(input[3]) > 5 && byte.Parse(input[3]) < 1))
                {
                    throw new Exception("Оценки введены некорректно!");
                }
                rating[i] = (double.Parse(input[2]) + double.Parse(input[3]) + double.Parse(input[4])) / 3.0;
                names[i] = input[0] + " " + input[1];
                if (rating[i] < min01)
                {
                    min02 = min01;
                    minName02 = minName01;
                    min01 = rating[i];
                    minName01 = names[i];
                }
                if (min01 < rating[i] && rating[i] < min02)
                {
                    min03 = min02;
                    minName03 = minName02;
                    min02 = rating[i];
                    minName02 = names[i];

                }
                if (min02 < rating[i] && rating[i] < min03)
                {
                    min03 = rating[i];
                    minName03 = names[i];
                }
            }

            Console.WriteLine("Самые низкие оценки: ");
            Console.WriteLine($"{minName01} {min01} \n{minName02} {min02} \n{minName03} {min03}");
            #endregion
        }
    }
}
