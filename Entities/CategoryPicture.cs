namespace Entities
{
    public class CategoryPicture : BaseEntity
    {
        public int CategoryID { get; set; }

        public int PictureID { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
