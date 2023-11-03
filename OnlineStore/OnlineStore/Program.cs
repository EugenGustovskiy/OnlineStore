using OnlineStore;
using OnlineStore.Comparers;

Order order1 = new ("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
Order order2 = new ("Phone Apple iPhone 14", 3079, 375298561972, "Minks, Kuntsevschina, 11, 32");
Order order3 = new ("Sony PlayStation 5", 2259, 375447412596, "Minks, Kuntsevschina, 11, 32");
Order order4 = new("Phone Apple iPhone 14", 3079, 375447853618, "Minks, Panchenko, 148, 2");
VIPOrder vipOrder1 = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");
VIPOrder vipOrder2 = new("Phone Honor 90", 1599, 375336472145, "Minks, Pushkina, 119, 94", "Honor Choice Earbuds X5");
DiscountOrder discountOrder1 = new("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10);
DiscountOrder discountOrder2 = new("Phone Huawei Mate 50 Pro", 2699, 375444697523, "Minks, Leshchinskogo, 3, 54", 10);

List<Order> orders = new() { order1, order2, order3, order4, vipOrder1, vipOrder2, discountOrder1, discountOrder2 };

ProductPriceComparer productPriceComparer = new ProductPriceComparer();
ProductNameComparer productNameComparer = new ProductNameComparer();
DeliveryAddressComparer deliveryAddressComparer = new DeliveryAddressComparer();

orders.Sort(deliveryAddressComparer);

foreach (Order order in orders)
{
    Console.WriteLine(order.GetFullInformation());
} 