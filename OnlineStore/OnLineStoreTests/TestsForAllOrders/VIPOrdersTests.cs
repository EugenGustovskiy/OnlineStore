using OnlineStore.Core.Orders;

namespace OnLineStoreTests.TestsForAllOrders
{
    [TestClass]
    public class VIPOrdersTests
    {
        public VIPOrder VIPOrder;

        [TestInitialize]
        public void BeforeTest()
        {
            VIPOrder = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "No name present")]
        [DataRow("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "")]
        [DataRow("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", null)]
        public void NegativeVIPOrderPresentTest(string productName, float productPrice, long customerName, string deliveryAddress, string present)
        {
            VIPOrder vipOrderNew = new(productName, productPrice, customerName, deliveryAddress, present);
        }

        [TestMethod]
        public void VIPOrderGetFullInformationPositiveTest()
        {
            string expectedResult = "Product name: Phone Honor 90, Product price: 1599 BYN, Customer number: +375295963418, Delivery address: Minks, Ponomarenko, 9, 4, Present: Honor Choice Earbuds X5";
            string actualResult = VIPOrder.GetFullInformation();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void VIPOrderGetFullInformationNegativeTest()
        {
            string expectedResult = "Product name:  Phone Honor 90, Product price: 1599 BYN, Customer number: +375295963418, Delivery address: Minks, Ponomarenko, 9, 4, Present: Honor Choice Earbuds X5";
            string actualResult = VIPOrder.GetFullInformation();

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void VIPOrderEqualsPositiveTest()
        {
            VIPOrder vipOrderNew = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");

            Assert.AreEqual(VIPOrder, vipOrderNew);
        }

        [TestMethod]
        [DataRow("Phone Honor", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5")]
        [DataRow("Phone Honor 90", 1600, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5")]
        [DataRow("Phone Honor 90", 1599, 375295963419, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5")]
        [DataRow("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 5", "Honor Choice Earbuds X5")]
        [DataRow("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds")]
        public void VIPOrderEqualsNegativeTest(string productName, float productPrice, long customerName, string deliveryAddress, string present)
        {
            VIPOrder orderNew = new(productName, productPrice, customerName, deliveryAddress, present);

            Assert.AreNotEqual(VIPOrder, orderNew);
        }
    }
}