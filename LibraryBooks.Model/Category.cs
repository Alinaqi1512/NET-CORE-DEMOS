using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryBooks.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Orders can be within 1 and 100!!")]
        public int Orders { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

    }
}
