using todo_dotnet.Data;

namespace todo_dotnet.Application.TodoOperation.DeleteTodo
{
  public class DeleteTodoCommand
  {
    private readonly TodosContext _dbContext;
    public int TodoId { get; set; }

    public DeleteTodoCommand(TodosContext dbContext){
      _dbContext = dbContext;
    }
    public void Handle()
    {
      var todo = _dbContext.todos.SingleOrDefault(t => t.Id==TodoId);
      if(todo==null)
      {
        throw new InvalidOperationException("There is no todo");
      }
      else
      {
        _dbContext.todos.Remove(todo);
        _dbContext.SaveChanges();
      }
    }
  }
}