using MC.CadastroCliente.Domain.Models;
using System.Collections.Generic;

namespace MC.CadastroCliente.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();
    }
}
