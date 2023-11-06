using OnlineStore.Core;
using OnlineStore.Core.Orders;

DeliveryService ups = new("UPS");

ups.AddOrder(new Order("Xiaomi MI TV", 1329, 375336746162, "Minks, Odintsova, 21, 42"));
ups.AddOrder(new Order("Phone Apple iPhone 14", 3079, 375298561972, "Minks, Kuntsevschina, 11, 32"));
ups.AddOrder(new Order("Sony PlayStation 5", 2259, 375447412596, "Minks, Kuntsevschina, 11, 32"));
ups.AddOrder(new Order("Phone Apple iPhone 14", 3079, 375447853618, "Minks, Panchenko, 148, 2"));
ups.AddOrder(new VIPOrder("Phone Honor 90", 1599, 375295963418, "Minks, Ponomarenko, 9, 4", "Honor Choice Earbuds X5"));
ups.AddOrder(new DiscountOrder("Phone Huawei Mate 50 Pro", 2699, 375334287626, "Minks, Kamennogorskaya, 138, 98", 10));
ups.AddOrder(new DiscountOrder("Phone Huawei Mate 50 Pro", 2699, 375444697523, "Minks, Leshchinskogo, 3, 54", 10));

Console.WriteLine(ups.GiveOrdersToDelivery());