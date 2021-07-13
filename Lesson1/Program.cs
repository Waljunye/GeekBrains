using System;
using System.IO;

namespace Lesson1
{
    // Матвей Волков
    struct Account
    {
        private string login;
        private string password;
        private int guess;

        public Account(string path, int countOfGuess)
        {
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + path);
            login = sr.ReadLine();
            password = sr.ReadLine();
            guess = countOfGuess;
        }
        
        public bool Login(string messOnLogin, string messOnPassword)
        {
            string inputLogin = "";
            string inputPassword = "";
            for(int i = 1; i <= guess; i++)
            {
                Console.Write(messOnLogin);
                inputLogin =  Console.ReadLine();
                Console.Write(messOnPassword);
                inputPassword = Console.ReadLine();
                if(inputLogin == login && inputPassword == password)
                {
                    return true;
                } else if(i != guess)
                {
                    Console.WriteLine($"Введен неверный логин или пароль, повторите попытку! (Осталось попыток: {guess - i})");
                }

            }
            return false;


        }


    }
    class ResizableIntClass
    {
        private int[] arr;
        public int Sum;
        public ResizableIntClass(int[] arr)
        {
            this.arr = arr;
        }
        public ResizableIntClass()
        {
            arr = new int[0];
        }
        public ResizableIntClass(string path)
        {
            arr = StaticMassClass.GetFileArray(path);
        }
        public ResizableIntClass(int len, int step)
        {
            Random ran = new Random();
            arr = new int[len];
            for (int i = 0; i < len; i += step)
            {
                arr[i] = ran.Next(-100, 100);
            }
            Sum = GetSum();
        }
        private int GetSum()
        {
            int retVal = 0;
            foreach (int val in arr)
            {
                retVal += val;
            }
            return retVal;
        }
        public ResizableIntClass Inverse()
        {
            ResizableIntClass retArr = new ResizableIntClass();
            foreach (int val in arr)
            {
                retArr.Append(-1 * val);
            }
            return retArr;
        }
        public ResizableIntClass Multi(int coeff)
        {
            ResizableIntClass retArr = new ResizableIntClass();
            foreach (int val in arr)
            {
                retArr.Append(coeff * val);
            }
            return retArr;
        }
        public int MaxCount()
        {
            int max = 0;
            int count = 1;
            foreach (int val in arr)
            {
                if(max < val)
                {
                    max = val;
                    count = 1;
                }else if (max == val)
                {
                    count++;
                }
            }
            return count;
        }
        public void Join(string sep)
        {
            foreach(int val in arr)
            {
                Console.Write(val + sep);
            }
            Console.WriteLine();
        }
        public void Join()
        {
            foreach (int val in arr)
            {
                Console.WriteLine(val);
            }
        }
        public void Append(int value)
        {
            int[] retArr = new int[arr.Length + 1];
            Array.Copy(arr, 0, retArr, 0, arr.Length);
            retArr[arr.Length] = value;
            arr = retArr;
            Sum = GetSum();
        }
        public int[] toIntArray()
        {
            return arr;
        }
        public int this[int index]
        {
            get 
            { 
                return arr[index];
            }
            set
            {
                arr[index] = value;
                Sum = GetSum();
            }
        }
    }
    class StaticMassClass
    {
        public static int CountIsDivideOnThree(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0 ^ arr[i + 1] % 3 == 0)
                {
                    count++;
                }
            }
            return count;
        }
        public static int[] GetFileArray(string path)
        {
            
            string file = AppDomain.CurrentDomain.BaseDirectory + path;
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + path))
            {
                int value = 0;
                StreamReader sr = new StreamReader(file);
                ResizableIntClass res = new ResizableIntClass(new int[0]);
                while (!sr.EndOfStream)
                {
                    if (int.TryParse(sr.ReadLine(), out value))
                    {
                        res.Append(value);
                    }
                    else
                    {
                        Console.WriteLine("Не удалось пропарсить строку");
                    }
                    
                }
                return res.toIntArray();
            }
            else
            {
                throw new FileNotFoundException($"Файл {path} не найден!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region Пары чисел(Задание 1)
            {
                int[] arr = new int[20];
                Random random = new Random();
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next(-10_000, 10_000);
                }
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] % 3 == 0 ^ arr[i + 1] % 3 == 0)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Количество пар чисел, которые делятся на 3 равно: {count}");
                Console.ReadKey();
                Console.WriteLine();

            }
            #endregion
            #region  Пары Чисел через класс (Задание 2)
            {
                string path = "ArrayList.txt";
                int[] arr = StaticMassClass.GetFileArray("ArrayList.txt");
                Console.WriteLine($"Количество пар чисел, которые делятся на 3 равно: {StaticMassClass.CountIsDivideOnThree(arr)}, числа считаны из файла {path}");
                Console.ReadKey();
                Console.WriteLine();
            }
            #endregion
            #region Задание 3
            {
                ResizableIntClass arr = new ResizableIntClass("ArrayList.txt");
                Console.WriteLine($"Количество максимальных элементов: {arr.MaxCount()}");
                Console.WriteLine("Метод Multi \nВведите коофицент: ");
                int coof = int.Parse(Console.ReadLine());
                Console.WriteLine("Исходный Массив: ");
                arr.Join("\t");
                Console.WriteLine("Результат: ");
                arr.Multi(coof).Join("\t");
                Console.WriteLine("Массив с методом Inverse: ");
                arr.Inverse().Join("\t");
            }

            #endregion
            #region Auth
            Account acc = new Account("Account.txt", 3);
            Console.WriteLine(acc.Login("Введите логин: \n", "Введите пароль: \n"));
            #endregion
        }
    }
}
