using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Empresa { get; private set; }
        public string Email { get; private set; }
        public string TelefonePessoal { get; private set; }
        public string TelefoneComercial { get; private set; }

        public ICollection<Email> Emails { get; set; }

        private void ValidateDomain(string nome, string empresa, string email, string telefonePessoal, string telefoneComercial)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
               "Nome inválido, Nome é obrigatório");

            Nome = nome;
            Empresa = empresa;
            Email = email;
            TelefonePessoal = telefonePessoal;
            TelefoneComercial = telefoneComercial;
        }

        public Usuario(int id, string nome, string empresa, string email, string telefonePessoal, string telefoneComercial)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(nome, empresa, email, telefonePessoal, telefoneComercial);
        }

        public void Update(string nome, string empresa, string email, string telefonePessoal, string telefoneComercial)
        {
            ValidateDomain(nome, empresa, email, telefonePessoal, telefoneComercial);
        }
    }
}
