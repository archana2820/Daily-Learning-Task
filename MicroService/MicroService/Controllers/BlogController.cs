using MediatR;
using MicroService.Application.Blogs.Commands.CreateBlog;
using MicroService.Application.Blogs.Commands.DeleteBlog;
using MicroService.Application.Blogs.Commands.UpdateBlog;
using MicroService.Application.Blogs.Queries.GetBlogById;
using MicroService.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _mediator.Send(new GetBlogQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _mediator.Send(new GetBlogByIdQuery(id));
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
        {
            var blogId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBlogById), new { id = blogId }, blogId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, [FromBody] UpdateBlogCommand command)
        {
            if (id != command.Id)
                return BadRequest("Route id and command.Id must match.");

            var success = await _mediator.Send(command);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var success = await _mediator.Send(new DeleteBlogCommand(id));
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
