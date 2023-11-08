using OnlineStore.Core.Orders;

namespace OnlineStoreTests.TestsForAllOrders
{
    [TestClass]
    public class DiscountOrdersTests
    {
        public DiscountOrder DiscountOrder;

        [TestInitialize]
        public void BeforeTest()
        {
            DiscountOrder = new("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 0)]
        [DataRow("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", -1)]
        [DataRow("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 21)]
        public void NegativeDiscountOrderPresentTest(string productName, float productPrice, long customerName, string deliveryAddress, float discount)
        {
            DiscountOrder discountOrderNew = new(productName, productPrice, customerName, deliveryAddress, discount);
        }

        [TestMethod]
        public void DiscountOrderGetFullInformationPositiveTest()
        {
            string expectedResult = "Product name: Phone Huawei Mate 50 Pro, Product price: 2699 BYN, Customer number: +375334287626, Delivery address: Minks, Kamennogorskaya, 138, 98, Discount: 10%";
            string actualResult = DiscountOrder.GetFullInformation();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DiscountOrderGetFullInformationNegativeTest()
        {
            string expectedResult = "Product name:  Phone Huawei Mate 50 Pro, Product price: 2699 BYN, Customer number: +375334287626, Delivery address: Minks, Kamennogorskaya, 138, 98, Discount: 10%";
            string actualResult = DiscountOrder.GetFullInformation();

            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow("Phone Huawei Mate 50", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10)]
        [DataRow("Phone Huawei Mate 50 Pro", 2700, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10)]
        [DataRow("Phone Huawei Mate 50 Pro", 2699, 375334287627, "Minks, Kamennogorskaya, 138, 98", 10)]
        [DataRow("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 100", 10)]
        [DataRow("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 15)]
        public void DiscountOrderEqualsNegativeTest(string productName, float productPrice, long customerName, string deliveryAddress, float discountt)
        {
            DiscountOrder discountOrderNew = new(productName, productPrice, customerName, deliveryAddress, discountt);

            Assert.AreNotEqual(DiscountOrder, discountOrderNew);
        }
    }
}