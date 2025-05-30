using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Application.Blogs.Queries.GetBlogs
{
    //public class GetBlogQuery : IRequestHandler<List<BlogVm>>
    //{
    //    public Task Handle(List<BlogVm> request, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public record GetBlogQuery() : IRequest<List<BlogVm>>;


}
