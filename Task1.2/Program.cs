namespace Task1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += (10 - i) * int.Parse(input[i].ToString());
            }

            int checkedDigit = (11 - sum % 11) % 11;

            string digitInput = (checkedDigit == 10) ? "X" :
                checkedDigit.ToString();

            Console.WriteLine($"{input}{digitInput}");
        }
    }
}
