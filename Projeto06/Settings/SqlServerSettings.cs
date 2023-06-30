using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Settings
{
    public class SqlServerSettings
    {
        public static string GetConnectionString()
        {


            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProjeto06;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }


    }
}
