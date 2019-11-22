using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    internal class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            Property(p => p.Nome)///property p aponta para p.Nome na lista da tabela Produto
                .IsRequired()//é requerida, é obrigatória
                .HasMaxLength(200);
            Property(p => p.Preco)//configuração do preço
                .HasPrecision(9, 2);
            HasOptional(p => p.Imagem)///configuração da tabela imagem
                .WithRequired(pi => pi.Produto)
                .WillCascadeOnDelete(true);
          



        }
    }
}