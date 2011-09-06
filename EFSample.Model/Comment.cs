using System;
using System.ComponentModel.DataAnnotations;

namespace EFSample.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User User { get; set; }
        public virtual int? UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(1024)]
        public string Text { get; set; }

        [Required]
        public virtual Post CommentOnPost { get; set; }
    }
}
