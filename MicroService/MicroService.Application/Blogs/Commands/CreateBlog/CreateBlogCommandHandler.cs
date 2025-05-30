using MediatR;
using MicroServiceAPI.Domain.Entity;
using MicroServiceAPI.Domain.Repository;

namespace MicroService.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
    {
        private readonly IblogRepository _repository;

        public CreateBlogCommandHandler(IblogRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var newBlog = new Blog
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author,
                ImageUrl = request.ImageUrl,
                //CreatedAt = DateTime.UtcNow
            };

            var createdBlog = await _repository.CreateAsync(newBlog); // Assuming this returns a Blog
            return createdBlog.Id;
        }
    }
}
