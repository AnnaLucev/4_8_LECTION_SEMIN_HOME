Console.Clear();
Console.WriteLine("1 - Программа для задания двумерного массива размером m x n, заполненного случайными целыми числами (задача 46)");
Console.WriteLine("2 - Программа для задания двумерного массива размером m x n, каждый элемент которого находится по формуле Amn = m+n (задача 48)");
Console.WriteLine("3 - Программа для задания двумерного массива размером m x n, нахождения элементов, у которых оба индекса четные и замены их на их квадраты (задача 49");
Console.WriteLine("4 - Программа для задания двумерного массива размером m x n и нахождения суммы элементов, находящихся на главной диагонали (задача 51");
Console.WriteLine("5 - Программа, которая на вход принимает значение и двумерный массив, и возвращает значение этого элемента или же указание, что такого элемента нет (задача 50");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    TwoRandomArray();
    break;

    case 2:
    TwoArrayFormula();
    break;

    case 3:
    TwoArraySquar();
    break;

    case 4:
    SumDiagonalArray();
    break;

    case 5:
    SearchNumberArray();
    break;

    default:
    Console.WriteLine("Номер задачи введен некорректно");
    break;
}

int Prompt(string message)     // Метод запроса
{
    Console.WriteLine(message);
    int result = Convert.ToInt32(Console.ReadLine());
    return result;
}


// Задача 46.
// Задать двумерный массив размером m x n, заполненный случайными целыми числами

int [,] TwoRandomArray()
{
    Console.WriteLine("Введите количество строк двумерного массива: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов двумерного массива: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[m,n];
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(-10, 11);
            Console.Write(array[i, j] + " ");
        }
    }
    return array;
}

// Задача 48
// Задать двумерный массив размером m x n. Каждый элемент массива находится по формуле Amn = m+n. Выведите полученный массив на экран 

void TwoArrayFormula()
{
    Console.WriteLine("Введите количество строк двумерного массива: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов двумерного массива: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[m,n];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = i+j;
            Console.Write(array[i, j] + " ");
        }
    }
}

// Задача 49
// Задать двумерный массив размером m x n. Найдите элементы, у которых оба индекса четные, и замените эти элементы на их квадраты
// например, изначально массив такой              А стал такой
//   1 4 7 2                                      1 4 7 2                                    
//   5 9 2 3                                      5 9 2 3
//   8 4 2 4                                      8 4 4 4

void TwoArraySquar()
{
    Console.WriteLine("Исходный массив: ");
    int[,] array = TwoRandomArray();
    Console.WriteLine();
    Console.WriteLine();
    Console.Write("Преобразованный массив: ");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (i%2 == 0 &&  j%2 == 0)
               array[i,j] = array[i,j]*array[i,j];
            Console.Write(array[i, j] + " ");
        }
    }
}   
    
// Задача 51: 
// Задайте двумерный массив. Найдите сумму элементов, находящихся на главной диагонали (с индексами (0,0); (1;1) и т.д. Например, задан массив: 
// 1 4 7 2
// 5 9 2 3 
// // 8 4 2 4 
// // Сумма элементов главной диагонали: 1+9+2 = 12

void SumDiagonalArray()
{
    Console.WriteLine("Исходный массив: ");
    int[,] array = TwoRandomArray();
    Console.WriteLine();
    Console.WriteLine();
 
    int result = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (i == j)
                result = result + array[i,j];
        }
    }
    Console.Write($"Сумма элементов главной диагонали: {result}");
}

// Задача 50: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет. Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

void SearchNumberArray()
{
    Console.WriteLine("Введите число для поиска: ");   // задаем число для поиска
    int N = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Исходный массив: ");
    int[,] array = TwoRandomArray();
    Console.WriteLine();
    Console.WriteLine();

    bool a = false;                                 // задаем булевую переменную
    Console.WriteLine("");
    for (int i = 0; i < array.GetLength(0); i++)    // проверка и результат
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i,j] == N)
            {     
                a = true;
                Console.WriteLine($"В заданном массиве число {N} находится на позиции [{i},{j}]");
            }
        }
    }
    if (a == false)
        Console.Write($"В заданном массиве числа {N} нет");
}

// Console.WriteLine("Введите искомое число: ");
// int ViewerNumber = Convert.ToInt32(Console.ReadLine());

// int[,] array = new int[new Random().Next(10,15), new Random().Next(10,15)];

// void FillArray(int[,] array)
// {
//     for (int i = 0; i < array.GetLength(0); i++)
//     {  
//         Console.WriteLine();
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             array[i, j] = new Random().Next(0, 10);
//             Console.Write(array[i, j] + " ");
//         }
//     }   
// }

// void Viewer(int[,] array, int ViewerNumber)
// {
//     int count = 0;
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             if(array[i,j] == ViewerNumber)
//             {
//                 Console.WriteLine($"Искомый элемент находится на позиции: {i}, {j}");
//             }
//             else
//                 {
//                     count++;
//                 }
//         }
//     }
//     if (count == array.GetLength(0)*array.GetLength(1))
//         Console.WriteLine("Искомого значения нет!");
// }

// FillArray(array);
// Console.WriteLine();
// Viewer(array, ViewerNumber);