using Desafio8QualiMVC.Infra.Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _context;

        public EmailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Email> CreateAsync(Email email)
        {
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();
            return email;

        }

        public async Task<Email> GetByIdAsync(int? id)
        {
            return await _context.Emails.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Email>> GetEmailsAsync()
        {
            return await _context.Emails.ToListAsync();
        }

        public async Task<Email> GetUsuarioAsync(int? id)
        {
            return await _context.Emails.Include(c => c.Usuario).SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Email> RemoveAsync(Email email)
        {
            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();
            return email;
        }

        public async Task<Email> UpdateAsync(Email email)
        {
            _context.Emails.Update(email);
            await _context.SaveChangesAsync();
            return email;
        }
    }
}
