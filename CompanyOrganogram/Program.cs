using System;
using System.Diagnostics;

namespace CompanyOrganogram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            LineWriter lineWriter = new LineWriter();
            DataReader dataReader = new DataReader();
            Organogram organogram = new Organogram(lineWriter, dataReader);

            stopwatch.Start();

            organogram.PrintOrganogram(organogram.BuildOrganogram());

            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }


    }
}
