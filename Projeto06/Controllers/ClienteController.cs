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
                    case 2: break;
                    case 3: break;
                    case 4: break;

                    default:
                        Console.WriteLine("\nOpção invalida.");
                        break;




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


    }
}
