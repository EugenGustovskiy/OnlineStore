using OnlineStore.Core.Orders;

namespace OnlineStore.Core.DeliveryMethods
{
    public class CarDelivery : BaseDeliveryMethod
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
                if(value.Length != 7 || value == null)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _registrationNumber = value;
            }
        }

        public CarDelivery(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string registrationNubmer) :
                      base(name, averageDeliveryTime, maximumOrderQuantity)
        {
            RegistrationNumber = registrationNubmer;
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