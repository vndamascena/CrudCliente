using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto06.Entities
{
    public class Cliente
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private DateTime _dataNascimento;


        public Cliente()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id 
        { 
            get => _id; 
            set => _id = value; 
        }
        public string Nome 
        { 
            get => _nome;
            set
            {
                if (string.IsNullOrEmpty(value))

                    throw new ArgumentException("Nome do cliente e obrigatorio.");
                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,100}$");
                
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Nome do cliente invalido. Informe de 8 a 100 carcteres.");
                  


                _nome = value;

            }
        }
        public string Cpf 
        { 
            get => _cpf;
            set 
            {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CPF do cliente e obrigatorio.");
                var regex = new Regex("^[0-9]{11}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("CPF do cliente invalido. Informe o exatamente 11 números");
                
                
                _cpf = value; 
            } 
        }
        public DateTime DataNascimento 
        { 
            get => _dataNascimento;
            set
            {
                var dataAtual = DateTime.Now;
                var idade = dataAtual.Year - value.Year;

                if (idade <= 18 && value > dataAtual.AddYears(-idade))
                    throw new ArgumentException("O cliente nao pode ser menor de idade.");




                _dataNascimento = value;

            }
        }




    }
}
