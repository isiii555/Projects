namespace ConsoleApp15
{
    public class Vegetable
    {
        public Vegetable(int status, double price,double salePrice)
        {
            Status = status;
            Price = price;
            this.salePrice = salePrice;
        }

        public int Status { get; set; }

        //toxic - 0
        //rotten - 1
        //staled - 2
        //new - 3

        public double Price { get; set; }

        public double salePrice { get; set; }   

    }
}
