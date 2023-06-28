using Dapper;
using Projeto06.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Repositories
{
    public class ClienteRepository
    {
        public void Inserir(Cliente cliente)
        {
            var query = @"
                INSERT INTO CLIENTE (ID, NOME, CPF, DATANASCIMENTO)
                VALUES(@Id, @Nome, @Cpf, @DataNascimento)
        
            ";

            using(var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProjeto06;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Execute(query, cliente);
            }

        }

    }
}
