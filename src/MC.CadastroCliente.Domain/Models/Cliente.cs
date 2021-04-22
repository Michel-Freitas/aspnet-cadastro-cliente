using System;
using System.Collections.Generic;

namespace MC.CadastroCliente.Domain.Models
{
    class Cliente
    {

        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }

        // LazyLoagding => Carrega os dados por demanda
        // EagerLoading => Carrega antecipadamente os dados
        // O Entity Framework vai trabalhar usando o LazyLoagding se colcoar o "virtual" no atributo
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public void Excluir()
        {
            Ativo = false;
            Excluido = true;
        }
    }
}
