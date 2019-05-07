using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5UP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядок матрицы:");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[,] arr = new int[N, N];
            int i, j; 
            int max = 0; 
            int b = N; 

            Random rnd = new Random();
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    arr[i, j] = rnd.Next(1, 100);
                }
            }
            int temp;
            Console.WriteLine("Вывод матрицы: ");
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            for (i = 0; i < arr.GetLength(1) / 2; i++)
                for (j = 0; j < arr.GetLength(0); j++)
                {
                    temp = arr[j, i];
                    arr[j, i] = arr[j, arr.GetLength(1) - i - 1];
                    arr[j, arr.GetLength(1) - i - 1] = temp;
                }

            int count = 0;
            int a1 = (N/2)+(N%2);
            b=1;
            for (i = 0; i < N; i++)
            {
                if ((b != a1)&&(count==0))
                {
                    for (j = 0; j < b; j++)
                    {
                        if (max < arr[i, j])
                        {
                            max = arr[i, j];
                        }
                    }
                    b = b + 1;
                }
                else {
                    count++;
                    for (j = 0; j < b; j++)
                    {
                        if (max < arr[i, j])
                        {
                            max = arr[i, j];
                        }
                    }
                    b = b - 1;
                }
            }
            Console.WriteLine("максимум: " + max);
            Console.ReadKey();
        }
    }
}
