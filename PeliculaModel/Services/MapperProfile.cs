﻿using AutoMapper;
using PeliculaModel.Dtos;
using PeliculaModel.Entities;

namespace PeliculaModel.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Genero, GeneroDto>();
            CreateMap<GeneroCreateDto, Genero>();
        }
    }
}