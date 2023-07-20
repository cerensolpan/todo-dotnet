using AutoMapper;
using Microsoft.EntityFrameworkCore;
using todo_dotnet.Data;
using todo_dotnet.Models.Todo;

namespace todo_dotnet.Application.TodoOperation.GetTodos
{
  public class GetTodosQuery
  {
    private readonly TodosContext _dbContext;
    private readonly IMapper _mapper;
    public GetTodosQuery(TodosContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }
    public List<Todo> Handle()
    {
      var todos = _dbContext.todos.ToList();
      List<Todo> viewModels = _mapper.Map<List<Todo>>(todos);
      return viewModels;
    }

  }
}