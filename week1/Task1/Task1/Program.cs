using System;

public class Program
{

    public static void Main(string[] args)
    {
        string b;
        b = Console.ReadLine();
        int n = int.Parse(b);

        string[] arr = Console.ReadLine().Split();

        int sum = 0;
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
