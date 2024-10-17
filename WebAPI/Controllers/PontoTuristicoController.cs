using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PontosTuristicosController : ControllerBase
{
    private readonly IPontoTuristicoService _service;

    public PontosTuristicosController(IPontoTuristicoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PontoTuristicoDto>>> GetAll()
    {
        var pontoTuristicoDto = await _service.GetAllAsync();
        return Ok(pontoTuristicoDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PontoTuristicoDto>> GetPontosTuristicosById(int id)
    {
        var pontoTuristicoDto = await _service.GetByIdAsync(id);
        if (pontoTuristicoDto == null)
        {
            return NotFound();
        }
        return Ok(pontoTuristicoDto);
    }

    [HttpPost]
    public async Task<ActionResult<PontoTuristicoDto>> Create(PontoTuristicoDto pontoTuristicoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdPontoTuristicoDto = await _service.AddAsync(pontoTuristicoDto);

        return CreatedAtAction(nameof(GetPontosTuristicosById), new { id = createdPontoTuristicoDto.Id }, createdPontoTuristicoDto);
    }
}
