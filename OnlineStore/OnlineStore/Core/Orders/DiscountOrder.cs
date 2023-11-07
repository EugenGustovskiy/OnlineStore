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
                _discount = value;
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

        public override bool Equals(object? obj)
        {
            if (obj is DiscountOrder)
            {
                DiscountOrder discountOrder = obj as DiscountOrder;
                return discountOrder.ProductName == ProductName &&
                       discountOrder.ProductPrice == ProductPrice &&
                       discountOrder.CustomerNumber == CustomerNumber &&
                       discountOrder.DeliveryAddress == DeliveryAddress &&
                       discountOrder.Discount == Discount;
            }
            return false;
        }
    }
}