using MC.CadastroCliente.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace MC.CadastroCliente.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogge());
        }
    }
}
