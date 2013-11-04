namespace SWCCorpCarpetEntry
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string ProductCode { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }

        public Order()
        {
            
        }

        public Order(string[] data)
        {
            CustomerName = data[0];
            Address1 = data[1];
            Address2 = data[2];
            City = data[3];
            State = data[4];
            Zipcode = data[5];
            ProductCode = data[6];
            Length = int.Parse(data[7]);
            Width = int.Parse(data[8]);
        }
    }
}
