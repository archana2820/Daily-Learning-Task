using MediatR;

namespace CrudOperation.Features.Players.CreatePlayer
{
    public record CreatePlayerCommand(string Titile, string Platform, string Developer, string Publisher) : IRequest<int>;

}
