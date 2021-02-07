﻿using GetSimple.WebAPI.Modelos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetSimple.WebAPI.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IRepositorio<Usuario> _repositorio;
        private readonly SignInManager<Usuario> _signInManager;
        public UsuarioRepositorio(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<Usuario> IncluirDbContext(RegisterModel model)
        {
            var user = new Usuario { UserName = model.Login };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return user;
            }
            return null;
        }

        public async Task<bool> DeletarDbContext(string Id)
        {
            var usuario = await _userManager.FindByIdAsync(Id);
            var model = await _userManager.DeleteAsync(usuario);

            if (model.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
