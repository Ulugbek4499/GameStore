using AutoMapper;
using GameStore.Application.UseCases.Comments;
using GameStore.Application.UseCases.Comments.Commands.CreateComment;
using GameStore.Application.UseCases.Comments.Commands.DeleteComment;
using GameStore.Application.UseCases.Comments.Commands.IsDeleteComment;
using GameStore.Application.UseCases.Comments.Commands.RestoreDeleteComment;
using GameStore.Application.UseCases.Comments.Commands.UpdateComment;
using GameStore.Domain.Entities;

namespace GameStore.Application.Common.Mappings
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<CreateCommentCommand, Comment>().ReverseMap();
            CreateMap<DeleteCommentCommand, Comment>().ReverseMap();
            CreateMap<UpdateCommentCommand, Comment>().ReverseMap();
            CreateMap<IsDeletedCommentCommand, Comment>().ReverseMap();
            CreateMap<RestoreDeleteCommentCommand, Comment>().ReverseMap();
            CreateMap<CommentResponse, Comment>().ReverseMap();
        }
    }
}
