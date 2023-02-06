namespace ConsoleApp15
{
    public class Customer
    {
        public Customer(double money, int moral)
        {
            Money = money;
            Moral = moral;
        }

        public double Money { get; set; }

        public int Moral { get; set; }

        // happy - 0 (+0.1 raiting)
        // sad - 1 (-0.1 raiting)


    }
}
