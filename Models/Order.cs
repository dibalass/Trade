using System;
using System.Collections.Generic;

namespace Trade.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderStatus { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public int OrderPickupPoint { get; set; }

    public int Code { get; set; }

    public DateTime OrderDate { get; set; }

    public int UserId { get; set; }

    public virtual PickupPoint OrderPickupPointNavigation { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual OrderStatus OrderStatusNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
