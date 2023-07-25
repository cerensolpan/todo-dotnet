using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todo_dotnet.Application.TodoOperation.GetTodos;
using todo_dotnet.Application.TodoOperation.GetByIdTodo;
using todo_dotnet.Application.TodoOperation.CreateTodo;
using todo_dotnet.Application.TodoOperation.DeleteTodo;
using todo_dotnet.Data;
using todo_dotnet.Models.Todo;
using FluentValidation;

namespace todo_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodosContext _dbContext;
    private readonly IMapper _mapper;

    public TodoController(TodosContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        GetTodosQuery todosQuery = new GetTodosQuery(_dbContext, _mapper);
        var result = todosQuery.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        GetByIdTodoQuery todoQuery = new GetByIdTodoQuery(_dbContext);
        GetByIdTodoQueryValidator validator = new GetByIdTodoQueryValidator();
        todoQuery.TodoId = id;
        validator.ValidateAndThrow(todoQuery);
        var result = todoQuery.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddTodo([FromBody] Todo newTodo)
    {
        CreateTodoCommand todoCommand = new CreateTodoCommand(_dbContext, _mapper);
        CreateTodoCommandValidator validator = new CreateTodoCommandValidator();
        todoCommand.Model = newTodo;
        validator.ValidateAndThrow(todoCommand);
        todoCommand.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteTodo(int id)
    {
        DeleteTodoCommand deleteTodoCommand = new DeleteTodoCommand(_dbContext);
        DeleteTodoCommandValidator validator = new DeleteTodoCommandValidator();
        deleteTodoCommand.TodoId = id;
        validator.ValidateAndThrow(deleteTodoCommand);
        deleteTodoCommand.Handle();
        return Ok();
    }
}