﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnetblogs.Repositorium.Blogs
{
    public class ListOfBlog
    {
        public List<Blog> Blogs { get; set; }

        public ListOfBlog()
        {
            Blogs = new List<Blog>();
            Blogs.Add(new Blog() { UrlToBlog = "xxx" });
            Blogs.Add(new Blog() { UrlToBlog = "xxx1" });
        }
    }
}