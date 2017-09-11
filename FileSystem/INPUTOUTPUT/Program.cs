using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPUTOUTPUT
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fstream = File.Create("Input.txt"))
            {
                string numbers = "10 25";
                byte[] bytes = System.Text.Encoding.Default.GetBytes(numbers);
                fstream.Write(bytes,0,bytes.Length);
            }
            string Sum;
            using (FileStream ifstream=new FileStream("Input.txt",FileMode.Open)) {
                byte[] bytes = new byte[ifstream.Length];
                ifstream.Read(bytes, 0, bytes.Length);
                string number = Encoding.Default.GetString(bytes);
                string[] numbers = number.Split(' ');
                Sum=(Int32.Parse(numbers[0]) + Int32.Parse(numbers[1])).ToString();
                Console.WriteLine("{0}+{1}={2}", numbers[0], numbers[1],Sum);
            }
            using (FileStream ofstream = File.Create("OUTPUT.txt"))
            {
                byte[] bytes = System.Text.Encoding.Default.GetBytes(Sum);
                ofstream.Write(bytes, 0, bytes.Length);
                Console.WriteLine("Создан файл  OUTPUT.txt где хранится {0}",Sum);
            }
                Console.ReadLine();
            
        }
    }
}
