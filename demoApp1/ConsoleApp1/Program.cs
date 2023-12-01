using System.ComponentModel.Design;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Nhập số thứ nhất: ");
            int so1 = int.Parse(Console.ReadLine());
            Console.Write("Nhập số thứ hai: ");
            int so2 = Convert.ToInt32(Console.ReadLine());
            mMenu();
            Console.Write("Nhập lựa chọn của bạn: ");
            int choice = int.Parse(Console.ReadLine());
            int result;
            switch (choice)
            {
                case 1:
                    result = so1 + so2;
                    Console.WriteLine("{0} + {1} = {2}",so1,so2,result);
                    break;
                case 2:
                    result = so1 - so2;
                    Console.WriteLine("{0} - {1} = {2}", so1, so2, result);
                    break;
                case 3:
                    result = so1 * so2;
                    Console.WriteLine("{0} * {1} = {2}", so1, so2, result);
                    break;
                case 4:
                    result = so1 / so2;
                    Console.WriteLine("{0} / {1} = {2}", so1, so2, result);
                    break;
            }
        }
        public static void mMenu()
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("1. Cộng");
            Console.WriteLine("2. Trừ");
            Console.WriteLine("3. Nhân");
            Console.WriteLine("4. Chia");
        }
    }
}
/*Console.WriteLine("Hello, World!");
            double a;
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Vừa nhập a = {0}", a);
            Console.WriteLine($"Hay a = {a}");
            Console.WriteLine("Hoặc a = " + a);*/