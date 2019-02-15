using System;
using System.IO;

namespace Task3
{
    class MainClass
    {

        //создаем функцию, которая будет выводить пробелы
        static void PrintSpaces(int level)
        {
            //создаем цикл для вывода
            for (int i = 0; i < level; i++)
            {
                //выводим пробелы
                Console.Write("   ");
            }
        }

        //создаем функцию, которая будет выводить название файлов из заданного пути
        static void Direction(DirectoryInfo directory, int level)
        {
            //создаем Fileinfo, чтобы получить файлы 
            FileInfo[] files = directory.GetFiles();

            //создаем цикл для файлов
            foreach (FileInfo file in files)
            {
                //вызываем функцию для вывода пробелов с уровнем "level" 
                PrintSpaces(level);

                //выводим в кансоль название файла с заданном пути
                Console.WriteLine(file.Name);
            }

            //создаем DirectoryInfo, чтобы получить путь ко всем файлам 
            DirectoryInfo[] directories = directory.GetDirectories();

            //создаем цикл для путей
            foreach (DirectoryInfo d in directories)
            {
                //вызываем функцию для вывода пробелов с уровнем "level"
                PrintSpaces(level);

                //выводим в кансоль название папки с заданного пути
                Console.WriteLine(d.Name);

                //рекурсивно вызываем вторую функцию, увеличивая значение на 1
                Direction(d, level + 1);
            }
        }


        public static void Main(string[] args)
        {
            //создаем DirectoryInfo и задаем свой путь 
            DirectoryInfo path = new DirectoryInfo("/Users/meruyertyernazarova/desktop/pp2/week2");

            //вызываем фунцию для вывода файлов и передаем наше значение: путь и количество пробелов
            Direction(path, 0);
        }
    }
}