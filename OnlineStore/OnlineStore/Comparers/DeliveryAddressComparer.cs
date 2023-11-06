using OnlineStore.Core.Orders;

namespace OnlineStore.Comparers
{
    internal class DeliveryAddressComparer : IComparer<Order>
    {
        //Increase
        public int Compare(Order? x, Order? y)
        {
            return x.DeliveryAddress.CompareTo(y.DeliveryAddress);
        }

        //Decreasing
        //public int Compare(Order? x, Order? y)
        //{
        //    return y.DeliveryAddress.CompareTo(x.DeliveryAddress);
        //}
    }
}