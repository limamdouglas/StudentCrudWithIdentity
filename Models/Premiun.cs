using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentCrudWithIdentity.Models;

public class Premiun
{
    [Key]
    [DisplayName("Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o título do Premiun")]
    [StringLength(80, ErrorMessage = "O título deve conter até 80 caracteres.")]
    [MinLength(5, ErrorMessage = "O título deve conter pelo menos 5 caracteres.")]
    [DisplayName("Título")]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    [DisplayName("Início")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayName("Término")]
    public DateTime EndDate { get; set; }

    [DisplayName("Aluno")]
    [Required(ErrorMessage = "Aluno Inválido")]
    public int StudentId { get; set; }

    public Student? Student { get; set; }
}
