namespace ONIS.Data.Catalog.Entities;

public class CatalogType
{


    [Key]
    public int CatalogTypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    public CatalogType(ICollection<Product> products, string name)
    {
        Products = products;
        Name = name;
    }
}
