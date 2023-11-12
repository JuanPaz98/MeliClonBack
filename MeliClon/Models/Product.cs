using System;
using System.Collections.Generic;

namespace MeliClon.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public string Category { get; set; } = null!;

    public string? UrlImage { get; set; }

    public decimal Cost { get; set; }

    public int Count { get; set; }

    public virtual ICollection<Concept> Concepts { get; set; } = new List<Concept>();
}
