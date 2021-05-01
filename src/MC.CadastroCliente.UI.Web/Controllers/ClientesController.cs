using System;
using System.Net;
using System.Web.Mvc;
using MC.CadastroCliente.Application.Interfaces;
using MC.CadastroCliente.Application.Services;
using MC.CadastroCliente.Application.ViewModel;
using MC.CadastroCliente.Infra.CrossCutting.MvcFilters;

namespace MC.CadastroCliente.UI.Web.Controllers
{
    // LISTAR, VISUALIZAR, INCLUIR, EDITAR, EXCLUIR
    // Anotação para restringir o acesso a somente quem estiver autenticado no sistema
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        // Permite que pessoas não logadas possam ver a lista de clientes
        //[AllowAnonymous]
        [ClaimsAuthorize("Cliente", "LISTAR")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        [ClaimsAuthorize("Cliente", "VISUALIZAR")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // Autorizando a criação de clientes somente para usuários Admin
        //[Authorize(Roles = "Admin")]
        [ClaimsAuthorize("Cliente", "INCLUIR")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Cliente", "INCLUIR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [ClaimsAuthorize("Cliente", "EDITAR")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Cliente", "EDITAR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Cliente", "EXCLUIR")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Cliente", "EXCLUIR")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
