using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFSample.Model
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User User { get; set; }
        public virtual int? UserId { get; set; }
        
        [Required(ErrorMessage="La fecha es un dato requerido")]
        public DateTime PostDate { get; set; }

        [Required(ErrorMessage="El texto del post es un dato requerido")]
        public string Text { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
