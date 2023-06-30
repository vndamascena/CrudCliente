using Microsoft.VisualBasic;
using Projeto06.Entities;
using Projeto06.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Controllers
{
    public class ClienteController
    {
        public void ExecutarMenu()
        {

            Console.WriteLine("\n--- CONTROLE DE CLIENTE---\n");
            Console.WriteLine("(1) - CADASTRA CLIENTE");
            Console.WriteLine("(2) - ATUALIZAR CLIENTE");
            Console.WriteLine("(3) - EXCLUIR CLIENTES");
            Console.WriteLine("(4) - CONSULTAR CLIENTES");

            try
            {
                Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: CadastraCliente(); break;
                    case 2: AtualizarCliente(); break;
                    case 3: ExcluirCliente(); break;
                    case 4: ConsultarClientes(); break;

                    default:
                        Console.WriteLine("\nOpção invalida.");
                        break;




                }
                Console.WriteLine("\nDESEJA CONTINUAR? (S,N): ");
                var escolha = Console.ReadLine();

                if (escolha.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    ExecutarMenu();

                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA.");
                }


            }
            catch(Exception e) 
            {
                Console.WriteLine("\nErro: " + e.Message);
            }




        }

        private void CadastraCliente()
        {

            try
            {
                Console.WriteLine("\n--- CADSTRO DE CLIENTE ---\n");

                var cliente = new Cliente();

                Console.Write("Nome do cliente: ");
                cliente.Nome = Console.ReadLine();

                Console.Write("CPF: ");
                cliente.Cpf = Console.ReadLine();

                Console.Write("Data de nascimento: ");
                cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

                var clienteRepository = new ClienteRepository();
                clienteRepository.Inserir(cliente);

                Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO!");



            }

            catch(ArgumentException e)
            {
                Console.WriteLine("\nOcorreram erros de validação:");
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {

                Console.WriteLine("\nFalha ao cadastra cliente" + e.Message );
            }




        }

        public void AtualizarCliente()
        {
            try
            {
                Console.WriteLine("\n--- EDIÇÃO DE CLIENTE ---\n");


                Console.Write("INFORME O ID DO CLIENTE: ");
                var id = Guid.Parse(Console.ReadLine());

                var clienteRespository = new ClienteRepository();
                var cliente = ClienteRepository.ObterPorId(id);

                if(cliente != null)
                {
                    Console.Write("INFORME O NOME DO CLIENTE: ");
                    cliente.Nome = Console.ReadLine();

                    Console.Write("INFORME O CPF: ");
                    cliente.Cpf = Console.ReadLine();

                    Console.Write("INFORME A DATA DE NASCIMENTO: ");
                    cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

                    clienteRespository.Atualizar(cliente);

                    Console.WriteLine("\nCLIENTE ATUALIZADO COM SUCESSO!");


                }
                else
                {
                    Console.WriteLine("Cliente não encontrado.");
                }

            }

            catch(ArgumentException e)
            {
                Console.WriteLine("\nOcorreram erros de validação:");
                Console.WriteLine(e.Message);

            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao atualizar cliente" + e.Message);

            }
        }
        public void ExcluirCliente()
        {
            try
            {
                Console.WriteLine("\n--- EXCLUSÃO DE CLIENTE ---");

                Console.Write("INFORME O ID DO CLIENTE: ");
                var id = Guid.Parse(Console.ReadLine());

                var clienteRespository = new ClienteRepository();
                var cliente = ClienteRepository.ObterPorId(id);

                if(cliente != null) 
                {
                    clienteRespository.Excluir(cliente);

                    Console.WriteLine("\nCLIENTE EXCLUIDO COM SUCESSO.");
                
                }
                else
                {

                    Console.WriteLine("Cliente não encontrado.");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao excluir cliente.");
                Console.WriteLine(e.Message);
            }
            
            
           

        }

        public void ConsultarClientes()
        {
            try
            {
                Console.WriteLine("\n --- CONSULTA DE CLIENTES ---");

                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterTodos();

                foreach (var item in cliente)
                {
                    Console.WriteLine("ID: " + item.Id);
                    Console.WriteLine("NOME: " + item.Nome);
                    Console.WriteLine("CPF: " + item.Cpf);
                    Console.WriteLine("DATA DE NASCIMENTO: " + item.DataNascimento);

                    Console.WriteLine(".......");


                }

            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao consultar clientes.");
                Console.WriteLine(e.Message);
            }




        }



    }
}
