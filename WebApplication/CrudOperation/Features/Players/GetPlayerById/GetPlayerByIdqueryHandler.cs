using CrudOperation.DataBase;
using MediatR;

namespace CrudOperation.Features.Players.GetPlayerById
{
    public class GetPlayerByIdqueryHandler : IRequestHandler<GetPlayerByIdquery, VideoGame>
    {
        private readonly VideoGameDbContext _context;

        public GetPlayerByIdqueryHandler(VideoGameDbContext context)
        {
            _context = context;
        }
        public async Task<VideoGame> Handle(GetPlayerByIdquery request, CancellationToken cancellationToken)
        {
            var game = await _context.VideoGames.FindAsync(request.id);
            return game;
        }
    }
}
