using System;
using todo_dotnet.Data;
using todo_dotnet.Models.Todo;

namespace todo_dotnet.Application.TodoOperation.GetByIdTodo
{
  public class GetByIdTodoQuery
  {
    private readonly TodosContext _dbContext;
    public int TodoId { get; set; }
    public GetByIdTodoQuery(TodosContext dbContext)
    {
      _dbContext = dbContext;
    }

    public Todo Handle()
    {
      var todo = _dbContext.todos.SingleOrDefault(t => t.Id == TodoId);
      Console.WriteLine("Hello",TodoId);
      if (todo == null)
      {
        throw new InvalidOperationException("There is not to do");
      }
      else
      {
        Todo getByIdTodoModel = new Todo();
        getByIdTodoModel.Name = todo.Name;
        getByIdTodoModel.Id = todo.Id;
        return getByIdTodoModel;
      }
    }
  }
}