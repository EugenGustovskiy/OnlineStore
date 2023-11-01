namespace OnlineStore
{
    public class Order
    {
        private string _productName;
        private float _productPrice;
        private long _customerNumber;
        
        public string ProductName
        {
            get
            { 
                return _productName;
            }
            set
            {
                if (value != "No name" && value != "")
                {
                    _productName = value;
                }
                else
                {
                    _productName = "PROBLEMS WITH THE NAME";
                }
            }
        }
        public float ProductPrice
        {
            get
            {
                return _productPrice;
            }
            set
            {
                if (value > 0 && value < 4000)
                { 
                    _productPrice = value;
                }
            }
        }
        public long CustomerNumber
        {
            get
            {
                return _customerNumber;
            }
            set
            {
                if (value > 0 && value.ToString().Length == 12)
                {
                    _customerNumber = value;
                }
            }
        }

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