create procedure TarefaAtualizar
	@id int
	,@Nome nvarchar(200)
	,@Prioridade int 
	,@Concluida bit
	,@Observacao nvarchar(1000)
as

UPDATE [dbo].[Tarefa]
   SET [Nome] = @Nome
      ,[Prioridade] = @Prioridade
      ,[Concluida] = @Concluida
      ,[Observacao] = @Observacao
 WHERE Id = @Id
