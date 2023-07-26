using System;
using System.Collections.Generic;

namespace di_cors_demo.Models.EF;

public partial class Order
{
    public int OId { get; set; }

    public string? OType { get; set; }

    public string? OStatus { get; set; }
}
