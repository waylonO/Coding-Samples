namespace SWCCorpCarpetEntry
{
    public class OrderOutput
    {
        public Order InputOrder { get; set; }
        
        public decimal ProductPrice { get; set; }

        public int Area { get { return InputOrder.Length*InputOrder.Width; } }

        public decimal TotalPrice { get { return Area* ProductPrice; } }

        public OrderOutput(Order order, decimal price)
        {
            InputOrder = order;
            ProductPrice = price;
        }
    }
}
