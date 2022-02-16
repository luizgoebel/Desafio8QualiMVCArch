using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Email : Entity
    {
        public string Endereco { get; private set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Email(string endereco)
        {
            Endereco = endereco;
            ValidateDomain(endereco);
        }
        //public Email(int id, string endereco)
        //{
        //    DomainExceptionValidation.When(id < 0, "Id inválido");
        //    Id = id;
        //    ValidateDomain(endereco);
        //}

        private void ValidateDomain(string endereco)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco), "Email inválido, email obrigatório");
        }

        public void Update(string endereco, int usuarioId)
        {
            ValidateDomain(endereco);
            UsuarioId = usuarioId;
        }
    }


}
