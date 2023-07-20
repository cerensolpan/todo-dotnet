using Microsoft.EntityFrameworkCore;
using todo_dotnet.Models.Todo;

namespace todo_dotnet.Data;

public class TodosContext : DbContext
{
  public virtual DbSet<Todo> todos { get; set; }

  public TodosContext(DbContextOptions<TodosContext> options) : base(options) { }
}
