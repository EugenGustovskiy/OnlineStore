namespace OnlineStore
{
    public class VIPOrder : Order
    {
        public string Present {  get; set; }

        public VIPOrder(string productName, float productPrice, long customerName, string deliveryAddress, string present):base
                       (productName, productPrice, customerName, deliveryAddress)
        {
            Present = present;
        }

        public override string GetFullInformation()
        {
            return $"Product name: {ProductName}, Product price: {ProductPrice} BYN, Customer number: {CustomerNumber}, " +
                   $"Delivery address: {DeliveryAddress}, Present: {Present}";
        }
    }
}