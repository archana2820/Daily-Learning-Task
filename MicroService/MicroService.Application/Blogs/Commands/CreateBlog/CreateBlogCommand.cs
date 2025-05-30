using MediatR;

namespace MicroService.Application.Blogs.Commands.CreateBlog
{
    public record CreateBlogCommand(string Name, string Description,string Author,string ImageUrl) : IRequest<int>;
}
