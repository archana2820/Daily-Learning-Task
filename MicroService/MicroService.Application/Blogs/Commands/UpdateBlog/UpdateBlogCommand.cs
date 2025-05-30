using MediatR;

namespace MicroService.Application.Blogs.Commands.UpdateBlog
{
    public record UpdateBlogCommand(int Id, string Name, string Description, string Author, string ImageUrl) : IRequest<bool>;
}
