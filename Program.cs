using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixDiagonals
{
    internal class Program
    {

        static int GetSumOfDiagonals(int[,] matrix, bool mainDiagonal = true)
        {
            int sum = 0;

            int size = matrix.GetLength(0);

            if (mainDiagonal)
            {
                for (int i = 0; i < size; i++)
                {
                    sum += matrix[i, i];
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    sum += matrix[i, size - i - 1];
                }
            }


            return sum;
        }

        static int[,] GetMatrix(uint size)
        {
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine($"X : {j}, Y : {i}");

                    int num;

                    while (!int.TryParse(Console.ReadLine(), out num))
                    {
                        Console.WriteLine("Invalid input. Enter an integer:");
                    }
                    matrix[i, j] = num;


                }
                Console.WriteLine();
            }

            return matrix;
        }

        static int[,] GetMatrix(uint size, uint minValue, uint maxValue)
        {

            int[,] matrix = new int[size, size];

            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    matrix[i, j] = random.Next((int)minValue, (int)maxValue + 1);

                }
            }

            return matrix;
        }


        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    Console.Write(matrix[i, j] + "\t");

                }
                Console.WriteLine();
            }
        }



        static void Main(string[] args)
        {
            bool isRepeat = true;
            do
            {

                uint size;


                do
                {
                    Console.WriteLine("Enter size of matrix : ");

                    if (!uint.TryParse(Console.ReadLine(), out size) || size == 0)
                    {
                        Console.WriteLine("Invalid input! Please enter a number greater than 0.\n");
                    }
                }
                while (size == 0);

                Console.WriteLine("Fill the matrix yourself, or automatically with random numbers in a given range? (1 = on one's own, 2 = automatically setting the range)");

                string input = Console.ReadLine();

                int[,] matrix;

                if (input.Equals("1"))
                {
                    matrix = GetMatrix(size);
                }
                else
                {
                    Console.WriteLine("Enter minimum value and max value : ");

                    uint minValue;
                    uint maxValue;

                    Console.WriteLine("Min : ");

                    while (!uint.TryParse(Console.ReadLine(), out minValue))
                    {
                        Console.WriteLine("\nInvalid input. The input is not a number or is less than 0.");
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Enter minimum value and max value : \n");
                    }

                    Console.WriteLine("Max : ");

                    while (!uint.TryParse(Console.ReadLine(), out maxValue) || minValue >= maxValue)
                    {
                        Console.WriteLine("Invalid input. The input is not a number or is less than the specified minimum value, try again.");
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Enter max value : \n");
                    }
                    matrix = GetMatrix(size, minValue, maxValue);
                }


                Console.WriteLine("\nMatrix :\n");

                PrintMatrix(matrix);

                bool isMainDiagonal = true;


                Console.WriteLine("\nMain diagonal or additional ? write \"M\" or \"Add\" \n");

                input = Console.ReadLine();

                string lowerInput = input.ToLower();

                if (lowerInput.Equals("add"))
                {
                    isMainDiagonal = false;
                }

                int sumOfDiagonal = GetSumOfDiagonals(matrix, isMainDiagonal);

                Console.WriteLine($"\nSum of {(isMainDiagonal ? "main" : "secondary")} diagonal: {sumOfDiagonal} \n");

                Console.WriteLine("Do you want to continue? If yes then enter \"y\" or \"yes\", otherwise \"q\" or \"quit\" .\n");

                input = Console.ReadLine();
                lowerInput = input.ToLower();
                Console.WriteLine();

                if (lowerInput.Equals("q") || lowerInput.Equals("quit"))
                    isRepeat = false;
            }
            while (isRepeat);


        }

    }
}
