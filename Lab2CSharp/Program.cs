//Task 1

using System;

class Program
{
    static void Main()
    {
        // Запит користувача на введення розмірності масиву
        Console.Write("Введіть розмірність масиву: ");
        int size = int.Parse(Console.ReadLine());

        // Одновимірний масив згідно умови задачі
        int[] array1D = new int[size];
        Console.WriteLine("Введіть елементи одновимірного масиву:");

        // Заповнення одновимірного масиву користувачем
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Елемент {i + 1}: ");
            array1D[i] = int.Parse(Console.ReadLine());
        }

        // Запит користувача на введення порогового значення
        Console.Write("Введіть число для порівняння: ");
        int threshold = int.Parse(Console.ReadLine());

        // Збільшення елементів одновимірного масиву, якщо вони менше порогу, удвічі
        for (int i = 0; i < size; i++)
        {
            if (array1D[i] < threshold)
            {
                array1D[i] *= 2;
            }
        }

        // Виведення результату для одновимірного масиву
        Console.WriteLine("Результат для одновимірного масиву:");
        PrintArray(array1D);

        // Двовимірний масив
        Console.WriteLine("Введіть елементи двовимірного масиву:");
        int[,] array2D = new int[size, size];

        // Заповнення двовимірного масиву користувачем
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Елемент [{i + 1},{j + 1}]: ");
                array2D[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Збільшення елементів двовимірного масиву, якщо вони менше порогу, удвічі
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (array2D[i, j] < threshold)
                {
                    array2D[i, j] *= 2;
                }
            }
        }

        // Виведення результату для двовимірного масиву
        Console.WriteLine("Результат для двовимірного масиву:");
        PrintArray(array2D);
    }

    // Функція для виведення одновимірного масиву
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    // Функція для виведення двовимірного масиву
    static void PrintArray(int[,] array)
    {
        int size = array.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}

//Task 2

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть розмірність масиву: ");
        int n = int.Parse(Console.ReadLine());

        double[] array = new double[n];

        // Зчитування послідовності з клавіатури
        Console.WriteLine("Введіть послідовність чисел:");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Елемент {i + 1}: ");
            array[i] = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        // Знаходження максимального елемента
        int maxIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }

        // Поміняти місцями максимальний елемент і перший
        double temp = array[0];
        array[0] = array[maxIndex];
        array[maxIndex] = temp;

        Console.WriteLine("Масив після заміни:");
        PrintArray(array);

        Console.ReadLine(); // Для того, щоб консольне вікно не закривалося відразу
    }

    static void PrintArray(double[] arr)
    {
        foreach (double num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}

//Task 3

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть розмірність квадратного масиву: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        Console.WriteLine("Введіть елементи масиву:");

        // Заповнення масиву
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Елемент [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Обчислення середнього арифметичного
        int sum = 0;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i + j > n - 1) // Перевірка, чи елемент знаходиться під побічною діагоналлю
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
        }

        double average = (double)sum / count;

        Console.WriteLine($"Середнє арифметичне елементів під побічною діагоналлю: {average}");
    }
}

//Task 4

using System;

class Program
{
    static void Main()
    {
        // Введення розмірності масиву
        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість елементів у рядку (m): ");
        int m = int.Parse(Console.ReadLine());

        // Ініціалізація та введення значень елементів масиву
        int[,] array = new int[n, m];

        Console.WriteLine("Введіть елементи масиву:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Елемент [{i + 1},{j + 1}]: ");
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Підрахунок сум парних додатних елементів для кожного стовпця
        int[] columnSums = new int[m];

        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n; i++)
            {
                if (array[i, j] > 0 && array[i, j] % 2 == 0)
                {
                    columnSums[j] += array[i, j];
                }
            }
        }

        // Виведення результатів
        Console.WriteLine("\nСуми парних додатних елементів для кожного стовпця:");

        for (int j = 0; j < m; j++)
        {
            Console.WriteLine($"Стовпець {j + 1}: {columnSums[j]}");
        }
    }
}



