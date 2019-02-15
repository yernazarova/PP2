using System;
using System.IO;

namespace Ex1
{
    //создаем новый класс
    class FarManager
    {
        /*
         объявляем переменные:
         курсор - указывает на место, где находится на данный момент курсор
         сз - сайз, чтобы передвигать курсор с заданном направлении
         ок - показывать или скрывать скрытые файлы        
         */
        public int cursor;
        public int sz;
        bool ok;

        //создаем конструктор 
        public FarManager()
        {
            //курсор по умолчанию = 0(верхний элемент)
            cursor = 0;

            //ок по умолчание тру
            ok = true;
        }

        //создаем функцию для перемещения курсора вверх
        public void Up()
        {
            //уменьшаем курсор по индексу для перемещения вверх
            cursor--;

            //если индекс курсора меньше нуля, мы вышли за границу(дошли до первого элемента)
            if (cursor < 0)
                //поэтому присваиваем курсору индекс последнего элемента, чтобы перейти в нижний элемент
                cursor = sz - 1;
        }

        //создаем функцию для пермещении курсора вниз
        public void Down()
        {
            //увеличиваем курсор по индексу для пермещения вниз
            cursor++;

            //если индекс равен сайзу(после последнего элемента)
            if (cursor == sz)
                //присываиваем индекс первого элемента, чтобы перейти в верхний элемент
                cursor = 0;
        }

