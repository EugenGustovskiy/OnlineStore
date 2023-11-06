using OnlineStore.Core.Orders;

namespace OnlineStore.Core.DeliveryMethods
{
    public class DroneDelivery : BaseDeliveryMethod
    {
        public string IdentificationalNumber;

        public DroneDelivery(string name, int averageDeliveryTime, int maximumOrderQuantity, string identificationalNumber) :
                        base(name, averageDeliveryTime, maximumOrderQuantity)
        {
            IdentificationalNumber = identificationalNumber;
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