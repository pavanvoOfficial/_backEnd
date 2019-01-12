using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class GetParams
    {
        [Required(ErrorMessage = "UserName is required")]
        public string login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}
