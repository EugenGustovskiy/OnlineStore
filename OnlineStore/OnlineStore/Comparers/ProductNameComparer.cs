namespace OnlineStore.Comparers
{
    internal class ProductNameComparer : IComparer<Order>
    {
        //Increase
        public int Compare(Order? x, Order? y)
        {
            return x.ProductName.CompareTo(y.ProductName);
        }

        //Decreasing
        //public int Compare(Order? x, Order? y)
        //{
        //    return y.ProductName.CompareTo(x.ProductName);
        //}
    }
}