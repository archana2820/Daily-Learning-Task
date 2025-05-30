using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Application.Blogs.Commands.DeleteBlog
{
    public record DeleteBlogCommand(int Id) : IRequest<bool>;
}
