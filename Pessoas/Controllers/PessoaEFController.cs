using Microsoft.AspNetCore.Mvc;
using Pessoas.Repository;

namespace Pessoas.Controllers
{
    public class PessoaEFController : Controller
    {

        private readonly PessoasEFRepository PessoaEFRepository;

        public PessoaEFController()
        {
            PessoaEFRepository = new PessoasEFRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoas = PessoaEFRepository.Listar();
            return View();
        }

    }
}
