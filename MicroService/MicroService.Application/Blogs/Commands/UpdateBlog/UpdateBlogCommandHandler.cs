using MediatR;
using MicroServiceAPI.Domain.Repository;

namespace MicroService.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, bool>
    {
        private readonly IblogRepository _repository;

        public UpdateBlogCommandHandler(IblogRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null)
                return false;

            blog.Name = request.Name;
            blog.Description = request.Description;
            blog.Author = request.Author;
            blog.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(request.Id, blog); // ✅ Pass both id and blog
            return true;
        }
    }
}
