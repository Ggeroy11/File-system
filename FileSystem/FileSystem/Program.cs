using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {


            string text = "0 1 1 2 3 5 8 ";
            List<int> fibonchiNumber = new List<int>();
            using (FileStream fstream = new FileStream(@"C:chisla.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
            using (FileStream fstream = File.OpenRead(@"chisla.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string str = System.Text.Encoding.Default.GetString(array);
                string[] number = str.Split(' ');
                for (int i = 0; i < number.Length; i++)
                {
                    fibonchiNumber.Add(Int32.Parse(number[i]));
                }
                for (int i=0;i<number.Length;i++) {
                    fibonchiNumber.Add(fibonchiNumber[fibonchiNumber.Count - 1] + fibonchiNumber[fibonchiNumber.Count - 2]);
                }
                
            }
            using (FileStream ofstream=File.Open(@"chisla.txt",FileMode.OpenOrCreate)) {
                string fibonachiNumbers = "";
                foreach (var a in fibonchiNumber) {
                    fibonachiNumbers = a.ToString();
                    fibonachiNumbers = " ";
                }
                byte[] arrayNumbers = new byte[fibonachiNumbers.Length];
                arrayNumbers = System.Text.Encoding.Default.GetBytes(fibonachiNumbers);
                ofstream.Write(arrayNumbers,0,arrayNumbers.Length);
            }


                Console.ReadLine();
        }
    }
}
