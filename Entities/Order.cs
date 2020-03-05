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
    }
}