        //создаем функцию для присваивания и изменения цвета элементов
        /*
         передаем FileSystemInfo fs: папка, которую мы хотим вывести в кансоль
                  int index: тип элемента - папка, файл, скрытый файл
         */
        public void Color(FileSystemInfo fs, int index)
        {
            //если индекс равен курсору(папка на которой сейчас стоит курсор)
            if (index == cursor)
            {
                //тогда перекрасить фон в белый, шрифт в черный
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            //если это DirectoryInfo(папка) - перекрасить фон в черный, шрифт в желтый
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                //в обратном случае(если это файл) - фон в черный, шрифт в циан(сине-зеленый)
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

        //создаем функцию чтобы показать весь список файлов, папок по заданному пути
        public void Show(string path)
        {
            //создаем перменную DirectoryInfo и передаем туда путь 
            DirectoryInfo directory = new DirectoryInfo(path);

            //создаем массив, где хранятся файлы и папки
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();

            //количество элементов, находящихся в массиве
            sz = fileSystemInfos.Length;

            //создаем переменную, которая указывает на элемент который выводим на экран в данный момент
            int index = 0;

            //пробегаемся по всем файлам этого массива 
            foreach (FileSystemInfo fs in fileSystemInfos)
            {

                //если ок равен тру(не показываем скрытые файлы) и название нашей папки/файла начинается с точки
                if (ok && fs.Name.StartsWith("."))
                {
                    //уменьшаем количество выводимых в кансоль файлов и продолжаем(не выводим этот файл в кансоль)
                    sz--;
                    continue;
                }

                //если предыдущие условие не выполняются, вызываем функцию для окрашивания и передаем fs файла на которой мы стоим и индекс файла
                Color(fs, index);

                //выводим название файла в кансоль и его порядковый номер
                Console.WriteLine(index + 1 + "." + fs.Name);

                //увеличиваем индекс для перехода на следующий файл
                index++;
            }
        }

        //создаем функцию старт для начала работы и передаем туда путь
        public void Start(string path)
        {
            //создаем новую директорию и передаем туда наш путь
            DirectoryInfo directory = new DirectoryInfo(path);

            //создаем переменную, которая будет считывать с клавиатуры набранные команды
            FileSystemInfo fs = null;
            while (true)
            {
                //красим фон по умолчанию в черный при очистке
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                //вызываем функцию шоу и выводим все элементы на экран
                Show(path);

                //считываем с клавиатуры
                ConsoleKeyInfo consoleKey = Console.ReadKey();

                //если нажали на eskape
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    //курсору присваиваем 0
                    cursor = 0;

                    //указываем путь к предыдущей папке
                    directory = directory.Parent;
                    path = directory.FullName;
                }
                //при нажатии на ап
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    //вызываем функцию ап
                    Up();
                //при нажатии на даун
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    //вызываем функцию даун
                    Down();
                //при нажатиии на правую кнопку
                if (consoleKey.Key == ConsoleKey.RightArrow)
                    //присваиваем ок ложь, выводим на экран скрытые файлы
                    ok = false;
                //при нажатии на левую кнопку
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                    //присваиваем ок правду, не выводим на экран скрытые файлы
                    ok = true;
                //при нажатии на backspace
                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    int k = 0;
                    //пробегаемся по всем файлам в директории
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        //если это скрытый файл, продолжаем
                        if (ok && directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                            continue;
                        //если нет, 
                        if (cursor == k)
                        {
                            //если условие выполняется, запоминаем директорию
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        //если это не скрытая папка, увеличиваем к
                        k++;
                    }
                    //если это папка
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        Directory.Delete(fs.FullName, true);

                    }
                    else
                    {
                        cursor = 0;
                        File.Delete(fs.FullName);

                    }
                }




                //при нажатии на N
                if (consoleKey.Key == ConsoleKey.N)

                {
                    int k = 0;
                    //пробегаемся по всем файлам в директории
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        //если это скрытый файл, продолжаем
                        if (ok && directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                            continue;
                        //если нет, 
                        if (cursor == k)
                        {
                            //если условие выполняется, запоминаем директорию
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        //если это не скрытая папка, увеличиваем к
                        k++;
                    }
                    //считываем введенное новое название
                    Console.Clear();
                    string nname = Console.ReadLine();

                    if (fs.GetType() == typeof(DirectoryInfo))
                    {

                        //переименовываем старое название на новое
                        int n = fs.Name.Length;
                        string newpath = "";
                        for (int i = 0; i < fs.FullName.Length - n; i++)
                        {
                            newpath += fs.FullName[i];
                        }
                        newpath = newpath + nname;
                        Directory.Move(fs.FullName, newpath);

                    }
                    //в противном случае(если это файл)
                    else
                    {
                        int n = fs.Name.Length;
                        string newpath = "";
                        for (int i = 0; i < fs.FullName.Length - n; i++)
                        {
                            newpath += fs.FullName[i];
                        }
                        newpath = newpath + nname;
                        //переименовываем старое название на новое
                        File.Move(fs.FullName, newpath);

                    }

                }


                //при нажатии на enter
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    //создаем переменную, которая будет показывать индекс не скрытых файлов
                    int k = 0;
                    //пробегаемся по всем файлам в директории
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        //если это скрытый файл, продолжаем
                        if (ok && directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                            continue;
                        //если нет, 
                        if (cursor == k)
                        {
                            //если условие выполняется, запоминаем директорию
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        //если это не скрытая папка, увеличиваем к
                        k++;
                    }
                    //проверяем это директория или файл, если директория:
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        //присваиваем курсору 0
                        cursor = 0;
                        //присваиваем новую директорию(входим в папку)
                        directory = new DirectoryInfo(fs.FullName);
                        //изменяем путь на новый(путь к вошедшей папке)
                        path = fs.FullName;
                    }
                    //если это файл и заканчивается на txt(текстовый файл)
                    if (fs.Name.EndsWith(".txt"))
                    {
                        //очищаем экран, чтобы вывести содержимое
                        Console.Clear();
                        //создаем StreamReader для считывания с файла
                        StreamReader sr = new StreamReader(fs.FullName);
                        //пишем в кансоль считанные данные
                        Console.Write(sr.ReadToEnd());
                        //закрываем StreamReader
                        sr.Close();
                        //ждем последующих команд с клавиатуры
                        Console.ReadKey();
                    }
                }
            }
        }
    }

    class MainClass
    {
        static void Main(string[] args)
        {
            //создаем FarManager
            FarManager farManager = new FarManager();
            //Вызываем функцию старт и передаем путь 
            farManager.Start("/Users/meruyertyernazarova/desktop/fortask4");
        }
    }
}