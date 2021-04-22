using System;

namespace MC.CadastroCliente.Domain.Models
{
    class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
