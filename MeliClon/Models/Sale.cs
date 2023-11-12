using System;
using System.Collections.Generic;

namespace MeliClon.Models;

public partial class Sale
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public int? IdClient { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<Concept> Concepts { get; set; } = new List<Concept>();

    public virtual Client? IdClientNavigation { get; set; }
}
