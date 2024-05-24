using System;

namespace Task1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] originalArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                originalArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Original array:");
            OutputArray(originalArray);

            int uniqueCount = 0;
            bool[] isDuplicate = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!isDuplicate[i])
                {
                    uniqueCount++;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (originalArray[i] == originalArray[j])
                        {
                            isDuplicate[j] = true;
                        }
                    }
                }
            }

            int[] newArray = new int[uniqueCount];
            int newIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (!isDuplicate[i])
                {
                    newArray[newIndex++] = originalArray[i];
                }
            }

            Console.WriteLine("New array:");
            OutputArray(newArray);
        }

        static void OutputArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
