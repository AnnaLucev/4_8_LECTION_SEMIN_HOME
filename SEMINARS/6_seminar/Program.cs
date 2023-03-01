// Console.Clear();
Console.WriteLine("1 - Программа переворота одномерного массива (задача 39)");
Console.WriteLine("2 - Программа, которая принимает на вход три числа и проверяет, может ли существовать треугольник со сторонами такой длины (задача 40)");
Console.WriteLine("3 - Программа преобразования десятичного числа в двоичное (задача 42)");
Console.WriteLine("4 - Программа вывода N чисел Фибоначчи без рекурсии (задача 44)");
Console.WriteLine("5 - Программа создания копии заданного массива с помощью поэлементного копирования (задача 45)");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    FlippingArray();
    break;

    case 2:
    CheckSidesTriangle();
    break;

    case 3:
    ConversionToBinary();
    break;

    case 4:
    FibonacciNoRecurcia();
    break;

    case 5:
    CopyArray();
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

// Задача 39: Напишите программу, которая перевернёт одномерный массив (последний элемент будет на первом месте, а первый - на последнем и т.д.)
// [1 2 3 4 5] -> [5 4 3 2 1]
// [6 7 3 6] -> [6 3 7 6]
//
// int GetNumber()     // задаем функцию вывода вводимых данных в виде int
// {
//     Console.WriteLine("Input number of array length: ");
//     int number = Convert.ToInt32(Console.ReadLine());
//     return number;
// }

int[] GenerateArray(int length)    // функция определения случайного одномерного массива заданной длины
{     
    int[] array = new int[length];     
    for (int i = 0; i < length; i++)         
         array[i] = new Random().Next(-10, 11);     
    return array; 
}  

int[] ReverseArray(int[] array)    //  функция переворота заданного одномерного массива
{     
    for (int i = 0; i < array.Length / 2; i++)     
    {         
        int tmp = array[i];         
        array[i] = array[array.Length - 1 - i];         
        array[array.Length - 1 - i] = tmp;     
    }     
    return array; 
}  

int[] AnotherReverseArray(int[] array)  //  еще одна функция переворота заданного одномерного массива
{     
    int[] tmpArray = new int[array.Length];     
    for (int i = 0; i < array.Length; i++)         
        tmpArray[i] = array[array.Length - 1 - i];     
    return tmpArray; 
}  

void PrintArray(int[] array)     //  функция вывода заданного одномерного массива
{
    Console.WriteLine(String.Join(" ", array));}

void FlippingArray()           //  итоговая функция решения задачи переворота массива
{
    int length = Prompt("Введите длину одномерного массива ");
    int[] array = GenerateArray(length); 
    PrintArray(array); 
    PrintArray(AnotherReverseArray(array)); 
    PrintArray(ReverseArray(array));
}


// Задача 40: Напишите программу, которая принимает на вход три числа и проверяет, может ли существовать треугольник с сторонами такой длины.
// Теорема о неравенстве треугольника: каждая сторона треугольника меньше суммы двух других сторон.

void CheckSidesTriangle()    //  итоговая функция решения задачи проверки существования треугольника с заданными сторонами
{
    int a = Prompt("Введите длину A стороны треугольника:  A =  ");
    int b = Prompt("Введите длину B стороны треугольника:  B =  ");
    int c = Prompt("Введите длину C стороны треугольника:  C =  ");

    if (a < b + c && b < a + c && c < b + a  )
        Console.Write("Треугольник с указанными сторонами может быть построен");
    else 
        Console.Write("Треугольник с указанными сторонами не существует");
}

// Задача 42: Напишите программу, которая будет преобразовывать десятичное число в двоичное.
// 45 -> 101101
// 3  -> 11
// 2  -> 10
//

void Binary(int dec)    //  функция вывода результата расчета перевода десятичного числа в двоичное
{
    string bin = "";
    while (dec > 0)
    {
        bin = (dec % 2).ToString() + bin;
        dec /= 2;
    }
    Console.WriteLine("Двоичное число:  {0} ", bin);
}

int[]  TwoArray(int dec)   //  функция вывода результата расчета перевода десятичного числа в двоичное в виде массива
{
    int count = 0;
    int dec_ = dec;
    for (int i = 0; dec > 0; i++)
    {
        dec /=2;
        count ++;
    }

    int[] array = new int[count];

    for (int i = 0; dec_ > 0; i++)
    {
        array[count - 1 - i] = dec_ % 2;
        dec_ /= 2;
    }
    return array;
}

void ConversionToBinary()  //  итоговая функция решения задачи преобразования десятичного числа в двоичное
{
    int decimal_ = Prompt("Введите десятичное число ");
    Binary(decimal_);
    Console.WriteLine("Вывод двоичного числа в виде массива:  ");
    PrintArray(TwoArray(decimal_));
}


// Задача 44: Не используя рекурсию, выведите первые N чисел Фибоначчи. Первые два числа Фибоначчи: 0 и 1.
// Если N = 5 -> 0 1 1 2 3
// Если N = 3 -> 0 1 1
// Если N = 7 -> 0 1 1 2 3 5 8

void FibonacciNoRecurcia() //  итоговая функция решения задачи расчета чисел Фибоначчи без рекурсии
{
    int N = Prompt("Введите количество чисел Фибоначчи - ");
    Fibonacci(N);
}

void Fibonacci(int n)   //  функция расчета чисел Фибоначчи без рекурсии
{
    int a = 0; int b = 1; int c;  
    Console.Write(a + " " + b + " ");  
    for (int i = 2; i < n; i++) 
    {   
        c = a + b;     
        a = b;     
        b = c;      
        Console.Write(c + " "); 
    }  
    Console.WriteLine();
}
    
// Задача 45: Напишите программу, которая будет создавать копию заданного массива с помощью поэлементного 
// копирования.

int [] CopyArray_(int[] array)
{
    int[] arrayCopy = new int[array.Length];
    for (int i = 0; i < array.Length; i++) 
        arrayCopy[i] = array[i];
    return arrayCopy;
}

void CopyArray()
{
    int length = Prompt("Введите длину одномерного массива ");
    int[] array = GenerateArray(length); 
    Console.WriteLine("Первичный массив:");  
    PrintArray(array);
    Console.WriteLine("Скопированный массив:"); 
    PrintArray(CopyArray_(array));
    // Console.WriteLine(array == array);
    // Console.WriteLine(array == CopyArray_(array));
}


// int[] array = { 1, 2, 3, 4, 5 };  
// int[] copyArray = new int[array.Length];  

// for (int i = 0; i < array.Length; i++) 
//     copyArray[i] = array[i];   

// Console.WriteLine("Original array:"); 

// foreach (int num in array) 
//     Console.Write(num + " ");   

// Console.WriteLine("\nCopied array:"); 

// foreach (int num in copyArray) 
//     Console.Write(num + " ");   
// Console.WriteLine();


// int GetNumber()     // задаем функцию вывода вводимых данных в виде int
// {
//     Console.WriteLine("Input number: ");
//     int number = Convert.ToInt32(Console.ReadLine());
//     return number;
// }

// array = TwoArray(GetNumber());