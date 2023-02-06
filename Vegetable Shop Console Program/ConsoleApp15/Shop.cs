namespace ConsoleApp15
{
    public class Shop
    {
        public Shop(double currentRaiting, string name, double bank)
        {
            this.currentRaiting = 0;
            Name = name;
            Bank = bank;
        }

        public double currentRaiting { get; set; } 

        public string Name { get; set; }
        
        public int customerCount { get; set; }

        public double Profit { get; set; }

        public double Cost { get; set; }

        public double Bank { get; set; } = 5000;

        public int vegetableCount { get; set; }

        public Employee employee { get; set; } = new("islam");

        public Dictionary<string, List<Vegetable>> Stands { get; set; } = new();

    }
}
