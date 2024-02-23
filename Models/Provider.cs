﻿using System;
using System.Collections.Generic;

namespace Trade.Models;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string ProviderName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
