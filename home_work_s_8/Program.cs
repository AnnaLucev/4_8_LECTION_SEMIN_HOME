﻿Console.Clear();
Console.WriteLine("1 - Программа для упорядочивания по убыванию элементов двумерного массива (задача 54)");
Console.WriteLine("2 - Программа для нахождения строки с наименьшей суммой элементов в заданном прямоугольном двумерном массиве (задача 56)");
Console.WriteLine("3 - Программа для нахождения произведения двух матриц (задача 58)");
Console.WriteLine("4 - Программа для вывода с индексами трехмерного массива из неповторяющихся двухзначных чисел (задача 60)");
Console.WriteLine("5 - Программа для спирального заполнения массива 4 на 4 (задача 62)");
Console.WriteLine("6 - Программа для вывода на экран раснобедренного треугольника Паскаля N строк (задача 61)");


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

    case 4:
    ThreeArray();
    break;

    case 5:
    //FourRandomArray(4);
    ReadArray(SpiralArray(4,4));
    break;

    case 6:
    TrianglePascale(9);
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

// Задача 60: Сформируйте трехмерный массив из неповторяющихся двухзначных чисел. Напишите программу, которая будет построчно выводить
// массив, добавляя индексы каждого элемента.
// Например, массив размером 2 х 2 х 2:
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

void ThreeArray()
{
    int[,,] threeArray = ThreeRandomArray();
    ReadThreeArrayIndex(threeArray);
    Console.WriteLine();
}

int [,,] ThreeRandomArray()
{
    Console.WriteLine("Введите размерность трехмерного массива: ");
    Console.Write("m =   ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write("n =   ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.Write("k =   ");
    int l = Convert.ToInt32(Console.ReadLine()); 
    
    int[,,] array = new int[m,n,l];
    int N = m*n*l;

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < l; k++)
            {
                array[i, j, k] = GenerateUniqueNumber();
            }
        }
    } return array;
}

int GenerateUniqueNumber()
{
    HashSet<int> numbers = new HashSet<int>();
    // int [] numbers = new int [N*2];
    Random r = new Random();
    while (true)
    {
        var n = r.Next(10, 100);
        if (!numbers.Contains(n))
        {
            numbers.Add(n);
            return n;
        }
    }
}
       
void ReadThreeArrayIndex(int[,,] array)            // функция вывода трехмерного массива с индексами
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write(array[i, j, k] + $"({i},{j},{k})  ");
            }
        System.Console.WriteLine();
        }
    }
}


// Задача 62: Напишите программу, которая заполнит спирально массив 4 на 4
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int [] FillOneArray(int a, int b) // функция задания одномерного массива
{
    int[] array = new int[a*b];
    int e = 0;

    for (int i = 0; i < a*b; i++)
    {
        e += 1;
        array[i] = e;
        //Console.Write(array[i] + " ");
    } return array;
}

int[,] SpiralArray(int a, int b)      // спиральная матрица слева направо
{
    int[] arr = FillOneArray(a,b);
    int[,] spiralArray = new int[a, b];
    int top = 0, bottom = a - 1;
    int left = 0, right = b - 1;
    int index = 0;

    while ((bottom >= 0) && (right >= 0))
    //while (1)
    {
        if (left > right)  break;
        for (int i = left; i <= right; i++)    // печатаем верхнюю строку
        {
            spiralArray[top, i] = arr[index++];
        }
        top++;

        if (top > bottom) break;
        for (int i = top; i <= bottom; i++)     // печатаем правый столбец
        {       
            spiralArray[i, right] = arr[index++];
        }
        right--;

        if (left > right) break;
        for (int i = right; i >= left; i--)    // печатаем нижнюю строку
        {
            spiralArray[bottom, i] = arr[index++];
        }
        bottom--;

        if (top > bottom) break;
        for (int i = bottom; i >= top; i--)     // печатаем левый столбец
        {
            spiralArray[i, left] = arr[index++];
        }
        left++;
    } return spiralArray;
}

// int [,] SpiralArray(int m,int n)     // функция формирования спирального массива 
// {
//     int[,] spiralArray = new int[n, m];
 
//     int row = 0;
//     int col = 0;
//     int dx = 1;
//     int dy = 0;
//     int dirChanges = 0;
//     int visits = m;

//     for (int i = 0; i < spiralArray.Length; i++) 
//     {
//         spiralArray[row, col] = i + 1;
//         if (--visits == 0) 
//         {
//             visits = m * (dirChanges %2) + n * ((dirChanges + 1) %2) - (dirChanges/2 - 1) - 2;
//             int temp = dx;
//             dx = -dy;
//             dy = temp;
//             dirChanges++;
//         }
//         col += dx;
//         row += dy;
//     } return spiralArray;
// }

