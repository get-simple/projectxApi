using GetSimple.WebAPI.Modelos;
using GetSimple.WebAPI.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetSimple.WebAPI.RegraDeNegocio
{
    public class UsuarioNegocios
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        public UsuarioNegocios(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public async Task<Usuario> ValidaInformacoes(RegisterModel model)
        {
            var usuario = await _usuarioRepositorio.IncluirDbContext(model);
            return usuario;
        } 
    }
}
