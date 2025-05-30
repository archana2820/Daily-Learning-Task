using MediatR;
using MicroService.Application.Blogs.Queries.GetBlogs;

namespace MicroService.Application.Blogs.Queries.GetBlogById
{
    public record GetBlogByIdQuery(int Id) : IRequest<BlogVm>;
}
