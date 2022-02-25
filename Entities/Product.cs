using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product:BaseEntity
    {
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsDay { get; set; }
        public bool IsSlider { get; set; }
        public int CoverPhotoId { get; set; }
        public decimal? Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CategoryId { get; set; }
        public ushort InStock { get; set; }
        public virtual List<ProductRecord> ProductRecords { get; set; }
        public virtual List<ProductPicture> ProductPictures { get; set; }

        public virtual Category Category { get; set; }
    }

    public class ProductRecord : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public int LanguageId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
