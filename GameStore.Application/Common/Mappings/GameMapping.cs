using AutoMapper;
using GameStore.Application.UseCases.CartItems.Response;
using GameStore.Application.UseCases.Games.Commands.CreateGame;
using GameStore.Application.UseCases.Games.Commands.DeleteGame;
using GameStore.Application.UseCases.Games.Commands.UpdateGame;
using GameStore.Domain.Entities;

namespace GameStore.Application.Common.Mappings
{
    public class GameMapping : Profile
    {
        public GameMapping()
        {
            CreateMap<CreateGameCommand, Game>().ReverseMap();
            CreateMap<DeleteGameCommand, Game>().ReverseMap();
            CreateMap<UpdateGameCommand, Game>().ReverseMap();
            CreateMap<GameResponse, Game>().ReverseMap();
        }
    }
}
