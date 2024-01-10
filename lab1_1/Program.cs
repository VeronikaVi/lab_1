 /* Вариант 17. Часть 1

 Написать программу, которая, согласно заданному варианту, будет выполнять операции
 над массивами. Массивы заполнять с использованием генератора случайных чисел
 
 В одномерном массиве, состоящем из N вещественных элементов, вычислить:
 - количество элементов массива, меньших С
 - сумму целых частей элементов массива, расположенных после последнего
   отрицательного элемента
 - Преобразовать массив таким образом, чтобы сначала располагались все элементы,
   отличающиеся от максимального не более чем на 20%, а потом — все остальные */

namespace lab1_1
{
   using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            // Ввод размера массива N
            Console.Write("Введите размер массива N: ");
            if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
            {
                Console.WriteLine("Некорректный ввод. Размер массива должен быть положительным целым числом.");
                return;
            }

            // Ввод значения C
            Console.Write("Введите значение C: ");
            if (!double.TryParse(Console.ReadLine(), out double C))
            {
                Console.WriteLine("Некорректный ввод. Значение C должно быть числом.");
                return;
            }

            // Генерация случайного массива
            double[] array = GenerateRandomArray(N);

            // Вывод исходного массива
            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // Вычисление количества элементов, меньших C
            int countLessThanC = CountElementsLessThanC(array, C);

            // Нахождение последнего отрицательного элемента
            int lastNegativeIndex = FindLastNegativeIndex(array);

            // Вычисление суммы целых частей элементов после последнего отрицательного
            int sumIntParts = SumIntPartsAfterLastNegative(array, lastNegativeIndex);

            // Сортировка массива
            double[] sortedArray = SortArray(array);

            // Вывод результатов
            Console.WriteLine($"Количество элементов меньше {C}: {countLessThanC}");
            Console.WriteLine($"Сумма целых частей элементов после последнего отрицательного: {sumIntParts}");
            Console.WriteLine("Преобразованный массив:");
            PrintArray(sortedArray);
        }

        // Генерация случайного массива
        static double[] GenerateRandomArray(int size)
        {
            double[] array = new double[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.NextDouble() * 10; // Пусть значения будут от 0 до 10
            }

            return array;
        }

        // Вывод массива на экран
        static void PrintArray(double[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write($"{element:F2} ");
            }
            Console.WriteLine();
        }

        // Подсчет количества элементов, меньших C
        public static int CountElementsLessThanC(double[] arr, double C)
        {
            int count = 0;
            foreach (var element in arr)
            {
                if (element < C)
                {
                    count++;
                }
            }
            return count;
        }

        // Поиск индекса последнего отрицательного элемента
        public static int FindLastNegativeIndex(double[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] < 0)
                {
                    return i;
                }
            }
            return -1; // Если отрицательных элементов нет
        }

        // Подсчет суммы целых частей элементов после последнего отрицательного
        public static int SumIntPartsAfterLastNegative(double[] arr, int lastNegativeIndex)
        {
            int sum = 0;
            if (lastNegativeIndex != -1)
            {
                for (int i = lastNegativeIndex + 1; i < arr.Length; i++)
                {
                    sum += (int)arr[i];
                }
            }
            return sum;
        }

        // Сортировка массива
        public static double[] SortArray(double[] arr)
        {
            double maxElement = arr.Max();
            var sortedArray = arr.OrderBy(e => Math.Abs(e - maxElement) > maxElement * 0.2).ToArray();
            return sortedArray;
        }
    }
}