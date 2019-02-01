using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] arr = s.Split();
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                int c = int.Parse(arr[i]);
                if (Prime(c) == true)
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt);

            for (int i = 0; i < n; i++)
            {
                int c = int.Parse(arr[i]);
                int j;
                for (j = 2; j < c; j++)
                    if ((c % j == 0))
                    {
                        break;
                    }


                if (j == c)
                {
                    Console.Write(c + " ");
                }
            }
        }
    }
}
