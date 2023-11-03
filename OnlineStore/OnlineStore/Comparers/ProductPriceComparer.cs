namespace OnlineStore.Comparers
{
    internal class ProductPriceComparer : IComparer<Order>
    {
        //Increase
        public int Compare(Order? x, Order? y)
        {
            if (x.ProductPrice < y.ProductPrice)
            {
                return -1;
            }
            else if (x.ProductPrice > y.ProductPrice)
            {
                return 1;
            }

            return 0;
        }

        //Decreasing
        //public int Compare(Order? x, Order? y)
        //{
        //    if (y.ProductPrice < x.ProductPrice)
        //    {
        //        return -1;
        //    }
        //    else if (y.ProductPrice > x.ProductPrice)
        //    {
        //        return 1;
        //    }

        //    return 0;
        //}
    }
}