using System;
using OrderReport.Entities;
using OrderReport.Entities.Enums;

namespace OrderReport
{
    class Print
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Client details:");
            Console.Write("Full Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birthdate (DD/MM/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthdate);

            Console.WriteLine("\nEnter the Order details:");
            Console.Write("Status (PendindPayment/Processing/Shipped/Delivered: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order: ");
            int nOrders = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            for (int i = 1; i <= nOrders; i++)
            {
                Console.WriteLine($"Enter the details number {i}:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Pruduct price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Product product = new Product(productName, price);
                OrderItem orderItem = new OrderItem(quantity, price, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine(order);
            foreach (OrderItem totalOrder in order.OrderItem)
            {
                Console.WriteLine($"{totalOrder.Product.Name}, " +
                    $"{totalOrder.Price}, " +
                    $"Quantity: {totalOrder.Quantity}, " +
                    $"Subtotal: {totalOrder.SubTotal()}");
            }
            Console.WriteLine($"\nTotal Price: {order.Total()}");
        }
    }
}
