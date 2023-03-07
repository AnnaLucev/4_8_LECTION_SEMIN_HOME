Console.Clear();
Console.WriteLine("1 - Программа для упорядочивания по убыванию элементов двумерного массива (задача 54)");
Console.WriteLine("2 - Программа для нахождения строки с наименьшей суммой элементов в заданном прямоугольном двумерном массиве (задача 56)");
Console.WriteLine("3 - Программа для нахождения произведения двух матриц (задача 58)");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    DecreasElementsRow();
    break;

    case 2:
    RowMinSumElemArray();
    break;

    case 3:
    ProductMatrices();
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

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:              В итоге получается вот такой массив:
// 1 4 7 2                              7 4 2 1
// 5 9 2 3                              9 5 3 2
// 8 4 2 4                              8 4 4 2

void DecreasElementsRow()          // итоговая функция задачи 54
{
    int[,] array = TwoRandomArray();
    System.Console.WriteLine();
    System.Console.WriteLine("Измененный массив");

    ReadArray(DecreasElements(array));

}

int [,] DecreasElements(int[,] array)       // функция упорядочивания по убыванию строк массива
{
    int[,] arrChange = new int[array.GetLength(0),array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int minPosition = j;
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i,k] > array[i,minPosition])
                    minPosition = k;
            } 
            int temp = array[i,j];  // временный элемент
            arrChange[i,j] = array[i,minPosition];
            array[i,minPosition] = temp;     
        }
    } return  arrChange; 
}

int [,] TwoRandomArray()     // функция формирования массива заданных параметров
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
            array[i, j] = new Random().Next(-5, 20);
            Console.Write(array[i, j] + " ");
        }
    }
    return array;
}

void ReadArray(int[,] array)            // функция вывода двумерного массива
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        System.Console.WriteLine();
    }
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void RowMinSumElemArray()         // итоговая функция задачи 56
{
    int[,] array = TwoRandomArray();
    System.Console.WriteLine("\n");
    RowMinSumElem(array);
    System.Console.WriteLine("\n");
}

void RowMinSumElem(int[,] array)     // функция, которая находит номер строки с наименьшей суммой элементов
{
    int sum = 0, minPositionRow = 0;
    int minim = 20*array.GetLength(1);
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        sum = 0;
        minPositionRow = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i,j];
        }
        Console.WriteLine($"Сумма элементов строки {i+1} =  {sum}.");
        if (sum < minim) 
        {
            minim = sum;
            minPositionRow = i;
        }
    } 
    Console.WriteLine($"Номер строки массива c наименьшей суммой элементов -  {minPositionRow+1} (индекс строки: {minPositionRow}).");
}

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:                Результирующая матрица будет:
// 2 4 | 3 4                                18 20
// 3 2 | 3 3                                15 18

void ProductMatrices()       // итоговая функция задачи 58
{
    System.Console.WriteLine("Матрица А");
    int[,] arrayOne = TwoRandomArray();
    System.Console.WriteLine("\n");
    System.Console.WriteLine("Матрица В");
    int[,] arraySec = TwoRandomArray();
    System.Console.WriteLine("\n");
    System.Console.WriteLine("Матрица произведения А*В");
    ReadArray(ProductMatrice(arrayOne, arraySec));
}

int [,] ProductMatrice(int[,] arrayOne, int[,] arraySec)
{
    int [,] arrProduct = new int[arrayOne.GetLength(0), arraySec.GetLength(1)];
    if (arrayOne.GetLength(1) != arraySec.GetLength(0))
        Console.WriteLine("Произведение матриц найти невозможно, так как количество столбцов матрицы А не равно количеству строк матрицы В.");
    else
    {
        for (int i = 0; i < arrayOne.GetLength(0); i++)
        {
            for (int j = 0; j < arraySec.GetLength(1); j++)
            {  
                for (int k = 0; k < arraySec.GetLength(0); k++)
                {
                    arrProduct[i,j] += arrayOne[i,k] * arraySec[k,j];
                }
            }
        }
    } return arrProduct;
}