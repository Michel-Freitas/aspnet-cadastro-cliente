using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.CadastroCliente.Application.ViewModel
{
    public class ClienteEnderecoViewModel
    {
        public ClienteViewModel Cliente { get; set; }

        public EnderecoViewModel Endereco { get; set; }
    }
}
