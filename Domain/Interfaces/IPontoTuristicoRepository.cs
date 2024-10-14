using Domain.Entities;

namespace Domain.Interfaces;

public interface IPontoTuristicoRepository
{
    Task<List<PontoTuristico>> GetAllAsync();
    Task<PontoTuristico> GetByIdAsync(int id);
    Task AddAsync(PontoTuristico touristSpot);
}
