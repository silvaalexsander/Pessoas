using Pessoas.Models;
using Pessoas.Repository.Context;

namespace Pessoas.Repository
{
    public class PessoasEFRepository
    {
        private readonly DataBaseContext context;

        public PessoasEFRepository()
        {
            context = new DataBaseContext();
        }

        public IList<PessoaEF> Listar()
        {
            return context.PessoaEF.ToList();
        }

        public IList<PessoaEF> ListarPorNome()
        {
            var lista =  context.PessoaEF.OrderBy(p => p.Name).ToList();
            return lista;
        }

        public IList<PessoaEF> ListarPorNomeDescendente()
        {
            var lista =  context.PessoaEF.OrderByDescending(p => p.Name).ToList();
            return lista;
        }

        public IList<PessoaEF> ListarPorID()
        {
            var lista = context.PessoaEF.OrderByDescending(p => p.idPessoa).ToList();
            return lista;
        }

        public PessoaEF ConsultaPorNome(string name)
        {
            PessoaEF pessoa = context.PessoaEF.Where(t =>t.Name == name).FirstOrDefault();
            return pessoa;
        }

        public IList<PessoaEF> ConsultaPorParteNome(string parteName)
        {
            var lista = context.PessoaEF.Where(t =>t.Name.Contains(parteName)).ToList();
            return lista;
        }

        public PessoaEF Consultar(int id)
        {
            return context.PessoaEF.Find(id);
        }

        public void Inserir (PessoaEF pessoa)
        {
            context.PessoaEF.Add(pessoa);
            context.SaveChanges();
        }

        public void Alterar(PessoaEF pessoa)
        {
            context.PessoaEF.Update(pessoa);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var pessoa = new PessoaEF()
            {
                idPessoa = id
            };

            context.PessoaEF.Remove(pessoa);
            context.SaveChanges();
        }
    }
}
