using api_airport.Emums;
using api_airport.Filters;
using api_airport.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_airport.Controllers;

[ApiController]
public abstract class BaseController<TDto, TCreateDto> : ControllerBase
{
    private readonly IBaseService<TDto, TCreateDto> _service;

    protected BaseController(IBaseService<TDto, TCreateDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<ActionResult<List<TDto>>> GetList()
    {
        var response = await _service.GetListAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TDto>> GetItem(Guid id)
    {
        var response = await _service.GetItemAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public virtual async Task<ActionResult<string>> AddItem(TCreateDto newItem)
    {
        var response = await _service.AddAsync(newItem);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpPut("{id}")]
    [RoleRequirement(UserRole.Admin)]
    public virtual async Task<ActionResult> UpdateItem(Guid id, TCreateDto updatedItem)
    {
        await _service.UpdateAsync(id, updatedItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [RoleRequirement(UserRole.Admin)]
    public virtual async Task<ActionResult> DeleteItem(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}