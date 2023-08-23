using System;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
namespace adventofcode;

class Program_01
{
    static void Main(string[] args)
    {
        string      input_path;
        string[]    formatted_input;
        int         result;

        Console.WriteLine("Advent Of Code 00 - by remiranda");
        Console.WriteLine("20 of August 2023");
        Console.Write("Enter the input path: ");
        input_path = Console.ReadLine();
        if (input_path == null)
            throw new ArgumentException("Usage: path to input file");
        else if (!File.Exists(input_path))
            throw new ArgumentException("Error: cannot access file");
        formatted_input = get_input_lines(input_path);
        result = find_elf_with_most_calories(formatted_input);
        Console.WriteLine($"The result is {result}");
        Console.Write("Enter anything to exit... ");
        Console.ReadLine();
        return ;
    }

    public static string[] get_input_lines(string file_path)
    {
        string[] result_array;

        result_array = File.ReadAllLines(file_path);
        return (result_array);
    }

    public static int   find_elf_with_most_calories(string[] formsatted_input)
    {
        int[] result;
        int temp;
        int index;
        int size;

        result = new int[] {0, 0, 0};
        temp = 0;
        index = 0;
        size = formsatted_input.Length;
        while (index < size)
        {
            if (formsatted_input[index].Length == 0)
            {
                if (temp > result[0])
                    update_result(temp, result);
                temp = 0;
            }
            else
            {
                temp += int.Parse(formsatted_input[index]);
            }
            index++;
        }
        return (Enumerable.Sum(result));
    }

    public static void  update_result(int temp, int[] result_array)
    {
        if (temp < result_array[1])
            result_array[0] = temp;
        else if (temp < result_array[2])
        {
            result_array[0] = result_array[1];
            result_array[1] = temp;
        }
        else
        {
            result_array[0] = result_array[1];
            result_array[1] = result_array[2];
            result_array[2] = temp;
        }
    }
}

