using MC.CadastroCliente.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.CadastroCliente.Infra.Data.EntityConfig
{
    class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(c => c.Complemento)
                .HasMaxLength(100);

            // ONE TO MANY
            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Enderecos");

        }
    }
}
