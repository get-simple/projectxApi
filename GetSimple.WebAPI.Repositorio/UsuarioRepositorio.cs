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
        public UsuarioRepositorio(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Usuario> IncluirDbContext(RegisterModel model)
        {
            var user = new Usuario { UserName = model.Login };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }
    }
}