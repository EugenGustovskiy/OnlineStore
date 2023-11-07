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
                if(value == "No name present" || value == "")
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
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
    }
}