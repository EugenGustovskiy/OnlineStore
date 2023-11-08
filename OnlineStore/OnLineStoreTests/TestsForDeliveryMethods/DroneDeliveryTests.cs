using OnlineStore.Core.DeliveryMethods;
using OnlineStore.Core.Orders;

namespace OnLineStoreTests.TestsForDeliveryMethods
{
    [TestClass]
    public class DroneDeliveryTests
    {
        public DroneDelivery Drone;
        public Order Order;
        public VIPOrder VIPOrder;
        public DiscountOrder DiscountOrder;

        [TestInitialize]
        public void BeforeTest()
        {
            Drone = new("Baby", (byte)20, (byte)1, "230796EG27");
            Order = new("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
            VIPOrder = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");
            DiscountOrder = new("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("No name", (byte)20, (byte)1, "230796EG27")]
        [DataRow("", (byte)20, (byte)1, "230796EG27")]
        [DataRow(null, (byte)20, (byte)1, "230796EG27")]
        public void NegativeDroneDeliveryNameTest(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string identificationalNumber)
        {
            DroneDelivery droneNew = new(name, averageDeliveryTime, maximumOrderQuantity, identificationalNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("Baby", (byte)20, (byte)1, "230796EG2")]
        [DataRow("Baby", (byte)20, (byte)1, "230796EG270")]
        public void NegativeDroneDeliveryIdentificationalNumberTest(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string identificationalNumber)
        {
            DroneDelivery droneNew = new(name, averageDeliveryTime, maximumOrderQuantity, identificationalNumber);
        }

        [TestMethod]
        [DataRow(typeof(Order), 20)]
        [DataRow(typeof(VIPOrder), 10)]
        [DataRow(typeof(DiscountOrder), 20)]
        public void ExpectedDeliveryTimePositiveTest(Type orderType, int expectedResult)
        {
            Order order = null;

            if (orderType == typeof(Order))
            {
                order = Order;
            }
            else if (orderType == typeof(VIPOrder))
            {
                order = VIPOrder;
            }
            else if (orderType == typeof(DiscountOrder))
            {
                order = DiscountOrder;
            }

            int actualResult = Drone.ExpectedDeliveryTime(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(typeof(Order), 21)]
        [DataRow(typeof(VIPOrder), 11)]
        [DataRow(typeof(DiscountOrder), 21)]
        public void ExpectedDeliveryTimeNegativeTest(Type orderType, int expectedResult)
        {
            Order order = null;

            if (orderType == typeof(Order))
            {
                order = Order;
            }
            else if (orderType == typeof(VIPOrder))
            {
                order = VIPOrder;
            }
            else if (orderType == typeof(DiscountOrder))
            {
                order = DiscountOrder;
            }

            int actualResult = Drone.ExpectedDeliveryTime(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreePositiveTest()
        {
            bool expectedResult = true;
            bool actualResult = Drone.IsFree();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreeNegativeTest()
        {
            Drone.MaximumOrderQuantity = 0;

            bool expectedResult = true;
            bool actualResult = Drone.IsFree();

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow(typeof(Order), true)]
        [DataRow(typeof(VIPOrder), true)]
        [DataRow(typeof(DiscountOrder), true)]
        public void DeliverOrderPositiveTest(Type orderType, bool expectedResult)
        {
            Order order = null;

            if (orderType == typeof(Order))
            {
                order = Order;
            }
            else if (orderType == typeof(VIPOrder))
            {
                order = VIPOrder;
            }
            else if (orderType == typeof(DiscountOrder))
            {
                order = DiscountOrder;
            }

            bool actualResult = Drone.DeliverOrder(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow(typeof(Order), true)]
        [DataRow(typeof(VIPOrder), true)]
        [DataRow(typeof(DiscountOrder), true)]
        public void DeliverOrderNegativeTest(Type orderType, bool expectedResult)
        {
            Drone.MaximumOrderQuantity = 0;

            Order order = null;

            if (orderType == typeof(Order))
            {
                order = Order;
            }
            else if (orderType == typeof(VIPOrder))
            {
                order = VIPOrder;
            }
            else if (orderType == typeof(DiscountOrder))
            {
                order = DiscountOrder;
            }

            bool actualResult = Drone.DeliverOrder(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }
    }
}