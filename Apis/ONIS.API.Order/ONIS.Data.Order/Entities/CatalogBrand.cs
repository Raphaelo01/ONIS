using System.ComponentModel.DataAnnotations;

namespace ONIS.Data.Order.Entities;

public class CatalogBrand
{
    [Key]
    public int CatalogBrandId { get; set; }

    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Product> Products { get; set; }

}
