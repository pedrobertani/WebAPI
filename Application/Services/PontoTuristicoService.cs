using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PontoTuristicoService : IPontoTuristicoService
    {
        private readonly IPontoTuristicoRepository _repository;
        private readonly IMapper _mapper;

        public PontoTuristicoService(IPontoTuristicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PontoTuristicoDto>> GetAllAsync()
        {
            var touristSpots = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PontoTuristicoDto>>(touristSpots); 
        }

        public async Task<PontoTuristicoDto> GetByIdAsync(int id)
        {
            var touristSpot = await _repository.GetByIdAsync(id);
            return _mapper.Map<PontoTuristicoDto>(touristSpot); 
        }

        public async Task<PontoTuristicoDto> AddAsync(PontoTuristicoDto dto)
        {
            var touristSpot = _mapper.Map<PontoTuristico>(dto);
            await _repository.AddAsync(touristSpot);
            return _mapper.Map<PontoTuristicoDto>(touristSpot); 
        }
    }
}
