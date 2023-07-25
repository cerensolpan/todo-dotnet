using FluentValidation;

namespace todo_dotnet.Application.TodoOperation.DeleteTodo
{
  public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
  {
    public DeleteTodoCommandValidator()
    {
      RuleFor(command => command.TodoId).GreaterThan(0);
    }
  }
}