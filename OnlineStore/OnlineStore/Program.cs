using OnlineStore;

Order order1 = new ("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
Order order2 = new ("Apple iPhone 14", 3079, 375298561972, "Minks, Kuntsevschina, 11, 32");
Order order3 = new ("Sony PlayStation 5", 2259, 375447412596, "Minks, Kuntsevschina, 11, 32");

Order[] orders = { order1, order2, order3 };

foreach (Order order in orders)
{
    Console.WriteLine(order.GetFullInformation());
}