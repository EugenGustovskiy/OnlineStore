using OnlineStore.Core.Orders;

namespace OnlineStoreTests.TestsForAllOrders
{
    [TestClass]
    public class OrdersTests
    {
        public Order Order;
        public Order Order1;
        
        [TestInitialize]
        public void BeforeTest()
        {
            Order = new("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
            Order1 = new ("Sony PlayStation 5", 2259, 375447412596, "Minks, Ignatovskogo, 1, 17");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("", 1329, 375336746162, "Minks, Odintsova, 21, 42")]
        [DataRow("No name", 1329, 375336746162, "Minks, Odintsova, 21, 42")]
        [DataRow(null, 1329, 375336746162, "Minks, Odintsova, 21, 42")]
        public void NegativeOrderProductNameTest(string productName, float productPrice, long customerName, string deliveryAddress)
        {
            Order orderNew = new(productName, productPrice, customerName, deliveryAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("Xiaomi MI TV", -1, 375336746162, "Minks, Odintsova, 21, 42")]
        [DataRow("Xiaomi MI TV", 0, 375336746162, "Minks, Odintsova, 21, 42")]
        [DataRow("Xiaomi MI TV", 4001, 375336746162, "Minks, Odintsova, 21, 42")]
        public void NegativeOrderProductPriceTest(string productName, float productPrice, long customerName, string deliveryAddress)
        {
            Order orderNew = new(productName, productPrice, customerName, deliveryAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("Xiaomi MI TV", 1329, -1, "Minks, Odintsova, 21, 42")]
        [DataRow("Xiaomi MI TV", 1329, 37533674616, "Minks, Odintsova, 21, 42")]
        [DataRow("Xiaomi MI TV", 1329, 3753367461623, "Minks, Odintsova, 21, 42")]
        public void NegativeOrderCustomerNumberTest(string productName, float productPrice, long customerName, string deliveryAddress)
        {
            Order orderNew = new(productName, productPrice, customerName, deliveryAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("Xiaomi MI TV", 1329, 375336746162, "No address")]
        [DataRow("Xiaomi MI TV", 1329, 375336746162, "")]
        [DataRow("Xiaomi MI TV", 1329, 375336746162, null)]
        public void NegativeOrderDeliveryAddressTest(string? productName, float productPrice, long customerName, string deliveryAddress)
        {
            Order orderNew = new(productName, productPrice, customerName, deliveryAddress);
        }

        [TestMethod]
        public void OrderGetFullInformationPositiveTest()
        {
            string expectedResult = "Product name: Xiaomi MI TV, Product price: 1329 BYN, Customer number: +375336746162, Delivery address: Minks, Odintsova, 21, 42";
            string actualResult = Order.GetFullInformation();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OrderGetFullInformationNegativeTest()
        {
            string expectedResult = "Product name: Xiaomi MI TV,  Product price: 1329 BYN, Customer number: +375336746162, Delivery address: Minks, Odintsova, 21, 42";
            string actualResult = Order.GetFullInformation();

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OrderCompareToPositiveTest()
        {
            int expectedResult = 1;
            int actualResult = Order1.CompareTo(Order);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OrderCompareToNegativeTest()
        {
            int expectedResult = 1;
            int actualResult = Order.CompareTo(Order1);

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OrderEqualsPositiveTest()
        {
            Order orderNew = new("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");

            Assert.AreEqual(Order, orderNew);
        }

        [TestMethod]
        [DataRow("Xiaomi MI", 1329, 375336746162, "Minks, Odintsova, 21, 42")]
        [DataRow("Xiaomi MI TV", 1330, 375336746162, "Minks, Odintsova, 21, 42")]
        [DataRow("Xiaomi MI TV", 1329, 375336746163, "Minks, Odintsova, 21, 42")]
        [DataRow("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 41")]
        public void OrderEqualsNegativeTest(string productName, float productPrice, long customerName, string deliveryAddress)
        {
            Order orderNew = new(productName, productPrice, customerName, deliveryAddress);

            Assert.AreNotEqual(Order, orderNew);
        }
    }
}