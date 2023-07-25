using AutoMapper;
using todo_dotnet.Data;
using todo_dotnet.Models.Todo;

namespace todo_dotnet.Application.TodoOperation.CreateTodo
{
  public class CreateTodoCommand
  {
    private readonly TodosContext _dbContext;
    private readonly IMapper _mapper;
    public Todo Model { get; set; }

    public CreateTodoCommand(TodosContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public void Handle()
    {
      var todo = _dbContext.todos.SingleOrDefault(t => t.Name == Model.Name);
      if(todo is not null)
      {
        throw new InvalidOperationException("Todo is already created");
      }
      else
      {
        todo=_mapper.Map<Todo>(Model);
        _dbContext.todos.Add(todo);
        _dbContext.SaveChanges();
      }
    }
  }
}