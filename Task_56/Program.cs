Console.WriteLine("Программа, которая находит строку с наименьшей суммой элементов прямоугольного двумерного массива.");

Console.Write("Введите число строк таблицы: ");
int m = int.Parse(Console.ReadLine()!);
Console.Write("Введите число столбцов таблицы: ");
int n = int.Parse(Console.ReadLine()!);

if (m == n) Console.WriteLine("Массив должен быть прямоугольным!");
else
{
    int[,] array = GetArray(m, n);
    Console.WriteLine("Полученный массив:");
    PrintArray(array);
    Console.WriteLine();

    int[] arrayOfSum = ArrayOfSum(array, m);
    PrintSumOfEachString(arrayOfSum);
    Console.WriteLine();

    int minStr = GetMinSum(arrayOfSum);
    Console.WriteLine("Строка с наименьшой суммой элементов: " + minStr);
}



int[,] GetArray(int m, int n)
{
    int[,] array = new int[m, n];
    Random random = new Random((int)DateTime.Now.Ticks);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(0, 21);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,4}", array[i, j]));
        }
        Console.WriteLine();
    }
}

int[] ArrayOfSum(int[,] array, int m)
{
    int[] arrayOfSum = new int[m];
    for (int i = 0; i < arrayOfSum.Length; i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            arrayOfSum[i] += array[i, j];
        }
    }
    return arrayOfSum;
}

void PrintSumOfEachString(int[] arrayOfSum)
{
    for (int i = 0; i < arrayOfSum.Length; i++)
    {
        Console.WriteLine($"Сумма {i + 1} строки = {arrayOfSum[i]}");
    }
}

int GetMinSum(int[] arrayOfSum)
{
    int min = arrayOfSum[0];
    int minIndex = 0;
    for (int i = 0; i < arrayOfSum.Length; i++)
    {
        if (arrayOfSum[i] < min)
        {
            min = arrayOfSum[i];
            minIndex = i;
        }
    }
    return minIndex + 1;
}