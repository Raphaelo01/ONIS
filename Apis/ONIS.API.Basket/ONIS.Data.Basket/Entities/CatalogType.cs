﻿using System.ComponentModel.DataAnnotations;

namespace ONIS.Data.Basket.Entities;

public class CatalogType
{
    [Key]
    public int CatalogTypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }


}
