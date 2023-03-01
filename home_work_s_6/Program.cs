Console.Clear();
Console.WriteLine("1 - Программа подсчета количества чисел >0 в заданной последовательности (задача 41)");
Console.WriteLine("2 - Программа, которая точку пересечения двух прямых, заданных пользователем (задача 43)");

int numberOfTask = Prompt("Введите номер задачи ");
switch (numberOfTask)
{
    case 1:
    CountMoreZero();
    break;

    case 2:
    PointIntersection();
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

// Задача 41
// Пользователь вводит с клавиатуры М чисел. Посчитайте, сколько чисел больше 0 ввел пользователь
// 0,7,8,-2,-2 ---- 2
// -1,-7,567,89,223 ----3
//

int[]  PrintArray()      // вывод массива чисел из N элементов
{
    int N = Prompt("Введите количество элементов в массиве ");
    int[] arr = new int[N];
    // Console.WriteLine("Введите элементы массива");
    // for (int i = 0; i < arr.Length; i++)        // решение, когда числа вводятся через enter   
    // {
    //     arr[i] = int.Parse(Console.ReadLine());
    // }
    Console.WriteLine("Введите элементы массива через пробел");
    int[] numbers = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray(); // решение, когда числа вводятся через пробел 
    for (int i = 0; i < N; i++)
        arr[i] = numbers[i];
    return arr;
}

void CountMoreZero()   //  итоговая функция решения задачи нахождения количества чисел >0 в заданной последовательности
{      
    int[] array = PrintArray();
    int result = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > 0) result++;
    }
    Console.Write($"Количество чисел > 0 в веденной последовательности  =  {result}");
}

// Задача 43
// Напишите программу, которая найдет точку пересечения двух прямых, заданных уравнениями y= k1*x+b1, y= k2*x+b2
// Значения b1, k1, b2, k2 задаются пользователем 
// b1=2, k1=5, b2=4, k2=9   -----  (-0,5; -0,5)
//

void PointIntersection()    //  итоговая функция решения задачи нахождения точки пересечения заданных прямых
{
    double k1 = Prompt("Введите коэффициент k1 линии 1 (y= k1*x+b1):  k1 =  ");
    double b1 = Prompt("Введите коэффициент b1 линии 1 (y= k1*x+b1):  b1 =  ");
    double k2 = Prompt("Введите коэффициент k2 линии 1 (y= k2*x+b2):  k2 =  ");
    double b2 = Prompt("Введите коэффициент b2 линии 1 (y= k2*x+b2):  b2 =  ");
    double x;
    double y;
    x = (b2-b1)/(k1-k2);
    y = k1*x+b1;
    Console.Write($"Координаты точки пересечения заданных прямых  -----    ({x};{y})");
}



