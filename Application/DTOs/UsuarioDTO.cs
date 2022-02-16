using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string Email { get; set; }
        [DisplayName("Telefone Pessoal")]
        public string TelefonePessoal { get; set; }
        [DisplayName("Telefone Comercial")]
        public string TelefoneComercial { get; set; }

        public IList<EmailDTO> Emails { get; set; }
    }
}
