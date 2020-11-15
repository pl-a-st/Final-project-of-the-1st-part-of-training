using System;

namespace Final_project_of_the_1st_part_of_training
{
    class Program
    {
        static void Main(string[] args)
        {
            for(; ; )
            {
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(1 + Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((i-1) / 4))));
                Console.WriteLine("");
            }
            
        }
    }
}
