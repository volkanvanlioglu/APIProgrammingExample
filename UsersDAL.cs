using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class UsersDAL:BaseDAL
    {
        public Users GetUserByApiKey(string ApiKey)
        {
            return Db.Users.FirstOrDefault(u => u.UserKey.ToString() == ApiKey);
        }

        public Users GetUsersByName(string Name)
        {
            return Db.Users.FirstOrDefault(u => u.Name == Name);
        }
    }
}
