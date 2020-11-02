using CST.Core.DomainObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace CST.Produtos.API.Models
{
    public class Produto : Entity, IAggregateRoot
    {        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0.1, 1000000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} R$.")]
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Imagem { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, 999, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} R$.")]
        public int QuantidadeEstoque { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CategoriaId { get; set; }
    }
}