// int[,] SpiralArray(int a, int b)      // спиральная матрица слева направо
// {
//     int[,] spiralArray = FillArray(a,b);
//     Console.WriteLine("\n");
//     int maxX = spiralArray.GetLength(0);
//     int maxY = spiralArray.GetLengt(1)-1;
//     int dirX = 1;
//     int dirY = 1;

//     int x = -1;
//     int y = 0;
//     int val = 1;
//     while ((maxX >= 0) && (maxY >= 0))
//     {
//         for (int xval = 1; xval <= maxX; xval++)         // задаем первый столбец 01-02--
//         {
//             spiralArray[x + dirX * xval, y] = val;
//             val++;
//         }
//         x = x + dirX * maxX;
//         dirX = -dirX;
//         maxX--;

//         for (int yval = 1; yval <= maxY; yval++)
//         {
//             spiralArray[x, y + dirY*yval] = val;
//             val++;
//         }

//         y = y + dirY * maxY;
//         dirY = -dirY;
//         maxY--;

//     } return spiralArray;
// }
// int [,] FillArray(int a, int b) // функция задания двумерного массива
// {
//     int[,] array = new int[a, b];
//     int e = 0;

//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         Console.WriteLine();
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             e += 1;
//             array[i, j] = e;
//             Console.Write(array[i, j] + " ");
//         }
//     } return array;
// }


// Задача 61: Вывести первые N строк треугольника Паскаля. 
// Сделать вывод в виде равнобедренного треугольника.

void TrianglePascale(int row)
{
    int [,] triangle = FillTriangle(row);
    PrintTriangle (triangle, row);
    Console.ReadLine();
    EmptyRows(row);
    Magic(triangle, row);
    Console.ReadLine();
}

int [,] FillTriangle(int row)
{
    int [,] triangle = new int [row, row];
    for (int i = 0; i < row; i++)
    {
        triangle [i,0] = 1;
        triangle [i,i] = 1;
    }
    for (int i = 2; i < row; i++)
    {
        for (int j = 1; j < i+1; j++)
        {
            triangle [i,j] = triangle [i-1, j-1] + triangle [i-1, j];
        }
    } return triangle;
}

void PrintTriangle (int [,] triangle, int row)
{
    const int cellWidth = 3;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < row; j++) 
        {
            if (triangle[i,j] !=0)
                Console.Write($"{triangle[i,j], cellWidth}"); 
        }
        Console.WriteLine();
    }
}

void Magic (int [,] triangle, int row)
{
    const int cellWidth = 2;
    int col = cellWidth * row;
    for (int i = 0; i <= row; i++)
    {
        for (int j = 0; j <= i; j++) 
        {
            Console.SetCursorPosition(col, i+1);
            if (triangle[i,j] !=0) Console.Write($"{triangle[i,j], cellWidth}");
            col += cellWidth *2;
        }
        col = cellWidth * row - cellWidth *(i+1);
        Console.WriteLine();
    }
}

void EmptyRows(int row)
{
    int a = 0;
    while (a < row+2) 
    {
        Console.WriteLine();
        a++;
    }
}





// int [,,] ThreeRandomArray()     // функция формирования трехмерного двузначного массива заданных параметров
// {
//     Console.WriteLine("Введите размерность трехмерного массива: ");
//     Console.Write("m =   ");
//     int m = Convert.ToInt32(Console.ReadLine());
//     Console.Write("n =   ");
//     int n = Convert.ToInt32(Console.ReadLine());
//     Console.Write("k =   ");
//     int l = Convert.ToInt32(Console.ReadLine()); 
    
//     int[,,] array = new int[m,n,l];
    
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         Console.WriteLine();
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             Console.WriteLine();
//             for (int k = 0; k < array.GetLength(2); k++)
//             {
//                 array[i, j, k] = new Random().Next(10, 100);
//                 Console.Write(array[i, j, k] + " ");
//             }
//         }
//     } return array;
// }
// int [,] FourRandomArray(int a, int b)     // функция формирования четырехмерного массива заданных параметров
// {
//     int[,] array = new int[a,b];
//     int e = 0;
    
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         Console.WriteLine();
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             e += 1;
//             array[i, j] = e;
//             Console.Write(array[i, j] + " ");
//         }
//     } return array;
// }


// for (int i = 0; i < array.GetLength(0); i++)
// {
//     Console.WriteLine();
//     for (int j = 0; j < array.GetLength(1); j++)
//     {
//         e += 1;
//         array[i, j] = e;
//         Console.Write(array[i, j] + " ");
//     }