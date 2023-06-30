using Dapper;
using Projeto06.Entities;
using Projeto06.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            using(var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, cliente);
            }

        }

        public void Atualizar(Cliente cliente)
        {
            var query = @"
              UPDATE CLIENTE
              SET
                  NOME = @Nome
                  CPF = @Cpf
                  DATANASCIMENTO = @DataNascimento
              WHERE
                ID = Id
            ";
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, cliente);
            }

        }

        public void Excluir(Cliente cliente)
        {
            var query = @"
                DELETE FROM CLIENTE
                WHERE ID = Id

            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, cliente);
            }
        }

        public List<Cliente> ObterTodos()
        {
            var query = @"
                SELECT *FROM CLIENTE
                ORDER BY NOME

            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Cliente>(query).ToList();
            }


        }

        public static Cliente? ObterPorId(Guid id)
        {
            var query = @"
                SELECT *FROM CLIENTE
                WHERE ID = @Id

            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Cliente>(query, new { @Id = id }).FirstOrDefault();
            }
        }

    }
}
