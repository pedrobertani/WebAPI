using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class PontoTuristicoProfile : Profile
{
    public PontoTuristicoProfile()
    {
        CreateMap<PontoTuristico, PontoTuristicoDto>().ReverseMap();
    }
}
