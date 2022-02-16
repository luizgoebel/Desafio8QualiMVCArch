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
    public class EmailDTO
    {
        public int Id { get; set; }
        public string Endereco { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public IList<Email> Emails { get; set; }
    }
}
