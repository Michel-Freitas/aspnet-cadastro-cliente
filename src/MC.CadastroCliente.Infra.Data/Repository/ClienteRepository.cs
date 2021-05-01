using Dapper;
using MC.CadastroCliente.Domain.Interfaces;
using MC.CadastroCliente.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MC.CadastroCliente.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> ObterAtivos()
        {
            //return Buscar(c => c.Ativo && !c.Excluido);

            // Usando Dapper
            var sql = @"SELECT * FROM Clientes c WHERE c.Excluido = 0 AND c.Ativo = 1";
            return Db.Database.Connection.Query<Cliente>(sql);
        }


        // Usando Dapper
        public override Cliente ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Clientes c
                        LEFT JOIN Enderecos e
                        ON c.Id = e.ClienteId
                        WHERE c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            // throw new Exception("Testando tratativas de erros");

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql, 
                (c, e) => { c.Enderecos.Add(e); return c; }, new {uid = id}).FirstOrDefault();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Excluir();

            Atualizar(cliente);
        }
    }
}
