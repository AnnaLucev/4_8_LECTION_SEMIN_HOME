Console.Clear();
Console.WriteLine("1 - Программа для вывода суммы всех натуральных между M и N через рекурсию (задача 66)");
Console.WriteLine("2 - Программа для вычисления функции Аккермана с помощью рекурсии (задача 68)");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    SumNumbersRec();
    break;

    case 2:
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

// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

void SumNumbersRec() 
{
    Console.WriteLine("Введите минимальное число: ");
    int m = Convert.ToInt32(Console.ReadLine());
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