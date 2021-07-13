using System;
using System.IO;

namespace Lesson1
{
    // Матвей Волков
    class ResizableIntClass
    {
        private int[] arr;
        public ResizableIntClass(int[] arr)
        {
            this.arr = arr;
        }
        public void Append(int value)
        {
            int[] retArr = new int[arr.Length + 1];
            Array.Copy(arr, 0, retArr, 0, arr.Length);
            retArr[arr.Length] = value;
            arr = retArr;
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
                    if(arr[i] % 3 == 0 ^ arr[i + 1] % 3 == 0)
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
            

        }
    }
}
