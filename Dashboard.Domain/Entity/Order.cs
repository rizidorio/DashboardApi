using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeliveryDate { get; private set; }
        public int? DeliveryTeamId { get; private set; }
        public DeliveryTeam DeliveryTeam { get; set; }
        public decimal TotalValue { get; private set; }

        public IEnumerable<ItemsOrder> ItemsOrders { get; set; }

        public Order(string address, DateTime? deliveryDate, int? deliveryTeamId, decimal totalValue)
        {
            Address = address;
            CreatedAt = DateTime.Now;
            DeliveryDate = deliveryDate;
            DeliveryTeamId = deliveryTeamId;
            TotalValue = totalValue;
        }

        public void Update(string address, DateTime? deliveryDate, int? deliveryTeamId, decimal totalValue)
        {
            Address = address;
            DeliveryDate = deliveryDate;
            DeliveryTeamId = deliveryTeamId;
            TotalValue = totalValue;
        }
    }
}
