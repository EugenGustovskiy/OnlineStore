using OnlineStore.Core.Orders;

namespace OnlineStore.Core.DeliveryMethods
{
    public class DroneDelivery : BaseDeliveryMethod
    {
        private string _identificationalNumber;

        public string IdentificationalNumber
        {
            get
            {
                return _identificationalNumber;
            }
            set
            {
                if(value.Length != 10 || value == null)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _identificationalNumber = value;
            }
        }

        public DroneDelivery(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string identificationalNumber) :
                        base(name, averageDeliveryTime, maximumOrderQuantity)
        {
            IdentificationalNumber = identificationalNumber;
        }

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