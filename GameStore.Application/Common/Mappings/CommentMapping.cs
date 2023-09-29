using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Application.UseCases.CartItems.Response;
using GameStore.Application.UseCases.Comments.Commands.CreateComment;
using GameStore.Application.UseCases.Comments.Commands.DeleteComment;
using GameStore.Application.UseCases.Comments.Commands.UpdateComment;
using GameStore.Domain.Entities;

namespace GameStore.Application.Common.Mappings
{
    public class CommentMapping:Profile
    {
        public CommentMapping()
        {
            CreateMap<CreateCommentCommand, Comment>().ReverseMap();
            CreateMap<DeleteCommentCommand, Comment>().ReverseMap();
            CreateMap<UpdateCommentCommand, Comment>().ReverseMap();
            CreateMap<CommentResponse, Comment>().ReverseMap();
        }
    }
}
