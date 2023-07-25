using FluentValidation;

namespace todo_dotnet.Application.TodoOperation.CreateTodo
{
  public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
  {
    public CreateTodoCommandValidator()
    {
      RuleFor(command => command.Model.Id).GreaterThan(0);
      RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
    }
  }
}