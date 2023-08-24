namespace day02_ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code Day 02 exercise 2/2 - by remiranda");
            Console.WriteLine("22 of August 2023");
            Console.Write("Enter the input path: ");
            string input_path;
            string[] parsed_input;


            input_path = Console.ReadLine();
            if (input_path == null)
                throw new ArgumentException("Usage: path to input file");
            else if (!File.Exists(input_path))
                throw new ArgumentException("Error: cannot access file");
            parsed_input = parse_input(input_path);
            Console.WriteLine("The result is " + get_result(parsed_input));
            Console.Write("Press ENTER do exit...");
            Console.ReadLine();
            return;
        }

        public static string[] parse_input(string input_path)
        {
            string[] result;

            result = File.ReadAllLines(input_path);
            return (result);
        }

        public static int get_result(string[] parsed_input)
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
                remainder = parsed_input[index][0] - 'A' + 1;
                if (parsed_input[index][2] == 'Y') // Draw case
                    result += 3 + remainder;
                else if (parsed_input[index][2] == 'Z') // Win case
                {
                    result += 6;
                    if (remainder > 2)
                        result += 1;
                    else
                        result += remainder + 1;
                }
                else
                {
                    if (remainder < 2)
                        result += 3;
                    else
                        result += remainder - 1;
                }
                index++;
            }
            return (result);
        }
    }
}