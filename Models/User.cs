using System.ComponentModel.DataAnnotations;

namespace Reddit.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}