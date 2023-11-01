namespace OnlineStore
{
    public class DiscountOrder : Order
    {
        public float Discount {  get; set; }

        public DiscountOrder(string productName, float productPrice, long customerName, string deliveryAddress, float discount) : base
                       (productName, productPrice, customerName, deliveryAddress)
        {
            Discount = discount;
        }

        public override string GetFullInformation()
        {
            return $"Product name: {ProductName}, Product price: {ProductPrice} BYN, Customer number: {CustomerNumber}, " +
                   $"Delivery address: {DeliveryAddress}, Discount: {Discount}%";
        }
    }
}