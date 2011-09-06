using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EFSample.Model
{
    public class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="El nombre es un dato requerido")]
        [StringLength(60)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es un dato requerido")]
        [StringLength(60)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El correo electrónico es un dato requerido")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public virtual ICollection<Post> Posts { get; set; }

        public override string ToString()
        {
            return string.Format("{0} <{1}>", FullName, Email);
        }
    }
}
