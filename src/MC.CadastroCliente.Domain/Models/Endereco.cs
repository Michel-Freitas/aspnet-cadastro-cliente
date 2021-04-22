using System;

namespace MC.CadastroCliente.Domain.Models
{
    class Endereco
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Guid ClienteId { get; set; }

        // Propriedade de Navegação do Entity Framework
        // Precisa ter as duas propriedades, o ID e o Objeto
        // LazyLoagding => Carrega os dados por demanda
        // EagerLoading => Carrega antecipadamente os dados
        // O Entity Framework vai trabalhar usando o LazyLoagding se colcoar o "virtual" no atributo
        public virtual Cliente Cliente { get; set; }
    }
}
