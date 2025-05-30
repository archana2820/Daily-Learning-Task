using MicroServiceAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm : Blog
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Author { get; set; }
    }
}
