namespace OnlineStore
{
    public class Order
    {
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public long CustomerNumber { get; set; }
        public string DeliveryAddress { get; set; }

        public Order(string productName, float productPrice, long customerName, string deliveryAddress)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            CustomerNumber = customerName;
            DeliveryAddress = deliveryAddress;
        }

        public string GetFullInformation()
        {
            return $"Product name: {ProductName}, Product price: {ProductPrice} BYN, Customer number: {CustomerNumber}, Delivery address: {DeliveryAddress}";
        }
    }
}
