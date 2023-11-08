using OnlineStore.Core;
using OnlineStore.Core.DeliveryMethods;
using OnlineStore.Core.Orders;

namespace OnLineStoreTests
{
    [TestClass]
    public class DeliveryServiceTests
    {
        public DeliveryService Service;
        public List<Order> Orders = new List<Order>();
        public List<BaseDeliveryMethod> DeliveryMethods = new List<BaseDeliveryMethod>();
        public WalkingDelivery WalkingPerson;
        public MotorcycleDelivery Motorcycle;
        public CarDelivery Car;
        public DroneDelivery Drone;
        public Order Order;
        public VIPOrder VIPOrder;
        public DiscountOrder DiscountOrder;

        [TestInitialize]
        public void Before()
        {
            Service = new("UPS");

            WalkingPerson = new("Sergey", (byte)60, (byte)2);
            Motorcycle = new("Gleb", (byte)25, (byte)2, "3647MX5");
            Car = new("Artem", (byte)35, (byte)5, "9800KI3");
            Drone = new("Baby", (byte)20, (byte)1, "230796EG27");

            Order = new("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
            DiscountOrder = new("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10);
            VIPOrder = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("No company name")]
        [DataRow("")]
        [DataRow(null)]
        public void NegativeDeliveryServiceCompanyNameTest(string companyName)
        {
            DeliveryService ServiceNew = new(companyName);
        }

        [TestMethod]
        [DataRow(typeof(WalkingDelivery), true)]
        [DataRow(typeof(MotorcycleDelivery), true)]
        [DataRow(typeof(CarDelivery), true)]
        [DataRow(typeof(DroneDelivery), true)]
        public void AddDeliveryMethodPositiveTest(Type methodType, bool expectedResult)
        {
            BaseDeliveryMethod method = null;

            if (methodType == typeof(WalkingDelivery))
            {
                method = WalkingPerson;
            }
            else if (methodType == typeof(MotorcycleDelivery))
            {
                method = Motorcycle;
            }
            else if (methodType == typeof(CarDelivery))
            {
                method = Car;
            }
            else if (methodType == typeof(DroneDelivery))
            {
                method = Drone;
            }

            bool actualResult = Service.AddDeliveryMethod(method);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddDeliveryMethodNegativeTest()
        {
            BaseDeliveryMethod method = null;

            bool expectedResult = true;
            bool actualResult = Service.AddDeliveryMethod(method);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(typeof(Order), true)]
        [DataRow(typeof(VIPOrder), true)]
        [DataRow(typeof(DiscountOrder), true)]
        public void AddOrderPositiveTest(Type methodType, bool expectedResult)
        {
            Order order = null;

            if (methodType == typeof(Order))
            {
                order = Order;
            }
            else if (methodType == typeof(VIPOrder))
            {
                order = VIPOrder;
            }
            else if (methodType == typeof(DiscountOrder))
            {
                order = DiscountOrder;
            }

            bool actualResult = Service.AddOrder(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddOrderNegativeTest()
        {
            Order = null;

            bool expectedResult = true;
            bool actualResult = Service.AddOrder(Order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PriorityOfOrdersPositiveTest()
        {
            Service.AddOrder(Order);
            Service.AddOrder(VIPOrder);
            Service.AddOrder(DiscountOrder);

            Orders = Service._orders;

            List<Order> expectedResult = new List<Order> { VIPOrder, DiscountOrder, Order };
            List<Order> actualResult = Service.PriorityOfOrders(Orders);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PriorityOfOrdersNegativeTest()
        {
            Service.AddOrder(Order);
            Service.AddOrder(VIPOrder);
            Service.AddOrder(DiscountOrder);

            Orders = Service._orders;

            List<Order> expectedResult = new List<Order> { Order, VIPOrder, DiscountOrder };
            List<Order> actualResult = Service.PriorityOfOrders(Orders);

            CollectionAssert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GiveOrdersToDeliveryPositiveTest()
        {
            Service.AddOrder(Order);
            Service.AddOrder(VIPOrder);
            Service.AddOrder(DiscountOrder);

            Orders = Service._orders;

            Service.AddDeliveryMethod(WalkingPerson);
            Service.AddDeliveryMethod(Motorcycle);
            Service.AddDeliveryMethod(Car);
            Service.AddDeliveryMethod(Drone);

            DeliveryMethods = Service._deliveryMethods;

            bool expectedResult = true;
            bool actualResult = Service.GiveOrdersToDelivery();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        
        public void GiveOrdersToDeliveryNegativeNoOrdersTest()
        {
            Orders = Service._orders;

            Service.AddDeliveryMethod(WalkingPerson);
            Service.AddDeliveryMethod(Motorcycle);
            Service.AddDeliveryMethod(Car);
            Service.AddDeliveryMethod(Drone);

            DeliveryMethods = Service._deliveryMethods;

            bool expectedResult = true;
            bool actualResult = Service.GiveOrdersToDelivery();

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GiveOrdersToDeliveryNegativeNoDeliveryMethodsTest()
        {
            Service.AddOrder(Order);
            Service.AddOrder(VIPOrder);
            Service.AddOrder(DiscountOrder);

            Orders = Service._orders;

            DeliveryMethods = Service._deliveryMethods;

            bool expectedResult = true;
            bool actualResult = Service.GiveOrdersToDelivery();

            Assert.AreNotEqual(expectedResult, actualResult);
        }
    }
}