using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;
using System.Data.Entity;

namespace Loja.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private readonly LojaDbContext db = new LojaDbContext();

        public LojaDbContextTests()
        {
            db.Database.Log = LogarQuery;
        }

        private void LogarQuery(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirCategoriaTest()
        {
            var categoria = new Categoria();
            categoria.Nome = "Eletronicos";
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTest()
        {
            var produto = new Produto();
            produto.Nome = "Celular";
            produto.Preco = 100.52m;
            produto.Estoque = 10;
            produto.Categoria = new Categoria {Nome = "Eletronicos"};
            //produto.Categoria = db.Categorias.Find(1);
            db.Produtos.Add(produto);
            db.SaveChanges();



        }

        [TestMethod]
        public void LazyLoadTest()
        {
            var produto = db.Produtos.Where(p => p.Nome == "Celular")
                .First();

            Console.WriteLine(produto.Categoria.Nome);

        }

        [TestMethod]
        public void IncludeTest()
        {
            var produto = db.Produtos
                .Include(p => p.Categoria)
                .Single(p => p.Id == 1);

            Console.WriteLine(produto.Categoria.Nome);

        }

        [TestMethod]
        [DataRow(1)]//sem esse cara aqui esse teste não roda
        public void QueryableTeste(int estoque)
        {
            var query = db.Produtos.Where(p => p.Preco > 2);

            if (estoque > 0)
            {
                query = query.Where(p => p.Estoque > estoque);

            }

            query.OrderBy(p => p.Nome);

            var primeiro = query.FirstOrDefault();///o .first dispara a consulta no banco de dados
            var ultimo = query.AsEnumerable().Last();///cuidado, ele recupera todos os registros
            //var ultimo = query.Last();
            //var unico = query.Single(p => p.Id == 1);
            var unico = query.Single();
            var todos = query.ToList();
 

        }
    }
}