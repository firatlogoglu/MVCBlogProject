﻿using MVCBlogProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogProject.MODEL.Entities
{
    public class Category:CoreEntity
    {
        public string CategoryName { get; set; }

        //todo: Her bir kategorinin birden fazla makalesi olabilir!
        
    }
}