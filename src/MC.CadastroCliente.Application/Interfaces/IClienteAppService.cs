using MC.CadastroCliente.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace MC.CadastroCliente.Application.Interfaces
{
    public interface IClienteAppService :IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteViewModel ObterPorId(Guid id);

        IEnumerable<ClienteViewModel> ObterTodos();

        IEnumerable<ClienteViewModel> ObterAtivos();

        ClienteViewModel ObterPorCpf(string cpf);

        ClienteViewModel ObterPorEmail(string email);

        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);

        void Remover(Guid id);
    }
}
