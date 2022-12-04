using Microsoft.AspNetCore.Mvc;
using Pessoas.Models;
using Pessoas.Repository;

namespace Pessoas.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoasRepository pessoasRepository;
        public PessoaController()
        {
            pessoasRepository = new PessoasRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoas = pessoasRepository.Listar();

            return View(listaPessoas);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new Pessoa());
        }

        [HttpPost]
        public ActionResult Cadastrar(Models.Pessoa pessoa)
        {

            if (ModelState.IsValid)
            {
                pessoasRepository.Inserir(pessoa);

                @TempData["mensagem"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index", "Pessoa");
            }
            else
            {
                return View(pessoa);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var pessoas = pessoasRepository.Consultar(Id);

            return View(pessoas);
        }

        [HttpPost]
        public ActionResult Editar(Models.Pessoa pessoas)
        {
            if (ModelState.IsValid)
            {
                pessoasRepository.Alterar(pessoas);

                @TempData["mensagem"] = "Cadastro alterado com sucesso!";
                return RedirectToAction("Index", "Pessoa");
            }
            else
            {
                return View(pessoas);
            }

        }

        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var pessoas = pessoasRepository.Consultar(Id);
            return View(pessoas);
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            pessoasRepository.Excluir(Id);

            @TempData["mensagem"] = "Cadastro excluído com sucesso!";

            return RedirectToAction("Index", "Pessoa");
        }

    }
}
