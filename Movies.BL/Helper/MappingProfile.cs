using AutoMapper;
using MoviesAPI.Dtos;
using MoviesAPI.Models;
using System.Runtime.InteropServices;

namespace MoviesAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDetailsDto>();
            CreateMap<MovieDto, Movie>()
                .ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}
