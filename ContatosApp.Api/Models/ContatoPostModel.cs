using ContatosApp.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContatosApp.Api.Models
{
    public class ContatoPostModel
    {
        private Guid? _id;
        private string _nome;
        private string _email;
        private string _telefone;

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do contato.")]
        public string Nome { get => _nome; set => _nome = value; }
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do contato.")]
        public string Email { get => _email; set => _email = value; }
        [RegularExpression(@"\(\d{2}\)\s\d{5}-\d{4}", ErrorMessage = "Por favor, informe um telefone no formato: '(99) 99999-9999'.")]
        [Required(ErrorMessage = "Por favor, informe o telefone do contato.")]

        public string Telefone { get => _telefone; set => _telefone = value; }
        public Guid? Id { get => _id; set => _id = value; }
    }
}
