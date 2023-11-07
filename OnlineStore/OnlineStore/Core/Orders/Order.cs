namespace OnlineStore.Core.Orders

{
    public class Order : IComparable<Order>
    {
        private string _productName;
        private float _productPrice;
        private long _customerNumber;
        private string _deliveryAddress;

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (value == "No name" || value == "")
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _productName = value;
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
                if(value <= 0 || value > 4000)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _productPrice = value;
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
                if (value < 0 || value.ToString().Length != 12)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _customerNumber = value;
            }
        }

        public string DeliveryAddress
        { 
            get
            {
                return _deliveryAddress;
            }
            set
            {
                if (value == "No address" || value == "" || value == null)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _deliveryAddress = value;
            }
        }

        public Order(string productName, float productPrice, long customerName, string deliveryAddress)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            CustomerNumber = customerName;
            DeliveryAddress = deliveryAddress;
        }

        public virtual string GetFullInformation()
        {
            return $"Product name: {ProductName}, Product price: {ProductPrice} BYN, Customer number: +{CustomerNumber}, Delivery address: {DeliveryAddress}";
        }

        //Increase
        public int CompareTo(Order? other)
        {
            if (other == null)
            {
                return 1;
            }
            return CustomerNumber.CompareTo(other.CustomerNumber);
        }

        //Decreasing
        /*public int CompareTo(Order? other)
        {
            if (other == null)
            {
                return 1;
            }
            return other.CustomerNumber.CompareTo(CustomerNumber);
        }*/

        public override bool Equals(object? obj)
        { 
            if(obj is Order)
            {
                Order order = obj as Order;
                return order.ProductName == ProductName &&
                       order.ProductPrice == ProductPrice &&
                       order.CustomerNumber == CustomerNumber &&
                       order.DeliveryAddress == DeliveryAddress;
            }
            return false;
        }
    }
}