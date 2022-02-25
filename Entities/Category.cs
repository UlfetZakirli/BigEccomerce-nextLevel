namespace Entities
{
    public class Category:BaseEntity
    {
        public int? ParentCategoryID { get; set; }
        public virtual Category? ParentCategory { get; set; }
        public bool IsFeatured { get; set; }
        public string SanitizedName { get; set; }
        public int DisplaySeqNo { get; set; }

        public int? PictureID { get; set; }
        public virtual Picture? Picture { get; set; }
        public virtual List<Product>? Products { get; set; }
        public virtual List<CategoryRecord> CategoryRecords { get; set; }=null!;

    }
    public class CategoryRecord : BaseEntity
    {
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int LanguageID { get; set; }

        public string Name { get; set; } = null!;
        public string? Summary { get; set; }
        public string? Description { get; set; }
    }
}
