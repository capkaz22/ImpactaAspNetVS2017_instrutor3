using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pessoal.Repositorios.SqlServer.Testes
{
    [TestClass]
    public class TarefaRepositorioTeste
    {
        ///preciso fazer a referencia do projeto adicionando os projetos Pessoal.dominio e Pessoal.Repositorio 
        //fazer o nuget do projeto para instalar o componente microsoft.extensions.configuration
        private TarefaRepositorio repositorio;//field

        public TarefaRepositorioTeste()
        {
            var config = new ConfigurationBuilder()
                
            repositorio = new TarefaRepositorio();
        }

        [TestMethod]
        public void InserirTeste()
        {

        }
    }
}
