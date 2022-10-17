using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBankDAL.Configuration
{
    public class Configuration
    {
        public string ConnectionString { get; set; }
        public Jwt Jwt { get; set; }
    }
}
