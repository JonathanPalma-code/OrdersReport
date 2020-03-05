using System;
using System.Collections.Generic;
using System.Text;
using OrderReport.Entities.Enums;

namespace OrderReport.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItem { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            OrderItem.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItem.Remove(item);
        }

        public double Total()
        {
            double result = 0;
            foreach (OrderItem orders in OrderItem)
            {
                result += orders.SubTotal();
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Ordered at: {Moment.ToString("dd/MM/yyyy HH:mm")}");
            result.AppendLine($"Order Status: {Status}");
            result.AppendLine($"Client: {Client}");
            result.AppendLine("Items ordered: ");
            foreach (OrderItem item in OrderItem)
            {
                result.AppendLine(item.ToString());
            }
            result.AppendLine($"Total Price: {Total().ToString("F2")}");
            return result.ToString();
        }
    }
}
