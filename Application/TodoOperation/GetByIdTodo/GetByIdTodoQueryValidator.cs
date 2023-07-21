using FluentValidation;

namespace todo_dotnet.Application.TodoOperation.GetByIdTodo
{
  public class GetByIdTodoQueryValidator : AbstractValidator<GetByIdTodoQuery>
  {
    public GetByIdTodoQueryValidator()
    {
      RuleFor(command => command.TodoId).GreaterThan(0).NotEmpty();
    }
  }
}