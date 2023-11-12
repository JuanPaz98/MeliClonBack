using System;
using System.Collections.Generic;

namespace MeliClon.Models;

public partial class Concept
{
    public long Id { get; set; }

    public long IdSale { get; set; }

    public int Count { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Amount { get; set; }

    public int IdProduct { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Sale IdSaleNavigation { get; set; } = null!;
}
