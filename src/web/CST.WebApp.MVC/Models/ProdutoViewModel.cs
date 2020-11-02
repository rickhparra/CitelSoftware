using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CST.WebApp.MVC.Models
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        [DisplayName("Valor (R$)")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0.1, 1000000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} R$.")]
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }

        [DisplayName("Link da imagem (URL)")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Imagem { get; set; }

        [DisplayName("Quantidade Estoque")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, 999, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} R$.")]
        public int QuantidadeEstoque { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CategoriaId { get; set; }

        public virtual CategoriaViewModel Categoria { get; set; }
    }
}