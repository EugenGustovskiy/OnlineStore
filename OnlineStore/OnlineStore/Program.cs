using OnlineStore;

Order order1 = new ("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42");
Order order2 = new ("Phone Apple iPhone 14", 3079, 375298561972, "Minks, Kuntsevschina, 11, 32");
Order order3 = new ("Sony PlayStation 5", 2259, 375447412596, "Minks, Kuntsevschina, 11, 32");
VIPOrder vipOrder1 = new("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5");
DiscountOrder discountOrder1 = new("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10);

Order[] orders = { order1, order2, order3, vipOrder1, discountOrder1 };

//foreach (Order order in orders)
//{
//    Console.WriteLine(order.GetFullInformation());
//}

//foreach (Order order in orders)
//{
//    string customerNumberString = order.CustomerNumber.ToString();
//    if (customerNumberString.StartsWith("375"))
//    {
//        Console.WriteLine(order.GetFullInformation());
//    }
//}

//foreach (Order order in orders)
//{
//    if (order.ProductPrice < 2000 && order.ProductName.Contains("TV"))
//    {
//        Console.WriteLine(order.GetFullInformation());
//    }
//}


MyList<Order> listOrders = new MyList<Order>();
listOrders.Add(order1);
listOrders.Add(order2);
listOrders.Add(order3);
listOrders.Add(vipOrder1);
listOrders.Add(discountOrder1);

//int position = listOrders.FindPosition(order2);
//int amount = listOrders.AmountOfElements();
//Order element = listOrders.ReturnElement(0);
//listOrders.RemoveElement(discountOrder1);
listOrders.DisplayInformation(listOrders);


Console.WriteLine("eugen");