using CrudOperation.DataBase;
using MediatR;

namespace CrudOperation.Features.Players.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly VideoGameDbContext _context;

        public CreatePlayerCommandHandler (VideoGameDbContext context)
        {
            _context = context;
        }
  
        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var newGame = new VideoGame
            {
                Titile = request.Titile,
                Platform = request.Platform,
                Developer = request.Developer,
                Publisher = request.Publisher
            };

            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();

            return newGame.Id; // return the generated Id
        }
    }
}
