using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public EmailService(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        public async Task Add(EmailDTO emailDto)
        {
            var emailEntity = _mapper.Map<Email>(emailDto);
            await _emailRepository.CreateAsync(emailEntity);
        }

        public async Task<EmailDTO> GetById(int? id)
        {
            var emailEntity = await _emailRepository.GetByIdAsync(id);
            return _mapper.Map<EmailDTO>(emailEntity);
        }

        public async Task<IEnumerable<EmailDTO>> GetEmails()
        {
            var emailEntity = await _emailRepository.GetEmailsAsync();
            return _mapper.Map<IEnumerable<EmailDTO>>(emailEntity);
        }

        public async Task<EmailDTO> GetUsuario(int? id)
        {
            var emailEntity = await _emailRepository.GetUsuarioAsync(id);
            return _mapper.Map<EmailDTO>(emailEntity);
        }

        public async Task Remove(int? id)
        {
            var emailEntity = _emailRepository.GetByIdAsync(id).Result;
            await _emailRepository.RemoveAsync(emailEntity);
        }

        public async Task Update(EmailDTO emailDto)
        {
            var emailEntity = _mapper.Map<Email>(emailDto);
            await _emailRepository.UpdateAsync(emailEntity);
        }
    }
}