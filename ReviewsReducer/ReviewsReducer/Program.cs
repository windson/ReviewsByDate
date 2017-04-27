using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsReducer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary for holding a count of dates
            Dictionary<string, int> dates = new Dictionary<string, int>();

            string line;
            //Read from STDIN
            while ((line = Console.ReadLine()) != null)
            {
                // Data from Hadoop is tab-delimited key/value pairs
                var sArr = line.Split('\t');
                // Get the date
                string date = sArr[0];
                // Get the count
                int count = Convert.ToInt32(sArr[1]);

                //Do we already have a count for the date?
                if (dates.ContainsKey(date))
                {
                    //If so, increment the count
                    dates[date] += count;
                }
                else
                {
                    //Add the key to the collection
                    dates.Add(date, count);
                }
            }
            //sort by decreasing order of count and emit each date and count of reviews
            foreach (var date in dates.OrderByDescending(key => key.Value))
            {
                //Emit tab-delimited key/value pairs.
                //In this case, a date and a count of 1.
                Console.WriteLine("{0}\t{1}", date.Key, date.Value);
            }
        }
    }
}
