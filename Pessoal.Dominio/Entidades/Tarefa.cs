using System;

namespace Pessoal.Dominio.Entidades///o namespace não atualiza sozinha após a criação da pasta
{
    public class Tarefa
    {
        //Página 61

        public int Id { get; set; }
        public string Nome { get; set; }
        public Prioridade Prioridade { get; set; }
        public bool Concluida { get; set; }
        public string Observacao { get; set; }
        //interface e injeção de dependencia


    }
}
