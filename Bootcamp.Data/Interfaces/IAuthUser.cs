using Bootcamp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Data.Interface
{
    public interface IAuthUser
    {
        public Task<Users> GetLogInUserName(string UserName);

        public List<Users> GetAuthUsers();

        public void AddData(Users user);
    }
}
