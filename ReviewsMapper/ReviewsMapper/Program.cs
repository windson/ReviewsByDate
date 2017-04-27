using System;
using System.Linq;

namespace ReviewsMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            //Hadoop passes data to the mapper on STDIN
            while ((line = Console.ReadLine()) != null)
            {
                // We need date, so strip out everything before last occurence of |||
                string datefrominput = line.Split(new char[] { '|' }).LastOrDefault();
                //Format date
                var dateParts = datefrominput.Replace(",", "").Split(new char[] { ' ' });
                var formattedDated = $"{dateParts[0]}-{dateParts[1]}-{dateParts[2]}";
                //write date from every line to the console
                Console.WriteLine("{0}\t1", formattedDated);
            }
        }
    }
}
