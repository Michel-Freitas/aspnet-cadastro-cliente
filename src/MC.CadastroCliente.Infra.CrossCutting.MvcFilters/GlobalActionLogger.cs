using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MC.CadastroCliente.Infra.CrossCutting.MvcFilters
{
    public class GlobalActionLogge : ActionFilterAttribute
    {
        // Com esse filtro não precisa mais usar os try cacht na classe controller.
        // Tudo vai passar por essa classe e caso tenha alguma Exception ele vai pegar
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Log de Auditoria
            // Usuário, Ação, IP, Máquina
            if(filterContext.Exception != null)
            {
                // Mnipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro no BD
                //  -> Email para o admin
                //  -> Retonar cod de erro amigavel

                // Precisa para informar ao sistema que o erro já foi capturado e tratado
                filterContext.ExceptionHandled = true;
                // Retornando o erro 500 para o cliente
                filterContext.Result = new HttpStatusCodeResult(500);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
