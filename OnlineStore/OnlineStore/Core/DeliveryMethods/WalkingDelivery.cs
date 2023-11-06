using OnlineStore.Core.Orders;

namespace OnlineStore.Core.DeliveryMethods
{
    public class WalkingDelivery : BaseDeliveryMethod
    {
        public WalkingDelivery(string name, int averageDeliveryTime, int maximumOrderQuantity) :
                          base(name, averageDeliveryTime, maximumOrderQuantity)
        { }

        public override int ExpectedDeliveryTime(Order order)
        {
            if (order is VIPOrder)
            {
                return AverageDeliveryTime - 15;
            }
            return AverageDeliveryTime;
        }
    }
}