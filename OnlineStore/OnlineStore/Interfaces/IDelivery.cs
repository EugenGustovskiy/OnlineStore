using OnlineStore.Core.Orders;

namespace OnlineStore.Interfaces
{
    public interface IDelivery
    {
        public bool DeliverOrder(Order order);
        public int ExpectedDeliveryTime(Order order);
    }
}