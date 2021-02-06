using GetSimple.WebAPI.Modelos;
using GetSimple.WebAPI.RegraDeNegocio;
using GetSimple.WebAPI.Seguranca;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GetSimple.WebAPI.AuthProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioNegocios _usuarioNegocios;

        public UsuarioController(UsuarioNegocios usuarioNegocios)
        {
            _usuarioNegocios = usuarioNegocios;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _usuarioNegocios.ValidaInformacoes(model);
                
                if (retorno != null)
                {
                    return Ok(retorno);
                }               
            }
            return BadRequest();
        }
    }
}
