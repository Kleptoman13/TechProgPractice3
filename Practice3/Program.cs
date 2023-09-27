using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*952. Составить программу, которая проводит замену всех элементов:
            а) некоторой строки Двумерного массива заданным числом;
            б) некоторого столбца Двумерного массива заданным числом.*/

            Task952();

            /*959. В Двумерном массиве хранится информация о количестве учеников 
            в каждом классе каждого потока школы с первого по одиннадцатый
            (в первой строке — информация о первых классах, во второй — о вторых классах и т.д.). 
            В каждом потоке школы имеются четыре класса.
            Определить общее число учеников 5 - х классов.*/

            Task959();

            /*978. Дана вещественная квадратная матрица порядка 2n.Получить новую матрицу, 
            переставляя ее блоки размера n × n крест-накрест.*/

            Task978();

            /*1015. Определить, является ли заданная матрица ортонормированной, 
            то есть равно ли скалярное произведение каждой пары разных строк(столбцов) нулю.*/

            Task1015();

            Console.ReadKey();
        }

        static void Task952()
        {
            Console.WriteLine("Задание 952");

            const int n = 3;
            const int m = 3;
            int[,] arr = new int[n, m];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[j, i] = r.Next(1, 10);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[j, i] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Заменять столбец (введите 1) или строку (введите 2)?");

            int direction = 0;
            Boolean correct = false;

            while (correct == false)
            {
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out direction))
                {
                    if (direction < 1 || direction > 2)
                    {
                        Console.WriteLine("Неверно. Введите 1 или 2.");
                        correct = false;
                    } else if (direction == 1 || direction == 2)
                    {
                        correct = true;
                    }
                } else
                {
                    Console.WriteLine("Неверный формат");
                    correct = false;
                }
            }

            string str;
            int h;

            if (direction == 1)
            {
                str = "ый столбец";
                h = m; 
            } else
            {
                str = "ую строку";
                h = n;
            }

            Console.WriteLine("Введите котор" + str + " нужно заменить");

            correct = false;
            int index = 0;

            while (correct == false)
            {
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out index))
                {
                    if (index > 0 && index <= h)
                    {
                        correct = true;
                    } else
                    {
                        Console.WriteLine("Нет такого. Введите существующий");
                        correct = false;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат");
                    correct = false;
                }
            }

            Console.WriteLine("Введите число на который нужно заменить");

            int number = 0;

            correct = false; 

            while (correct == false)
            {
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out number))
                {
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Неверный формат");
                    correct = false;
                }
            }

            if (direction == 1)
            {
                for (int i = 0; i < m; i++)
                {
                    arr[index - 1, i] = number;
                }
            } else if (direction == 2) 
            {
                for (int i = 0; i < n; i++)
                {
                    arr[i, index - 1] = number;
                }
            }

            Console.WriteLine("Полученный массив");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[j, i] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void Task959()
        {
            Console.WriteLine("Задание 959");

            const int n = 11;
            const int m = 4;
            int[,] arr = new int[n, m];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = r.Next(15, 24);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            int countOfStudents = 0;
            int indexOfFiveClass = 4;

            for (int i = 0; i < m; i++)
            {
                countOfStudents += arr[indexOfFiveClass, i];
            }

            Console.WriteLine("Количество учеников в 5 классе: " + countOfStudents);
            Console.WriteLine();
        }

        static void Task978()
        {
            Console.WriteLine("Задание 978");

            const int n = 2 * 3;

            float[,] arr = new float[n, n];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = (float)(r.NextDouble() * 10 - 5);
                }
            }

            Console.WriteLine("Исходная матрица: ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            int size = n / 2;

            float[,] newArr = new float[n, n];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    newArr[i, j] = arr[i + size, j + size];
                    newArr[i, size + j] = arr[size + i, j];
                    newArr[i + size, j + size] = arr[i, j];
                    newArr[size + i, j] = arr[i, size + j];
                }
            }

            Console.WriteLine("Матрица с переставленными блоками: ");


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(newArr[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void Task1015()
        {
            Console.WriteLine("Задание 1015");

            const int n = 4;
            int[,] arr = new int[n, n];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = r.Next(0, 2);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            int result = 0;

            for (int i = n - 1; i > 0; i--)
            {
                for (int k = 0; k < n; k++)
                {
                    result += arr[i, k] * arr[i - 1, k];
                    result += arr[k, i] * arr[k, i - 1];
                }
            }


            if (result > 0)
            {
                Console.WriteLine("Матрица не является ортонормированной");
            }
            else if (result == 0)
            {
                Console.WriteLine("Матрица является ортонормированной");
            }


        }
    }
}
