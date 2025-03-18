using Academia2.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using acdm = Academia2.Domain.Models;
namespace Academia2.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Academia2Controller : ControllerBase
{
    private readonly IAcademiaService _academiaService;

    public Academia2Controller(IAcademiaService academiaService)
    {
        _academiaService = academiaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAcademias()
    {
        var result = await _academiaService.GetAcademias();
        if (!result.Success)
        {
            return NotFound();
        }
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAcademiaById(Guid id)
    {
        var result = await _academiaService.GetAcademiaById(id);
        if (!result.Success)
        {
            return NotFound();
        }
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> AddAcademia([FromBody] acdm.Academia2 newAcademia)
    {
        if (newAcademia == null)
        {
            return BadRequest("Academia data não pode ser nulo.");
        }
        var result = await _academiaService.AddAcademia(newAcademia);
        if (!result.Success)
        {
            return BadRequest(result.ErrorDescription);
        }
        return Ok(result.Data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAcademia(Guid id, [FromBody] acdm.Academia2 updatedAcademia)
    {
        if (id != updatedAcademia.Id)
        {
            return BadRequest("Academia Id incompativel");
        }
        var result = await _academiaService.UpdateAcademia(id, updatedAcademia);
        if (!result.Success)
        {
            return NotFound(result.ErrorDescription);
        }
        return Ok(result.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAcademia(Guid id)
    {
        var result = await _academiaService.DeleteAcademia(id);
        if (!result.Success)
        {
            return NotFound();
        }
        return Accepted();
    }
}


