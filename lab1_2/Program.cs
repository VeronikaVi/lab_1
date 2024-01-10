 /* Вариант 17. Часть 2
 
 Написать программу, которая, согласно заданному варианту, будет выполнять операции
 над двумерным массивом. Массивы заполнять с использованием генератора случайных чисел
 
 Дана целочисленная прямоугольная матрица. Определить:
 - количество строк, содержащих хотя бы один нулевой элемент
 - номер столбца, в котором находится самая длинная серия одинаковых элементов */
 
namespace lab1_2
{
    using System;

    class Program
    {
        static void Main()
        {
            // Ввод количества строк матрицы
            Console.Write("Введите количество строк матрицы: ");
            if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0)
            {
                Console.WriteLine("Некорректный ввод. Количество строк должно быть положительным целым числом.");
                return;
            }

            // Ввод количества столбцов матрицы
            Console.Write("Введите количество столбцов матрицы: ");
            if (!int.TryParse(Console.ReadLine(), out int cols) || cols <= 0)
            {
                Console.WriteLine("Некорректный ввод. Количество столбцов должно быть положительным целым числом.");
                return;
            }

            // Генерация случайной матрицы
            int[,] matrix = GenerateRandomMatrix(rows, cols);

            // Вывод исходной матрицы
            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            // Определение количества строк с хотя бы одним нулевым элементом
            int rowsWithZero = CountRowsWithZero(matrix);

            // Определение номера столбца с самой длинной серией одинаковых элементов
            int longestSeriesColumn = FindLongestSeriesColumn(matrix);

            // Вывод результатов
            Console.WriteLine($"Количество строк с хотя бы одним нулевым элементом: {rowsWithZero}");
            Console.WriteLine($"Номер столбца с самой длинной серией одинаковых элементов: {longestSeriesColumn}");
        }

        // Генерация случайной матрицы
        static int[,] GenerateRandomMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(10); // Пусть значения будут от 0 до 9
                }
            }

            return matrix;
        }

        // Вывод матрицы на экран
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        // Подсчет количества строк с хотя бы одним нулевым элементом
        public static int CountRowsWithZero(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        count++;
                        break; // Переходим к следующей строке после обнаружения нулевого элемента
                    }
                }
            }

            return count;
        }

        // Поиск номера столбца с самой длинной серией одинаковых элементов
        public static int FindLongestSeriesColumn(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int longestSeriesColumn = -1;
            int currentSeriesLength = 0;
            int longestSeriesLength = 0;

            for (int j = 0; j < cols; j++)
            {
                currentSeriesLength = 1;

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] == matrix[i - 1, j])
                    {
                        currentSeriesLength++;
                    }
                    else
                    {
                        currentSeriesLength = 1;
                    }

                    if (currentSeriesLength > longestSeriesLength)
                    {
                        longestSeriesLength = currentSeriesLength;
                        longestSeriesColumn = j;
                    }
                }
            }

            return longestSeriesColumn;
        }
    }
}