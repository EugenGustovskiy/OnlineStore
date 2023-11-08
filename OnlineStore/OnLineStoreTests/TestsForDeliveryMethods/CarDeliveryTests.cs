using OnlineStore.Core.DeliveryMethods;
using OnlineStore.Core.Orders;
using System.Text;

namespace OnLineStoreTests.TestsForDeliveryMethods
{
    [TestClass]
    public class CarDeliveryTests
    {
        public CarDelivery Car;
        public Order Order;
        public VIPOrder VIPOrder;
        public DiscountOrder DiscountOrder;

        [TestInitialize]
        public void Before()
        {
            Car = new("Artem", (byte)35, (byte)5, "9800KI3");
            Order = new("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
            VIPOrder = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");
            DiscountOrder = new("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("No name", (byte)35, (byte)5, "9800KI3")]
        [DataRow("", (byte)35, (byte)5, "9800KI3")]
        [DataRow(null, (byte)35, (byte)5, "9800KI3")]
        public void NegativeCarDeliveryNameTest(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string registrationNumber)
        {
            CarDelivery carNew = new(name, averageDeliveryTime, maximumOrderQuantity, registrationNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("Artem", (byte)35, (byte)5, "9800KI")]
        [DataRow("Artem", (byte)35, (byte)5, "9800KI30")]
        public void NegativeCarDeliveryRegistrationNumberTest(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string registrationNumber)
        {
            CarDelivery carNew = new(name, averageDeliveryTime, maximumOrderQuantity, registrationNumber);
        }

        [TestMethod]
        [DataRow(typeof(Order), 35)]
        [DataRow(typeof(VIPOrder), 25)]
        [DataRow(typeof(DiscountOrder), 35)]
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

            int actualResult = Car.ExpectedDeliveryTime(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(typeof(Order), 36)]
        [DataRow(typeof(VIPOrder), 26)]
        [DataRow(typeof(DiscountOrder), 36)]
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

            int actualResult = Car.ExpectedDeliveryTime(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreePositiveTest()
        {
            bool expectedResult = true;
            bool actualResult = Car.IsFree();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreeNegativeTest()
        {
            Car.MaximumOrderQuantity = 0;

            bool expectedResult = true;
            bool actualResult = Car.IsFree();

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

            bool actualResult = Car.DeliverOrder(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow(typeof(Order), true)]
        [DataRow(typeof(VIPOrder), true)]
        [DataRow(typeof(DiscountOrder), true)]
        public void DeliverOrderNegativeTest(Type orderType, bool expectedResult)
        {
            Car.MaximumOrderQuantity = 0;

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

            bool actualResult = Car.DeliverOrder(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }
    }   
}