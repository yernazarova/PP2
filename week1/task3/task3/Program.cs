using System;

namespace b
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            string n; //объявляем переменную   
            n = Console.ReadLine(); //считываем строку
            int b = int.Parse(n);//переобразовываем  массив в integer

            string[] arr = Console.ReadLine().Split(); // создаем массив, считываем и разделяем его по пробелу


            for (int i = 0; i < b; i++) //создаем цикл для массива с длинною б
            {

                Console.Write(arr[i] + " " + arr[i] + " ");//выводим два раза повторяющийся элемент, который разделен между собой пробелом
            }
        }
    }
}