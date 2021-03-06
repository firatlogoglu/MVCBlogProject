﻿using MVCBlogProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogProject.MODEL.Entities
{
    public class Article : CoreEntity
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }



        public virtual User Owner { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Tag> Tags { get; set; }



    }
}
