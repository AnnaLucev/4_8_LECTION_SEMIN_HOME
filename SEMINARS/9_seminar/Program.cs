Console.Clear();
Console.WriteLine("1 - Программа для вывода всех чисел от M до N через рекурсию (задача 65)");
Console.WriteLine("2 - Программа для приема на вход число и возврата суммы его цифр через рекурсию (задача 67)");
Console.WriteLine("3 - Программа для возведения числа А в целую степень B с помощью рекурсии (задача 69)");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    NumbersIntervalRec();
    break;

    case 2:
    SumFigureNumberRec_();
    break;

    case 3:
    ExponentRec();
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

// Задача 65
// Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежуте от M до N.
// М = 1; N = 5 ------- 1,2,3,4,5
// М = 4; N = 8 ------- 4,5,6,7,8

void NumbersIntervalRec()
{
    Console.WriteLine("Введите минимальное число: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите максимальное число: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(NumbersInterval(m, n));
}

int NumbersInterval(int m, int n)
{
    if (n==m) return n;
    Console.Write($"{m}, ");
    return NumbersInterval(m+1,n);
}
// System.Console.WriteLine(ReturnNumber(PutNumber("Введите m : "),PutNumber("Введите n : ")));
// int PutNumber(string message)
// {
//    System.Console.WriteLine(message);
//    int number = Convert.ToInt32(Console.ReadLine());
//    return number;
// }
// string ReturnNumber(int m, int n)
// {
//   if (m == n) return n + "";
//   else
//     return m + " " + ReturnNumber(m + 1, n);
// }

// Задача 67: Напишите программу, которая будет принимать на вход число и возвращать сумму его цифр.
// 453 -> 12
// 45 -> 9

void SumFigureNumberRec_()
{
    Console.WriteLine("Введите число: ");
    int m = Convert.ToInt32(Console.ReadLine()); 
    Console.WriteLine(SumFigureNumberRec(m));
}

int SumFigureNumberRec(int m)
{
    if (m/10==0) return m;
    return m%10 + SumFigureNumberRec(m/10);
}

// Задача 69: Напишите программу, которая на вход принимает два числа A и B, и возводит число А в целую степень B с помощью рекурсии.
// A = 3; B = 5 -> 243 (3⁵)
// A = 2; B = 3 -> 8

void ExponentRec()
{
    Console.WriteLine("Введите число: ");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите степень: ");
    int b = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(Exponent(a, b));
}

int Exponent(int  a, int b)
{
    if (b ==1) return a;
    else if (b ==0) return 1;
    return a * Exponent(a, b-1);
}

// int Rec (int a, int b)
// {
//     if (a > b) return 0;
//     return Rec (a, b - 1);
// }

