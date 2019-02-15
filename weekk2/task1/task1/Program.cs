using System;
using System.IO;

namespace Task1
{
    class MainClass
    {
        //создаем функцию, которая возвращает true, false после выполнения условия 
        public static bool P(string s)
        {
            //объявляем переменные: начало слово и конец
            int i = 0;
            int j = s.Length - 1;

            //условие: пока i меньше j(пока отсчет дойдет до середины)
            while (i < j)
            {
                //если значение i-того и j-того элемента не равны, возвращать false
                if (s[i] != s[j])
                    return false;
                //увеличиваем значение i и уменьшаем j, чтобы проверить полностью слово
                i++;
                j--;
            }

            //если указанное выше условие не выполняется, возвращаем true
            return true;
        }

        public static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo("/Users/meruyertyernazarova/desktop");
            StreamReader sr = new StreamReader("a.txt");
            String t = sr.ReadLine(); //создаем переменную для строки

            Console.WriteLine(t); //считываем

            bool a = P( t); 

            //если условие выполнено, выводим "YES"
            if (a == true)
            {
                Console.WriteLine("Yes");
            }
            //в противном случае выводим "NO"
            else
            {
                Console.WriteLine("NO");

            }
        }
    }
}