namespace MC.CadastroCliente.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MC.CadastroCliente.Infra.Data.Context.CadastroClienteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MC.CadastroCliente.Infra.Data.Context.CadastroClienteContext context)
        {
        }
    }
}
