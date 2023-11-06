using OnlineStore.Core.Orders;

namespace OnlineStore.Core.DeliveryMethods
{
    internal class MotorcycleDelivery : BaseDeliveryMethod
    {
        public string RegistrationNumber;

        public MotorcycleDelivery(string name, int averageDeliveryTime, int maximumOrderQuantity, string registrationNumber) :
                             base(name, averageDeliveryTime, maximumOrderQuantity)
        {
            RegistrationNumber = registrationNumber;
        }

        //public override bool DeliverOrder(Order order)
        //{
        //    if (IsFree() == true && order is VIPOrder)
        //    {
        //        _orders.Add(order);
        //        MaximumOrderQuantity = 0;
        //        return true;
        //    }
        //    else if (IsFree() == true)
        //    {
        //        _orders.Add(order);
        //        MaximumOrderQuantity -= 1;
        //        return true;
        //    }
        //    return false;
        //}

        public override int ExpectedDeliveryTime(Order order)
        {
            if (order is VIPOrder)
            {
                return AverageDeliveryTime - 10;
            }
            return AverageDeliveryTime;
        }
    }
}