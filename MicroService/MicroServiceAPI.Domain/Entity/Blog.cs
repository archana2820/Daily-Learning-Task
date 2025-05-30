using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceAPI.Domain.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
