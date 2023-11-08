using OnlineStore.Core.DeliveryMethods;
using OnlineStore.Core.Orders;

namespace OnLineStoreTests.TestsForAllOrders
{
    [TestClass]
    public class WalkingDeliveryTests
    {
        public WalkingDelivery WalkingDelivery;
        public Order Order;
        public VIPOrder VIPOrder;
        public DiscountOrder DiscountOrder;


        [TestInitialize]
        public void BeforeTest()
        {
            WalkingDelivery = new("Sergey", (byte)60, (byte)2);
            Order = new("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
            VIPOrder = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");
            DiscountOrder = new("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("No name", (byte)60, (byte)2)]
        [DataRow("", (byte)60, (byte)2)]
        [DataRow(null, (byte)60, (byte)2)]
        public void NegativeWalkingDeliveryNameTest(string name, byte averageDeliveryTime, byte maximumOrderQuantity)
        {
            WalkingDelivery walkingDeliveryNew = new(name, averageDeliveryTime, maximumOrderQuantity);
        }

        [TestMethod]
        public void ExpectedDeliveryTimeWithOrderPositiveTest()
        {
            int expectedResult = 60;
            int actualResult = WalkingDelivery.ExpectedDeliveryTime(Order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ExpectedDeliveryTimeWithOrderNegativeTest()
        {
            int expectedResult = 61;
            int actualResult = WalkingDelivery.ExpectedDeliveryTime(Order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ExpectedDeliveryTimeWithDiscountOrderPositiveTest()
        {
            int expectedResult = 60;
            int actualResult = WalkingDelivery.ExpectedDeliveryTime(DiscountOrder);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ExpectedDeliveryTimeWithDiscountOrderNegativeTest()
        {
            int expectedResult = 61;
            int actualResult = WalkingDelivery.ExpectedDeliveryTime(DiscountOrder);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ExpectedDeliveryTimeWithVIPOrderPositiveTest()
        {
            int expectedResult = 45;
            int actualResult = WalkingDelivery.ExpectedDeliveryTime(VIPOrder);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ExpectedDeliveryTimeWithVIPOrderNegativeTest()
        {
            int expectedResult = 60;
            int actualResult = WalkingDelivery.ExpectedDeliveryTime(VIPOrder);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreePositiveTest()
        {
            bool expectedResult = true;
            bool actualResult = WalkingDelivery.IsFree();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreeNegativeTest()
        {
            WalkingDelivery.MaximumOrderQuantity = 0;

            bool expectedResult = true;
            bool actualResult = WalkingDelivery.IsFree();

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

            bool actualResult = WalkingDelivery.DeliverOrder(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(typeof(Order), true)]
        [DataRow(typeof(VIPOrder), true)]
        [DataRow(typeof(DiscountOrder), true)]
        public void DeliverOrderNegativeTest(Type orderType, bool expectedResult)
        {
            WalkingDelivery.MaximumOrderQuantity = 0;

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

            bool actualResult = WalkingDelivery.DeliverOrder(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }
    }
}