namespace Bloggie.Areas.Admin.Models
{
    public class EditPostViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsDraft { get; set; } = false;
    }
}
