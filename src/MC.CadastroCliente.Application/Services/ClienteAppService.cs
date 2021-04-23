using MC.CadastroCliente.Application.Interfaces;
using MC.CadastroCliente.Application.ViewModel;
using MC.CadastroCliente.Domain.Interfaces;
using MC.CadastroCliente.Domain.Models;
using MC.CadastroCliente.Infra.Data.Repository;
using System;
using System.Collections.Generic;

namespace MC.CadastroCliente.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = new Cliente
            {
                Nome = clienteEnderecoViewModel.Cliente.Nome,
                Email = clienteEnderecoViewModel.Cliente.Email
            };

            _clienteRepository.Adicionar(cliente);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = new Cliente
            {
                Nome = clienteViewModel.Nome,
                Email = clienteViewModel.Email
            };

            _clienteRepository.Atualizar(cliente);

            return clienteViewModel;
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
