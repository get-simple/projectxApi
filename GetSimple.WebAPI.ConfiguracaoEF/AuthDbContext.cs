using GetSimple.WebAPI.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetSimple.WebAPI.ConfiguracaoEF
{
    public class AuthDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public AuthDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
                
        }
    }
}
