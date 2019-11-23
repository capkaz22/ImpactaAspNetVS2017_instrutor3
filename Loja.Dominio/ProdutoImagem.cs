namespace Loja.Dominio
{
    public class ProdutoImagem
    {
        public int ProdutoId { get; set; }//usa o mesmo id da base pai, chave fraca
        public byte[] Bytes { get; set; }//vetor de bytes no sqlserver
        public string ContentType { get; set; }///

        public virtual Produto Produto { get; set; }

    }
}