using OnlineStore.Core.Orders;
using OnlineStore.Interfaces;

namespace OnlineStore.Core.DeliveryMethods
{
    public abstract class BaseDeliveryMethod : IDelivery
    {
        public string Name;
        public int AverageDeliveryTime;
        public int MaximumOrderQuantity;
        public List<Order> _orders = new List<Order>();

        public BaseDeliveryMethod(string name, int averageDeliveryTime, int maximumOrderQuantity)
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
            if (/*IsFree() == true &&*/ order is VIPOrder)
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