using MediatR;
using MicroService.Application.Blogs.Queries.GetBlogs;
using MicroServiceAPI.Domain.Repository;


namespace MicroService.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IblogRepository _repository;

        public GetBlogByIdQueryHandler(IblogRepository repository)
        {
            _repository = repository;
        }

        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null) return null;

            return new BlogVm
            {
                Id = blog.Id,
                Name = blog.Name,
                Description = blog.Description,
                Author = blog.Author,
            };
        }

    }
}
