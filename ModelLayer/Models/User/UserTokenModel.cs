using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models.User
{
    public class UserTokenModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
