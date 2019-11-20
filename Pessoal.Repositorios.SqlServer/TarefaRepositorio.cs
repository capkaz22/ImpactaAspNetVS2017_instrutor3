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

        public TarefaRepositorio(string stringConexao)
            
        {
            this.stringConexao = stringConexao;
        }

        public void Atualizar(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))                                                                  
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaAtualizar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa).ToArray());

                    
                    comando.ExecuteNonQuery();

                }

            }

        }

        public void Excluir(int id)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaExcluir", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", id);


                    comando.ExecuteNonQuery();

                }

            }

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

            if (tarefa.Id != 0)
            {
                parametros.Add(new SqlParameter("@Id", tarefa.Id));

            }

            parametros.Add(new SqlParameter("@nome",tarefa.Nome));///instancia da classe SqlParameter
            parametros.Add(new SqlParameter("@Prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@Concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@Observacao", tarefa.Observacao));
            return parametros;
        }

        public List<Tarefa> Selecionar()
        {
            var tarefas = new List<Tarefa>();
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            tarefas.Add(Mapear(registro));

                        }
                    }
                }

            }

            return tarefas;
        }

        private Tarefa Mapear(SqlDataReader registro)
        {
            var tarefa = new Tarefa();
            tarefa.Id = Convert.ToInt32(registro["id"]);
            tarefa.Concluida = Convert.ToBoolean(registro["Concluida"]);
            tarefa.Nome = registro["nome"].ToString();
            tarefa.Observacao = Convert.ToString(registro["observacao"]);
            tarefa.Prioridade = (Prioridade)Convert.ToInt32(registro["Prioridade"]);//convert do tipo enumerador

            return tarefa;
        }

        public Tarefa Selecionar(int id)
        {
            Tarefa tarefa = null;//para garantir caso tenha valor nulo

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id",id);
                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.Read())
                        {
                            tarefa = Mapear(registro);
                        }
                    }
                }

            }



            return tarefa;
        }


    }
}
