using MediatR;
using MicroServiceAPI.Domain.Repository;

namespace MicroService.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IblogRepository _repository;

        public DeleteBlogCommandHandler(IblogRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null)
                return false;

            await _repository.DeleteAsync(request.Id); // ✅ Pass the ID only
            return true;
        }

    }
}
