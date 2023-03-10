Console.Clear();
Console.WriteLine("1 - Программа для вывода натуральных чисел в промежутке от N до 1 с помощью рекурсии (задача 64)");
Console.WriteLine("3 - Программа для вывода суммы всех натуральных между M и N через рекурсию (задача 66)");
Console.WriteLine("3 - Программа для вычисления функции Аккермана с помощью рекурсии (задача 68)");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    NumbersIntervalRec();
    break;

    case 2:
    SumNumbersRec();
    break;

    case 3:
    AkkermanRec();
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

// Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"

void NumbersIntervalRec()
{
    Console.WriteLine("Введите число больше 0: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(NumbersInterval(m));
}

int NumbersInterval(int m)
{
    if (m==1) return 1;
    Console.Write($"{m}, ");
    return NumbersInterval(m-1);
}


// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

void SumNumbersRec() 
{
    Console.WriteLine("Введите минимальное число: ");
    int m = Convert.ToInt32cd(Console.ReadLine());
    Console.WriteLine("Введите максимальное число: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(SumNumbers(m, n));
}

int SumNumbers(int m, int n)
{
    if (m==n) return n;
    return m + SumNumbers(m+1,n);
}

// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n. 
// m = 2, n = 3 -> A(m,n) = 29

void AkkermanRec()
{
    Console.WriteLine("Введите число  m: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите число  n: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(Akkerman(m, n));
}

int Akkerman(int m, int n)
{
    if (m == 0) return n+1;
    else if (m != 0 && n == 0) return Akkerman(m-1, 1);
    else if (m > 0 && n > 0) return Akkerman(m-1, Akkerman(m, n-1)); 
    return Akkerman(m, n); 
}