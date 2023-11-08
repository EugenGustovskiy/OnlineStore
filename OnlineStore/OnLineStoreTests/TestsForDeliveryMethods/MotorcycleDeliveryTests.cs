using OnlineStore.Core.DeliveryMethods;
using OnlineStore.Core.Orders;

namespace OnlineStoreTests.TestsForDeliveryMethods
{
    [TestClass]
    public class MotorcycleDeliveryTests
    {
        public MotorcycleDelivery Motorcycle;
        public Order Order;
        public VIPOrder VIPOrder;
        public DiscountOrder DiscountOrder;


        [TestInitialize]
        public void BeforeTest()
        {
            Motorcycle = new("Gleb", (byte)25, (byte)2, "3647MX5");
            Order = new("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
            VIPOrder = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");
            DiscountOrder = new("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("No name", (byte)25, (byte)2, "3647MX5")]
        [DataRow("", (byte)25, (byte)2, "3647MX5")]
        [DataRow(null, (byte)25, (byte)2, "3647MX5")]
        public void NegativeMotorcycleDeliveryNameTest(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string registrationNumber)
        {
            MotorcycleDelivery motorcycleNew = new(name, averageDeliveryTime, maximumOrderQuantity, registrationNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("Gleb", (byte)25, (byte)2, "3647MX")]
        [DataRow("Gleb", (byte)25, (byte)2, "3647MX57")]
        public void NegativeMotorcycleDeliveryRegistrationNumberTest(string name, byte averageDeliveryTime, byte maximumOrderQuantity, string registrationNumber)
        {
            MotorcycleDelivery motorcycleNew = new(name, averageDeliveryTime, maximumOrderQuantity, registrationNumber);
        }

        [TestMethod]
        [DataRow(typeof(Order), 25)]
        [DataRow(typeof(VIPOrder), 15)]
        [DataRow(typeof(DiscountOrder), 25)]
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

            int actualResult = Motorcycle.ExpectedDeliveryTime(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(typeof(Order), 26)]
        [DataRow(typeof(VIPOrder), 16)]
        [DataRow(typeof(DiscountOrder), 26)]
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

            int actualResult = Motorcycle.ExpectedDeliveryTime(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreePositiveTest()
        {
            bool expectedResult = true;
            bool actualResult = Motorcycle.IsFree();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreeNegativeTest()
        {
            Motorcycle.MaximumOrderQuantity = 0;
            
            bool expectedResult = true;
            bool actualResult = Motorcycle.IsFree();

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

            bool actualResult = Motorcycle.DeliverOrder(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow(typeof(Order), true)]
        [DataRow(typeof(VIPOrder), true)]
        [DataRow(typeof(DiscountOrder), true)]
        public void DeliverOrderNegativeTest(Type orderType, bool expectedResult)
        {
            Motorcycle.MaximumOrderQuantity = 0;

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

            bool actualResult = Motorcycle.DeliverOrder(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }
    }
}
