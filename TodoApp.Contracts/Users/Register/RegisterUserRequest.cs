using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Contracts.Users.Login;

namespace TodoApp.Contracts.Users.Register
{
    public class RegisterUserRequest: LoginUserRequest
    {
        public string email { get; set; } =string.Empty;
    }
}
