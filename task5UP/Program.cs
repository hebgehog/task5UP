using System;

namespace task5UP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            int N=0;
            Console.WriteLine("Введите порядок матрицы:");
            while (!exit) {
                N = wwww();
                if (N <= 0) { Console.WriteLine("Невозможно составить матрицу"); }
                else { exit = true; }
            }
            Console.WriteLine();
            int[,] arr = null;
            try{arr = new int[N, N];}
            catch (OutOfMemoryException){
                Console.WriteLine("Невозможно составить матрицу");
                Console.WriteLine("Нажмите Enter для выхода");
                Console.ReadKey();
                Environment.Exit(0);
            }
            int i, j; 
            int max = 0; 
            int b = N; 
            Random rnd = new Random();
            for (i = 0; i < N; i++){
                for (j = 0; j < N; j++)
                {
                    arr[i, j] = rnd.Next(1, 100);
                }
            }
            int temp;
            Console.WriteLine("Вывод матрицы: ");
            for (i = 0; i < N; i++){
                for (j = 0; j < N; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            for (i = 0; i < arr.GetLength(1) / 2; i++)
                for (j = 0; j < arr.GetLength(0); j++){
                    temp = arr[j, i];
                    arr[j, i] = arr[j, arr.GetLength(1) - i - 1];
                    arr[j, arr.GetLength(1) - i - 1] = temp;
                }
            int count = 0;
            int count1 = 0;
            int a1 = (N/2)+(N%2);
            b=1;
            for (i = 0; i < N; i++){
                if ((b != a1) && (count == 0))
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
                    if ((N % 2 == 0) && (count1 != 2))
                    {
                        for (j = 0; j < b; j++)
                        {
                            if (max < arr[i, j])
                            {
                                max = arr[i, j];
                            }
                        }
                        count1++;
                        count++;
                        if (count1 == 2) { b--; }
                    }
                    else
                    {
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
            }
            Console.WriteLine("максимум: " + max);
            Console.ReadKey();
        }
        static int wwww()
        {
            while (true)
            {
                int number;
                if (int.TryParse(Console.ReadLine(), out number))
                    return number;
                else
                    Console.WriteLine("Ошибка, введите еще раз");
            }
        }
    }
}
