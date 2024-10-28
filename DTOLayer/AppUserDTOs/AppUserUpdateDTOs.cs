using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DTOLayer.AppUserDTOs
{
    public class AppUserUpdateDTOs
    {
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? password { get; set; }
        public string? oldPassword { get; set; }

        public string? confirmpassword { get; set; }
        public string? phonenumber { get; set; }
        public string? mail { get; set; }
        public string? imageurl { get; set; }
        public IFormFile? Image { get; set; }
    }
}
