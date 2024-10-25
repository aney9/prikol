﻿using System;
using System.Collections.Generic;

namespace P50_4_22.Models;

public partial class CatalogProduct
{
    public int IdCatalogproducts { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal PriceOfProduct { get; set; }

    public string DescriptionProduct { get; set; } = null!;

    public string Img { get; set; } = null!;

    public int BrandsId { get; set; }

    public int CategoriesId { get; set; }

    public virtual Brand Brands { get; set; } = null!;

    public virtual Category Categories { get; set; } = null!;

    public virtual ICollection<PosOrder> PosOrders { get; set; } = new List<PosOrder>();
}
