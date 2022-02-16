using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmailService
    {
        Task<IEnumerable<EmailDTO>> GetEmails();
        Task<EmailDTO> GetById(int? id);

        Task<EmailDTO> GetUsuario(int? id);

        Task Add(EmailDTO emailDto);
        Task Update(EmailDTO emailDto);
        Task Remove(int? id);
    }
}
