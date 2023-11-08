using OnlineStore.Core.DeliveryMethods;
using OnlineStore.Core.Orders;

namespace OnlineStoreTests.TestsForDeliveryMethods
{
    [TestClass]
    public class WalkingDeliveryTests
    {
        public WalkingDelivery WalkingPerson;
        public Order Order;
        public VIPOrder VIPOrder;
        public DiscountOrder DiscountOrder;


        [TestInitialize]
        public void BeforeTest()
        {
            WalkingPerson = new("Sergey", (byte)60, (byte)2);
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
            WalkingDelivery walkingPersonNew = new(name, averageDeliveryTime, maximumOrderQuantity);
        }

        [TestMethod]
        [DataRow(typeof(Order), 60)]
        [DataRow(typeof(VIPOrder), 45)]
        [DataRow(typeof(DiscountOrder), 60)]
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

            int actualResult = WalkingPerson.ExpectedDeliveryTime(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(typeof(Order), 61)]
        [DataRow(typeof(VIPOrder), 46)]
        [DataRow(typeof(DiscountOrder), 61)]
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

            int actualResult = WalkingPerson.ExpectedDeliveryTime(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreePositiveTest()
        {
            bool expectedResult = true;
            bool actualResult = WalkingPerson.IsFree();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsFreeNegativeTest()
        {
            WalkingPerson.MaximumOrderQuantity = 0;

            bool expectedResult = true;
            bool actualResult = WalkingPerson.IsFree();

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

            bool actualResult = WalkingPerson.DeliverOrder(order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(typeof(Order), true)]
        [DataRow(typeof(VIPOrder), true)]
        [DataRow(typeof(DiscountOrder), true)]
        public void DeliverOrderNegativeTest(Type orderType, bool expectedResult)
        {
            WalkingPerson.MaximumOrderQuantity = 0;

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

            bool actualResult = WalkingPerson.DeliverOrder(order);

            Assert.AreNotEqual(expectedResult, actualResult);
        }
    }
}