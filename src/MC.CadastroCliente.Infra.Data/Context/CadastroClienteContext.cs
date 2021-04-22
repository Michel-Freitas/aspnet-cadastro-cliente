using MC.CadastroCliente.Domain.Models;
using MC.CadastroCliente.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MC.CadastroCliente.Infra.Data.Context
{
    class CadastroClienteContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; private set; }

        public DbSet<Endereco> Enderecos { get; private set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}
