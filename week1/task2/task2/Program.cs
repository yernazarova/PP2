using System;

namespace Task2
{

    class Student //создаем новый класс под названием Student
     {

        public string name; //создаем переменные
        public string id;
        public int year;


        public Student(string name, string id)
       //создаем конструктор, который будет принимать два значения 
            {
            this.name = name;
            this.id = id;
        }


        public string GetName()  //создаем функцию, которая будет возвращать имя  
            {
            return name;
        }

       
        public string GetId()  //создаем функцию, которая будет возвращать айди 
        {
            return id;
        }


        public int GetYear()
       //создаем функцию, которая будет увеличивать год обучения
             {
            return ++year;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {


            Student Info = new Student(Console.ReadLine(), Console.ReadLine());

            //считваем с кансоли данные  

            for (int i = 0; i < 4; i++)
                //создаем цикл, который будет повторяться 4 раза(4 года обучения)
                 {
               
                Console.WriteLine(Info.GetName()); //вызываем функцию, которая будет возварщать имя 


            Console.WriteLine(Info.GetId());
            //вызываем функцию, которая будет возвращать айди      

            Console.WriteLine(Info.GetYear());//вызываем функцию, которая будет возваращать увеличенный год обучения
        }
        }
    }
}