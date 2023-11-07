using OnlineStore.Core.Orders;
using OnlineStore.Interfaces;

namespace OnlineStore.Core.DeliveryMethods
{
    public abstract class BaseDeliveryMethod : IDelivery
    {
        private string _name;
        private byte _averageDeliveryTime;
        private byte _maximumOrderQuantity;


        public string Name
        { 
            get 
            { 
                return _name; 
            } 
            set
            {
                if (value == "No name" || value == "" || value == null)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _name = value;
            }
        }

        public byte AverageDeliveryTime
        {
            get
            { 
                return _averageDeliveryTime;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _averageDeliveryTime = value;
            }
        }

        public byte MaximumOrderQuantity
        {
            get
            {
                return _maximumOrderQuantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _maximumOrderQuantity = value;
            }
        }

        public List<Order> _orders = new List<Order>();

        public BaseDeliveryMethod(string name, byte averageDeliveryTime, byte maximumOrderQuantity)
        {
            Name = name;
            AverageDeliveryTime = averageDeliveryTime;
            MaximumOrderQuantity = maximumOrderQuantity;
        }

        public bool IsFree()
        {
            if (MaximumOrderQuantity > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeliverOrder(Order order)
        {
            if (order is VIPOrder)
            {
                _orders.Add(order);
                MaximumOrderQuantity = 0;
                return true;
            }
            else if (IsFree() == true)
            {
                _orders.Add(order);
                MaximumOrderQuantity -= 1;
                return true;
            }
            return false;
        }


        public abstract int ExpectedDeliveryTime(Order order);
    }
}