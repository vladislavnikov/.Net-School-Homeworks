using System;

namespace HM1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            for (int i = a; i <= b; i++)
            {
                int count = 0;
                int num = i;
                while (num > 0)
                {
                    if (num % 12 == 10) 
                    {
                        count++;
                    }
                    num /= 12;
                }

                if (count == 2)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
