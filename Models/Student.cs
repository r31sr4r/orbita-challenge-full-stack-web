using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace orbita_challenge_full_stack_web.Models
{
    [Table("tb_students")]
    public class Student
    {

        #region Properties

        [Column("id")]
        [Key]
        public int Id { get; set; }
        
        [Column("name", TypeName = "varchar")]
        [Required]
        [MaxLength(250)]
        public string? Name { get; set; }        
        
        [Column("cpf", TypeName = "varchar")]
        [Required]
        [MaxLength(14)]
        public string? CPF { get; set; } 
       
        [Column("email", TypeName = "varchar")]
        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }

        #endregion

    }
}