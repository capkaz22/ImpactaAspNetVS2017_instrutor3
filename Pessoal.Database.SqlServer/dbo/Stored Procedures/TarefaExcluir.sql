create proc TarefaExcluir
	@id int
as
	Delete Tarefa
	Where Id = @id
