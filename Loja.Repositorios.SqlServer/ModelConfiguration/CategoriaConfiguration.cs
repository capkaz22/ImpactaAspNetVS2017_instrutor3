using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    internal class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(c => c.Nome)///property p aponta para p.Nome na lista da tabela Produto
                .IsRequired()//é requerida, é obrigatória
                .HasMaxLength(200);

        }
    }
}