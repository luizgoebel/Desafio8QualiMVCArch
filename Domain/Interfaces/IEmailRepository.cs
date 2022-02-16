using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmailRepository
    {
        Task<IEnumerable<Email>> GetEmailsAsync();
        Task<Email> GetByIdAsync(int? id);

        Task<Email> GetUsuarioAsync(int? id);

        Task<Email> CreateAsync(Email email);
        Task<Email> UpdateAsync(Email email);
        Task<Email> RemoveAsync(Email email);
    }
}
