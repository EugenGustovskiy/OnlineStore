namespace OnlineStore.Core.Orders

{
    public class VIPOrder : Order
    {
        private string _present;
        public string Present 
        { 
            get
            {
                return _present;
            }
            set
            {
                if(value == "No name present" || value == "" || value == null)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _present = value;
            }
        }

        public VIPOrder(string productName, float productPrice, long customerName, string deliveryAddress, string present) : base
                       (productName, productPrice, customerName, deliveryAddress)
        {
            Present = present;
        }

        public override string GetFullInformation()
        {
            return $"Product name: {ProductName}, Product price: {ProductPrice} BYN, Customer number: +{CustomerNumber}, " +
                   $"Delivery address: {DeliveryAddress}, Present: {Present}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is VIPOrder)
            {
                VIPOrder vipOrder = obj as VIPOrder;
                return vipOrder.ProductName == ProductName &&
                       vipOrder.ProductPrice == ProductPrice &&
                       vipOrder.CustomerNumber == CustomerNumber &&
                       vipOrder.DeliveryAddress == DeliveryAddress &&
                       vipOrder.Present == Present;
            }
            return false;
        }
    }
}