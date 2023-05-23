namespace ONIS.Data.Catalog.Entities;

public class CatalogBrand
{
    [Key]
    public int CatalogBrandId { get; set; }

    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    public CatalogBrand(ICollection<Product> products, string pname)
    {
        Products = products;
        Name = pname;
    }
}
