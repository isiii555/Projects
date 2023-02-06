using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp15
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void CheckShop(ref Shop shop)
        {
            int count = 0;
            foreach (var item in shop.Stands)
            {
                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (item.Value[i].Status == 0)
                    {
                        item.Value.Remove(item.Value[i]);
                        count++;
                        shop.vegetableCount++;
                    }
                }
            }
            Console.WriteLine($"\n{count} Terevez zeherli oldugu ucun atildi...");
        }

    }
}
