/*
Задача 54: Задайте двумерный массив. 
Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

Console.Write("Введите номер задачи: ");
string? task = Console.ReadLine();
switch (task)
{
    case "54":
    Task54(task);
    break;
    default:
    break;
}

int size (string message)                                   // Определение параметров
{
    Console.Write(message);
    int s = Convert.ToInt32(Console.ReadLine());
    return (s);
}

int [,] FillIntArray2d (int lengthM, int lengthN)           // Заполнение случайными целыми числами двумерного массива
{
    int [,] array2d = new int [lengthM, lengthN];
    for (int i =0; i < lengthM; i++)
    {
        for (int j = 0; j < lengthN; j++)
        {
            array2d[i, j] = new Random().Next(0,10);
        }
    }
    return (array2d);
}

void PrintIntArray2d (int [,] array2d)                      // Вывод на экран двумерного массива
{
    for (int i =0; i < array2d.GetLength(0); i++)
    {
        for (int j = 0; j < array2d.GetLength(1); j++)
        {
           Console.Write($"[{array2d[i, j]}] ");
        }
        Console.WriteLine();
    }
}

void SortRowIntArray2d (int [,] array2d)                    // Сортировка строк двумерного массива по убыванию
{
int temp;
for (int i = 0; i < array2d.GetLength(0); i++)
    {
        for (int b = 0; b < array2d.GetLength(1); b++)
        {
            for (int j = 0; j < array2d.GetLength(1) - 1; j++)
            {
                if (array2d [i, j] < array2d [i, j + 1])
                {
                temp = array2d [i, j];
                array2d [i, j] = array2d [i, j + 1];
                array2d [i, j + 1] = temp;
                }
            }
        }
    }
}

void Task54 (string task)                                   // Решение задачи №54
{
    string message = "Введите количество строк массива m: ";
    int m = size (message);
    message = "Введите количество столбцов массива n: ";
    int n = size (message);
    int [,] array2d = FillIntArray2d(m, n);
    Console.WriteLine("Исходный массив:");
    PrintIntArray2d(array2d);
    SortRowIntArray2d(array2d);
    Console.WriteLine("Получен массив:");
    PrintIntArray2d(array2d);
}

