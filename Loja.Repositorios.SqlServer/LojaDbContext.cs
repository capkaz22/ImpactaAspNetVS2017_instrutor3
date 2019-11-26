using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using Loja.Repositorios.SqlServer.ModelConfiguration;

namespace Loja.Repositorios.SqlServer
{
    public class LojaDbContext : DbContext
    {

        public LojaDbContext() : base("lojaSqlServer")
        {
            //1. enable-Migrations --necessário para rodar o banco de dados
            
            //2. Add-MIgration NomeDaModificacao
            //3. Update-Database
            //passo 2 e 3 é para sempre inserido
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();//deleta um deleta todos em cascata

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Loja.Dominio.ProdutoImagem> ProdutoImagem { get; set; }
    }
}
