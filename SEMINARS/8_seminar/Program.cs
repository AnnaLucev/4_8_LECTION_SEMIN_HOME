Console.Clear();
Console.WriteLine("1 - Программа для замены местами первой и последней строк двумерного массива (задача 53)");
Console.WriteLine("2 - Программа для транспонирования массива (перемена строк столбцами) (задача 55)");
Console.WriteLine("3 - Программа для составления частотного словаря элементов двумерного массива (задача 57)");
Console.WriteLine("4 - Программа, удаляющая строку и столбец, на пересечении которых расположен наименьший элемент массива (задача 59)");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    ChangeRowsArray();
    break;

    case 2:
    ChangeRowsColumnsArray();
    break;

    case 3:
    FrequencyDictionary();
    break;

    case 4:
    RemoveMinElemArray();
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


// Задача 53: Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.

void ChangeRowsArray()
{
    int[,] array = TwoRandomArray();
    System.Console.WriteLine();
    System.Console.WriteLine("Измененный массив");
    ReadArray(ChangedRowsArray(array));
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
            array[i, j] = new Random().Next(-10, 11);
            Console.Write(array[i, j] + " ");
        }
    }
    return array;
}

int[,] ChangedRowsArray(int[,] array)  // функция замены строк массива
{
    int m = array.GetLength(0);
    for (int j = 0; j < array.GetLength(1); j++)
    {
        int tmp = array[0,j];
        array[0, j] = array[m - 1, j];
        array[m - 1, j] = tmp;
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

// Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. В случае, если это невозможно, 
// программа должна вывести сообщение для пользователя.

void ChangeRowsColumnsArray()
{
    int[,] array = TwoRandomArray();
    System.Console.WriteLine();
    System.Console.WriteLine();
    // if (array.GetLength(0) != array.GetLength(1))
    //     Console.WriteLine("Замена строк на столбцы невозможна в связи с неравенством количества элементов. Задайте квадратный массив");
    // else
        Console.WriteLine("Измененный массив");
        ReadArray(ChangeRowsColumns(array));
        System.Console.WriteLine();
}

int [,] ChangeRowsColumns(int[,] array)
{
    int[,] arrayChange = new int[array.GetLength(1),array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            arrayChange[j, i] = array[i, j];
        }    
    }
    return arrayChange;
}

// Задача 57: Составить частотный словарь элементов двумерного массива. 
// Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.

void FrequencyDictionary()
{
    int[,] array = TwoRandomArray();
    System.Console.WriteLine("\n");
    int [] convertedArray = ConvertArray(array);   
    // if (array.GetLength(0) != array.GetLength(1))
    //     Console.WriteLine("Замена строк на столбцы невозможна в связи с неравенством количества элементов. Задайте квадратный массив");
    // else
    Array.Sort(convertedArray);
    Console.WriteLine(String.Join(" ", convertedArray));
    FrequencyDict(convertedArray);
}

int [] ConvertArray (int [,] array)
{
    int m = array.GetLength(0);
    int n = array.GetLength(1);
    int arrayIndex = 0;
    int[] newArray = new int [m*n];
    foreach (int item in array)
    {
        newArray[arrayIndex] = item;
        arrayIndex ++;
    }
    return newArray;
}

void FrequencyDict(int[] array)
{
    int element = array[0];
    int result = 1;
    for (int i = 1; i <= array.Length+1; i++)
    {
        if (element == array[i])
            result ++;
        else
        {
            Console.WriteLine($"Элемент: {element} содержится в массиве {result} раз");
            element = array[i];
            result = 1;
        }
    }
    Console.WriteLine($"Элемент: {element} содержится в массиве {result} раз");
}

// Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, 
// на пересечении которых расположен наименьший элемент массива.

void RemoveMinElemArray()
{
    int [,] arr = TwoRandomArray();
    Console.WriteLine("\n");
    int [] indexMinValue =  FindMinEl(arr);
    Console.WriteLine("Измененный массив");
    DeleteRowColumn(arr, indexMinValue);
    Console.WriteLine("\n");
}

int[] FindMinEl(int[,] arr)
{
    int minValue = arr[0,0];
    int[] indexMinValue = new int [2];
   for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if(minValue > arr[i,j])
            {
                minValue = arr[i,j];
                indexMinValue[0] = i;
                indexMinValue[1] = j;
            }
        }
    }
    Console.WriteLine($"Минимальный элемент массива: {minValue}");
    return indexMinValue;
}
void DeleteRowColumn(int[,] arr, int[] index)
{
    int [,] newArr = new int[arr.GetLength(0) - 1, arr.GetLength(1) - 1];
    int a = 0, b = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        if (index[0] == i) continue;
        for (int j = 0; j < arr.GetLength(1); j++)
        { 
            if (index[1] == j) continue;

            newArr[a,b] = arr[i,j];
            b++;
        }
        a ++;
        b = 0;
    } 
    ReadArray(newArr);    
}
