using Microsoft.Data.SqlClient;
using Pessoal.Dominio.Entidades;
using Pessoal.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pessoal.Repositorios.SqlServer
{
    public class TarefaRepositorio : ITarefaRepositorio//ctrl . ultima opção depois ctrl . para inserir o código
    {
        private string stringConexao;

        public TarefaRepositorio(string stringConexao)//metodo construtor da classe
            //obriga passar a string de conexão se não o build quebra
        {
            this.stringConexao = stringConexao;//usar o this cria o vinculo com a classe em que estou
        }

        public void Atualizar(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))//using tab tab ganha fechar a conexão
                //tomar cuidado ao fazer o ctrl . pois é um nuget, com o system data, pasta dependencia gerenciador nuget
                //atualizar a versão da estrutura de destino depois fazer um nuget
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaInserir",  conexao))//passar o nome da procedure do banco e a conexao
                {
                    comando.CommandType = CommandType.StoredProcedure;//CommandType é o enumerador da microsoft
                    comando.Parameters.AddRange(Mapear(tarefa).ToArray());


                    //comando.ExecuteNonQuery(); não retorna nada
                    return (int)comando.ExecuteScalar();//retorna uma única informação do tipo object extraindo um inteiro
                    
                }

            }
            
        }

        private List<SqlParameter> Mapear(Tarefa tarefa)
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@nome",tarefa.Nome));///instancia da classe SqlParameter
            parametros.Add(new SqlParameter("@Prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@Concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@Observacao", tarefa.Observacao));

            return parametros;

        }

        public List<Tarefa> Selecionar()
        {
            throw new NotImplementedException();
        }

        public Tarefa Selecionar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
