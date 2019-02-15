using System;
using System.IO;

namespace task2
{
    class MainClass
    {
        static bool IsPrime(int n) //вызываем функция булеан 
        {
            if (n == 1) 
                return false;
            for (int m = 2; m < n; m++) //считываем массив,1 не прайм, начинаем с2
            {
                if (n % m == 0) //если число делиться еще на число кроме себя 
                    return false;
            }
            return true; //если условия не выполнены то число прайм
        }




        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"/Users/meruyertyernazarova/desktop/pp2/week2/task2"); //получаем путь до папки
            StreamReader sr = new StreamReader("input.txt"); //путь с папки до файла инпут
            StreamWriter sw = new StreamWriter("output.txt");//путь с папки до оутпут, куда будем вставлять прайм намберс
            string s = sr.ReadLine(); //считываем строку файла инпут созданную как переменная 
            string[] b= s.Split(); //создаем новый массив,разделяем его по пробелам

            for (int i = 0; i < b.Length; i++) //создаем цикл,считываем нашу строку в массиве
            {
                int f = int.Parse(b[i]); //преобразовываем ее в инт
                if (IsPrime(f) == true) // если по условию оно прайм
                {
                    sw.Write(f + " "); //то записываем прайм числа в оутпут
                }


            }
            sr.Close(); //закрываем файлы
            sw.Close();
        }
    }
}
