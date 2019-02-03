using System;

namespace d
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            string s; //обьявляем переменную


            s = Console.ReadLine(); //считываем

            int a = int.Parse(s); //переоразовываем стринг в инт

            int[,] arr = new int[a, a]; //создаем 2х мерный массив


            for (int i = 1; i <= a; i++) //создаем цикл роу
            {

                for (int j = 1; j <= a; j++) //создаем цикл для коламн
                {

                    if (i >= j) /*чтобы вывести треугольник из * порядочный номер массива должен быть больше или равен 
                        номеру строки */
                    {

                        Console.Write("[*]"); //выводим звездочки
                    }
                }

                Console.WriteLine(); //если условие не вполняется то выводим пробел
            }
        }
    }
}