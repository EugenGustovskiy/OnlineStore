using OnlineStore.Core.DeliveryMethods;
using OnlineStore.Core.Orders;

namespace OnlineStore.Core
{
    public class DeliveryService
    {
        private string _companyName;
        public string CompanyName 
        { 
            get
            {
                return _companyName;
            }
            set
            {
                if (value == "No company name" || value == "" || value == null)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }
                _companyName = value;
            } 
        }
        public List<Order> _orders = new List<Order>();
        public List<BaseDeliveryMethod> _deliveryMethods = new List<BaseDeliveryMethod>();

        public DeliveryService(string companyName)
        {
            CompanyName = companyName;
        }

        public bool AddDeliveryMethod(BaseDeliveryMethod method)
        {
            if (method != null)
            {
                _deliveryMethods.Add(method);
                return true;
            }
            return false;
        }

        public bool AddOrder(Order order)
        {
            if (order != null)
            {
                _orders.Add(order);
                return true;
            }
            return false;
        }

        public List<Order> PriorityOfOrders(List<Order> _orders)
        {
            var vipOrders = _orders.Where(x => x is VIPOrder).OrderByDescending(x => x.ProductPrice).ToList();

            _orders = _orders.Except(vipOrders).ToList();

            _orders = _orders.OrderByDescending(order => order.ProductPrice).ToList();

            return _orders = vipOrders.Concat(_orders).ToList();
        }

        public bool GiveOrdersToDelivery()
        {
            if (_orders.Count == 0 || _deliveryMethods.Count == 0)
            {
                return false;
            }

            _orders = PriorityOfOrders(_orders);

            for (int i = 0; i < _orders.Count; i++)
            {
                var order = _orders[i];
                var fastestDeliveryMethod = _deliveryMethods.Where(x => x.IsFree())
                                                            .OrderBy(x => x.AverageDeliveryTime)
                                                            .FirstOrDefault();

                if (fastestDeliveryMethod != null)
                {
                    bool delivered = fastestDeliveryMethod.DeliverOrder(order);
                    if (delivered)
                    {
                        Console.WriteLine($"Order for {order.ProductName} delivered by {fastestDeliveryMethod.Name} using {fastestDeliveryMethod.GetType().Name}");
                        _orders.RemoveAt(i);
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine($"Order for {order.ProductName} could not be delivered (no available couriers).");
                }
            }

            return true;
        }
    }
}