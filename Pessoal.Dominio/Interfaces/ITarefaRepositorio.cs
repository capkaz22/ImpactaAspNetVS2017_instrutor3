using Pessoal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pessoal.Dominio.Interfaces
{
    public interface ITarefaRepositorio
    {
        int Inserir(Tarefa tarefa);//objeto do tipo Tarefa
        List<Tarefa> Selecionar();
        Tarefa Selecionar(int id);///parametro a inicial é minuscula
        void Atualizar(Tarefa tarefa);
        void Excluir(int id);
    }
}

