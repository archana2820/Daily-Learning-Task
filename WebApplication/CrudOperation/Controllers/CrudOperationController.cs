using CrudOperation.DataBase;
using CrudOperation.Features.Players.CreatePlayer;
using CrudOperation.Features.Players.GetPlayerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        //  static private List<VideoGame> VideoGames = new List<VideoGame> {

        //  new VideoGame{
        //  Id = 1,
        //  Titile = "ABC",
        //  Platform="ps5" ,
        //  Developer="Insomnic games",
        //  Publisher="sony" ,
        //  },
        //  new VideoGame{
        //  Id = 2,
        //  Titile = "ABC",
        //  Platform="ps5" ,
        //  Developer="Insomnic games",
        //  Publisher="sony" ,
        //  },
        //  new VideoGame{
        //  Id = 3,
        //  Titile = "ABC",
        //  Platform="ps5" ,
        //  Developer="Insomnic games",
        //  Publisher="sony" ,
        //  }
        //};
        private readonly VideoGameDbContext _context;
        private readonly ISender _sender;

        public CrudOperationController(VideoGameDbContext context, ISender Sender)
        {
            _context = context;
            _sender = Sender;
        }
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            var games = await _context.GetAllVideoGamesFromSP();
            return Ok(games);

            //return Ok(await _context.VideoGames.ToListAsync());
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<VideoGame>> GetVideoGamesById(int id)
        //{
        //   // var game = await _context.VideoGames.FindAsync(id);

        //    var result = await _context.VideoGames
        //.FromSqlRaw("EXEC GetVideoGamesById @Id = {0}", id)
        //.ToListAsync();

        //    var game = result.FirstOrDefault();
        //    if (game is null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(game);
        //}
        //     [HttpPost]
        //     public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        //     {
        //         //if (newGame is null)
        //         //{
        //         //    return BadRequest();
        //         //}

        //         //_context.VideoGames.Add(newGame);
        //         //await _context.SaveChangesAsync();
        //         //return CreatedAtAction(nameof(GetVideoGamesById), new { id = newGame.Id }, newGame);

        //         await _context.Database.ExecuteSqlRawAsync(
        //    "EXEC AddVideoGames @Title = {0}, @Platform = {1}, @Developer = {2}, @Publisher = {3}",
        //    newGame.Titile, newGame.Platform, newGame.Developer, newGame.Publisher
        //);

        //         return Ok("Game added successfully.");
        //     }
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGamesById(int id)
        {
            var game = await _sender.Send(new GetPlayerByIdquery(id));
            if (game is null)
            {
                return NotFound();
            }
            return Ok(game);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlayerCommand command)
        {
            var id = await _sender.Send(command);
            return Ok(new { message = "VideoGame created", id });
        }
        [HttpPut("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<VideoGame>> UpdateVideoGame(int id, VideoGame updateGame)
        {
            //var game = await _context.VideoGames.FindAsync(id);
            //if (game is null)
            //{
            //    return NotFound();
            //}
            //game.Titile = updateGame.Titile;
            //game.Publisher = updateGame.Publisher;
            //game.Developer = updateGame.Developer;
            //game.Platform = updateGame.Platform;

            //await _context.SaveChangesAsync();
            await _context.Database.ExecuteSqlRawAsync(
       "EXEC updateVideoGames @Id = {0}, @Title = {1}, @Platform = {2}, @Developer = {3}, @Publisher = {4}",
       id, updateGame.Titile, updateGame.Platform, updateGame.Developer, updateGame.Publisher
   );
            return NoContent();
        }
        [HttpDelete("{id}")]
        //[Route("{id}")]
        public async Task<IActionResult> deleteVideoGame(int id)
        {
            //var game = await _context.VideoGames.FindAsync(id);
            //if (game is null)
            //{
            //    return NotFound();
            //}
            //_context.VideoGames.Remove(game);
            //await _context.SaveChangesAsync();
            //return NoContent();

            await _context.Database.ExecuteSqlRawAsync("DeleteVideoGames @Id = {0}", id);

            return NoContent();
        }
        //[HttpGet]
        //public ActionResult<List<VideoGame>> GetVideoGames()
        //{
        //    return Ok(VideoGames);
        //}


        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult<VideoGame> GetVideoGamesById(int id)
        //{
        //    var game = VideoGames.FirstOrDefault(a => a.Id == id);
        //    if (game is null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(game);
        //}
        //[HttpPost]
        //public ActionResult<VideoGame> AddVideoGame (VideoGame newGame)
        //{
        //    if(newGame is null)
        //    {
        //        return BadRequest();
        //    }
        //    newGame.Id = VideoGames.Max(a => a.Id) + 1;
        //    VideoGames.Add(newGame);
        //    return CreatedAtAction(nameof(GetVideoGamesById), new { id = newGame.Id }, newGame);

        //}
        //[HttpDelete]
        //[Route("{id}")]
        //public IActionResult deleteVideoGame(int id)
        //{
        //    var game = VideoGames.FirstOrDefault(a => a.Id == id);
        //    if (game is null)
        //    {
        //        return NotFound();
        //    }
        //    VideoGames.Remove(game);
        //    return NoContent();

        //}

    }
}
