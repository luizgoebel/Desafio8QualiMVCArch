using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuarios();
        Task<UsuarioDTO> GetById(int? id);

        Task Add(UsuarioDTO usuarioDto);
        Task Update(UsuarioDTO usuarioDto);
        Task Remove(int? id);
    }
}
