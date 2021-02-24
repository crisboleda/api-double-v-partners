using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace double_v_partners.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "La longitud debe ser entre 5 - 45 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El username del usuario es obligatorio")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "La longitud debe ser entre 5 - 20 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El email del usuario es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es valido")]
        public string Email { get; set; }
    }
}
