using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    public class Report
    {
        public Report(double currentRaiting, int customerCount, double profit, double cost, int vegetableCount)
        {
            this.currentRaiting = currentRaiting;
            this.customerCount = customerCount;
            Profit = profit;
            Cost = cost;
            this.vegetableCount = vegetableCount;
        }

        public double currentRaiting { get; set; }

        public int customerCount { get; set; }

        public double Profit { get; set; }

        public double Cost { get; set; }

        public int vegetableCount { get; set; }
    }
}
