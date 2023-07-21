using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todo_dotnet.Application.TodoOperation.GetTodos;
using todo_dotnet.Application.TodoOperation.GetByIdTodo;
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

}