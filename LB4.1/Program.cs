using System;

namespace LB4._1
{ 
    class Program
    {
        static int splitLine(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ') return i;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Complex number1=new Complex();
            Complex number2 = new Complex();
            Console.WriteLine("Введите вещественную и мнимую части первого комплексного чилса через пробел");
            string str;
            str = Console.ReadLine();
            if (str != "") {
                try
                {
                    number1 = new Complex(Convert.ToDouble(str.Substring(0, splitLine(str))), Convert.ToDouble(str.Substring(splitLine(str)+1)));
                }
                catch (FormatException e) { 
                    number1 = new Complex();
                    Console.WriteLine("Неверные данные. Создано число 0");
                }
            }
            Console.WriteLine("Введите вещественную и мнимую части второго комплексного чилса через пробел");
            str = Console.ReadLine();
            if (str != "")
            {
                try
                {
                    number2 = new Complex(Convert.ToDouble(str.Substring(0, splitLine(str))), Convert.ToDouble(str.Substring(splitLine(str) + 1)));
                }
                catch(FormatException e)
                {
                    number2 = new Complex();
                    Console.WriteLine("Неверные данные. Создано число 0");
                }
            }
            Console.WriteLine("Сложение {0:f3}", number1 +number2);
            Console.WriteLine("Вычитание {0:f3}", number1 - number2);
            Console.WriteLine("Умножение {0:f3}", number1 * number2);
            Console.WriteLine("Деление {0:f3}", number1 / number2);
            number1.showNumber();
            uint power;
            Console.WriteLine("Введите степень числа");
            power = Convert.ToUInt32(Console.ReadLine());
            number1.pow(power);
            Console.WriteLine("Введите степень корня");
            power = Convert.ToUInt32(Console.ReadLine());
            number1.root(power);
            Console.WriteLine(number1.Equals(number2));
            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}
