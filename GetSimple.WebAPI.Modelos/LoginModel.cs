using System;
using System.ComponentModel.DataAnnotations;

namespace GetSimple.WebAPI.Modelos
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
