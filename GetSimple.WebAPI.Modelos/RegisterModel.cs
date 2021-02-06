using System;
using System.Collections.Generic;
using System.Text;

namespace GetSimple.WebAPI.Modelos
{
    public class RegisterModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
