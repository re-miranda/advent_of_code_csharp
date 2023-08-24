namespace day02_ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code Day 02 exercise 1/2 - by remiranda");
            Console.WriteLine("22 of August 2023");
            Console.Write("Enter the input path: ");
            string      input_path;
            string[]    parsed_input;


            input_path = Console.ReadLine();
            if (input_path == null)
                throw new ArgumentException("Usage: path to input file");
            else if (!File.Exists(input_path))
                throw new ArgumentException("Error: cannot access file");
            parsed_input = parse_input(input_path);
            Console.WriteLine("The result is " + get_result(parsed_input));
            Console.Write("Press ENTER do exit...");
            Console.ReadLine();
            return ;
        }

        public static string[] parse_input(string input_path)
        {
            string[] result;

            result = File.ReadAllLines(input_path);
            return (result);
        }

        public static int   get_result(string[] parsed_input)
        {
            int result;
            int index;
            int array_lenght;
            int remainder;

            result = 0;
            index = 0;
            array_lenght = parsed_input.Length;
            while (index < array_lenght)
            {
                result += parsed_input[index][2] - 87;
                remainder = parsed_input[index][2] - parsed_input[index][0];
                if (remainder == 23) // Draw case
                        result += 3;
                if (remainder == 24 || remainder == 21) // Win case
                        result += 6;
                index++;
            }
            return (result);
        }
    }
}