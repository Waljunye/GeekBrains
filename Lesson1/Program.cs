using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public delegate double ToDoFunction(double x, double h);
public delegate double Fun(double a, double x);

class Program
{
    // Матвей Волков
    public static void SaveFunc(string fileName, double a, double b, double h, double param, ToDoFunction Function)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        double x = a;
        while (x <= b)
        {
            bw.Write(Function(x, param));
            x += h;
        }
        bw.Close();
        fs.Close();
    }
    public static List<double> Load(string fileName, out double min)
    {
        List<double> retList = new List<double>();

        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);
        min = double.MaxValue;
        double d;
        for (int i = 0; i < fs.Length / sizeof(double); i++)
        {
            // Считываем значение и переходим к следующему
            d = bw.ReadDouble();
            retList.Add(d);
            if (d < min) min = d;
        }
        bw.Close();
        fs.Close();
        Console.WriteLine(min);
        return retList;
    }

    public static void Table(Fun F, double a, double x, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }
    public static double SqrAndMult(double a, double x)
    {
        return a * x * x;
    }
    public static double SinAndMulti(double a, double x)
    {
        return a * Math.Sin(x);
    }

    public static double PlusNumber(double x, double param)
    {
        return x + param;
    }
    public static double MultiplyNumber(double x, double param)
    {
        return x * param;
    }
    public static double Exponent(double x, double param)
    {
        for (int i = 0; i < param; i++)
        {
            x *= x;
        }
        return x;
    }
    public static double DivideParam( double x, double param)
    {
        return param / x;
    }
    
    static void Main()
    {
        #region Таблицы 
        // Создаем новый делегат и передаем ссылку на него в метод Table
        Console.WriteLine("Таблица функции SqrAndMult:");
        // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
        // a*x^2
        Table(new Fun(SqrAndMult), -2, -2, 2);
        Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
        // a*sin(x)
        Console.WriteLine("Таблица функции SinAndMulti:");
        // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
        Fun MyFunc = SinAndMulti;
        Table(MyFunc, -2, -2, 2);
        #endregion
        #region Функции

        Console.Write("Укажите какую функцию хотите использовать: \n\n1-PlusNUmber(Значение возрастает на указанный параметр(прямая))\n\n2-MultiplyNumber(Значение умножается на указанный параметр(прямая))\n\n3-Exponent(Значение возводиться в указанную степень(Парабола или Кубическая парабола. Тут я не разобрался))\n\n4-DivideParam(Указанный параметр постоянно делиться на указанное число(Гиперболa))\n\ndefault = PlusNumber\n");
        int funcArg = int.Parse(Console.ReadLine());
        ToDoFunction toDoFunction;
        switch (funcArg)
        {
            case 1:
                {
                    toDoFunction = PlusNumber;
                    break;
                }
            case 2:
                {
                    toDoFunction = MultiplyNumber;
                    break;
                }
            case 3:
                {
                    toDoFunction = Exponent;
                    break;
                }
            case 4:
                {
                    toDoFunction = DivideParam;
                    break;
                }
            default:
                {
                    toDoFunction = PlusNumber;
                    break;
                }
        }
        // Сохранение значений функции 
        Console.Write("Укажите параметр функции: ");
        double param = int.Parse(Console.ReadLine());
        Console.Write("Укажите на каком отрезке хотите искать минимум данной функции (Через пробел 1 и 2 значение):");
        string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        SaveFunc("data.bin", double.Parse(values[0]), double.Parse(values[1]), 0.5, param, toDoFunction);
        double min = 0;

        // Загрузка минимального значения функции
        Console.Write("\n\nМинимальное значение функции = ");
        List<double> valueList = Load("data.bin", out min);

        // Вывод значений функции из полученного списка 
        Console.WriteLine("\nЗначения функиции: ");
        foreach (double value in valueList)
        {
            Console.WriteLine(value);
        }
        Console.ReadKey();
        #endregion
        #region Студенты
        int numOfBachelors = 0;
        int numOfMasters = 0;
        // Создадим необобщенный список
        ArrayList list = new ArrayList();
        ArrayList eghteenToTwenty = new ArrayList();
        // Запомним время в начале обработки данных
        DateTime dt = DateTime.Now;
        StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "students.csv");
        int bakalavr = 0;
        int magistr = 0;
        int fifthCourse = 0;
        int sixthCourse = 0;
        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                // Console.WriteLine("{0}", s[0], s[1], s[2], s[3], s[4]);
                list.Add($"{s[1]};{ s[0]};{s[2]};{s[3]};{s[4]};{s[5]};{s[6]};{s[7]};{s[8]}");// Добавляем склееные имя и фамилию
                if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                if (int.Parse(s[6]) == 5)
                {
                    fifthCourse++;
                }
                else if (int.Parse(s[6]) == 5)
                {
                    sixthCourse++;
                }
                if (int.Parse(s[5]) <= 18 && int.Parse(s[5]) >= 20)
                {
                    eghteenToTwenty.Add(s[0] + " " + s[1]);
                }
            }
            catch
            {
            }
        }
        sr.Close();
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                string[] s01 = list[j].ToString().Split(";");
                string[] s02 = list[j + 1].ToString().Split(";");
                int n01 = 0;
                int n02 = 0;
                int.TryParse(s01[5], out n01);
                int.TryParse(s02[5], out n02);
                if (n01 >= n02)
                {
                    string help = (string)list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = help;
                    if (n01 == n02)
                    {
                        if (int.Parse(s01[6]) >= int.Parse(s02[6]))
                        {
                            help = (string)list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = help;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            list[i] = String.Join(" ", list[i].ToString().Split(";"));
        }
        Console.WriteLine("Всего студентов:{0}", list.Count);
        Console.WriteLine("Магистров:{0}", magistr);
        Console.WriteLine("Бакалавров:{0}", bakalavr);
        foreach (var v in list) Console.WriteLine(v);
        // Вычислим время обработки данных
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();

        #endregion 
    }
}
