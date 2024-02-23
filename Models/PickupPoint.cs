using System;
using System.Collections.Generic;

namespace Trade.Models;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public string Index { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
