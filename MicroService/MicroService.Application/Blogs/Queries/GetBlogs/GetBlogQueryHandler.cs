using AutoMapper;
using MediatR;
using MicroServiceAPI.Domain.Repository;


namespace MicroService.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {

    private readonly IblogRepository _blogRepository;
        private readonly IMapper _Imapper;
    public GetBlogQueryHandler(IblogRepository blogRepository, IMapper mapper) 
    {
            _blogRepository = blogRepository;
            _Imapper = mapper;
    }
  
    public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
            var blog = await _blogRepository.GetALLBlogAsync();
            var bloglist = blog.Select(x => new BlogVm
            {
                Author = x.Author,
                Description = x.Description,
                Name = x.Name,
                Id = x.Id,

            }).ToList();
            //var bloglist = mapper.map<List<BlogVm>>(blog);

            return bloglist;
    }
}

}
