using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Gray;
            int[] diem = new int[9] { 1, 4, 5, 6, 7, 8, 9, 10, 9};
            int i = 0;
            for (i = 0; i < diem.Length;  i++)
            {
                Console.Write(diem[i] + " ");
            }
            Console.WriteLine("\n");
            foreach (var c in diem){
                Console.Write(c + " ");
            }
            Console.WriteLine("");
            for (i = 0; i < diem.Length; ++i)
            {
                if (diem[i] == 9)
                {
                    Console.WriteLine("số thứ {0} là 9", ++i);
                    break;
                }
            }
            Console.WriteLine(i);
        }
    }
}