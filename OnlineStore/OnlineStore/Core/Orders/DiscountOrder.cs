namespace OnlineStore.Core.Orders

{
    public class DiscountOrder : Order
    {
        private float _discount;
        public float Discount
        { 
            get
            {  
                return _discount;
            }
            set
            {
                if(value == 0 || value < 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
            }
        }

        public DiscountOrder(string productName, float productPrice, long customerName, string deliveryAddress, float discount) : base
                       (productName, productPrice, customerName, deliveryAddress)
        {
            Discount = discount;
        }

        public override string GetFullInformation()
        {
            return $"Product name: {ProductName}, Product price: {ProductPrice} BYN, Customer number: +{CustomerNumber}, " +
                   $"Delivery address: {DeliveryAddress}, Discount: {Discount}%";
        }
    }
}