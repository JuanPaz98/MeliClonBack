using System;
using System.Collections.Generic;

namespace MeliClon.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int Idproduct { get; set; }

    public string? UrlImage { get; set; }

    public virtual Product IdproductNavigation { get; set; } = null!;
}
