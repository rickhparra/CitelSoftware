using CST.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace CST.Categoria.API.Models
{
    public class Categorias : Entity, IAggregateRoot
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }
    }
}