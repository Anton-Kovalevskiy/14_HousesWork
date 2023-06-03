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

Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Задача 58: Задайте две матрицы. 
Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.Write("Введите номер задачи: ");
string? task = Console.ReadLine();
switch (task)
{
    case "54":
    Task54 (task);
    break;
    case "56":
    Task56 (task);
    break;
    case "58":
    Task58 (task);
    break;
    case "62":
    Task62 (task);
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
            if (array2d[i, j] < 10) Console.Write($"[0{array2d[i, j]}] ");
            else Console.Write($"[{array2d[i, j]}] ");
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

int MinSumRowArray2d (int [,] array2d)                      // Поиск минимальной суммы строки в массиве
{
    int sumRow;
    int minSumRow = 0;
    int numberRow = 1;
    for (int i = 0; i < array2d.GetLength(0); i++)
    {
        sumRow = 0;
        for (int j = 0; j < array2d.GetLength(1); j++)
        {
            sumRow += array2d[i, j];
        }
        if (i == 0) minSumRow = sumRow;
        if (sumRow < minSumRow)
        {
            minSumRow = sumRow;
            numberRow = i + 1;
        }
    }
    return (numberRow);
}

int [,] MultiplicationArrays (int [,] array2d1, int [,] array2d2) // Произведение двух матриц
{
    int [,] multArr = new int [array2d1.GetLength(0), array2d2.GetLength(1)];
    if (array2d1.GetLength(1) != array2d2.GetLength(0)) Console.WriteLine("Произведение данных матриц не имеет смысла!");
    else
    {
        for (int i = 0; i < array2d1.GetLength(0); i++)
        {
            for (int k = 0; k < array2d2.GetLength(1); k++)
            {
                for (int j = 0; j < array2d1.GetLength(1); j++)
                {
                        multArr [i, k] += array2d1[i, j] * array2d2[j, k];
                }
            }
        }
        Console.WriteLine("Произведение матриц:");
        PrintIntArray2d(multArr);
    }
    return (multArr);
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

void Task56 (string task)                                   // Решение задачи №56
{
    string message = "Введите количество строк массива m: ";
    int m = size (message);
    message = "Введите количество столбцов массива n: ";
    int n = size (message);
    int [,] array2d = FillIntArray2d(m, n);
    Console.WriteLine("Исходный массив:");
    PrintIntArray2d(array2d);
    int numRow = MinSumRowArray2d(array2d);
    Console.Write($"Минимальная сумма элемнтов в {numRow} строке");
}

void Task58 (string task)                                   // Решение задачи №58
{
    string message = "Задайте размер m первой матрицы: ";
    int m = size (message);
    message = "Задайте размер n первой матрицы: ";
    int n = size (message);
    int [,] array2d1 = FillIntArray2d(m, n);
    message = "Задайте размер m второй матрицы: ";
    m = size (message);
    message = "Задайте размер n первой матрицы: ";
    n = size (message);
    int [,] array2d2 = FillIntArray2d(m, n);
    Console.WriteLine("Получена первая матрица:");
    PrintIntArray2d (array2d1);
    Console.WriteLine("Получена вторая матрица:");
    PrintIntArray2d (array2d2);
    int [,] mult = MultiplicationArrays(array2d1, array2d2);
}

void Task62 (string task)                                   // Решение задачи №62
{
    int m = 4; int n1 = 0;
    int n = 4; int m1 = 0;
    int [,] array2d = new int [m, n];
    int i = 1;
    int j = 0;
    int number = 1;
    while (number <= m * n)
    {
        while (j < array2d.GetLength(1) - n1)
        {
            j++;
            array2d [i - 1, j - 1] = number;
            number++;
        }
        n1++;
        while (i < array2d.GetLength(0) - m1)
        {
            i++;
            array2d [i - 1, j - 1] = number;
            number++;
        }
        m1++;
        while (j > 0 + n1)
        {
            j--;
            array2d [i - 1, j - 1] = number;
            number++;
        }
        while (i > 1 + m1)
        {
            i--;
            array2d [i - 1, j - 1] = number;
            number++;
        }
    }

PrintIntArray2d (array2d);
    
}