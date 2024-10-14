using Application.DTOs;

namespace Application.Interfaces;

public interface IPontoTuristicoService
{
    Task<IEnumerable<PontoTuristicoDto>> GetAllAsync();
    Task<PontoTuristicoDto> GetByIdAsync(int id);
    Task<PontoTuristicoDto> AddAsync(PontoTuristicoDto dto);
}
