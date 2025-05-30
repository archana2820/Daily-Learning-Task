using MediatR;

namespace CrudOperation.Features.Players.GetPlayerById
{
 
       public record GetPlayerByIdquery(int id) : IRequest<VideoGame>;

}
