Console.Clear();
Console.WriteLine("1 - Программа для задания двумерного массива размером m x n, заполненного случайными вещественными числами (задача 47)");
Console.WriteLine("2 - Программа, которая на вход принимает значение и двумерный массив, и возвращает значение этого элемента или же указание, что такого элемента нет (задача 50");
Console.WriteLine("3 - Программа для задания двумерного массива размером m x n, нахождения среднего арифметического элементов каждого столбца (задача 52");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    TwoRandomDoublArray();
    break;

    case 2:
    SearchNumberArray();
    break;

    case 3:
    ArithmeticMeanColumnsArray();
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

// Задача 47.
// Задать двумерный массив размером m x n, заполненный случайными вещественными числами

double [,] TwoRandomDoublArray()
{
    Console.WriteLine("Введите количество строк двумерного массива: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов двумерного массива: ");
    int n = Convert.ToInt32(Console.ReadLine());
    double[,] array = new double[m,n];
    Random Rand = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = Math.Round((Rand.NextDouble() * 100),1);
            Console.Write(array[i, j] + " ");
        }
    }
    return array;
}

// Задача 50: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет. Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

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

// Задача 52
// Задать двумерный массив из целых чисел размером m x n. Найдите среднее арифметическое элементов в каждом столбце. Например, задан массив -
// 1 4 7 2
// 5 9 2 3 
// 8 4 2 4 
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3


void ArithmeticMeanColumnsArray()
{
    Console.WriteLine("Исходный массив: ");
    int[,] array = TwoRandomArray();
    Console.WriteLine();
     
    double meanColumns = 0;
    double sum = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            sum = sum + array[i,j];
        }
        meanColumns = Math.Round((sum / array.GetLength(0)),1);
        Console.WriteLine($"Среднее арифметическое элементов столбца [{j}]: {meanColumns}");
    }
}
