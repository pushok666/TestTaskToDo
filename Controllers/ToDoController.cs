using TestTaskToDo.Models;
using TestTaskToDo.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskToDo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly ToDosService _todoService;
    public ToDoController(ToDosService todoService) =>
        _todoService = todoService;

    [HttpGet]
    public async Task<List<ToDo>> Get () =>
        await _todoService.GetAsync();
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ToDo>> Get(string id)
    {
        var todo = await _todoService.GetAsync(id);
        if(todo is null)
            return NotFound();
        return todo;
    }
    [HttpPost]
    public async Task<IActionResult> Post(ToDo newToDo)
    {
        await _todoService.CreateAsync(newToDo);
        return CreatedAtAction(nameof(Get), new {id = newToDo.Id}, newToDo);
    }
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ToDo updateToDo)
    {
        var todo = await _todoService.GetAsync(id);
        if(todo is null)
            return NotFound();
        updateToDo.Id = todo.Id;
        await _todoService.UpdateAsync(id, updateToDo);
        return NoContent();
    }
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var todo = await _todoService.GetAsync(id);
        if(todo is null)
            return NotFound();
        await _todoService.RemoveAsync(id);
        return NoContent();

    }
}