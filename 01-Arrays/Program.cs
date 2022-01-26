using System;

namespace _01_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArraysDemo();

            // Create arrays with 1 index
            //Test1BasedArray();

            // Multi-dimensional arrays
            //MultiDimArrays();

            // Jagged arrays
            //JaggedArrays();

            // Using pointers to traverse an array
            //IterateOver(new[] {1, 2, 3});

            Console.Read();
        }

        private static void ArraysDemo()
        {
            // Different ways to initialize an array
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[] { 1, 3, -2, 5, 10};

            int[] a4 = { 1, 2, 3, 4, 5};

            // Different ways to traverse an array
            for (int i = 0; i < a3.Length; i++)
            {
                Console.Write($"{a3[i]} ");
            }
            
            Console.WriteLine();

            foreach (var el in a4)
            {
                Console.Write($"{el} ");
            }

            Console.WriteLine();

            // Arrrays derive from System.Array class
            Array myArray = new int[5];

            Array myArray2 = Array.CreateInstance(typeof(int), 5);
            myArray2.SetValue(1, 0);
        }

        private static void Test1BasedArray()
        {
            // Create a new array and specify the starting index
            Array myArray = Array.CreateInstance(typeof(int), new[] {4}, new[] {1});

            myArray.SetValue(2019, 1);
            myArray.SetValue(2020, 2);
            myArray.SetValue(2021, 3);
            myArray.SetValue(2022, 4);

            Console.WriteLine($"Starting index: {myArray.GetLowerBound(0)}");
            Console.WriteLine($"Ending index: {myArray.GetUpperBound(0)}");

            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
        }

        private static void MultiDimArrays()
        {
            // Multidimensional arrays hold the same amount of values in each position
            // Declared with commas inside the brackets
            int[,] r1 = new int[2, 3] { {1, 2, 3}, {4, 5, 6} };

            int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // In multi-dimensional arrays the Length property returns the total amount of elements
            for (int i = 0; i < r2.GetLength(0); i++)
            {
                for (int j = 0; j < r2.GetLength(1); j++)
                {
                    Console.Write($"{r2[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void JaggedArrays()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            Console.WriteLine("Enter the numbers for a jagged array.");

            // In jagged arrays the Length property retunrs the amount of elements in the first dimension
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string value = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(value);
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Printing the elements:");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        private static unsafe void IterateOver(int[] array)
        {
            // fixed tells the Garbage Collector to pin an object and not change its address during runtime
            // has performance implications so fixed blocks should be kept to a minimum
            // heap allocations should be avoided inside a fixed block
            fixed(int* b = array)
            {
                // we need another pointer because we can't modify the fixed one
                int* p = b;

                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(*p);
                    p++;
                }
            }
        }

        private static void ArrayTimeComplexity(object[] array)
        {
            // access by index -> O(1)
            Console.WriteLine(array[0]);

            // searching for an element -> O(n)
            object elementToFind = new object();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == elementToFind)
                {
                    Console.WriteLine("Exists/Found");
                }
            }

            // add to the end of an array -> O(1)
            array[array.Length - 1] = 10;

            // add to a full array -> O(n)
            var bigArray = new int[array.Length * 2];
            Array.Copy(array, bigArray, array.Length);
            bigArray[array.Length + 1] = 10;

            // remove an element by assigning null -> O(1)
            array[6] = null;

            // remove an element by shifting -> O(n)
            RemoveAt(array, 0);
        }

        private static void RemoveAt(object[] array, int index)
        {
            var newArr = new object[array.Length - 1];
            Array.Copy(array, 0, newArr, 0, index);
            Array.Copy(array, index + 1, newArr, index, array.Length - 1 - index);
        }
    }
}
