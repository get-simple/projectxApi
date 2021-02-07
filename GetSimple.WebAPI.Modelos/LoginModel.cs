using System;
using System.ComponentModel.DataAnnotations;

namespace GetSimple.WebAPI.Modelos
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
