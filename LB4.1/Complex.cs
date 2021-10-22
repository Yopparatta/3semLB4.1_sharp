using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB4._1
{
    class Complex
    {
        private double real;
        private double imaginary;
        public Complex(double r, double i)
        {
            Logger.info("Создаем экземпляр класса");
            real = r;
            imaginary = i;
        }
        public Complex()
        {
            Logger.info("Создаем экземпляр класса");
            real = 0;
            imaginary = 0;
        }
        private double getArg()
        {
            Logger.info("Вычисляем фи");
            if (real > 0)
            {
                return Math.Atan(imaginary / real);
            }
            else if (real < 0)
            {
                if (imaginary >= 0)
                {
                    return Math.PI + Math.Atan(imaginary / real);
                }
                if (imaginary < 0)
                {
                    return -Math.PI + Math.Atan(imaginary / real);
                }
            }
            else
            {
                if (imaginary > 0)
                {
                    return Math.PI / 2;
                }
                if (imaginary < 0)
                {
                    return -Math.PI / 2;
                }
            }
            return 0;
        }

        private double getAbs()
        {
            Logger.info("Вычисляем модуль");
            return Math.Sqrt(real * real + imaginary * imaginary);
        }
        public void showNumber()
        {
            Logger.info("Выводим различные формы на экран");
            Console.WriteLine($"Тригонометрическая форма:\nZ = {getAbs():f3} * (cos{getArg():f3} + i*sin{getArg():f3})");
            Console.WriteLine("Показательная форма:\nZ = {0:f3}*e^(i*{1:f3})", getAbs(), getArg());
        }

        public void pow(uint n)
        {
            Logger.info("Возводим в степень");
            Console.WriteLine("Z^{0:f3} = {1:f3}*(cos{2:f3} + i*sin{2:f3})", n, Math.Pow(getAbs(), n), n * getArg());
        }
        public void root(uint n)
        {
            Logger.info("Вычисляем корень и находим корни уравнения");
            Complex number = new Complex();
            Console.WriteLine("Z^{0:f3} = {1:f3}*(cos({2:f3}+2*Pi*k*{0}) + i*sin({2:f3}+2*Pi*k*{0}))", 1.0 / n, Math.Pow(getAbs(), 1.0 / n), getArg() / n);
            for (int i = 0; i < n; i++)
            {
                number.real = Math.Pow(getAbs(), 1.0 / 2) * Math.Cos((getArg() + (2 * Math.PI * i)) / n);
                number.imaginary = Math.Pow(getAbs(), 1.0 / 2) * Math.Sin((getArg() + (2 * Math.PI * i)) / n);
                Console.WriteLine(i + "" + number);
            }
        }

        public static Complex operator +(Complex num1, Complex num2)
        {
            Complex number = new Complex();
            number.real = num1.real + num2.real;
            number.imaginary = num1.imaginary + num2.imaginary;
            return number;
        }
        public static Complex operator -(Complex num1, Complex num2)
        {
            Complex number = new Complex();
            number.real = num1.real - num2.real;
            number.imaginary = num1.imaginary - num2.imaginary;
            return number;
        }
        public static Complex operator *(Complex num1, Complex num2)
        {
            Complex number = new Complex();
            number.real = (num1.real * num2.real) - (num1.imaginary * num2.imaginary);
            number.imaginary = (num1.imaginary * num2.real + num1.real * num2.imaginary);
            return number;
        }
        public static Complex operator /(Complex num1, Complex num2)
        {
            Complex number = new Complex();
            number.real = ((num1.real * num2.real) + (num1.imaginary * num2.imaginary)) / (num2.imaginary * num2.imaginary + num2.real * num2.real);
            number.imaginary = (num1.imaginary * num2.real - num1.real * num2.imaginary) / (num2.imaginary * num2.imaginary + num2.real * num2.real);
            return number;
        }
        public override bool Equals(Object num1)
        {
            Complex num = num1 as Complex;

            if (num == null)
            {
                return false;
            }

            return (this.real == num.real) && (this.imaginary == num.imaginary);
        }
        public override string ToString()
        {
            return "Z = " + String.Format("{0:f3}", real) + " + i * " + String.Format("{0:f3}", imaginary);
        }


    }
}
