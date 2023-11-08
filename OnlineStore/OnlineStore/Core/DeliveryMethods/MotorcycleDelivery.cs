using OnlineStore.Core.Orders;

namespace OnlineStore.Core.DeliveryMethods
{
    public class MotorcycleDelivery : BaseDeliveryMethod
    {
        private string _registrationNumber;

        public string RegistrationNumber
        {
            get
            {
                return _registrationNumber;
            }
            set
            {
                if (value.Length != 7)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _registrationNumber = value;
            }
        }

        public MotorcycleDelivery(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string registrationNumber) :
                             base(name, averageDeliveryTime, maximumOrderQuantity)
        {
            RegistrationNumber = registrationNumber;
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