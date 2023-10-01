using AutoMapper;
using GameStore.Application.UseCases.Genres;
using GameStore.Application.UseCases.Genres.Commands.CreateGenre;
using GameStore.Application.UseCases.Genres.Commands.DeleteGenre;
using GameStore.Application.UseCases.Genres.Commands.UpdateGenre;
using GameStore.Domain.Entities;

namespace GenreStore.Application.Common.Mappings
{
    public class GenreMapping : Profile
    {
        public GenreMapping()
        {
            CreateMap<CreateGenreCommand, Genre>().ReverseMap();
            CreateMap<DeleteGenreCommand, Genre>().ReverseMap();
            CreateMap<UpdateGenreCommand, Genre>().ReverseMap();
            CreateMap<GenreResponse, Genre>().ReverseMap();
        }
    }
}
