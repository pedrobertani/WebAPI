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
        var touristSpotsDto = await _service.GetAllAsync();
        return Ok(touristSpotsDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PontoTuristicoDto>> GetPontosTuristicosById(int id)
    {
        var touristSpotDto = await _service.GetByIdAsync(id);
        if (touristSpotDto == null)
        {
            return NotFound();
        }
        return Ok(touristSpotDto);
    }

    [HttpPost]
    public async Task<ActionResult<PontoTuristicoDto>> Create(PontoTuristicoDto touristSpotDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdTouristSpotDto = await _service.AddAsync(touristSpotDto);

        return CreatedAtAction(nameof(GetPontosTuristicosById), new { id = createdTouristSpotDto.Id }, createdTouristSpotDto);
    }
}
