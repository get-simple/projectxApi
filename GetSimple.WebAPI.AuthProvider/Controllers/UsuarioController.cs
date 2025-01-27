﻿using GetSimple.WebAPI.Modelos;
using GetSimple.WebAPI.RegraDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace GetSimple.WebAPI.AuthProvider.Controllers
{

    [Route("api/Usuario/")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioNegocios _usuarioNegocios;

        public UsuarioController(UsuarioNegocios usuarioNegocios)
        {
            _usuarioNegocios = usuarioNegocios;
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Registra um novo usuário na base.")]
        [ProducesResponseType(statusCode: 200, Type = typeof(Usuario))]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Incluir([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _usuarioNegocios.RegrasParaIncluir(model);
                
                if (retorno != null)
                {
                    return Ok(retorno);
                }               
            }
            return BadRequest();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetUsername/{username}")]
        public async Task<IActionResult> GetUsername(string username)
        {
            var response = await _usuarioNegocios.QueryUsername(username);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta o usuário da base pelo ID.")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Deletar(string Id)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _usuarioNegocios.RegrasParaDeletar(Id);
                if (retorno)
                {
                    return NoContent();
                }
            }
            return NotFound();
        }
    }
}
