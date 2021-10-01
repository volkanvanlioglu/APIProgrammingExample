using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class BaseDAL
    {
        protected ProgrammingDbEntities Db;

        public BaseDAL()
        {
            Db = new ProgrammingDbEntities();
        }
    }
}
